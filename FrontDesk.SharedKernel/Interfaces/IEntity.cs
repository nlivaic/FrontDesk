using System.Collections.Generic;
using FrontDesk.SharedKernel.Interfaces;

namespace FrontDesk.SharedKernel.Interfaces {
    public interface IEntity
    {
        IEnumerable<IDomainEvent> DomainEvents { get; }
        void ClearEvents();
    }
}