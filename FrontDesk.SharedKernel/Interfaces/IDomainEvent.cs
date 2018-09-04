using System;
using MediatR;

namespace FrontDesk.SharedKernel.Interfaces {
    public interface IDomainEvent : INotification {
        DateTime DateTimeOccurred { get; }
    }
}