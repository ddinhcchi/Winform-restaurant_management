using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using QLNHDTO;
using System.Data.SqlClient;

namespace QLNHDAL
{
    public class BillDAL
    {
        //singleton pattern (khởi tạo duy nhất)
        private static BillDAL instance;

        public static BillDAL Instance
        {
            get { if (instance == null) instance = new BillDAL(); return instance; }
            private set => instance = value;
        }

        private BillDAL() { }

        public int GetUncheckBillByTableID(string id)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM Bill WHERE IdTable = '" + id + "' AND Stat = 0");

            if (data.Rows.Count > 0)
            {
                DataRow r = data.Rows[0];
                Bill bill = new Bill
                {
                    Id = (int)r["Id"],
                    DateCheckIn = (DateTime)r["DateCheckIn"],
                    IdTable = r["IdTable"].ToString(),
                    Stat = (int)r["Stat"]
                };
                var dateCheckOut = r["DateCheckOut"];
                if (dateCheckOut.ToString() != "")
                    bill.DateCheckOut = (DateTime?)r["DateCheckOut"];
                return bill.Id;
            }

            return -1;
        }

        public void InsertBill(int id, string idTable)
        {
            DataProvider.Instance.ExecuteNonQuery("exec USP_InsertBill @id , @idTable", new object[] { id , idTable });
        }

        public void DeleteBill(int id)
        {
            string sql = "DELETE FROM Bill WHERE Id=@id";
            SqlParameter[] pa = new SqlParameter[1];
            pa[0] = new SqlParameter("id", id);
            DataProvider.Instance.ExcuteNonQuery(sql, CommandType.Text, pa);
        }

        public int GetBillMax()
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("SELECT MAX(Id) FROM [Bill]");
            }
            catch
            {
                return 0;
            }
        }

        public void Payment(int idbill, float totalbill, string discount)
        {
            string sql = "UPDATE dbo.Bill SET Stat = 1, Payment = " + totalbill.ToString() + ", DateCheckOut = GETDATE(), Discount = '"+discount+"' WHERE Id = " + idbill.ToString();
            DataProvider.Instance.ExecuteNonQuery(sql);
        }

        public void ChuyenBan(int idbill, string idtable)
        {
            string sql = "UPDATE dbo.Bill SET IdTable = '" + idtable + "' WHERE Id = " + idbill.ToString();
            DataProvider.Instance.ExecuteNonQuery(sql);
        }

        public DataTable LayCacNam()
        {
            DataTable dt = DataProvider.Instance.ExecuteQuery("Select distinct Datepart(year, DateCheckIn) as Nam from Bill where stat = 1");
            return dt;
        }

        public double LayTongTienTheoNam(int nam)
        {
            DataTable dt = DataProvider.Instance.ExecuteQuery("Select sum(payment) as doanh_thu from Bill where Datepart(year, DateCheckIn) = " + nam);
            double kq = dt.Rows[0].Field<double>("doanh_thu");
            return kq;
        }

        public double LayTongTienTheoQuy(int nam, int quy)
        {
            DataTable dt = DataProvider.Instance.ExecuteQuery("Select sum(payment) as doanh_thu from Bill where Datepart(year, DateCheckIn) = " + nam + "and Datepart(QUARTER, DateCheckIn) = " + quy);
            DataRow r = dt.Rows[0];
            object value = r["doanh_thu"];
            double kq = 0;
            if (value != DBNull.Value)
            {
                kq = Convert.ToDouble(value);
            }
            return kq;
        }

        public double LayTongTienTheoThang(int nam, int thang)
        {
            DataTable dt = DataProvider.Instance.ExecuteQuery("Select sum(payment) as doanh_thu from Bill where Datepart(year, DateCheckIn) = " + nam + " and Datepart(month, DateCheckIn) = " + thang);
            DataRow r = dt.Rows[0];
            object value = r["doanh_thu"];
            double kq = 0;
            if (value != DBNull.Value)
            {
                kq = Convert.ToDouble(value);
            }
            return kq;
        }

        public double LayTongTienTheoNgay(int nam, int thang, int ngay)
        {
            DataTable dt = DataProvider.Instance.ExecuteQuery("Select sum(payment) as doanh_thu from Bill where Datepart(year, DateCheckIn) = " + nam + " and Datepart(month, DateCheckIn) = " + thang + " and Datepart(Day, DateCheckIn) = " + ngay);
            DataRow r = dt.Rows[0];
            object value = r["doanh_thu"];
            double kq = 0;
            if (value != DBNull.Value)
            {
                kq = Convert.ToDouble(value);
            }
            return kq;
        }

        public double LayTongTienTheoCa(int nam, int thang, int ngay, int ca)
        {
            string sql = "";
            if (ca == 1)
            {
                sql = "Select sum(payment) as doanh_thu from Bill where Datepart(year, DateCheckIn) = " + nam + " and Datepart(month, DateCheckIn) = " + thang + " and Datepart(Day, DateCheckIn) = " + ngay + " and Datepart(hour, DateCheckIn) >= 6 and Datepart(hour, DateCheckIn) < 14";
            }
            else if (ca == 2)
            {
                sql = "Select sum(payment) as doanh_thu from Bill where Datepart(year, DateCheckIn) = " + nam + " and Datepart(month, DateCheckIn) = " + thang + " and Datepart(Day, DateCheckIn) = " + ngay + " and Datepart(hour, DateCheckIn) >= 14 and Datepart(hour, DateCheckIn) <= 23";
            }
            DataTable dt = DataProvider.Instance.ExecuteQuery(sql);
            DataRow r = dt.Rows[0];
            object value = r["doanh_thu"];
            double kq = 0;
            if (value != DBNull.Value)
            {
                kq = Convert.ToDouble(value);
            }
            return kq;
        }

        public DataTable LayDoanhThuTheoBill(int nam, int thang, int ngay, int ca)
        {
            string sql = "";
            if (ca == 1)
            {
                sql = "Select Id, CONVERT(char(5), DateCheckIn, 108) as [Giờ vào], CONVERT(char(5), DateCheckOut, 108) as [Giờ ra], payment as [Tổng tiền] from Bill where Datepart(year, DateCheckIn) = " + nam + " and Datepart(month, DateCheckIn) = " + thang + " and Datepart(Day, DateCheckIn) = " + ngay + " and Datepart(hour, DateCheckIn) >= 6 and Datepart(hour, DateCheckIn) < 14 and stat = 1";
            }
            else if (ca == 2)
            {
                sql = "Select Id, CONVERT(char(5), DateCheckIn, 108) as [Giờ vào], CONVERT(char(5), DateCheckOut, 108) as [Giờ ra], payment as [Tổng tiền] from Bill where Datepart(year, DateCheckIn) = " + nam + " and Datepart(month, DateCheckIn) = " + thang + " and Datepart(Day, DateCheckIn) = " + ngay + " and Datepart(hour, DateCheckIn) >= 14 and Datepart(hour, DateCheckIn) <= 23 and stat = 1";
            }
            DataTable dt = DataProvider.Instance.ExecuteQuery(sql);
            return dt;
        }

        public string GetDisCount(int idbill)
        {
            DataTable dt = DataProvider.Instance.ExecuteQuery("Select Discount From [Bill] where Id = " + idbill.ToString());
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                object value = row["Discount"];
                if (value != DBNull.Value)
                {
                    return value.ToString();
                }
            }
            return "";
        }

        public string GetTableName(int idbill)
        {
            DataTable dt = DataProvider.Instance.ExecuteQuery("Select tf.Name as Name, ta.Name as Area From [Bill] as bi, [TableFood] as tf, [TableArea] as ta where bi.Id = " + idbill.ToString() + " and tf.Id = bi.IdTable and ta.Id = tf.Area");
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                object value = row["Name"];
                string ketqua = "";
                if (value != DBNull.Value)
                {
                    ketqua = value.ToString();
                }
                value = row["Area"];
                if (value != DBNull.Value)
                {
                    ketqua += " " + value.ToString();
                }
                return ketqua;
            }
            return "";
        }
    }
}
