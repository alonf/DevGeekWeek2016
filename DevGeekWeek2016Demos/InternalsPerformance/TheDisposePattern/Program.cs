using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheDisposePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var r = new ResourceUser())
            {
                
            }
            var x = new ResourceUser();
        }
    }
}
