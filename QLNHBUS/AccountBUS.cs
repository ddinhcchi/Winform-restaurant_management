using QLNHDAL;
using QLNHDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLNHBUS
{
    public class AccountBUS
    {
        //singleton pattern (khởi tạo duy nhất)
        private static AccountBUS instance;

        public static AccountBUS Instance
        {
            get { if (instance == null) instance = new AccountBUS(); return instance; }
            private set => instance = value;
        }

        private AccountBUS() { }

        //Hàm mã hóa mật khẩu
        private string MaHoa(string pass)
        {
            byte[] tmp = ASCIIEncoding.ASCII.GetBytes(pass);
            byte[] hasData = new MD5CryptoServiceProvider().ComputeHash(tmp);

            string haspass = "";

            foreach(byte item in hasData)
            {
                haspass += item;
            }

            return haspass;
        }

        //Hàm đăng nhập bằng cách kiểm tra tài khoản và mật khẩu đã mã hóa
        public bool Login(string user, string pass)
        {
            try
            {
                pass = MaHoa(pass);
                return AccountDAL.Instance.Login(user, pass);
            }
            catch
            {
                return false;
            }
        }

        //Lấy tên hiển thị của người dùng
        public string GetDisplayName(string user, string pass)
        {
            pass = MaHoa(pass);
            try
            {
                return AccountDAL.Instance.GetDisplayName(user, pass);
            }
            catch
            {
                return "";
            }
        }

        //Lấy chức vụ của người dùng
        public int GetStatus(string user, string pass)
        {
            pass = MaHoa(pass);
            try
            {
                return AccountDAL.Instance.GetStatus(user, pass);
            }
            catch
            {
                return 0;
            }
        }

        //Lấy tên tài khoản của người dùng
        public string GetUserName(string user, string pass)
        {
            pass = MaHoa(pass);
            try
            {
                return AccountDAL.Instance.GetUserName(user, pass);
            }
            catch
            {
                return "";
            }
        }

        //Lấy danh sách tài khoản
        public List<Account> GetAccounts()
        {
            try
            {
                return AccountDAL.Instance.GetAccounts();
            }
            catch
            {
                List<Account> na = new List<Account>();
                return na;
            }
        }

        //Cập nhật tài khoản
        public void Update(string username, string displayname, string pass, int type)
        {
            pass = MaHoa(pass);
            try
            {
                List<Account> lst = GetAccounts();
                foreach (Account ac in lst)
                {
                    if (ac.UserName == username)
                    {
                        if (displayname != "")
                        {
                            ac.DisplayName = displayname;
                        }

                        if (pass != "")
                        {
                            ac.Pass = pass;
                        }

                        if (type == 0 || type == 1)
                        {
                            ac.Type = type;
                        }
                        AccountDAL.Instance.Update(ac);
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        //Lấy danh sách tài khoản nhưng trừ đi tài khoản của bản thân (chỉ quản lý)
        public List<Account> GetAccountsTruBanThan(string UserName, string tk, string name, string chucvu)
        {
            try
            {
                List<Account> lst = AccountDAL.Instance.GetAccountsSearch(tk, name, chucvu);
                foreach (Account ac in lst)
                {
                    if (ac.UserName == UserName)
                    {
                        lst.Remove(ac);
                        break;
                    }
                }
                return lst;
            }
            catch
            {
                List<Account> lst = new List<Account>();
                return lst;
            }
        }

        //Tạo thêm tài khoản
        public void InsertAccount(string UserName, string DisplayName, string Type)
        {
            int type = 0;
            switch (Type)
            {
                case "Quản lý":
                    type = 1;
                    break;
                case "Nhân viên":
                    type = 0;
                    break;
            }
            try
            {
                AccountDAL.Instance.InsertAccount(UserName, DisplayName, type);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        //Xóa tài khoản
        public void DeleteAccount(string UserName)
        {
            try
            {
                AccountDAL.Instance.DeleteAccount(UserName);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}

