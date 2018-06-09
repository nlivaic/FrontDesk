using System;

namespace FrontDesk.SharedKernel {
    public abstract class Entity<TId> : IEquatable<Entity<TId>>
    {
        public TId Id { get; protected set; }
        protected Entity(TId id)
        {
            if (Object.Equals(id, default(TId)))
            {
                throw new ArgumentException("ID cannot be default value.");
            }
            this.Id = id;
        }

        /// <summary>
        /// Required by Entity Framework.
        /// </summary>
        protected Entity()
        {

        }

        public override bool Equals(object otherObject)
        {
            var entity = otherObject as Entity<TId>;
            if (entity != null)
            {
                return this.Equals(entity);
            }
            return base.Equals(otherObject);
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        public bool Equals(Entity<TId> other)
        {
            if (other == null)
            {
                return false;
            }
            return this.Id.Equals(other.Id);
        }
    }
}