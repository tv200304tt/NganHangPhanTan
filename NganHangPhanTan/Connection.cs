using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace NganHangPhanTan
{
    public static class Connection
    {
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

        // ✅ THÊM MỚI: Role và thông tin user
        public static string userRole = "";      // "NganHang", "ChiNhanh", "KhachHang"
        public static string userCMND = "";      // CMND của khách hàng (nếu là KhachHang)
        public static string displayRole = "";   // Text hiển thị role

        private static SqlConnection CreateConnection(string db, string user, string pass)
        {
            string connStr = $"Server={serverName};Database={db};User Id={user};Password={pass};TrustServerCertificate=True;Connection Timeout=30;";
            return new SqlConnection(connStr);
        }

        // ✅ Kết nối và phát hiện role tự động
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

                // ✅ PHÁT HIỆN ROLE
                DetectUserRole();

                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("❌ Không thể kết nối CSDL!\nLý do: " + ex.Message, "Lỗi SQL");
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Lỗi hệ thống: " + ex.Message, "Lỗi");
                return false;
            }
        }

        // ✅ HÀM PHÁT HIỆN ROLE TỰ ĐỘNG
        private static void DetectUserRole()
        {
            try
            {
                string query = @"
                    SELECT 
                        CASE 
                            WHEN IS_ROLEMEMBER('NganHang') = 1 THEN 'NganHang'
                            WHEN IS_ROLEMEMBER('ChiNhanh') = 1 THEN 'ChiNhanh'
                            WHEN IS_ROLEMEMBER('KhachHang') = 1 THEN 'KhachHang'
                            ELSE 'None'
                        END AS UserRole";

                using (SqlCommand cmd = new SqlCommand(query, currentConn))
                {
                    object result = cmd.ExecuteScalar();
                    userRole = result?.ToString() ?? "None";
                }

                // Set display text
                switch (userRole)
                {
                    case "NganHang":
                        displayRole = "Quản trị toàn hệ thống";
                        break;
                    case "ChiNhanh":
                        displayRole = $"Nhân viên chi nhánh {chiNhanh}";
                        break;
                    case "KhachHang":
                        displayRole = "Khách hàng";
                        // Lấy CMND từ username (format: KH_1001234567)
                        userCMND = username.Replace("KH_", "").Trim();
                        break;
                    default:
                        displayRole = "Không xác định";
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Lỗi phát hiện quyền: " + ex.Message);
                userRole = "None";
                displayRole = "Lỗi";
            }
        }

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

        // ✅ Kiểm tra quyền
        public static bool HasPermission(string requiredRole)
        {
            switch (requiredRole)
            {
                case "NganHang":
                    return userRole == "NganHang";
                case "ChiNhanh":
                    return userRole == "NganHang" || userRole == "ChiNhanh";
                case "KhachHang":
                    return true; // Tất cả đều có quyền cơ bản
                default:
                    return false;
            }
        }

        // ✅ Format MACN chuẩn (bỏ khoảng trắng thừa)
        public static string GetFormattedMACN(string chiNhanh)
        {
            return chiNhanh.Trim().PadRight(10);
        }

        public static string LoginName = "";
        public static string CurrentBranch = "";
    }
}
