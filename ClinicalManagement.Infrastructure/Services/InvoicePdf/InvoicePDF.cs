using ClinicalManagement.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ClinicalManagement.Infrastructure.Services.InvoicePdf
{
    public class InvoicePDF : IDocument
    {
        public Invoice Model { get; }

        public InvoicePDF(Invoice model)
        {
            Model = model;
        }

        public DocumentMetadata GetMetadata() => DocumentMetadata.Default;
        public DocumentSettings GetSettings() => DocumentSettings.Default;
        public void Compose(IDocumentContainer container)
        {
            container
            .Page(page =>
            {
                page.Margin(50);

                page.Header().Element(ComposeHeader);
                page.Content().Element(ComposeContent);

                page.Footer().AlignCenter().Text(x =>
                {
                    x.CurrentPageNumber();
                    x.Span(" / ");
                    x.TotalPages();
                });
            });
           
        }
        void ComposeHeader(IContainer container)
        {
            container.Row(row =>
            {
                row.RelativeItem().Column(column =>
                {
                    column.Item()
                        .Text($"Invoice #{Model.InvoiceNumber}")
                        .FontSize(20).SemiBold().FontColor(Colors.Blue.Medium);

                    column.Item().Text(text =>
                    {
                        text.Span("Issue date: ").SemiBold();
                        text.Span($"{Model.Appointment.AppointmentDate:d}");
                    });

                    column.Item().Text(text =>
                    {
                        text.Span("Due date: ").SemiBold();
                        text.Span($"{Model.Date:d}");
                    });
                });

                row.ConstantItem(100).Height(50).Placeholder();
            });
        }
        void ComposeContent(IContainer container)
        {
            container.PaddingVertical(40).Column(column =>
            {
                column.Spacing(5);
                column.Item().Element(InvoiceInfo);

                column.Item().Element(ComposeTable);

                column.Item().PaddingTop(25).Element(ComposeComments);
            });
        }

        private void InvoiceInfo(IContainer container)
        {
            container.PaddingVertical(20).Table(table =>
            {
                // تعريف الأعمدة
                table.ColumnsDefinition(columns =>
                {
                    columns.RelativeColumn(); // العمود الأول (معلومات المريض)
                    columns.RelativeColumn(); // العمود الثاني (معلومات العيادة)
                });

                // الصف الأول
                table.Cell().Element(CellStyle).Text(text =>
                {
                    text.Span("Patient Name: ").SemiBold();
                    text.Span($"{Model.patient?.UserName}");
                });
                table.Cell().Element(CellStyle).Text(text =>
                {
                    text.Span("Clinic Name: ").SemiBold();
                    text.Span($"{Model.ClinicName}");
                });

                // الصف الثاني
                table.Cell().Element(CellStyle).Text(text =>
                {
                    text.Span("Patient Phone: ").SemiBold();
                    text.Span($"{Model.patient?.PhoneNumber}");
                });
                table.Cell().Element(CellStyle).Text(text =>
                {
                    text.Span("Clinic Contact: ").SemiBold();
                    text.Span($"{Model.ClinicContact}");
                });

                // الصف الثالث
                table.Cell().Element(CellStyle).Text(text =>
                {
                    text.Span("Discount: ").SemiBold();
                    text.Span($"{Model.Discount} EGP");
                });
                table.Cell().Element(CellStyle).Text(text =>
                {
                    text.Span("Payment Method: ").SemiBold();
                    text.Span($"{Model.PaymentMethod}");
                });
            });
        }

        // ستايل موحد للخلايا
        private static IContainer CellStyle(IContainer container)
        {
            return container
                .PaddingVertical(5)
                .DefaultTextStyle(x => x.FontSize(12))
                .BorderBottom(1)
                .BorderColor(Colors.Black);
        }

        void ComposeTable(IContainer container)
        {
            container.Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.ConstantColumn(15);
                    columns.RelativeColumn(3);
                    columns.RelativeColumn();
                    columns.RelativeColumn();
                    columns.RelativeColumn();
                });

                table.Header(header =>
                {
                    header.Cell().Element(CellStyle).Text("#");
                    header.Cell().Element(CellStyle).Text("ServiceName");
                    header.Cell().Element(CellStyle).AlignRight().Text("DoctorName");
                    header.Cell().Element(CellStyle).AlignRight().Text("Unit price");
                    header.Cell().Element(CellStyle).AlignRight().Text("Date");

                    //static IContainer CellStyle(IContainer container)
                    //{
                    //    return container.DefaultTextStyle(x => x.SemiBold()).PaddingVertical(5).BorderBottom(1).BorderColor(Colors.Black);
                    //}
                });

                foreach (var item in Model.Items)
                {
                    table.Cell().Element(CellStyle).Text(Model.Items.IndexOf(item) + 1);
                    table.Cell().Element(CellStyle).Text(item.ServiceName);
                    table.Cell().Element(CellStyle).AlignRight().Text(item.DoctorName);
                    table.Cell().Element(CellStyle).AlignRight().Text($"{item.Price}$");
                    table.Cell().Element(CellStyle).AlignRight().Text(item.Date);


                    //static IContainer CellStyle(IContainer container)
                    //{
                    //    return container.BorderBottom(1).BorderColor(Colors.Grey.Lighten2).PaddingVertical(5);
                    //}
                }
            });
        }

        void ComposeComments(IContainer container)
        {
            container.Background(Colors.Grey.Lighten3).Padding(10).Column(column =>
            {
                column.Spacing(5);
                column.Item().Text("Comments").FontSize(14);
                column.Item().Text("thank you for appointment with us");
            });
        }
    }

}
