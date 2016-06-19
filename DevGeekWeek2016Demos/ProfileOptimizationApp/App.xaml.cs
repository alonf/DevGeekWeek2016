using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Runtime;
using System.Threading.Tasks;
using System.Windows;

namespace ProfileOptimizationApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public  Stopwatch ExecutionTime { get; }

        public App()
        {
            ExecutionTime = Stopwatch.StartNew();
            var args = Environment.GetCommandLineArgs();
            if (args.Length >= 2 && args[1].ToLower().EndsWith("p"))
            {
                ProfileOptimization.SetProfileRoot(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
                ProfileOptimization.StartProfile("JustInTimeProfileOptimization");
            }
        }
    }
}
