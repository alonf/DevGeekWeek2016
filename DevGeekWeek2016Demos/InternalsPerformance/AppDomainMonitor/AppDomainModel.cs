using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Timers;
using AppDomainMonitor.Annotations;

// ReSharper disable ExplicitCallerInfoArgument

namespace AppDomainMonitor
{
    public class AppDomainModel : INotifyPropertyChanged
    {
        private readonly Timer _timer = new Timer(1000) {AutoReset = true};

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void StartMonitoring()
        {
                AppDomain.MonitoringIsEnabled = true;
                _timer.Elapsed += UpdateAppDomainInfo;
                _timer.Enabled = true;
                _timer.Start();
            OnPropertyChanged("MonitorIsNotEnabled");
        }

        public bool MonitorIsNotEnabled => !AppDomain.MonitoringIsEnabled;

        private void UpdateAppDomainInfo(object sender, ElapsedEventArgs e)
        {
            OnPropertyChanged("MonitoringSurvivedMemorySize");
            OnPropertyChanged("MonitoringSurvivedProcessMemorySize");
            OnPropertyChanged("MonitoringTotalAllocatedMemorySize");
            OnPropertyChanged("MonitoringTotalProcessorTime");
        }

        public long MonitoringSurvivedProcessMemorySize => AppDomain.MonitoringIsEnabled ? AppDomain.MonitoringSurvivedProcessMemorySize : 0;

        public long MonitoringSurvivedMemorySize => AppDomain.MonitoringIsEnabled ? AppDomain.CurrentDomain.MonitoringSurvivedMemorySize : 0;

        public long MonitoringTotalAllocatedMemorySize => AppDomain.MonitoringIsEnabled ? AppDomain.CurrentDomain.MonitoringTotalAllocatedMemorySize : 0;

        public TimeSpan MonitoringTotalProcessorTime => AppDomain.MonitoringIsEnabled ? AppDomain.CurrentDomain.MonitoringTotalProcessorTime : TimeSpan.Zero;
    }
}
