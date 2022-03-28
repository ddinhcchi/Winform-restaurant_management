using QLNHDAL;
using QLNHDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNHBUS
{
    public class FoodCategoryBUS
    {
        //singleton pattern (khởi tạo duy nhất)
        private static FoodCategoryBUS instance;

        public static FoodCategoryBUS Instance
        {
            get { if (instance == null) instance = new FoodCategoryBUS(); return instance; }
            private set => instance = value;
        }

        private FoodCategoryBUS() { }

        //Lấy danh sách loại món
        public List<FoodCategory> LayDsLoaiMon()
        {
            try
            {
                return FoodCategoryDAL.Instance.LayDsLoaiMon();
            }
            catch
            {
                List<FoodCategory> categories = new List<FoodCategory>();
                return categories;
            }
        }
    }
}
