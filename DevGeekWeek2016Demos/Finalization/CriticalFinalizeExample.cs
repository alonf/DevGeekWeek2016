using System;
using System.Runtime.ConstrainedExecution;
using System.Threading;

namespace Finalization
{
    class CriticalFinalizeExample : CriticalFinalizerObject
    {
        private readonly int _i;

        public CriticalFinalizeExample(int i)
        {
            _i = i;
        }
        
        ~CriticalFinalizeExample()
        {
            Console.WriteLine($"Critical Finalization:{_i}");
        }
    }
}