using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.WebModel.Response
{
    public class PaginationFilterResponse<T>
    {
        public int PageNumber {get; set;}
        public int PageSize { get; set;}
        public IEnumerable<T> Data {get; set;}

        // Total count of GetAll
        public int TotalCount {get; set;}
        // Total count based on the page size and page number
        public int Rows {get; set;}

        public PaginationFilterResponse(int pageNumber, int pageSize, IEnumerable<T> data, int rows, int totalCount)
        {
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
            this.Data = data;
            this.Rows = data.Count();
            this.TotalCount = totalCount;
        }
    }
}
