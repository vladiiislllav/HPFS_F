using Avalonia.Controls;
using HPFS_FA.ViewModels;

namespace HPFS_FA.Views
{
    public partial class ProgT : Window
    {
        public ProgT()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }
    }
}
