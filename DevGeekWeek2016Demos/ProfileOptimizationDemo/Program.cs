using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ProfileOptimizationDemo
{
    
    class Program
    {
        private static void QSort<T>(T[] a, int lo, int hi) where T : IComparable<T>
        {
            if (lo < hi)
            {
                var p = Partition(a, lo, hi);
                QSort(a, lo, p - 1);
                QSort(a, p + 1, hi);
            }
        }

        private static void Swap<T>(ref T a, ref T b)
        {
            var t = a;
            a = b;
            b = t;
        }

        private static int Partition<T>(T[] a, int lo, int hi) where T : IComparable<T>
        {
            var pivot = a[hi];
            int i = lo;
            for (int j = lo; j < hi; ++j)
            {
                if (a[j].CompareTo(pivot) <= 0)
                {
                   Swap(ref a[i], ref a[j]);
                    ++i;
                }
            }
            Swap(ref a[i], ref a[hi]);

            return i;
        }

        static void Main(string[] args)
        {
            var sw = Stopwatch.StartNew();
            if (args.Length >= 1 && args[0].ToLower().EndsWith("p"))
            {
                ProfileOptimization.SetProfileRoot(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
                ProfileOptimization.StartProfile("JustInTimeProfileOptimization");
            }

            var rnd = new Random();
            var a =  new int[100000];
            for(int i = 0; i < a.Length; ++i)
                a[i] = rnd.Next(int.MaxValue);

            QSort(a, 0, a.Length - 1);

            var d = new double[100000];
            for (int i = 0; i < d.Length; ++i)
                d[i] = rnd.Next(int.MaxValue);

            Console.WriteLine($"Execution time: {sw.ElapsedMilliseconds} ms");
        }
    }
}
