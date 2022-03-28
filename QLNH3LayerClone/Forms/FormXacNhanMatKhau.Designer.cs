namespace QLNH3Layer.Forms
{
    partial class FormXacNhanMatKhau
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormXacNhanMatKhau));
            this.label1 = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.txbPass = new System.Windows.Forms.TextBox();
            this.btnXacNhan = new System.Windows.Forms.Button();
            this.btncancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Location = new System.Drawing.Point(106, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(392, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Để xác minh là bạn hãy điền mật khẩu hiện tại của bạn";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(106, 78);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(147, 20);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Xác nhận mật khẩu";
            // 
            // txbPass
            // 
            this.txbPass.Location = new System.Drawing.Point(320, 75);
            this.txbPass.Name = "txbPass";
            this.txbPass.Size = new System.Drawing.Size(168, 26);
            this.txbPass.TabIndex = 2;
            this.txbPass.UseSystemPasswordChar = true;
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.Location = new System.Drawing.Point(226, 127);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(112, 39);
            this.btnXacNhan.TabIndex = 3;
            this.btnXacNhan.Text = "Xác nhận";
            this.btnXacNhan.UseVisualStyleBackColor = true;
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // btncancel
            // 
            this.btncancel.Location = new System.Drawing.Point(376, 127);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(112, 39);
            this.btncancel.TabIndex = 3;
            this.btncancel.Text = "Hủy";
            this.btncancel.UseVisualStyleBackColor = true;
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // FormXacNhanMatKhau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 187);
            this.Controls.Add(this.btncancel);
            this.Controls.Add(this.btnXacNhan);
            this.Controls.Add(this.txbPass);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormXacNhanMatKhau";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Xác nhận mật khẩu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txbPass;
        private System.Windows.Forms.Button btnXacNhan;
        private System.Windows.Forms.Button btncancel;
    }
}