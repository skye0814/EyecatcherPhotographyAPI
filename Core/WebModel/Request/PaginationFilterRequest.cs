using Core.Interface;

namespace Core.WebModel.Request
{
    public class PaginationFilterRequest : IEntity
    {
        public bool isAscending { get; set; } = true;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string? Search {get; set;} = string.Empty;
        public string SortBy {get; set;} = string.Empty;
    }
}
