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
    public class ChiTietMonAnBUS
    {
        //singleton pattern (khởi tạo duy nhất)
        private static ChiTietMonAnBUS instance;

        public static ChiTietMonAnBUS Instance
        {
            get { if (instance == null) instance = new ChiTietMonAnBUS(); return instance; }
            private set => instance = value;
        }

        private ChiTietMonAnBUS() { }

        //Lấy toàn bộ thông tin mô tả và đường dẫn video đã lưu
        public ChiTietMonAn LoadChiTiet(string id)
        {
            try
            {
                return ChiTietMonAnDAL.Instance.LoadChiTiet(id);
            }
            catch
            {
                ChiTietMonAn ct = new ChiTietMonAn();
                return ct;
            }
        }

        //Cập nhật thông tin chi tiết của món ăn
        public void UpdateChiTiet(string id, string chitiet, string duongdan, string tenvideo)
        {
            try
            {
                ChiTietMonAnDAL.Instance.UpdateChiTiet(id, chitiet, duongdan, tenvideo);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
