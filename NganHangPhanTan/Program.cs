using System;
using System.Windows.Forms;
using NganHangPhanTan;
using NganHangPhanTan.Core;

namespace NganHangPhanTan
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Khởi động vào màn hình đăng nhập
            Application.Run(new frmLogin());
        }
    }
}
