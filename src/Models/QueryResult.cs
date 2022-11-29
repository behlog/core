using Behlog.Extensions;
using Behlog.Core.Validations;

namespace Behlog.Core.Models;

/// <summary>
/// Represents a collection of paged results from a Query. 
/// </summary>
/// <typeparam name="TResult">type of Query Results.</typeparam>
public class QueryResult<TResult> where TResult : class
{
    private ICollection<ValidationError> _errors;

    protected QueryResult()
    {
        _errors = new List<ValidationError>();
        Results = new List<TResult>();
    }

    protected QueryResult(IEnumerable<TResult> results)
    {
        _errors = new List<ValidationError>();
        if (results is null)
            throw new ArgumentNullException(nameof(results));
        
        Results = results.ToList();
    }

    public IReadOnlyCollection<TResult> Results { get; }
    
    public bool HasError => _errors.Any();

    public IReadOnlyCollection<ValidationError> Errors => _errors.ToList();
    
    public long PageNumber { get; protected set; }
    
    public int PageSize { get; protected set; }
    
    public long TotalCount { get; protected set; }

    public long TotalPages => TotalCount / PageSize;


    public static QueryResult<TResult> Create()
    {
        return new QueryResult<TResult>();
    }

    public static QueryResult<TResult> Create(IEnumerable<TResult> results)
    {
        return new QueryResult<TResult>(results);
    }

    public QueryResult<TResult> WithPageSize(int pageSize = 10)
    {
        PageSize = pageSize;
        return this;
    }

    public QueryResult<TResult> WithPageNumber(int pageNumber)
    {
        PageNumber = pageNumber;
        return this;
    }

    public QueryResult<TResult> WithTotalCount(int totalCount)
    {
        TotalCount = totalCount;
        return this;
    }


    public void AddError(ValidationError error)
    {
        error.ThrowExceptionIfArgumentIsNull(nameof(error));
        _errors.Add(error);
    }

    public void AddErrors(IEnumerable<ValidationError> errors)
    {
        errors.ThrowExceptionIfArgumentIsNull(nameof(errors));
        if(!errors.Any()) return;

        foreach (var err in errors)
        {
            _errors.Add(err);
        }
    }

    public QueryResult<TResult> WithError(ValidationError error)
    {
        AddError(error);
        return this;
    }

    public QueryResult<TResult> WithErrors(IEnumerable<ValidationError> errors)
    {
        AddErrors(errors);
        return this;
    }
}