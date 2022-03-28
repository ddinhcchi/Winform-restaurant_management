using QLNHBUS;
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
    public partial class FormSuaChiTietMonAn : Form
    {
        public FormSuaChiTietMonAn()
        {
            InitializeComponent();
        }
        string idmon = "";
        string filePath = "";
        string fileName = "";
        public FormSuaChiTietMonAn(string id, bool tontai) : this()
        {
            idmon = id;
            idmon = id;
            ChiTietMonAn ct = ChiTietMonAnBUS.Instance.LoadChiTiet(idmon);
            lblTen.Text = ct.Name;
            if (ct.Detail != "")
            {
                txbChiTiet.Text = ct.Detail;
            }

            if (ct.Link != "")
            {  
               filePath = ct.Link;
            }

            if (ct.VideoName != "")
            {
                if (tontai)
                {
                    fileName = ct.VideoName;
                    txbVideoName.Text = fileName;
                }
                else
                {
                    txbVideoName.Text = "Video không tồn tại theo đường dẫn đã lưu";
                }
            }
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Mp4 files (*.mp4) |*.mp4";
            openFileDialog1.Multiselect = false;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog1.FileName;
                fileName = openFileDialog1.SafeFileName;
                txbVideoName.Text = fileName;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(txbVideoName.Text == "")
            {
                filePath = "";
                fileName = "";
            }
            ChiTietMonAnBUS.Instance.UpdateChiTiet(idmon, txbChiTiet.Text, filePath, fileName);
            this.Close();
        }
    }
}
