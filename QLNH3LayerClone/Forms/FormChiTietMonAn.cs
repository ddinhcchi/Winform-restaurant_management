using QLNH3LayerClone;
using QLNHBUS;
using QLNHDTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLNH3Layer.Forms
{
    public partial class FormChiTietMonAn : Form
    {
        public FormChiTietMonAn()
        {
            InitializeComponent();
        }
        string idmon = "";
        bool tontai = true;

        public FormChiTietMonAn(string id) : this()
        {
            if (frmLogin.UserStatic == 0)
            {
                btnUpdate.Visible = false;
            }
            idmon = id;
            ChiTietMonAn ct = ChiTietMonAnBUS.Instance.LoadChiTiet(idmon);
            lblTen.Text = ct.Name;
            if (ct.Detail != "")
            {
                txbChiTiet.Text = ct.Detail;
            }
            else
            {
                if (frmLogin.UserStatic == 0)
                {
                    txbChiTiet.Text = "Món ăn chưa có chi tiết";
                }
                else
                {
                    txbChiTiet.Text = "Món ăn chưa có chi tiết - nhấn nút sửa ở trên để cập nhật chi tiết";
                }
            }

            if (ct.Link != "")
            {
                if (File.Exists(ct.Link))
                {
                    axWindowsMediaPlayer1.URL = ct.Link;
                }
                else
                {
                    tontai = false;
                    MessageBox.Show("Video không tồn tại theo đường dẫn đã lưu\nBạn nên tạo một thư mục riêng để lưu trữ video giới thiệt món ăn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            this.Text = string.Empty;
            this.ControlBox = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            QLNH3Layer.Forms.FormSuaChiTietMonAn f = new FormSuaChiTietMonAn(idmon,tontai);
            f.ShowDialog();
            ChiTietMonAn ct = ChiTietMonAnBUS.Instance.LoadChiTiet(idmon);
            if (ct.Detail != "")
            {
                txbChiTiet.Text = ct.Detail;
            }
            else
            {
                txbChiTiet.Text = "Món ăn chưa có chi tiết - nhấn nút sửa ở trên để cập nhật chi tiết";
            }

            if (ct.Link != "")
            {
                axWindowsMediaPlayer1.URL = ct.Link;
            }
            else
            {
                axWindowsMediaPlayer1.URL = "";
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = "";
            this.Close();
        }

        private void axWindowsMediaPlayer1_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (e.newState == 1 || e.newState == 8)
            {
                axWindowsMediaPlayer1.Ctlcontrols.play();
            }
        }
    }
}
