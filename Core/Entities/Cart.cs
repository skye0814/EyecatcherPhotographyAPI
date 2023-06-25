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
        public double TotalAmount { get; set; }

        //Navigation prop
        [ForeignKey("CustomerID")]
        public virtual Customer? Customer { get; set; }
        public IEnumerable<Product>? Products { get; set;}
    }
}
