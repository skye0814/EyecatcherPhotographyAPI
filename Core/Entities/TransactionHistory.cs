using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class TransactionHistory
    {
        [Key]
        public long TransactionHistoryID { get; set; }
        public string? Status { get; set;}

        //Navprop
        public IEnumerable<BillingDetails>? BillingDetails { get; set; }
        [ForeignKey("CustomerID")]
        public virtual Customer? Customer { get; set; }
        public Guid? CustomerID { get; set; }
    }
}
