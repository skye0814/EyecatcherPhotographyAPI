using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Extensions
{
    public static class ProductExtensions
    {
        public static void Map(this Product dbProduct, Product product)
        {
            dbProduct.ProductID = product.ProductID;
            dbProduct.ProductName = product.ProductName;
            dbProduct.ProductTag = product.ProductTag;
            dbProduct.ProductDescription = product.ProductDescription;
            dbProduct.FreeText1 = product.FreeText1;
            dbProduct.FreeText2 = product.FreeText2;
            dbProduct.FreeText3 = product.FreeText3;
            dbProduct.FreeText4 = product.FreeText4;
            dbProduct.Price = product.Price;
            dbProduct.ProductCategoryID = product.ProductCategoryID;
        }

        public static void MapMultiple(this IEnumerable<Product> dbProducts, IEnumerable<Product> products)
        {
            try
            {
                foreach (var dbProduct in dbProducts) 
                {
                    foreach (var product in products)
                    {
                        dbProduct.ProductID = product.ProductID;
                        dbProduct.ProductName = product.ProductName;
                        dbProduct.ProductTag = product.ProductTag;
                        dbProduct.Price = product.Price;
                        dbProduct.FreeText1 = product.FreeText1;
                        dbProduct.FreeText1 = product.FreeText2;
                        dbProduct.FreeText1 = product.FreeText3;
                        dbProduct.FreeText1 = product.FreeText4;
                        dbProduct.ProductCategoryID = product.ProductCategoryID;

                        // We cannot edit this
                        //dbProduct.ProductCategory.ProductCategoryID = product.ProductCategory.ProductCategoryID;
                    }
                }
            }
            catch(Exception ex)
            {
                throw new Exception($"There was an error occured during mapping multiple entities: {ex.Message}");
            }
        }
    }
}
