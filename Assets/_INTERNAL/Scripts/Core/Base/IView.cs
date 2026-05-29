using UnityEngine;

namespace Core.Base
{
    public interface IView
    {
        void Initialize();
        void BindViewModel(IViewModel viewModel);
        void Release();
    }
}