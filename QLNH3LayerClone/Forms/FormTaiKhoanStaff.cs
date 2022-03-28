using QLNH3LayerClone;
using QLNHBUS;
using QLNHDAL;
using QLNHDTO;
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
    public partial class FormTaiKhoanStaff : Form
    {
        public FormTaiKhoanStaff()
        {
            InitializeComponent();
        }
        string tenmoi = "";
        bool check = false;

        public event EventHandler ButtonClicked;

        public void NotifyButtonClicked(EventArgs e)
        {
            if (ButtonClicked != null)
                ButtonClicked(this, e);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool kiemtra = true;
            if (txbName.Text!="")
            {
                string tentmp = txbName.Text;
                string c = " ";
                tentmp = tentmp.Replace(c, string.Empty);
                if (tentmp == "")
                {
                    kiemtra = false;
                    MessageBox.Show("Tên có thể để trống nhưng không được chứa toàn khoảng trắng");
                }
            }

            if (txbnewpass.Text == "" && txbxacnhan.Text == "" && txbName.Text == "")
            {
                kiemtra = false;
                MessageBox.Show("Chưa điền thông tin nào để sửa cả");
            }
            else if (txbnewpass.Text == "" && txbxacnhan.Text == "" && txbName.Text != "")
            {
                string namehientai = "";
                List<Account> lst = AccountDAL.Instance.GetAccounts();
                foreach (Account ac in lst)
                {
                    if (ac.UserName == frmLogin.UserName)
                    {
                        namehientai = ac.DisplayName;
                        break;
                    }
                }

                if (txbName.Text == namehientai)
                {
                    kiemtra = false;
                    MessageBox.Show("Không có thông tin mới nào để sửa cả");
                }
            }
            else
            {
                if (txbnewpass.Text != "")
                {
                    KiemTraHopLe();
                    if (check)
                    {
                        if (txbnewpass.Text != txbxacnhan.Text)
                        {
                            kiemtra = false;
                            MessageBox.Show("Xác nhận mật khẩu mới không chính xác");
                        }
                    }
                    else
                    {
                        kiemtra = false;
                    }
                }
                else if (txbxacnhan.Text != "")
                {
                    kiemtra = false;
                    MessageBox.Show("Chưa điền mật khẩu mới");
                }
            }

            if (kiemtra)
            {
                FormXacNhanMatKhau f = new FormXacNhanMatKhau();
                f.ShowDialog();
                if (f.checkpass)
                {
                    if (txbName.Text == "")
                    {
                        tenmoi = frmLogin.UserDisplayName;
                    }
                    else
                    {
                        tenmoi = txbName.Text;
                    }
                    AccountBUS.Instance.Update(frmLogin.UserName, tenmoi, txbnewpass.Text, frmLogin.UserStatic);
                    MessageBox.Show("Lưu thành công");
                    FormTaiKhoanStaff_Load(sender, e);
                    NotifyButtonClicked(e);
                    if (frmLogin.UserStatic == 1)
                    {
                        this.Close();
                    }
                }
            }
        }

        private void KiemTraHopLe()
        {
            if (txbnewpass.Text.Length < 8 || txbnewpass.Text.Length > 16)
            {
                check = false;
                MessageBox.Show("Mật khẩu chỉ từ 8 đến 16 ký tự");
            }

            //kiem tra mat khau hop le
            else if (txbnewpass.Text.Length >= 8 && txbnewpass.Text.Length <= 16)
            {
                //bien kiem tra co ky tu dac biet
                bool codacbiet = false;
                //bien kiem tra co ky tu in hoa
                bool cohoa = false;
                //bien kiem tra co ky tu in thuong
                bool cothuong = false;
                //bien kiem tra co ky tu so
                bool coso = false;

                //chuoi kiem tra
                string specialChar = @"~\|!#$%&/()=?»«@£§€{}.-;'<>_,";
                string upperLetter = @"ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                string lowerLetter = @"abcdefghijklmnopqrstuvwxyz";
                string number = @"0123456789";

                //vong lap kiem tra
                foreach (var item in specialChar)
                {
                    if (txbnewpass.Text.Contains(item))
                    {
                        codacbiet = true;
                        break;
                    }
                }

                foreach (var item in upperLetter)
                {
                    if (txbnewpass.Text.Contains(item))
                    {
                        cohoa = true;
                        break;
                    }
                }

                foreach (var item in lowerLetter)
                {
                    if (txbnewpass.Text.Contains(item))
                    {
                        cothuong = true;
                        break;
                    }
                }

                foreach (var item in number)
                {
                    if (txbnewpass.Text.Contains(item))
                    {
                        coso = true;
                        break;
                    }
                }

                if (!codacbiet || !cohoa || !cothuong || !coso)
                {
                    MessageBox.Show("Pass cần có ít nhất 1 chữ thường, 1 chữ hoa, 1 ký tự đặc biệt, 1 số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    check = false;
                }
                else
                {
                    check = true;
                }
            }
        }

        private void FormTaiKhoanStaff_Load(object sender, EventArgs e)
        {
            LoadTheme();
            txbUserName.Text = frmLogin.UserName;
            List<Account> lst = AccountDAL.Instance.GetAccounts();
            foreach (Account ac in lst)
            {
                if (ac.UserName == frmLogin.UserName)
                {
                    txbName.Text = ac.DisplayName;
                    break;
                }
            }

            if (frmLogin.UserStatic == 1)
            {
                btnSave.Text = "Lưu và thoát";
            }
            txbnewpass.Clear();
            txbxacnhan.Clear();
        }

        //hàm chuyển đổi màu cho các nút chức năng
        private void LoadTheme()
        {
            //lấy toàn control trong form (vì thiết kế form đều dùng panel nên lấy panel trước)
            foreach (Control pnls in this.Controls)
            {
                //lấy toàn bộ control là panel
                if (pnls.GetType() == typeof(Panel))
                {
                    Panel pnl = (Panel)pnls;
                    //lấy toàn bộ control có trong panel
                    foreach (Control btns in pnl.Controls)
                    {
                        //lấy toàn bộ button trong panel
                        if (btns.GetType() == typeof(Button))
                        {
                            //chuyển đổi màu và định dạng của button
                            Button btn = (Button)btns;
                            btn.BackColor = ThemeColor.PrimaryColor;
                            btn.ForeColor = Color.Black;
                            btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                            btn.TabStop = false;
                            btn.FlatStyle = FlatStyle.Flat;
                            btn.FlatAppearance.BorderSize = 0;
                        }
                    }
                }
            }
        }
    }
}
