
namespace NganHangPhanTan
{
    partial class frmGiaoDichKhach
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
            this.lblSoTKNhan = new System.Windows.Forms.Label();
            this.cboLoaiGD = new System.Windows.Forms.ComboBox();
            this.txtSoTK = new System.Windows.Forms.TextBox();
            this.txtSoTien = new System.Windows.Forms.TextBox();
            this.txtSoTKNhan = new System.Windows.Forms.TextBox();
            this.btnThoat = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.cboMaNV = new System.Windows.Forms.ComboBox();
            this.btnGoiTien = new System.Windows.Forms.Button();
            this.btnRutTien = new System.Windows.Forms.Button();
            this.btnChuyenTien = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label1.Location = new System.Drawing.Point(239, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(403, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "GIAO DỊCH KHÁCH";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 27);
            this.label2.TabIndex = 0;
            this.label2.Text = "Loại GD";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 157);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 27);
            this.label3.TabIndex = 0;
            this.label3.Text = "Số TK";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(470, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 27);
            this.label4.TabIndex = 0;
            this.label4.Text = "Số Tiền";
            // 
            // lblSoTKNhan
            // 
            this.lblSoTKNhan.AutoSize = true;
            this.lblSoTKNhan.Location = new System.Drawing.Point(470, 157);
            this.lblSoTKNhan.Name = "lblSoTKNhan";
            this.lblSoTKNhan.Size = new System.Drawing.Size(126, 27);
            this.lblSoTKNhan.TabIndex = 0;
            this.lblSoTKNhan.Text = "Số TK nhận";
            // 
            // cboLoaiGD
            // 
            this.cboLoaiGD.FormattingEnabled = true;
            this.cboLoaiGD.Location = new System.Drawing.Point(172, 90);
            this.cboLoaiGD.Name = "cboLoaiGD";
            this.cboLoaiGD.Size = new System.Drawing.Size(223, 34);
            this.cboLoaiGD.TabIndex = 1;
            this.cboLoaiGD.SelectedIndexChanged += new System.EventHandler(this.cboLoaiGD_SelectedIndexChanged);
            // 
            // txtSoTK
            // 
            this.txtSoTK.Location = new System.Drawing.Point(172, 157);
            this.txtSoTK.Name = "txtSoTK";
            this.txtSoTK.Size = new System.Drawing.Size(223, 34);
            this.txtSoTK.TabIndex = 2;
            // 
            // txtSoTien
            // 
            this.txtSoTien.Location = new System.Drawing.Point(608, 86);
            this.txtSoTien.Name = "txtSoTien";
            this.txtSoTien.Size = new System.Drawing.Size(223, 34);
            this.txtSoTien.TabIndex = 2;
            // 
            // txtSoTKNhan
            // 
            this.txtSoTKNhan.Location = new System.Drawing.Point(608, 150);
            this.txtSoTKNhan.Name = "txtSoTKNhan";
            this.txtSoTKNhan.Size = new System.Drawing.Size(223, 34);
            this.txtSoTKNhan.TabIndex = 2;
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(699, 296);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(132, 40);
            this.btnThoat.TabIndex = 3;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(47, 232);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 27);
            this.label6.TabIndex = 0;
            this.label6.Text = "Mã NV";
            // 
            // cboMaNV
            // 
            this.cboMaNV.FormattingEnabled = true;
            this.cboMaNV.Location = new System.Drawing.Point(172, 229);
            this.cboMaNV.Name = "cboMaNV";
            this.cboMaNV.Size = new System.Drawing.Size(223, 34);
            this.cboMaNV.TabIndex = 4;
            // 
            // btnGoiTien
            // 
            this.btnGoiTien.Location = new System.Drawing.Point(172, 296);
            this.btnGoiTien.Name = "btnGoiTien";
            this.btnGoiTien.Size = new System.Drawing.Size(132, 40);
            this.btnGoiTien.TabIndex = 5;
            this.btnGoiTien.Text = "Gởi tiền";
            this.btnGoiTien.UseVisualStyleBackColor = true;
            this.btnGoiTien.Click += new System.EventHandler(this.btnGoiTien_Click);
            // 
            // btnRutTien
            // 
            this.btnRutTien.Location = new System.Drawing.Point(334, 296);
            this.btnRutTien.Name = "btnRutTien";
            this.btnRutTien.Size = new System.Drawing.Size(132, 40);
            this.btnRutTien.TabIndex = 5;
            this.btnRutTien.Text = "Rút tiền";
            this.btnRutTien.UseVisualStyleBackColor = true;
            this.btnRutTien.Click += new System.EventHandler(this.btnRutTien_Click);
            // 
            // btnChuyenTien
            // 
            this.btnChuyenTien.Location = new System.Drawing.Point(496, 296);
            this.btnChuyenTien.Name = "btnChuyenTien";
            this.btnChuyenTien.Size = new System.Drawing.Size(173, 40);
            this.btnChuyenTien.TabIndex = 5;
            this.btnChuyenTien.Text = "Chuyển tiền";
            this.btnChuyenTien.UseVisualStyleBackColor = true;
            this.btnChuyenTien.Click += new System.EventHandler(this.btnChuyenTien_Click);
            // 
            // frmGiaoDichKhach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(869, 348);
            this.Controls.Add(this.btnChuyenTien);
            this.Controls.Add(this.btnRutTien);
            this.Controls.Add(this.btnGoiTien);
            this.Controls.Add(this.cboMaNV);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.txtSoTKNhan);
            this.Controls.Add(this.txtSoTien);
            this.Controls.Add(this.txtSoTK);
            this.Controls.Add(this.cboLoaiGD);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblSoTKNhan);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "frmGiaoDichKhach";
            this.Text = "Thực hiện";
            this.Load += new System.EventHandler(this.frmGiaoDichKhach_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblSoTKNhan;
        private System.Windows.Forms.ComboBox cboLoaiGD;
        private System.Windows.Forms.TextBox txtSoTK;
        private System.Windows.Forms.TextBox txtSoTien;
        private System.Windows.Forms.TextBox txtSoTKNhan;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboMaNV;
        private System.Windows.Forms.Button btnGoiTien;
        private System.Windows.Forms.Button btnRutTien;
        private System.Windows.Forms.Button btnChuyenTien;
    }
}