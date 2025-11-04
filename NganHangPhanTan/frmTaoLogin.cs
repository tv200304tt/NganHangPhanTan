using NganHangPhanTan.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NganHangPhanTan
{
    public partial class frmTaoLogin : Form
    {
        public frmTaoLogin()
        {
            InitializeComponent();
        }

        private void frmTaoLogin_Load(object sender, EventArgs e)
        {
            cbRole.Items.AddRange(new[] { "NganHang", "ChiNhanh", "KhachHang" });
            LoadDatabases();
        }
        private void LoadDatabases()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("DBName");
            dt.Rows.Add("NGANHANG_BENTHANH");
            dt.Rows.Add("NGANHANG_TANDINH");
            cbDatabase.DataSource = dt;
            cbDatabase.DisplayMember = "DBName";
            cbDatabase.ValueMember = "DBName";
        }

        private void btnTaoLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string login = txtLoginName.Text.Trim();
                string password = txtPass.Text.Trim();
                string dbName = cbDatabase.SelectedValue.ToString();

                // ✅ Kiểm tra input
                if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
                {
                    MessageBox.Show("⚠️ Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu!");
                    return;
                }

                // ✅ Đảm bảo kết nối tới DB trung tâm
                if (Connection.currentConn == null || Connection.currentConn.State != ConnectionState.Open)
                {
                    bool ok = Connection.ConnectSingle("NGANHANG", Connection.username, Connection.password);
                    if (!ok)
                    {
                        MessageBox.Show("Không thể kết nối tới cơ sở dữ liệu trung tâm (NGANHANG).");
                        return;
                    }
                }

                // ✅ Lấy quyền hiện tại tự động
                string currentRole = Connection.userRole;
                if (string.IsNullOrEmpty(currentRole))
                {
                    MessageBox.Show("Không xác định được quyền hiện tại. Vui lòng đăng nhập lại.", "Lỗi quyền");
                    return;
                }

                // ✅ Gọi stored procedure sp_TaoLoginMoi
                using (SqlCommand cmd = new SqlCommand("sp_TaoLoginMoi", Connection.currentConn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@LoginName", login);
                    cmd.Parameters.AddWithValue("@Password", password);
                    cmd.Parameters.AddWithValue("@NhomQuyen", currentRole);
                    cmd.Parameters.AddWithValue("@DatabaseName", dbName);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show($"✅ Tạo login thành công!\n→ Role: {currentRole}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Reset form
                txtLoginName.Clear();
                txtPass.Clear();
                cbDatabase.SelectedIndex = 0;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("❌ Lỗi SQL khi tạo login:\n" + ex.Message, "Lỗi SQL");
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Lỗi tạo login:\n" + ex.Message, "Lỗi hệ thống");
            }
        }
    }
}
