namespace Mobile_individ
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

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
            btnExportExcel = new Button();
            btnOpenStock = new Button();
            btnOpenProducts = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvOrders).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvOrderItems).BeginInit();
            SuspendLayout();
            // 
            // dgvOrders
            // 
            dgvOrders.AllowUserToAddRows = false;
            dgvOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOrders.Location = new Point(12, 35);
            dgvOrders.MultiSelect = false;
            dgvOrders.Name = "dgvOrders";
            dgvOrders.ReadOnly = true;
            dgvOrders.RowHeadersWidth = 51;
            dgvOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrders.Size = new Size(450, 163);
            dgvOrders.TabIndex = 0;
            dgvOrders.SelectionChanged += dgvOrders_SelectionChanged;
            // 
            // dgvOrderItems
            // 
            dgvOrderItems.AllowUserToAddRows = false;
            dgvOrderItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOrderItems.Location = new Point(12, 245);
            dgvOrderItems.Name = "dgvOrderItems";
            dgvOrderItems.ReadOnly = true;
            dgvOrderItems.RowHeadersWidth = 51;
            dgvOrderItems.Size = new Size(450, 150);
            dgvOrderItems.TabIndex = 1;
            // 
            // txtCustomerName
            // 
            txtCustomerName.Location = new Point(480, 35);
            txtCustomerName.Name = "txtCustomerName";
            txtCustomerName.Size = new Size(200, 27);
            txtCustomerName.TabIndex = 2;
            // 
            // btnCreateOrder
            // 
            btnCreateOrder.Location = new Point(480, 68);
            btnCreateOrder.Name = "btnCreateOrder";
            btnCreateOrder.Size = new Size(200, 35);
            btnCreateOrder.TabIndex = 3;
            btnCreateOrder.Text = "Создать новый заказ";
            btnCreateOrder.UseVisualStyleBackColor = true;
            btnCreateOrder.Click += btnCreateOrder_Click;
            // 
            // cmbProducts
            // 
            cmbProducts.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProducts.FormattingEnabled = true;
            cmbProducts.Location = new Point(480, 245);
            cmbProducts.Name = "cmbProducts";
            cmbProducts.Size = new Size(200, 28);
            cmbProducts.TabIndex = 4;
            // 
            // txtQty
            // 
            txtQty.Location = new Point(480, 298);
            txtQty.Name = "txtQty";
            txtQty.Size = new Size(90, 27);
            txtQty.TabIndex = 5;
            txtQty.Text = "1";
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(590, 298);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(90, 27);
            txtPrice.TabIndex = 6;
            txtPrice.Text = "0";
            // 
            // btnAddToOrder
            // 
            btnAddToOrder.Location = new Point(480, 331);
            btnAddToOrder.Name = "btnAddToOrder";
            btnAddToOrder.Size = new Size(200, 35);
            btnAddToOrder.TabIndex = 7;
            btnAddToOrder.Text = "Добавить в заказ";
            btnAddToOrder.UseVisualStyleBackColor = true;
            btnAddToOrder.Click += btnAddToOrder_Click;
            // 
            // btnExportWord
            // 
            btnExportWord.Location = new Point(12, 401);
            btnExportWord.Name = "btnExportWord";
            btnExportWord.Size = new Size(215, 40);
            btnExportWord.TabIndex = 8;
            btnExportWord.Text = "Экспорт заказа (Word)";
            btnExportWord.UseVisualStyleBackColor = true;
            btnExportWord.Click += btnExportWord_Click;
            // 
            // btnExportExcel
            // 
            btnExportExcel.Location = new Point(247, 401);
            btnExportExcel.Name = "btnExportExcel";
            btnExportExcel.Size = new Size(215, 40);
            btnExportExcel.TabIndex = 9;
            btnExportExcel.Text = "Отчет по убыткам (Excel)";
            btnExportExcel.UseVisualStyleBackColor = true;
            btnExportExcel.Click += btnExportExcel_Click;
            // 
            // btnOpenStock
            // 
            btnOpenStock.Location = new Point(480, 120);
            btnOpenStock.Name = "btnOpenStock";
            btnOpenStock.Size = new Size(200, 35);
            btnOpenStock.TabIndex = 10;
            btnOpenStock.Text = "Склад (Приход)";
            btnOpenStock.UseVisualStyleBackColor = true;
            btnOpenStock.Click += btnOpenStock_Click;
            // 
            // btnOpenProducts
            // 
            btnOpenProducts.Location = new Point(480, 161);
            btnOpenProducts.Name = "btnOpenProducts";
            btnOpenProducts.Size = new Size(200, 35);
            btnOpenProducts.TabIndex = 11;
            btnOpenProducts.Text = "Справочник товаров";
            btnOpenProducts.UseVisualStyleBackColor = true;
            btnOpenProducts.Click += btnOpenProducts_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 12);
            label1.Name = "label1";
            label1.Size = new Size(122, 20);
            label1.TabIndex = 12;
            label1.Text = "Список заказов:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 222);
            label2.Name = "label2";
            label2.Size = new Size(111, 20);
            label2.TabIndex = 13;
            label2.Text = "Состав заказа:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(480, 12);
            label3.Name = "label3";
            label3.Size = new Size(100, 20);
            label3.TabIndex = 14;
            label3.Text = "Имя клиента:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(480, 222);
            label4.Name = "label4";
            label4.Size = new Size(126, 20);
            label4.TabIndex = 15;
            label4.Text = "Выберите товар:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(480, 275);
            label5.Name = "label5";
            label5.Size = new Size(114, 20);
            label5.TabIndex = 16;
            label5.Text = "Кол-во и Цена:";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(702, 453);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnOpenProducts);
            Controls.Add(btnOpenStock);
            Controls.Add(btnExportExcel);
            Controls.Add(btnExportWord);
            Controls.Add(btnAddToOrder);
            Controls.Add(txtPrice);
            Controls.Add(txtQty);
            Controls.Add(cmbProducts);
            Controls.Add(btnCreateOrder);
            Controls.Add(txtCustomerName);
            Controls.Add(dgvOrderItems);
            Controls.Add(dgvOrders);
            Name = "MainForm";
            Text = "Управление интернет-магазином";
            ((System.ComponentModel.ISupportInitialize)dgvOrders).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvOrderItems).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvOrders;
        private DataGridView dgvOrderItems;
        private TextBox txtCustomerName;
        private Button btnCreateOrder;
        private ComboBox cmbProducts;
        private TextBox txtQty;
        private TextBox txtPrice;
        private Button btnAddToOrder;
        private Button btnExportWord;
        private Button btnExportExcel;
        private Button btnOpenStock;
        private Button btnOpenProducts;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
    }
}