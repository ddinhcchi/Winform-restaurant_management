using QLNHDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLNHBUS
{
    public class BillBUS
    {
        //singleton pattern (khởi tạo duy nhất)
        private static BillBUS instance;

        public static BillBUS Instance
        {
            get { if (instance == null) instance = new BillBUS(); return instance; }
            private set => instance = value;
        }

        private BillBUS() { }

        public int GetUncheckBillByTableID(string id)
        {
            return BillDAL.Instance.GetUncheckBillByTableID(id);
        }

        //Tạo bill
        public void InsertBill(int id, string idTable)
        {
            id = GetBillMax() + 1;
            try
            {
                BillDAL.Instance.InsertBill(id, idTable);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        //Xóa bill
        public void DeleteBill(int id)
        {
            try
            {
                BillDAL.Instance.DeleteBill(id);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        //Lấy id bill lớn nhất
        public int GetBillMax()
        {
            try
            {
                return BillDAL.Instance.GetBillMax();
            }
            catch
            {
                return 0;
            }
        }

        //Hàm thanh toán (lưu tổng tiền và giảm giá nếu có theo id bill)
        public void Payment(int idbill, float totalbill, string discount)
        {
            try
            {
                BillDAL.Instance.Payment(idbill, totalbill, discount);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        //Đổi idtable trong bill để chuyển bàn
        public void ChuyenBan(int idbill, string idtable)
        {
            try
            {
                BillDAL.Instance.ChuyenBan(idbill, idtable);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        //Lấy doanh thu theo các năm
        public DataTable DoanhThuTheoNam()
        {
            try
            {
                DataTable dt = BillDAL.Instance.LayCacNam();
                dt.Columns.Add("Doanh thu", typeof(double));
                foreach (DataRow r in dt.Rows)
                {
                    double doanhthu = BillDAL.Instance.LayTongTienTheoNam(Convert.ToInt32(r["Nam"].ToString()));
                    r["Doanh thu"] = doanhthu;
                }
                return dt;
            }
            catch
            {
                DataTable dt = new DataTable();
                return dt;
            }
        }

        //Lấy doanh thu theo từng quý trong năm đã chọn
        public DataTable DoanhThuTheoQuy(int nam)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Quý", typeof(string));
                dt.Columns.Add("Doanh thu", typeof(double));
                for (int i = 1; i <= 4; i++)
                {
                    double doanhthu = BillDAL.Instance.LayTongTienTheoQuy(nam, i);
                    DataRow r = dt.NewRow();
                    r["Quý"] = "Quý " + i.ToString();
                    r["Doanh thu"] = doanhthu;
                    dt.Rows.Add(r);
                }
                return dt;
            }
            catch
            {
                DataTable dt = new DataTable();
                return dt;
            }
        }

        //Lấy doanh thu theo từng tháng theo quý đã chọn
        public DataTable DoanhThuTheoThang(int nam, int quy)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Tháng", typeof(string));
                dt.Columns.Add("Doanh thu", typeof(double));
                int dau = 0;
                int cuoi = 0;
                switch (quy)
                {
                    case 1:
                        dau = 1;
                        cuoi = 3;
                        break;
                    case 2:
                        dau = 4;
                        cuoi = 6;
                        break;
                    case 3:
                        dau = 7;
                        cuoi = 9;
                        break;
                    case 4:
                        dau = 10;
                        cuoi = 12;
                        break;
                }
                for (int i = dau; i <= cuoi; i++)
                {
                    double doanhthu = BillDAL.Instance.LayTongTienTheoThang(nam, i);
                    DataRow r = dt.NewRow();
                    r["Tháng"] = "Tháng " + i.ToString();
                    r["Doanh thu"] = doanhthu;
                    dt.Rows.Add(r);
                }
                return dt;
            }
            catch
            {
                DataTable dt = new DataTable();
                return dt;
            }
        }

        //Lấy doanh thu từng ngày theo tháng đã chọn
        public DataTable DoanhThuTheoNgay(int nam, int thang)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Ngày", typeof(string));
                dt.Columns.Add("Doanh thu", typeof(double));
                int dau = 1;
                int cuoi = 0;
                if (thang == 1 || thang == 3 || thang == 5 || thang == 7 || thang == 8 || thang == 10 || thang == 12)
                {
                    cuoi = 31;
                }
                else if (thang == 4 || thang == 6 || thang == 9 || thang == 11)
                {
                    cuoi = 30;
                }
                else if (thang == 2 && nam % 400 == 0)
                {
                    cuoi = 29;
                }
                else if (thang == 2 && nam % 400 != 0)
                {
                    cuoi = 28;
                }

                for (int i = dau; i <= cuoi; i++)
                {
                    double doanhthu = BillDAL.Instance.LayTongTienTheoNgay(nam, thang, i);
                    DataRow r = dt.NewRow();
                    r["Ngày"] = "Ngày " + i.ToString();
                    r["Doanh thu"] = doanhthu;
                    dt.Rows.Add(r);
                }

                return dt;
            }
            catch
            {
                DataTable dt = new DataTable();
                return dt;
            }
        }

        //Lấy doanh thu từng ca theo ngày đã chọn
        public DataTable DoanhThuTheoCa(int nam, int thang, int ngay)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Ca", typeof(string));
                dt.Columns.Add("Doanh thu", typeof(double));

                for (int i = 1; i <= 2; i++)
                {
                    double doanhthu = BillDAL.Instance.LayTongTienTheoCa(nam, thang, ngay, i);
                    DataRow r = dt.NewRow();
                    if (i == 1)
                    {
                        r["Ca"] = "Ca sáng";
                    }
                    else
                    {
                        r["Ca"] = "Ca chiều";
                    }
                    r["Doanh thu"] = doanhthu;
                    dt.Rows.Add(r);
                }

                return dt;
            }
            catch
            {
                DataTable dt = new DataTable();
                return dt;
            }
        }

        //Lấy doanh thu từng bill
        public DataTable LayDoanhThuTheoBill(int nam, int thang, int ngay, int ca)
        {
            try
            {
                return BillDAL.Instance.LayDoanhThuTheoBill(nam, thang, ngay, ca);
            }
            catch
            {
                DataTable dt = new DataTable();
                return dt;
            }
        }

        //Lấy số tiền đã giảm của một bill đã thanh toán
        public string GetDisCount(int idbill)
        {
            try
            {
                return BillDAL.Instance.GetDisCount(idbill);
            }
            catch
            {
                return "";
            }
        }

        //Lấy tên bàn của bill đã thanh toán
        public string GetTableName(int idbill)
        {
            try
            {
                return BillDAL.Instance.GetTableName(idbill);
            }
            catch
            {
                return "";
            }
        }
    }
}
