using System;
using System.Collections.Generic;
using FrontDesk.SharedKernel.Interfaces;

namespace FrontDesk.SharedKernel {
    
    public abstract class Entity<TId> : IEquatable<Entity<TId>>, IEntity
    {
        public TId Id { get; protected set; }
        [ThreadStatic]
        private static List<Delegate> _actions;
        private readonly IList<IDomainEvent> _domainEvents;
        public IEnumerable<IDomainEvent> DomainEvents => _domainEvents;
        protected Entity(TId id)
        {
            if (Object.Equals(id, default(TId)))
            {
                throw new ArgumentException("ID cannot be default value.");
            }
            this.Id = id;
            _domainEvents = new List<IDomainEvent>();
        }

        /// <summary>
        /// Required by Entity Framework.
        /// </summary>
        protected Entity()
        {
            _domainEvents = new List<IDomainEvent>();
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
        protected virtual void AddDomainEvent(IDomainEvent newEvent)
        {
            _domainEvents.Add(newEvent);
        }
        public static void Register<T>(Action<T> callback) where T : IDomainEvent
        {
            if (_actions == null)
            {
                _actions = new List<Delegate>();
            }
            if (!_actions.Contains(callback))
            {
                _actions.Add(callback);
            }
        }
        public virtual void ClearEvents()
        {
            _domainEvents.Clear();
            if (_actions != null)
            {
                _actions.Clear();
            }
        }
    }
}