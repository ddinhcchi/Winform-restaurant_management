using QLNHBUS;
using QLNHDTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLNH3Layer.Forms
{
    public partial class FormChuyenBan : Form
    {
        public FormChuyenBan()
        {
            InitializeComponent();
        }

        float total = 0;
        float totalbichuyen = 0;
        CultureInfo culture = new CultureInfo("vi-VN");

        public FormChuyenBan(TableFood tb) : this()
        {
            ShowBill(tb.Id);
            //xuất theo mệnh giá tiền Việt
            
            lblBanChuyen.Text = "Bàn " + tb.Name + "-" + tb.Area + ":" + total.ToString("c", culture);

            //Load combobox khu vực
            LoadTableArea();

            //Load danh sách bàn
            LoadTable(cbArea.SelectedItem.ToString());

            //lưu table lại
            lvBill.Tag = tb;
        }

        //show hóa đơn của bàn
        private void ShowBill(string tableid)
        {
            lvBill.Items.Clear();
            total = 0;
            //gọi hàm BUS
            List<TotalBill> billInfos = TotalBillBUS.Instance.GetTotalBills(tableid);

            //xuất theo định dạng details
            foreach (TotalBill bi in billInfos)
            {
                total += bi.TotalPrice;
                ListViewItem lsvItem = new ListViewItem(bi.FoodName.ToString());
                lsvItem.SubItems.Add(bi.Count.ToString());
                lsvItem.SubItems.Add(bi.Price.ToString());
                lsvItem.SubItems.Add(bi.TotalPrice.ToString());
                lvBill.Items.Add(lsvItem);
            }

            //căn chiều rộng cột tên món
            if (billInfos.Count > 0)
            {
                this.lvBill.SizeChanged += new EventHandler(ListView_SizeChanged);
            }
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
            List<TableFood> lsttable = TableFoodBUS.Instance.LoadTableTrong(area);

            foreach (TableFood item in lsttable)
            {
                Button btn = new Button() { Width = 50, Height = 50 };
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
            TableFood tf = (sender as Button).Tag as TableFood;
            lvBillbichuyen.Tag = (sender as Button).Tag as TableFood;
            lblBanBiChuyen.Text = "Bàn " + tf.Name + "-" + tf.Area + ":" + totalbichuyen.ToString("c", culture);
        }

        private void cbArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbArea.SelectedIndex != -1)
            {
                LoadTable(cbArea.SelectedItem.ToString());
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnright1_Click(object sender, EventArgs e)
        {
            TableFood tf = lvBillbichuyen.Tag as TableFood;
            TableFood tt = lvBill.Tag as TableFood;
            int soluong = 0;
            if (tf != null)
            {
                if (int.TryParse(txbSoLuong.Text, out soluong) && soluong > 0)
                {
                    if (lvBill.SelectedItems.Count > 0)
                    {
                        int tmp = lvBill.SelectedItems.Count;
                        while (tmp > 0)
                        {
                            ListViewItem item = lvBill.SelectedItems[0];
                            ListViewItem items = new ListViewItem(item.Text);
                            int con = Convert.ToInt32(item.SubItems[1].Text) - soluong;
                            float so = Convert.ToInt32(item.SubItems[1].Text) - con;
                            float gia = Convert.ToInt32(item.SubItems[2].Text);
                            bool cosan = false;

                            if (con <= 0)
                            {
                                if (lvBillbichuyen.Items.Count > 0)
                                {
                                    foreach (ListViewItem it in lvBillbichuyen.Items)
                                    {
                                        if (it.Text == item.Text)
                                        {
                                            float soluongcosan = Convert.ToInt32(it.SubItems[1].Text);
                                            it.SubItems[1].Text = (soluongcosan + so).ToString();
                                            it.SubItems[3].Text = ((soluongcosan + so) * gia).ToString();
                                            lvBill.Items.Remove(lvBill.SelectedItems[0]);
                                            cosan = true;
                                            break;
                                        }
                                    }
                                }

                                if (!cosan)
                                {
                                    items.SubItems.Add(item.SubItems[1].Text);
                                    items.SubItems.Add(item.SubItems[2].Text);
                                    items.SubItems.Add(item.SubItems[3].Text);
                                    lvBillbichuyen.Items.Add(items);
                                    lvBill.Items.Remove(lvBill.SelectedItems[0]);
                                }
                            }
                            else if (con > 0)
                            {
                                if (lvBillbichuyen.Items.Count > 0)
                                {
                                    foreach (ListViewItem it in lvBillbichuyen.Items)
                                    {
                                        if (it.Text == item.Text)
                                        {
                                            float soluongcosan = Convert.ToInt32(it.SubItems[1].Text);
                                            it.SubItems[1].Text = (soluongcosan + so).ToString();
                                            it.SubItems[3].Text = ((soluongcosan + so) * gia).ToString();
                                            lvBill.SelectedItems[0].SubItems[1].Text = con.ToString();
                                            lvBill.SelectedItems[0].SubItems[3].Text = (con * gia).ToString();
                                            cosan = true;
                                            break;
                                        }
                                    }
                                }

                                if (!cosan)
                                {
                                    items.SubItems.Add(so.ToString());
                                    items.SubItems.Add(item.SubItems[2].Text);
                                    items.SubItems.Add((so * gia).ToString());
                                    lvBillbichuyen.Items.Add(items);
                                    lvBill.SelectedItems[0].SubItems[1].Text = con.ToString();
                                    lvBill.SelectedItems[0].SubItems[3].Text = (con * gia).ToString();
                                }
                            }
                            totalbichuyen += so * gia;
                            total -= so * gia;
                            tmp--;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Số lượng không hợp lệ!!!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                lblBanBiChuyen.Text = "Bàn " + tf.Name + "-" + tf.Area + ":" + totalbichuyen.ToString("c", culture);
                lblBanChuyen.Text = "Bàn " + tt.Name + "-" + tt.Area + ":" + total.ToString("c", culture);
            }
            else
            {
                MessageBox.Show("Chưa chọn bàn để chuyển!!!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            TableFood tf = lvBillbichuyen.Tag as TableFood;
            if (tf != null)
            {
                totalbichuyen = 0;
                lblBanBiChuyen.Text = "Bàn " + tf.Name + "-" + tf.Area + ":" + totalbichuyen.ToString("c", culture);
                lvBillbichuyen.Items.Clear();
                TableFood tt = lvBill.Tag as TableFood;
                ShowBill(tt.Id);
                lblBanChuyen.Text = "Bàn " + tt.Name + "-" + tt.Area + ":" + total.ToString("c", culture);
            }
        }

        private void btnDo_Click(object sender, EventArgs e)
        {
            TableFood tbchuyen = lvBill.Tag as TableFood;
            TableFood tbbichuyen = lvBillbichuyen.Tag as TableFood;
            if (tbbichuyen != null)
            {
                if (lvBillbichuyen.Items.Count > 0)
                {
                    if (lvBill.Items.Count == 0)
                    {
                        ChuyenBan(tbchuyen, tbbichuyen);
                    }
                    else
                    {
                        TachBan(tbchuyen, tbbichuyen);
                    }
                }
                else
                {
                    ChuyenBan(tbchuyen, tbbichuyen);
                }
            }
            else
            {
                MessageBox.Show("Chưa chọn bàn để chuyển!!!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void ChuyenBan(TableFood tbchuyen, TableFood tbbichuyen)
        {
            int idbill = BillBUS.Instance.GetUncheckBillByTableID(tbchuyen.Id);
            if (idbill != -1)
            {
                BillBUS.Instance.ChuyenBan(idbill, tbbichuyen.Id);
                TableFoodBUS.Instance.UpdateStat(tbchuyen);
                TableFoodBUS.Instance.UpdateStat(tbbichuyen);
                MessageBox.Show("Chuyển thành công từ bàn " + tbchuyen.Name + " sang bàn " + tbbichuyen.Name);
                this.Close();
            }

        }

        private void TachBan(TableFood tbchuyen, TableFood tbbichuyen)
        {
            int idbillmax = BillBUS.Instance.GetBillMax() + 1;
            int idbillcu = BillBUS.Instance.GetUncheckBillByTableID(tbchuyen.Id);
            BillBUS.Instance.InsertBill(idbillmax, tbbichuyen.Id);
            BillInfoBUS.Instance.DeleteAllBillInfo(idbillcu);
            List<QLNHDTO.Menu> lstmenus = new List<QLNHDTO.Menu>();
            lstmenus = MenuBUS.Instance.LayDanhSachMon();
            int soluongchuyen = lvBill.Items.Count;
            int demchuyen = 0;
            while (demchuyen!=soluongchuyen)
            {
                foreach(QLNHDTO.Menu mn in lstmenus)
                {
                    if (lvBill.Items[demchuyen].Text == mn.Tên_món)
                    {
                        int idbillinfo = BillInfoBUS.Instance.GetBillMax() + 1;
                        int count = Convert.ToInt32(lvBill.Items[demchuyen].SubItems[1].Text);
                        BillInfoBUS.Instance.InsertBillInfo(idbillinfo, idbillcu, mn.Id, count);
                        demchuyen++;
                        break;
                    }
                }
            }

            int soluong = lvBillbichuyen.Items.Count;
            int dem = 0;

            while (dem != soluong)
            {
                foreach (QLNHDTO.Menu mn in lstmenus)
                {
                    if (lvBillbichuyen.Items[dem].Text == mn.Tên_món)
                    {
                        int idbillinfo = BillInfoBUS.Instance.GetBillMax() + 1;
                        int count = Convert.ToInt32(lvBillbichuyen.Items[dem].SubItems[1].Text);
                        BillInfoBUS.Instance.InsertBillInfo(idbillinfo, idbillmax, mn.Id, count);
                        dem++;
                        break;
                    }
                }
            }
            if (dem == soluong && demchuyen == soluongchuyen)
            {
                TableFoodBUS.Instance.UpdateStat(tbbichuyen);
                MessageBox.Show("Tách thành công từ bàn " + tbchuyen.Name + " sang bàn " + tbbichuyen.Name);
                this.Close();
            }


        }
    }
}
