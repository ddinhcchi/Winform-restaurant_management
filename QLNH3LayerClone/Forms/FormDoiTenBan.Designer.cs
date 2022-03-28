namespace QLNH3Layer.Forms
{
    partial class FormDoiTenBan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDoiTenBan));
            this.btnChange = new System.Windows.Forms.Button();
            this.lblTableName = new System.Windows.Forms.Label();
            this.txbTableName = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnChange
            // 
            this.btnChange.Location = new System.Drawing.Point(163, 147);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(99, 45);
            this.btnChange.TabIndex = 0;
            this.btnChange.Text = "Sửa";
            this.btnChange.UseVisualStyleBackColor = true;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // lblTableName
            // 
            this.lblTableName.AutoSize = true;
            this.lblTableName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTableName.Location = new System.Drawing.Point(82, 70);
            this.lblTableName.Name = "lblTableName";
            this.lblTableName.Size = new System.Drawing.Size(195, 25);
            this.lblTableName.TabIndex = 1;
            this.lblTableName.Text = "Đổi tên bàn \"?\" thành";
            // 
            // txbTableName
            // 
            this.txbTableName.Location = new System.Drawing.Point(338, 69);
            this.txbTableName.Name = "txbTableName";
            this.txbTableName.Size = new System.Drawing.Size(113, 26);
            this.txbTableName.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(324, 147);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(99, 45);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FormDoiTenBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 216);
            this.Controls.Add(this.txbTableName);
            this.Controls.Add(this.lblTableName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnChange);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormDoiTenBan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Đổi tên bàn";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.Label lblTableName;
        private System.Windows.Forms.TextBox txbTableName;
        private System.Windows.Forms.Button btnCancel;
    }
}