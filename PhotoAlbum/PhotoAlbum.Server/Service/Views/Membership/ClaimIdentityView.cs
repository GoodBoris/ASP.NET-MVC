using System.Collections.Generic;
using System.Runtime.Serialization;
using Service.Utilities.Membership;

namespace Service.Views.Membership
{
    [DataContract]
    public class ClaimIdentityView
    {
        public ClaimIdentityView()
        {
            ClaimViewList = new List<ClaimView>();
        }

        [DataMember]
        public string UserId { get; set; }

        [DataMember]
        public AuthenticationTypeEnum AuthenticationType { get; set; }

        [DataMember]
        public IList<ClaimView> ClaimViewList { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string NameClaimType { get; set; }

        [DataMember]
        public string RoleClaimType { get; set; }
    }
}