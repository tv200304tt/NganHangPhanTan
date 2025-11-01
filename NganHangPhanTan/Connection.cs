using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace NganHangPhanTan
{
    public static class Connection
    {
        // 🔧 ĐỔI TÊN NÀY cho đúng máy của bạn (xem trong SSMS)
        public static string serverName = @"LAPTOP-VB7EKE79";

        // 3 database
        public static string dbBenthanh = "NGANHANG_BENTHANH";
        public static string dbTandinh = "NGANHANG_TANDINH";
        public static string dbTonghop = "NGANHANG";

        // Connection hiện tại
        public static SqlConnection currentConn;

        // Thông tin người đăng nhập
        public static string username = "";
        public static string password = "";
        public static string chiNhanh = "";

        // Hàm tạo connection theo DB
        private static SqlConnection CreateConnection(string db, string user, string pass)
        {
            string connStr = $"Server={serverName};Database={db};User Id={user};Password={pass};TrustServerCertificate=True;Connection Timeout=30;";
            return new SqlConnection(connStr);
        }

        // ✅ Kết nối duy nhất theo chi nhánh
        public static bool ConnectSingle(string chiNhanh, string user, string pass)
        {
            string db = "";
            if (chiNhanh == "BENTHANH")
                db = dbBenthanh;
            else if (chiNhanh == "TANDINH")
                db = dbTandinh;
            else
                db = dbTonghop;

            try
            {
                SqlConnection conn = CreateConnection(db, user, pass);
                conn.Open();

                // Lưu thông tin hiện tại
                currentConn = conn;
                username = user;
                password = pass;
                Connection.chiNhanh = chiNhanh;

                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("❌ Không thể kết nối CSDL!\n" +
                                "Lý do: " + ex.Message, "Lỗi SQL");
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Lỗi hệ thống: " + ex.Message, "Lỗi");
                return false;
            }
        }

        // Đóng kết nối (nếu cần)
        public static void CloseConnection()
        {
            if (currentConn != null && currentConn.State == System.Data.ConnectionState.Open)
                currentConn.Close();
        }
        public static SqlConnection GetConnectionToChiNhanh(string chiNhanhMoi)
        {
            string db = "";
            if (chiNhanhMoi == "BENTHANH")
                db = dbBenthanh;
            else if (chiNhanhMoi == "TANDINH")
                db = dbTandinh;
            else
                db = dbTonghop;

            string connStr = $"Server={serverName};Database={db};User Id={username};Password={password};TrustServerCertificate=True;";
            return new SqlConnection(connStr);
        }
        public static string LoginName = "";      // Lưu tên đăng nhập hiện tại (vd: admin_nh)
        public static string CurrentBranch = "";  // Lưu mã chi nhánh hiện tại (vd: BENTHANH, TANDINH)
    }
}
