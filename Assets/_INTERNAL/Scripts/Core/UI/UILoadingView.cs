using Core.Base;
using R3;
using UnityEngine;
using UnityEngine.UI;

namespace Core.UI
{
    public class UILoadingView : UIView<LoadingViewModel>
    {
        private CompositeDisposable _disposables;

        [SerializeField] private Slider _progress;

        public override void Initialize()
        {
            _disposables = new CompositeDisposable();
            gameObject.SetActive(true);
        }

        public override void BindViewModel(IViewModel viewModel)
        {
            base.BindViewModel(viewModel);

            _viewModel = viewModel as LoadingViewModel;

            _viewModel.ProgressChanged.Subscribe(UpdateProgress).AddTo(_disposables);
        }

        public override void Release()
        {
            _disposables.Dispose();
            gameObject.SetActive(false);
        }

        private void UpdateProgress(float progress)
        {
            _progress.value = progress;
        }
    }
}