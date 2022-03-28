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
    public partial class FormChiTietBill : Form
    {
        public FormChiTietBill()
        {
            InitializeComponent();
        }
        float total = 0;
        public FormChiTietBill(int IdBill, string time) : this()
        {
            lblIdBill.Text = "Bill số " + IdBill.ToString();
            List<TotalBill> totalBills = TotalBillBUS.Instance.GetTotalBillDetails(IdBill);
            //xuất theo định dạng details
            foreach (TotalBill bi in totalBills)
            {
                total += bi.TotalPrice;
                ListViewItem lsvItem = new ListViewItem(bi.FoodName.ToString());
                lsvItem.SubItems.Add(bi.Count.ToString());
                lsvItem.SubItems.Add(bi.Price.ToString());
                lsvItem.SubItems.Add(bi.TotalPrice.ToString());
                lsvBill.Items.Add(lsvItem);
            }

            //Set chieu rong cho cac cot trong hoa don
            this.lsvBill.SizeChanged += new EventHandler(ListView_SizeChanged);
            lblDate.Text = time;
            string tenban = BillBUS.Instance.GetTableName(IdBill);
            if (tenban == "")
            {
                lblBan.Text = "Bàn đã bị xóa";
            }
            else
            {
                lblBan.Text = "Bàn " + tenban;
            }
            txbGiamGia.Text = BillBUS.Instance.GetDisCount(IdBill);
            txbTotal.Text = total.ToString();
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

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
