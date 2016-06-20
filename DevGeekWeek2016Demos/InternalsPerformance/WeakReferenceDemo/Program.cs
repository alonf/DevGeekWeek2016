using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeakReferenceDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var pub = new Publisher();
            var sub = new Subscriber();
            pub.Register(sub);
            pub.DoSomething();
            sub = null;
            pub.DoSomething();
            GC.Collect();
            pub.DoSomething();

        }
    }
}
