using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Service.Messages.Photo
{
    [DataContract]
    public class PhotoDescriptionDto
    {
        [DataMember]
        [Required]
        [StringLength(256)]
        public string Name { get; set; }

        [DataMember]
        [Required]
        [StringLength(1024)]
        public string Description { get; set; }

        [DataMember]
        [Required]
        public double AverageRating { get; set; }

        [DataMember]
        public DateTime TimeOfCreation { get; set; }

        [DataMember]
        public Guid PhotoId { get; set; }

        [DataMember]
        [Required]
        public string UserId { get; set; }

        [DataMember]
        [Required]
        public string UserName { get; set; }
    }
}