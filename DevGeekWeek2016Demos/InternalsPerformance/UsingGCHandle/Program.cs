using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace UsingGCHandle
{
    internal delegate bool EnumWindowProc(IntPtr hwnd, IntPtr param);

    internal class Program
    {
        [DllImport("user32")]
        public static extern bool EnumWindows(EnumWindowProc cb, IntPtr param);

        [DllImport("user32")]
        public static extern bool GetWindowText(IntPtr hWnd, StringBuilder name, int count);

        [DllImport("user32")]
        public static extern bool IsWindowVisible(IntPtr hWnd);

        private static void Main()
        {
            var titles = new List<string>();
            EnumWindows(EnumCallback, (IntPtr)GCHandle.Alloc(titles));

            foreach (var title in titles)
            {
                Console.WriteLine(title);
            }
        }
        static bool EnumCallback(IntPtr hWnd, IntPtr param)
        {
            if (IsWindowVisible(hWnd))
            {
                var name = new StringBuilder(300);
                GetWindowText(hWnd, name, 300);

                if (name.Length > 0)
                {
                    GCHandle h = GCHandle.FromIntPtr(param);
                    var list = (List<string>)h.Target;
                    list.Add(name.ToString());
                }
            }
            return true;
        }
    }
}
