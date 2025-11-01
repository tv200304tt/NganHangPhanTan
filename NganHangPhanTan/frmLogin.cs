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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            cbChiNhanh.Items.Clear();
            cbChiNhanh.Items.Add("BENTHANH");
            cbChiNhanh.Items.Add("TANDINH");
            cbChiNhanh.Items.Add("NGANHANG");
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            string user = txtUser.Text.Trim();
            string pass = txtPass.Text.Trim();

            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ User và Password!", "Thông báo");
                return;
            }

            if (cbChiNhanh.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn chi nhánh!", "Thông báo");
                return;
            }

            string chiNhanh = cbChiNhanh.SelectedItem.ToString();

            // ✅ Kết nối 1 chi nhánh duy nhất
            if (Connection.ConnectSingle(chiNhanh, user, pass))
            {
                // Gán biến toàn cục
                Program.chiNhanh = chiNhanh;
                Program.currentLogin = user;
                Program.currentPass = pass;

                // Lấy thông tin nhân viên (nếu có)
                Program.LoadCurrentUserInfo();

                // Hiện duy nhất 1 thông báo thành công
                MessageBox.Show(
                    $"✅ Đăng nhập thành công vào chi nhánh {chiNhanh}!\n\nXin chào {Program.currentUserName ?? "Người dùng"}",
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Mở menu chính
                this.Hide();
                new frmMainMenu().Show();
            }
            else
            {
                MessageBox.Show("❌ Đăng nhập thất bại! Vui lòng kiểm tra lại.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

            private void btnExit_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
        }

    }
}
