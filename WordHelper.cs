using System;
using System.Data;

namespace Mobile_individ
{
    public static class WordHelper
    {
        public static void ExportOrderToWord(string customerName, DataTable items)
        {
            try
            {
                Type wordType = Type.GetTypeFromProgID("Word.Application");
                if (wordType == null)
                {
                    System.Windows.Forms.MessageBox.Show("MS Word не установлен!");
                    return;
                }

                dynamic wordApp = Activator.CreateInstance(wordType);
                wordApp.Visible = true;

                // Добавляем документ
                dynamic documents = wordApp.Documents;
                dynamic document = documents.Add();

                // Пишем заголовок напрямую в начало документа
                dynamic range = document.Range(0, 0);
                range.Text = $"Заказ для клиента: {customerName}\n\n";
                range.Font.Bold = 1;
                range.Font.Size = 16;

                // Определяем место для таблицы (в конце документа)
                int end = document.Content.End;
                dynamic tableRange = document.Range(end - 1, end - 1);

                // Создаем таблицу
                dynamic tables = document.Tables;
                dynamic table = tables.Add(tableRange, items.Rows.Count + 1, 3);
                table.Borders.Enable = 1; // Включаем границы

                // Шапка таблицы
                table.Cell(1, 1).Range.Text = "Товар";
                table.Cell(1, 2).Range.Text = "Кол-во";
                table.Cell(1, 3).Range.Text = "Цена";

                // Данные
                for (int i = 0; i < items.Rows.Count; i++)
                {
                    table.Cell(i + 2, 1).Range.Text = items.Rows[i]["Товар"]?.ToString();
                    table.Cell(i + 2, 2).Range.Text = items.Rows[i]["Кол-во"]?.ToString();
                    table.Cell(i + 2, 3).Range.Text = items.Rows[i]["Цена"]?.ToString();
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Ошибка Word: " + ex.Message);
            }
        }
    }
}