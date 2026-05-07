using System;
using System.Data;
using System.IO;
using NPOI.XWPF.UserModel; // Библиотека NPOI

namespace Mobile_individ
{
    public static class WordHelper
    {
        public static void ExportOrderToWord(string customerName, DataTable items)
        {
            try
            {
                string fileName = $"Заказ_{customerName}_{DateTime.Now:yyyyMMdd_HHmm}.docx";
                string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), fileName);

                using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write))
                {
                    XWPFDocument doc = new XWPFDocument();

                    // Заголовок
                    XWPFParagraph p1 = doc.CreateParagraph();
                    p1.Alignment = ParagraphAlignment.CENTER;
                    XWPFRun r1 = p1.CreateRun();
                    r1.IsBold = true;
                    r1.FontSize = 18;
                    r1.SetText($"Заказ для клиента: {customerName}");

                    // Таблица (строки: данные + 1 для шапки; столбцы: 3)
                    XWPFTable table = doc.CreateTable(items.Rows.Count + 1, 3);
                    table.Width = 5000; // Ширина таблицы

                    // Шапка
                    table.GetRow(0).GetCell(0).SetText("Товар");
                    table.GetRow(0).GetCell(1).SetText("Кол-во");
                    table.GetRow(0).GetCell(2).SetText("Цена");

                    // Заполнение данными
                    for (int i = 0; i < items.Rows.Count; i++)
                    {
                        XWPFTableRow row = table.GetRow(i + 1);
                        row.GetCell(0).SetText(items.Rows[i]["Товар"]?.ToString() ?? "-");
                        row.GetCell(1).SetText(items.Rows[i]["Кол-во"]?.ToString() ?? "0");
                        row.GetCell(2).SetText(items.Rows[i]["Цена"]?.ToString() ?? "0");
                    }

                    doc.Write(fs);
                }

                System.Windows.Forms.MessageBox.Show($"Word-файл создан на рабочем столе:\n{fileName}");
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Ошибка NPOI (Word): " + ex.Message);
            }
        }
    }
}