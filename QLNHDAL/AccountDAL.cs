using QLNHDTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace QLNHDAL
{
    public class AccountDAL
    {
        //singleton pattern (khởi tạo duy nhất)
        private static AccountDAL instance;

        public static AccountDAL Instance
        {
            get { if (instance == null) instance = new AccountDAL(); return instance; }
            private set => instance = value;
        }

        private AccountDAL() { }

        //hàm kiểm tra tài khoản mật khẩu đăng nhập
        public bool Login(string user, string pass)
        {
            string query = "USP_Login @userName , @passWord";

            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { user, pass });

            return result.Rows.Count > 0;
        }

        //hàm lấy tên người dùng của tài khoản đăng nhập
        public string GetDisplayName(string user, string pass)
        {

            string query = "USP_Login @userName , @passWord";

            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { user, pass });

            return result.Rows[0].Field<string>(1).ToString();
        }

        //hàm lấy chức vụ của người dùng
        public int GetStatus(string user, string pass)
        {

            string query = "USP_Login @userName , @passWord";

            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { user, pass });

            return result.Rows[0].Field<int>(3);
        }

        //hàm lấy chức vụ của người dùng
        public string GetUserName(string user, string pass)
        {

            string query = "USP_Login @userName , @passWord";

            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { user, pass });

            return result.Rows[0].Field<string>(0);
        }

        public void Update(Account ac)
        {
            string sql = "UPDATE Account SET DisplayName=@tennguoi, Pass=@mkmoi, Type=@loai WHERE UserName=@ten";
            SqlParameter[] pa = new SqlParameter[4];
            pa[0] = new SqlParameter("tennguoi", ac.DisplayName);
            pa[1] = new SqlParameter("mkmoi", ac.Pass);
            pa[2] = new SqlParameter("loai", ac.Type);
            pa[3] = new SqlParameter("ten", ac.UserName);
            DataProvider.Instance.ExcuteNonQuery(sql, CommandType.Text, pa);
        }

        public List<Account> GetAccounts()
        {
            List<Account> accounts = new List<Account>();
            DataTable dtac = DataProvider.Instance.ExecuteQuery("Select * from Account order by Type");
            foreach (DataRow r in dtac.Rows)
            {
                Account ac = new Account
                {
                    UserName = r["UserName"].ToString(),
                    DisplayName = r["DisplayName"].ToString(),
                    Pass = r["Pass"].ToString(),
                    Type = Convert.ToInt32(r["Type"].ToString())
                };
                accounts.Add(ac);
            }
            return accounts;
        }

        public List<Account> GetAccountsSearch(string tk, string name, string chucvu)
        {
            string sql = "";
            int type = 0;
            if (tk == "" && name == "" && chucvu != "(None)")
            {
                if (chucvu == "Quản lý") type = 1;
                sql = "Select * from Account Where Type = " + type.ToString();
            }
            else if (tk == "" && name != "" && chucvu == "(None)")
            {
                sql = "Select * from Account Where DisplayName LIKE N'%" + name + "%' order by Type";
            }
            else if (tk != "" && name == "" && chucvu == "(None)")
            {
                sql = "Select * from Account Where UserName LIKE N'%" + tk + "%' order by Type";
            }
            else if (tk != "" && name != "" && chucvu == "(None)")
            {
                sql = "Select * from Account Where UserName LIKE N'%" + tk + "%' AND DisplayName LIKE N'%" + name + "%' order by Type";
            }
            else if (tk != "" && name == "" && chucvu != "(None)")
            {
                if (chucvu == "Quản lý") type = 1;
                sql = "Select * from Account Where UserName LIKE N'%" + tk + "%' AND Type = " + type.ToString();
            }
            else if (tk == "" && name != "" && chucvu != "(None)")
            {
                if (chucvu == "Quản lý") type = 1;
                sql = "Select * from Account Where DisplayName LIKE N'%" + name + "%' AND Type = " + type.ToString();
            }
            else if (tk != "" && name != "" && chucvu != "(None)")
            {
                if (chucvu == "Quản lý") type = 1;
                sql = "Select * from Account Where DisplayName LIKE N'%" + name + "%' AND Type = " + type.ToString() + "AND UserName LIKE N'%" + tk + "%'";
            }
            else if (tk == "" && name == "" && chucvu == "(None)")
            {
                sql = "Select * from Account order by Type";
            }

            List<Account> accounts = new List<Account>();
            DataTable dtac = DataProvider.Instance.ExecuteQuery(sql);
            foreach (DataRow r in dtac.Rows)
            {
                Account ac = new Account
                {
                    UserName = r["UserName"].ToString(),
                    DisplayName = r["DisplayName"].ToString(),
                    Pass = r["Pass"].ToString(),
                    Type = Convert.ToInt32(r["Type"].ToString())
                };
                accounts.Add(ac);
            }
            return accounts;
        }

        public void InsertAccount(string UserName, string DisplayName, int Type)
        {
            string sql = "insert into Account(UserName,DisplayName,Pass,Type) values('"+UserName+"',N'"+DisplayName+ "','150231146241509418344146165732219051118'," + Type.ToString()+")";
            DataProvider.Instance.ExecuteNonQuery(sql);
        }

        public void DeleteAccount(string UserName)
        {
            string sql = "Delete Account where UserName = '" + UserName + "'";
            DataProvider.Instance.ExecuteNonQuery(sql);
        }
    }
}
