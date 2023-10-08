using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyecatcherPhotography.Services.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(Exception innerException) : base(string.Empty, innerException)
        {
        }
        public NotFoundException(string message) : base(message)
        {
        }
    }
}