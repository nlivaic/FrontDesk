using System.Linq;
using FrontDesk.SharedKernel;
using FrontDesk.SharedKernel.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Scheduling.Infrastructure
{
    public abstract class BaseDispatchDbContext : DbContext
    {
        private DomainEventsDispatcher _domainEventsDispatcher;

        public BaseDispatchDbContext(DbContextOptions<BaseDispatchDbContext> options) : base(options) { }

        protected BaseDispatchDbContext(DomainEventsDispatcher domainEventsDispatcher, DbContextOptions options) : base(options)
        {
            _domainEventsDispatcher = domainEventsDispatcher;
        }
        public override int SaveChanges()
        {
            var domainEventEntities = ChangeTracker.Entries<IEntity>()
                .Select(e => e.Entity);
            _domainEventsDispatcher.Dispatch(domainEventEntities);
            return base.SaveChanges();
        }
    }
}