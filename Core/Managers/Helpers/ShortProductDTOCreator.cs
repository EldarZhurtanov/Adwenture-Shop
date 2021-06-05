using DataContracts;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Managers.Helpers
{
    public static class ShortProductDTOCreator
    {
        public static ShortProductDTO Create(Product product, ProductProductPhoto thumbnail, ProductInventory inventory, ProductSubcategory subcategory)
        {
            ShortProductDTO shortProductDTO = new ShortProductDTO();

            if (!(product is null))
            {
                shortProductDTO.ProductID = product.ProductID;
                shortProductDTO.Name = product.Name;
                shortProductDTO.Color = product.Color;
                shortProductDTO.ProductNumber = product.ProductNumber;
                shortProductDTO.StandardCost = product.StandardCost;
            }

            if (!(thumbnail is null))
                shortProductDTO.ThumbNailPhotoID = thumbnail.ProductPhotoID;

            if (!(inventory is null))
                shortProductDTO.Quantity = inventory.Quantity;
            
            if (!(subcategory is null))
                shortProductDTO.SubcategoryName = subcategory.Name;

            return shortProductDTO;
        }
    }
}
