﻿using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;

namespace VenturaSoftHR.Tests.Repositories.Utils;

public class AsyncEnumerable<T> : EnumerableQuery<T>, IAsyncEnumerable<T>, IQueryable<T>
{
    public AsyncEnumerable(IEnumerable<T> enumerable)
        : base(enumerable)
    { }

    public AsyncEnumerable(Expression expression)
        : base(expression)
    { }

    public IAsyncEnumerator<T> GetEnumerator()
    {
        return new AsyncEnumerator<T>(this.AsEnumerable().GetEnumerator());
    }

    public IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = default)
    {
        return new AsyncEnumerator<T>(this.AsEnumerable().GetEnumerator());
    }

    IQueryProvider IQueryable.Provider
    {
        get { return new AsyncQueryProvider<T>(this); }
    }
}
