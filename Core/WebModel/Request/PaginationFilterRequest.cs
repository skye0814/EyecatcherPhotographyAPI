using Core.Interface;

namespace Core.WebModel.Request
{
    public class PaginationFilterRequest : IEntity
    {
        string? sort {get; set;}
        int pageNumber = 1;
        int pageSize = 10;
        string? search {get; set;} = string.Empty;
        string sortBy {get; set;} = string.Empty;
    }
}
