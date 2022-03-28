using QLNH3LayerClone;
using QLNHBUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLNH3Layer.Forms
{
    public partial class FormXacNhanMatKhau : Form
    {
        public FormXacNhanMatKhau()
        {
            InitializeComponent();
        }

        public bool checkpass = false;

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (txbPass.Text != "")
            {
                if (AccountBUS.Instance.Login(frmLogin.UserName, txbPass.Text))
                {
                    checkpass = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Sai mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa điền mật khẩu");
            }
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
