using DataContracts;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Managers.Helpers
{
    public static class DetailProductDTOCreator
    {
        public static DetailProductDTO Create(Product product, IEnumerable<ProductProductPhoto> photos, ProductInventory inventory, ProductDescription description, ProductSubcategory subcategory)
        {
            DetailProductDTO detailProductDTO = new DetailProductDTO();

            if (!(product is null))
            {
                detailProductDTO.ProductID = product.ProductID;
                detailProductDTO.Name = product.Name;
                detailProductDTO.Color = product.Color;
                detailProductDTO.ProductNumber = product.ProductNumber;
                detailProductDTO.StandardCost = product.StandardCost;
            }

            if (!(photos is null))
            {
                List<int> idPhotosEnumerable = new List<int>();

                foreach (var photo in photos)
                    idPhotosEnumerable.Add(photo.ProductPhotoID);
                detailProductDTO.LargePhotosIDs = idPhotosEnumerable;
            }

            if (!(inventory is null))
                detailProductDTO.Quantity = inventory.Quantity;

            if (!(description is null))
                detailProductDTO.Description = description.Description;

            if (!(subcategory is null))
                detailProductDTO.SubcategoryName = subcategory.Name;

            return detailProductDTO;
        }
    }
}
