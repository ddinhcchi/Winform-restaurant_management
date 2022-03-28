namespace QLNH3LayerClone.Forms
{
    partial class FormDoanhThu
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExport = new System.Windows.Forms.Button();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.checkboxAll = new System.Windows.Forms.CheckBox();
            this.btnTurnBack = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txbDoanhThu = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dtgvBill = new System.Windows.Forms.DataGridView();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvBill)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnExport);
            this.panel1.Controls.Add(this.lblTrangThai);
            this.panel1.Controls.Add(this.checkboxAll);
            this.panel1.Controls.Add(this.btnTurnBack);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txbDoanhThu);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(974, 109);
            this.panel1.TabIndex = 0;
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Location = new System.Drawing.Point(861, 72);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(110, 31);
            this.btnExport.TabIndex = 5;
            this.btnExport.Text = "Xuất excel";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrangThai.Location = new System.Drawing.Point(333, 83);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(59, 20);
            this.lblTrangThai.TabIndex = 4;
            this.lblTrangThai.Text = "Tất cả";
            // 
            // checkboxAll
            // 
            this.checkboxAll.AutoSize = true;
            this.checkboxAll.Location = new System.Drawing.Point(757, 31);
            this.checkboxAll.Name = "checkboxAll";
            this.checkboxAll.Size = new System.Drawing.Size(79, 24);
            this.checkboxAll.TabIndex = 3;
            this.checkboxAll.Text = "Tất cả";
            this.checkboxAll.UseVisualStyleBackColor = true;
            this.checkboxAll.CheckedChanged += new System.EventHandler(this.checkboxAll_CheckedChanged);
            // 
            // btnTurnBack
            // 
            this.btnTurnBack.Location = new System.Drawing.Point(3, 69);
            this.btnTurnBack.Name = "btnTurnBack";
            this.btnTurnBack.Size = new System.Drawing.Size(111, 34);
            this.btnTurnBack.TabIndex = 2;
            this.btnTurnBack.Text = "Quay Lại";
            this.btnTurnBack.UseVisualStyleBackColor = true;
            this.btnTurnBack.Click += new System.EventHandler(this.btnTurnBack_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(333, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tổng doanh thu";
            // 
            // txbDoanhThu
            // 
            this.txbDoanhThu.Location = new System.Drawing.Point(506, 31);
            this.txbDoanhThu.Name = "txbDoanhThu";
            this.txbDoanhThu.ReadOnly = true;
            this.txbDoanhThu.Size = new System.Drawing.Size(140, 26);
            this.txbDoanhThu.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dtgvBill);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 109);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(974, 415);
            this.panel2.TabIndex = 1;
            // 
            // dtgvBill
            // 
            this.dtgvBill.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvBill.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvBill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgvBill.Location = new System.Drawing.Point(0, 0);
            this.dtgvBill.MultiSelect = false;
            this.dtgvBill.Name = "dtgvBill";
            this.dtgvBill.ReadOnly = true;
            this.dtgvBill.RowTemplate.Height = 28;
            this.dtgvBill.Size = new System.Drawing.Size(974, 415);
            this.dtgvBill.TabIndex = 0;
            this.dtgvBill.DoubleClick += new System.EventHandler(this.dtgvBill_DoubleClick);
            // 
            // FormDoanhThu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 524);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FormDoanhThu";
            this.Text = "FormDoanhThu";
            this.Load += new System.EventHandler(this.FormDoanhThu_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvBill)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbDoanhThu;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dtgvBill;
        private System.Windows.Forms.Button btnTurnBack;
        private System.Windows.Forms.CheckBox checkboxAll;
        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}