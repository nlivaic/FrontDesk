using System;
using System.Threading;
using System.Threading.Tasks;

namespace FrontDesk.SharedKernel.Interfaces {
    public abstract class BaseEventHandler<T> : IEventHandler<T> where T : IDomainEvent
    {
        public abstract void Handle(T args);

        public Task Handle(T notification, CancellationToken cancellationToken)
        {
            Handle(notification);
            return Task.CompletedTask;
        }
    }
}