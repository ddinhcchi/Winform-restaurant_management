namespace QLNH3LayerClone.Forms
{
    partial class FormThucDon
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
            this.components = new System.ComponentModel.Container();
            this.cbLoai = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbSortPrice = new System.Windows.Forms.ComboBox();
            this.btnDeleteFood = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblInfo = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.cbUpdateLoai = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.labelPrice = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txbID = new System.Windows.Forms.TextBox();
            this.txbPrice = new System.Windows.Forms.TextBox();
            this.txbName = new System.Windows.Forms.TextBox();
            this.btnAddFood = new System.Windows.Forms.Button();
            this.btnUpdateFood = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txbTen = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dtgvFood = new System.Windows.Forms.DataGridView();
            this.ttAddFood = new System.Windows.Forms.ToolTip(this.components);
            this.ttDeleteFood = new System.Windows.Forms.ToolTip(this.components);
            this.ttUpdateFood = new System.Windows.Forms.ToolTip(this.components);
            this.ttRefresh = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvFood)).BeginInit();
            this.SuspendLayout();
            // 
            // cbLoai
            // 
            this.cbLoai.FormattingEnabled = true;
            this.cbLoai.Location = new System.Drawing.Point(232, 17);
            this.cbLoai.Name = "cbLoai";
            this.cbLoai.Size = new System.Drawing.Size(121, 28);
            this.cbLoai.TabIndex = 9;
            this.cbLoai.SelectedValueChanged += new System.EventHandler(this.cbLoai_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(152, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Loại món";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(369, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Giá dưới";
            // 
            // cbSortPrice
            // 
            this.cbSortPrice.FormattingEnabled = true;
            this.cbSortPrice.Location = new System.Drawing.Point(443, 19);
            this.cbSortPrice.Name = "cbSortPrice";
            this.cbSortPrice.Size = new System.Drawing.Size(121, 28);
            this.cbSortPrice.TabIndex = 10;
            this.cbSortPrice.SelectedValueChanged += new System.EventHandler(this.cbSortPrice_SelectedValueChanged);
            // 
            // btnDeleteFood
            // 
            this.btnDeleteFood.Location = new System.Drawing.Point(126, 423);
            this.btnDeleteFood.Name = "btnDeleteFood";
            this.btnDeleteFood.Size = new System.Drawing.Size(105, 62);
            this.btnDeleteFood.TabIndex = 5;
            this.btnDeleteFood.TabStop = false;
            this.btnDeleteFood.Text = "Xóa";
            this.ttDeleteFood.SetToolTip(this.btnDeleteFood, "Xóa món theo ID");
            this.btnDeleteFood.UseVisualStyleBackColor = true;
            this.btnDeleteFood.Click += new System.EventHandler(this.btnDeleteFood_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblInfo);
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.cbUpdateLoai);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.labelPrice);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txbID);
            this.panel1.Controls.Add(this.txbPrice);
            this.panel1.Controls.Add(this.txbName);
            this.panel1.Controls.Add(this.btnAddFood);
            this.panel1.Controls.Add(this.btnUpdateFood);
            this.panel1.Controls.Add(this.btnDeleteFood);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(593, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(356, 526);
            this.panel1.TabIndex = 5;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Segoe Script", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.Location = new System.Drawing.Point(78, 35);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(218, 57);
            this.lblInfo.TabIndex = 8;
            this.lblInfo.Text = "Thông tin";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(241, 116);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(115, 31);
            this.btnRefresh.TabIndex = 7;
            this.btnRefresh.Text = "Làm mới";
            this.ttRefresh.SetToolTip(this.btnRefresh, "Làm sạch dữ liệu nhập vào\r\n");
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(25, 159);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 29);
            this.label6.TabIndex = 6;
            this.label6.Text = "ID";
            // 
            // cbUpdateLoai
            // 
            this.cbUpdateLoai.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbUpdateLoai.FormattingEnabled = true;
            this.cbUpdateLoai.Location = new System.Drawing.Point(143, 323);
            this.cbUpdateLoai.Name = "cbUpdateLoai";
            this.cbUpdateLoai.Size = new System.Drawing.Size(192, 33);
            this.cbUpdateLoai.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(25, 322);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 29);
            this.label5.TabIndex = 6;
            this.label5.Text = "Loại món";
            // 
            // labelPrice
            // 
            this.labelPrice.AutoSize = true;
            this.labelPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPrice.Location = new System.Drawing.Point(25, 266);
            this.labelPrice.Name = "labelPrice";
            this.labelPrice.Size = new System.Drawing.Size(50, 29);
            this.labelPrice.TabIndex = 6;
            this.labelPrice.Text = "Giá";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(25, 213);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 29);
            this.label3.TabIndex = 6;
            this.label3.Text = "Tên";
            // 
            // txbID
            // 
            this.txbID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbID.Location = new System.Drawing.Point(143, 153);
            this.txbID.MaxLength = 5;
            this.txbID.Name = "txbID";
            this.txbID.Size = new System.Drawing.Size(192, 30);
            this.txbID.TabIndex = 0;
            // 
            // txbPrice
            // 
            this.txbPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbPrice.Location = new System.Drawing.Point(143, 266);
            this.txbPrice.Name = "txbPrice";
            this.txbPrice.Size = new System.Drawing.Size(192, 30);
            this.txbPrice.TabIndex = 2;
            // 
            // txbName
            // 
            this.txbName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbName.Location = new System.Drawing.Point(143, 213);
            this.txbName.Name = "txbName";
            this.txbName.Size = new System.Drawing.Size(192, 30);
            this.txbName.TabIndex = 1;
            // 
            // btnAddFood
            // 
            this.btnAddFood.Location = new System.Drawing.Point(6, 424);
            this.btnAddFood.Name = "btnAddFood";
            this.btnAddFood.Size = new System.Drawing.Size(105, 60);
            this.btnAddFood.TabIndex = 4;
            this.btnAddFood.TabStop = false;
            this.btnAddFood.Text = "Thêm";
            this.ttAddFood.SetToolTip(this.btnAddFood, "Thêm món ăn");
            this.btnAddFood.UseVisualStyleBackColor = true;
            this.btnAddFood.Click += new System.EventHandler(this.btnAddFood_Click);
            // 
            // btnUpdateFood
            // 
            this.btnUpdateFood.Location = new System.Drawing.Point(248, 423);
            this.btnUpdateFood.Name = "btnUpdateFood";
            this.btnUpdateFood.Size = new System.Drawing.Size(105, 62);
            this.btnUpdateFood.TabIndex = 6;
            this.btnUpdateFood.TabStop = false;
            this.btnUpdateFood.Text = "Sửa";
            this.ttUpdateFood.SetToolTip(this.btnUpdateFood, "Sửa thông tin món theo ID");
            this.btnUpdateFood.UseVisualStyleBackColor = true;
            this.btnUpdateFood.Click += new System.EventHandler(this.btnUpdateFood_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txbTen);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.cbLoai);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.cbSortPrice);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(593, 57);
            this.panel2.TabIndex = 6;
            // 
            // txbTen
            // 
            this.txbTen.Location = new System.Drawing.Point(46, 19);
            this.txbTen.Name = "txbTen";
            this.txbTen.Size = new System.Drawing.Size(100, 26);
            this.txbTen.TabIndex = 8;
            this.txbTen.TextChanged += new System.EventHandler(this.txbTen_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Tên";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dtgvFood);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 57);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(593, 469);
            this.panel3.TabIndex = 7;
            // 
            // dtgvFood
            // 
            this.dtgvFood.AllowUserToAddRows = false;
            this.dtgvFood.AllowUserToDeleteRows = false;
            this.dtgvFood.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvFood.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgvFood.Location = new System.Drawing.Point(0, 0);
            this.dtgvFood.MultiSelect = false;
            this.dtgvFood.Name = "dtgvFood";
            this.dtgvFood.ReadOnly = true;
            this.dtgvFood.RowTemplate.Height = 28;
            this.dtgvFood.Size = new System.Drawing.Size(593, 469);
            this.dtgvFood.TabIndex = 0;
            this.dtgvFood.TabStop = false;
            this.dtgvFood.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvFood_CellClick);
            this.dtgvFood.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvFood_CellDoubleClick);
            // 
            // FormThucDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 526);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FormThucDon";
            this.Text = "Thuc Don";
            this.Load += new System.EventHandler(this.FormThucDon_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvFood)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox cbLoai;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbSortPrice;
        private System.Windows.Forms.Button btnDeleteFood;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnAddFood;
        private System.Windows.Forms.Button btnUpdateFood;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelPrice;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txbID;
        private System.Windows.Forms.TextBox txbPrice;
        private System.Windows.Forms.TextBox txbName;
        private System.Windows.Forms.DataGridView dtgvFood;
        private System.Windows.Forms.ComboBox cbUpdateLoai;
        private System.Windows.Forms.TextBox txbTen;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ToolTip ttAddFood;
        private System.Windows.Forms.ToolTip ttDeleteFood;
        private System.Windows.Forms.ToolTip ttUpdateFood;
        private System.Windows.Forms.ToolTip ttRefresh;
    }
}