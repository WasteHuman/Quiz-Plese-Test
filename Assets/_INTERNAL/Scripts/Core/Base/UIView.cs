using UnityEngine;

namespace Core.Base
{
    public abstract class UIView<TViewModel> : MonoBehaviour, IView where TViewModel : IViewModel
    {
        protected TViewModel _viewModel;

        public virtual void BindViewModel(IViewModel viewModel)
        {
            _viewModel = (TViewModel)viewModel;
        }

        public abstract void Initialize();

        public abstract void Release();
    }
}