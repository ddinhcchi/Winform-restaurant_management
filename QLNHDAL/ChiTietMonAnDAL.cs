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
    public class ChiTietMonAnDAL
    {
        //singleton pattern (khởi tạo duy nhất)
        private static ChiTietMonAnDAL instance;

        public static ChiTietMonAnDAL Instance
        {
            get { if (instance == null) instance = new ChiTietMonAnDAL(); return instance; }
            private set => instance = value;
        }

        private ChiTietMonAnDAL() { }

        public ChiTietMonAn LoadChiTiet(string id)
        {
            DataTable tb = DataProvider.Instance.ExecuteQuery("select Name, Detail, Link, VideoName from Menu Where Id = '"+id+"'");
            DataRow r = tb.Rows[0];
            ChiTietMonAn ct = new ChiTietMonAn();
            if (r != null)
            {
                ct.Id = id;
                ct.Name = r["Name"].ToString();
                ct.Detail = r["Detail"].ToString();
                ct.Link = r["Link"].ToString();
                ct.VideoName = r["VideoName"].ToString();
            }
            return ct;
        }

        public void UpdateChiTiet(string id, string chitiet, string duongdan, string tenvideo)
        {
            string sql = "UPDATE Menu SET Detail=@chitiet, Link=@duongdan, VideoName=@tenvideo WHERE Id=@MaMon";
            SqlParameter[] pa = new SqlParameter[4];
            pa[0] = new SqlParameter("MaMon", id);
            pa[1] = new SqlParameter("chitiet", chitiet);
            pa[2] = new SqlParameter("duongdan", duongdan);
            pa[3] = new SqlParameter("tenvideo", tenvideo);
            DataProvider.Instance.ExcuteNonQuery(sql, CommandType.Text, pa);
        }
    }
}
