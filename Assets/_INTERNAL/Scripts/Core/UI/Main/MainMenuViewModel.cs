using Core.Base;
using Core.StateMachine;
using Cysharp.Threading.Tasks;
using System.Threading;

namespace Core.UI.Main
{
    public class MainMenuViewModel : IViewModel
    {
        private readonly IStateController<GameState> _stateController;

        public MainMenuViewModel(IStateController<GameState> stateController)
        {
            _stateController = stateController;
        }

        public void Restart()
        {
            _stateController.EnterStateAsync(GameState.Load, CancellationToken.None).Forget();
        }
    }
}