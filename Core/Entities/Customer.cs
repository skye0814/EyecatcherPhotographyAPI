using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Customer
    {
        [Key]
        public string? CustomerID { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set;}
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public int? ContactNumber { get; set; }

        // Nav prop
        public IEnumerable<BillingDetails>? BillingDetails { get; set; }
        public IEnumerable<TransactionHistory>? TransactionHistories { get; set; }

        [ForeignKey("Id")]
        public virtual IdentityUser? ApplicationUser { get; set; }
        public string? Id { get; set; }
       

    }
}
