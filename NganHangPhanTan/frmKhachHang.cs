using NganHangPhanTan.Core;
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
            LoadChiNhanhTheoRole();
            LoadKhachHang();
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
        private DataTable _dtKhachHang;

        private void LoadKhachHang()
        {
            try
            {
                string sql = @"SELECT CMND, HO, TEN, DIACHI, PHAI, NGAYCAP, SODT, MACN
                       FROM KhachHang
                       ORDER BY HO, TEN";

                _dtKhachHang = DB.Query(sql, CommandType.Text);   // ✅ dùng đúng tên biến
                dgvKH.AutoGenerateColumns = true;
                dgvKH.DataSource = _dtKhachHang;                  // ✅ dùng đúng tên biến
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải khách hàng: " + ex.Message);
            }
        }
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtCMND.Text))
            {
                MessageBox.Show("CMND không được để trống!"); return false;
            }
            if (string.IsNullOrWhiteSpace(txtHo.Text) || string.IsNullOrWhiteSpace(txtTen.Text))
            {
                MessageBox.Show("Họ và tên không được để trống!"); return false;
            }
            if (!long.TryParse(txtSDT.Text, out _))
            {
                MessageBox.Show("Số điện thoại phải là số!"); return false;
            }
            if (cbPhai.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn giới tính!"); return false;
            }
            if (cbMaCN.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn chi nhánh!"); return false;
            }
            return true;
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
            if (!ValidateInput()) return;

            try
            {
                DB.Exec("sp_ThemKhachHang",
                    new SqlParameter("@CMND", txtCMND.Text.Trim()),
                    new SqlParameter("@HO", txtHo.Text.Trim()),
                    new SqlParameter("@TEN", txtTen.Text.Trim()),
                    new SqlParameter("@DIACHI", txtDiaChi.Text.Trim()),
                    new SqlParameter("@PHAI", cbPhai.Text),
                    new SqlParameter("@NGAYCAP", dtpNgayCap.Value),
                    new SqlParameter("@SODT", txtSDT.Text.Trim()),
                    new SqlParameter("@MACN", cbMaCN.Text.Trim())
                );

                MessageBox.Show("✅ Thêm khách hàng thành công!");
                LoadKhachHang();
            }
            catch (SqlException ex)
            {
                // SP sẽ RAISERROR nếu CMND trùng hoặc mã CN sai
                MessageBox.Show("SQL Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm khách hàng: " + ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCMND.Text))
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần xóa!");
                return;
            }

            if (MessageBox.Show("Xác nhận xóa khách hàng này?", "Cảnh báo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;

            try
            {
                string sql = "DELETE FROM KhachHang WHERE CMND=@CMND";
                DB.Query(sql, CommandType.Text, new SqlParameter("@CMND", txtCMND.Text.Trim()));
                LoadKhachHang();
                MessageBox.Show("🗑️ Xóa khách hàng thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa khách hàng: " + ex.Message);
            }
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            try
            {
                string sql = @"UPDATE KhachHang 
                               SET HO=@HO, TEN=@TEN, DIACHI=@DC, PHAI=@P, NGAYCAP=@NC, SODT=@SDT 
                               WHERE CMND=@CMND";

                DB.Query(sql, CommandType.Text,
                    new SqlParameter("@HO", txtHo.Text.Trim()),
                    new SqlParameter("@TEN", txtTen.Text.Trim()),
                    new SqlParameter("@DC", txtDiaChi.Text.Trim()),
                    new SqlParameter("@P", cbPhai.Text),
                    new SqlParameter("@NC", dtpNgayCap.Value),
                    new SqlParameter("@SDT", txtSDT.Text.Trim()),
                    new SqlParameter("@CMND", txtCMND.Text.Trim())
                );

                MessageBox.Show("💾 Cập nhật thông tin khách hàng thành công!");
                LoadKhachHang();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật: " + ex.Message);
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
