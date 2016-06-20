using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace TheDisposePattern
{
    class ResourceUser : Disposable
    {
        private readonly ManualResetEvent _e = new ManualResetEvent(false);
        private readonly IntPtr _memoty;
        public ResourceUser()
        {
            _memoty = Marshal.AllocHGlobal(1024);
        }
        protected override void DisposeManagedResources()
        {
            _e.Dispose();
        }

        protected override void DisposeUnmanagedResources()
        {
            Marshal.FreeHGlobal(_memoty);
        }
    }
}