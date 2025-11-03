namespace NganHangPhanTan.Core
{
    public static class Session
    {
        public static string LoginName { get; set; }
        public static string RoleName { get; set; } // NganHang / ChiNhanh / KhachHang
        public static string ChiNhanhHienTai { get; set; } // MACN hiển thị trên UI
    }
}
