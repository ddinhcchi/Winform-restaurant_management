using QLNHDAL;
using QLNHDTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLNH3LayerClone
{
    public partial class frmMenu : Form
    {
        //fields
        private Button currentButton;
        private Random random;
        private int tempIndex;
        private Form activeForm;
        private string childformname;

        //constructor
        public frmMenu()
        {
            InitializeComponent();
            random = new Random();
            btnCloseChildForm.Visible = false;
            //làm mất thanh bar ở trên cùng của cửa sổ
            this.Text = string.Empty;
            this.ControlBox = false;
            //ngăn cửa sổ che mất thanh taskbar
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }

        //Có thể nhấn giữ vào thanh title và di chuột để di chuyển toàn cửa sổ
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wMsg, int WParam, int lParam);

        //method
        //lấy tên user đăng nhập vào để hiển thị ra màn hình
        private void ThongBao_Load(object sender, EventArgs e)
        {
            lbUser.Text = frmLogin.UserDisplayName;
            if (frmLogin.UserStatic == 1)
            {
                lblChucVu.Text = "Chức vụ: Admin";
            }
            else
            {
                lblChucVu.Text = "Chức vụ: Staff";
                btnDoanhThu.Visible = false;
            }

        }

        //Hàm chọn màu random
        private Color SelectThemeColor()
        {
            int index = random.Next(ThemeColor.ColorList.Count);
            while (tempIndex == index)
            {
                index = random.Next(ThemeColor.ColorList.Count);
            }
            tempIndex = index;
            string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }

        //Hàm thanh đổi giao diện button khi được nhấn
        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = SelectThemeColor();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.Black;
                    currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    panelTitle.BackColor = color;
                    panelLogo.BackColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    ThemeColor.PrimaryColor = color;
                    ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    btnCloseChildForm.Visible = true;
                }
            }
        }

        //hàm trả button về giao diện ban đầu
        private void DisableButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(255, 192, 128);
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }

        //hàm mở form con
        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktopPane.Controls.Add(childForm);
            this.panelDesktopPane.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitle.Text = childformname;
        }

        //Click nut ban an
        private void btnBanAn_Click(object sender, EventArgs e)
        {
            //mở form con bàn ăn
            childformname = "Bàn ăn";
            OpenChildForm(new Forms.FormBanAn(), sender);
        }

        //click nút thực đơn
        private void btnThucDon_Click(object sender, EventArgs e)
        {
            //mở form con thực đơn
            childformname = "Thực đơn";
            OpenChildForm(new Forms.FormThucDon(), sender);
        }

        //click nút doanh thu
        private void btnDoanhThu_Click(object sender, EventArgs e)
        {
            //mở form con doanh thu
            childformname = "Doanh thu";
            OpenChildForm(new Forms.FormDoanhThu(), sender);
        }

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            childformname = "Tài khoản";
            if (frmLogin.UserStatic == 1)
            {
                Forms.FormTaiKhoan f = new Forms.FormTaiKhoan();
                if (activeForm != null)
                {
                    activeForm.Close();
                }
                ActivateButton(sender);
                activeForm = f;
                f.TopLevel = false;
                f.FormBorderStyle = FormBorderStyle.None;
                f.Dock = DockStyle.Fill;
                this.panelDesktopPane.Controls.Add(f);
                this.panelDesktopPane.Tag = f;
                f.BringToFront();
                f.ButtonClicked += new EventHandler(f_ButtonClicked);
                f.Show();
                lblTitle.Text = childformname;
            }
            else
            {
                QLNH3Layer.Forms.FormTaiKhoanStaff f = new QLNH3Layer.Forms.FormTaiKhoanStaff();
                if (activeForm != null)
                {
                    activeForm.Close();
                }
                ActivateButton(sender);
                activeForm = f;
                f.TopLevel = false;
                f.FormBorderStyle = FormBorderStyle.None;
                f.Dock = DockStyle.Fill;
                this.panelDesktopPane.Controls.Add(f);
                this.panelDesktopPane.Tag = f;
                f.BringToFront();
                f.ButtonClicked += new EventHandler(f_ButtonClicked);
                f.Show();
                lblTitle.Text = childformname;
            }
            
        }

        void f_ButtonClicked(object sender, EventArgs e)
        {
            List<Account> lst = AccountDAL.Instance.GetAccounts();
            foreach(Account ac in lst)
            {
                if (ac.UserName == frmLogin.UserName)
                {
                    lbUser.Text = ac.DisplayName;
                    break;
                }
            }
        }

        //click nút x (đóng form con)
        private void btnCloseChildForm_Click(object sender, EventArgs e)
        {
            //kiểm tra xem có form con nào đang mở không
            if (activeForm != null)
                activeForm.Close();
            Reset();
        }

        //hàm reset form Menu lại thành ban đầu
        private void Reset()
        {
            DisableButton();
            lblTitle.Text = "Nhóm Muối Biển";
            panelTitle.BackColor = Color.FromArgb(255, 128, 0);
            panelLogo.BackColor = Color.FromArgb(192, 0, 0);
            currentButton = null;
            btnCloseChildForm.Visible = false;
            btnBanAn.ForeColor = Color.Black;
            btnBanAn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btnThucDon.ForeColor = Color.Black;
            btnThucDon.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btnDoanhThu.ForeColor = Color.Black;
            btnDoanhThu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btnTaiKhoan.ForeColor = Color.Black;
            btnTaiKhoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        //hàm di chuyển cửa sổ bằng cách nhấn giữ panel và di chuột
        private void panelTitle_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        //hàm đóng cửa sổ
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //hàm phóng to nhỏ cửa sổ
        private void btnMaximize_Click(object sender, EventArgs e)
        {
            //kiểm tra tình trạng cửa sổ có phải nhỏ không
            if (WindowState == FormWindowState.Normal)
            {
                //nếu nhỏ thì chuyển thành lớn
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                //nếu lớn thì chuyển thành nhỏ
                this.WindowState = FormWindowState.Normal;
            }
        }

        //kéo ứng xuống thanh taskbar
        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
