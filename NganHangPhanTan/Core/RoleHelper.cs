using System;
using System.Data;
using System.Data.SqlClient;

namespace NganHangPhanTan.Core
{
    /// <summary>
    /// Các hàm hỗ trợ kiểm tra quyền truy cập
    /// </summary>
    public static class RoleHelper
    {
        /// <summary>
        /// Kiểm tra xem user hiện tại có phải là NganHang không
        /// </summary>
        public static bool IsNganHang
        {
            get { return Session.RoleName == "NganHang"; }
        }

        /// <summary>
        /// Kiểm tra xem user hiện tại có phải là ChiNhanh không
        /// </summary>
        public static bool IsChiNhanh
        {
            get { return Session.RoleName == "ChiNhanh"; }
        }

        /// <summary>
        /// Kiểm tra xem user hiện tại có phải là KhachHang không
        /// </summary>
        public static bool IsKhachHang
        {
            get { return Session.RoleName == "KhachHang"; }
        }

        /// <summary>
        /// Kiểm tra xem user có quyền truy cập không (NganHang hoặc ChiNhanh)
        /// </summary>
        public static bool CanManage
        {
            get { return IsNganHang || IsChiNhanh; }
        }

        /// <summary>
        /// Lấy role hiện tại của user từ database
        /// </summary>
        public static string GetCurrentRole()
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
                    return dt.Rows[0]["UserRole"].ToString();
                }

                return "None";
            }
            catch (Exception)
            {
                return "None";
            }
        }

        /// <summary>
        /// Kiểm tra quyền truy cập theo role yêu cầu
        /// </summary>
        public static bool HasPermission(string requiredRole)
        {
            switch (requiredRole)
            {
                case "NganHang":
                    return IsNganHang;

                case "ChiNhanh":
                    return IsNganHang || IsChiNhanh;

                case "KhachHang":
                    return true; // Tất cả đều có quyền cơ bản

                default:
                    return false;
            }
        }

        /// <summary>
        /// Lấy tên hiển thị của role
        /// </summary>
        public static string GetDisplayRole()
        {
            switch (Session.RoleName)
            {
                case "NganHang":
                    return "Quản trị toàn hệ thống";

                case "ChiNhanh":
                    return $"Nhân viên chi nhánh {Session.ChiNhanhHienTai}";

                case "KhachHang":
                    return "Khách hàng";

                default:
                    return "Không xác định";
            }
        }

        /// <summary>
        /// Kiểm tra user có quyền truy cập vào chi nhánh cụ thể không
        /// </summary>
        public static bool CanAccessBranch(string maCN)
        {
            // NganHang có quyền truy cập tất cả chi nhánh
            if (IsNganHang)
                return true;

            // ChiNhanh chỉ truy cập chi nhánh của mình
            if (IsChiNhanh)
                return Session.ChiNhanhHienTai.Trim().ToUpper() == maCN.Trim().ToUpper();

            // KhachHang không có quyền truy cập theo chi nhánh
            return false;
        }
    }
}