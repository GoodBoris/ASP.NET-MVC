using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Service.Messages.Membership
{
    [DataContract]
    public class LoginRequest : BaseRequest
    {
        [Required]
        [DataMember]
        public string UserName { get; set; }

        [Required]
        [DataMember]
        public string Password { get; set; }

    }
}