using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyecatcherPhotography.Services.Exceptions
{
    public class CustomerServiceException : Exception
    {
        public CustomerServiceException(Exception innerException) : base(string.Empty, innerException)
        {
        }
        public CustomerServiceException(string message) : base(message)
        {
        }
    }
}