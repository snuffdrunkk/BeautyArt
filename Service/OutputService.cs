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
                    MessageBox.Show("Для открытия документа закройте Excel!", "Ошибка!");
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

        public void ExportToExcel(DataGrid dataTable, string filePath, string title, bool should, DataRowView selectedRow)
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
                worksheet.Cells["A2:D2"].Value = "Настоящий сертификат подтверждает, что";

                for (int i = 1, j = 0; i < dataTable.Columns.Count; i++)
                {
                    worksheet.Cells[4, i].Value = dataTable.Columns[i].Header;
                }

                int lastRow = 5;

                foreach (DataRowView rowView in dataTable.Items)
                {
                    DataRow row = rowView.Row;

                    if (row["NumberStud"].ToString().Equals(selectedRow.Row.ItemArray[2]))
                    {
                        for (int col = 1; col < dataTable.Columns.Count; col++)
                        {
                            var cellValue = row.ItemArray[col]?.ToString();
                            worksheet.Cells[lastRow, col].Value = cellValue;
                        }
                        lastRow++;
                    }
                }

                var tableRange = worksheet.Cells[5, 1, lastRow - 1, dataTable.Columns.Count - 1];
                var border = tableRange.Style.Border;
                border.Left.Style = border.Right.Style = border.Top.Style = border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;

                worksheet.Cells.AutoFitColumns();

                lastRow++;

                if (should)
                    worksheet.Cells[lastRow, 1].Value = "Прослушал(а) курс в полном объеме и успешно подтвердил(а)";
                    worksheet.Cells[lastRow + 1, 1].Value = "занания на модели с использование профессионального оборудования и материалов";
                worksheet.Cells[lastRow + 2, 1].Value = "Вручила _______________ О.М.Волкова";
                try
                {
                    excelPackage.Save();
                }
                catch (Exception)
                {
                    MessageBox.Show("Для открытия документа закройте Excel!", "Ошибка!");
                    return;
                }
            }

            Process.Start(filePath);
        }

        public void ExportStudToExcel(DataGrid dataTable, string filePath, string title, bool should, DataRowView selectedRow)
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
                worksheet.Cells["A2:D2"].Value = "Исполнитель";
                worksheet.Cells["A2:D2"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
                worksheet.Cells["A4:D4"].Merge = true;
                worksheet.Cells["A4:D4"].Value = "ЧУДОВ BeautyArt";
                worksheet.Cells["A4:D4"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
                worksheet.Cells["A5:D5"].Merge = true;
                worksheet.Cells["A5:D5"].Value = "УНП 193586673";
                worksheet.Cells["A5:D5"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
                worksheet.Cells["A6:D6"].Merge = true;
                worksheet.Cells["A6:D6"].Value = "Р/С BY19 MTBK 3012 0001 0933 0010 4489 ";
                worksheet.Cells["A6:D6"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
                worksheet.Cells["A7:D7"].Merge = true;
                worksheet.Cells["A7:D7"].Value = "в ЦБУ№ 3 ЗАО «МТБанк», г. Минск, ул. Короля, 51 БИК  MTBKBY22";
                worksheet.Cells["A7:D7"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
                worksheet.Cells["A8:D8"].Merge = true;
                worksheet.Cells["A8:D8"].Value = "БИК  MTBKBY22";
                worksheet.Cells["A8:D8"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
                worksheet.Cells["A9:D9"].Merge = true;
                worksheet.Cells["A9:D9"].Value = "Юр.адрес: г.Минск, ул. Мельникайте, д. 2, оф. 708";
                worksheet.Cells["A9:D9"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
                worksheet.Cells["A10:D10"].Merge = true;
                worksheet.Cells["A10:D10"].Value = "Тел.: 8-29-643-40-07 Эл.адрес: awrora11@bk.ru";
                worksheet.Cells["A10:D10"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
                worksheet.Cells["A12:D12"].Merge = true;
                worksheet.Cells["A12:D12"].Value = "Заказчик";
                worksheet.Cells["A12:D12"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
                worksheet.Cells["A13:D13"].Merge = true;

                for (int i = 1, j = 0; i < dataTable.Columns.Count; i++)
                {
                    worksheet.Cells[14, i].Value = dataTable.Columns[i].Header;
                }

                int lastRow = 15;

                foreach (DataRowView rowView in dataTable.Items)
                {
                    DataRow row = rowView.Row;

                    if (row["PassportData"].ToString().Equals(selectedRow.Row.ItemArray[6]))
                    {
                        for (int col = 1; col < dataTable.Columns.Count; col++)
                        {
                            var cellValue = row.ItemArray[col]?.ToString();
                            worksheet.Cells[lastRow, col].Value = cellValue;
                        }
                        lastRow++;
                    }
                }

                var tableRange = worksheet.Cells[15, 1, lastRow - 1, dataTable.Columns.Count - 1];
                var border = tableRange.Style.Border;
                border.Left.Style = border.Right.Style = border.Top.Style = border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;

                worksheet.Cells.AutoFitColumns();

                lastRow++;

                if (should)
                    worksheet.Cells[lastRow, 1].Value = "_______________ О.М.Волкова";
                worksheet.Cells[lastRow + 1, 1].Value = "_______________ Заказчик";


                try
                {
                    excelPackage.Save();
                }
                catch (Exception)
                {
                    MessageBox.Show("Для открытия документа закройте Excel!", "Ошибка!");
                    return;
                }
            }

            Process.Start(filePath);
        }
    }
}
