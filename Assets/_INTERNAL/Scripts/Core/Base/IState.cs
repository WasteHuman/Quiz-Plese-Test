using Cysharp.Threading.Tasks;
using System.Threading;

namespace Core.Base
{
    public interface IState
    {
        UniTask EnterAsync(CancellationToken ct);
        UniTask ExitAsync(CancellationToken ct);
    }
}