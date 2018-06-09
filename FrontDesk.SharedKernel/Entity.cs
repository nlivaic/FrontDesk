using System;

namespace FrontDesk.SharedKernel {
    public abstract class Entity<TId> : IEquatable<Entity<TId>>
    {
        public TId Id { get; protected set; }
        public Entity(TId id)
        {
            if (Object.Equals(id, default(TId)))
            {
                throw new ArgumentException("ID cannot be default value.");
            }
            this.Id = id;
        }

        public bool Equals(Entity<TId> other)
        {
            throw new NotImplementedException();
        }
    }
}