using QLNH3Layer.Forms;
using QLNHBUS;
using QLNHDTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLNH3LayerClone.Forms
{
    public partial class FormTaiKhoan : Form
    {
        public FormTaiKhoan()
        {
            InitializeComponent();
        }

        public event EventHandler ButtonClicked;

        public void NotifyButtonClicked(EventArgs e)
        {
                ButtonClicked(this, e);
        }

        //hàm chuyển đổi màu cho các nút chức năng
        private void LoadTheme()
        {
            //lấy toàn control trong form (vì thiết kế form đều dùng panel nên lấy panel trước)
            foreach (Control pnls in this.Controls)
            {
                //lấy toàn bộ control là panel
                if (pnls.GetType() == typeof(Panel))
                {
                    Panel pnl = (Panel)pnls;
                    //lấy toàn bộ control có trong panel
                    foreach (Control btns in pnl.Controls)
                    {
                        //lấy toàn bộ button trong panel
                        if (btns.GetType() == typeof(Button))
                        {
                            //chuyển đổi màu và định dạng của button
                            Button btn = (Button)btns;
                            btn.BackColor = ThemeColor.PrimaryColor;
                            btn.ForeColor = Color.Black;
                            btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                            btn.TabStop = false;
                            btn.FlatStyle = FlatStyle.Flat;
                            btn.FlatAppearance.BorderSize = 0;
                        }
                    }
                }
            }
        }

        private bool Resizing = false;

        private void ListView_SizeChanged(object sender, EventArgs e)
        {
            // Don't allow overlapping of SizeChanged calls
            if (!Resizing)
            {
                // Set the resizing flag
                Resizing = true;

                ListView listView = sender as ListView;
                if (listView != null)
                {
                    float totalColumnWidth = 0;

                    // Get the sum of all column tags
                    for (int i = 0; i < listView.Columns.Count; i++)
                        totalColumnWidth += Convert.ToInt32(listView.Columns[i].Tag);

                    // Calculate the percentage of space each column should 
                    // occupy in reference to the other columns and then set the 
                    // width of the column to that percentage of the visible space.
                    for (int i = 0; i < listView.Columns.Count; i++)
                    {
                        float colPercentage = (Convert.ToInt32(listView.Columns[i].Tag) / totalColumnWidth);
                        listView.Columns[i].Width = (int)(colPercentage * listView.ClientRectangle.Width);
                    }
                }
            }

            // Clear the resizing flag
            Resizing = false;
        }

        private void FormTaiKhoan_Load(object sender, EventArgs e)
        {
            LoadTheme();
            //Set chieu rong cho cac cot trong hoa don
            this.lvAccount.SizeChanged += new EventHandler(ListView_SizeChanged);

            cbStat.SelectedIndex = 0;
            cbSearchChucVu.SelectedIndex = 0;

            LoadLv();
        }

        private void LoadLv()
        {
            lvAccount.Items.Clear();
            List<Account> lst = AccountBUS.Instance.GetAccountsTruBanThan(frmLogin.UserName,txbSearchTk.Text,txbSearchName.Text,cbSearchChucVu.SelectedItem.ToString());
            foreach (Account ac in lst)
            {
                ListViewItem lv = new ListViewItem(ac.UserName);
                lv.SubItems.Add(ac.DisplayName);
                if(ac.Type == 0)
                {
                    lv.SubItems.Add("Nhân viên");
                }
                else if (ac.Type == 1)
                {
                    lv.SubItems.Add("Quản lý");
                }
                lvAccount.Items.Add(lv);
            }
        }

        private void lvAccount_MouseClick(object sender, MouseEventArgs e)
        {
            if(lvAccount.SelectedItems.Count > 0)
            {
                txbUser.Text = lvAccount.SelectedItems[0].Text;
                txbDisplay.Text = lvAccount.SelectedItems[0].SubItems[1].Text;
                if (lvAccount.SelectedItems[0].SubItems[2].Text == "Quản lý")
                {
                    cbStat.SelectedIndex = 0;
                }
                else
                {
                    cbStat.SelectedIndex = 1;
                }
            }
        }

        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            bool check = true;
            if (txbUser.Text == "" || txbDisplay.Text == "")
            {
                MessageBox.Show("Không được để bất cứ thông tin nào trống","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string usertmp = txbUser.Text;
                string c = " ";
                usertmp = usertmp.Replace(c, string.Empty);
                string displaytmp = txbDisplay.Text;
                displaytmp = displaytmp.Replace(c, string.Empty);

                if (usertmp.Length < txbUser.Text.Length || displaytmp == "")
                {
                    MessageBox.Show("Tên tài khoản không được chứa khoảng trắng\nTên người dùng Không được chỉ chứa toàn khoảng trắng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    List<Account> lst = AccountBUS.Instance.GetAccounts();
                    foreach(Account ac in lst)
                    {
                        if (ac.UserName == txbUser.Text)
                        {
                            check = false;
                            MessageBox.Show("Tên tài khoản bị trùng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                        }
                    }
                    if (check)
                    {
                        AccountBUS.Instance.InsertAccount(txbUser.Text, txbDisplay.Text, cbStat.SelectedItem.ToString());
                        MessageBox.Show("Thêm thành công", "Thông báo");
                        LoadLv();
                    }
                }
            }
        }

        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            if (txbUser.Text != "")
            {
                if (txbUser.Text != frmLogin.UserName)
                {
                    bool check = false;
                    string username = "";
                    string displayname = "";
                    foreach (ListViewItem t in lvAccount.Items)
                    {
                        if (txbUser.Text == t.Text)
                        {
                            username = t.Text;
                            displayname = t.SubItems[1].Text;
                            check = true;
                            break;
                        }
                    }
                    if (check)
                    {
                        DialogResult r = MessageBox.Show("Bạn chắc chắn muốn xóa tài khoản " + username + " của " + displayname + "?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (r == DialogResult.Yes)
                        {
                            AccountBUS.Instance.DeleteAccount(username);
                            LoadLv();
                            refresh();
                            MessageBox.Show("Xóa thành công", "Thông báo");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không tồn tại tài khoản bạn muốn xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Không thể xóa tài khoản của bản thân", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Điền tài khoản bạn muốn xóa");
            }
        }

        void refresh()
        {
            txbDisplay.Clear();
            txbUser.Clear();
        }

        private void btnUpdateAccount_Click(object sender, EventArgs e)
        {
            if (txbUser.Text != "")
            {
                if(txbUser.Text != frmLogin.UserName)
                {
                    bool check = false;
                    Account ac = new Account();
                    List<Account> lst = AccountBUS.Instance.GetAccounts();
                    foreach (Account t in lst)
                    {
                        if (txbUser.Text == t.UserName)
                        {
                            ac = t;
                            check = true;
                            break;
                        }
                    }

                    if (check)
                    {
                        bool checkten = true;
                        string displayname = txbDisplay.Text;
                        if (displayname == "")
                        {
                            displayname = ac.DisplayName;
                        }
                        else
                        {
                            string c = " ";
                            displayname = displayname.Replace(c, string.Empty);
                            if (displayname == "")
                            {
                                checkten = false;
                                MessageBox.Show("Tên người dùng không được chứa toàn khoảng trắng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else
                            {
                                displayname = txbDisplay.Text;
                            }
                        }


                        if (checkten)
                        {
                            if (cbStat.SelectedItem.ToString() == "Quản lý")
                            {
                                ac.Type = 1;
                            }
                            else
                            {
                                ac.Type = 0;
                            }
                            AccountBUS.Instance.Update(ac.UserName, displayname, ac.Pass, ac.Type);
                            LoadLv();
                            refresh();
                            MessageBox.Show("Sửa thành công");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy tài khoản bạn muốn sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Nhấn nút chỉnh sửa góc trên bên trái để chỉnh sửa thông tin của bạn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Điền tài khoản bạn muốn sửa");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            refresh();
            LoadLv();
            cbStat.SelectedIndex = 0;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (txbUser.Text != "")
            {
                if (txbUser.Text != frmLogin.UserName)
                {
                    bool check = false;
                    Account ac = new Account();
                    List<Account> lst = AccountBUS.Instance.GetAccounts();
                    foreach (Account t in lst)
                    {
                        if (txbUser.Text == t.UserName)
                        {
                            ac = t;
                            check = true;
                            break;
                        }
                    }

                    if (check)
                    {
                        DialogResult r = MessageBox.Show("Bạn chắc chắn muốn đặt lại mật khẩu cho tài khoản " + ac.UserName + "?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (r == DialogResult.Yes)
                        {
                            AccountBUS.Instance.Update(ac.UserName, ac.DisplayName, "111111", ac.Type);
                            MessageBox.Show("Đã đặt lại mật khẩu cho tài khoản " + ac.UserName + " thành '111111'", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadLv();
                            refresh();
                            cbStat.SelectedIndex = 0;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy tài khoản muốn xóa");
                    }
                }
                else
                {
                    MessageBox.Show("Nhấn nút chỉnh sửa góc trên bên trái để chỉnh sửa thông tin của bạn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Điền tài khoản bạn muốn đặt lại mật khẩu");
            }
        }

        private void btnUpdateSelf_Click(object sender, EventArgs e)
        {
            FormTaiKhoanStaff f = new FormTaiKhoanStaff();
            f.ShowDialog();
            NotifyButtonClicked(e);
        }

        private void txbSearchTk_TextChanged(object sender, EventArgs e)
        {
            LoadLv();
        }

        private void txbSearchName_TextChanged(object sender, EventArgs e)
        {
            LoadLv();
        }

        private void cbSearchChucVu_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadLv();
        }
    }
}
