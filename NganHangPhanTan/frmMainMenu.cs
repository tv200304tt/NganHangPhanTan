using NganHangPhanTan.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NganHangPhanTan
{
    public partial class frmMainMenu : Form
    {
        public frmMainMenu()
        {
            InitializeComponent();
        }
        private void frmMainMenu_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = $"Xin chào: {Connection.username}  |  Chi nhánh: {Connection.chiNhanh}";

        }
        private void thốngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuKhachHang_Click(object sender, EventArgs e)
        {
            new frmKhachHang().ShowDialog();

        }

        private void menuTaiKhoan_Click(object sender, EventArgs e)
        {
            new frmMoTaiKhoan().ShowDialog();
        }

        private void frmMainMenu_Load_1(object sender, EventArgs e)
        {
            Text = "HỆ THỐNG NGÂN HÀNG PHÂN TÁN";
            lblInfo.Text = $"Người dùng: {Session.LoginName} | Vai trò: {Session.RoleName} | Chi nhánh: {Session.ChiNhanhHienTai}";

            // Ẩn tất cả trước
            menuCapNhat.Visible = false;
            menuThongKe.Visible = false;
            menuQuanTri.Visible = false;
            mnuSaoKe.Visible = false;

            switch (Connection.userRole)
            {
                case "NganHang": // admin_nh
                    menuCapNhat.Visible = true;
                    menuThongKe.Visible = true;
                    menuQuanTri.Visible = true;
                    mnuSaoKe.Visible = true;
                    break;

                case "ChiNhanh": // chinhanh_bt
                    menuCapNhat.Visible = true;
                    menuThongKe.Visible = true;
                    break;

                case "KhachHang":
                    menuThongKe.Visible = true;
                    mnuSaoKe.Visible = true;
                    break;
            }

        }
        private void OpenSubForm(Form form)
        {
            form.StartPosition = FormStartPosition.CenterScreen;
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.MaximizeBox = false;

            this.Hide(); // ẩn main menu

            // đăng ký sự kiện khi form con đóng
            form.FormClosed += (s, args) =>
            {
                this.Show(); // hiện lại main menu
                this.WindowState = FormWindowState.Normal;
                this.Size = new System.Drawing.Size(1024, 720); // đảm bảo kích thước đúng
                this.CenterToScreen(); // căn giữa lại
            };

            form.Show();
        }
        private void menuLogout_Click(object sender, EventArgs e)
        { }

        private void menuNhanVien_Click(object sender, EventArgs e)
        {
            OpenSubForm(new frmNhanVien());
        }

        private void menuGiaoDich_Click(object sender, EventArgs e)
        {
            OpenSubForm(new frmGiaoDichKhach());
        }

        private void menuThongKe_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenSubForm(new frmSaoKe());
        }

        private void mnuBaoCao_Click(object sender, EventArgs e)
        {
            OpenSubForm(new frmBaoCaoTaiKhoan());
        }

        private void mnuKhachHangCN_Click(object sender, EventArgs e)
        {
            OpenSubForm(new frmKhachHang());
        }

        private void menuLogout_Click_1(object sender, EventArgs e)
        {
            this.Close();
            OpenSubForm(new frmLogin());
        }

        private void qUẢNTRỊToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenSubForm(new frmTaoLogin());
        }
    }
}
