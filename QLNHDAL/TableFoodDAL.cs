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
    public class TableFoodDAL
    {
        //singleton pattern (khởi tạo duy nhất)
        private static TableFoodDAL instance;

        public static TableFoodDAL Instance
        {
            get { if (instance == null) instance = new TableFoodDAL(); return instance; }
            private set => instance = value;
        }

        private TableFoodDAL() { }

        public List<TableFood> LoadTable(string area)
        {
            List<TableFood> listtable = new List<TableFood>();

            DataTable data = new DataTable();
            if (area == "(None)")
            {
                data = DataProvider.Instance.ExecuteQuery("SELECT * FROM TableFood ORDER BY Area, Name");
            }
            else
            {
                data = DataProvider.Instance.ExecuteQuery("SELECT * FROM TableFood WHERE Area = '" + area + "' ORDER BY Area, Name");
            }

            foreach (DataRow r in data.Rows)
            {
                TableFood tb = new TableFood
                {
                    Id = r["Id"].ToString(),
                    Name = r["Name"].ToString(),
                    Stat = r["Stat"].ToString(),
                };
                switch (r["Area"].ToString())
                {
                    case "TA001":
                        tb.Area = "Tầng trệt";
                        break;
                    case "TA002":
                        tb.Area = "Lầu 1";
                        break;
                    case "TA003":
                        tb.Area = "Lầu 2";
                        break;
                }
                listtable.Add(tb);
            }

            return listtable;
        }

        public List<TableFood> LoadTableTrong(string area)
        {
            List<TableFood> listtable = new List<TableFood>();

            DataTable data = new DataTable();
            if (area == "(None)")
            {
                data = DataProvider.Instance.ExecuteQuery("SELECT * FROM TableFood WHERE Stat = N'Trống'");
            }
            else
            {
                data = DataProvider.Instance.ExecuteQuery("SELECT * FROM TableFood WHERE Area = '" + area + "' AND Stat = N'Trống'");
            }

            foreach (DataRow r in data.Rows)
            {
                TableFood tb = new TableFood
                {
                    Id = r["Id"].ToString(),
                    Name = r["Name"].ToString(),
                    Stat = r["Stat"].ToString(),
                };
                switch (r["Area"].ToString())
                {
                    case "TA001":
                        tb.Area = "Tầng trệt";
                        break;
                    case "TA002":
                        tb.Area = "Lầu 1";
                        break;
                    case "TA003":
                        tb.Area = "Lầu 2";
                        break;
                }
                listtable.Add(tb);
            }

            return listtable;
        }

        public List<TableFood> LoadTableCoNguoi(string area, string idTable)
        {
            List<TableFood> listtable = new List<TableFood>();

            DataTable data = new DataTable();
            if (area == "(None)")
            {
                data = DataProvider.Instance.ExecuteQuery("SELECT * FROM TableFood WHERE Stat = N'Có người' And Id != '"+idTable+"'");
            }
            else
            {
                data = DataProvider.Instance.ExecuteQuery("SELECT * FROM TableFood WHERE Area = '" + area + "' AND Stat = N'Có người' And Id != '" + idTable + "'");
            }

            foreach (DataRow r in data.Rows)
            {
                TableFood tb = new TableFood
                {
                    Id = r["Id"].ToString(),
                    Name = r["Name"].ToString(),
                    Stat = r["Stat"].ToString(),
                };
                switch (r["Area"].ToString())
                {
                    case "TA001":
                        tb.Area = "Tầng trệt";
                        break;
                    case "TA002":
                        tb.Area = "Lầu 1";
                        break;
                    case "TA003":
                        tb.Area = "Lầu 2";
                        break;
                }
                listtable.Add(tb);
            }

            return listtable;
        }

        public void UpdateStat(TableFood tf)
        {
            string sql = "UPDATE TableFood SET Name=@name, Stat=@stat, Area=@area WHERE Id=@id";
            SqlParameter[] pa = new SqlParameter[4];
            pa[0] = new SqlParameter("id", tf.Id);
            pa[1] = new SqlParameter("name", tf.Name);
            pa[2] = new SqlParameter("stat", tf.Stat);
            pa[3] = new SqlParameter("area", tf.Area);
            DataProvider.Instance.ExcuteNonQuery(sql, CommandType.Text, pa);
        }

        public void DeleteTable(TableFood tf)
        {
            string sql = "DELETE TableFood WHERE Id= '" + tf.Id + "'";
            DataProvider.Instance.ExecuteNonQuery(sql);
        }

        public string GetIdMax()
        {
            string sql = "select Id from TableFood where Id=(Select max(id) from tablefood)";
            DataTable dt = DataProvider.Instance.ExecuteQuery(sql);
            string kq = "TF001";
            if (dt.Rows.Count > 0)
            {
                kq = dt.Rows[0].Field<string>(0);
            }
            return kq;
        }

        public void InsertTable(string idtable, string name, string area)
        {
            string sql = "INSERT INTO TableFood(Id, Name, Stat, Area) VALUES(@id, @name, @stat, @area)";
            SqlParameter[] pa = new SqlParameter[4];
            pa[0] = new SqlParameter("id", idtable);
            pa[1] = new SqlParameter("name", name);
            pa[2] = new SqlParameter("stat", "Trống");
            pa[3] = new SqlParameter("area", area);
            DataProvider.Instance.ExcuteNonQuery(sql, CommandType.Text, pa);
        }
    }
}
