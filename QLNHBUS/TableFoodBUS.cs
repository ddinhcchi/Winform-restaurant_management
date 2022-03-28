using QLNHDAL;
using QLNHDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLNHBUS
{
    public class TableFoodBUS
    {
        //singleton pattern (khởi tạo duy nhất)
        private static TableFoodBUS instance;

        public static TableFoodBUS Instance
        {
            get { if (instance == null) instance = new TableFoodBUS(); return instance; }
            private set => instance = value;
        }

        private TableFoodBUS() { }

        //Lấy toàn bộ bàn
        public List<TableFood> LoadTable(string area)
        {
            switch (area) {
                case "Tầng trệt":
                    area = "TA001";
                    break;
                case "Lầu 1":
                    area = "TA002";
                    break;
                case "Lầu 2":
                    area = "TA003";
                    break;
            }
            try
            {
                return TableFoodDAL.Instance.LoadTable(area);
            }
            catch
            {
                return new List<TableFood>();
            }
        }

        //Lấy toàn bộ bàn còn trống
        public List<TableFood> LoadTableTrong(string area)
        {
            switch (area)
            {
                case "Tầng trệt":
                    area = "TA001";
                    break;
                case "Lầu 1":
                    area = "TA002";
                    break;
                case "Lầu 2":
                    area = "TA003";
                    break;
            }
            try
            {
                return TableFoodDAL.Instance.LoadTableTrong(area);
            }
            catch
            {
                return new List<TableFood>();
            }
        }

        //Lấy toàn bộ bàn có người
        public List<TableFood> LoadTableCoNguoi(string area, string idTable)
        {
            switch (area)
            {
                case "Tầng trệt":
                    area = "TA001";
                    break;
                case "Lầu 1":
                    area = "TA002";
                    break;
                case "Lầu 2":
                    area = "TA003";
                    break;
            }
            try
            {
                return TableFoodDAL.Instance.LoadTableCoNguoi(area, idTable);
            }
            catch
            {
                return new List<TableFood>();
            }
        }

        //Cập nhật trạng thái của bàn
        public void UpdateStat(TableFood tf)
        {
            if (tf.Stat == "Trống")
            {
                tf.Stat = "Có người";
            }
            else
            {
                tf.Stat = "Trống";
            }
            switch (tf.Area)
            {
                case "Tầng trệt":
                    tf.Area = "TA001";
                    break;
                case "Lầu 1":
                    tf.Area = "TA002";
                    break;
                case "Lầu 2":
                    tf.Area = "TA003";
                    break;
            }
            try
            {
                TableFoodDAL.Instance.UpdateStat(tf);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        //Xóa bàn
        public void DeleteTable(TableFood tf)
        {
            try
            {
                TableFoodDAL.Instance.DeleteTable(tf);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        //Lấy id bàn lớn nhất
        public string GetIdMax()
        {
            try
            {
                return TableFoodDAL.Instance.GetIdMax();
            }
            catch
            {
                return "TF000";
            }
        }

        //Thêm bàn
        public void InsertTable(string name, string area)
        {
            try
            {
                string id = GetIdMax();
                string so = id[2].ToString() + id[3].ToString() + id[4].ToString();
                int tmp = Convert.ToInt32(so);
                tmp++;
                if (tmp < 100)
                {
                    if (tmp < 10)
                    {
                        so = "00" + tmp.ToString();
                    }
                    else
                    {
                        so = "0" + tmp.ToString();
                    }
                }
                id = "TF" + so;
                switch (area)
                {
                    case "Tầng trệt":
                        area = "TA001";
                        break;
                    case "Lầu 1":
                        area = "TA002";
                        break;
                    case "Lầu 2":
                        area = "TA003";
                        break;
                }
                TableFoodDAL.Instance.InsertTable(id, name, area);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
