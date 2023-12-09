using Microsoft.AspNetCore.Identity;
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
        public long CartID { get; set;}
        public Product? Product { get; set; }
        public float? Amount { get; set; }
        public int Quantity { get; set; }

        [ForeignKey("Id")]
        public virtual IdentityUser ApplicationUser { get; set; }
    }
}
