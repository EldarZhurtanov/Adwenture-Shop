using DataContracts;
using Model.Models;

namespace Core.Managers.Helpers
{
    public static class ShortProductDTOCreator
    {
        public static ShortProductDTO Create(Product product, ProductProductPhoto thumbnail, ProductInventory inventory, ProductSubcategory subcategory, ProductReserve productReserve)
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
            {
                shortProductDTO.Quantity = inventory.Quantity;
                if (productReserve != null)
                    shortProductDTO.Quantity -= productReserve.Quantity;
            }

            if (!(subcategory is null))
                shortProductDTO.SubcategoryName = subcategory.Name;

            return shortProductDTO;
        }
    }
}
