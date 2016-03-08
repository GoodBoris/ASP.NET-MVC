using System;
using System.ComponentModel.DataAnnotations;
using PhotoAlbum.DAL.Interfaces;

namespace PhotoAlbum.DAL.Entities
{
    public class Vote : BaseEntity, IEntity<Guid>
    {
        public Vote()
        {
            Id = Guid.NewGuid();
        }
        [Key]
        public Guid Id { get; set; }
        public float NodeVote { get; set; }
        public Guid PhotoId { get; set; }
        public virtual Photo Photo { get; set; }
    }
}