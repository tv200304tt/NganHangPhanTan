
namespace NganHangPhanTan
{
    partial class frmNhanVien
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
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtHo = new System.Windows.Forms.TextBox();
            this.txtMaNV = new System.Windows.Forms.TextBox();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.txtCMND = new System.Windows.Forms.TextBox();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.cbPhai = new System.Windows.Forms.ComboBox();
            this.cbMaCN = new System.Windows.Forms.ComboBox();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.dgvNhanVien = new System.Windows.Forms.DataGridView();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnGhi = new System.Windows.Forms.Button();
            this.btnPhucHoi = new System.Windows.Forms.Button();
            this.btnChuyenCN = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhanVien)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(263, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(248, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "NHÂN VIÊN";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 27);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mã NV";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(60, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 27);
            this.label3.TabIndex = 0;
            this.label3.Text = "Họ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(60, 220);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 27);
            this.label4.TabIndex = 0;
            this.label4.Text = "Tên";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(60, 277);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 27);
            this.label5.TabIndex = 0;
            this.label5.Text = "Địa chỉ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(443, 108);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 27);
            this.label6.TabIndex = 0;
            this.label6.Text = "CMND";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(443, 160);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 27);
            this.label7.TabIndex = 0;
            this.label7.Text = "Phái";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(443, 213);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 27);
            this.label8.TabIndex = 0;
            this.label8.Text = "SDT";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(443, 270);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(116, 27);
            this.label9.TabIndex = 0;
            this.label9.Text = "Chi Nhánh";
            // 
            // txtHo
            // 
            this.txtHo.Location = new System.Drawing.Point(182, 164);
            this.txtHo.Name = "txtHo";
            this.txtHo.Size = new System.Drawing.Size(193, 34);
            this.txtHo.TabIndex = 1;
            // 
            // txtMaNV
            // 
            this.txtMaNV.Location = new System.Drawing.Point(182, 108);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.Size = new System.Drawing.Size(193, 34);
            this.txtMaNV.TabIndex = 1;
            // 
            // txtTen
            // 
            this.txtTen.Location = new System.Drawing.Point(182, 220);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(193, 34);
            this.txtTen.TabIndex = 1;
            this.txtTen.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // txtCMND
            // 
            this.txtCMND.Location = new System.Drawing.Point(569, 101);
            this.txtCMND.Name = "txtCMND";
            this.txtCMND.Size = new System.Drawing.Size(172, 34);
            this.txtCMND.TabIndex = 1;
            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(569, 206);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(172, 34);
            this.txtSDT.TabIndex = 1;
            // 
            // cbPhai
            // 
            this.cbPhai.FormattingEnabled = true;
            this.cbPhai.Location = new System.Drawing.Point(569, 153);
            this.cbPhai.Name = "cbPhai";
            this.cbPhai.Size = new System.Drawing.Size(172, 34);
            this.cbPhai.TabIndex = 2;
            // 
            // cbMaCN
            // 
            this.cbMaCN.FormattingEnabled = true;
            this.cbMaCN.Location = new System.Drawing.Point(569, 263);
            this.cbMaCN.Name = "cbMaCN";
            this.cbMaCN.Size = new System.Drawing.Size(172, 34);
            this.cbMaCN.TabIndex = 2;
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(182, 267);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(193, 34);
            this.txtDiaChi.TabIndex = 1;
            this.txtDiaChi.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // dgvNhanVien
            // 
            this.dgvNhanVien.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvNhanVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNhanVien.Location = new System.Drawing.Point(24, 333);
            this.dgvNhanVien.Name = "dgvNhanVien";
            this.dgvNhanVien.RowHeadersWidth = 51;
            this.dgvNhanVien.RowTemplate.Height = 24;
            this.dgvNhanVien.Size = new System.Drawing.Size(770, 150);
            this.dgvNhanVien.TabIndex = 3;
            this.dgvNhanVien.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNhanVien_CellContentClick);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(9, 536);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(121, 43);
            this.btnThem.TabIndex = 4;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(136, 536);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(121, 43);
            this.btnXoa.TabIndex = 4;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnGhi
            // 
            this.btnGhi.Location = new System.Drawing.Point(263, 536);
            this.btnGhi.Name = "btnGhi";
            this.btnGhi.Size = new System.Drawing.Size(121, 43);
            this.btnGhi.TabIndex = 4;
            this.btnGhi.Text = "Ghi";
            this.btnGhi.UseVisualStyleBackColor = true;
            this.btnGhi.Click += new System.EventHandler(this.btnGhi_Click);
            // 
            // btnPhucHoi
            // 
            this.btnPhucHoi.Location = new System.Drawing.Point(390, 536);
            this.btnPhucHoi.Name = "btnPhucHoi";
            this.btnPhucHoi.Size = new System.Drawing.Size(121, 43);
            this.btnPhucHoi.TabIndex = 4;
            this.btnPhucHoi.Text = "Phục hồi";
            this.btnPhucHoi.UseVisualStyleBackColor = true;
            this.btnPhucHoi.Click += new System.EventHandler(this.btnPhucHoi_Click);
            // 
            // btnChuyenCN
            // 
            this.btnChuyenCN.Location = new System.Drawing.Point(517, 536);
            this.btnChuyenCN.Name = "btnChuyenCN";
            this.btnChuyenCN.Size = new System.Drawing.Size(146, 43);
            this.btnChuyenCN.TabIndex = 4;
            this.btnChuyenCN.Text = "Chuyển CN ";
            this.btnChuyenCN.UseVisualStyleBackColor = true;
            this.btnChuyenCN.Click += new System.EventHandler(this.btnChuyenCN_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(673, 536);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(121, 43);
            this.btnThoat.TabIndex = 4;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // frmNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(820, 626);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnChuyenCN);
            this.Controls.Add(this.btnPhucHoi);
            this.Controls.Add(this.btnGhi);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.dgvNhanVien);
            this.Controls.Add(this.cbMaCN);
            this.Controls.Add(this.cbPhai);
            this.Controls.Add(this.txtMaNV);
            this.Controls.Add(this.txtSDT);
            this.Controls.Add(this.txtCMND);
            this.Controls.Add(this.txtDiaChi);
            this.Controls.Add(this.txtTen);
            this.Controls.Add(this.txtHo);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "frmNhanVien";
            this.Text = "frmNhanVien";
            this.Load += new System.EventHandler(this.frmNhanVien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhanVien)).EndInit();
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
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtHo;
        private System.Windows.Forms.TextBox txtMaNV;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.TextBox txtCMND;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.ComboBox cbPhai;
        private System.Windows.Forms.ComboBox cbMaCN;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.DataGridView dgvNhanVien;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnGhi;
        private System.Windows.Forms.Button btnPhucHoi;
        private System.Windows.Forms.Button btnChuyenCN;
        private System.Windows.Forms.Button btnThoat;
    }
}