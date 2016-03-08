using System.Runtime.Serialization;
using Service.Views.Membership;

namespace Service.Messages.Membership
{
    [DataContract]
    public class LoginResponse : BaseResponse
    {
        [DataMember]
        public ClaimIdentityView ClaimIdentityView { get; set; }
    }
}