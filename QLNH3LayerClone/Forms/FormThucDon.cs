using QLNHBUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLNHDTO;
using System.Windows.Forms;
using Menu = QLNHDTO.Menu;

namespace QLNH3LayerClone.Forms
{
    public partial class FormThucDon : Form
    {
        ////Đối tượng kết nối
        //QLNHDataContext db = new QLNHDataContext();

        public FormThucDon()
        {
            InitializeComponent();
        }

        string tmp; //luu ma loai mon

        private void FormThucDon_Load(object sender, EventArgs e)
        {
            LoadTheme();
            dtgvFood.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //load các loại món vào combobox tìm kiếm
            cbLoai.Items.Add("(None)");
            cbLoai.Items.Add("Món chính");
            cbLoai.Items.Add("Tráng miệng");
            cbLoai.Items.Add("Nước");
            cbLoai.SelectedIndex = 0;

            //load các loại món vào combobox sửa đổi
            cbUpdateLoai.Items.Add("Món chính");
            cbUpdateLoai.Items.Add("Tráng miệng");
            cbUpdateLoai.Items.Add("Nước");
            cbUpdateLoai.SelectedIndex = 0;
            

            //load giá cho combobox sort giá
            cbSortPrice.Items.Add("(None)");
            cbSortPrice.Items.Add("1000000");
            cbSortPrice.Items.Add("500000");
            cbSortPrice.Items.Add("200000");
            cbSortPrice.Items.Add("100000");
            cbSortPrice.Items.Add("50000");
            cbSortPrice.Items.Add("20000");
            cbSortPrice.SelectedIndex = 0;

            ////sort thực đơn theo loại món ăn đang chọn
            fillThucDonByLoaiMon();

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
            //đổi màu label Thông tin
            lblInfo.ForeColor = ThemeColor.SecondaryColor;
        }

        //sort thực đơn theo loại món ăn đang chọn, giá và tên gần đúng
        private void fillThucDonByLoaiMon()
        {
            
            switch (cbLoai.SelectedItem.ToString())
            {
                case "Món chính":
                    tmp = "FC001";
                    break;
                case "Tráng miệng":
                    tmp = "FC002";
                    break;
                case "Nước":
                    tmp = "FC003";
                    break;
            }

            if (txbTen.Text != "" && cbLoai.SelectedIndex == 0 && cbSortPrice.SelectedIndex == 0)
            {
                dtgvFood.DataSource = MenuBUS.Instance.LayDanhSachMonTheoTen(txbTen.Text);
            }

            if (txbTen.Text == "" && cbLoai.SelectedIndex > 0 && cbSortPrice.SelectedIndex == 0)
            {
                dtgvFood.DataSource = MenuBUS.Instance.LayDanhSachMonTheoLoaiMon(tmp);
            }

            if (txbTen.Text == "" && cbLoai.SelectedIndex == 0 && cbSortPrice.SelectedIndex > 0)
            {
                dtgvFood.DataSource = MenuBUS.Instance.LayDanhSachMonTheoGia(float.Parse(cbSortPrice.SelectedItem.ToString()));
            }

            if (txbTen.Text != "" && cbLoai.SelectedIndex > 0 && cbSortPrice.SelectedIndex == 0)
            {
                dtgvFood.DataSource = MenuBUS.Instance.LayDanhSachMonTheoTenVaLoaiMon(txbTen.Text, tmp);
            }

            if (txbTen.Text == "" && cbLoai.SelectedIndex > 0 && cbSortPrice.SelectedIndex > 0)
            {
                dtgvFood.DataSource = MenuBUS.Instance.LayDanhSachMonTheoLoaiMonVaGia(tmp, float.Parse(cbSortPrice.SelectedItem.ToString()));
            }

            if (txbTen.Text != "" && cbLoai.SelectedIndex == 0 && cbSortPrice.SelectedIndex > 0)
            {
                dtgvFood.DataSource = MenuBUS.Instance.LayDanhSachMonTheoTenVaGia(txbTen.Text, float.Parse(cbSortPrice.SelectedItem.ToString()));
            }

            if (txbTen.Text != "" && cbLoai.SelectedIndex > 0 && cbSortPrice.SelectedIndex > 0)
            {
                dtgvFood.DataSource = MenuBUS.Instance.LayDanhSachMonTheoTenVaLoaiMonVaGia(txbTen.Text, tmp, float.Parse(cbSortPrice.SelectedItem.ToString()));
            }

            if (txbTen.Text == "" && cbLoai.SelectedIndex == 0 && cbSortPrice.SelectedIndex == 0)
            {
                dtgvFood.DataSource = MenuBUS.Instance.LayDanhSachMon();
            }
        }

        //nhập chữ nào là tìm món theo chữ đó (từng chữ 1 nếu là tiếng Anh, sau khi nhấn cách nếu là tiếng Việt)
        private void txbTen_TextChanged(object sender, EventArgs e)
        {
            fillThucDonByLoaiMon();
        }

        //tìm món mỗi khi chọn loại
        private void cbLoai_SelectedValueChanged(object sender, EventArgs e)
        {
            fillThucDonByLoaiMon();
        }

        //tìm món mỗi khi chọn giá
        private void cbSortPrice_SelectedValueChanged(object sender, EventArgs e)
        {
            fillThucDonByLoaiMon();
        }

        //đổ thông tin của món vào các textbox khi click vào bất kỳ cell nào trong gridview
        private void dtgvFood_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dtgvFood.CurrentRow.Index;
            txbID.Text = dtgvFood.Rows[i].Cells[0].Value.ToString();
            txbName.Text = dtgvFood.Rows[i].Cells[1].Value.ToString();
            txbPrice.Text = dtgvFood.Rows[i].Cells[3].Value.ToString();
            cbUpdateLoai.SelectedIndex = cbUpdateLoai.FindStringExact(dtgvFood.Rows[i].Cells[2].Value.ToString());
        }

        //Thêm món ăn (chỉ Admin)
        private void btnAddFood_Click(object sender, EventArgs e)
        {
            //Kiểm tra coi phải admin không
            if (frmLogin.UserStatic == 0)
            {
                MessageBox.Show("Chỉ có admin được sử dụng chức năng này", "Không đủ quyền hạn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                //Kiểm tra xem id đã tồn tại chưa
                DataTable kt = MenuBUS.Instance.KiemTraDaTonTai(txbID.Text);

                #region kiểm tra tính hợp lệ của thông tin đưa vào
                //kiểm tra thông tin trống
                if (txbID.Text.Length == 0 && txbName.Text.Length == 0 && txbPrice.Text.Length == 0)
                {
                    MessageBox.Show("Chưa điền thông tin", "Lỗi!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txbName.Text.Length == 0 && txbID.Text.Length == 0)
                {
                    MessageBox.Show("Không để ID và Tên trống", "Lỗi!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txbPrice.Text.Length == 0 && txbID.Text.Length == 0)
                {
                    MessageBox.Show("Không để ID và Giá trống", "Lỗi!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txbName.Text.Length == 0 && txbPrice.Text.Length == 0)
                {
                    MessageBox.Show("Không để Giá và Tên trống", "Lỗi!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txbID.Text.Length == 0)
                {
                    MessageBox.Show("Không để ID trống", "Lỗi!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txbName.Text.Length == 0)
                {
                    MessageBox.Show("Không để Tên trống", "Lỗi!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txbPrice.Text.Length == 0)
                {
                    MessageBox.Show("Không để Giá trống", "Lỗi!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //kiểm tra id hợp lệ
                else if (!KiemTraId())
                {
                    MessageBox.Show("ID bắt đầu bằng ký tự \"MN\" và 3 số theo sau", "Lỗi!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //kiểm tra id đã tồn tại chưa
                else if (kt.Rows.Count > 0)
                {
                    MessageBox.Show("ID đã tồn tại", "Lỗi!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                #endregion
                //nếu hợp lệ => thêm món
                else
                {
                    float t;
                    //kiểm tra giá tiền có phải số tự nhiên không
                    if (!float.TryParse(txbPrice.Text, out t))
                    {
                        MessageBox.Show("Giá không hợp lệ", "Lỗi!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (t < 0)
                    {
                        MessageBox.Show("Giá không thể âm", "Lỗi!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (cbUpdateLoai.SelectedItem == null)
                    {
                        MessageBox.Show("Chưa chọn loại món", "Lỗi!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (cbUpdateLoai.SelectedItem.ToString() != "Món chính" && cbUpdateLoai.SelectedItem.ToString() != "Tráng miệng" && cbUpdateLoai.SelectedItem.ToString() != "Nước")
                    {
                        MessageBox.Show("Chưa chọn loại món", "Lỗi!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        //tạo đối tượng món mới
                        Menu mn = new Menu
                        {
                            Id = txbID.Text,
                            Tên_món = txbName.Text,
                            Loại_món = cbUpdateLoai.SelectedItem.ToString(),
                            Giá = float.Parse(txbPrice.Text)
                        };

                        //Them
                        MenuBUS.Instance.ThemMon(mn);

                        //Xoa du lieu trong textbox
                        txbPrice.Clear();
                        txbID.Clear();
                        txbName.Clear();
                        fillThucDonByLoaiMon();
                        MessageBox.Show("Thêm thành công");
                    }
                }
            }
        }

        //hàm kiểm tra id hợp lệ
        private bool KiemTraId()
        {
            int kiemtra;
            string tmp = txbID.Text;
            string tmpMN = tmp[0].ToString() + tmp[1].ToString();
            if (tmpMN != "MN") return false;
            else
            {
                for (int i = 2; i < 5; i++)
                {
                    if (!Int32.TryParse(tmp[i].ToString(), out kiemtra))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        //nút xóa dữ liệu đã điền trong các textbox
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txbTen.Clear();
            cbLoai.SelectedIndex = 0;
            cbSortPrice.SelectedIndex = 0;
            txbID.Clear();
            txbName.Clear();
            txbPrice.Clear();
        }

        //nút xóa món ăn (chỉ xóa theo ID; chỉ Admin)
        private void btnDeleteFood_Click(object sender, EventArgs e)
        {
            //Kiểm tra coi phải admin không
            if (frmLogin.UserStatic == 0)
            {
                MessageBox.Show("Chỉ có admin được sử dụng chức năng này", "Không đủ quyền hạn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                //kiểm tra trống
                if (txbID.Text.Length == 0)
                {
                    MessageBox.Show("Chưa điền ID món cần xóa", "Lỗi!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    //kiểm tra id có tồn tại hay không
                    DataTable kt = MenuBUS.Instance.KiemTraDaTonTai(txbID.Text);
                    if (kt.Rows.Count == 0)
                    {
                        MessageBox.Show("Không tìm thấy món cần xóa", "Lỗi!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        string tenmon = "";
                        foreach (DataGridViewRow row in dtgvFood.Rows)
                        {
                            if (row.Cells["Id"].Value.ToString().Equals(txbID.Text))
                            {
                                tenmon = row.Cells["Tên_món"].Value.ToString();
                            }
                        }
                        DialogResult re;
                        re = MessageBox.Show("Bạn chắc chắn muốn xóa món " + tenmon, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (re == System.Windows.Forms.DialogResult.Yes)
                        {
                            //xóa
                            MenuBUS.Instance.XoaMon(txbID.Text.ToString());

                            //xóa sạch dữ liệu có trong textbox 
                            txbPrice.Clear();
                            txbID.Clear();
                            txbName.Clear();
                            fillThucDonByLoaiMon();
                            MessageBox.Show("Xóa thành công");
                        }
                    }
                }
            }
        }

        //cập nhật thông tin món ăn (chỉ cập nhật theo ID; chỉ Admin)
        private void btnUpdateFood_Click(object sender, EventArgs e)
        {
            //Kiểm tra coi phải admin không
            if (frmLogin.UserStatic == 0)
            {
                MessageBox.Show("Chỉ có admin được sử dụng chức năng này", "Không đủ quyền hạn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                float t = 0;
                bool checkGiaHopLe = true;
                bool checkGiaAm = true;
                //kiểm tra trống

                if (txbPrice.Text.Length > 0)
                {
                    if (!float.TryParse(txbPrice.Text, out t))
                    {
                        MessageBox.Show("Giá không hợp lệ", "Lỗi!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        checkGiaHopLe = false;
                    }
                }

                if (t < 0)
                {
                    MessageBox.Show("Giá không thể âm", "Lỗi!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    checkGiaAm = false;
                }

                if (txbID.Text.Length == 0)
                {
                    MessageBox.Show("Chưa điền ID món cần sửa", "Lỗi!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (checkGiaAm && checkGiaHopLe)
                {
                    //kiểm tra coi tồn tại id này ko
                    DataTable kt = MenuBUS.Instance.KiemTraDaTonTai(txbID.Text);
                    //nếu tồn tại
                    if (kt.Rows.Count > 0)
                    {
                        string tenmon = "";
                        float gia = 0;
                        string loaimon = "";
                        foreach (DataGridViewRow row in dtgvFood.Rows)
                        {
                            if (row.Cells["Id"].Value.ToString().Equals(txbID.Text))
                            {
                                tenmon = row.Cells["Tên_món"].Value.ToString();
                                gia = float.Parse(row.Cells["Giá"].Value.ToString());
                                loaimon = row.Cells["Loại_món"].Value.ToString();
                            }                            
                        }
                        Menu mn = new Menu
                        {
                            Id = txbID.Text,
                            Tên_món = txbName.Text == "" ? tenmon : txbName.Text, //nếu textbox tên để trống thì không cập nhật tên, nếu không để trống thì cập nhật
                            Loại_món = cbUpdateLoai.SelectedIndex >= 0 ? cbUpdateLoai.SelectedItem.ToString() : loaimon,
                            Giá = txbPrice.Text == "" ? gia : float.Parse(txbPrice.Text) //nếu textbox giá để trống thì không cập nhật giá, nếu không để trống thì cập nhật
                        };

                        //lưu thay đổi
                        MenuBUS.Instance.SuaMon(mn);

                        //xóa sạch dữ liệu textbox
                        txbPrice.Clear();
                        txbID.Clear();
                        txbName.Clear();
                        fillThucDonByLoaiMon();
                        MessageBox.Show("Sửa thành công");
                    }
                    //nếu không tồn tại
                    else
                    {
                        MessageBox.Show("Không tìm thấy id món cần sửa");
                    }
                }
            }
        }

        private void dtgvFood_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dtgvFood.CurrentRow.Index;
            string id = dtgvFood.Rows[i].Cells[0].Value.ToString();
            QLNH3Layer.Forms.FormChiTietMonAn f = new QLNH3Layer.Forms.FormChiTietMonAn(id);
            f.ShowDialog();
        }
    }
}
