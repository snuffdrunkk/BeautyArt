using OfficeOpenXml;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System;
using System.Windows.Controls;
using System.Linq;

namespace BeautyArt.Service
{
    internal class OutputService
    {
        public void ExportScheduleToExcel(DataGrid dataTable, string filePath, string title, bool should)
        {
            using (ExcelPackage excelPackage = new ExcelPackage(new FileInfo(filePath)))
            {
                if (excelPackage.Workbook.Worksheets.Any(x => x.Name.Equals(title)))
                {
                    excelPackage.Workbook.Worksheets.Delete(title);
                }

                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add(title);
                worksheet.PrinterSettings.Orientation = eOrientation.Landscape;

                worksheet.Cells["A1:D1"].Merge = true;
                worksheet.Cells["A1:D1"].Value = title;
                worksheet.Cells["A1:D1"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                worksheet.Cells["A2:D2"].Merge = true;
                worksheet.Cells["A2:D2"].Value = "ЧУДОВ BeautyArt";
                worksheet.Cells["A2:D2"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
                worksheet.Cells["A4:D4"].Merge = true;
                worksheet.Cells["A4:D4"].Value = "Главный офис";
                worksheet.Cells["A4:D4"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
                worksheet.Cells["A5:D5"].Merge = true;
                worksheet.Cells["A5:D5"].Value = "Адрес: г.Минск, ул. Мельникайте, 2";
                worksheet.Cells["A5:D5"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
                worksheet.Cells["A6:D6"].Merge = true;

                for (int i = 1, j = 0; i < dataTable.Columns.Count; i++)
                {
                    worksheet.Cells[7, i].Value = dataTable.Columns[i].Header;
                }

                int lastRow = 8;

                foreach (DataRowView rowView in dataTable.Items)
                {
                    DataRow row = rowView.Row;

                    for (int col = 1; col < dataTable.Columns.Count; col++)
                    {
                        var cellValue = row.ItemArray[col]?.ToString();
                        worksheet.Cells[lastRow, col].Value = cellValue;
                    }

                    lastRow++;
                }


                var tableRange = worksheet.Cells[7, 1, lastRow - 1, dataTable.Columns.Count - 1];
                var border = tableRange.Style.Border;
                border.Left.Style = border.Right.Style = border.Top.Style = border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;

                worksheet.Cells.AutoFitColumns();

                lastRow++;

                if (should)
                    worksheet.Cells[lastRow, 1].Value = "Составил: _______________";

                try
                {
                    excelPackage.Save();
                }
                catch (Exception)
                {
                    MessageBox.Show("Для открытия отчёта закройте Excel!");
                    return;
                }
            }

            Process.Start(filePath);
        }

        public void ExportScheduleToExcelWithDate(DataGrid dataTable, string filePath, string title, bool should, DateTime firstDate, DateTime secondDate)
        {
            using (ExcelPackage excelPackage = new ExcelPackage(new FileInfo(filePath)))
            {
                if (excelPackage.Workbook.Worksheets.Any(x => x.Name.Equals(title)))
                {
                    excelPackage.Workbook.Worksheets.Delete(title);
                }

                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add(title);
                worksheet.PrinterSettings.Orientation = eOrientation.Landscape;

                worksheet.Cells["A1:D1"].Merge = true;
                worksheet.Cells["A1:D1"].Value = title;
                worksheet.Cells["A1:D1"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                worksheet.Cells["A2:D2"].Merge = true;
                worksheet.Cells["A2:D2"].Value = "ЧУДОВ BeautyArt";
                worksheet.Cells["A2:D2"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
                worksheet.Cells["A4:D4"].Merge = true;
                worksheet.Cells["A4:D4"].Value = "Главный офис";
                worksheet.Cells["A4:D4"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
                worksheet.Cells["A5:D5"].Merge = true;
                worksheet.Cells["A5:D5"].Value = "Адрес: г.Минск, ул. Мельникайте, 2";
                worksheet.Cells["A5:D5"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
                worksheet.Cells["A6:D6"].Merge = true;

                for (int i = 1, j = 0; i < dataTable.Columns.Count; i++)
                {
                    worksheet.Cells[7, i].Value = dataTable.Columns[i].Header;
                }

                int lastRow = 8;

                foreach (DataRowView rowView in dataTable.Items)
                {
                    DataRow row = rowView.Row;

                    DateTime orderDate = (DateTime)row["Date"];

                    if (orderDate >= firstDate && orderDate <= secondDate)
                    {
                        for (int col = 1; col < dataTable.Columns.Count; col++)
                        {
                            var cellValue = row.ItemArray[col]?.ToString();
                            worksheet.Cells[lastRow, col].Value = cellValue;
                        }

                        lastRow++;
                    }
                }

                var tableRange = worksheet.Cells[7, 1, lastRow - 1, dataTable.Columns.Count - 1];
                var border = tableRange.Style.Border;
                border.Left.Style = border.Right.Style = border.Top.Style = border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;

                worksheet.Cells.AutoFitColumns();

                lastRow++;

                if (should)
                    worksheet.Cells[lastRow, 1].Value = "Составил: _______________";

                try
                {
                    excelPackage.Save();
                }
                catch (Exception)
                {
                    MessageBox.Show("Для открытия отчёта закройте Excel!");
                    return;
                }
            }

            Process.Start(filePath);
        }
    }
}
