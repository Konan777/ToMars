using System;
using System.Windows;
using ToMars.WPF.ViewModel;

namespace ToMars.Views
{
    /// <summary>
    /// Interaction logic for Edit.xaml
    /// </summary>
    public partial class EditView : Window
    {
        public EditView(IEditViewModel viewmodel)
        {
            InitializeComponent();
            DataContext = viewmodel;
            // Register actions which closes/shows EditView from a IEditViewModel
            viewmodel.CloseAction = new Action(() => this.Close());
            viewmodel.ShowAction = new Action(() => this.ShowDialog());
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }
    }
}
