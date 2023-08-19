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
        public int TotalCount {get; set;}
        public int TotalPages {get; set;}

        public PaginationFilterResponse(int pageNumber, int pageSize, IEnumerable<T> data, int totalCount)
        {
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
            this.Data = data;
            this.TotalCount = totalCount;
            this.TotalPages = data.Count() == 0 ? 0 : data.Count() < pageSize ? pageNumber : (int)Math.Ceiling((double)totalCount / data.Count());


        }
    }
}
