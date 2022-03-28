namespace QLNH3Layer.Forms
{
    partial class FormSuaChiTietMonAn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSuaChiTietMonAn));
            this.txbChiTiet = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTen = new System.Windows.Forms.Label();
            this.txbVideoName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // txbChiTiet
            // 
            this.txbChiTiet.Location = new System.Drawing.Point(139, 156);
            this.txbChiTiet.Multiline = true;
            this.txbChiTiet.Name = "txbChiTiet";
            this.txbChiTiet.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txbChiTiet.Size = new System.Drawing.Size(520, 115);
            this.txbChiTiet.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(135, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Chi tiết món ăn";
            // 
            // lblTen
            // 
            this.lblTen.AutoSize = true;
            this.lblTen.Font = new System.Drawing.Font("SVN-Aaron Script", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblTen.Location = new System.Drawing.Point(352, 50);
            this.lblTen.Name = "lblTen";
            this.lblTen.Size = new System.Drawing.Size(86, 42);
            this.lblTen.TabIndex = 1;
            this.lblTen.Text = "label1";
            // 
            // txbVideoName
            // 
            this.txbVideoName.Location = new System.Drawing.Point(139, 335);
            this.txbVideoName.Name = "txbVideoName";
            this.txbVideoName.Size = new System.Drawing.Size(453, 26);
            this.txbVideoName.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(135, 297);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Video";
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenFile.Location = new System.Drawing.Point(598, 330);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(61, 35);
            this.btnOpenFile.TabIndex = 3;
            this.btnOpenFile.Text = "...";
            this.btnOpenFile.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(511, 406);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(148, 40);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Lưu và thoát";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // FormSuaChiTietMonAn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 458);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnOpenFile);
            this.Controls.Add(this.txbVideoName);
            this.Controls.Add(this.lblTen);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txbChiTiet);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSuaChiTietMonAn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Sửa chi tiết món ăn";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txbChiTiet;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTen;
        private System.Windows.Forms.TextBox txbVideoName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}