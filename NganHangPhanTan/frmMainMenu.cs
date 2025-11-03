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

            // Ẩn menu theo role
            menuQuanTri.Visible = RoleHelper.IsNganHang;
            menuCapNhat.Visible = !RoleHelper.IsKhachHang; // KH không được cập nhật
        }

        private void menuLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất không?",
                                          "Đăng xuất",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // 2️⃣ Ẩn form hiện tại
                this.Hide();

                // 3️⃣ Mở lại form đăng nhập
                frmLogin f = new frmLogin();
                f.Show();

                // 4️⃣ Đóng form hiện tại (nếu muốn giải phóng tài nguyên)
                this.Close();

            }
        }

        private void menuNhanVien_Click(object sender, EventArgs e)
        {
            frmNhanVien f = new frmNhanVien();
            f.MdiParent = this;
            f.StartPosition = FormStartPosition.Manual; // để tự canh giữa
            f.Location = new Point(0, 0);
            f.FormBorderStyle = FormBorderStyle.None;   // bỏ viền
            f.Dock = DockStyle.Fill;                    // 👉 fill toàn vùng MDI
            f.Show();

            // Resize frmMainMenu để vừa khít form con (nếu cần)
            this.ClientSize = f.Size;
        }

        private void menuGiaoDich_Click(object sender, EventArgs e)
        {
            frmGiaoDichKhach f = new frmGiaoDichKhach();
            f.MdiParent = this;
            f.StartPosition = FormStartPosition.Manual; // để tự canh giữa
            f.Location = new Point(0, 0);
            f.FormBorderStyle = FormBorderStyle.None;   // bỏ viền
            f.Dock = DockStyle.Fill;                    // 👉 fill toàn vùng MDI
            f.Show();

            // Resize frmMainMenu để vừa khít form con (nếu cần)
            this.ClientSize = f.Size;
        }

        private void menuThongKe_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
    }
}
