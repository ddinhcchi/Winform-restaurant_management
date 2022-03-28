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
    public partial class FormGopBan : Form
    {
        public FormGopBan()
        {
            InitializeComponent();
        }

        private TableFood tb = new TableFood();
        public TableFood tbgop = null;

        public FormGopBan(TableFood tt) : this()
        {
            tb = tt;
            lblChiTiet.Text = "Gộp bàn " + tb.Name + " với bàn ?";

            LoadTableArea();

            LoadTable(cbArea.SelectedItem.ToString());
        }

        //Load combobox khu vuc
        private void LoadTableArea()
        {
            cbArea.Items.Clear();
            cbArea.Items.Add("(None)");
            List<TableArea> lsttableAreas = TableAreaBUS.Instance.LayDsKhuVuc();
            foreach (TableArea ta in lsttableAreas)
            {
                cbArea.Items.Add(ta.Name);
            }
            cbArea.SelectedIndex = 0;
        }

        //Load table lên flow layout panel
        private void LoadTable(string area)
        {
            flpTable.Controls.Clear();
            List<TableFood> lsttable = TableFoodBUS.Instance.LoadTableCoNguoi(area,tb.Id);

            foreach (TableFood item in lsttable)
            {
                Button btn = new Button() { Width = 75, Height = 75 };
                btn.Text = "Bàn " + item.Name + "\n" + item.Stat;
                btn.Click += Btn_Click;
                btn.Tag = item;

                if (item.Stat == "Có người")
                {
                    btn.BackColor = Color.Red;
                }
                flpTable.Controls.Add(btn);
            }
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            tbgop = (sender as Button).Tag as TableFood;
            string tenban = tbgop.Name;
            lblChiTiet.Text = "Gộp bàn " + tb.Name + " với bàn " + tenban;
        }

        private void btnDo_Click(object sender, EventArgs e)
        {
            if (tbgop != null)
            {
                int idbillBanGop = BillBUS.Instance.GetUncheckBillByTableID(tb.Id);
                int idbillBiGop = BillBUS.Instance.GetUncheckBillByTableID(tbgop.Id);
                //lấy danh sách billinfo từ bàn muốn gộp (bàn truyền vào)
                List<BillInfo> billInfos = BillInfoBUS.Instance.GetListBillInFoByBillId(idbillBanGop);
                //lấy danh sách billinfo từ bàn bị gộp (bàn được nhấn trong form)
                List<BillInfo> lstbillInfos = BillInfoBUS.Instance.GetListBillInFoByBillId(idbillBiGop);

                foreach (BillInfo bi in billInfos)
                {
                    int idbillinfomax = BillInfoBUS.Instance.GetBillMax() + 1;
                    BillInfoBUS.Instance.InsertBillInfo(idbillinfomax, idbillBiGop, bi.IdFood, bi.Count);
                }
                BillInfoBUS.Instance.DeleteAllBillInfo(idbillBanGop);
                BillBUS.Instance.DeleteBill(idbillBanGop);
                tb.Stat = "Có người";
                TableFoodBUS.Instance.UpdateStat(tb);
                this.Close();
            }
            else
            {
                MessageBox.Show("Chưa chọn bàn để gộp", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadTable(cbArea.SelectedItem.ToString());
        }
    }
}
