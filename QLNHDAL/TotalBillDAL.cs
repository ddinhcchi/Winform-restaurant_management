using QLNHDTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNHDAL
{
    public class TotalBillDAL
    {
        //singleton pattern (khởi tạo duy nhất)
        private static TotalBillDAL instance;

        public static TotalBillDAL Instance
        {
            get { if (instance == null) instance = new TotalBillDAL(); return instance; }
            private set => instance = value;
        }

        private TotalBillDAL() { }

        //truy vấn hóa đơn
        public List<TotalBill> GetTotalBills(string tableid)
        {
            List<TotalBill> totals = new List<TotalBill>();
            //truy vấn tên món, số lượng, giá, và tổng tiền từ 3 bảng billinfo, bill và menu
            string query = "SELECT m.Id, m.Name, bi.Count, m.Price, m.Price*bi.Count as TotalPrice FROM [BillInfo] AS bi, [Bill] AS b, [Menu] as m WHERE bi.IdBill = b.id AND bi.IdFood = m.Id AND b.IdTable = '" + tableid + "' AND b.Stat = 0";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow r in dt.Rows)
            {
                TotalBill tb = new TotalBill
                {
                    FoodName = r["Name"].ToString(),
                    Count = (int)r["Count"],
                    Price = (float)Convert.ToDouble(r["Price"].ToString()),
                    TotalPrice = (float)Convert.ToDouble(r["TotalPrice"].ToString()),
                    IdFood = r["Id"].ToString()
                };
                totals.Add(tb);
            }
            return totals;
        }

        public List<TotalBill> GetTotalBillDetails(int idBill)
        {
            List<TotalBill> totals = new List<TotalBill>();
            //truy vấn tên món, số lượng, giá, và tổng tiền từ 3 bảng billinfo, bill và menu
            string query = "SELECT m.Id, m.Name, bi.Count, bi.Price, bi.Price*bi.Count as TotalPrice FROM [BillInfo] AS bi, [Bill] AS b, [Menu] as m WHERE bi.IdBill = " + idBill+" AND bi.IdFood = m.Id AND b.Id = " + idBill + " AND b.Stat = 1";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            string sql = "SELECT bi.Count, bi.Price, bi.Price*bi.Count as TotalPrice FROM [BillInfo] AS bi, [Bill] AS b WHERE bi.IdBill = " + idBill + " AND b.Stat = 1 AND b.Id = " + idBill;
            DataTable dts = DataProvider.Instance.ExecuteQuery(sql);

            if (dts.Rows.Count > dt.Rows.Count)
            {
                foreach(DataRow r in dts.Rows)
                {
                    DataRow row = dt.NewRow();
                    row["ID"] = "";
                    row["Name"] = "Deleted";
                    row["Count"] = r["Count"];
                    row["Price"] = r["Price"];
                    row["TotalPrice"] = r["TotalPrice"];

                    dt.Rows.InsertAt(row, dt.Rows.Count);
                }
            }
            foreach (DataRow r in dt.Rows)
            {
                TotalBill tb = new TotalBill
                {
                    FoodName = r["Name"].ToString(),
                    Count = (int)r["Count"],
                    Price = (float)Convert.ToDouble(r["Price"].ToString()),
                    TotalPrice = (float)Convert.ToDouble(r["TotalPrice"].ToString()),
                    IdFood = r["Id"].ToString()
                };
                totals.Add(tb);
            }
            return totals;
        }
    }
}
