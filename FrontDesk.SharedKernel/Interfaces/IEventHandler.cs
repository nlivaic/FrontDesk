using System;

namespace FrontDesk.SharedKernel.Interfaces {
    public interface IEventHandler<T> where T : IDomainEvent {
        void Handle(T args);
    }
}