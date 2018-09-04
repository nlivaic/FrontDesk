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
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMediatR(typeof(AppointmentConfirmedHandler).Assembly);      // Handlers are in other assemblies, this is the way to add these assemblies.
            services.AddMediatR(typeof(RelayAppointmentScheduledService).Assembly);
            services.AddTransient<IScheduleRepository, ScheduleRepository>();
            services.AddTransient<ScheduleContext, ScheduleContext>();
            services.AddScoped<DomainEventsDispatcher, DomainEventsDispatcher>();
            // services.AddTransient<IEventHandler<AppointmentUpdatedEvent>, AppointmentUpdatedHandler>();
            // services.AddTransient<IEventHandler<AppointmentConfirmedEvent>, AppointmentConfirmedHandler>();
            // services.AddTransient<IEventHandler<AppointmentScheduledEvent>, RelayAppointmentScheduledService>();
            // services.AddTransient<IEventHandler<Scheduling.Infrastructure.ApplicationEvents.AppointmentConfirmedEvent>, EmailConfirmationHandler>();
            services.AddTransient<IAppointmentDTORepository, AppointmentDTORepository>();
            services.AddTransient<IMessagePublisher, ServiceBrokerMessagePublisher>();
            services.AddMvc();
            // DomainEvents.ServiceProvider = services.BuildServiceProvider();
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
