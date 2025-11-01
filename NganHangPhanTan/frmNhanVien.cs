using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace NganHangPhanTan
{
    public partial class frmNhanVien : Form
    {
        public frmNhanVien()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            cbPhai.Items.AddRange(new string[] { "Nam", "Nữ" });
            LoadChiNhanh();
            LoadNhanVien();
            dgvNhanVien.CellClick += dgvNhanVien_CellContentClick;
        }
        private void LoadChiNhanh()
        {
            string query = "SELECT MACN, TENCN FROM ChiNhanh";
            SqlDataAdapter da = new SqlDataAdapter(query, Connection.currentConn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cbMaCN.DataSource = dt;
            cbMaCN.DisplayMember = "TENCN";
            cbMaCN.ValueMember = "MACN";

            if (Connection.chiNhanh != "TONGHOP")
                cbMaCN.SelectedValue = Connection.chiNhanh;
        }

        private void LoadNhanVien()
        {
            string query = "SELECT MANV, HO, TEN, DIACHI, CMND, PHAI, SODT, MACN FROM NhanVien WHERE TrangThaiXoa = 0";
            SqlDataAdapter da = new SqlDataAdapter(query, Connection.currentConn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvNhanVien.DataSource = dt;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO NhanVien (MANV, HO, TEN, DIACHI, CMND, PHAI, SODT, MACN) VALUES (@manv, @ho, @ten, @diachi, @cmnd, @phai, @sdt, @macn)";
            using (SqlCommand cmd = new SqlCommand(query, Connection.currentConn))
            {
                cmd.Parameters.AddWithValue("@manv", txtMaNV.Text);
                cmd.Parameters.AddWithValue("@ho", txtHo.Text);
                cmd.Parameters.AddWithValue("@ten", txtTen.Text);
                cmd.Parameters.AddWithValue("@diachi", txtDiaChi.Text);
                cmd.Parameters.AddWithValue("@cmnd", txtCMND.Text);
                cmd.Parameters.AddWithValue("@phai", cbPhai.Text);
                cmd.Parameters.AddWithValue("@sdt", txtSDT.Text);
                cmd.Parameters.AddWithValue("@macn", cbMaCN.SelectedValue.ToString());
                cmd.ExecuteNonQuery();
            }
            LoadNhanVien();
            MessageBox.Show("✅ Đã thêm nhân viên mới!");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string query = "UPDATE NhanVien SET TrangThaiXoa = 1 WHERE MANV=@manv";
            using (SqlCommand cmd = new SqlCommand(query, Connection.currentConn))
            {
                cmd.Parameters.AddWithValue("@manv", txtMaNV.Text);
                cmd.ExecuteNonQuery();
            }
            LoadNhanVien();
            MessageBox.Show("🗑️ Nhân viên đã được xóa (ẩn).");
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            string query = "UPDATE NhanVien SET HO=@ho, TEN=@ten, DIACHI=@diachi, CMND=@cmnd, PHAI=@phai, SODT=@sdt, MACN=@macn WHERE MANV=@manv";
            using (SqlCommand cmd = new SqlCommand(query, Connection.currentConn))
            {
                cmd.Parameters.AddWithValue("@manv", txtMaNV.Text);
                cmd.Parameters.AddWithValue("@ho", txtHo.Text);
                cmd.Parameters.AddWithValue("@ten", txtTen.Text);
                cmd.Parameters.AddWithValue("@diachi", txtDiaChi.Text);
                cmd.Parameters.AddWithValue("@cmnd", txtCMND.Text);
                cmd.Parameters.AddWithValue("@phai", cbPhai.Text);
                cmd.Parameters.AddWithValue("@sdt", txtSDT.Text);
                cmd.Parameters.AddWithValue("@macn", cbMaCN.SelectedValue.ToString());
                cmd.ExecuteNonQuery();
            }
            LoadNhanVien();
            MessageBox.Show("💾 Dữ liệu nhân viên đã cập nhật!");
        }

        private void btnPhucHoi_Click(object sender, EventArgs e)
        {
            LoadNhanVien();
        }

        private void btnChuyenCN_Click(object sender, EventArgs e)
        {
            // ✅ Lấy thông tin nhân viên hiện tại từ form
            string maNV = txtMaNV.Text.Trim();
            string ho = txtHo.Text.Trim();
            string ten = txtTen.Text.Trim();
            string diaChi = txtDiaChi.Text.Trim();
            string cmnd = txtCMND.Text.Trim();
            string phai = cbPhai.Text.Trim();
            string sdt = txtSDT.Text.Trim();

            string maCNHienTai = Connection.chiNhanh;
            string maCNMoi = cbMaCN.SelectedValue.ToString().Trim();

            // --- Kiểm tra ---
            if (string.IsNullOrEmpty(maNV))
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần chuyển!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(maCNMoi))
            {
                MessageBox.Show("Vui lòng chọn chi nhánh cần chuyển đến!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (maCNMoi == maCNHienTai)
            {
                MessageBox.Show("Nhân viên đang ở chi nhánh này rồi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // --- Xác nhận ---
            DialogResult dr = MessageBox.Show(
                $"Bạn có chắc chắn muốn chuyển nhân viên {maNV} sang chi nhánh {maCNMoi}?",
                "Xác nhận chuyển chi nhánh",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );
            if (dr == DialogResult.No) return;

            try
            {
                // ✅ 1. Kết nối tới chi nhánh mới
                using (SqlConnection connMoi = Program.GetConnectionForBranch(maCNMoi))
                {
                    connMoi.Open();

                    // Kiểm tra trùng mã nhân viên bên chi nhánh mới
                    string checkQuery = "SELECT COUNT(*) FROM NhanVien WHERE MANV = @MANV";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, connMoi))
                    {
                        checkCmd.Parameters.AddWithValue("@MANV", maNV);
                        int exists = (int)checkCmd.ExecuteScalar();

                        if (exists > 0)
                        {
                            MessageBox.Show($"❌ Mã nhân viên {maNV} đã tồn tại ở chi nhánh {maCNMoi}.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // ✅ 2. Thêm nhân viên vào chi nhánh mới
                    string insertQuery = @"
                INSERT INTO NhanVien (MANV, HO, TEN, DIACHI, CMND, PHAI, SODT, MACN, TrangThaiXoa)
                VALUES (@MANV, @HO, @TEN, @DIACHI, @CMND, @PHAI, @SODT, @MACN, 0)";
                    using (SqlCommand insertCmd = new SqlCommand(insertQuery, connMoi))
                    {
                        insertCmd.Parameters.AddWithValue("@MANV", maNV);
                        insertCmd.Parameters.AddWithValue("@HO", ho);
                        insertCmd.Parameters.AddWithValue("@TEN", ten);
                        insertCmd.Parameters.AddWithValue("@DIACHI", diaChi);
                        insertCmd.Parameters.AddWithValue("@CMND", cmnd);
                        insertCmd.Parameters.AddWithValue("@PHAI", phai);
                        insertCmd.Parameters.AddWithValue("@SODT", sdt);
                        insertCmd.Parameters.AddWithValue("@MACN", maCNMoi);
                        insertCmd.ExecuteNonQuery();
                    }

                    connMoi.Close();
                }

                // ✅ 3. Đánh dấu đã chuyển (ẩn nhân viên ở CN hiện tại)
                string updateQuery = "UPDATE NhanVien SET TrangThaiXoa = 1 WHERE MANV=@MANV";
                using (SqlCommand cmd = new SqlCommand(updateQuery, Connection.currentConn))
                {
                    cmd.Parameters.AddWithValue("@MANV", maNV);
                    cmd.ExecuteNonQuery();
                }

                LoadNhanVien();

                MessageBox.Show($"✅ Nhân viên {maNV} đã được chuyển sang chi nhánh {maCNMoi} thành công!",
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Lỗi khi chuyển chi nhánh:\n\n{ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
