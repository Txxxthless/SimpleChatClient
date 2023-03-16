using ChatClient.Core;

namespace ChatClient.MVVM.ViewModel
{
    public class NicknameViewModel : ObservableObject
    {
        private ChangeViewCommand _changeViewCommand;
        private string _nickname = "";

        public ChangeViewCommand Command => _changeViewCommand;
        public string Nickname
        {
            get
            {
                return _nickname;
            }
            set
            {
                _nickname = value;
                OnPropertyChanged();
            }
        }

        public NicknameViewModel(DisplayViewModel displayViewModel)
        {
            _changeViewCommand = new ChangeViewCommand(displayViewModel, this);
        }
    }
}
