using QLNH3Layer.Forms;
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

namespace QLNH3LayerClone.Forms
{
    public partial class FormBanAn : Form
    {
        public FormBanAn()
        {
            InitializeComponent();
        }
        //lưu tổng tiền hóa đơn theo bàn đã chọn
        float total = 0;
        TableFood tb = null;

        private void FormBanAn_Load(object sender, EventArgs e)
        {
            LoadTheme();

            //Load combobox khu vực
            LoadTableArea();

            //Load combobox loại món
            LoadFoodCategory();

            //Load danh sách bàn
            LoadTable(cbArea.SelectedItem.ToString());

            //Set chieu rong cho cac cot trong hoa don
            this.lvBill.SizeChanged += new EventHandler(ListView_SizeChanged);
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

        //Load combobox loại món
        private void LoadFoodCategory()
        {
            cbLoai.Items.Clear();
            cbLoai.Items.Add("(None)");
            List<FoodCategory> lstfoodCategories = FoodCategoryBUS.Instance.LayDsLoaiMon();
            foreach(FoodCategory fc in lstfoodCategories)
            {
                cbLoai.Items.Add(fc.Name);
            }
            cbLoai.SelectedIndex = 0;
        }

        //Load combobox khu vuc
        private void LoadTableArea()
        {
            cbArea.Items.Clear();
            cbArea.Items.Add("(None)");
            List<TableArea> lsttableAreas = TableAreaBUS.Instance.LayDsKhuVuc();
            foreach(TableArea ta in lsttableAreas)
            {
                cbArea.Items.Add(ta.Name);
            }
            cbArea.SelectedIndex = 0;
        }

        //Load combobox món ăn
        private void LoadMonAn(string idloaimon)
        {
            cbFood.Items.Clear();
            List<QLNHDTO.Menu> lstmenus = new List<QLNHDTO.Menu>();
            if (idloaimon == "(None)")
            {
                lstmenus = MenuBUS.Instance.LayDanhSachMon();
            }
            else
            {
                lstmenus = MenuBUS.Instance.LayDanhSachMonTheoLoaiMon(idloaimon);
            }

            foreach (QLNHDTO.Menu mn in lstmenus)
            {
                cbFood.Items.Add(mn.Tên_món);
            }
            cbFood.SelectedIndex = 0;
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
                    foreach (Control panel in pnl.Controls)
                    {
                        if (panel.GetType() == typeof(Panel))
                        {
                            Panel pn = (Panel)panel;

                            foreach (Control btns in pn.Controls)
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
            //đổi màu label Thông tin
            lbltable.ForeColor = ThemeColor.SecondaryColor;
        }

        //Load table lên flow layout panel
        private void LoadTable(string area)
        {
            flpTable.Controls.Clear();
            List<TableFood> lsttable = TableFoodBUS.Instance.LoadTable(area);

            foreach (TableFood item in lsttable)
            {
                Button btn = new Button() { Width = 75, Height = 75 };
                if (cbArea.SelectedItem.ToString() == "(None)")
                {
                    btn.Text = "Bàn " + item.Name + "\n" + item.Stat + "\n" + item.Area;
                }
                else
                {
                    btn.Text = "Bàn " + item.Name + "\n" + item.Stat;
                }
                btn.Click += Btn_Click;
                btn.Tag = item.Id;

                if (item.Stat == "Có người")
                {
                    btn.BackColor = Color.Red;
                }
                flpTable.Controls.Add(btn);
            }
        }

        //show hóa đơn của bàn khi nhấn vào
        private void Btn_Click(object sender, EventArgs e)
        {
            string tbid = (sender as Button).Tag as string;
            List<TableFood> tf = TableFoodBUS.Instance.LoadTable("(None)");
            foreach(TableFood t in tf)
            {
                if (tbid == t.Id)
                {
                    tb = t;
                    break;
                }
            }
            string tableid = tb.Id;
            string tablename = tb.Name;
            lbltable.Text = "Bàn " + tablename;
            ShowBill(tableid);
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

            //xuất theo mệnh giá tiền Việt
            CultureInfo culture = new CultureInfo("vi-VN");
            
            txbTotal.Text = total.ToString("c", culture);
        }

        //load lại flow layout mỗi khi nhấn chọn khu vực
        private void cbArea_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbArea.SelectedIndex!=-1)
            {
                LoadTable(cbArea.SelectedItem.ToString());
            }
        }

        //load lại danh sách món ăn mỗi lần thay đổi loại món
        private void cbLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            string idfoodcategory = "(None)";
            List<FoodCategory> lstfoodCategories = FoodCategoryBUS.Instance.LayDsLoaiMon();
            foreach (FoodCategory fc in lstfoodCategories)
            {
                if (fc.Name == cbLoai.SelectedItem.ToString())
                {
                    idfoodcategory = fc.Id;
                    break;
                }
            }

            LoadMonAn(idfoodcategory);
        }

        //them mon vao bill
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (tb != null)
            {
                try
                {
                    int idBill = BillBUS.Instance.GetUncheckBillByTableID(tb.Id);
                    string foodid = "";
                    List<QLNHDTO.Menu> lstmenus = MenuBUS.Instance.LayDanhSachMon();
                    foreach (QLNHDTO.Menu mn in lstmenus)
                    {
                        if (mn.Tên_món == cbFood.SelectedItem.ToString())
                        {
                            foodid = mn.Id;
                            break;
                        }
                    }
                    int count = (int)nmud.Value;
                    int idbillmoi = BillBUS.Instance.GetBillMax() + 1;
                    int idbillinfo = BillInfoBUS.Instance.GetBillMax() + 1;

                    if (idBill == -1)
                    {
                        BillBUS.Instance.InsertBill(idbillmoi, tb.Id);
                        BillInfoBUS.Instance.InsertBillInfo(idbillinfo, idbillmoi, foodid, count);
                        tb.Stat = "Trống";
                        TableFoodBUS.Instance.UpdateStat(tb);
                        LoadTable(cbArea.SelectedItem.ToString());
                    }
                    else
                    {
                        BillInfoBUS.Instance.InsertBillInfo(idbillinfo, idBill, foodid, count);
                    }

                    ShowBill(tb.Id);
                }
                catch
                {
                    MessageBox.Show("Chọn món muốn thêm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        //bot hoac xoa mon an 
        private void btnMinus_Click(object sender, EventArgs e)
        {
            if (tb != null)
            {
                try{
                    int idBill = BillBUS.Instance.GetUncheckBillByTableID(tb.Id);
                    string foodid = "";
                    List<QLNHDTO.Menu> lstmenus = MenuBUS.Instance.LayDanhSachMon();
                    foreach (QLNHDTO.Menu mn in lstmenus)
                    {
                        if (mn.Tên_món == cbFood.SelectedItem.ToString())
                        {
                            foodid = mn.Id;
                            break;
                        }
                    }
                    int count = -(int)nmud.Value;
                    int idbillmoi = BillBUS.Instance.GetBillMax() + 1;
                    int idbillinfo = BillInfoBUS.Instance.GetBillMax() + 1;

                    if (idBill != -1)
                    {
                        BillInfoBUS.Instance.InsertBillInfo(idbillinfo, idBill, foodid, count);
                        int tmp = BillInfoBUS.Instance.GetListBillInFoByBillId(idBill).Count();
                        if (tmp == 0)
                        {
                            tb.Stat = "Có người";
                            TableFoodBUS.Instance.UpdateStat(tb);
                            BillBUS.Instance.DeleteBill(idBill);
                            LoadTable(cbArea.SelectedItem.ToString());
                        }
                    }

                    ShowBill(tb.Id);
                }
                catch
                {
                    MessageBox.Show("Chọn món muốn bớt", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        //chon mon an muon them,bot hoac xoa
        private void lvBill_MouseClick(object sender, MouseEventArgs e)
        {
            if (lvBill.SelectedItems.Count > 0)
            {
                cbLoai.SelectedIndex = 0;
                string tenmon = lvBill.SelectedItems[0].SubItems[0].Text;
                foreach (string ten in cbFood.Items)
                {
                    if (ten==tenmon)
                    {
                        cbFood.SelectedIndex = cbFood.Items.IndexOf(ten);
                    }
                }
            }
        }

        //thanh toan
        private void btnPay_Click(object sender, EventArgs e)
        {
            if (tb != null)
            {
                int idBill = BillBUS.Instance.GetUncheckBillByTableID(tb.Id);
                if (idBill != -1)
                {
                    FormPay f = new FormPay(tb);
                    f.ShowDialog();
                    LoadTable(cbArea.SelectedItem.ToString());
                    ShowBill(tb.Id);
                }
            }
        }

        private void btnChuyen_Click(object sender, EventArgs e)
        {
            if (tb != null)
            {
                int idBill = BillBUS.Instance.GetUncheckBillByTableID(tb.Id);
                List<TableFood> li = TableFoodBUS.Instance.LoadTableTrong("(None)");
                if (li.Count > 0)
                {
                    if (idBill != -1)
                    {
                        FormChuyenBan f = new FormChuyenBan(tb);
                        f.ShowDialog();
                        ShowBill(tb.Id);
                        LoadTable(cbArea.SelectedItem.ToString());
                    }
                }
                else
                {
                    MessageBox.Show("Không có bàn nào trống để chuyển cả", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnGopBan_Click(object sender, EventArgs e)
        {
            if (tb != null)
            {
                int idBill = BillBUS.Instance.GetUncheckBillByTableID(tb.Id);
                List<TableFood> li = TableFoodBUS.Instance.LoadTableCoNguoi("(None)", tb.Id);
                if (li.Count > 0)
                {
                    if (idBill != -1)
                    {
                        FormGopBan f = new FormGopBan(tb);
                        f.ShowDialog();
                        if (f.tbgop != null)
                        {
                            tb = f.tbgop;
                            ShowBill(f.tbgop.Id);
                            lbltable.Text = "Bàn " + f.tbgop.Name;
                            LoadTable(cbArea.SelectedItem.ToString());
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Không có bàn nào để gộp cả", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnUpdateTable_Click(object sender, EventArgs e)
        {
            FormUpdateTable f = new FormUpdateTable();
            f.ShowDialog();
            LoadTable(cbArea.SelectedItem.ToString());
        }
    }
}
