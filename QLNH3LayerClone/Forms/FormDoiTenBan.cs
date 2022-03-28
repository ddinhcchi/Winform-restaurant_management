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
    public partial class FormDoiTenBan : Form
    {
        public FormDoiTenBan()
        {
            InitializeComponent();
        }
        public string newtablename = "";
        string area = "";

        public FormDoiTenBan(string tenban, string khuvuc) : this()
        {
            lblTableName.Text = "Đổi tên bàn '" + tenban + "' thành";
            area = khuvuc;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            bool kiemtratontai = true;
            if (txbTableName.Text != "")
            {
                List<TableFood> lsttable = TableFoodBUS.Instance.LoadTable("(None)");
                foreach(TableFood tb in lsttable)
                {
                    if (txbTableName.Text == tb.Name && area == tb.Area)
                    {
                        kiemtratontai = false;
                        break;
                    }
                }

                if(kiemtratontai)
                {
                    newtablename = txbTableName.Text;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Trong cùng một khu vực không được đặt trùng tên bàn");
                }
                
            }
            else
            {
                MessageBox.Show("Vui lòng nhập tên bàn");
            }
        }
    }
}
