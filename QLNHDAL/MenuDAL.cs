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
    public class MenuDAL
    {
        //singleton pattern (khởi tạo duy nhất)
        private static MenuDAL instance;

        public static MenuDAL Instance
        {
            get { if (instance == null) instance = new MenuDAL(); return instance; }
            private set => instance = value;
        }

        private MenuDAL() { }

        public List<Menu> LayDanhSachMon()
        {
            List<Menu> dsMon = new List<Menu>();
            DataTable dtMon = DataProvider.Instance.ExecuteQuery("Select * From Menu Order by IdCategory, Id");
            foreach (DataRow r in dtMon.Rows)
            {
                Menu mn = new Menu
                {
                    Id = r["Id"].ToString(),
                    Tên_món = r["Name"].ToString(),
                    Giá = float.Parse(r["Price"].ToString()),
                };
                switch (r["IdCategory"].ToString())
                {
                    case "FC001":
                        mn.Loại_món = "Món chính";
                        break;
                    case "FC002":
                        mn.Loại_món = "Tráng miệng";
                        break;
                    case "FC003":
                        mn.Loại_món = "Nước";
                        break;
                }
                dsMon.Add(mn);
            }
            return dsMon;
        }

        public List<Menu> LayDanhSachMonTheoLoaiMon(string mamon)
        {
            List<Menu> dsMon = new List<Menu>();
            DataTable dtMon = DataProvider.Instance.ExecuteQuery("Select * From Menu Where IdCategory = '" + mamon + "' Order by IdCategory, Id");
            foreach (DataRow r in dtMon.Rows)
            {
                Menu mn = new Menu
                {
                    Id = r["Id"].ToString(),
                    Tên_món = r["Name"].ToString(),
                    Giá = float.Parse(r["Price"].ToString())
                };
                switch (r["IdCategory"].ToString())
                {
                    case "FC001":
                        mn.Loại_món = "Món chính";
                        break;
                    case "FC002":
                        mn.Loại_món = "Tráng miệng";
                        break;
                    case "FC003":
                        mn.Loại_món = "Nước";
                        break;
                }
                dsMon.Add(mn);
            }
            return dsMon;
        }

        public List<Menu> LayDanhSachMonTheoTen(string ten)
        {
            List<Menu> dsMon = new List<Menu>();
            DataTable dtMon = DataProvider.Instance.ExecuteQuery("Select * From Menu Where Name LIKE N'%" + ten + "%' Order by IdCategory, Id");
            foreach (DataRow r in dtMon.Rows)
            {
                Menu mn = new Menu
                {
                    Id = r["Id"].ToString(),
                    Tên_món = r["Name"].ToString(),
                    Giá = float.Parse(r["Price"].ToString())
                };
                switch (r["IdCategory"].ToString())
                {
                    case "FC001":
                        mn.Loại_món = "Món chính";
                        break;
                    case "FC002":
                        mn.Loại_món = "Tráng miệng";
                        break;
                    case "FC003":
                        mn.Loại_món = "Nước";
                        break;
                }
                dsMon.Add(mn);
            }
            return dsMon;
        }

        public List<Menu> LayDanhSachMonTheoGia(float gia)
        {
            List<Menu> dsMon = new List<Menu>();
            DataTable dtMon = DataProvider.Instance.ExecuteQuery("Select * From Menu Where Price < " + gia + " Order by IdCategory, Id");
            foreach (DataRow r in dtMon.Rows)
            {
                Menu mn = new Menu
                {
                    Id = r["Id"].ToString(),
                    Tên_món = r["Name"].ToString(),
                    Giá = float.Parse(r["Price"].ToString())
                };
                switch (r["IdCategory"].ToString())
                {
                    case "FC001":
                        mn.Loại_món = "Món chính";
                        break;
                    case "FC002":
                        mn.Loại_món = "Tráng miệng";
                        break;
                    case "FC003":
                        mn.Loại_món = "Nước";
                        break;
                }
                dsMon.Add(mn);
            }
            return dsMon;
        }

        public List<Menu> LayDanhSachMonTheoTenVaLoaiMon(string ten, string mamon)
        {
            List<Menu> dsMon = new List<Menu>();
            DataTable dtMon = DataProvider.Instance.ExecuteQuery("Select * From Menu Where IdCategory = '" + mamon + "' AND Name LIKE N'%" + ten + "%' Order by IdCategory, Id");
            foreach (DataRow r in dtMon.Rows)
            {
                Menu mn = new Menu
                {
                    Id = r["Id"].ToString(),
                    Tên_món = r["Name"].ToString(),
                    Giá = float.Parse(r["Price"].ToString())
                };
                switch (r["IdCategory"].ToString())
                {
                    case "FC001":
                        mn.Loại_món = "Món chính";
                        break;
                    case "FC002":
                        mn.Loại_món = "Tráng miệng";
                        break;
                    case "FC003":
                        mn.Loại_món = "Nước";
                        break;
                }
                dsMon.Add(mn);
            }
            return dsMon;
        }

        public List<Menu> LayDanhSachMonTheoTenVaGia(string ten, float gia)
        {
            List<Menu> dsMon = new List<Menu>();
            DataTable dtMon = DataProvider.Instance.ExecuteQuery("Select * From Menu Where Name LIKE N'%" + ten + "%' AND Price < " + gia + " Order by IdCategory, Id");
            foreach (DataRow r in dtMon.Rows)
            {
                Menu mn = new Menu
                {
                    Id = r["Id"].ToString(),
                    Tên_món = r["Name"].ToString(),
                    Giá = float.Parse(r["Price"].ToString())
                };
                switch (r["IdCategory"].ToString())
                {
                    case "FC001":
                        mn.Loại_món = "Món chính";
                        break;
                    case "FC002":
                        mn.Loại_món = "Tráng miệng";
                        break;
                    case "FC003":
                        mn.Loại_món = "Nước";
                        break;
                }
                dsMon.Add(mn);
            }
            return dsMon;
        }

        public List<Menu> LayDanhSachMonTheoLoaiMonVaGia(string mamon, float gia)
        {
            List<Menu> dsMon = new List<Menu>();
            DataTable dtMon = DataProvider.Instance.ExecuteQuery("Select * From Menu Where IdCategory = '" + mamon + "' AND Price < " + gia + " Order by IdCategory, Id");
            foreach (DataRow r in dtMon.Rows)
            {
                Menu mn = new Menu
                {
                    Id = r["Id"].ToString(),
                    Tên_món = r["Name"].ToString(),
                    Giá = float.Parse(r["Price"].ToString())
                };
                switch (r["IdCategory"].ToString())
                {
                    case "FC001":
                        mn.Loại_món = "Món chính";
                        break;
                    case "FC002":
                        mn.Loại_món = "Tráng miệng";
                        break;
                    case "FC003":
                        mn.Loại_món = "Nước";
                        break;
                }
                dsMon.Add(mn);
            }
            return dsMon;
        }

        public List<Menu> LayDanhSachMonTheoTenVaLoaiMonVaGia(string ten,string mamon, float gia)
        {
            List<Menu> dsMon = new List<Menu>();
            DataTable dtMon = DataProvider.Instance.ExecuteQuery("Select * From Menu Where IdCategory = '" + mamon + "' AND Price < " + gia + "AND Name LIKE N'%" + ten + "%' Order by IdCategory, Id");
            foreach (DataRow r in dtMon.Rows)
            {
                Menu mn = new Menu
                {
                    Id = r["Id"].ToString(),
                    Tên_món = r["Name"].ToString(),
                    Giá = float.Parse(r["Price"].ToString())
                };
                switch (r["IdCategory"].ToString())
                {
                    case "FC001":
                        mn.Loại_món = "Món chính";
                        break;
                    case "FC002":
                        mn.Loại_món = "Tráng miệng";
                        break;
                    case "FC003":
                        mn.Loại_món = "Nước";
                        break;
                }
                dsMon.Add(mn);
            }
            return dsMon;
        }

        public void ThemMon(Menu mn)
        {
            string sql = "INSERT INTO Menu(Id, Name, IdCategory, Price) VALUES(@MaMon, @TenMon, @LoaiMon, @Gia)";
            SqlParameter[] pa = new SqlParameter[4];
            pa[0] = new SqlParameter("MaMon", mn.Id);
            pa[1] = new SqlParameter("TenMon", mn.Tên_món);
            pa[2] = new SqlParameter("LoaiMon", mn.Loại_món);
            pa[3] = new SqlParameter("Gia", mn.Giá);
            DataProvider.Instance.ExcuteNonQuery(sql, CommandType.Text, pa);
        }

        public void XoaMon(string mamon)
        {
            string sql = "DELETE FROM Menu WHERE Id = @MaMon";
            SqlParameter[] pa = new SqlParameter[1];
            pa[0] = new SqlParameter("MaMon", mamon);
            DataProvider.Instance.ExcuteNonQuery(sql, CommandType.Text, pa);
        }

        public void SuaMon(Menu mn)
        {
            string sql = "UPDATE Menu SET Name=@TenMon, IdCategory=@LoaiMon, Price=@Gia WHERE Id=@MaMon";
            SqlParameter[] pa = new SqlParameter[4];
            pa[0] = new SqlParameter("MaMon", mn.Id);
            pa[1] = new SqlParameter("TenMon", mn.Tên_món);
            pa[2] = new SqlParameter("LoaiMon", mn.Loại_món);
            pa[3] = new SqlParameter("Gia", mn.Giá);
            DataProvider.Instance.ExcuteNonQuery(sql, CommandType.Text, pa);
        }

        public DataTable KiemTraDaTonTai(string Id)
        {
            return DataProvider.Instance.ExecuteQuery("Select * From Menu Where Id = '" + Id + "'");
        }
    }
}
