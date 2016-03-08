using System.Runtime.Serialization;

namespace Service.Views.Membership
{
    [DataContract]
    public class ClaimView
    {
        [DataMember]
        public string Type { get; set; }

        [DataMember]
        public string Value { get; set; }

        [DataMember]
        public string ValueType { get; set; }
    }
}