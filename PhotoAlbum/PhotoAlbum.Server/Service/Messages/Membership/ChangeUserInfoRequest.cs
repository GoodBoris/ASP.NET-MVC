using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Service.Messages.Membership
{
    [DataContract]
    public class ChangeUserInfoRequest : BaseRequest
    {
        [Required]
        [DataMember]
        public string UserId { get; set; }

        [Required]
        [DataMember]
        public string FullName { get; set; }

        [Required]
        [DataMember]
        public string Email { get; set; }
    }
}