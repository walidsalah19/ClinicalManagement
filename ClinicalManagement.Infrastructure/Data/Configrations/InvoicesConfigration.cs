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
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class InvoicesConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.ToTable("Invoices");

            builder.HasKey(i => i.Id);

            builder.Property(i => i.InvoiceNumber)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(i => i.ClinicName)
                .HasMaxLength(100);

            builder.Property(i => i.PaymentMethod)
                .HasMaxLength(50);

            builder.HasMany(i => i.Items)
                   .WithOne(ii => ii.Invoice)
                   .HasForeignKey(ii => ii.InvoiceId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(i => i.Appointment)
                   .WithOne(b => b.Invoice)
                   .HasForeignKey<Invoice>(i => i.appointmentId)
                   .OnDelete(DeleteBehavior.Restrict);
            
            builder.HasOne(i => i.patient)
                  .WithMany(b => b.Invoices)
                  .HasForeignKey(i => i.PatientId)
                  .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(i => i.InvoiceNumber)
                .IsUnique();
        }
    }


}
