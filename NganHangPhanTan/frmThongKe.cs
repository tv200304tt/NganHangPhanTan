using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace NganHangPhanTan
{
    public partial class frmThongKe : Form
    {
        public frmThongKe()
        {
            InitializeComponent();
        }

        private void frmThongKe_Load(object sender, EventArgs e)
        {
            // ✅ Load danh sách chi nhánh
            cbChiNhanh.Items.Clear();
            cbChiNhanh.Items.Add("BENTHANH");
            cbChiNhanh.Items.Add("TANDINH");
            cbChiNhanh.Items.Add("TONGHOP");

            // ✅ Thiết lập chi nhánh mặc định theo login
            string currentBranch = Program.chiNhanh.ToUpper();

            if (currentBranch == "BENTHANH")
            {
                cbChiNhanh.SelectedItem = "BENTHANH";
                cbChiNhanh.Enabled = false; // chỉ xem chi nhánh của mình
            }
            else if (currentBranch == "TANDINH")
            {
                cbChiNhanh.SelectedItem = "TANDINH";
                cbChiNhanh.Enabled = false;
            }
            else // nếu là tài khoản tổng hợp
            {
                cbChiNhanh.SelectedItem = "TONGHOP";
                cbChiNhanh.Enabled = true; // cho phép chọn tất cả
            }

            // ✅ Loại báo cáo
            cboLoaiBaoCao.Items.Clear();
            cboLoaiBaoCao.Items.Add("1. Sao kê giao dịch theo tài khoản");
            cboLoaiBaoCao.Items.Add("2. Liệt kê tài khoản mở theo khoảng thời gian");
            cboLoaiBaoCao.Items.Add("3. Liệt kê khách hàng theo chi nhánh");
            cboLoaiBaoCao.SelectedIndex = 0;

            dtTuNgay.Value = DateTime.Today.AddMonths(-1);
            dtDenNgay.Value = DateTime.Today;
        }

        private void btnThucHien_Click(object sender, EventArgs e)
        {
            string chiNhanh = cbChiNhanh.SelectedItem.ToString();
            string connStr = Program.GetConnectionString(chiNhanh);

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                switch (cboLoaiBaoCao.SelectedIndex)
                {
                    case 0:
                        ThongKeSaoKe(conn);
                        break;
                    case 1:
                        LietKeTaiKhoan(conn);
                        break;
                    case 2:
                        LietKeKhachHang(conn);
                        break;
                }

                conn.Close();
            }
        }
        private void ThongKeSaoKe(SqlConnection conn)
        {
            string stk = txtSoTK.Text.Trim();
            DateTime tuNgay = dtTuNgay.Value;
            DateTime denNgay = dtDenNgay.Value;

            SqlCommand cmd = new SqlCommand("sp_SaoKeTaiKhoan", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SOTK", stk);
            cmd.Parameters.AddWithValue("@TUNGAY", tuNgay);
            cmd.Parameters.AddWithValue("@DENNGAY", denNgay);

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Không có giao dịch trong khoảng thời gian này.");
                return;
            }

            // Lấy số dư đầu kỳ
            decimal soDu = Convert.ToDecimal(dt.Rows[0]["SoDuDauKy"]);

            // Thêm cột số dư sau giao dịch nếu chưa có
            if (!dt.Columns.Contains("SODU_SAU_GD"))
                dt.Columns.Add("SODU_SAU_GD", typeof(decimal));

            // Tính số dư sau giao dịch
            foreach (DataRow row in dt.Rows)
            {
                string loai = row["LOAIGD"].ToString();
                decimal soTien = Convert.ToDecimal(row["SOTIEN"]);

                if (loai == "GT" || loai == "NHAN") // Gửi tiền hoặc nhận chuyển khoản
                    soDu += soTien;
                else // Rút hoặc chuyển đi
                    soDu -= soTien;

                row["SODU_SAU_GD"] = soDu;
            }

            // Hiển thị
            dgvBaoCao.DataSource = dt;
            dgvBaoCao.Columns["SOTIEN"].DefaultCellStyle.Format = "N0";
            dgvBaoCao.Columns["SODU_SAU_GD"].DefaultCellStyle.Format = "N0";

            // Lấy số dư cuối kỳ
            decimal soDuCuoiKy = soDu;

            lblThongTin.Text =
                $"📘 Sao kê tài khoản {stk}\n" +
                $"Từ {tuNgay:dd/MM/yyyy} đến {denNgay:dd/MM/yyyy}\n" +
                $"Số dư đầu kỳ: {Convert.ToDecimal(dt.Rows[0]["SoDuDauKy"]):N0}\n" +
                $"Số dư cuối kỳ: {soDuCuoiKy:N0}";
        }





        // ✅ Xác định trong GD_CHUYENTIEN là người nhận hay người gửi
        private bool IsNhanTien(string soTK, SqlConnection conn, DataRow gdRow)
        {
            // Giả sử GD_CHUYENTIEN có cột SOTK_NHAN
            string query = "SELECT SOTK_NHAN FROM GD_CHUYENTIEN WHERE SOTK_NHAN = @SOTK AND NGAYGD = @NGAY";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@SOTK", soTK);
            cmd.Parameters.AddWithValue("@NGAY", gdRow["NGAYGD"]);
            object result = cmd.ExecuteScalar();
            return result != null;
        }

        // ======================== 2️⃣ LIỆT KÊ TÀI KHOẢN ==========================
        private void LietKeTaiKhoan(SqlConnection conn)
        {
            DateTime tuNgay = dtTuNgay.Value.Date;
            DateTime denNgay = dtDenNgay.Value.Date;
            string query = @"
                SELECT SOTK, CMND, SODU, NGAYMOTK, MACN
                FROM TaiKhoan
                WHERE NGAYMOTK BETWEEN @TUNGAY AND @DENNGAY
                ORDER BY MACN, NGAYMOTK";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            da.SelectCommand.Parameters.AddWithValue("@TUNGAY", tuNgay);
            da.SelectCommand.Parameters.AddWithValue("@DENNGAY", denNgay);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvBaoCao.DataSource = dt;

            lblThongTin.Text = $"📊 Tài khoản mở từ {tuNgay:dd/MM/yyyy} đến {denNgay:dd/MM/yyyy}";
        }

        // ======================== 3️⃣ LIỆT KÊ KHÁCH HÀNG ========================
        private void LietKeKhachHang(SqlConnection conn)
        {
            string query = @"
                SELECT MACN, HO + ' ' + TEN AS HOTEN, CMND, DIACHI, SODT
                FROM KhachHang
                ORDER BY MACN, HO, TEN";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvBaoCao.DataSource = dt;
            lblThongTin.Text = $"📋 Danh sách khách hàng theo từng chi nhánh (tăng dần theo họ tên)";
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
