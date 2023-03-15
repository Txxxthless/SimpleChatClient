using ChatClient.MVVM.View;
using ChatClient.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Windows;

namespace ChatClient
{
    public partial class MainWindow : Window
    {
        private MainViewModel viewModel;
        public MainWindow()
        {
            viewModel = new MainViewModel();
            this.DataContext = viewModel;
            InitializeComponent();
        }
    }
}
