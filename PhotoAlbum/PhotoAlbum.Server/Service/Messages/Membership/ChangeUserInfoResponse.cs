using System.Runtime.Serialization;

namespace Service.Messages.Membership
{
    [DataContract]
    public class ChangeUserInfoResponse : BaseResponse
    {
        [DataMember]
        public string UserId { get; set; }

        [DataMember]
        public string FullName { get; set; }

        [DataMember]
        public string Email { get; set; }
    }
}