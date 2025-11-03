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
                string dbName = cbDatabase.Enabled ? cbDatabase.SelectedValue.ToString() : null;

                DB.Exec("sp_TaoLoginMoi",
                    new SqlParameter("@LoginName", txtLoginName.Text.Trim()),
                    new SqlParameter("@Password", txtPass.Text.Trim()),
                    new SqlParameter("@NhomQuyen", cbRole.Text),
                    new SqlParameter("@DatabaseName", dbName));

                MessageBox.Show("✅ Tạo login thành công!");
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi SQL: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tạo login: " + ex.Message);
            }
        }
    }
}
