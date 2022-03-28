namespace QLNH3Layer.Forms
{
    partial class FormGopBan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGopBan));
            this.flpTable = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.cbArea = new System.Windows.Forms.ComboBox();
            this.btnDo = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblChiTiet = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // flpTable
            // 
            this.flpTable.AutoScroll = true;
            this.flpTable.Location = new System.Drawing.Point(39, 88);
            this.flpTable.Name = "flpTable";
            this.flpTable.Size = new System.Drawing.Size(718, 304);
            this.flpTable.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(264, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Khu vực";
            // 
            // cbArea
            // 
            this.cbArea.FormattingEnabled = true;
            this.cbArea.Location = new System.Drawing.Point(348, 13);
            this.cbArea.Name = "cbArea";
            this.cbArea.Size = new System.Drawing.Size(121, 28);
            this.cbArea.TabIndex = 2;
            this.cbArea.SelectedIndexChanged += new System.EventHandler(this.cbArea_SelectedIndexChanged);
            // 
            // btnDo
            // 
            this.btnDo.Location = new System.Drawing.Point(471, 409);
            this.btnDo.Name = "btnDo";
            this.btnDo.Size = new System.Drawing.Size(113, 44);
            this.btnDo.TabIndex = 3;
            this.btnDo.Text = "Thực hiện";
            this.btnDo.UseVisualStyleBackColor = true;
            this.btnDo.Click += new System.EventHandler(this.btnDo_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(644, 409);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(113, 44);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblChiTiet
            // 
            this.lblChiTiet.AutoSize = true;
            this.lblChiTiet.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChiTiet.Location = new System.Drawing.Point(282, 60);
            this.lblChiTiet.Name = "lblChiTiet";
            this.lblChiTiet.Size = new System.Drawing.Size(187, 25);
            this.lblChiTiet.TabIndex = 4;
            this.lblChiTiet.Text = "Gộp bàn ? với bàn ?";
            // 
            // FormGopBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 465);
            this.Controls.Add(this.lblChiTiet);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDo);
            this.Controls.Add(this.cbArea);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.flpTable);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormGopBan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Gộp bàn";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpTable;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbArea;
        private System.Windows.Forms.Button btnDo;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblChiTiet;
    }
}