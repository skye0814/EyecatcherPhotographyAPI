using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class Product
    {
        public long ProductID { get; set; }
        public string? ProductName { get; set; }
        public string? ProductTag { get; set; }
        public string? ProductDescription { get; set; }
        public string? FreeText1 { get; set; }
        public string? FreeText2 { get; set; }
        public string? FreeText3 { get; set; }
        public string? FreeText4 { get; set; }
        public double Price { get; set; }
        public string? Label { get; set; }

  

        //Navprop
        [ForeignKey("ProductCategoryID")]
        public virtual ProductCategory? ProductCategory { get; set; }

        // This is to modify the foreign key
        public long? ProductCategoryID { get; set; }
    }
}
