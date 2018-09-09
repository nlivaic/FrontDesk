using System.Linq;
using FrontDesk.SharedKernel;
using FrontDesk.SharedKernel.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Scheduling.Infrastructure
{
    public abstract class BaseDispatchDbContext : DbContext
    {
        private DomainEventsDispatcher _domainEventsDispatcher;

        /// <summary>
        /// Use to instantiate superclass via IoC container.
        /// Please visit
        /// https://github.com/aspnet/EntityFrameworkCore/issues/7533#issuecomment-353669263
        /// </summary>
        public BaseDispatchDbContext(DbContextOptions<BaseDispatchDbContext> options) : base(options) { }

        /// <summary>
        /// Call from superclass.
        /// Please visit
        /// https://github.com/aspnet/EntityFrameworkCore/issues/7533#issuecomment-353669263
        /// </summary>
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