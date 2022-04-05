using Microsoft.EntityFrameworkCore.Query;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;

namespace VenturaSoftHR.Tests.Repositories.Utils;

public class AsyncQueryProvider<T> : IAsyncQueryProvider
{
    private readonly IQueryProvider query;

    public AsyncQueryProvider(IQueryProvider query)
    {
        this.query = query;
    }

    public IQueryable CreateQuery(Expression expression)
    {
        return new AsyncEnumerable<T>(expression);
    }

    public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
    {
        return new AsyncEnumerable<TElement>(expression);
    }

    public object? Execute(Expression expression)
    {
        return query.Execute(expression);
    }

    public TResult Execute<TResult>(Expression expression)
    {
        return query.Execute<TResult>(expression);
    }

    public TResult ExecuteAsync<TResult>(Expression expression, CancellationToken cancellationToken = default)
    {
        return query.Execute<TResult>(expression);
    }
}
