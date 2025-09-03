using ClinicalManagement.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalManagement.Infrastructure.Data.Configrations
{
    public class InvoiceItemConfiguration : IEntityTypeConfiguration<InvoiceItem>
    {
        public void Configure(EntityTypeBuilder<InvoiceItem> builder)
        {
            builder.ToTable("InvoiceItems");

            builder.HasKey(ii => ii.Id);

            builder.Property(ii => ii.ServiceName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(ii => ii.DoctorName)
                .HasMaxLength(100);

            builder.Property(ii => ii.Price)
                .HasColumnType("decimal(18,2)");

            builder.HasOne(ii => ii.Invoice)
                .WithMany(i => i.Items)
                .HasForeignKey(ii => ii.InvoiceId);
        }
    }

}
