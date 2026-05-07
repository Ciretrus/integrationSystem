using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Mobile_individ
{
    partial class StockForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            cmbProductsStock = new ComboBox();
            txtQtyStock = new TextBox();
            txtPriceStock = new TextBox();
            btnAddStock = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            SuspendLayout();

            // Выбор товара
            cmbProductsStock.Location = new Point(12, 35);
            cmbProductsStock.Name = "cmbProductsStock";
            cmbProductsStock.Size = new Size(200, 28);

            // Количество
            txtQtyStock.Location = new Point(12, 90);
            txtQtyStock.Name = "txtQtyStock";
            txtQtyStock.Size = new Size(100, 27);

            // Цена закупки
            txtPriceStock.Location = new Point(125, 90);
            txtPriceStock.Name = "txtPriceStock";
            txtPriceStock.Size = new Size(100, 27);

            // Кнопка
            btnAddStock.Location = new Point(12, 135);
            btnAddStock.Name = "btnAddStock";
            btnAddStock.Size = new Size(213, 40);
            btnAddStock.Text = "Оформить приход";
            btnAddStock.Click += btnAddStock_Click;

            // Подписи
            label1.Text = "Выберите товар:"; label1.Location = new Point(12, 12);
            label2.Text = "Кол-во:"; label2.Location = new Point(12, 70);
            label3.Text = "Цена закупки:"; label3.Location = new Point(125, 70);

            // Форма
            ClientSize = new Size(245, 195);
            Controls.AddRange(new Control[] { cmbProductsStock, txtQtyStock, txtPriceStock, btnAddStock, label1, label2, label3 });
            Text = "Приход товара";
            ResumeLayout(false);
            PerformLayout();
        }

        private ComboBox cmbProductsStock;
        private TextBox txtQtyStock;
        private TextBox txtPriceStock;
        private Button btnAddStock;
        private Label label1, label2, label3;
    }
}