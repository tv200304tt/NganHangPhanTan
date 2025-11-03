using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using NganHangPhanTan.Core;


namespace NganHangPhanTan
{
    public partial class frmGiaoDichKhach : Form
    {
        public frmGiaoDichKhach()
        {
            InitializeComponent();
        }
        

        private void frmGiaoDichKhach_Load(object sender, EventArgs e)
        {


            cboLoaiGD.Items.AddRange(new[] { "Gửi tiền", "Rút tiền", "Chuyển tiền" });
            cboLoaiGD.SelectedIndex = 0;
            cboLoaiGD.SelectedIndexChanged += cboLoaiGD_SelectedIndexChanged;

            LoadNhanVien();
           
            UpdateButtonState();
        }
        private void LoadNhanVien()
        {
            try
            {
                string sql = "SELECT MANV, HO + ' ' + TEN AS HOTEN FROM NhanVien WHERE TrangThaiXoa = 0";
                DataTable dt = DB.Query(sql, CommandType.Text);
                cboMaNV.DataSource = dt;
                cboMaNV.DisplayMember = "HOTEN";
                cboMaNV.ValueMember = "MANV";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách nhân viên: " + ex.Message);
            }
        }
        private bool ValidateInput(string type)
        {
            if (string.IsNullOrWhiteSpace(txtSoTK.Text))
            {
                MessageBox.Show("Vui lòng nhập số tài khoản!", "Cảnh báo");
                return false;
            }

            if (type == "Chuyển tiền" && string.IsNullOrWhiteSpace(txtSoTKNhan.Text))
            {
                MessageBox.Show("Vui lòng nhập số tài khoản nhận!", "Cảnh báo");
                return false;
            }

            if (!decimal.TryParse(txtSoTien.Text, out decimal soTien))
            {
                MessageBox.Show("Số tiền không hợp lệ!", "Cảnh báo");
                return false;
            }

            if (soTien < 100000)
            {
                MessageBox.Show("Số tiền giao dịch tối thiểu là 100.000 VNĐ!", "Cảnh báo");
                return false;
            }

            return true;
        }

        private void btnThucHien_Click(object sender, EventArgs e)
        {

        }

        private void btnGoiTien_Click(object sender, EventArgs e)
        {
            if (!ValidateInput("Gửi tiền")) return;

            try
            {
                DB.Exec("sp_GuiRutTien",
                    new SqlParameter("@SOTK", txtSoTK.Text.Trim()),
                    new SqlParameter("@LOAIGD", "GT"),
                    new SqlParameter("@SOTIEN", Convert.ToDecimal(txtSoTien.Text.Trim())),
                    new SqlParameter("@MANV", cboMaNV.SelectedValue.ToString())
                );

                MessageBox.Show("✅ Gửi tiền thành công!", "Thành công");
                ClearForm();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi SQL: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi gửi tiền: " + ex.Message);
            }
        }

        private void btnRutTien_Click(object sender, EventArgs e)
        {
            if (!ValidateInput("Rút tiền")) return;

            try
            {
                DB.Exec("sp_GuiRutTien",
                    new SqlParameter("@SOTK", txtSoTK.Text.Trim()),
                    new SqlParameter("@LOAIGD", "RT"),
                    new SqlParameter("@SOTIEN", Convert.ToDecimal(txtSoTien.Text.Trim())),
                    new SqlParameter("@MANV", cboMaNV.SelectedValue.ToString())
                );

                MessageBox.Show("✅ Rút tiền thành công!", "Thành công");
                ClearForm();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi SQL: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi rút tiền: " + ex.Message);
            }
        }

        private void btnChuyenTien_Click(object sender, EventArgs e)
        {

            if (!ValidateInput("Chuyển tiền")) return;

            if (txtSoTK.Text.Trim() == txtSoTKNhan.Text.Trim())
            {
                MessageBox.Show("❌ Tài khoản chuyển và nhận không được trùng!", "Lỗi");
                return;
            }

            try
            {
                DB.Exec("sp_ChuyenTien",
                    new SqlParameter("@SOTK_CHUYEN", txtSoTK.Text.Trim()),
                    new SqlParameter("@SOTK_NHAN", txtSoTKNhan.Text.Trim()),
                    new SqlParameter("@SOTIEN", Convert.ToDecimal(txtSoTien.Text.Trim())),
                    new SqlParameter("@MANV", cboMaNV.SelectedValue.ToString())
                );

                MessageBox.Show("✅ Chuyển tiền thành công!", "Thành công");
                ClearForm();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi SQL: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi chuyển tiền: " + ex.Message);
            }
        }
        private void ClearForm()
        {
            txtSoTK.Clear();
            txtSoTKNhan.Clear();
            txtSoTien.Clear();
            cboLoaiGD.SelectedIndex = 0;
        }


        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboLoaiGD_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateButtonState();
        }
        private void UpdateButtonState()
        {
            string loaiGD = cboLoaiGD.SelectedItem.ToString();

            btnGoiTien.Enabled = loaiGD == "Gửi tiền";
            btnRutTien.Enabled = loaiGD == "Rút tiền";
            btnChuyenTien.Enabled = loaiGD == "Chuyển tiền";

            txtSoTKNhan.Enabled = loaiGD == "Chuyển tiền";
            if (loaiGD != "Chuyển tiền")
                txtSoTKNhan.Clear();
        }
    }
}
