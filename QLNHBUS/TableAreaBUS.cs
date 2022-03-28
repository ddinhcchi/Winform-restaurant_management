using QLNHDAL;
using QLNHDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNHBUS
{
    public class TableAreaBUS
    {
        //singleton pattern (khởi tạo duy nhất)
        private static TableAreaBUS instance;

        public static TableAreaBUS Instance
        {
            get { if (instance == null) instance = new TableAreaBUS(); return instance; }
            private set => instance = value;
        }

        private TableAreaBUS() { }

        //Lấy danh sách loại món
        public List<TableArea> LayDsKhuVuc()
        {
            try
            {
                return TableAreaDAL.Instance.LayDsKhuVuc();
            }
            catch
            {
                return new List<TableArea>();
            }
        }
    }
}
