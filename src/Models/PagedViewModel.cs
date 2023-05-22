namespace Behlog.Core.Models;

public abstract class PagedViewModel<T> where T: class
{
    
    public IReadOnlyCollection<T> Data { get; set; }
    
    public long TotalCount { get; set; }
    
    public int PageNumber { get; set; }

    public int PageSize { get; set; } = 10;
    
    public int TotalPages => (PageNumber * PageSize) - PageSize;
}