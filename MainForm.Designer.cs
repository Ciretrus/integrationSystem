namespace Mobile_individ
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            dgvOrders = new DataGridView();
            dgvOrderItems = new DataGridView();
            txtCustomerName = new TextBox();
            btnCreateOrder = new Button();
            cmbProducts = new ComboBox();
            txtQty = new TextBox();
            txtPrice = new TextBox();
            btnAddToOrder = new Button();
            btnExportWord = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvOrders).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvOrderItems).BeginInit();
            SuspendLayout();

            // Таблица Заказов (Верхняя)
            dgvOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOrders.Location = new Point(12, 35);
            dgvOrders.Name = "dgvOrders";
            dgvOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrders.Size = new Size(450, 150);
            dgvOrders.TabIndex = 0;
            dgvOrders.SelectionChanged += dgvOrders_SelectionChanged;

            // Таблица Состава (Нижняя)
            dgvOrderItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOrderItems.Location = new Point(12, 245);
            dgvOrderItems.Name = "dgvOrderItems";
            dgvOrderItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrderItems.Size = new Size(450, 150);
            dgvOrderItems.TabIndex = 1;

            // Имя клиента
            txtCustomerName.Location = new Point(480, 55);
            txtCustomerName.Name = "txtCustomerName";
            txtCustomerName.Size = new Size(200, 27);

            // Кнопка создать заказ
            btnCreateOrder.Location = new Point(480, 88);
            btnCreateOrder.Name = "btnCreateOrder";
            btnCreateOrder.Size = new Size(200, 30);
            btnCreateOrder.Text = "Создать новый заказ";
            btnCreateOrder.Click += btnCreateOrder_Click;

            // Выбор товара (ComboBox)
            cmbProducts.Location = new Point(480, 245);
            cmbProducts.Name = "cmbProducts";
            cmbProducts.Size = new Size(200, 28);

            // Количество и Цена
            txtQty.Location = new Point(480, 295);
            txtQty.Name = "txtQty";
            txtQty.Size = new Size(90, 27);
            txtQty.Text = "1";

            txtPrice.Location = new Point(590, 295);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(90, 27);
            txtPrice.Text = "0";

            // Кнопка добавить в заказ
            btnAddToOrder.Location = new Point(480, 330);
            btnAddToOrder.Name = "btnAddToOrder";
            btnAddToOrder.Size = new Size(200, 30);
            btnAddToOrder.Text = "Добавить в заказ";
            btnAddToOrder.Click += btnAddToOrder_Click;

            // Кнопка Word
            btnExportWord.Location = new Point(480, 365);
            btnExportWord.Name = "btnExportWord";
            btnExportWord.Size = new Size(200, 30);
            btnExportWord.Text = "Экспорт заказа (Word)";
            btnExportWord.Click += btnExportWord_Click;

            // Подписи (Labels)
            label1.Text = "Список заказов:"; label1.Location = new Point(12, 12);
            label2.Text = "Состав выбранного заказа:"; label2.Location = new Point(12, 220);
            label3.Text = "Клиент:"; label3.Location = new Point(480, 35);
            label4.Text = "Кол-во и Цена:"; label4.Location = new Point(480, 275);

            // MainForm
            ClientSize = new Size(710, 420);
            Controls.AddRange(new Control[] { dgvOrders, dgvOrderItems, txtCustomerName, btnCreateOrder, cmbProducts, txtQty, txtPrice, btnAddToOrder, btnExportWord, label1, label2, label3, label4 });
            Text = "Управление заказами";
            ((System.ComponentModel.ISupportInitialize)dgvOrders).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvOrderItems).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private DataGridView dgvOrders;
        private DataGridView dgvOrderItems;
        private TextBox txtCustomerName;
        private Button btnCreateOrder;
        private ComboBox cmbProducts;
        private TextBox txtQty;
        private TextBox txtPrice;
        private Button btnAddToOrder;
        private Button btnExportWord;
        private Label label1, label2, label3, label4;
    }
}