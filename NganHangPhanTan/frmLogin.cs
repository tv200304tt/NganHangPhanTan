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
            cbChiNhanh.Items.Clear();
            cbChiNhanh.Items.Add("BENTHANH");
            cbChiNhanh.Items.Add("TANDINH");
            cbChiNhanh.Items.Add("NGANHANG");
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                var dbKey = cbChiNhanh.SelectedItem.ToString();
                DB.UseConnection(dbKey, txtUser.Text.Trim(), txtPass.Text);

                // Test kết nối + lấy role
                Session.LoginName = txtUser.Text.Trim();
                Session.RoleName = RoleHelper.GetCurrentRole();
                Session.ChiNhanhHienTai = dbKey.Replace("NGANHANG_", ""); // hiển thị

                if (Session.RoleName == "None")
                    throw new Exception("Tài khoản chưa thuộc role nào (NganHang/ChiNhanh/KhachHang).");

                // Mở main
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
