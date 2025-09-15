using ClosedXML.Excel;
using SchoolHallBooking.Models;

namespace SchoolHallBooking.Services
{
    public class ExportService : IExportService
    {
        public Task<byte[]> ExportToExcelAsync(List<Booking> bookings)
        {
            using var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("حجوزات القاعات");

            // Set RTL direction for the worksheet
            worksheet.RightToLeft = true;

            // Add headers
            var headers = new[]
            {
                "اسم القاعة",
                "اسم المدرس", 
                "القسم",
                "التاريخ",
                "الحصة"
            };

            // Style the header row
            var headerRow = worksheet.Row(1);
            headerRow.Style.Font.Bold = true;
            headerRow.Style.Fill.BackgroundColor = XLColor.LightBlue;
            headerRow.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            headerRow.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

            // Add headers to the worksheet
            for (int i = 0; i < headers.Length; i++)
            {
                worksheet.Cell(1, i + 1).Value = headers[i];
            }

            // Add data rows
            for (int i = 0; i < bookings.Count; i++)
            {
                var booking = bookings[i];
                var row = i + 2; // Start from row 2 (after header)

                worksheet.Cell(row, 1).Value = booking.Hall.Name;
                worksheet.Cell(row, 2).Value = booking.TeacherName;
                worksheet.Cell(row, 3).Value = booking.Section;
                worksheet.Cell(row, 4).Value = booking.BookingDate.ToString("yyyy/MM/dd");
                worksheet.Cell(row, 5).Value = $"الحصة {booking.Period}";
            }

            // Auto-fit columns
            worksheet.Columns().AdjustToContents();

            // Add borders to all cells
            var range = worksheet.Range(1, 1, bookings.Count + 1, headers.Length);
            range.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            range.Style.Border.InsideBorder = XLBorderStyleValues.Thin;

            // Set column widths
            worksheet.Column(1).Width = 25; // اسم القاعة
            worksheet.Column(2).Width = 20; // اسم المدرس
            worksheet.Column(3).Width = 15; // القسم
            worksheet.Column(4).Width = 12; // التاريخ
            worksheet.Column(5).Width = 10; // الحصة

            // Center align all data cells
            var dataRange = worksheet.Range(2, 1, bookings.Count + 1, headers.Length);
            dataRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            dataRange.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

            using var stream = new MemoryStream();
            workbook.SaveAs(stream);
            return Task.FromResult(stream.ToArray());
        }

        public string GenerateFileName()
        {
            return $"Bookings_{DateTime.UtcNow:yyyyMMdd}.xlsx";
        }
    }
}
