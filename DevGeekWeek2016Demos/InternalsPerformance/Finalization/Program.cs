using System.Collections;

namespace Finalization
{
    class Program
    {
        static void Main()
        {
            Foo();
        }

        private static void Foo()
        {
            var ar = new ArrayList();
            for (int i = 0; i < 20; i++)
            {
                if (i%2 == 0)
                    ar.Add(new Example(i));
                else
                    ar.Add(new CriticalFinalizeExample(i));
            }
        }
    }
}
