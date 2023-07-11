using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EyecatcherPhotographyAPI.Helper
{
    public static class PaginationFilter
    {
        public static object PaginationMap<T>(IEnumerable<T> data, int pageNumber, int pageSize)
        {
            return new
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                Data = data,
                TotalCount = data.Count(),
                TotalPages = (int)Math.Ceiling((float)data.Count() / (float)pageSize)
        };
        }

    }
}
