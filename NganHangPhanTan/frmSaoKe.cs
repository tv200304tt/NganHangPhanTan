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
    public partial class frmSaoKe : Form
    {
        public frmSaoKe()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void frmSaoKe_Load(object sender, EventArgs e)
        {
            

        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_SaoKeGiaoDich", Connection.currentConn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SOTK", txtSoTK.Text.Trim());
                    cmd.Parameters.AddWithValue("@TuNgay", dtpTuNgay.Value);
                    cmd.Parameters.AddWithValue("@DenNgay", dtpDenNgay.Value);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvSaoKe.DataSource = dt;

                    if (dt.Rows.Count == 0)
                        MessageBox.Show("Không có giao dịch nào trong khoảng thời gian này.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xem sao kê: " + ex.Message);
            }
        }
    }
}
