using ChatClient.Core;
using ChatClient.MVVM.ViewModel;
using System.Windows;

namespace ChatClient
{
    public partial class MainWindow : Window
    {
        private ObservableObject _currentViewModel;
        public ObservableObject CurrentViewModel => _currentViewModel;
        public MainWindow()
        {
            _currentViewModel = new DisplayViewModel();
            this.DataContext = CurrentViewModel;
            InitializeComponent();
        }
    }
}
