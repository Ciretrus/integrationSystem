namespace Mobile_individ
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            dgvProducts = new DataGridView();
            txtName = new TextBox();
            txtUnit = new TextBox();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            label1 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            SuspendLayout();

            // Таблица товаров
            dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProducts.Location = new Point(12, 12);
            dgvProducts.Name = "dgvProducts";
            dgvProducts.ReadOnly = true; // Только для просмотра, правим через поля
            dgvProducts.AllowUserToAddRows = false; // Отключаем пустую строку внизу
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.Size = new Size(400, 250);
            dgvProducts.TabIndex = 0;
            dgvProducts.SelectionChanged += dgvProducts_SelectionChanged;

            // Поля ввода
            txtName.Location = new Point(12, 290);
            txtName.Name = "txtName";
            txtName.Size = new Size(180, 27);

            txtUnit.Location = new Point(210, 290);
            txtUnit.Name = "txtUnit";
            txtUnit.Size = new Size(80, 27);

            // Кнопки
            btnAdd.Location = new Point(430, 12);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(120, 35);
            btnAdd.Text = "Новый";
            btnAdd.Click += btnAdd_Click;

            btnEdit.Location = new Point(430, 60);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(120, 35);
            btnEdit.Text = "Сохранить";
            btnEdit.Click += btnEdit_Click;

            btnDelete.Location = new Point(430, 108);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(120, 35);
            btnDelete.Text = "Удалить";
            btnDelete.Click += btnDelete_Click;

            // Подписи
            label1.Text = "Название товара:"; label1.Location = new Point(12, 270);
            label2.Text = "Ед. изм.:"; label2.Location = new Point(210, 270);

            // Настройка формы
            ClientSize = new Size(570, 340);
            Controls.AddRange(new Control[] { dgvProducts, txtName, txtUnit, btnAdd, btnEdit, btnDelete, label1, label2 });
            Text = "Справочник товаров";
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private DataGridView dgvProducts;
        private TextBox txtName;
        private TextBox txtUnit;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private Label label1, label2;
    }
}