using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace AppDomainMonitor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        // ReSharper disable once CollectionNeverQueried.Local
        private readonly List<double []> _list = new List<double []>();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new AppDomainModel();
        }

        
        private void ConsumeMemory(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 1000; ++i)
            {
                    _list.Add(new double[1024]);
            }
        }

        private void ConsumeCPUTime(object sender, RoutedEventArgs e)
        {
            Task.Run(() =>
                         {
                             var da = new double[1024];
                             for (int n = 0; n < 10000; n++)
                             {
                                 for (int i = 0; i < 1024; i++)
                                 {
                                     da[i] = Math.Sqrt(i);
                                 }
                             }
                             return da;
                         }).ContinueWith(r => r.Result.OrderBy(f => f).Reverse());
        }

        private void FreeMemory(object sender, RoutedEventArgs e)
        {
            _list.Clear();
            GC.Collect(2);
            GC.WaitForPendingFinalizers();
            GC.Collect(2);
        }

        private void EnableAppDomainMonitoring(object sender, RoutedEventArgs e)
        {
            var appDomainModel = DataContext as AppDomainModel;
            Debug.Assert(appDomainModel != null, "appDomainModel != null");
            appDomainModel.StartMonitoring();
        }
    }
}
