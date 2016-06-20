using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryHardToSaveGuids
{
    using System.Threading;
    using static Console;
    class Program
    {
        static SaveALostGuidService.ISaveGuid _saveGuidClient
            = new SaveALostGuidService.SaveGuidClient();
        static void Main(string[] args)
        {

            Parallel.Invoke(()=>DoYourBest(), ()=>ShowStatistics());

        }

        private static void ShowStatistics()
        {
           Thread.CurrentThread.Name = "ShowStatistics";
           while(true)
            {
                Task.Delay(TimeSpan.FromSeconds(5));
                var statistics = _saveGuidClient.GetLostGuidStatistics();
                WriteLine($"Lost Guids: {statistics.LostGuids} \t Saved Guids: {statistics.SavedGuids}");
            }
        }

        private static void DoYourBest()
        {
            Thread.CurrentThread.Name = "DoYourBest";
            while (true)
            {
                _saveGuidClient.GetGuid();
            }
        }
    }
}
