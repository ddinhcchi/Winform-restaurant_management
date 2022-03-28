namespace QLNH3LayerClone.Forms
{
    partial class FormBanAn
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
            this.label6 = new System.Windows.Forms.Label();
            this.cbArea = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.flpTable = new System.Windows.Forms.FlowLayoutPanel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnUpdateTable = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.lbltable = new System.Windows.Forms.Label();
            this.btnMinus = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.nmud = new System.Windows.Forms.NumericUpDown();
            this.cbLoai = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbFood = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnChuyen = new System.Windows.Forms.Button();
            this.btnGopBan = new System.Windows.Forms.Button();
            this.btnPay = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txbTotal = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.lvBill = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmud)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(29, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 25);
            this.label6.TabIndex = 1;
            this.label6.Text = "Khu vực";
            // 
            // cbArea
            // 
            this.cbArea.FormattingEnabled = true;
            this.cbArea.Location = new System.Drawing.Point(141, 55);
            this.cbArea.Name = "cbArea";
            this.cbArea.Size = new System.Drawing.Size(173, 28);
            this.cbArea.TabIndex = 0;
            this.cbArea.SelectedValueChanged += new System.EventHandler(this.cbArea_SelectedValueChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(393, 591);
            this.panel1.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.flpTable);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 100);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(393, 491);
            this.panel6.TabIndex = 4;
            // 
            // flpTable
            // 
            this.flpTable.AutoScroll = true;
            this.flpTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpTable.Location = new System.Drawing.Point(0, 0);
            this.flpTable.Name = "flpTable";
            this.flpTable.Size = new System.Drawing.Size(393, 491);
            this.flpTable.TabIndex = 2;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btnUpdateTable);
            this.panel5.Controls.Add(this.label6);
            this.panel5.Controls.Add(this.cbArea);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(393, 100);
            this.panel5.TabIndex = 3;
            // 
            // btnUpdateTable
            // 
            this.btnUpdateTable.Location = new System.Drawing.Point(12, 10);
            this.btnUpdateTable.Name = "btnUpdateTable";
            this.btnUpdateTable.Size = new System.Drawing.Size(119, 37);
            this.btnUpdateTable.TabIndex = 2;
            this.btnUpdateTable.Text = "Chỉnh sửa";
            this.btnUpdateTable.UseVisualStyleBackColor = true;
            this.btnUpdateTable.Click += new System.EventHandler(this.btnUpdateTable_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.lbltable);
            this.panel4.Controls.Add(this.btnMinus);
            this.panel4.Controls.Add(this.btnAdd);
            this.panel4.Controls.Add(this.nmud);
            this.panel4.Controls.Add(this.cbLoai);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.cbFood);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(699, 100);
            this.panel4.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(284, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 25);
            this.label4.TabIndex = 1;
            this.label4.Text = "Số lượng";
            // 
            // lbltable
            // 
            this.lbltable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lbltable.AutoSize = true;
            this.lbltable.Font = new System.Drawing.Font("Mistral", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltable.Location = new System.Drawing.Point(543, 22);
            this.lbltable.Name = "lbltable";
            this.lbltable.Size = new System.Drawing.Size(109, 53);
            this.lbltable.TabIndex = 7;
            this.lbltable.Text = "Bàn ?";
            // 
            // btnMinus
            // 
            this.btnMinus.Location = new System.Drawing.Point(431, 50);
            this.btnMinus.Name = "btnMinus";
            this.btnMinus.Size = new System.Drawing.Size(84, 36);
            this.btnMinus.TabIndex = 2;
            this.btnMinus.Text = "Bớt";
            this.btnMinus.UseVisualStyleBackColor = true;
            this.btnMinus.Click += new System.EventHandler(this.btnMinus_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(431, 8);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(84, 36);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // nmud
            // 
            this.nmud.Location = new System.Drawing.Point(289, 58);
            this.nmud.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmud.Name = "nmud";
            this.nmud.Size = new System.Drawing.Size(120, 26);
            this.nmud.TabIndex = 3;
            this.nmud.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cbLoai
            // 
            this.cbLoai.FormattingEnabled = true;
            this.cbLoai.Location = new System.Drawing.Point(105, 10);
            this.cbLoai.Name = "cbLoai";
            this.cbLoai.Size = new System.Drawing.Size(173, 28);
            this.cbLoai.TabIndex = 0;
            this.cbLoai.SelectedIndexChanged += new System.EventHandler(this.cbLoai_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 25);
            this.label3.TabIndex = 1;
            this.label3.Text = "Loại món";
            // 
            // cbFood
            // 
            this.cbFood.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbFood.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbFood.FormattingEnabled = true;
            this.cbFood.Location = new System.Drawing.Point(105, 56);
            this.cbFood.Name = "cbFood";
            this.cbFood.Size = new System.Drawing.Size(173, 28);
            this.cbFood.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên";
            // 
            // btnChuyen
            // 
            this.btnChuyen.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnChuyen.Location = new System.Drawing.Point(10, 117);
            this.btnChuyen.Name = "btnChuyen";
            this.btnChuyen.Size = new System.Drawing.Size(110, 45);
            this.btnChuyen.TabIndex = 6;
            this.btnChuyen.Text = "Chuyển bàn";
            this.btnChuyen.UseVisualStyleBackColor = true;
            this.btnChuyen.Click += new System.EventHandler(this.btnChuyen_Click);
            // 
            // btnGopBan
            // 
            this.btnGopBan.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnGopBan.Location = new System.Drawing.Point(10, 179);
            this.btnGopBan.Name = "btnGopBan";
            this.btnGopBan.Size = new System.Drawing.Size(110, 45);
            this.btnGopBan.TabIndex = 6;
            this.btnGopBan.Text = "Gộp bàn";
            this.btnGopBan.UseVisualStyleBackColor = true;
            this.btnGopBan.Click += new System.EventHandler(this.btnGopBan_Click);
            // 
            // btnPay
            // 
            this.btnPay.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnPay.Location = new System.Drawing.Point(10, 433);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(110, 45);
            this.btnPay.TabIndex = 6;
            this.btnPay.Text = "Thanh toán";
            this.btnPay.UseVisualStyleBackColor = true;
            this.btnPay.Click += new System.EventHandler(this.btnPay_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 347);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 25);
            this.label1.TabIndex = 7;
            this.label1.Text = "Thành tiền";
            // 
            // txbTotal
            // 
            this.txbTotal.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txbTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbTotal.Location = new System.Drawing.Point(10, 387);
            this.txbTotal.Name = "txbTotal";
            this.txbTotal.ReadOnly = true;
            this.txbTotal.Size = new System.Drawing.Size(141, 30);
            this.txbTotal.TabIndex = 8;
            this.txbTotal.Text = "0";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel7);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(393, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(699, 591);
            this.panel2.TabIndex = 1;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.lvBill);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(0, 100);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(542, 491);
            this.panel7.TabIndex = 10;
            // 
            // lvBill
            // 
            this.lvBill.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lvBill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvBill.FullRowSelect = true;
            this.lvBill.GridLines = true;
            this.lvBill.HideSelection = false;
            this.lvBill.Location = new System.Drawing.Point(0, 0);
            this.lvBill.Name = "lvBill";
            this.lvBill.Size = new System.Drawing.Size(542, 491);
            this.lvBill.TabIndex = 0;
            this.lvBill.UseCompatibleStateImageBehavior = false;
            this.lvBill.View = System.Windows.Forms.View.Details;
            this.lvBill.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lvBill_MouseClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Tag = "2";
            this.columnHeader1.Text = "Tên món";
            this.columnHeader1.Width = 115;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Tag = "1";
            this.columnHeader2.Text = "Số lượng";
            this.columnHeader2.Width = 81;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Tag = "1";
            this.columnHeader3.Text = "Giá";
            this.columnHeader3.Width = 88;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Tag = "1";
            this.columnHeader4.Text = "Thành tiền";
            this.columnHeader4.Width = 177;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnChuyen);
            this.panel3.Controls.Add(this.btnPay);
            this.panel3.Controls.Add(this.txbTotal);
            this.panel3.Controls.Add(this.btnGopBan);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(542, 100);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(157, 491);
            this.panel3.TabIndex = 9;
            // 
            // FormBanAn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1092, 591);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FormBanAn";
            this.Text = "Ban An";
            this.Load += new System.EventHandler(this.FormBanAn_Load);
            this.panel1.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmud)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbArea;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.FlowLayoutPanel flpTable;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbltable;
        private System.Windows.Forms.Button btnMinus;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.NumericUpDown nmud;
        private System.Windows.Forms.ComboBox cbLoai;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbFood;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnChuyen;
        private System.Windows.Forms.Button btnGopBan;
        private System.Windows.Forms.Button btnPay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbTotal;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.ListView lvBill;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnUpdateTable;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
    }
}