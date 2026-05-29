using Core.Base;

using Core.StateMachine;
using Core.StateMachine.States;

using Core.UI;
using Core.UI.Main;

using UnityEngine;

using VContainer;
using VContainer.Unity;

namespace Core
{
    public class GameLifetimeScope : LifetimeScope
    {
        [SerializeField] private UILoadingView _uiLoadingView;
        [SerializeField] private UIMainMenuView _uiMainMenuView;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(_uiLoadingView);
            builder.RegisterInstance(_uiMainMenuView);

            builder.Register<StatesController>(Lifetime.Singleton)
                .AsSelf().As<IStateController<GameState>>();

            builder.Register<SplashState>(Lifetime.Singleton);
            builder.Register<LoadState>(Lifetime.Singleton);
            builder.Register<MenuState>(Lifetime.Singleton);

            builder.RegisterEntryPoint<GameBootstrap>();
        }
    }
}