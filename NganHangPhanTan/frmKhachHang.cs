using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace NganHangPhanTan
{
    public partial class frmKhachHang : Form
    {
        public frmKhachHang()
        {
            InitializeComponent();
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            cbPhai.Items.AddRange(new string[] { "Nam", "Nữ" });
            LoadChiNhanhTheoPhanQuyen();
            LoadKhachHang();
        }
        private void LoadChiNhanhTheoPhanQuyen()
        {
            try
            {
                if (Connection.chiNhanh == "TONGHOP")
                {
                    // Cho phép chọn chi nhánh (dữ liệu từ bảng ChiNhanh)
                    string query = "SELECT MACN FROM ChiNhanh";
                    SqlDataAdapter da = new SqlDataAdapter(query, Connection.currentConn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cbMaCN.DataSource = dt;
                    cbMaCN.DisplayMember = "MACN";
                    cbMaCN.ValueMember = "MACN";
                    cbMaCN.Enabled = true;
                }
                else
                {
                    // Gán mã CN cố định
                    cbMaCN.Items.Clear();
                    cbMaCN.Items.Add(Connection.chiNhanh);
                    cbMaCN.SelectedIndex = 0;
                    cbMaCN.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải chi nhánh: " + ex.Message);
            }
        }

        private void LoadKhachHang()
        {
            string query = "SELECT * FROM dbo.KhachHang";
            SqlDataAdapter da = new SqlDataAdapter(query, Connection.currentConn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dgvKH.DataSource = dt;

            // ✅ Xóa ràng buộc cũ (tránh trùng)
            txtCMND.DataBindings.Clear();
            txtHo.DataBindings.Clear();
            txtTen.DataBindings.Clear();
            txtDiaChi.DataBindings.Clear();
            cbPhai.DataBindings.Clear();
            txtSDT.DataBindings.Clear();
            dtpNgayCap.DataBindings.Clear();

            // ✅ Tạo ràng buộc mới
            txtCMND.DataBindings.Add("Text", dt, "CMND");
            txtHo.DataBindings.Add("Text", dt, "HO");
            txtTen.DataBindings.Add("Text", dt, "TEN");
            txtDiaChi.DataBindings.Add("Text", dt, "DIACHI");
            cbPhai.DataBindings.Add("Text", dt, "PHAI");
            txtSDT.DataBindings.Add("Text", dt, "SODT");
            dtpNgayCap.DataBindings.Add("Value", dt, "NGAYCAP");
        }
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCMND.Text))
            {
                MessageBox.Show("Vui lòng nhập CMND!");
                return;
            }

            string query = "INSERT INTO KhachHang(CMND, HO, TEN, DIACHI, PHAI, NGAYCAP, SODT, MACN) " +
                           "VALUES (@cmnd, @ho, @ten, @diachi, @phai, @ngaycap, @sdt, @macn)";

            using (SqlCommand cmd = new SqlCommand(query, Connection.currentConn))
            {
                cmd.Parameters.AddWithValue("@cmnd", txtCMND.Text);
                cmd.Parameters.AddWithValue("@ho", txtHo.Text);
                cmd.Parameters.AddWithValue("@ten", txtTen.Text);
                cmd.Parameters.AddWithValue("@diachi", txtDiaChi.Text);
                cmd.Parameters.AddWithValue("@phai", cbPhai.Text);
                cmd.Parameters.AddWithValue("@ngaycap", dtpNgayCap.Value);
                cmd.Parameters.AddWithValue("@sdt", txtSDT.Text);
                cmd.Parameters.AddWithValue("@macn", cbMaCN.Text);

                cmd.ExecuteNonQuery();
            }

            LoadKhachHang(); // Nạp lại danh sách
            MessageBox.Show("✅ Đã thêm khách hàng mới!");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "DELETE FROM KhachHang WHERE CMND = @CMND";
                SqlCommand cmd = new SqlCommand(query, Connection.currentConn);
                cmd.Parameters.AddWithValue("@CMND", txtCMND.Text);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Xóa khách hàng thành công!");
                LoadKhachHang();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa khách hàng: " + ex.Message);
            }
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {

            try
            {
                string query = "UPDATE KhachHang SET HO = @HO, TEN = @TEN, DIACHI = @DIACHI, " +
                               "PHAI = @PHAI, NGAYCAP = @NGAYCAP, SODT = @SODT WHERE CMND = @CMND";
                SqlCommand cmd = new SqlCommand(query, Connection.currentConn);
                cmd.Parameters.AddWithValue("@CMND", txtCMND.Text);
                cmd.Parameters.AddWithValue("@HO", txtHo.Text);
                cmd.Parameters.AddWithValue("@TEN", txtTen.Text);
                cmd.Parameters.AddWithValue("@DIACHI", txtDiaChi.Text);
                cmd.Parameters.AddWithValue("@PHAI", cbPhai.Text);
                cmd.Parameters.AddWithValue("@NGAYCAP", dtpNgayCap.Value);
                cmd.Parameters.AddWithValue("@SODT", txtSDT.Text);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Cập nhật thông tin khách hàng thành công!");
                LoadKhachHang();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật khách hàng: " + ex.Message);
            }
        }

        private void btnPhucHoi_Click(object sender, EventArgs e)
        {
            txtCMND.Clear();
            txtHo.Clear();
            txtTen.Clear();
            txtDiaChi.Clear();
            txtSDT.Clear();
            cbPhai.SelectedIndex = -1;
            dtpNgayCap.Value = DateTime.Now;
        }

        private void dgvKH_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvKH.Rows[e.RowIndex];
                txtCMND.Text = row.Cells["CMND"].Value.ToString();
                txtHo.Text = row.Cells["HO"].Value.ToString();
                txtTen.Text = row.Cells["TEN"].Value.ToString();
                txtDiaChi.Text = row.Cells["DIACHI"].Value.ToString();
                cbPhai.Text = row.Cells["PHAI"].Value.ToString();
                dtpNgayCap.Value = Convert.ToDateTime(row.Cells["NGAYCAP"].Value);
                txtSDT.Text = row.Cells["SODT"].Value.ToString();
            }
        }
    }
}
