﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Scheduling.Infrastructure;
using System;

namespace Scheduling.Infrastructure.Migrations
{
    [DbContext(typeof(ScheduleContext))]
    [Migration("20180614204329_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452");

            modelBuilder.Entity("Scheduling.Core.Domain.Model.ScheduleAggregate.Appointment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AppointmentTypeId");

                    b.Property<int>("ClientId");

                    b.Property<DateTime?>("DateTimeConfirmed");

                    b.Property<int>("DoctorId");

                    b.Property<int>("PatientId");

                    b.Property<int>("RoomId");

                    b.Property<Guid>("ScheduleId");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("ScheduleId");

                    b.ToTable("appointment");
                });

            modelBuilder.Entity("Scheduling.Core.Domain.Model.ScheduleAggregate.Schedule", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClinicId");

                    b.HasKey("Id");

                    b.ToTable("schedule");
                });

            modelBuilder.Entity("Scheduling.Core.Domain.Model.ScheduleAggregate.Appointment", b =>
                {
                    b.HasOne("Scheduling.Core.Domain.Model.ScheduleAggregate.Schedule")
                        .WithMany("Appointments")
                        .HasForeignKey("ScheduleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.OwnsOne("FrontDesk.SharedKernel.DateTimeRange", "TimeRange", b1 =>
                        {
                            b1.Property<Guid>("AppointmentId");

                            b1.Property<DateTime>("EndDate");

                            b1.Property<DateTime>("StartDate");

                            b1.ToTable("appointment");

                            b1.HasOne("Scheduling.Core.Domain.Model.ScheduleAggregate.Appointment")
                                .WithOne("TimeRange")
                                .HasForeignKey("FrontDesk.SharedKernel.DateTimeRange", "AppointmentId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });
#pragma warning restore 612, 618
        }
    }
}