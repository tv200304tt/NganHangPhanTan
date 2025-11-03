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
    public partial class frmBaoCaoTaiKhoan : Form
    {
        public frmBaoCaoTaiKhoan()
        {
            InitializeComponent();
        }

        private void frmBaoCaoTaiKhoan_Load(object sender, EventArgs e)
        {
            DataTable cn = DB.Query("SELECT MACN, TENCN FROM ChiNhanh", CommandType.Text);
            cbChiNhanh.DataSource = cn;
            cbChiNhanh.DisplayMember = "TENCN";
            cbChiNhanh.ValueMember = "MACN";
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_TaiKhoanMoiTheoThoiGian", Connection.currentConn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TuNgay", dtpTuNgay.Value);
                    cmd.Parameters.AddWithValue("@DenNgay", dtpDenNgay.Value);
                    cmd.Parameters.AddWithValue("@MaCN", cbChiNhanh.SelectedValue);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvTaiKhoan.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xem báo cáo: " + ex.Message);
            }
        }
    }
}
