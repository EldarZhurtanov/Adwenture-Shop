using Model.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace Core.Managers.Helpers
{
    public static class PurchaseOrderHeaderCreator
    {
        public static PurchaseOrderHeader Create(IEnumerable<ShoppingCartItem> cartItems, AspNetUsersBusinesEntity aspNetUsers
            , SalesTaxRate taxRate, ShipMethod shipMethod, SalesPerson salesPerson)
        {
            decimal subTotal = cartItems.Sum(e => e.Product.StandardCost);
            decimal taxAmt = subTotal + subTotal * taxRate.TaxRate / 100;

            decimal? weight = cartItems.Sum(e => e.Product.Weight.HasValue ? e.Product.Weight : null);

            decimal? freight = 0;

            if (weight.HasValue)
                freight = weight * shipMethod.ShipRate > shipMethod.ShipBase ? weight * shipMethod.ShipRate : shipMethod.ShipBase;

            decimal? totalDue = subTotal + taxAmt + freight;

            return new PurchaseOrderHeader()
            {
                RevisionNumber = Convert.ToByte(ConfigurationManager.AppSettings.Get("RevisionNumber")),
                Status = 2,
                EmployeeID = salesPerson.BusinessEntityID,
                PersonID = aspNetUsers.BusinessEntityID,
                ShipMethodID = shipMethod.ShipMethodID,
                OrderDate = System.DateTime.Now,
                SubTotal = subTotal,
                TaxAmt = taxAmt,
                Freight = freight ?? 0,
                TotalDue = totalDue ?? 0,
                ModifiedDate = DateTime.Now,
                rowguid = Guid.NewGuid()
            };
        }
    }
}
