using Core.Entities;
using Core.Helper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.WebModel.Response
{
    public class ProductCategoryResponse
    {
        private string? imageUrl;
        private BaseUrlUtility baseUrlUtility = new BaseUrlUtility(new HttpContextAccessor());

        public long ProductCategoryID { get; set; }
        public string? CategoryName { get; set; }
        public string? CategoryDescription { get; set; }
        public string? ImageUrl { 
            get => imageUrl;
            set => imageUrl = (string.IsNullOrEmpty(value)) ? string.Empty : $"{baseUrlUtility.GetBaseUrl()}/{value}";
        }

        // Navprop
        public IEnumerable<Product>? Products { get; set; }
    }
}
