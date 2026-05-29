using Core.Base;
using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using UnityEngine;

namespace Core.StateMachine.States
{
    public sealed class SplashState : IState
    {
        private readonly IStateController<GameState> _stateController;

        public SplashState(IStateController<GameState> stateController)
        {
            _stateController = stateController;
        }

        public async UniTask EnterAsync(CancellationToken ct)
        {
            await UniTask.Delay(TimeSpan.FromSeconds(1f), cancellationToken: ct);

            try
            {
                await _stateController.EnterStateAsync(GameState.Load, ct);
            }
            catch (Exception ex)
            {
                Debug.LogError($"[SplashState] Exception: {ex}");
            }
        }

        public UniTask ExitAsync(CancellationToken ct)
        {
            return UniTask.CompletedTask;
        }
    }
}