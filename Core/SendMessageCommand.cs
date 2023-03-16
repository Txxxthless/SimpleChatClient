using ChatClient.MVVM.ViewModel;
using System.Windows;

namespace ChatClient.Core
{
    public class SendMessageCommand : CommandBase
    {
        private MainViewModel _viewModel;

        public MainViewModel ViewModel => _viewModel;
        public SendMessageCommand(MainViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object? parameter)
        {

            if (string.IsNullOrEmpty(_viewModel.Message)) return;

            try
            {
                _viewModel.SendMessage();
            }
            catch
            {
                App.Current.Dispatcher.Invoke(() =>
                {
                    MessageBox.Show("The server is down!");
                });
            }

            _viewModel.Message = "";
        }
    }
}
