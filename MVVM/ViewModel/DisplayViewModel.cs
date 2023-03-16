using ChatClient.Core;

namespace ChatClient.MVVM.ViewModel
{
    public class DisplayViewModel : ObservableObject
    {
        private ObservableObject _currentViewModel;
        public ObservableObject CurrentViewModel
        {
            get
            {
                return _currentViewModel;
            }
            set
            {
                _currentViewModel = value;
                OnPropertyChanged();
            }
        }
        public DisplayViewModel()
        {
            _currentViewModel = new NicknameViewModel(this);
        }
    }
}
