using System;
using System.Data;
using System.IO;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace Mobile_individ
{
    public static class ExcelHelper
    {
        public static void ExportProfitReport(DataTable reportData)
        {
            try
            {
                string fileName = $"Отчет_Убытки_{DateTime.Now:yyyyMMdd_HHmm}.xlsx";
                string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), fileName);

                IWorkbook workbook = new XSSFWorkbook();
                ISheet sheet = workbook.CreateSheet("Отчет");

                // Шапка
                IRow headerRow = sheet.CreateRow(0);
                headerRow.CreateCell(0).SetCellValue("Товар");
                headerRow.CreateCell(1).SetCellValue("Кол-во");
                headerRow.CreateCell(2).SetCellValue("Цена закупки");
                headerRow.CreateCell(3).SetCellValue("Цена продажи");
                headerRow.CreateCell(4).SetCellValue("Разница");

                // Стиль для убытка (красный шрифт)
                ICellStyle redStyle = workbook.CreateCellStyle();
                IFont font = workbook.CreateFont();
                font.Color = IndexedColors.Red.Index;
                redStyle.SetFont(font);

                // Данные
                for (int i = 0; i < reportData.Rows.Count; i++)
                {
                    IRow row = sheet.CreateRow(i + 1);
                    row.CreateCell(0).SetCellValue(reportData.Rows[i]["name"].ToString());
                    row.CreateCell(1).SetCellValue(Convert.ToDouble(reportData.Rows[i]["quantity"]));
                    row.CreateCell(2).SetCellValue(Convert.ToDouble(reportData.Rows[i]["purchase_price"]));
                    row.CreateCell(3).SetCellValue(Convert.ToDouble(reportData.Rows[i]["sale_price"]));

                    double diff = Convert.ToDouble(reportData.Rows[i]["sale_price"]) - Convert.ToDouble(reportData.Rows[i]["purchase_price"]);
                    ICell diffCell = row.CreateCell(4);
                    diffCell.SetCellValue(diff);

                    if (diff < 0) diffCell.CellStyle = redStyle;
                }

                using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write))
                {
                    workbook.Write(fs);
                }

                System.Windows.Forms.MessageBox.Show($"Excel-отчет создан на рабочем столе:\n{fileName}");
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Ошибка NPOI (Excel): " + ex.Message);
            }
        }
    }
}