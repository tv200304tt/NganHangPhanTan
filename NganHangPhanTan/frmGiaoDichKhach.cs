using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace NganHangPhanTan
{
    public partial class frmGiaoDichKhach : Form
    {
        public frmGiaoDichKhach()
        {
            InitializeComponent();
        }
        private bool EnsureConnection()
        {
            if (Program.currentConn == null)
            {
                // Tự động kết nối lại nếu chưa có
                string connStr = Program.GetConnectionString(Program.chiNhanh);
                Program.currentConn = new SqlConnection(connStr);
            }

            if (Program.currentConn.State != ConnectionState.Open)
            {
                try
                {
                    Program.currentConn.Open();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("⚠️ Không thể mở kết nối tới CSDL:\n" + ex.Message,
                                    "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }


        private void frmGiaoDichKhach_Load(object sender, EventArgs e)
        {


            cboLoaiGD.Items.Add("Gửi tiền");
            cboLoaiGD.Items.Add("Rút tiền");
            cboLoaiGD.Items.Add("Chuyển tiền");
            cboLoaiGD.SelectedIndex = 0;
            cboLoaiGD.SelectedIndexChanged += cboLoaiGD_SelectedIndexChanged;

            LoadDanhSachNhanVien(Program.chiNhanh);
            AutoSelectCurrentEmployee();
            UpdateButtonState();
        }
        private void LoadDanhSachNhanVien(string chiNhanh)
        {
            try
            {
                string connStr = Program.GetConnectionString(chiNhanh);

                if (string.IsNullOrEmpty(connStr))
                {
                    MessageBox.Show("❌ Không xác định được chuỗi kết nối cho chi nhánh: " + chiNhanh, "Lỗi");
                    return;
                }

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();

                    string query = "SELECT MANV, HO + ' ' + TEN AS HOTEN FROM NHANVIEN WHERE TrangThaiXoa = 0";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show($"⚠️ Chi nhánh {chiNhanh} hiện chưa có nhân viên hoạt động!", "Thông báo");
                    }

                    cboMaNV.DataSource = dt;
                    cboMaNV.DisplayMember = "HOTEN";
                    cboMaNV.ValueMember = "MANV";
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("❌ Lỗi SQL khi tải danh sách nhân viên:\n" + sqlEx.Message +
                    "\n\n👉 Kiểm tra lại instance, login và quyền truy cập của chi nhánh: " + chiNhanh,
                    "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Lỗi không xác định khi tải danh sách nhân viên:\n" + ex.Message,
                    "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AutoSelectCurrentEmployee()
        {
            try
            {
                // Nếu chưa có thông tin nhân viên hiện tại, load từ DB
                if (string.IsNullOrEmpty(Program.currentUser))
                {
                    Program.LoadCurrentUserInfo();
                }

                // Nếu vẫn không có thông tin, thông báo
                if (string.IsNullOrEmpty(Program.currentUser))
                {
                    MessageBox.Show("⚠️ Không xác định được nhân viên đang đăng nhập!", "Cảnh báo");
                    return;
                }

                // Tự động chọn nhân viên đang login
                cboMaNV.SelectedValue = Program.currentUser;

                // Disable ComboBox để không cho thay đổi (tùy chọn)
                cboMaNV.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Lỗi khi tự động chọn nhân viên: " + ex.Message, "Lỗi");
            }
        }

        private void btnThucHien_Click(object sender, EventArgs e)
        {

        }

        private void btnGoiTien_Click(object sender, EventArgs e)
        {
            if (!EnsureConnection()) return;

            string soTK = txtSoTK.Text.Trim();
            if (string.IsNullOrWhiteSpace(soTK) || string.IsNullOrWhiteSpace(txtSoTien.Text))
            {
                MessageBox.Show("Vui lòng nhập Số tài khoản và Số tiền.", "Thông báo");
                return;
            }

            decimal soTien = Convert.ToDecimal(txtSoTien.Text.Trim());
            SqlTransaction tran = Program.currentConn.BeginTransaction();

            try
            {
                // 1️⃣ Cập nhật số dư
                string updateQuery = "UPDATE TaiKhoan SET SODU = SODU + @SOTIEN WHERE SOTK = @SOTK";
                using (SqlCommand cmd = new SqlCommand(updateQuery, Program.currentConn, tran))
                {
                    cmd.Parameters.AddWithValue("@SOTK", soTK);
                    cmd.Parameters.AddWithValue("@SOTIEN", soTien);
                    int rows = cmd.ExecuteNonQuery();
                    if (rows == 0)
                        throw new Exception("Không tìm thấy tài khoản!");
                }

                // 2️⃣ Ghi lịch sử giao dịch
                string insertQuery = @"INSERT INTO GD_GOIRUT(SOTK, LOAIGD, SOTIEN, MANV, NGAYGD)
                                       VALUES(@SOTK, 'GT', @SOTIEN, @MANV, GETDATE())";
                using (SqlCommand cmd = new SqlCommand(insertQuery, Program.currentConn, tran))
                {
                    cmd.Parameters.AddWithValue("@SOTK", soTK);
                    cmd.Parameters.AddWithValue("@SOTIEN", soTien);
                    cmd.Parameters.AddWithValue("@MANV", cboMaNV.SelectedValue.ToString());
                    cmd.ExecuteNonQuery();
                }

                tran.Commit();
                MessageBox.Show("✅ Gửi tiền thành công! Số dư đã được cập nhật.", "Thành công");
            }
            catch (Exception ex)
            {
                tran.Rollback();
                MessageBox.Show("❌ Lỗi khi gửi tiền: " + ex.Message);
            }
        }

        private void btnRutTien_Click(object sender, EventArgs e)
        {
            if (!EnsureConnection()) return;

            string soTK = txtSoTK.Text.Trim();
            if (string.IsNullOrWhiteSpace(soTK) || string.IsNullOrWhiteSpace(txtSoTien.Text))
            {
                MessageBox.Show("Vui lòng nhập Số tài khoản và Số tiền.", "Thông báo");
                return;
            }

            decimal soTien = Convert.ToDecimal(txtSoTien.Text.Trim());
            SqlTransaction tran = Program.currentConn.BeginTransaction();

            try
            {
                // 1️⃣ Kiểm tra số dư
                string checkQuery = "SELECT SODU FROM TaiKhoan WHERE SOTK=@SOTK";
                decimal sodu = 0;
                using (SqlCommand cmd = new SqlCommand(checkQuery, Program.currentConn, tran))
                {
                    cmd.Parameters.AddWithValue("@SOTK", soTK);
                    object result = cmd.ExecuteScalar();
                    if (result == null) throw new Exception("Không tìm thấy tài khoản!");
                    sodu = Convert.ToDecimal(result);
                }

                if (sodu < soTien)
                    throw new Exception("Số dư không đủ để rút tiền!");

                // 2️⃣ Cập nhật số dư
                string updateQuery = "UPDATE TaiKhoan SET SODU = SODU - @SOTIEN WHERE SOTK = @SOTK";
                using (SqlCommand cmd = new SqlCommand(updateQuery, Program.currentConn, tran))
                {
                    cmd.Parameters.AddWithValue("@SOTK", soTK);
                    cmd.Parameters.AddWithValue("@SOTIEN", soTien);
                    cmd.ExecuteNonQuery();
                }

                // 3️⃣ Ghi lịch sử giao dịch
                string insertQuery = @"INSERT INTO GD_GOIRUT(SOTK, LOAIGD, SOTIEN, MANV, NGAYGD)
                                       VALUES(@SOTK, 'RT', @SOTIEN, @MANV, GETDATE())";
                using (SqlCommand cmd = new SqlCommand(insertQuery, Program.currentConn, tran))
                {
                    cmd.Parameters.AddWithValue("@SOTK", soTK);
                    cmd.Parameters.AddWithValue("@SOTIEN", soTien);
                    cmd.Parameters.AddWithValue("@MANV", cboMaNV.SelectedValue.ToString());
                    cmd.ExecuteNonQuery();
                }

                tran.Commit();
                MessageBox.Show("✅ Rút tiền thành công! Số dư đã được cập nhật.", "Thành công");
            }
            catch (Exception ex)
            {
                tran.Rollback();
                MessageBox.Show("❌ Lỗi khi rút tiền: " + ex.Message);
            }
        }

        private void btnChuyenTien_Click(object sender, EventArgs e)
        {

            if (!EnsureConnection()) return;

            string tkChuyen = txtSoTK.Text.Trim();
            string tkNhan = txtSoTKNhan.Text.Trim();

            if (string.IsNullOrWhiteSpace(tkChuyen) || string.IsNullOrWhiteSpace(tkNhan) || string.IsNullOrWhiteSpace(txtSoTien.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin chuyển tiền.", "Thông báo");
                return;
            }

            decimal soTien = Convert.ToDecimal(txtSoTien.Text.Trim());
            SqlTransaction tran = Program.currentConn.BeginTransaction();

            try
            {
                // 1️⃣ Kiểm tra số dư tài khoản chuyển
                string checkQuery = "SELECT SODU FROM TaiKhoan WHERE SOTK=@SOTK";
                decimal soduChuyen = 0;
                using (SqlCommand cmd = new SqlCommand(checkQuery, Program.currentConn, tran))
                {
                    cmd.Parameters.AddWithValue("@SOTK", tkChuyen);
                    object result = cmd.ExecuteScalar();
                    if (result == null) throw new Exception("Không tìm thấy tài khoản chuyển!");
                    soduChuyen = Convert.ToDecimal(result);
                }

                if (soduChuyen < soTien)
                    throw new Exception("Số dư tài khoản chuyển không đủ!");

                // 2️⃣ Trừ tiền người chuyển
                string updateChuyen = "UPDATE TaiKhoan SET SODU = SODU - @SOTIEN WHERE SOTK = @SOTK";
                using (SqlCommand cmd = new SqlCommand(updateChuyen, Program.currentConn, tran))
                {
                    cmd.Parameters.AddWithValue("@SOTIEN", soTien);
                    cmd.Parameters.AddWithValue("@SOTK", tkChuyen);
                    cmd.ExecuteNonQuery();
                }

                // 3️⃣ Cộng tiền người nhận
                string updateNhan = "UPDATE TaiKhoan SET SODU = SODU + @SOTIEN WHERE SOTK = @SOTK";
                using (SqlCommand cmd = new SqlCommand(updateNhan, Program.currentConn, tran))
                {
                    cmd.Parameters.AddWithValue("@SOTIEN", soTien);
                    cmd.Parameters.AddWithValue("@SOTK", tkNhan);
                    int rows = cmd.ExecuteNonQuery();
                    if (rows == 0)
                        throw new Exception("Không tìm thấy tài khoản nhận!");
                }

                // 4️⃣ Lưu lịch sử chuyển tiền
                string insertQuery = @"INSERT INTO GD_CHUYENTIEN(SOTK_CHUYEN, SOTK_NHAN, SOTIEN, MANV, NGAYGD)
                                       VALUES(@CHUYEN, @NHAN, @SOTIEN, @MANV, GETDATE())";
                using (SqlCommand cmd = new SqlCommand(insertQuery, Program.currentConn, tran))
                {
                    cmd.Parameters.AddWithValue("@CHUYEN", tkChuyen);
                    cmd.Parameters.AddWithValue("@NHAN", tkNhan);
                    cmd.Parameters.AddWithValue("@SOTIEN", soTien);
                    cmd.Parameters.AddWithValue("@MANV", cboMaNV.SelectedValue.ToString());
                    cmd.ExecuteNonQuery();
                }

                tran.Commit();
                MessageBox.Show("✅ Chuyển tiền thành công!", "Thành công");
            }
            catch (Exception ex)
            {
                tran.Rollback();
                MessageBox.Show("❌ Lỗi chuyển tiền: " + ex.Message);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboLoaiGD_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateButtonState();
        }
        private void UpdateButtonState()
        {
            string loaiGD = cboLoaiGD.SelectedItem.ToString();

            btnGoiTien.Enabled = loaiGD == "Gửi tiền";
            btnRutTien.Enabled = loaiGD == "Rút tiền";
            btnChuyenTien.Enabled = loaiGD == "Chuyển tiền";

            txtSoTKNhan.Enabled = loaiGD == "Chuyển tiền";
            if (loaiGD != "Chuyển tiền")
                txtSoTKNhan.Clear();
        }
    }
}
