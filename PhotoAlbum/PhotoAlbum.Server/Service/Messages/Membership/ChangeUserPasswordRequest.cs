using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Service.Messages.Membership
{
    [DataContract]
    public class ChangeUserPasswordRequest : BaseRequest
    {
        [Required]
        [DataMember]
        public string UserId { get; set; }

        [Required]
        [DataMember]
        public string OldPassword { get; set; }

        [Required]
        [DataMember]
        public string NewPassword { get; set; }
    }
}