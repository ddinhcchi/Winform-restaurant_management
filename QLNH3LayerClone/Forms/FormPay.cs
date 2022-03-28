using QLNHBUS;
using QLNHDTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLNH3Layer.Forms
{
    public partial class FormPay : Form
    {
        public FormPay()
        {
            InitializeComponent();
        }
        PrintDialog prnDialog = new PrintDialog();
        PrintPreviewDialog prnPreview = new PrintPreviewDialog();
        System.Drawing.Printing.PrintDocument prnDocument = new System.Drawing.Printing.PrintDocument();

        // the Event of 'PrintPage'
        //.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(prnDocument_PrintPage);

        private TableFood tb = new TableFood();
        private float total = 0;
        private float totalfinal = 0;
        private bool hople = false;
        //xuất theo mệnh giá tiền Việt
        CultureInfo culture = new CultureInfo("vi-VN");

        public FormPay(TableFood _tb) : this()
        {
            tb = _tb;
            lblBan.Text = "Bàn " + tb.Name;
            ShowBill();
            cbDonVi.SelectedIndex = 0;
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
        List<TotalBill> billInfos = new List<TotalBill>();
        //show hóa đơn của bàn
        private void ShowBill()
        {
            lsvBill.Items.Clear();
            //gọi hàm BUS
            billInfos = TotalBillBUS.Instance.GetTotalBills(tb.Id);

            //xuất theo định dạng details
            foreach (TotalBill bi in billInfos)
            {
                total += bi.TotalPrice;
                ListViewItem lsvItem = new ListViewItem(bi.FoodName.ToString());
                lsvItem.SubItems.Add(bi.Count.ToString());
                lsvItem.SubItems.Add(bi.Price.ToString());
                lsvItem.SubItems.Add(bi.TotalPrice.ToString());
                lsvBill.Items.Add(lsvItem);
            }
            //lưu tổng tiền vào giá thanh toán cuối cùng
            totalfinal = total;

            //Set chieu rong cho cac cot trong hoa don
            this.lsvBill.SizeChanged += new EventHandler(ListView_SizeChanged);

            txbTamTinh.Text = total.ToString("c", culture);
            txbTotal.Text = total.ToString("c", culture);
        }

        private void txbGiamGia_TextChanged(object sender, EventArgs e)
        {
            float giamgiaphantram = 0;
            float giamgiatienmat = 0;
            lblError.Visible = false;
            total = totalfinal;
            hople = false;
            if (cbDonVi.SelectedIndex >= 0 && txbGiamGia.Text != "")
            {
                if (cbDonVi.SelectedIndex == 0)
                {
                    if(float.TryParse(txbGiamGia.Text, out giamgiaphantram))
                    {
                        if(giamgiaphantram>0 && giamgiaphantram<=100)
                        {
                            total = total - ((total * giamgiaphantram) / 100);
                            txbTotal.Text = total.ToString("c", culture);
                            hople = true;
                        }
                        else
                        {
                            total = totalfinal;
                            txbTotal.Text = total.ToString("c", culture);
                            lblError.Visible = true;
                            lblError.Text = "Giá trị không hợp lệ!!!";
                            
                        }
                    }
                    else
                    {
                        total = totalfinal;
                        txbTotal.Text = total.ToString("c", culture);
                        lblError.Visible = true;
                        lblError.Text = "Giá trị không hợp lệ!!!";
                    }
                }
                else if (cbDonVi.SelectedIndex == 1)
                {
                    if(float.TryParse(txbGiamGia.Text, out giamgiatienmat))
                    {
                        giamgiatienmat *= 1000;
                        if (giamgiatienmat <= totalfinal)
                        {
                            total -= giamgiatienmat;
                            txbTotal.Text = total.ToString("c", culture);
                            hople = true;
                        }
                        else
                        {
                            total = totalfinal;
                            txbTotal.Text = total.ToString("c", culture);
                            lblError.Visible = true;
                            lblError.Text = "Lỗi: Giá tiền giảm lớn hơn tổng hóa đơn!!!";
                        }
                    }
                    else
                    {
                        total = totalfinal;
                        txbTotal.Text = total.ToString("c", culture);
                        lblError.Visible = true;
                        lblError.Text = "Giá trị không hợp lệ!!!";
                    }
                }
            }

            if (txbGiamGia.Text == "")
            {
                hople = true;
                total = totalfinal;
                txbTotal.Text = total.ToString("c", culture);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            if (txbGiamGia.Text == "")
                hople = true;

            if(hople==true)
            {
                totalfinal = total;
                int idBill = BillBUS.Instance.GetUncheckBillByTableID(tb.Id);
                string giamgia = "";
                if (txbGiamGia.Text != "")
                {
                    giamgia = txbGiamGia.Text + " " + cbDonVi.SelectedItem.ToString();
                }
                BillBUS.Instance.Payment(idBill, totalfinal, giamgia);
                foreach(TotalBill ttb in billInfos)
                {
                    BillInfoBUS.Instance.UpdateBillInfo(idBill, ttb.IdFood, ttb.Price);
                }
                tb.Stat = "Có người";
                TableFoodBUS.Instance.UpdateStat(tb);
                printDocument1.Print();
                MessageBox.Show("Thanh toán thành công!!!", "Xin cảm ơn");
                this.Close();
            }
            else
            {
                MessageBox.Show("Dữ liệu giảm giá nhập vào không hợp lệ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbDonVi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDonVi.SelectedIndex >= 0)
            {
                float giamgiaphantram = 0;
                float giamgiatienmat = 0;
                lblError.Visible = false;
                total = totalfinal;
                hople = false;
                if (cbDonVi.SelectedIndex >= 0 && txbGiamGia.Text != "")
                {
                    if (cbDonVi.SelectedIndex == 0)
                    {
                        if (float.TryParse(txbGiamGia.Text, out giamgiaphantram))
                        {
                            if (giamgiaphantram > 0 && giamgiaphantram <= 100)
                            {
                                total = total - ((total * giamgiaphantram) / 100);
                                txbTotal.Text = total.ToString("c", culture);
                                hople = true;
                            }
                            else
                            {
                                total = totalfinal;
                                txbTotal.Text = total.ToString("c", culture);
                                lblError.Visible = true;
                                lblError.Text = "Giá trị không hợp lệ!!!";

                            }
                        }
                        else
                        {
                            total = totalfinal;
                            txbTotal.Text = total.ToString("c", culture);
                            lblError.Visible = true;
                            lblError.Text = "Giá trị không hợp lệ!!!";
                        }
                    }
                    else if (cbDonVi.SelectedIndex == 1)
                    {
                        if (float.TryParse(txbGiamGia.Text, out giamgiatienmat))
                        {
                            giamgiatienmat *= 1000;
                            if (giamgiatienmat <= totalfinal)
                            {
                                total -= giamgiatienmat;
                                txbTotal.Text = total.ToString("c", culture);
                                hople = true;
                            }
                            else
                            {
                                total = totalfinal;
                                txbTotal.Text = total.ToString("c", culture);
                                lblError.Visible = true;
                                lblError.Text = "Lỗi: Giá tiền giảm lớn hơn tổng hóa đơn!!!";
                            }
                        }
                        else
                        {
                            total = totalfinal;
                            txbTotal.Text = total.ToString("c", culture);
                            lblError.Visible = true;
                            lblError.Text = "Giá trị không hợp lệ!!!";
                        }
                    }
                }
            }
        }

        //in bill và lưu bill (Yêu cầu của vấn đáp cuối kỳ)
        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawString("NHÀ HÀNG MUỐI BIỂN", new Font("SVN-Aaron Script", 20, FontStyle.Regular), Brushes.Orange, new Point(200, 0));
            e.Graphics.DrawString("Số điện thoại: 113 | Địa chỉ: Trái đất", new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(300, 50));
            e.Graphics.DrawString("Ngày " + DateTime.Now, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(600, 120));
            e.Graphics.DrawString(lblBan.Text, new Font("SVN-Aaron Script", 18, FontStyle.Regular), Brushes.Black, new Point(400, 160));
            e.Graphics.DrawString("-----------------------------------------------------------------------------------------------------------------", new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(50, 200));
            e.Graphics.DrawString("Tên món", new Font("Arial", 14, FontStyle.Regular), Brushes.Blue, new Point(50, 230));
            e.Graphics.DrawString("Số lượng", new Font("Arial", 14, FontStyle.Regular), Brushes.Blue, new Point(370, 230));
            e.Graphics.DrawString("Giá", new Font("Arial", 14, FontStyle.Regular), Brushes.Blue, new Point(500, 230));
            e.Graphics.DrawString("Thành tiền", new Font("Arial", 14, FontStyle.Regular), Brushes.Blue, new Point(650, 230));
            e.Graphics.DrawString("-----------------------------------------------------------------------------------------------------------------", new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(50, 250));

            int yPos = 275;

            foreach (TotalBill tb in billInfos)
            {
                e.Graphics.DrawString(tb.FoodName, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(50, yPos));
                e.Graphics.DrawString(tb.Count.ToString(), new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(370, yPos));
                e.Graphics.DrawString(tb.Price.ToString(), new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(500, yPos));
                e.Graphics.DrawString(tb.TotalPrice.ToString(), new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(650, yPos));
                yPos += 30;
            }
            e.Graphics.DrawString("Tạm tính", new Font("Arial", 14, FontStyle.Regular), Brushes.DeepPink, new Point(600, yPos));
            e.Graphics.DrawString(txbTamTinh.Text, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(700, yPos));
            yPos += 30;
            e.Graphics.DrawString("Giảm giá: ", new Font("Arial", 14, FontStyle.Regular), Brushes.Blue, new Point(600, yPos));
            if (txbGiamGia.Text != "") {
                e.Graphics.DrawString(txbGiamGia.Text + " " + cbDonVi.SelectedItem.ToString(), new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(700, yPos));
            }
            else
            {
                e.Graphics.DrawString(txbGiamGia.Text, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(700, yPos));

            }
            yPos += 30;
            e.Graphics.DrawString("Tổng tiền: ", new Font("Arial", 14, FontStyle.Regular), Brushes.Red, new Point(600, yPos));
            e.Graphics.DrawString(txbTotal.Text, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(700, yPos));
            yPos += 30;
            e.Graphics.DrawString("XIN CHÂN THÀNH CẢM ƠN QUÝ KHÁCH", new Font("Arial", 14, FontStyle.Italic), Brushes.Black, new Point(230, yPos));
        }
    }
}
