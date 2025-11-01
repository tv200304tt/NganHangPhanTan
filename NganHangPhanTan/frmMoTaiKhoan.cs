using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace NganHangPhanTan
{
    public partial class frmMoTaiKhoan : Form
    {
        public frmMoTaiKhoan()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmMoTaiKhoan_Load(object sender, EventArgs e)
        {
            LoadChiNhanh();
            LoadKhachHang();
            LoadTaiKhoan();
        }
        private void LoadChiNhanh()
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

        // 🔹 Load danh sách khách hàng (CMND)
        private void LoadKhachHang()
        {
            string query = "SELECT CMND FROM dbo.KhachHang";
            SqlDataAdapter da = new SqlDataAdapter(query, Connection.currentConn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cbCMND.DataSource = dt;
            cbCMND.DisplayMember = "CMND";
            cbCMND.ValueMember = "CMND";
        }

        // 🔹 Load danh sách tài khoản
        private void LoadTaiKhoan()
        {
            string query = "SELECT SOTK, CMND, SODU, MACN, NGAYMOTK FROM dbo.TaiKhoan";
            SqlDataAdapter da = new SqlDataAdapter(query, Connection.currentConn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvTaiKhoan.DataSource = dt;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSoTK.Text))
            {
                MessageBox.Show("Vui lòng nhập số tài khoản!");
                return;
            }

            string query = "INSERT INTO TaiKhoan (SOTK, CMND, SODU, MACN, NGAYMOTK) " +
                           "VALUES (@sotk, @cmnd, @sodu, @macn, @ngaymo)";
            using (SqlCommand cmd = new SqlCommand(query, Connection.currentConn))
            {
                cmd.Parameters.AddWithValue("@sotk", txtSoTK.Text);
                cmd.Parameters.AddWithValue("@cmnd", cbCMND.Text);
                cmd.Parameters.AddWithValue("@sodu", Convert.ToDecimal(txtSoDu.Text));
                cmd.Parameters.AddWithValue("@macn", cbMaCN.Text);
                cmd.Parameters.AddWithValue("@ngaymo", dtpNgayMo.Value);
                cmd.ExecuteNonQuery();
            }

            LoadTaiKhoan();
            MessageBox.Show("✅ Đã mở tài khoản thành công!");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSoTK.Text))
            {
                MessageBox.Show("Vui lòng nhập số tài khoản cần xóa!");
                return;
            }

            string query = "DELETE FROM TaiKhoan WHERE SOTK = @sotk";
            using (SqlCommand cmd = new SqlCommand(query, Connection.currentConn))
            {
                cmd.Parameters.AddWithValue("@sotk", txtSoTK.Text);
                cmd.ExecuteNonQuery();
            }

            LoadTaiKhoan();
            MessageBox.Show("🗑️ Đã xóa tài khoản!");
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            string query = "UPDATE TaiKhoan SET CMND=@cmnd, SODU=@sodu, MACN=@macn, NGAYMOTK=@ngaymo WHERE SOTK=@sotk";
            using (SqlCommand cmd = new SqlCommand(query, Connection.currentConn))
            {
                cmd.Parameters.AddWithValue("@sotk", txtSoTK.Text);
                cmd.Parameters.AddWithValue("@cmnd", cbCMND.Text);
                cmd.Parameters.AddWithValue("@sodu", Convert.ToDecimal(txtSoDu.Text));
                cmd.Parameters.AddWithValue("@macn", cbMaCN.Text);
                cmd.Parameters.AddWithValue("@ngaymo", dtpNgayMo.Value);
                cmd.ExecuteNonQuery();
            }

            LoadTaiKhoan();
            MessageBox.Show("💾 Đã cập nhật tài khoản!");
        }

        private void btnPhucHoi_Click(object sender, EventArgs e)
        {
            LoadTaiKhoan();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvTaiKhoan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtSoTK.Text = dgvTaiKhoan.Rows[e.RowIndex].Cells["SOTK"].Value.ToString();
                cbCMND.Text = dgvTaiKhoan.Rows[e.RowIndex].Cells["CMND"].Value.ToString();
                txtSoDu.Text = dgvTaiKhoan.Rows[e.RowIndex].Cells["SODU"].Value.ToString();
                cbMaCN.Text = dgvTaiKhoan.Rows[e.RowIndex].Cells["MACN"].Value.ToString();
                dtpNgayMo.Value = Convert.ToDateTime(dgvTaiKhoan.Rows[e.RowIndex].Cells["NGAYMOTK"].Value);
            }
        }
    }
}
