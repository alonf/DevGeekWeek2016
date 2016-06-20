using System.Windows;
using TDFKinectGreenScreen.ViewModel;

namespace TDFKinectGreenScreen.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = ((App) Application.Current).Container.GetExportedValue<IKinectGreenScreenViewModel>();
        }
    }
}