using Npgsql;
using System;
using System.Data;
using System.Windows.Forms;

namespace Mobile_individ
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            LoadOrders();
            LoadProductsToCombo();
        }

        // 1. Загрузка заказов в верхнюю таблицу
        private void LoadOrders()
        {
            try
            {
                using (var conn = DbHelper.GetConnection())
                {
                    conn.Open();
                    string sql = "SELECT id, customer_name AS \"Клиент\", order_date AS \"Дата\" FROM Orders ORDER BY id DESC";
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvOrders.DataSource = dt;
                    if (dgvOrders.Columns["id"] != null) dgvOrders.Columns["id"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки заказов: " + ex.Message);
            }
        }

        // 2. Наполнение списка товаров (Выбор по названию)
        private void LoadProductsToCombo()
        {
            try
            {
                using (var conn = DbHelper.GetConnection())
                {
                    conn.Open();
                    string sql = "SELECT id, name FROM Products ORDER BY name";
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cmbProducts.DataSource = dt;
                    cmbProducts.DisplayMember = "name";
                    cmbProducts.ValueMember = "id";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки списка товаров: " + ex.Message);
            }
        }

        // 3. АВТОМАТИЧЕСКАЯ ГЕНЕРАЦИЯ СОСТАВА (При клике на строку заказа)
        private void dgvOrders_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count > 0 && dgvOrders.SelectedRows[0].Cells["id"].Value != DBNull.Value)
            {
                int orderId = Convert.ToInt32(dgvOrders.SelectedRows[0].Cells["id"].Value);
                LoadOrderItems(orderId);
            }
        }

        private void LoadOrderItems(int orderId)
        {
            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();
                string sql = @"SELECT oi.id, p.name AS ""Товар"", oi.quantity AS ""Кол-во"", oi.sale_price AS ""Цена"" 
                               FROM Order_Items oi 
                               JOIN Products p ON oi.product_id = p.id 
                               WHERE oi.order_id = @orderId";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("orderId", orderId);
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvOrderItems.DataSource = dt;
                if (dgvOrderItems.Columns["id"] != null) dgvOrderItems.Columns["id"].Visible = false;
            }
        }

        // 4. Создание нового заказа
        private void btnCreateOrder_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCustomerName.Text))
            {
                MessageBox.Show("Введите имя клиента!");
                return;
            }

            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();
                string sql = "INSERT INTO Orders (customer_name) VALUES (@name)";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("name", txtCustomerName.Text);
                cmd.ExecuteNonQuery();
            }
            LoadOrders();
            txtCustomerName.Clear();
        }

        // 5. Добавление товара в выбранный заказ
        private void btnAddToOrder_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count == 0)
            {
                MessageBox.Show("Сначала выберите заказ в верхней таблице!");
                return;
            }

            try
            {
                int orderId = Convert.ToInt32(dgvOrders.SelectedRows[0].Cells["id"].Value);
                int productId = (int)cmbProducts.SelectedValue;

                using (var conn = DbHelper.GetConnection())
                {
                    conn.Open();
                    string sql = "INSERT INTO Order_Items (order_id, product_id, quantity, sale_price) VALUES (@o, @p, @q, @s)";
                    NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("o", orderId);
                    cmd.Parameters.AddWithValue("p", productId);
                    cmd.Parameters.AddWithValue("q", int.Parse(txtQty.Text));
                    cmd.Parameters.AddWithValue("s", decimal.Parse(txtPrice.Text));
                    cmd.ExecuteNonQuery();
                }
                LoadOrderItems(orderId);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при добавлении: " + ex.Message);
            }
        }

        // 6. Экспорт в Word (через NPOI)
        private void btnExportWord_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count > 0 && dgvOrderItems.DataSource != null)
            {
                string name = dgvOrders.SelectedRows[0].Cells["Клиент"].Value.ToString();
                DataTable dt = (DataTable)dgvOrderItems.DataSource;
                WordHelper.ExportOrderToWord(name, dt);
            }
            else
            {
                MessageBox.Show("Выберите заказ с товарами для экспорта!");
            }
        }

        // 7. Экспорт отчета в Excel (через NPOI - логика убыточных товаров)
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();
                // SQL запрос для поиска товаров, проданных дешевле закупки
                string sql = @"
                    SELECT p.name, oi.quantity, pur.purchase_price, oi.sale_price
                    FROM Order_Items oi
                    JOIN Products p ON oi.product_id = p.id
                    JOIN Purchases pur ON p.id = pur.product_id
                    WHERE oi.sale_price < pur.purchase_price";

                NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                    ExcelHelper.ExportProfitReport(dt);
                else
                    MessageBox.Show("Убыточных товаров за период не найдено.");
            }
        }

        // 8. Открытие окна склада (Приход товара)
        private void btnOpenStock_Click(object sender, EventArgs e)
        {
            StockForm stockForm = new StockForm();
            stockForm.ShowDialog();
        }
        
        // 9. Открытие справочника товаров (Form1)
        private void btnOpenProducts_Click(object sender, EventArgs e)
        {
            Form1 productsForm = new Form1();
            productsForm.ShowDialog();
            LoadProductsToCombo(); // Обновляем комбобокс после закрытия, вдруг добавили новые товары
        }
    }
}