using System.Windows;
using WpfExcelInteraction.ViewModels;

namespace WpfExcelInteraction
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new ExcelDataViewModel();
        }
    }
}
