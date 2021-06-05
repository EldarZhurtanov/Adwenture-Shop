using Core.Managers.Helpers;
using Core.Managers.ManagerInterfaces;
using DataContracts;
using Model;
using Model.Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Managers.MangersImplementations
{
    public class CartManager : ICartManager
    {
        private readonly DbContext context = new AdwentureWorksContext();
        private readonly UnitOfWork unitOfWork;

        public CartManager()
        {
            unitOfWork = new UnitOfWork(context);
        }
        public void AddCartItem(string sessionID, int productID, int quantity)
        {
            bool productExist = unitOfWork.Product.Get(productID) != null;

            if (!productExist)
                return;

            bool itemAlreadyExist = unitOfWork.ShoppingCart.GetList(a => a.ShoppingCartID == sessionID && a.ProductID == productID).Count() > 0;
            var inventory = unitOfWork.ProductInventory.GetList(a => a.ProductID == productID).FirstOrDefault();
            bool inStockEnough = inventory != null && inventory.Quantity > 0;

            if(itemAlreadyExist)
            {
                ChangeCartItemQuantity(sessionID, productID, quantity);
                return;
            }

            var newItem = new ShoppingCartItem()
            {
                ProductID = productID,
                ShoppingCartID = sessionID,
                DateCreated = DateTime.Now,
                ModifiedDate = DateTime.Now,
                Quantity = inStockEnough ? quantity : inventory.Quantity
            };

            unitOfWork.ShoppingCart.Create(newItem);
            unitOfWork.Complete();
        }

        public void ChangeCartItemQuantity(string sessionID, int productID, int quantity)
        {
            bool productExist = unitOfWork.Product.Get(productID) != null;

            if (!productExist)
                return;

            bool itemAlreadyExist = unitOfWork.ShoppingCart.GetList(a => a.ShoppingCartID == sessionID && a.ProductID == productID).Count() > 0;
            var inventory = unitOfWork.ProductInventory.GetList(a => a.ProductID == productID).FirstOrDefault();
            bool inStockEnough = inventory != null && inventory.Quantity > 0;

            if (!itemAlreadyExist)
            {
                AddCartItem(sessionID, productID, quantity);
                return;
            }

            var item = unitOfWork.ShoppingCart.GetList(a=> a.ProductID == productID && a.ShoppingCartID == sessionID).FirstOrDefault();
            if(quantity == 0)
            {
                unitOfWork.ShoppingCart.Delete(item);
                unitOfWork.Complete();
                return;
            }

            item.Quantity = inStockEnough ? quantity : inventory.Quantity;

            unitOfWork.ShoppingCart.Update(item);
            unitOfWork.Complete();

        }

        public void Delete(string sessionID)
        {
            var items = unitOfWork.ShoppingCart.GetList(a => a.ShoppingCartID == sessionID);

            foreach(var item in items)
            {
                unitOfWork.ShoppingCart.Delete(item);
            }
            unitOfWork.Complete();
        }

        public IEnumerable<CartItemDTO> GetCart(string sessionID)
        {
            var items = unitOfWork.ShoppingCart.GetList(a => a.ShoppingCartID == sessionID);

            var itemsDTOs = new List<CartItemDTO>();
            foreach (var item in items)
            {
                var product = unitOfWork.Product.Get(item.ProductID);

                var itemDTOs = CartItemDTOCreator.Create(item, product);
                itemsDTOs.Add(itemDTOs);
            }
            return itemsDTOs;
        }
    }
}
