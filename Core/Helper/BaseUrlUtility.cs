using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Helper
{
    public class BaseUrlUtility
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public BaseUrlUtility(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public string GetBaseUrl()
        {
            try
            {
                var request = httpContextAccessor.HttpContext.Request;

                var scheme = request.Scheme;
                var host = request.Host;

                return $"{scheme}://{host}";
            }
            catch(Exception ex)
            {
                throw new Exception($"Error occured in getting base URL: {ex.Message}");
            }
        }
    }
}
