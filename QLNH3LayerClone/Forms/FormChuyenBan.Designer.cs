namespace QLNH3Layer.Forms
{
    partial class FormChuyenBan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormChuyenBan));
            this.cbArea = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.flpTable = new System.Windows.Forms.FlowLayoutPanel();
            this.lvBill = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvBillbichuyen = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnright1 = new System.Windows.Forms.Button();
            this.btnDo = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblBanChuyen = new System.Windows.Forms.Label();
            this.lblBanBiChuyen = new System.Windows.Forms.Label();
            this.txbSoLuong = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnUndo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbArea
            // 
            this.cbArea.FormattingEnabled = true;
            this.cbArea.Location = new System.Drawing.Point(386, 12);
            this.cbArea.Name = "cbArea";
            this.cbArea.Size = new System.Drawing.Size(121, 28);
            this.cbArea.TabIndex = 0;
            this.cbArea.SelectedIndexChanged += new System.EventHandler(this.cbArea_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(308, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Khu vực";
            // 
            // flpTable
            // 
            this.flpTable.AutoScroll = true;
            this.flpTable.Location = new System.Drawing.Point(12, 57);
            this.flpTable.Name = "flpTable";
            this.flpTable.Size = new System.Drawing.Size(776, 166);
            this.flpTable.TabIndex = 3;
            // 
            // lvBill
            // 
            this.lvBill.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lvBill.FullRowSelect = true;
            this.lvBill.GridLines = true;
            this.lvBill.HideSelection = false;
            this.lvBill.Location = new System.Drawing.Point(12, 342);
            this.lvBill.MultiSelect = false;
            this.lvBill.Name = "lvBill";
            this.lvBill.Size = new System.Drawing.Size(346, 271);
            this.lvBill.TabIndex = 4;
            this.lvBill.UseCompatibleStateImageBehavior = false;
            this.lvBill.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Tag = "2";
            this.columnHeader1.Text = "Tên món";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Tag = "1";
            this.columnHeader2.Text = "Số lượng";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Tag = "1";
            this.columnHeader3.Text = "Giá";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Tag = "1";
            this.columnHeader4.Text = "Thành tiền";
            // 
            // lvBillbichuyen
            // 
            this.lvBillbichuyen.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8});
            this.lvBillbichuyen.FullRowSelect = true;
            this.lvBillbichuyen.GridLines = true;
            this.lvBillbichuyen.HideSelection = false;
            this.lvBillbichuyen.Location = new System.Drawing.Point(442, 342);
            this.lvBillbichuyen.Name = "lvBillbichuyen";
            this.lvBillbichuyen.Size = new System.Drawing.Size(346, 271);
            this.lvBillbichuyen.TabIndex = 4;
            this.lvBillbichuyen.UseCompatibleStateImageBehavior = false;
            this.lvBillbichuyen.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Tag = "2";
            this.columnHeader5.Text = "Tên món";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Tag = "1";
            this.columnHeader6.Text = "Số lượng";
            // 
            // columnHeader7
            // 
            this.columnHeader7.Tag = "1";
            this.columnHeader7.Text = "Giá";
            // 
            // columnHeader8
            // 
            this.columnHeader8.Tag = "1";
            this.columnHeader8.Text = "Thành tiền";
            // 
            // btnright1
            // 
            this.btnright1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnright1.Location = new System.Drawing.Point(364, 396);
            this.btnright1.Name = "btnright1";
            this.btnright1.Size = new System.Drawing.Size(72, 40);
            this.btnright1.TabIndex = 5;
            this.btnright1.Text = ">";
            this.btnright1.UseVisualStyleBackColor = true;
            this.btnright1.Click += new System.EventHandler(this.btnright1_Click);
            // 
            // btnDo
            // 
            this.btnDo.Location = new System.Drawing.Point(535, 620);
            this.btnDo.Name = "btnDo";
            this.btnDo.Size = new System.Drawing.Size(109, 48);
            this.btnDo.TabIndex = 6;
            this.btnDo.Text = "Thực hiện";
            this.btnDo.UseVisualStyleBackColor = true;
            this.btnDo.Click += new System.EventHandler(this.btnDo_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(679, 620);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(109, 48);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblBanChuyen
            // 
            this.lblBanChuyen.AutoSize = true;
            this.lblBanChuyen.Font = new System.Drawing.Font("SVN-Androgyne", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBanChuyen.Location = new System.Drawing.Point(12, 308);
            this.lblBanChuyen.Name = "lblBanChuyen";
            this.lblBanChuyen.Size = new System.Drawing.Size(75, 31);
            this.lblBanChuyen.TabIndex = 7;
            this.lblBanChuyen.Text = "Bàn ?";
            // 
            // lblBanBiChuyen
            // 
            this.lblBanBiChuyen.AutoSize = true;
            this.lblBanBiChuyen.Font = new System.Drawing.Font("SVN-Androgyne", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBanBiChuyen.Location = new System.Drawing.Point(451, 308);
            this.lblBanBiChuyen.Name = "lblBanBiChuyen";
            this.lblBanBiChuyen.Size = new System.Drawing.Size(75, 31);
            this.lblBanBiChuyen.TabIndex = 7;
            this.lblBanBiChuyen.Text = "Bàn ?";
            // 
            // txbSoLuong
            // 
            this.txbSoLuong.Location = new System.Drawing.Point(365, 443);
            this.txbSoLuong.Name = "txbSoLuong";
            this.txbSoLuong.Size = new System.Drawing.Size(71, 26);
            this.txbSoLuong.TabIndex = 8;
            this.txbSoLuong.Text = "1";
            this.txbSoLuong.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label4.Location = new System.Drawing.Point(194, 226);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(396, 60);
            this.label4.TabIndex = 9;
            this.label4.Text = "Lưu ý: - Chuyển bàn thì chỉ cần nhấn thực hiện\r\n          - Tách bàn thì chuyển m" +
    "ón cần tách qua bên phải\r\n             rồi nhấn thực hiện";
            // 
            // btnUndo
            // 
            this.btnUndo.Image = global::QLNH3Layer.Properties.Resources.undo__1_;
            this.btnUndo.Location = new System.Drawing.Point(365, 342);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(72, 40);
            this.btnUndo.TabIndex = 5;
            this.btnUndo.UseVisualStyleBackColor = true;
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // FormChuyenBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 676);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txbSoLuong);
            this.Controls.Add(this.lblBanBiChuyen);
            this.Controls.Add(this.lblBanChuyen);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDo);
            this.Controls.Add(this.btnUndo);
            this.Controls.Add(this.btnright1);
            this.Controls.Add(this.lvBillbichuyen);
            this.Controls.Add(this.lvBill);
            this.Controls.Add(this.flpTable);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbArea);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormChuyenBan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chuyển bàn";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbArea;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flpTable;
        private System.Windows.Forms.ListView lvBill;
        private System.Windows.Forms.ListView lvBillbichuyen;
        private System.Windows.Forms.Button btnright1;
        private System.Windows.Forms.Button btnUndo;
        private System.Windows.Forms.Button btnDo;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblBanChuyen;
        private System.Windows.Forms.Label lblBanBiChuyen;
        private System.Windows.Forms.TextBox txbSoLuong;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.Label label4;
    }
}