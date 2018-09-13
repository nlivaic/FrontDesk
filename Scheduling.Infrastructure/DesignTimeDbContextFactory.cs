using FrontDesk.SharedKernel;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Scheduling.Infrastructure
{
public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ScheduleContext>
    {
        private IConfiguration _configuration;
        public DesignTimeDbContextFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public ScheduleContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ScheduleContext>();

            var connStr = _configuration["Data:FrontDeskScheduling:ConnectionString"];

            builder.UseMySql(connStr, 
                b => b.MigrationsAssembly("Scheduling.Infrastructure"));
            DomainEventsDispatcher dispatcher = new DomainEventsDispatcher(null);

            return new ScheduleContext(dispatcher, builder.Options);
        }
    }
}