using ClinicalManagement.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalManagement.Infrastructure.Data.Configrations
{
    public class AppointmentConfigrations : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.ToTable("Appointments");

            builder.HasKey(a => a.Id);

            builder.HasIndex(a => a.PatientId)
                 .HasDatabaseName("IX_Appointment_PatientId")
                 .IsUnique(false);
           
            builder.HasIndex(a => new { a.DoctorId, a.AppointmentDate })
                   .IsUnique();


            builder.Property(a => a.AppointmentDate)
                   .IsRequired();

            builder.Property(a => a.Status)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(a => a.Notes)
                .HasMaxLength(500);

            builder.Property(a => a.DoctorId)
                .IsRequired();

            builder.HasOne(a => a.Doctor)
                .WithMany(d => d.Appointments)
                .HasForeignKey(a => a.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(a => a.PatientId)
                .IsRequired();

            builder.HasOne(a => a.Patient)
                .WithMany(p => p.Appointments)
                .HasForeignKey(a => a.PatientId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
