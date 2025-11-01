
namespace NganHangPhanTan
{
    partial class frmMainMenu
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.cậpNhậtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuKhachHang = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTaiKhoan = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNhanVien = new System.Windows.Forms.ToolStripMenuItem();
            this.menuGiaoDich = new System.Windows.Forms.ToolStripMenuItem();
            this.qUẢNTRỊToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDangXuat = new System.Windows.Forms.ToolStripMenuItem();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.menuThongKe = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(30, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cậpNhậtToolStripMenuItem,
            this.menuThongKe,
            this.qUẢNTRỊToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(566, 30);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // cậpNhậtToolStripMenuItem
            // 
            this.cậpNhậtToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuKhachHang,
            this.menuTaiKhoan,
            this.menuNhanVien,
            this.menuGiaoDich});
            this.cậpNhậtToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cậpNhậtToolStripMenuItem.Name = "cậpNhậtToolStripMenuItem";
            this.cậpNhậtToolStripMenuItem.Size = new System.Drawing.Size(120, 26);
            this.cậpNhậtToolStripMenuItem.Text = "CẬP NHẬT";
            // 
            // menuKhachHang
            // 
            this.menuKhachHang.Name = "menuKhachHang";
            this.menuKhachHang.Size = new System.Drawing.Size(224, 26);
            this.menuKhachHang.Text = "Khách hàng";
            this.menuKhachHang.Click += new System.EventHandler(this.menuKhachHang_Click);
            // 
            // menuTaiKhoan
            // 
            this.menuTaiKhoan.Name = "menuTaiKhoan";
            this.menuTaiKhoan.Size = new System.Drawing.Size(224, 26);
            this.menuTaiKhoan.Text = "Mở tài khoản";
            this.menuTaiKhoan.Click += new System.EventHandler(this.menuTaiKhoan_Click);
            // 
            // menuNhanVien
            // 
            this.menuNhanVien.Name = "menuNhanVien";
            this.menuNhanVien.Size = new System.Drawing.Size(224, 26);
            this.menuNhanVien.Text = "Nhân viên";
            this.menuNhanVien.Click += new System.EventHandler(this.menuNhanVien_Click);
            // 
            // menuGiaoDich
            // 
            this.menuGiaoDich.Name = "menuGiaoDich";
            this.menuGiaoDich.Size = new System.Drawing.Size(224, 26);
            this.menuGiaoDich.Text = "Giao dịch";
            this.menuGiaoDich.Click += new System.EventHandler(this.menuGiaoDich_Click);
            // 
            // qUẢNTRỊToolStripMenuItem
            // 
            this.qUẢNTRỊToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuDangXuat});
            this.qUẢNTRỊToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qUẢNTRỊToolStripMenuItem.Name = "qUẢNTRỊToolStripMenuItem";
            this.qUẢNTRỊToolStripMenuItem.Size = new System.Drawing.Size(115, 26);
            this.qUẢNTRỊToolStripMenuItem.Text = "QUẢN TRỊ";
            // 
            // menuDangXuat
            // 
            this.menuDangXuat.Name = "menuDangXuat";
            this.menuDangXuat.Size = new System.Drawing.Size(224, 26);
            this.menuDangXuat.Text = "Đăng xuất";
            this.menuDangXuat.Click += new System.EventHandler(this.menuDangXuat_Click);
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Location = new System.Drawing.Point(193, 131);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(0, 25);
            this.lblWelcome.TabIndex = 1;
            // 
            // menuThongKe
            // 
            this.menuThongKe.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuThongKe.Name = "menuThongKe";
            this.menuThongKe.Size = new System.Drawing.Size(123, 26);
            this.menuThongKe.Text = "THỐNG KÊ";
            this.menuThongKe.Click += new System.EventHandler(this.menuThongKe_Click);
            // 
            // frmMainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(566, 359);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmMainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmMainMenu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMainMenu_Load_1);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cậpNhậtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuKhachHang;
        private System.Windows.Forms.ToolStripMenuItem menuTaiKhoan;
        private System.Windows.Forms.ToolStripMenuItem menuNhanVien;
        private System.Windows.Forms.ToolStripMenuItem menuGiaoDich;
        private System.Windows.Forms.ToolStripMenuItem qUẢNTRỊToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuDangXuat;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.ToolStripMenuItem menuThongKe;
    }
}