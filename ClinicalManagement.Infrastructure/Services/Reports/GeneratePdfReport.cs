using ClinicalManagement.Application.Abstractions.GenerateReport;
using ClinicalManagement.Domain.Models;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using SkiaSharp;

namespace ClinicalManagement.Infrastructure.Services.Reports
{
    public class GeneratePdfReport : IGenerateReport
    {
        public byte[] GenerateAppointmentsPdf(List<Appointment> data, DateTime from, DateTime to, string? doctor = null)
        {
            var totalAppointments = data.Count;
            var groupedByStatus = data.GroupBy(a => a.Status)
                                      .Select(g => new ChartData { Status = g.Key, Count = g.Count() })
                                      .ToList();

            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(50);

                    // ✅ Header
                    page.Header().Row(row =>
                    {
                        row.RelativeItem().Column(column =>
                        {
                            column.Item().Text($"Appointments Report").FontSize(20).SemiBold().FontColor(Colors.Blue.Medium);
                            column.Item().Text($"Doctor: {doctor ?? "All"}");
                            column.Item().Text($"From: {from:dd/MM/yyyy}  To: {to:dd/MM/yyyy}");
                        });

                        //row.ConstantItem(80).Height(50).Image("wwwroot/images/logo.png", ImageScaling.FitArea);
                    });

                    // ✅ Content
                    page.Content().Column(column =>
                    {
                        column.Spacing(10);

                        // Table of Appointments
                        column.Item().Text("Appointments Details").FontSize(14).Bold();
                        column.Item().Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.ConstantColumn(30);
                                columns.RelativeColumn(2);
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                            });

                            // Header
                            table.Header(header =>
                            {
                                header.Cell().Text("#").SemiBold();
                                header.Cell().Text("Patient").SemiBold();
                                header.Cell().AlignRight().Text("Date").SemiBold();
                                header.Cell().AlignRight().Text("Status").SemiBold();
                            });

                            int index = 1;
                            foreach (var item in data)
                            {
                                table.Cell().Text(index++);
                                table.Cell().Text(item.Patient.UserName);
                                table.Cell().AlignRight().Text(item.AppointmentDate.ToString("dd/MM/yyyy"));
                                table.Cell().AlignRight().Text(item.Status);
                            }
                        });

                        // ✅ Pie Chart
                        column.Item().Text("Appointments Distribution").FontSize(14).Bold();
                        column.Item().Element(container =>
                        {
                            var chartImage = GeneratePieChart(groupedByStatus);
                            container.Image(chartImage, ImageScaling.FitWidth);
                        });
                    });

                    // ✅ Footer
                    page.Footer().AlignCenter().Text(x =>
                    {
                        x.CurrentPageNumber();
                        x.Span(" / ");
                        x.TotalPages();
                    });
                });
            });

            return document.GeneratePdf();
        }

     
        private byte[] GeneratePieChart(List<ChartData> groupedData)
        {
            int width = 400;
            int height = 400;

            using var surface = SKSurface.Create(new SKImageInfo(width, height));
            var canvas = surface.Canvas;
            canvas.Clear(SKColors.White);

            var total = groupedData.Sum(x => (int)x.Count);
            float startAngle = 0;
            var paint = new SKPaint { IsAntialias = true };

            var colors = new[] { SKColors.Blue, SKColors.Green, SKColors.Red, SKColors.Orange, SKColors.Purple };
            int colorIndex = 0;

            foreach (var item in groupedData)
            {
                float sweepAngle = 360f * item.Count / total;
                paint.Color = colors[colorIndex % colors.Length];
                canvas.DrawArc(new SKRect(50, 50, width - 50, height - 50), startAngle, sweepAngle, true, paint);
                startAngle += sweepAngle;
                colorIndex++;
            }

            using var image = surface.Snapshot();
            using var dataImage = image.Encode(SKEncodedImageFormat.Png, 100);
            return dataImage.ToArray();
        }
    }
    public class ChartData
    {
        public string Status { get; set; }
        public int Count { get; set; }
    }
}
