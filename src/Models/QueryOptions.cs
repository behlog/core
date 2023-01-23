namespace Behlog.Core.Models;

/// <summary>
/// Base class for Query filter data classes. Can be used to filter query results 
/// and apply pagingations to the result.
/// </summary>
public class QueryOptions
{
    private QueryOptions()
    {
    }

    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public int StartIndex => (PageNumber * PageSize) - PageSize;
    public string OrderBy { get; set; }
    public bool OrderDesc { get; set; }
    public string? Search { get; set; }

    public static QueryOptions New()
    {
        return new QueryOptions();
    }

    public QueryOptions WithPageNumber(int pageNum)
    {
        PageNumber = pageNum;
        return this;
    }

    public QueryOptions WithPageSize(int pageSize)
    {
        PageSize = pageSize;
        return this;
    }

    public QueryOptions WillOrderBy(string orderBy) 
    {
        OrderBy = orderBy;
        return this;
    }

    public QueryOptions WillOrderDesc() 
    {
        OrderDesc = true;
        return this;
    }

    public QueryOptions SearchingFor(string search)
    {
        Search = search;
        return this;
    }
}