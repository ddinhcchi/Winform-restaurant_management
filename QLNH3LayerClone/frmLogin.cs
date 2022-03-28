using QLNHBUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLNH3LayerClone
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        //trường truyền tên người dùng đăng nhập cho các form khác
        private static string userDisplayName;

        public static string UserDisplayName
        {
            get => userDisplayName;
            private set => userDisplayName = value;
        }

        //trường truyền tên tài khoản người dùng đăng nhập cho các form khác
        private static string userName;

        public static string UserName { get => userName; private set => userName = value; }

        //trường truyền chức vụ người dùng đăng nhập cho các form khác
        private static int userStatic;

        public static int UserStatic { get => userStatic; private set => userStatic = value; }
        

        private void btDangNhap_Click(object sender, EventArgs e)
        {
            //biến tạm lưu tên đăng nhập và mật khẩu
            string user = txtUser.Text;
            string pass = txtPass.Text;

            //kiểm tra tài khoản mật khẩu
            if (Login(user, pass))
            {
                //lưu tên và chức vụ người dùng 
                UserDisplayName = AccountBUS.Instance.GetDisplayName(user, pass);
                UserStatic = AccountBUS.Instance.GetStatus(user, pass);
                UserName = AccountBUS.Instance.GetUserName(user, pass);
                //mở form Menu
                frmMenu f = new frmMenu();
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            else
            {
                //hiện dòng chữ sai tài khoản hoặc mật khẩu
                if (lbSai.Visible == true)
                {
                    lbSai.Visible = false;
                    Thread.Sleep(150);
                    lbSai.Visible = true;
                }
                lbSai.Visible = true;
            }
        }

        //hàm gọi kiểm tra login của class accountDAO
        bool Login(string username, string password)
        {
            return AccountBUS.Instance.Login(username, password);
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Chắc chắn không?", "Trả lời",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (traloi == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        public void CapNhat(string displayname)
        {
            UserDisplayName = displayname;
            txtUser.Text = displayname;
        }
    }
}
