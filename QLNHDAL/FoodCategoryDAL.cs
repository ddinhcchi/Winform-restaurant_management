using QLNHDTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNHDAL
{
    public class FoodCategoryDAL
    {
        //singleton pattern (khởi tạo duy nhất)
        private static FoodCategoryDAL instance;

        public static FoodCategoryDAL Instance
        {
            get { if (instance == null) instance = new FoodCategoryDAL(); return instance; }
            private set => instance = value;
        }

        private FoodCategoryDAL() { }

        public List<FoodCategory> LayDsLoaiMon()
        {
            List<FoodCategory> dsLoaiMon = new List<FoodCategory>();
            DataTable dtLoaiMon = DataProvider.Instance.ExecuteQuery("SELECT * FROM FoodCategory");
            foreach (DataRow r in dtLoaiMon.Rows)
            {
                FoodCategory fc = new FoodCategory
                {
                    Id = r["Id"].ToString(),
                    Name = r["Name"].ToString()
                };
                dsLoaiMon.Add(fc);
            }
            return dsLoaiMon;
        }
    }
}
