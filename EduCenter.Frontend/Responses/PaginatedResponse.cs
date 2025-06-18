namespace EduCenter.Frontend.Responses;

public class PaginatedResponse<T> where T : class
{

    public IEnumerable<T>? Items { get; set; }


    public int TotalCount { get; set; }
    public int Page { get; set; }

    public int PageSize { get; set; }


}
