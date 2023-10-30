using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Cart
    {
        [Key]
        public long CartID { get; set; }
        public int Quantity { get; set; }
        public double TotalAmounts { get; set; }


        // Nav prop
        public string? CustomerID { get; set; }
        public IEnumerable<Product>? Products { get; set;}

        [ForeignKey("BillingDetailsID")]
        public virtual BillingDetails? BillingDetails { get; set; }
        public Guid? BillingDetailsID { get; set; }
    }
}
