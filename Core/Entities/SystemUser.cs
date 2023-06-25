using Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class SystemUser 
    {
        public long SystemUserID { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public bool isAdmin { get; set; }
        public bool isCustomer { get; set; }
    }
}
