using System;
using System.Windows;
using ToMars.WPF.ViewModel;


namespace ToMars.Views
{
    public partial class MainView : Window
    {
        public MainView(MainViewModel viewmodel)
        {
            InitializeComponent();
            DataContext = viewmodel;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }
    }
}
