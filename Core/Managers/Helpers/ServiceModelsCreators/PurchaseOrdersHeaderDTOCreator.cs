using Core.Managers.Helpers.Extensions;
using DataContracts;
using Model.Models;
using System.Collections.Generic;
using System.Configuration;

namespace Core.Managers.Helpers
{
    public static class PurchaseOrdersHeaderDTOCreator
    {
        private static readonly Dictionary<int, string> statusNames;
        public static PurchaseOrdersHeaderDTO Create(PurchaseOrderHeader purchaseOrdersHeader, ShipMethod shipMethod, Person managerPerson)
        {
            int? EmployeeID = null;
            string EmployeeFullName = null;

            if (managerPerson != null)
            {
                EmployeeID = managerPerson.BusinessEntityID;
                EmployeeFullName = managerPerson.GetFullName();
            }

            return new PurchaseOrdersHeaderDTO()
            {
                PurchaseOrderID = purchaseOrdersHeader.PurchaseOrderID,
                Freight = purchaseOrdersHeader.Freight,
                TaxAmt = purchaseOrdersHeader.TaxAmt,
                OrderDate = purchaseOrdersHeader.OrderDate,
                ShipDate = purchaseOrdersHeader.ShipDate,
                TotalDue = purchaseOrdersHeader.TotalDue,
                Status = purchaseOrdersHeader.Status,
                SubTotal = purchaseOrdersHeader.SubTotal,
                StatusName = statusNames[purchaseOrdersHeader.Status],
                EmployeeID = EmployeeID,
                EmployeeFullName = EmployeeFullName,
                ShipMethodID = shipMethod.ShipMethodID,
                ShipMethodName = shipMethod.Name
            };
        }
        static PurchaseOrdersHeaderDTOCreator()
        {
            statusNames = new Dictionary<int, string>()
            {
                {1, ConfigurationManager.AppSettings.Get("Status1") },
                {2, ConfigurationManager.AppSettings.Get("Status2") },
                {3, ConfigurationManager.AppSettings.Get("Status3") },
                {4, ConfigurationManager.AppSettings.Get("Status4") }
            };
        }
    }
}
