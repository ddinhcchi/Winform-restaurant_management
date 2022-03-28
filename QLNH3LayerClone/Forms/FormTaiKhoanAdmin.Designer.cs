namespace QLNH3LayerClone.Forms
{
    partial class FormTaiKhoan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTaiKhoan));
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.cbStat = new System.Windows.Forms.ComboBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnUpdateAccount = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnDeleteAccount = new System.Windows.Forms.Button();
            this.btnAddAccount = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txbDisplay = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txbUser = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbSearchChucVu = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txbSearchName = new System.Windows.Forms.TextBox();
            this.txbSearchTk = new System.Windows.Forms.TextBox();
            this.btnUpdateSelf = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lvAccount = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.cbStat);
            this.panel2.Controls.Add(this.btnReset);
            this.panel2.Controls.Add(this.btnUpdateAccount);
            this.panel2.Controls.Add(this.btnRefresh);
            this.panel2.Controls.Add(this.btnDeleteAccount);
            this.panel2.Controls.Add(this.btnAddAccount);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.txbDisplay);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txbUser);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(631, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(416, 559);
            this.panel2.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(20, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(2, 1080);
            this.label2.TabIndex = 0;
            this.label2.Text = "label2";
            // 
            // cbStat
            // 
            this.cbStat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbStat.FormattingEnabled = true;
            this.cbStat.Items.AddRange(new object[] {
            "Quản lý",
            "Nhân viên"});
            this.cbStat.Location = new System.Drawing.Point(246, 303);
            this.cbStat.Name = "cbStat";
            this.cbStat.Size = new System.Drawing.Size(130, 33);
            this.cbStat.TabIndex = 3;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(245, 467);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(113, 37);
            this.btnReset.TabIndex = 7;
            this.btnReset.Text = "Reset MK";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnUpdateAccount
            // 
            this.btnUpdateAccount.Location = new System.Drawing.Point(93, 467);
            this.btnUpdateAccount.Name = "btnUpdateAccount";
            this.btnUpdateAccount.Size = new System.Drawing.Size(113, 37);
            this.btnUpdateAccount.TabIndex = 6;
            this.btnUpdateAccount.Text = "Sửa";
            this.btnUpdateAccount.UseVisualStyleBackColor = true;
            this.btnUpdateAccount.Click += new System.EventHandler(this.btnUpdateAccount_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(291, 120);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(113, 37);
            this.btnRefresh.TabIndex = 8;
            this.btnRefresh.Text = "Làm mới";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnDeleteAccount
            // 
            this.btnDeleteAccount.Location = new System.Drawing.Point(245, 389);
            this.btnDeleteAccount.Name = "btnDeleteAccount";
            this.btnDeleteAccount.Size = new System.Drawing.Size(113, 37);
            this.btnDeleteAccount.TabIndex = 5;
            this.btnDeleteAccount.Text = "Xóa";
            this.btnDeleteAccount.UseVisualStyleBackColor = true;
            this.btnDeleteAccount.Click += new System.EventHandler(this.btnDeleteAccount_Click);
            // 
            // btnAddAccount
            // 
            this.btnAddAccount.Location = new System.Drawing.Point(93, 389);
            this.btnAddAccount.Name = "btnAddAccount";
            this.btnAddAccount.Size = new System.Drawing.Size(113, 37);
            this.btnAddAccount.TabIndex = 4;
            this.btnAddAccount.Text = "Thêm";
            this.btnAddAccount.UseVisualStyleBackColor = true;
            this.btnAddAccount.Click += new System.EventHandler(this.btnAddAccount_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(68, 302);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 25);
            this.label5.TabIndex = 0;
            this.label5.Text = "Chức vụ";
            // 
            // txbDisplay
            // 
            this.txbDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbDisplay.Location = new System.Drawing.Point(246, 241);
            this.txbDisplay.Name = "txbDisplay";
            this.txbDisplay.Size = new System.Drawing.Size(130, 30);
            this.txbDisplay.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(68, 244);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(149, 25);
            this.label4.TabIndex = 0;
            this.label4.Text = "Tên người dùng";
            // 
            // txbUser
            // 
            this.txbUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbUser.Location = new System.Drawing.Point(246, 182);
            this.txbUser.Name = "txbUser";
            this.txbUser.Size = new System.Drawing.Size(130, 30);
            this.txbUser.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(68, 187);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 25);
            this.label3.TabIndex = 0;
            this.label3.Text = "Tài khoản";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbSearchChucVu);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txbSearchName);
            this.panel1.Controls.Add(this.txbSearchTk);
            this.panel1.Controls.Add(this.btnUpdateSelf);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(631, 100);
            this.panel1.TabIndex = 2;
            // 
            // cbSearchChucVu
            // 
            this.cbSearchChucVu.FormattingEnabled = true;
            this.cbSearchChucVu.Items.AddRange(new object[] {
            "(None)",
            "Quản lý",
            "Nhân viên"});
            this.cbSearchChucVu.Location = new System.Drawing.Point(493, 64);
            this.cbSearchChucVu.Name = "cbSearchChucVu";
            this.cbSearchChucVu.Size = new System.Drawing.Size(121, 28);
            this.cbSearchChucVu.TabIndex = 12;
            this.cbSearchChucVu.SelectedIndexChanged += new System.EventHandler(this.cbSearchChucVu_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(412, 72);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 20);
            this.label7.TabIndex = 11;
            this.label7.Text = "Chức vụ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(234, 72);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 20);
            this.label8.TabIndex = 11;
            this.label8.Text = "Tên";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 72);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 20);
            this.label6.TabIndex = 11;
            this.label6.Text = "Tài Khoản";
            // 
            // txbSearchName
            // 
            this.txbSearchName.Location = new System.Drawing.Point(276, 66);
            this.txbSearchName.Name = "txbSearchName";
            this.txbSearchName.Size = new System.Drawing.Size(121, 26);
            this.txbSearchName.TabIndex = 10;
            this.txbSearchName.TextChanged += new System.EventHandler(this.txbSearchName_TextChanged);
            // 
            // txbSearchTk
            // 
            this.txbSearchTk.Location = new System.Drawing.Point(107, 66);
            this.txbSearchTk.Name = "txbSearchTk";
            this.txbSearchTk.Size = new System.Drawing.Size(121, 26);
            this.txbSearchTk.TabIndex = 10;
            this.txbSearchTk.TextChanged += new System.EventHandler(this.txbSearchTk_TextChanged);
            // 
            // btnUpdateSelf
            // 
            this.btnUpdateSelf.Location = new System.Drawing.Point(12, 12);
            this.btnUpdateSelf.Name = "btnUpdateSelf";
            this.btnUpdateSelf.Size = new System.Drawing.Size(113, 37);
            this.btnUpdateSelf.TabIndex = 9;
            this.btnUpdateSelf.Text = "Chỉnh sửa";
            this.btnUpdateSelf.UseVisualStyleBackColor = true;
            this.btnUpdateSelf.Click += new System.EventHandler(this.btnUpdateSelf_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Location = new System.Drawing.Point(138, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(312, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Chỉnh sửa thông tin tài khoản của bản thân";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lvAccount);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 100);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(631, 459);
            this.panel3.TabIndex = 3;
            // 
            // lvAccount
            // 
            this.lvAccount.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvAccount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvAccount.Font = new System.Drawing.Font("SVN-Abril Fatface", 9.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvAccount.FullRowSelect = true;
            this.lvAccount.GridLines = true;
            this.lvAccount.HideSelection = false;
            this.lvAccount.Location = new System.Drawing.Point(0, 0);
            this.lvAccount.MultiSelect = false;
            this.lvAccount.Name = "lvAccount";
            this.lvAccount.Size = new System.Drawing.Size(631, 459);
            this.lvAccount.TabIndex = 0;
            this.lvAccount.UseCompatibleStateImageBehavior = false;
            this.lvAccount.View = System.Windows.Forms.View.Details;
            this.lvAccount.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lvAccount_MouseClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Tag = "1";
            this.columnHeader1.Text = "Tài khoản";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Tag = "1";
            this.columnHeader2.Text = "Tên người dùng";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Tag = "1";
            this.columnHeader3.Text = "Chức vụ";
            // 
            // FormTaiKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1047, 559);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormTaiKhoan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tài khoản admin";
            this.Load += new System.EventHandler(this.FormTaiKhoan_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txbDisplay;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txbUser;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnUpdateSelf;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbStat;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnUpdateAccount;
        private System.Windows.Forms.Button btnDeleteAccount;
        private System.Windows.Forms.Button btnAddAccount;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ListView lvAccount;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ComboBox cbSearchChucVu;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txbSearchName;
        private System.Windows.Forms.TextBox txbSearchTk;
    }
}