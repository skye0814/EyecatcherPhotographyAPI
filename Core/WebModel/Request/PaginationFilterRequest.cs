using Core.Interface;

namespace Core.WebModel.Request
{
    public class PaginationFilterRequest : IEntity
    {
        private int _pageSize;
        private int _pageNumber;

        public bool isAscending { get; set; } = true;
        public int PageNumber
        {
            get => _pageNumber;
            set => _pageNumber = (value < 1) ? 1 : value;
        }
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value < 1) ? 1 : value;
        }
        public string? Search {get; set;} = string.Empty;
        public string SortBy {get; set;} = string.Empty;
        
    }
}
