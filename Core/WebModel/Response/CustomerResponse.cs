using Core.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.WebModel.Response
{
    public class CustomerResponse
    {
        public string? CustomerID { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public int? ContactNumber { get; set; }
        public UserWebResponse? ApplicationUser { get; set; }
    }
}
