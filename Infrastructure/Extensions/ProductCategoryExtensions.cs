using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Extensions
{
    public static class ProductCategoryExtensions
    {
        public static void Map(this ProductCategory dbCategory, ProductCategory category)
        {
            dbCategory.ProductCategoryID = category.ProductCategoryID;
            dbCategory.CategoryName = category.CategoryName;
            dbCategory.CategoryDescription = category.CategoryDescription;
        }
    }
}
