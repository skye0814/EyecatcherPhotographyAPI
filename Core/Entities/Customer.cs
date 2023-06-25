using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set;}
        public string? LastName { get; set; }
        public string? EmailAddress { get; set; }
        public string? Address { get; set; }
        public int? ContactNumber { get; set; }

        // Nav prop
        public IEnumerable<BillingDetails>? BillingDetails { get; set; }

        [ForeignKey("SystemUserID")]
        public virtual SystemUser? SystemUser { get; set; }

    }
}
