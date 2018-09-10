using FrontDesk.SharedKernel;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Scheduling.Infrastructure
{
public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ScheduleContext>
    {
        public ScheduleContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ScheduleContext>();

            var connStr = "server=localhost;userid=root;pwd=rootpw;port=3306;database=schedule;sslmode=none;";

            builder.UseMySql(connStr, 
                b => b.MigrationsAssembly("Scheduling.Infrastructure"));
            DomainEventsDispatcher dispatcher = new DomainEventsDispatcher(null);

            return new ScheduleContext(dispatcher, builder.Options);
        }
    }
}