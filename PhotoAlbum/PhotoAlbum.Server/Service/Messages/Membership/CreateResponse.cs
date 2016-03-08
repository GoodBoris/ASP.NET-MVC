using System.Runtime.Serialization;
using Service.Views.Membership;

namespace Service.Messages.Membership
{
    [DataContract]
    public class CreateResponse : BaseResponse
    {
        [DataMember]
        public string UserId { get; set; }

        [DataMember]
        public ClaimIdentityView ClaimIdentityView { get; set; }
    }
}
