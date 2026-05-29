using Core.Base;
using R3;

namespace Core.UI
{
    public class LoadingViewModel : IViewModel
    {
        private readonly ReactiveProperty<float> _progressChanged;

        public Observable<float> ProgressChanged => _progressChanged.AsObservable();

        public LoadingViewModel(ReactiveProperty<float> property)
        {
            _progressChanged = property;
        }
    }
}