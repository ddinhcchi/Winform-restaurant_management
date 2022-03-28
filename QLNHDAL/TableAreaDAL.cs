using QLNHDTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNHDAL
{
    public class TableAreaDAL
    {
        //singleton pattern (khởi tạo duy nhất)
        private static TableAreaDAL instance;

        public static TableAreaDAL Instance
        {
            get { if (instance == null) instance = new TableAreaDAL(); return instance; }
            private set => instance = value;
        }

        private TableAreaDAL() { }

        public List<TableArea> LayDsKhuVuc()
        {
            List<TableArea> dsKhuVuc = new List<TableArea>();
            DataTable dtKhuVuc = DataProvider.Instance.ExecuteQuery("SELECT * FROM TableArea");
            foreach (DataRow r in dtKhuVuc.Rows)
            {
                TableArea ta = new TableArea
                {
                    Id = r["Id"].ToString(),
                    Name = r["Name"].ToString()
                };
                dsKhuVuc.Add(ta);
            }
            return dsKhuVuc;
        }
    }
}
