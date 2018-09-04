using System;
using MediatR;

namespace FrontDesk.SharedKernel.Interfaces {
    public interface IEventHandler<T> : INotificationHandler<T> where T : IDomainEvent {
        void Handle(T args);
    }
}