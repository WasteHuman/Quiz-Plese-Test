using Core.Base;
using UnityEngine;
using UnityEngine.UI;

namespace Core.UI.Main
{
    public class UIMainMenuView : UIView<MainMenuViewModel>
    {
        [SerializeField] private Button _restartButton;

        public override void Initialize()
        {
            gameObject.SetActive(true);
        }

        public override void BindViewModel(IViewModel viewModel)
        {
            base.BindViewModel(viewModel);

            _viewModel = viewModel as MainMenuViewModel;
            _restartButton.onClick.AddListener(HandleRestartButtonClick);
        }

        public override void Release()
        {
            _restartButton.onClick.RemoveListener(HandleRestartButtonClick);
            gameObject.SetActive(false);
        }

        private void HandleRestartButtonClick() => _viewModel.Restart();
    }
}