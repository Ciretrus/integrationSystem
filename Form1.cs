using Npgsql;
using System;
using System.Data;
using System.Windows.Forms;

namespace Mobile_individ
{
    public partial class Form1 : Form
    {
        private int selectedProductId = -1;

        public Form1()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();
                string sql = "SELECT id, name AS \"Название\", unit AS \"Ед. изм.\" FROM Products ORDER BY name";
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvProducts.DataSource = dt;
                if (dgvProducts.Columns["id"] != null) dgvProducts.Columns["id"].Visible = false;
            }
        }

        private void dgvProducts_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count > 0 && dgvProducts.SelectedRows[0].Cells["id"].Value != DBNull.Value)
            {
                selectedProductId = Convert.ToInt32(dgvProducts.SelectedRows[0].Cells["id"].Value);
                txtName.Text = dgvProducts.SelectedRows[0].Cells["Название"].Value?.ToString();
                txtUnit.Text = dgvProducts.SelectedRows[0].Cells["Ед. изм."].Value?.ToString();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ClearFields();
            txtName.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Заполните название!");
                return;
            }

            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();
                string sql = selectedProductId == -1
                    ? "INSERT INTO Products (name, unit) VALUES (@name, @unit)"
                    : "UPDATE Products SET name = @name, unit = @unit WHERE id = @id";

                using (var cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("name", txtName.Text);
                    cmd.Parameters.AddWithValue("unit", txtUnit.Text);
                    if (selectedProductId != -1) cmd.Parameters.AddWithValue("id", selectedProductId);
                    cmd.ExecuteNonQuery();
                }
            }
            LoadData();
            ClearFields();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedProductId == -1) return;

            var res = MessageBox.Show("Удалить товар? Это может затронуть связанные заказы!", "Внимание", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                using (var conn = DbHelper.GetConnection())
                {
                    conn.Open();
                    string sql = "DELETE FROM Products WHERE id = @id";
                    using (var cmd = new NpgsqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("id", selectedProductId);
                        try
                        {
                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Нельзя удалить товар, который уже есть в заказах!");
                        }
                    }
                }
                LoadData();
                ClearFields();
            }
        }

        private void ClearFields()
        {
            selectedProductId = -1;
            txtName.Clear();
            txtUnit.Clear();
            dgvProducts.ClearSelection();
        }
    }
}