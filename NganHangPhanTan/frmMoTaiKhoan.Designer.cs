
namespace NganHangPhanTan
{
    partial class frmMoTaiKhoan
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSoDu = new System.Windows.Forms.TextBox();
            this.txtSoTK = new System.Windows.Forms.TextBox();
            this.cbCMND = new System.Windows.Forms.ComboBox();
            this.cbMaCN = new System.Windows.Forms.ComboBox();
            this.dtpNgayMo = new System.Windows.Forms.DateTimePicker();
            this.dgvTaiKhoan = new System.Windows.Forms.DataGridView();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnGhi = new System.Windows.Forms.Button();
            this.btnPhucHoi = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaiKhoan)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(137, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(622, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "MỞ TÀI KHOẢN KHÁCH HÀNG";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 111);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 27);
            this.label2.TabIndex = 1;
            this.label2.Text = "Số tài khoản";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(60, 175);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 27);
            this.label3.TabIndex = 1;
            this.label3.Text = "Số dư";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(430, 111);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 27);
            this.label4.TabIndex = 1;
            this.label4.Text = "Mã CN";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(60, 239);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 27);
            this.label5.TabIndex = 1;
            this.label5.Text = "CMND";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(430, 176);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(137, 27);
            this.label6.TabIndex = 1;
            this.label6.Text = "Ngày mở TK";
            // 
            // txtSoDu
            // 
            this.txtSoDu.Location = new System.Drawing.Point(214, 169);
            this.txtSoDu.Name = "txtSoDu";
            this.txtSoDu.Size = new System.Drawing.Size(180, 34);
            this.txtSoDu.TabIndex = 2;
            // 
            // txtSoTK
            // 
            this.txtSoTK.Location = new System.Drawing.Point(214, 111);
            this.txtSoTK.Name = "txtSoTK";
            this.txtSoTK.Size = new System.Drawing.Size(180, 34);
            this.txtSoTK.TabIndex = 2;
            // 
            // cbCMND
            // 
            this.cbCMND.FormattingEnabled = true;
            this.cbCMND.Location = new System.Drawing.Point(214, 237);
            this.cbCMND.Name = "cbCMND";
            this.cbCMND.Size = new System.Drawing.Size(180, 34);
            this.cbCMND.TabIndex = 3;
            // 
            // cbMaCN
            // 
            this.cbMaCN.FormattingEnabled = true;
            this.cbMaCN.Location = new System.Drawing.Point(602, 104);
            this.cbMaCN.Name = "cbMaCN";
            this.cbMaCN.Size = new System.Drawing.Size(180, 34);
            this.cbMaCN.TabIndex = 3;
            // 
            // dtpNgayMo
            // 
            this.dtpNgayMo.CalendarFont = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgayMo.Location = new System.Drawing.Point(602, 170);
            this.dtpNgayMo.Name = "dtpNgayMo";
            this.dtpNgayMo.Size = new System.Drawing.Size(203, 34);
            this.dtpNgayMo.TabIndex = 4;
            // 
            // dgvTaiKhoan
            // 
            this.dgvTaiKhoan.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvTaiKhoan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTaiKhoan.Location = new System.Drawing.Point(21, 286);
            this.dgvTaiKhoan.Name = "dgvTaiKhoan";
            this.dgvTaiKhoan.RowHeadersWidth = 51;
            this.dgvTaiKhoan.RowTemplate.Height = 24;
            this.dgvTaiKhoan.Size = new System.Drawing.Size(825, 181);
            this.dgvTaiKhoan.TabIndex = 5;
            this.dgvTaiKhoan.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTaiKhoan_CellContentClick);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(112, 514);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(117, 36);
            this.btnThem.TabIndex = 6;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(247, 514);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(117, 36);
            this.btnXoa.TabIndex = 6;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnGhi
            // 
            this.btnGhi.Location = new System.Drawing.Point(391, 514);
            this.btnGhi.Name = "btnGhi";
            this.btnGhi.Size = new System.Drawing.Size(117, 36);
            this.btnGhi.TabIndex = 6;
            this.btnGhi.Text = "Ghi";
            this.btnGhi.UseVisualStyleBackColor = true;
            this.btnGhi.Click += new System.EventHandler(this.btnGhi_Click);
            // 
            // btnPhucHoi
            // 
            this.btnPhucHoi.Location = new System.Drawing.Point(535, 514);
            this.btnPhucHoi.Name = "btnPhucHoi";
            this.btnPhucHoi.Size = new System.Drawing.Size(117, 36);
            this.btnPhucHoi.TabIndex = 6;
            this.btnPhucHoi.Text = "Phục hồi";
            this.btnPhucHoi.UseVisualStyleBackColor = true;
            this.btnPhucHoi.Click += new System.EventHandler(this.btnPhucHoi_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(679, 514);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(117, 36);
            this.btnThoat.TabIndex = 6;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // frmMoTaiKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(858, 573);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnPhucHoi);
            this.Controls.Add(this.btnGhi);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.dgvTaiKhoan);
            this.Controls.Add(this.dtpNgayMo);
            this.Controls.Add(this.cbMaCN);
            this.Controls.Add(this.cbCMND);
            this.Controls.Add(this.txtSoTK);
            this.Controls.Add(this.txtSoDu);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "frmMoTaiKhoan";
            this.Text = "frmMoTaiKhoan";
            this.Load += new System.EventHandler(this.frmMoTaiKhoan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaiKhoan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSoDu;
        private System.Windows.Forms.TextBox txtSoTK;
        private System.Windows.Forms.ComboBox cbCMND;
        private System.Windows.Forms.ComboBox cbMaCN;
        private System.Windows.Forms.DateTimePicker dtpNgayMo;
        private System.Windows.Forms.DataGridView dgvTaiKhoan;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnGhi;
        private System.Windows.Forms.Button btnPhucHoi;
        private System.Windows.Forms.Button btnThoat;
    }
}