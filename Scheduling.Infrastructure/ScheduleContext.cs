using System;
using System.Collections.Generic;
using System.Linq;
using FrontDesk.SharedKernel;
using FrontDesk.SharedKernel.Interfaces;
using Microsoft.EntityFrameworkCore;
using Scheduling.Core.Domain.Model.ScheduleAggregate;

namespace Scheduling.Infrastructure {

    public class ScheduleContext : BaseDispatchDbContext
    {
        public virtual DbSet<Schedule> Schedules { get; set; }
        public virtual DbSet<Appointment> Appointments { get; set; }

        public ScheduleContext(DomainEventsDispatcher domainEventsDispatcher, DbContextOptions<ScheduleContext> options) : base(domainEventsDispatcher, options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Schedule>(entity => {
                entity.ToTable("schedule");
                entity.Ignore(s => s.DateRange);
            });
            modelBuilder.Entity<Appointment>(entity => {
                entity.ToTable("appointment");
                entity.Ignore(a => a.IsPotentiallyConflicting);
                entity.Ignore(a => a.State);
                entity.OwnsOne(a => a.TimeRange);
            });
        }
    }
}