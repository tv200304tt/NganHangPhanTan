using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using NganHangPhanTan.Core;

namespace NganHangPhanTan
{
    public static class Connection
    {
        public static string serverName = @"PC\MSSQLSERVER1";

        // 3 database
        public static string dbBenthanh = "NGANHANG_BENTHANH";
        public static string dbTandinh = "NGANHANG_TANDINH";
        public static string dbTonghop = "NGANHANG";

        // ✅ Connection hiện tại - lấy từ DB.cs
        public static SqlConnection currentConn
        {
            get { return DB.GetCurrentConnection(); }
        }

        // ✅ Thông tin người đăng nhập - lấy từ DB.cs
        public static string username
        {
            get { return DB.username; }
            set { DB.username = value; }
        }

        public static string password
        {
            get { return DB.password; }
            set { DB.password = value; }
        }

        public static string chiNhanh
        {
            get { return DB.chiNhanh; }
            set { DB.chiNhanh = value; }
        }

        // ✅ Role và thông tin user - lấy từ DB.cs
        public static string userRole
        {
            get { return DB.userRole; }
            set { DB.userRole = value; }
        }

        public static string userCMND
        {
            get { return DB.userCMND; }
            set { DB.userCMND = value; }
        }

        public static string displayRole
        {
            get { return DB.displayRole; }
            set { DB.displayRole = value; }
        }

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
                // ✅ Sử dụng DB.UseConnection
                DB.UseConnection(db, user, pass);

                // ✅ Phát hiện role
                DetectUserRole();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Lỗi kết nối: " + ex.Message, "Lỗi");
                return false;
            }
        }

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

                DataTable dt = DB.Query(query, CommandType.Text);
                if (dt.Rows.Count > 0)
                {
                    userRole = dt.Rows[0]["UserRole"].ToString();
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
            DB.CloseConnection();
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

        public static bool HasPermission(string requiredRole)
        {
            switch (requiredRole)
            {
                case "NganHang":
                    return userRole == "NganHang";
                case "ChiNhanh":
                    return userRole == "NganHang" || userRole == "ChiNhanh";
                case "KhachHang":
                    return true;
                default:
                    return false;
            }
        }

        public static string GetFormattedMACN(string chiNhanh)
        {
            return chiNhanh.Trim().PadRight(10);
        }

        public static string LoginName = "";
        public static string CurrentBranch = "";
    }
}