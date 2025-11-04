using System;

namespace NganHangPhanTan.Core
{
    /// <summary>
    /// Lưu trữ thông tin phiên đăng nhập hiện tại
    /// </summary>
    public static class Session
    {
        public static string LoginName { get; set; } = "";
        public static string RoleName { get; set; } = "None";
        public static string ChiNhanhHienTai { get; set; } = "";
        public static string CMND { get; set; } = ""; // Dành cho KhachHang
        public static string DisplayRole { get; set; } = "";

        /// <summary>
        /// Reset toàn bộ session khi logout
        /// </summary>
        public static void Clear()
        {
            LoginName = "";
            RoleName = "None";
            ChiNhanhHienTai = "";
            CMND = "";
        }

        /// <summary>
        /// Kiểm tra xem có đang đăng nhập không
        /// </summary>
        public static bool IsLoggedIn()
        {
            return !string.IsNullOrEmpty(LoginName) && RoleName != "None";
        }
    }
}