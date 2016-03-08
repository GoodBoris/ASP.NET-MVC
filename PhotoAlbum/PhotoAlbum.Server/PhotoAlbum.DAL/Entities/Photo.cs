using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PhotoAlbum.DAL.Interfaces;

namespace PhotoAlbum.DAL.Entities
{
    public class Photo : BaseEntity, IEntity<Guid>
    {
        public Photo()
        {
            Id = Guid.NewGuid();
        }
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Vote> Votes { get; set; } = new List<Vote>();
        public DateTime? TimeOfCreation { get; set; }
        public string ClientProfileId { get; set; }
        public virtual ClientProfile ClientProfile { get; set; }
        public virtual Image Image { get; set; }
    }
}