using Core.Base;
using Core.UI.Main;
using Cysharp.Threading.Tasks;
using System.Threading;

namespace Core.StateMachine.States
{
    public class MenuState : IState
    {
        private readonly UIMainMenuView _view;
        private readonly IStateController<GameState> _stateController;

        public MenuState(UIMainMenuView view, IStateController<GameState> stateController)
        {
            _view = view;
            _stateController = stateController;
        }

        public UniTask EnterAsync(CancellationToken ct)
        {
            var viewModel = new MainMenuViewModel(_stateController);

            _view.Initialize();
            _view.BindViewModel(viewModel);

            return UniTask.CompletedTask;
        }

        public UniTask ExitAsync(CancellationToken ct)
        {
            _view.Release();

            return UniTask.CompletedTask;
        }
    }
}