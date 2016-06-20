using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SaveALostGuid
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.Single)]
    public class SaveGuid : ISaveGuid
    {
        private static readonly GuidSaver GuidSaver = new GuidSaver();
        public string GetGuid()
        {
            return GuidSaver.GetSavedGuid().ToString();
        }

        public LostGuidStatistics GetLostGuidStatistics()
        {
            return new LostGuidStatistics
                   {
                       LostGuids = GuidSaver.LostGuids,
                       SavedGuids = GuidSaver.SavedGuids
                   };
        }
    }
}
