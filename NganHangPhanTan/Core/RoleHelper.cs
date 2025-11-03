using System.Data;
using System.Data.SqlClient;

namespace NganHangPhanTan.Core
{
    public static class RoleHelper
    {
        // Dựa vào fn_KiemTraQuyenNguoiDung() trên DB hiện tại để lấy role
        public static string GetCurrentRole()
        {
            var tb = DB.Query("SELECT dbo.fn_KiemTraQuyenNguoiDung() AS RoleName", CommandType.Text);
            if (tb.Rows.Count == 0) return "None";
            return tb.Rows[0]["RoleName"]?.ToString() ?? "None";
        }

        public static bool IsNganHang => Session.RoleName == "NganHang";
        public static bool IsChiNhanh => Session.RoleName == "ChiNhanh";
        public static bool IsKhachHang => Session.RoleName == "KhachHang";
    }
}
