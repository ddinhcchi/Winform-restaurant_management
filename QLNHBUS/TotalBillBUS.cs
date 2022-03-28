using QLNHDAL;
using QLNHDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNHBUS
{
    public class TotalBillBUS
    {
        //singleton pattern (khởi tạo duy nhất)
        private static TotalBillBUS instance;

        public static TotalBillBUS Instance
        {
            get { if (instance == null) instance = new TotalBillBUS(); return instance; }
            private set => instance = value;
        }

        private TotalBillBUS() { }

        //gọi hàm DAL
        public List<TotalBill> GetTotalBills(string tableid)
        {
            try
            {
                return TotalBillDAL.Instance.GetTotalBills(tableid);
            }
            catch
            {
                return new List<TotalBill>();
            }
        }

        public List<TotalBill> GetTotalBillDetails(int idBill)
        {
            try
            {
                return TotalBillDAL.Instance.GetTotalBillDetails(idBill);
            }
            catch
            {
                return new List<TotalBill>();
            }
        }
    }
}
