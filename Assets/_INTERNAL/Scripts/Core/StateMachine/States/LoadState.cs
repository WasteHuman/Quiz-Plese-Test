using Core.Base;
using Core.UI;
using Cysharp.Threading.Tasks;
using R3;
using System;
using System.Threading;
using UnityEngine;

namespace Core.StateMachine.States
{
    public sealed class LoadState : IState
    {
        private readonly ReactiveProperty<float> _progressChanged = new();

        private readonly IStateController<GameState> _stateController;
        private readonly UILoadingView _view;

        public LoadState(IStateController<GameState> stateController, UILoadingView loadingView)
        {
            _stateController = stateController;
            _view = loadingView;
        }

        public async UniTask EnterAsync(CancellationToken ct)
        {
            _progressChanged.Value = 0f;

            var viewModel = new LoadingViewModel(_progressChanged);

            _view.Initialize();
            _view.BindViewModel(viewModel);

            for (int i = 0; i < 5; i++)
            {
                await UniTask.Delay(TimeSpan.FromSeconds(1f), cancellationToken: ct);

                _progressChanged.Value = (i + 1) / 5f;
            }

            await UniTask.Delay(TimeSpan.FromSeconds(5f), cancellationToken: ct);
            await _stateController.EnterStateAsync(GameState.Menu, ct);
        }

        public UniTask ExitAsync(CancellationToken ct)
        {
            _view.Release();

            return UniTask.CompletedTask;
        }
    }
}