using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PhotoAlbum.DAL.Interfaces;

namespace PhotoAlbum.DAL.Entities
{
    public class ClientProfile : BaseEntity, IEntity<string>
    {
        [Key]
        [ForeignKey("ApplicationUser")]
        public string Id { get; set; }
        public string UserName { get; set; } 
        public string FullName { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual ICollection<Photo> Photos { get; set; } = new List<Photo>();
    }
}