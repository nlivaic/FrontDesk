using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrontDesk.SharedKernel;
using FrontDesk.SharedKernel.Interfaces;
using FrontDesk.Web.Controllers.Hub;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Scheduling.Core.Domain.Model.Events;
using Scheduling.Core.Domain.Model.Interfaces;
using Scheduling.Infrastructure;
using Scheduling.Infrastructure.Repositories;

namespace FrontDesk.Web
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IScheduleRepository, ScheduleRepository>();
            services.AddTransient<ScheduleContext, ScheduleContext>();
            services.AddTransient<IEventHandler<AppointmentUpdatedEvent>, AppointmentUpdatedHandler>();
            services.AddMvc();
            DomainEvents.ServiceProvider = services.BuildServiceProvider();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStatusCodePages();
            app.UseMvc(routes => {
                routes.MapRoute(
                    name: "",
                    template: "{controller}/{action}",
                    defaults: new { controller = "Appointment", action = "Index" }
                );
            });
        }
    }
}
