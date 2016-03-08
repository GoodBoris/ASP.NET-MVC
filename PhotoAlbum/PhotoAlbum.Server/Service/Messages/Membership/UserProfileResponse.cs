using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Service.Messages.Membership
{
    [DataContract]
    public class UserProfileResponse : BaseResponse
    {
        [DataMember]
        [Required]
        public string UserName { get; set; }

        [DataMember]
        [Required]
        public string FullName { get; set; }

        [DataMember]
        [Required]
        public string Email { get; set; }
    }
}