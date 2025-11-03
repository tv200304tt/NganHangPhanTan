using NganHangPhanTan.Core;
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
            cbMaCN.Items.Clear();
            LoadChiNhanhTheoRole();
            LoadKhachHang();
            LoadTaiKhoan();
        }
        private void LoadChiNhanhTheoRole()
        {
            try
            {
                if (RoleHelper.IsNganHang)
                {
                    var tb = DB.Query("SELECT MACN, TENCN FROM ChiNhanh ORDER BY MACN", CommandType.Text);
                    cbMaCN.DataSource = tb;
                    cbMaCN.DisplayMember = "MACN";
                    cbMaCN.ValueMember = "MACN";
                    cbMaCN.Enabled = true;
                }
                else
                {
                    cbMaCN.Items.Clear();
                    cbMaCN.Items.Add(Session.ChiNhanhHienTai);
                    cbMaCN.SelectedIndex = 0;
                    cbMaCN.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải chi nhánh: " + ex.Message);
            }
        }
        private DataTable _dtTaiKhoan;



        private void LoadKhachHang()
        {
            try
            {
                string sql = "SELECT CMND, HO + ' ' + TEN AS HoTen FROM KhachHang ORDER BY HO, TEN";
                var tb = DB.Query(sql, CommandType.Text);
                cbCMND.DataSource = tb;
                cbCMND.DisplayMember = "CMND";
                cbCMND.ValueMember = "CMND";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải khách hàng: " + ex.Message);
            }
        }

        // 🔹 Load danh sách tài khoản
        private void LoadTaiKhoan()
        {
            try
            {
                string sql = @"SELECT SOTK, CMND, SODU, MACN, NGAYMOTK 
                               FROM TaiKhoan ORDER BY NGAYMOTK DESC";
                _dtTaiKhoan = DB.Query(sql, CommandType.Text);
                dgvTaiKhoan.DataSource = _dtTaiKhoan;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải tài khoản: " + ex.Message);
            }
        }
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtSoTK.Text))
            {
                MessageBox.Show("Số tài khoản không được để trống!"); return false;
            }
            if (cbCMND.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn khách hàng hợp lệ!"); return false;
            }
            if (!decimal.TryParse(txtSoDu.Text, out decimal sodu))
            {
                MessageBox.Show("Số dư phải là số!"); return false;
            }
            if (sodu < 100000)
            {
                MessageBox.Show("Số dư tối thiểu phải >= 100.000 VNĐ!"); return false;
            }
            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            try
            {
                DB.Exec("sp_MoTaiKhoan",
                    new SqlParameter("@SOTK", txtSoTK.Text.Trim()),
                    new SqlParameter("@CMND", cbCMND.Text.Trim()),
                    new SqlParameter("@SODU", Convert.ToDecimal(txtSoDu.Text)),
                    new SqlParameter("@MACN", cbMaCN.Text.Trim())
                );

                MessageBox.Show("✅ Đã mở tài khoản thành công!");
                LoadTaiKhoan();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi SQL: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm tài khoản: " + ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSoTK.Text))
            {
                MessageBox.Show("Vui lòng nhập số tài khoản cần xóa!");
                return;
            }

            if (MessageBox.Show("Xác nhận xóa tài khoản này?", "Cảnh báo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;

            try
            {
                DB.Query("DELETE FROM TaiKhoan WHERE SOTK=@SOTK",
                    CommandType.Text,
                    new SqlParameter("@SOTK", txtSoTK.Text.Trim()));
                MessageBox.Show("🗑️ Đã xóa tài khoản!");
                LoadTaiKhoan();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa tài khoản: " + ex.Message);
            }
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            try
            {
                string sql = @"UPDATE TaiKhoan 
                               SET CMND=@CMND, SODU=@SODU, MACN=@MACN, NGAYMOTK=@NGAYMOTK 
                               WHERE SOTK=@SOTK";
                DB.Query(sql, CommandType.Text,
                    new SqlParameter("@SOTK", txtSoTK.Text.Trim()),
                    new SqlParameter("@CMND", cbCMND.Text.Trim()),
                    new SqlParameter("@SODU", Convert.ToDecimal(txtSoDu.Text)),
                    new SqlParameter("@MACN", cbMaCN.Text.Trim()),
                    new SqlParameter("@NGAYMOTK", dtpNgayMo.Value)
                );

                MessageBox.Show("💾 Cập nhật tài khoản thành công!");
                LoadTaiKhoan();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật tài khoản: " + ex.Message);
            }
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
