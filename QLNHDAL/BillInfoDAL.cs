using QLNHDTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNHDAL
{
    public class BillInfoDAL
    {
        //singleton pattern (khởi tạo duy nhất)
        private static BillInfoDAL instance;

        public static BillInfoDAL Instance
        {
            get { if (instance == null) instance = new BillInfoDAL(); return instance; }
            private set => instance = value;
        }

        private BillInfoDAL() { }

        public List<BillInfo> GetListBillInFoByBillId(int id)
        {
            List<BillInfo> lst = new List<BillInfo>();
            DataTable tb = DataProvider.Instance.ExecuteQuery("SELECT * FROM BillInfo WHERE IdBill = " + id);
            foreach (DataRow r in tb.Rows)
            {
                BillInfo bi = new BillInfo
                {
                    Id = (int)r["Id"],
                    IdBill = (int)r["IdBill"],
                    IdFood = r["IdFood"].ToString(),
                    Count = (int)r["Count"]
                };
                lst.Add(bi);
            }
            return lst;
        }

        public int GetBillMax()
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("SELECT MAX(Id) FROM [BillInfo]");
            }
            catch
            {
                return 0;
            }
        }

        public void InsertBillInfo(int id, int idBill, string idFood, int count)
        {
            const string Query = "exec USP_InsertBillInfo @id , @idBill , @idFood , @count";
            DataProvider.Instance.ExecuteNonQuery(Query, new object[] { id , idBill , idFood , count });
        }

        public void DeleteAllBillInfo(int idBill)
        {
            string sql = "DELETE FROM BillInfo WHERE IdBill=@id";
            SqlParameter[] pa = new SqlParameter[1];
            pa[0] = new SqlParameter("id", idBill);
            DataProvider.Instance.ExcuteNonQuery(sql, CommandType.Text, pa);
        }

        public void UpdateBillInfo(int idBill, string idFood, float price)
        {
            string sql = "UPDATE dbo.BillInfo SET Price = " + price.ToString() + " WHERE IdBill = " + idBill.ToString() + " AND IdFood = '" + idFood + "'";
            DataProvider.Instance.ExecuteNonQuery(sql);
        }

        public void TachBan(int idBillcu, string idFood, int idBillmoi)
        {
            string sql = "UPDATE dbo.BillInfo SET IdBill = "+idBillmoi.ToString()+" WHERE IdBill = "+idBillcu.ToString()+" AND IdFood = '"+idFood+"'";
            DataProvider.Instance.ExecuteNonQuery(sql);
        }
    }
}
