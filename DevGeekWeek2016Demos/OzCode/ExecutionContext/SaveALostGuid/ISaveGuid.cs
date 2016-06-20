using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace SaveALostGuid
{
    [ServiceContract]
    public interface ISaveGuid
    {
        [OperationContract]
        string GetGuid();

        [OperationContract]
        LostGuidStatistics GetLostGuidStatistics();
    }

    [DataContract]
    public class LostGuidStatistics
    {
        [DataMember]
        public long SavedGuids { get; set; }
        
        [DataMember]
        public long LostGuids { get; set; }
    }
}
