using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class ProductCategoryResponse
    {
        [Key]
        public long ProductCategoryID { get; set; }
        public string? CategoryName { get; set; }
        public string? CategoryDescription { get; set; }

        // Navprop
        public List<string>? Products { get; set; }
    }
}
