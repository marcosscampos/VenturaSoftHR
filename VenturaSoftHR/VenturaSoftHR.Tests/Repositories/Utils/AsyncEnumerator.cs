using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace VenturaSoftHR.Tests.Repositories.Utils;
public class AsyncEnumerator<T> : IAsyncEnumerator<T>
{
    private readonly IEnumerator<T> enumerator;

    public AsyncEnumerator(IEnumerator<T> enumerator)
    {
        this.enumerator = enumerator;
    }

    public T Current => enumerator.Current;

    public async ValueTask DisposeAsync()
    {
        await ValueTask.FromResult(() => enumerator.Dispose());
    }

    public ValueTask<bool> MoveNextAsync()
    {
        return ValueTask.FromResult(enumerator.MoveNext());
    }
}
