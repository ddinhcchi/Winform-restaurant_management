using QLNHBUS;
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
    public partial class FormDoanhThu : Form
    {
        public FormDoanhThu()
        {
            InitializeComponent();
        }
        //Doanh thu
        double doanhthu = 0;

        //trang thai cua datagridview
        string trangthai = "";

        //nam doanh thu dang xem
        int nam = 0;

        //quy doanh thu dang xem
        int quy = 0;

        //thang doanh thu dang xem
        int thang = 0;

        //ngay doanh thu dang xem
        int ngay = 0;

        //ca doanh thu dang xem
        int ca = 0;

        //bill dang xem
        int bill = 0;

        //xuất theo mệnh giá tiền Việt
        CultureInfo culture = new CultureInfo("vi-VN");
        private void FormDoanhThu_Load(object sender, EventArgs e)
        {
            LoadDtgvTheoNam();
            dtgvBill.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            checkboxAll.Checked = true;
        }

        private void LoadDtgvTheoNam()
        {
            doanhthu = 0;
            DataTable dt = BillBUS.Instance.DoanhThuTheoNam();
            foreach (DataRow r in dt.Rows)
            {
                doanhthu += Convert.ToDouble(r["Doanh thu"].ToString());
            }
            trangthai = "nam";
            dtgvBill.DataSource = dt;
            txbDoanhThu.Text = doanhthu.ToString("c", culture);
        }

        private void LoadDtgvTheoQuy()
        {
            trangthai = "quy";
            DataTable dt = BillBUS.Instance.DoanhThuTheoQuy(nam);
            List<DataRow> todelete = new List<DataRow>();
            foreach (DataRow r in dt.Rows)
            {
                double tmp = Convert.ToDouble(r["Doanh thu"].ToString());
                if (tmp == 0 && !checkboxAll.Checked)
                {
                    todelete.Add(r);
                }
                doanhthu += tmp;
            }
            foreach(DataRow r in todelete)
            {
                dt.Rows.Remove(r);
            }
            txbDoanhThu.Text = doanhthu.ToString("c", culture);
            dtgvBill.DataSource = dt;
        }

        private void LoadDtgvTheoThang()
        {
            trangthai = "thang";
            DataTable dt = BillBUS.Instance.DoanhThuTheoThang(nam,quy);
            List<DataRow> todelete = new List<DataRow>();
            foreach (DataRow r in dt.Rows)
            {
                double tmp = Convert.ToDouble(r["Doanh thu"].ToString());
                if (tmp == 0 && !checkboxAll.Checked)
                {
                    todelete.Add(r);
                }
                doanhthu += tmp;
            }
            foreach (DataRow r in todelete)
            {
                dt.Rows.Remove(r);
            }
            txbDoanhThu.Text = doanhthu.ToString("c", culture);
            dtgvBill.DataSource = dt;
        }

        private void LoadDtgvTheoNgay()
        {
            trangthai = "ngay";
            DataTable dt = BillBUS.Instance.DoanhThuTheoNgay(nam,thang);
            List<DataRow> todelete = new List<DataRow>();
            foreach (DataRow r in dt.Rows)
            {
                double tmp = Convert.ToDouble(r["Doanh thu"].ToString());
                if (tmp == 0 && !checkboxAll.Checked)
                {
                    todelete.Add(r);
                }
                doanhthu += tmp;
            }
            foreach (DataRow r in todelete)
            {
                dt.Rows.Remove(r);
            }
            txbDoanhThu.Text = doanhthu.ToString("c", culture);
            dtgvBill.DataSource = dt;
        }

        private void LoadDtgvTheoCa()
        {
            trangthai = "ca";
            DataTable dt = BillBUS.Instance.DoanhThuTheoCa(nam, thang, ngay);
            List<DataRow> todelete = new List<DataRow>();
            foreach (DataRow r in dt.Rows)
            {
                double tmp = Convert.ToDouble(r["Doanh thu"].ToString());
                if (tmp == 0 && !checkboxAll.Checked)
                {
                    todelete.Add(r);
                }
                doanhthu += tmp;
            }
            foreach (DataRow r in todelete)
            {
                dt.Rows.Remove(r);
            }
            txbDoanhThu.Text = doanhthu.ToString("c", culture);
            dtgvBill.DataSource = dt;
        }

        private void LoadDtgvTheoBill()
        {
            trangthai = "bill";
            DataTable dt = BillBUS.Instance.LayDoanhThuTheoBill(nam, thang, ngay, ca);
            List<DataRow> todelete = new List<DataRow>();
            foreach (DataRow r in dt.Rows)
            {
                double tmp = Convert.ToDouble(r["Tổng tiền"].ToString());
                if (tmp == 0 && !checkboxAll.Checked)
                {
                    todelete.Add(r);
                }
                doanhthu += tmp;
            }
            foreach (DataRow r in todelete)
            {
                dt.Rows.Remove(r);
            }
            txbDoanhThu.Text = doanhthu.ToString("c", culture);
            dtgvBill.DataSource = dt;
        }

        private void dtgvBill_DoubleClick(object sender, EventArgs e)
        {
            doanhthu = 0;
            if (dtgvBill.SelectedRows.Count > 0)
            {
                if (trangthai == "nam")
                {
                    string tmp = dtgvBill.SelectedRows[0].Cells["Nam"].Value.ToString();
                    nam = Convert.ToInt32(tmp);
                    lblTrangThai.Text = "Năm " + nam.ToString();
                    LoadDtgvTheoQuy();
                }
                else if (trangthai == "quy")
                {
                    string tmp = dtgvBill.SelectedRows[0].Cells["Quý"].Value.ToString();
                    quy = Convert.ToInt32(tmp[4]) - 48;
                    lblTrangThai.Text = "Năm " + nam.ToString() + " Quý " + quy.ToString();
                    LoadDtgvTheoThang();
                }
                else if (trangthai == "thang")
                {
                    string tmp = dtgvBill.SelectedRows[0].Cells["Tháng"].Value.ToString();
                    if (tmp.Length > 7)
                    {
                        thang = int.Parse(tmp[6].ToString() + tmp[7].ToString());
                    }
                    else
                    {
                        thang = int.Parse(tmp[6].ToString());
                    }
                    lblTrangThai.Text = "Năm " + nam.ToString() + " Quý " + quy.ToString() + " tháng " + thang.ToString();
                    LoadDtgvTheoNgay();
                }
                else if (trangthai == "ngay")
                {
                    string tmp = dtgvBill.SelectedRows[0].Cells["Ngày"].Value.ToString();
                    if (tmp.Length > 6)
                    {
                        ngay = int.Parse(tmp[5].ToString() + tmp[6].ToString());
                    }
                    else
                    {
                        ngay = int.Parse(tmp[5].ToString());
                    }
                    lblTrangThai.Text = "Năm " + nam.ToString() + " Quý " + quy.ToString() + " tháng " + thang.ToString() + " ngày " + ngay.ToString();
                    LoadDtgvTheoCa();
                }
                else if (trangthai == "ca")
                {
                    string tmp = dtgvBill.SelectedRows[0].Cells["Ca"].Value.ToString();
                    if (tmp == "Ca sáng")
                    {
                        ca = 1;
                    }
                    else if (tmp == "Ca chiều")
                    {
                        ca = 2;
                    }
                    lblTrangThai.Text = "Năm " + nam.ToString() + " Quý " + quy.ToString() + " tháng " + thang.ToString() + " ngày " + ngay.ToString() + " " + tmp;
                    LoadDtgvTheoBill();
                }
                else if (trangthai == "bill")
                {
                    string tmp = dtgvBill.SelectedRows[0].Cells["Id"].Value.ToString();
                    bill = Int32.Parse(tmp);
                    string time = lblTrangThai.Text + dtgvBill.SelectedRows[0].Cells["Giờ ra"].Value.ToString(); ; 
                    QLNH3Layer.Forms.FormChiTietBill f = new QLNH3Layer.Forms.FormChiTietBill(bill, time);
                    f.ShowDialog();
                }
            }
        }

        private void btnTurnBack_Click(object sender, EventArgs e)
        {
            doanhthu = 0;
            if (trangthai == "bill")
            {
                lblTrangThai.Text = "Năm " + nam.ToString() + " Quý " + quy.ToString() + " tháng " + thang.ToString() + " ngày " + ngay.ToString();
                LoadDtgvTheoCa();
            }
            else if (trangthai == "ca")
            {
                lblTrangThai.Text = "Năm " + nam.ToString() + " Quý " + quy.ToString() + " tháng " + thang.ToString();
                LoadDtgvTheoNgay();
            }
            else if (trangthai == "ngay")
            {
                lblTrangThai.Text = "Năm " + nam.ToString() + " Quý " + quy.ToString();
                LoadDtgvTheoThang();
            }
            else if (trangthai == "thang")
            {
                lblTrangThai.Text = "Năm " + nam.ToString();
                LoadDtgvTheoQuy();
            }
            else if (trangthai == "quy")
            {
                lblTrangThai.Text = "Tất cả";
                LoadDtgvTheoNam();
            }
        }

        private void checkboxAll_CheckedChanged(object sender, EventArgs e)
        {
            doanhthu = 0;
            if (trangthai == "bill")
            {
                LoadDtgvTheoBill();
            }
            else if (trangthai == "ca")
            {
                LoadDtgvTheoCa();
            }
            else if (trangthai == "ngay")
            {
                LoadDtgvTheoNgay();
            }
            else if (trangthai == "thang")
            {
                LoadDtgvTheoThang();
            }
            else if (trangthai == "quy")
            {
                LoadDtgvTheoQuy();
            }
            else if (trangthai == "nam")
            {
                LoadDtgvTheoNam();
            }
        }

        //hàm xuất file excel
        private void ToExcel(DataGridView dataGridView1, string fileName)
        {
            //khai báo thư viện hỗ trợ Microsoft.Office.Interop.Excel
            Microsoft.Office.Interop.Excel.Application excel;
            Microsoft.Office.Interop.Excel.Workbook workbook;
            Microsoft.Office.Interop.Excel.Worksheet worksheet;
            try
            {
                //Tạo đối tượng COM.
                excel = new Microsoft.Office.Interop.Excel.Application();
                excel.Visible = false;
                excel.DisplayAlerts = false;
                //tạo mới một Workbooks bằng phương thức add()
                workbook = excel.Workbooks.Add(Type.Missing);
                worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets["Sheet1"];
                //đặt tên cho sheet
                worksheet.Name = lblTrangThai.Text;

                // export header trong DataGridView
                for (int i = 0; i < dataGridView1.ColumnCount; i++)
                {
                    worksheet.Cells[1, i + 1] = dataGridView1.Columns[i].HeaderText;
                }
                // export nội dung trong DataGridView
                for (int i = 0; i < dataGridView1.RowCount-1; i++)
                {
                    for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                    }
                }
                //Xuất tổng
                worksheet.Cells[dataGridView1.RowCount + 1, dataGridView1.ColumnCount-1] = "Tổng";
                worksheet.Cells[dataGridView1.RowCount + 1, dataGridView1.ColumnCount] = txbDoanhThu.Text;
                // sử dụng phương thức SaveAs() để lưu workbook với filename
                workbook.SaveAs(fileName);
                //đóng workbook
                workbook.Close();
                excel.Quit();
                MessageBox.Show("Xuất dữ liệu ra Excel thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                workbook = null;
                worksheet = null;
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //gọi hàm ToExcel() với tham số là dtgDSHS và filename từ SaveFileDialog
                ToExcel(dtgvBill, saveFileDialog1.FileName);
            }
        }
    }
}
