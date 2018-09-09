using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FrontDesk.SharedKernel.Interfaces;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace FrontDesk.SharedKernel {
    public class DomainEventsDispatcher
    {
        private IMediator _mediator;
        public DomainEventsDispatcher(IMediator mediator)
        {
            _mediator = mediator;
        }
        public void Dispatch(IEnumerable<IEntity> entities)
        {
            var domainEventEntities = entities
                .Where(e => e.DomainEvents.Any())
                .ToArray();
            foreach (var entity in domainEventEntities)
            {
                IEnumerable<IDomainEvent> events = entity.DomainEvents.ToArray();
                entity.ClearEvents();
                foreach (IDomainEvent domainEvent in events)
                {
                    _mediator.Publish(domainEvent);
                }
            }
        }
    }
}