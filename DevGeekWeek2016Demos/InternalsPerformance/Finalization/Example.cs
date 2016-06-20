using System;
using System.Threading;

namespace Finalization
{
    class Example
    {
        private readonly int _i;

        public Example(int i)
        {
            _i = i;
        }

        ~Example()
        {
            Console.WriteLine($"Finalization:{_i}");
        }
    }
}