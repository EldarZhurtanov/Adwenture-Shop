using System.Runtime.Serialization;

namespace DataContracts
{
    [DataContract]
    public class OperationDetailsDTO
    {
        public OperationDetailsDTO(bool succedeed, string message, string prop)
        {
            Succedeed = succedeed;
            Message = message;
            Property = prop;
        }

        [DataMember]
        public bool Succedeed { get; private set; }
        [DataMember]
        public string Message { get; private set; }
        [DataMember]
        public string Property { get; private set; }
    }
}
