Generic repository interface
 - See https://github.com/nlivaic/FrontDesk/blob/master/Scheduling.Core/Domain.Model/Interfaces/IRepository.cs
 - Implementation of a concrete repository (RootRepository : IRepository<T>), generic repository (Repository<T> : IRepository<T>).
  - Marker interface IAggregateRoot limiting repositories so they work only with Aggregate Roots.

Missing:
- SharedKernel/Guard.cs
- CRUD Context (Client, Patient, Doctor, Room).
