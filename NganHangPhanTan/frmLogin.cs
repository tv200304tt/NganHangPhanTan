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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            // ✅ Load danh sách chi nhánh
            cbChiNhanh.Items.Clear();
            cbChiNhanh.DisplayMember = "Text";
            cbChiNhanh.ValueMember = "Value";
            cbChiNhanh.Items.Add(new { Text = "Trung tâm", Value = "NGANHANG" });
            cbChiNhanh.Items.Add(new { Text = "Bến Thành", Value = "BENTHANH" });
            cbChiNhanh.Items.Add(new { Text = "Tân Định", Value = "TANDINH" });
            cbChiNhanh.SelectedIndex = 0;
        }
        

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string user = txtUser.Text.Trim();
                string pass = txtPass.Text.Trim();
                string chiNhanh = (cbChiNhanh.SelectedItem as dynamic).Value;

                if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
                    throw new Exception("Tên người dùng hoặc mật khẩu không thể để trống!");

                // Kết nối tới cơ sở dữ liệu chi nhánh
                bool connected = Connection.ConnectSingle(chiNhanh, user, pass);
                if (!connected)
                    throw new Exception("Không thể kết nối đến cơ sở dữ liệu chi nhánh " + chiNhanh);

                // Cập nhật thông tin đăng nhập và quyền
                Session.LoginName = user;
                Session.RoleName = Connection.userRole;
                Session.ChiNhanhHienTai = chiNhanh;
                Session.DisplayRole = Connection.displayRole;

                if (Session.RoleName == "None")
                    throw new Exception("Tài khoản chưa có quyền nào (NganHang / ChiNhanh / KhachHang).");

                Connection.username = user;
                Connection.password = pass;
                Connection.chiNhanh = chiNhanh;

                MessageBox.Show($"✅ Đăng nhập thành công!\nUser: {user}\nRole: {Session.DisplayRole}",
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Mở form chính
                new frmMainMenu().Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đăng nhập thất bại:\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        

            private void btnExit_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
        }

    }
}
