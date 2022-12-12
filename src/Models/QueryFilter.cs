namespace Behlog.Core.Models;

/// <summary>
/// Base class for Query filter data classes. Can be used to filter query results.
/// </summary>
public class QueryFilter
{
    public long PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public long StartIndex => (PageNumber * PageSize) - PageSize;
    public string OrderBy { get; set; }
    public bool OrderDesc { get; set; }

    public static QueryFilter New()
    {
        return new QueryFilter();
    }

    public QueryFilter WithPageNumber(int pageNum)
    {
        PageNumber = pageNum;
        return this;
    }

    public QueryFilter WithPageSize(int pageSize)
    {
        PageSize = pageSize;
        return this;
    }
    
}