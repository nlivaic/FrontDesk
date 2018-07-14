using System;

namespace FrontDesk.SharedKernel.Interfaces {
    public interface IApplicationEvent {
        DateTime DateTimeOccurred { get; }
    }
}