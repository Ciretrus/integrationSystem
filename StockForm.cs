using Npgsql;
using System;
using System.Data;
using System.Windows.Forms;

namespace Mobile_individ
{
    public partial class StockForm : Form
    {
        public StockForm()
        {
            InitializeComponent();
            LoadProducts();
        }

        private void LoadProducts()
        {
            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();
                string sql = "SELECT id, name FROM Products ORDER BY name";
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cmbProductsStock.DataSource = dt;
                cmbProductsStock.DisplayMember = "name";
                cmbProductsStock.ValueMember = "id";
            }
        }

        private void btnAddStock_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtQtyStock.Text) || string.IsNullOrEmpty(txtPriceStock.Text)) return;

            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();
                string sql = "INSERT INTO Purchases (product_id, quantity, purchase_price) VALUES (@p, @q, @pr)";
                using (var cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("p", cmbProductsStock.SelectedValue);
                    cmd.Parameters.AddWithValue("q", int.Parse(txtQtyStock.Text));
                    cmd.Parameters.AddWithValue("pr", decimal.Parse(txtPriceStock.Text));
                    cmd.ExecuteNonQuery();
                }
            }
            MessageBox.Show("Товар успешно добавлен на склад!");
            this.Close();
        }
    }
}