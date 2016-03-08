using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PhotoAlbum.DAL.Interfaces;

namespace PhotoAlbum.DAL.Entities
{
    public class Image : BaseEntity, IEntity<Guid>
    {
        [Key, ForeignKey("Photo")]
        public Guid Id { get; set; }
        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }
        public virtual Photo Photo { get; set; }
    }
}