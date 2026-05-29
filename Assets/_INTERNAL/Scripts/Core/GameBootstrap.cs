using Core.Base;
using Core.StateMachine;
using Core.StateMachine.States;
using Cysharp.Threading.Tasks;
using VContainer.Unity;
using CancellationToken = System.Threading.CancellationToken;

namespace Core
{
    public sealed class GameBootstrap : IStartable
    {
        private readonly IStateController<GameState> _stateController;

        private readonly SplashState _splashState;
        private readonly LoadState _loadState;
        private readonly MenuState _mainMenuState;

        public GameBootstrap(IStateController<GameState> stateController,
            SplashState splashState, LoadState loadState, MenuState mainMenuState)
        {
            _stateController = stateController;
            _splashState = splashState;
            _loadState = loadState;
            _mainMenuState = mainMenuState;
        }

        public void Start()
        {
            _stateController.RegisterState(GameState.Splash, _splashState);
            _stateController.RegisterState(GameState.Load, _loadState);
            _stateController.RegisterState(GameState.Menu, _mainMenuState);

            _stateController.EnterStateAsync(GameState.Splash, CancellationToken.None).Forget();
        }
    }
}