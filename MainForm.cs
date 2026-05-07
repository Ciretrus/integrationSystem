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

        // Загрузка заказов в верхнюю таблицу
        private void LoadOrders()
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

        // Наполнение списка товаров (Выбор по названию, ТЗ выполнено)
        private void LoadProductsToCombo()
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

        // При клике на заказ — грузим его состав в нижнюю таблицу
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

        // Создание нового заказа
        private void btnCreateOrder_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCustomerName.Text)) return;
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

        // Добавление товара в выбранный заказ
        private void btnAddToOrder_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count == 0) return;

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

        private void btnExportWord_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Здесь будет логика экспорта в Word");
        }
    }
}