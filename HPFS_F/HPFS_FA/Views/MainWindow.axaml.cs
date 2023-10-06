using Avalonia.Controls;
using HPFS_FA.ViewModels;

namespace HPFS_FA.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }
    }
}