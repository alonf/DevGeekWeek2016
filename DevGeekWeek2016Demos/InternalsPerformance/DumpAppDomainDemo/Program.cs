using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumpAppDomainDemo
{
    
    class AppDomainInfo : MarshalByRefObject
    {
        public string DomainName => AppDomain.CurrentDomain.FriendlyName;
    }
    class Program
    {


        static void Main(string[] args)
        {
            Console.WriteLine("Default domains loaded, press a key to continue");
            Console.ReadKey();
            var domain = AppDomain.CreateDomain("New Domain", null);
            Console.WriteLine("New domains has been created, press a key to continue");
            Console.ReadKey();
            var remotreDomainInfo = (AppDomainInfo) (domain.CreateInstanceAndUnwrap(
                typeof(AppDomainInfo).Assembly.FullName, "DumpAppDomainDemo.AppDomainInfo"));
            Console.WriteLine($"Remote domain name is: {remotreDomainInfo.DomainName}");
            Console.ReadKey();
        }
    }
}
