using AutoMapper;
using Core.Managers.Helpers;
using Core.Managers.Helpers.CoreModelsHelpers;
using Core.Managers.ManagerInterfaces;
using Core.Models;
using DataContracts;
using Microsoft.AspNet.Identity.EntityFramework;
using Model;
using Model.Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;

namespace Core.Managers.MangersImplementations
{
    public class PurchaseOrderManager : IPurchaseOrderManager
    {
        private readonly UnitOfWork unitOfWork;
        private readonly DbContext context = new AdwentureWorksContext();
        private readonly IdentityDbContext<ApplicationUser> identityDbContext = new IdentityContext();
        private readonly CartManager cartManager = new CartManager();
        private readonly IMapper mapper;

        public PurchaseOrderManager()
        {
            unitOfWork = new UnitOfWork(context, identityDbContext);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<PurchaseOrderDetail, PurchaseOrderDetailRowDTO>());
            mapper = new Mapper(config);
        }

        public IEnumerable<PurchaseOrdersHeaderDTO> GetPurchaseOrderHeadersDTO(PurchaseOrderFilterDTO purchaseOrderFilterDTO)
        {
            IEnumerable<PurchaseOrderHeader> purchaseOrdersHeaders = null;

            if (purchaseOrderFilterDTO.UserRole == "owner")
                purchaseOrdersHeaders = unitOfWork.PurchaseOrderHeader.GetList()
                    .Skip(purchaseOrderFilterDTO.Skip)
                    .Take(purchaseOrderFilterDTO.Take);

            else if (purchaseOrderFilterDTO.UserRole == "admin")
            {
                var employeeId = unitOfWork.AspNetUsersBusinesEntity
                    .GetList(a => a.Id == purchaseOrderFilterDTO.UserID)
                    .FirstOrDefault()
                    .BusinessEntityID.Value;

                purchaseOrdersHeaders = unitOfWork.PurchaseOrderHeader.GetList(e => e.EmployeeID == employeeId)
                    .Skip(purchaseOrderFilterDTO.Skip)
                    .Take(purchaseOrderFilterDTO.Take);
            }
            else
            {
                var userId = unitOfWork.AspNetUsersBusinesEntity
                    .GetList(a => a.Id == purchaseOrderFilterDTO.UserID)
                    .FirstOrDefault()
                    .BusinessEntityID.Value;

                purchaseOrdersHeaders = unitOfWork.PurchaseOrderHeader.GetList(e => e.PersonID == userId)
                    .Skip(purchaseOrderFilterDTO.Skip)
                    .Take(purchaseOrderFilterDTO.Take);
            }

            return GetPurchaseOrderHeaderDTOs(purchaseOrdersHeaders);
        }
        public PurchaseOrderDetailDTO GetPurchaseOrderDetailDTO(Guid orderGuidId)
        {
            var purchaseOrderDetailDTO = new PurchaseOrderDetailDTO();

            var PurchaseOrderHeader = unitOfWork.PurchaseOrderHeader.GetList(a => a.rowguid == orderGuidId).FirstOrDefault();
            if (PurchaseOrderHeader == null)
                return null;

            purchaseOrderDetailDTO.PurchaseDetailRowDTOs = GetPurchaseOrderDetailRowDTOs(PurchaseOrderHeader);
            purchaseOrderDetailDTO.PurchaseOrdersDTO = GetPurchaseOrderHeaderDTO(PurchaseOrderHeader);

            return purchaseOrderDetailDTO;
        }
        public PurchaseOrderDetailDTO Create(string cartId, string userId)
        {
            var aspNetBusinessEntity = unitOfWork.AspNetUsersBusinesEntity.GetList(e => e.Id == userId).FirstOrDefault();
            var cartItems = unitOfWork.ShoppingCart.GetList(e => e.ShoppingCartID == cartId).ToList();

            if (aspNetBusinessEntity == null || cartItems == null)
                return null;

            var bussinesEntityAdress = unitOfWork.BusinessEntityAddress.GetList(e => e.BusinessEntityID == aspNetBusinessEntity.BusinessEntityID).FirstOrDefault().Address;
            var address = unitOfWork.Address.GetList(e => e.AddressID == bussinesEntityAdress.AddressID).FirstOrDefault();
            var stateProvince = unitOfWork.StateProvince.Get(address.StateProvinceID);
            var taxRate = unitOfWork.SalesTaxRate.GetList(e => e.StateProvinceID == stateProvince.StateProvinceID).FirstOrDefault();

            int shipMethodId = Convert.ToInt32(ConfigurationManager.AppSettings.Get("ShipMethodId"));
            var shipMethod = unitOfWork.ShipMethod.Get(shipMethodId);

            var salesPerson = unitOfWork.SalesPerson.GetList(e => e.TerritoryID == stateProvince.TerritoryID).OrderBy(e => e.SalesLastYear).FirstOrDefault();

            if (salesPerson == null)
            {
                var salesPersons = unitOfWork.SalesPerson.GetList().ToList();
                salesPerson = salesPersons[new Random().Next(salesPersons.Count - 1)];
            }

            var purchaseOrderHeader = PurchaseOrderHeaderCreator.Create(cartItems, aspNetBusinessEntity, taxRate, shipMethod, salesPerson);

            unitOfWork.PurchaseOrderHeader.Create(purchaseOrderHeader);
            unitOfWork.Complete();

            foreach (var cartItem in cartItems)
            {
                var productReserve = cartItem.Product.ProductReserve;
                var purchaseOrderDetail = PurchaseOrderDetailCreator.Create(purchaseOrderHeader, cartItem, cartItem.Product, cartItem.Product.ProductInventory.FirstOrDefault(), productReserve);
                unitOfWork.PurchaseOrderDetail.Create(purchaseOrderDetail);
                unitOfWork.Complete();

                if (productReserve != null)
                {
                    productReserve.Quantity = Convert.ToInt16(purchaseOrderDetail.ReceivedQty + productReserve.Quantity.Value);
                    unitOfWork.Complete();
                }
            }

            cartManager.Delete(cartId);

            return GetPurchaseOrderDetailDTO(purchaseOrderHeader.rowguid.Value);
        }
        public void Ship(Guid orderGuidId, string managerId)
        {
            var purchaseOrderHeader = unitOfWork.PurchaseOrderHeader.GetList(e => e.rowguid == orderGuidId).FirstOrDefault();

            if (purchaseOrderHeader == null || purchaseOrderHeader.Status != 2)
                return;

            purchaseOrderHeader.Status = 3;

            var purchaseOrderDetails = unitOfWork.PurchaseOrderDetail.GetList(e => e.PurchaseOrderID == purchaseOrderHeader.PurchaseOrderID);
            foreach (var purchaseOrderDetail in purchaseOrderDetails)
            {
                var productReserve = purchaseOrderDetail.Product.ProductReserve;
                var inventory = purchaseOrderDetail.Product.ProductInventory.FirstOrDefault();

                if (productReserve != null && productReserve.Quantity.HasValue)
                {
                    productReserve.Quantity = Convert.ToInt16(productReserve.Quantity.Value - purchaseOrderDetail.ReceivedQty);

                    if (productReserve.Quantity <= 0)
                        unitOfWork.ProductReserve.Delete(productReserve);
                }
                if (inventory == null || inventory.Quantity < purchaseOrderDetail.ReceivedQty)
                    return;
                inventory.Quantity -= Convert.ToInt16(purchaseOrderDetail.ReceivedQty);
                unitOfWork.Complete();
            }

            var address = purchaseOrderHeader.Person.BusinessEntity.BusinessEntityAddress.FirstOrDefault().Address;
            var user = unitOfWork.AspNetUsersBusinesEntity.GetList(e => e.BusinessEntityID == purchaseOrderHeader.PersonID).FirstOrDefault();
            var shipCustomerDTO = ShipCustomerDTOCreator.Create(purchaseOrderHeader.Person, address, unitOfWork.ApplicationUser.GetEmailAsync(user.Id).Result);

            List<ShipPurchaseOrderDetailDTO> shipPurchaseOrderDetailDTOs = new List<ShipPurchaseOrderDetailDTO>();

            foreach (var purchaseOrderDetail in purchaseOrderDetails)
                shipPurchaseOrderDetailDTOs.Add(ShipPurchaseOrderDetailDTOCreator.Create(purchaseOrderDetail.Product, purchaseOrderDetail));

            var forSHIP = ShipPurchaseOrderDTOCreator.Create(purchaseOrderHeader, shipPurchaseOrderDetailDTOs, shipCustomerDTO);

        }
        public void Close(Guid orderGuidId, string managerId)
        {
            var purchaseOrderHeader = unitOfWork.PurchaseOrderHeader.GetList(e => e.rowguid == orderGuidId).FirstOrDefault();

            if (purchaseOrderHeader == null || purchaseOrderHeader.Status != 2)
                return;

            purchaseOrderHeader.Status = 4;

            var purchaseOrderDetails = unitOfWork.PurchaseOrderDetail.GetList(e => e.PurchaseOrderID == purchaseOrderHeader.PurchaseOrderID);
            foreach (var purchaseOrderDetail in purchaseOrderDetails)
            {
                var productReserve = purchaseOrderDetail.Product.ProductReserve;

                if (productReserve != null && productReserve.Quantity.HasValue)
                {
                    productReserve.Quantity = Convert.ToInt16(productReserve.Quantity.Value - purchaseOrderDetail.ReceivedQty);

                    if (productReserve.Quantity <= 0)
                        unitOfWork.ProductReserve.Delete(productReserve);
                }
                unitOfWork.Complete();
            }
        }

        public IEnumerable<PurchaseOrderDetailRowDTO> GetPurchaseOrderDetailRowDTOs(PurchaseOrderHeader purchaseOrdersHeaders)
        {
            var PurchaseOrderDetailRowDTOs = new List<PurchaseOrderDetailRowDTO>();

            var purchaseOrderDetail = unitOfWork.PurchaseOrderDetail.GetList(a => a.PurchaseOrderID == purchaseOrdersHeaders.PurchaseOrderID);

            foreach (var purchaseOrderDetailRow in purchaseOrderDetail)
                PurchaseOrderDetailRowDTOs.Add(mapper.Map<PurchaseOrderDetailRowDTO>(purchaseOrderDetailRow));

            return PurchaseOrderDetailRowDTOs;
        }
        public PurchaseOrdersHeaderDTO GetPurchaseOrderHeaderDTO(PurchaseOrderHeader purchaseOrdersHeader)
        {
            var shipMetod = unitOfWork.ShipMethod.Get(purchaseOrdersHeader.ShipMethodID.Value);

            Person person = null;
            if (purchaseOrdersHeader.EmployeeID.HasValue)
            {
                person = unitOfWork.Person.Get(purchaseOrdersHeader.EmployeeID.Value);
            }

            return PurchaseOrdersHeaderDTOCreator.Create(purchaseOrdersHeader, shipMetod, person);
        }
        public IEnumerable<PurchaseOrdersHeaderDTO> GetPurchaseOrderHeaderDTOs(IEnumerable<PurchaseOrderHeader> purchaseOrdersHeaders)
        {
            var purchaseOrdersHeaderDTOs = new List<PurchaseOrdersHeaderDTO>();

            foreach (var purchaseOrdersHeader in purchaseOrdersHeaders)
            {
                purchaseOrdersHeaderDTOs.Add(GetPurchaseOrderHeaderDTO(purchaseOrdersHeader));
            }
            return purchaseOrdersHeaderDTOs;
        }
        public IEnumerable<PurchaseOrdersHeaderDTO> GetUserPurchaseOrderHeaderDTOs(Customer customer, int skip, int take)
        {
            var purchaseOrdersHeaders = unitOfWork.PurchaseOrderHeader.GetList(e => e.PersonID == customer.PersonID).Skip(skip).Take(take);

            return GetPurchaseOrderHeaderDTOs(purchaseOrdersHeaders);
        }
        public IEnumerable<PurchaseOrdersHeaderDTO> GetManagerPurchaseOrderHeaderDTOs(SalesPerson salesPerson, int skip, int take)
        {
            var purchaseOrdersHeaders = unitOfWork.PurchaseOrderHeader.GetList(e => e.EmployeeID == salesPerson.BusinessEntityID).Skip(skip).Take(take);

            return GetPurchaseOrderHeaderDTOs(purchaseOrdersHeaders);
        }
        public int GetCountOfPurchaseOrderHeaderDTOs(PurchaseOrderFilterDTO purchaseOrderFilterDTO)
        {
            IQueryable<PurchaseOrderHeader> purchaseOrderHeaders = null;

            if (purchaseOrderFilterDTO.UserRole == "owner")
                purchaseOrderHeaders = unitOfWork.PurchaseOrderHeader.GetList();

            else if (purchaseOrderFilterDTO.UserRole == "admin")
            {
                var employeeId = unitOfWork.AspNetUsersBusinesEntity
                    .GetList(a => a.Id == purchaseOrderFilterDTO.UserID)
                    .FirstOrDefault()
                    .BusinessEntityID.Value;
                purchaseOrderHeaders = unitOfWork.PurchaseOrderHeader.GetList(e => e.EmployeeID == employeeId);
            }
            else
            {
                var userId = unitOfWork.AspNetUsersBusinesEntity
                    .GetList(a => a.Id == purchaseOrderFilterDTO.UserID)
                    .FirstOrDefault()
                    .BusinessEntityID.Value;
                purchaseOrderHeaders = unitOfWork.PurchaseOrderHeader.GetList(e => e.PersonID == userId);
            }
            return purchaseOrderHeaders.Count();
        }
    }
}