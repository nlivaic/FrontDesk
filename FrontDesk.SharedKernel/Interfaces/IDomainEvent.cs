using System;

namespace FrontDesk.SharedKernel.Interfaces {
    public interface IDomainEvent {
        DateTime DateTimeOccurred { get; }
    }
}