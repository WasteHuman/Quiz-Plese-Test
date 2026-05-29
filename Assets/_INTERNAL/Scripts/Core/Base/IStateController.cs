using Cysharp.Threading.Tasks;
using System.Threading;

namespace Core.Base
{
    public interface IStateController<TState>
    {
        void RegisterState(TState key, IState state);
        UniTask EnterStateAsync(TState state, CancellationToken ct);
    }
}