using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using NganHangPhanTan.Core;


namespace NganHangPhanTan
{
    public partial class frmNhanVien : Form
    {
        private DataTable _dtNhanVien;
        public frmNhanVien()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            cbPhai.Items.AddRange(new[] { "Nam", "Nữ" });
            LoadChiNhanhTheoRole();
            LoadNhanVien();
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

        private void LoadNhanVien()
        {
            try
            {
                string sql = @"SELECT MANV, HO, TEN, DIACHI, CMND, PHAI, SODT, MACN 
                               FROM NhanVien WHERE TrangThaiXoa = 0 ORDER BY HO, TEN";
                _dtNhanVien = DB.Query(sql, CommandType.Text);
                dgvNhanVien.DataSource = _dtNhanVien;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải nhân viên: " + ex.Message);
            }
        }
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtMaNV.Text))
            {
                MessageBox.Show("Mã nhân viên không được để trống!"); return false;
            }
            if (string.IsNullOrWhiteSpace(txtHo.Text) || string.IsNullOrWhiteSpace(txtTen.Text))
            {
                MessageBox.Show("Họ tên nhân viên không được để trống!"); return false;
            }
            if (string.IsNullOrWhiteSpace(txtCMND.Text))
            {
                MessageBox.Show("CMND không được để trống!"); return false;
            }
            if (cbPhai.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn giới tính!"); return false;
            }
            if (!long.TryParse(txtSDT.Text, out _))
            {
                MessageBox.Show("Số điện thoại phải là số!"); return false;
            }
            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            try
            {
                string sql = @"INSERT INTO NhanVien(MANV, HO, TEN, DIACHI, CMND, PHAI, SODT, MACN, TrangThaiXoa)
                               VALUES(@MANV, @HO, @TEN, @DIACHI, @CMND, @PHAI, @SODT, @MACN, 0)";
                DB.Query(sql, CommandType.Text,
                    new SqlParameter("@MANV", txtMaNV.Text.Trim()),
                    new SqlParameter("@HO", txtHo.Text.Trim()),
                    new SqlParameter("@TEN", txtTen.Text.Trim()),
                    new SqlParameter("@DIACHI", txtDiaChi.Text.Trim()),
                    new SqlParameter("@CMND", txtCMND.Text.Trim()),
                    new SqlParameter("@PHAI", cbPhai.Text),
                    new SqlParameter("@SODT", txtSDT.Text.Trim()),
                    new SqlParameter("@MACN", cbMaCN.Text.Trim())
                );

                MessageBox.Show("✅ Đã thêm nhân viên mới!");
                LoadNhanVien();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi SQL: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm nhân viên: " + ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaNV.Text))
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần xóa!");
                return;
            }

            if (MessageBox.Show("Xác nhận xóa nhân viên này?", "Cảnh báo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;

            try
            {
                DB.Query("UPDATE NhanVien SET TrangThaiXoa = 1 WHERE MANV=@MANV",
                    CommandType.Text, new SqlParameter("@MANV", txtMaNV.Text.Trim()));

                MessageBox.Show("🗑️ Nhân viên đã được ẩn (TrangThaiXoa = 1)");
                LoadNhanVien();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa nhân viên: " + ex.Message);
            }
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            try
            {
                string sql = @"UPDATE NhanVien SET HO=@HO, TEN=@TEN, DIACHI=@DC, CMND=@CMND, 
                               PHAI=@P, SODT=@SDT, MACN=@MACN WHERE MANV=@MANV";
                DB.Query(sql, CommandType.Text,
                    new SqlParameter("@MANV", txtMaNV.Text.Trim()),
                    new SqlParameter("@HO", txtHo.Text.Trim()),
                    new SqlParameter("@TEN", txtTen.Text.Trim()),
                    new SqlParameter("@DC", txtDiaChi.Text.Trim()),
                    new SqlParameter("@CMND", txtCMND.Text.Trim()),
                    new SqlParameter("@P", cbPhai.Text),
                    new SqlParameter("@SDT", txtSDT.Text.Trim()),
                    new SqlParameter("@MACN", cbMaCN.Text.Trim())
                );

                MessageBox.Show("💾 Cập nhật thông tin nhân viên thành công!");
                LoadNhanVien();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật nhân viên: " + ex.Message);
            }
        }

        private void btnPhucHoi_Click(object sender, EventArgs e)
        {
            LoadNhanVien();
        }

        private void btnChuyenCN_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaNV.Text) || cbMaCN.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn nhân viên và chi nhánh đích!");
                return;
            }

            string maNV = txtMaNV.Text.Trim();
            string maCNMoi = cbMaCN.Text.Trim();

            if (MessageBox.Show($"Xác nhận chuyển nhân viên {maNV} sang chi nhánh {maCNMoi}?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            try
            {
                DB.Exec("sp_ChuyenNhanVien",
                    new SqlParameter("@MANV", maNV),
                    new SqlParameter("@MACN_MOI", maCNMoi)
                );

                MessageBox.Show($"✅ Nhân viên {maNV} đã được chuyển sang chi nhánh {maCNMoi}!");
                LoadNhanVien();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi SQL: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi chuyển nhân viên: " + ex.Message);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvNhanVien.Rows.Count > 0)
            {
                DataGridViewRow row = dgvNhanVien.Rows[e.RowIndex];
                txtMaNV.Text = row.Cells["MANV"].Value.ToString();
                txtHo.Text = row.Cells["HO"].Value.ToString();
                txtTen.Text = row.Cells["TEN"].Value.ToString();
                txtDiaChi.Text = row.Cells["DIACHI"].Value.ToString();
                txtCMND.Text = row.Cells["CMND"].Value.ToString();
                cbPhai.Text = row.Cells["PHAI"].Value.ToString();
                txtSDT.Text = row.Cells["SODT"].Value.ToString();
                cbMaCN.SelectedValue = row.Cells["MACN"].Value.ToString();
            }
        }
    }
}
