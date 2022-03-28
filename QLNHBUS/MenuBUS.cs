using QLNHDAL;
using QLNHDTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Menu = QLNHDTO.Menu;

namespace QLNHBUS
{
    public class MenuBUS
    {
        //singleton pattern (khởi tạo duy nhất)
        private static MenuBUS instance;

        public static MenuBUS Instance
        {
            get { if (instance == null) instance = new MenuBUS(); return instance; }
            private set => instance = value;
        }

        private MenuBUS() { }

        //Thêm món ăn
        public void ThemMon(Menu mn)
        {
            switch (mn.Loại_món)
            {
                case "Món chính":
                    mn.Loại_món = "FC001";
                    break;
                case "Tráng miệng":
                    mn.Loại_món = "FC002";
                    break;
                case "Nước":
                    mn.Loại_món = "FC003";
                    break;
            }
            try
            {
                MenuDAL.Instance.ThemMon(mn);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        //Xóa món ăn theo id món
        public void XoaMon(string mamon)
        {
            try
            {
                MenuDAL.Instance.XoaMon(mamon);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        //Sửa thông tin món theo id món
        public void SuaMon(Menu mn)
        {
            switch (mn.Loại_món)
            {
                case "Món chính":
                    mn.Loại_món = "FC001";
                    break;
                case "Tráng miệng":
                    mn.Loại_món = "FC002";
                    break;
                case "Nước":
                    mn.Loại_món = "FC003";
                    break;
            }
            try
            {
                MenuDAL.Instance.SuaMon(mn);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        //Kiểm tra id món ăn muốn thêm đã tồn tại chưa
        public DataTable KiemTraDaTonTai(string id)
        {
            try
            {
                return MenuDAL.Instance.KiemTraDaTonTai(id);
            }
            catch
            {
                return new DataTable();
            }
        }

        //Lấy toàn bộ món ăn
        public List<Menu> LayDanhSachMon()
        {
            try
            {
                return MenuDAL.Instance.LayDanhSachMon();
            }
            catch
            {
                return new List<Menu>();
            }
        }

        public List<Menu> LayDanhSachMonTheoTen(string ten)
        {
            try
            {
                return MenuDAL.Instance.LayDanhSachMonTheoTen(ten);
            }
            catch
            {
                return new List<Menu>();
            }
        }

        public List<Menu> LayDanhSachMonTheoLoaiMon(string mamon)
        {
            try
            {
                return MenuDAL.Instance.LayDanhSachMonTheoLoaiMon(mamon);
            }
            catch
            {
                return new List<Menu>();
            }
        }

        public List<Menu> LayDanhSachMonTheoGia(float gia)
        {
            try
            {
                return MenuDAL.Instance.LayDanhSachMonTheoGia(gia);
            }
            catch
            {
                return new List<Menu>();
            }
        }

        public List<Menu> LayDanhSachMonTheoTenVaLoaiMon(string ten, string mamon)
        {
            try
            {
                return MenuDAL.Instance.LayDanhSachMonTheoTenVaLoaiMon(ten, mamon);
            }
            catch
            {
                return new List<Menu>();
            }
        }

        public List<Menu> LayDanhSachMonTheoTenVaGia(string ten, float gia)
        {
            try
            {
                return MenuDAL.Instance.LayDanhSachMonTheoTenVaGia(ten, gia);
            }
            catch
            {
                return new List<Menu>();
            }
        }

        public List<Menu> LayDanhSachMonTheoLoaiMonVaGia(string mamon, float gia)
        {
            try
            {
                return MenuDAL.Instance.LayDanhSachMonTheoLoaiMonVaGia(mamon, gia);
            }
            catch
            {
                return new List<Menu>();
            }
        }

        public List<Menu> LayDanhSachMonTheoTenVaLoaiMonVaGia(string ten, string mamon, float gia)
        {
            try
            {
                return MenuDAL.Instance.LayDanhSachMonTheoTenVaLoaiMonVaGia(ten, mamon, gia);
            }
            catch
            {
                return new List<Menu>();
            }
        }
    }
}
