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
        public int TotalCountPerPage {get; set;}
        public int TotalCount {get; set;}
        public int TotalPage {get; set;}

        public PaginationFilterResponse(int pageNumber, int pageSize, IEnumerable<T> data, int totalCount)
        {
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
            this.Data = data;
            this.TotalCountPerPage = data.Count();
            this.TotalCount = totalCount;
            this.TotalPage = (int)Math.Ceiling((float)data.Count()/(float)totalCount);
        }
    }
}
