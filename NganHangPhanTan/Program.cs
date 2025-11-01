using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace NganHangPhanTan
{
    internal static class Program
    {
        public static SqlConnection currentConn;
        public static string chiNhanh = "";
        public static string connStr = "";

        public static string currentLogin;   // Username hiện tại
        public static string currentPass;    // Password hiện tại
        public static string currentUser;    // Mã nhân viên đang login
        public static string currentUserName; // Tên nhân viên đang login (HO + TEN)

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmLogin());
        }

        public static bool KetNoi(string serverName, string dbName, string user, string pass)
        {
            try
            {
                connStr = $@"Data Source={serverName};Initial Catalog={dbName};User ID={user};Password={pass}";
                currentConn = new SqlConnection(connStr);
                currentConn.Open();

                // Lưu thông tin login
                currentLogin = user;
                currentPass = pass;

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể kết nối SQL Server.\n" + ex.Message,
                                "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static string GetConnectionString(string chiNhanhMoi)
        {
            string newConnStr = "";
            if (chiNhanhMoi == "BENTHANH")
                newConnStr = @"Data Source=LAPTOP-VB7EKE79\YAKAO;Initial Catalog=NGANHANG_BENTHANH;User ID=chinhanh_bt;Password=CN@123";
            else if (chiNhanhMoi == "TANDINH")
                newConnStr = @"Data Source=LAPTOP-VB7EKE79\YAKAO;Initial Catalog=NGANHANG_TANDINH;User ID=chinhanh_td;Password=CN@123";
            else if (chiNhanhMoi == "TONGHOP")
                newConnStr = @"Data Source=LAPTOP-VB7EKE79\YAKAO;Initial Catalog=NGANHANG_TRUNGTAM;User ID=admin_nh;Password=Admin@123";
            return newConnStr;
        }

        public static SqlConnection GetConnectionForBranch(string chiNhanhMoi)
        {
            string newConnStr = GetConnectionString(chiNhanhMoi);
            return new SqlConnection(newConnStr);
        }

        /// <summary>
        /// Lấy thông tin nhân viên từ login hiện tại
        /// </summary>
        public static void LoadCurrentUserInfo()
        {
            try
            {
                // ⚙️ 1️⃣ Kiểm tra kết nối
                if (currentConn == null)
                    return;
                if (currentConn.State != System.Data.ConnectionState.Open)
                    currentConn.Open();

                // ⚙️ 2️⃣ Lấy thông tin login đang kết nối SQL Server
                string sqlUser;
                using (SqlCommand cmd = new SqlCommand("SELECT SYSTEM_USER", currentConn))
                {
                    sqlUser = cmd.ExecuteScalar()?.ToString() ?? "";
                }

                if (string.IsNullOrEmpty(sqlUser))
                    return;

                // ⚙️ 3️⃣ Tách tên login nếu có domain
                string loginName = sqlUser.Contains("\\")
                    ? sqlUser.Split('\\')[1]
                    : sqlUser;

                // ⚙️ 4️⃣ Lấy thông tin nhân viên tương ứng nếu tồn tại
                string query = @"
            SELECT TOP 1 MANV, (HO + ' ' + TEN) AS HOTEN
            FROM NhanVien
            WHERE TrangThaiXoa = 0";

                using (SqlCommand cmd = new SqlCommand(query, currentConn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            currentUser = reader["MANV"].ToString();
                            currentUserName = reader["HOTEN"].ToString();
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("❌ Lỗi khi lấy thông tin nhân viên:\n" + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}