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
    public class BillInfoBUS
    {
        //singleton pattern (khởi tạo duy nhất)
        private static BillInfoBUS instance;

        public static BillInfoBUS Instance
        {
            get { if (instance == null) instance = new BillInfoBUS(); return instance; }
            private set => instance = value;
        }

        private BillInfoBUS() { }

        public List<BillInfo> GetListBillInFoByBillId(int id)
        {
            try
            {
                return BillInfoDAL.Instance.GetListBillInFoByBillId(id);
            }
            catch
            {
                List<BillInfo> nl = new List<BillInfo>();
                return nl;
            }
        }

        //Lấy id lơn nhất của bill info
        public int GetBillMax()
        {
            try
            {
                return BillInfoDAL.Instance.GetBillMax();
            }
            catch
            {
                return 0;
            }
        }

        //Thêm bill info
        public void InsertBillInfo(int id, int idBill, string idFood, int count)
        {
            try
            {
                id = GetBillMax() + 1;
                BillInfoDAL.Instance.InsertBillInfo(id, idBill, idFood, count);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        //Xóa toàn bộ bill info
        public void DeleteAllBillInfo(int idBill)
        {
            try
            {
                BillInfoDAL.Instance.DeleteAllBillInfo(idBill);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        //Cập nhật bill info
        public void UpdateBillInfo(int idBill, string idFood, float price)
        {
            try
            {
                BillInfoDAL.Instance.UpdateBillInfo(idBill, idFood, price);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        //Tách bàn bằng cách đổi idbill
        public void TachBan(int idBillcu, string idFood, int idBillmoi)
        {
            try
            {
                BillInfoDAL.Instance.TachBan(idBillcu, idFood, idBillmoi);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
