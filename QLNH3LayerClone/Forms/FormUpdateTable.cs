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
    public partial class FormUpdateTable : Form
    {
        public FormUpdateTable()
        {
            InitializeComponent();
        }

        private void FormUpdateTable_Load(object sender, EventArgs e)
        {
            //Set chieu rong cho cac cot trong hoa don
            this.lvTable.SizeChanged += new EventHandler(ListView_SizeChanged);
            Loadlv();
            LoadTableArea();
        }

        private bool Resizing = false;

        private void ListView_SizeChanged(object sender, EventArgs e)
        {
            // Don't allow overlapping of SizeChanged calls
            if (!Resizing)
            {
                // Set the resizing flag
                Resizing = true;

                ListView listView = sender as ListView;
                if (listView != null)
                {
                    float totalColumnWidth = 0;

                    // Get the sum of all column tags
                    for (int i = 0; i < listView.Columns.Count; i++)
                        totalColumnWidth += Convert.ToInt32(listView.Columns[i].Tag);

                    // Calculate the percentage of space each column should 
                    // occupy in reference to the other columns and then set the 
                    // width of the column to that percentage of the visible space.
                    for (int i = 0; i < listView.Columns.Count; i++)
                    {
                        float colPercentage = (Convert.ToInt32(listView.Columns[i].Tag) / totalColumnWidth);
                        listView.Columns[i].Width = (int)(colPercentage * listView.ClientRectangle.Width);
                    }
                }
            }

            // Clear the resizing flag
            Resizing = false;
        }

        //load ds bàn
        private void Loadlv()
        {
            lvTable.Items.Clear();
            List<TableFood> lsttable = TableFoodBUS.Instance.LoadTable("(None)");

            foreach (TableFood item in lsttable)
            {
                ListViewItem lv = new ListViewItem(item.Name);
                lv.SubItems.Add(item.Area);
                lvTable.Items.Add(lv);
            }
        }

        //Load combobox khu vuc
        private void LoadTableArea()
        {
            cbArea.Items.Clear();
            List<TableArea> lsttableAreas = TableAreaBUS.Instance.LayDsKhuVuc();
            foreach (TableArea ta in lsttableAreas)
            {
                cbArea.Items.Add(ta.Name);
            }
            cbArea.SelectedIndex = 0;
        }

        private void lvTable_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lvTable.SelectedItems.Count > 0)
            {
                string tenban = lvTable.SelectedItems[0].Text;
                string khuvuc = lvTable.SelectedItems[0].SubItems[1].Text;
                FormDoiTenBan f = new FormDoiTenBan(tenban, khuvuc);
                f.ShowDialog();
                if (f.newtablename != "")
                {
                    List<TableFood> lsttable = TableFoodBUS.Instance.LoadTable("(None)");
                    foreach (TableFood item in lsttable)
                    {
                        if (item.Name == tenban && item.Area == khuvuc)
                        {
                            item.Name = f.newtablename;
                            item.Stat = "Có người";
                            TableFoodBUS.Instance.UpdateStat(item);
                            Loadlv();
                            break;
                        }
                    }
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDeleteTable_Click(object sender, EventArgs e)
        {
            if (lvTable.SelectedItems.Count > 0)
            {
                string tenban = lvTable.SelectedItems[0].Text;
                string khuvuc = lvTable.SelectedItems[0].SubItems[1].Text;
                List<TableFood> lsttable = TableFoodBUS.Instance.LoadTable("(None)");
                foreach (TableFood item in lsttable)
                {
                    if (item.Name == tenban && item.Area == khuvuc && item.Stat == "Trống")
                    {
                        TableFoodBUS.Instance.DeleteTable(item);
                        Loadlv();
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("Chọn bàn bạn muốn xóa");
            }
        }

        private void btnAddTable_Click(object sender, EventArgs e)
        {
            if(txbTableName.Text != "" && cbArea.SelectedIndex != -1)
            {
                bool tontai = false;
                string tenmoi = txbTableName.Text;
                string khuvuc = cbArea.SelectedItem.ToString();
                List<TableFood> lsttable = TableFoodBUS.Instance.LoadTable("(None)");
                foreach (TableFood item in lsttable)
                {
                    if (item.Area == khuvuc)
                    {
                        if(item.Name == tenmoi)
                        {
                            tontai = true;
                            MessageBox.Show("Trong cùng 1 khu vực không được đặt trùng tên bàn");
                            break;
                        }
                    }
                }

                if (!tontai)
                {
                    TableFoodBUS.Instance.InsertTable(tenmoi, khuvuc);
                    Loadlv();
                }
            }
            else
            {
                MessageBox.Show("Điền tên bàn muốn thêm");
            }
        }
    }
}
