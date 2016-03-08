using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Service.Utilities.Membership;

namespace Service.Messages.Membership
{
    [DataContract]
    public class CreateRequest : BaseRequest
    {
        [Required]
        [DataMember]
        public string UserName { get; set; }

        [Required]
        [DataMember]
        public string Password { get; set; }

        [Required]
        [DataMember]
        public string FullName { get; set; }

        [Required]
        [DataMember]
        public string Email { get; set; }

        [Required]
        [DataMember]
        public AuthenticationTypeEnum AuthenticationType { get; set; }

        [Required]
        [DataMember]
        public string Role { get; set; }
    }
}