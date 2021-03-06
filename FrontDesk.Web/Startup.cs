﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrontDesk.SharedKernel;
using FrontDesk.SharedKernel.Interfaces;
using FrontDesk.Web.Controllers.Hub;
using FrontDesk.Web.Controllers.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Scheduling.Core.Domain.Model.Events;
using Scheduling.Core.Domain.Model.Interfaces;
using Scheduling.Infrastructure;
using Scheduling.Infrastructure.Repositories;
using Scheduling.Infrastructure.Services;
using Scheduling.Infrastructure.Services.Interfaces;

namespace FrontDesk.Web
{
    public class Startup
    {
        private IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ScheduleContext>(
                options => options.UseMySql(_configuration["Data:FrontDeskScheduling:ConnectionString"])
            );
            services.AddMediatR(typeof(AppointmentConfirmedHandler).Assembly);      // Handlers are in other assemblies, this is the way to add these assemblies.
            services.AddMediatR(typeof(RelayAppointmentScheduledService).Assembly);
            services.AddTransient<IScheduleRepository, ScheduleRepository>();
            services.AddScoped<DomainEventsDispatcher, DomainEventsDispatcher>();
            services.AddTransient<IAppointmentDTORepository, AppointmentDTORepository>();
            services.AddTransient<IMessagePublisher, ServiceBrokerMessagePublisher>();
            services.AddMvc();
            MessagingConfig.StartCheckingMessages();
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
