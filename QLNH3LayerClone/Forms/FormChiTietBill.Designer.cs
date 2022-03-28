namespace QLNH3Layer.Forms
{
    partial class FormChiTietBill
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormChiTietBill));
            this.lblBan = new System.Windows.Forms.Label();
            this.lblIdBill = new System.Windows.Forms.Label();
            this.lsvBill = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txbGiamGia = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txbTotal = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.lblDate = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblBan
            // 
            this.lblBan.AutoSize = true;
            this.lblBan.Font = new System.Drawing.Font("SVN-Aaron Script", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblBan.Location = new System.Drawing.Point(133, 47);
            this.lblBan.Name = "lblBan";
            this.lblBan.Size = new System.Drawing.Size(129, 47);
            this.lblBan.TabIndex = 1;
            this.lblBan.Text = "Bàn ?";
            // 
            // lblIdBill
            // 
            this.lblIdBill.AutoSize = true;
            this.lblIdBill.Location = new System.Drawing.Point(12, 9);
            this.lblIdBill.Name = "lblIdBill";
            this.lblIdBill.Size = new System.Drawing.Size(50, 20);
            this.lblIdBill.TabIndex = 2;
            this.lblIdBill.Text = "Bill số";
            // 
            // lsvBill
            // 
            this.lsvBill.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lsvBill.GridLines = true;
            this.lsvBill.HideSelection = false;
            this.lsvBill.Location = new System.Drawing.Point(68, 146);
            this.lsvBill.Name = "lsvBill";
            this.lsvBill.Size = new System.Drawing.Size(432, 330);
            this.lsvBill.TabIndex = 3;
            this.lsvBill.UseCompatibleStateImageBehavior = false;
            this.lsvBill.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Tag = "2";
            this.columnHeader1.Text = "Tên món";
            this.columnHeader1.Width = 147;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Tag = "1";
            this.columnHeader2.Text = "Số lượng";
            this.columnHeader2.Width = 66;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Tag = "1";
            this.columnHeader3.Text = "Giá";
            this.columnHeader3.Width = 81;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Tag = "1";
            this.columnHeader4.Text = "Thành tiền";
            this.columnHeader4.Width = 111;
            // 
            // txbGiamGia
            // 
            this.txbGiamGia.Location = new System.Drawing.Point(255, 482);
            this.txbGiamGia.Name = "txbGiamGia";
            this.txbGiamGia.ReadOnly = true;
            this.txbGiamGia.Size = new System.Drawing.Size(139, 26);
            this.txbGiamGia.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(162, 488);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Giảm giá";
            // 
            // txbTotal
            // 
            this.txbTotal.Location = new System.Drawing.Point(255, 528);
            this.txbTotal.Name = "txbTotal";
            this.txbTotal.ReadOnly = true;
            this.txbTotal.Size = new System.Drawing.Size(139, 26);
            this.txbTotal.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(162, 534);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Tổng";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(219, 566);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(92, 44);
            this.btnOk.TabIndex = 9;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(172, 123);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(51, 20);
            this.lblDate.TabIndex = 10;
            this.lblDate.Text = "label2";
            // 
            // FormChiTietBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 622);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txbTotal);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txbGiamGia);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lsvBill);
            this.Controls.Add(this.lblIdBill);
            this.Controls.Add(this.lblBan);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormChiTietBill";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chi tiết hóa đơn";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBan;
        private System.Windows.Forms.Label lblIdBill;
        private System.Windows.Forms.ListView lsvBill;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.TextBox txbGiamGia;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txbTotal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label lblDate;
    }
}