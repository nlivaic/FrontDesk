using Microsoft.EntityFrameworkCore;
using Scheduling.Core.Domain.Model.ScheduleAggregate;

namespace Scheduling.Infrastructure {

    public class ScheduleContext : DbContext
    {
        public virtual DbSet<Schedule> Schedules { get; set; }
        public virtual DbSet<Appointment> Appointments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=localhost;userid=root;pwd=rootpw;port=3306;database=Scheduling;sslmode=none;");
            }
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
            });
        }
    }
}