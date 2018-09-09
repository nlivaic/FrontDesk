using System;
using System.Collections.Generic;
using FrontDesk.SharedKernel.Interfaces;

namespace FrontDesk.SharedKernel
{
    public abstract class AggregateRoot<TId> : Entity<TId>
    {
        protected AggregateRoot(TId id) : base(id) 
        { 
            // _domainEvents = new List<IDomainEvent>();
        }
        
        /// <summary>
        /// Required by Entity Framework.
        /// </summary>        
        protected AggregateRoot() : base()
        {
        }
    }
}