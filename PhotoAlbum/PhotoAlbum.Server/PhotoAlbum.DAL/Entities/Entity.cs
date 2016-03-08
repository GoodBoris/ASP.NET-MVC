using PhotoAlbum.DAL.Interfaces;

namespace PhotoAlbum.DAL.Entities
{
    public abstract class BaseEntity { }

    public abstract class Entity<T> : BaseEntity,  IEntity<T>
    {
        public virtual T Id { get; set; }
    }
}