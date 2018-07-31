Generic repository interface
 - See https://github.com/nlivaic/domain-driven-design-fundamentals/blob/master/ddd7/FrontDeskSolution/ClientPatientManagement.Data/Repository.cs
 - Implementation of a concrete repository (RootRepository : IRepository<T>), generic repository (Repository<T> : IRepository<T>).
  - Marker interface IAggregateRoot limiting repositories so they work only with Aggregate Roots.

Missing:
- SharedKernel/Guard.cs
- CRUD Context (Client, Patient, Doctor, Room).
