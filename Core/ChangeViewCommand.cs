using ChatClient.MVVM.ViewModel;
using System;
using System.Windows;

namespace ChatClient.Core
{
    public class ChangeViewCommand : CommandBase
    {
        private DisplayViewModel _viewModel;
        private NicknameViewModel _nickname;
        public DisplayViewModel ViewModel => _viewModel;
        public NicknameViewModel NicknameViewModel => _nickname;
        public ChangeViewCommand(DisplayViewModel displayViewModel, NicknameViewModel nicknameViewModel)
        {
            _viewModel = displayViewModel;
            _nickname = nicknameViewModel;
        }
        public override void Execute(object? parameter)
        {
            if (NicknameViewModel.Nickname == "")
            {
                App.Current.Dispatcher.Invoke(() =>
                {
                    MessageBox.Show("Input your nickname!");
                });
                return;
            }
            ViewModel.CurrentViewModel = new MainViewModel(NicknameViewModel.Nickname);
        }
    }
}
