using Core.Interface;

namespace Core.WebModel.Request
{
    public class PaginationFilterRequest : IEntity
    {
        private int _pageSize;

        public bool isAscending { get; set; } = true;
        public int PageNumber { get; set; } = 1;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value < 10) ? 10 : value;
        }
        public string? Search {get; set;} = string.Empty;
        public string SortBy {get; set;} = string.Empty;
        
    }
}
