using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using OfficeOpenXml;
using Excel = Microsoft.Office.Interop.Excel;

namespace QUANLYNHANSU
{
    public partial class hosonhanvien : Form
    {
        public hosonhanvien()
        {
            InitializeComponent();
        }
        string chuoiketnoi = "Data Source=DESKTOP-8RC4J29\\SQLEXPRESS;Initial Catalog=QUANLYNHANSU;Integrated Security=True";
        SqlConnection con = new SqlConnection();

        // hàm kết nối
        private void ketNoicsdl()
        {
            try
            {
                con = new SqlConnection(chuoiketnoi);         // truyền vào chuỗi kết nối 
                con.Open();                                  // mở chuỗi kết nối 
            }
            catch
            {
                MessageBox.Show("Kết nối thất bại  ");
            }
        }
        // dinh dang du lieu tren datagirdView
        private void dinhdangdulieutrendata()
        {
            dtg.Columns[0].HeaderText = "Mã nhân viên ";
            dtg.Columns[1].HeaderText = "Họ tên ";
            dtg.Columns[2].HeaderText = " Ngày sinh";
            dtg.Columns[3].HeaderText = "Giới tính ";
            dtg.Columns[4].HeaderText = "Dân tộc ";
            dtg.Columns[5].HeaderText = "Tôn Giáo ";
            dtg.Columns[6].HeaderText = "Số cmnd";
            dtg.Columns[7].HeaderText = "Địa chỉ ";
            dtg.Columns[8].HeaderText = "Quê quán  ";
            dtg.Columns[9].HeaderText = "Số ĐT";
            dtg.Columns[10].HeaderText = "Mã TĐ";
            dtg.Columns[11].HeaderText = "Ngoại ngữ";
            dtg.Columns[12].HeaderText = "Trình độ nn ";
            dtg.Columns[13].HeaderText = "Mã cv";
            dtg.Columns[14].HeaderText = "Mã PB";
            dtg.Columns[15].HeaderText = "Ngày CT";
            dtg.Columns[16].HeaderText = "Ảnh";
            dtg.Columns[0].Width = 120;
            dtg.Columns[1].Width = 170;
            dtg.Columns[2].Width = 110;
            dtg.Columns[3].Width = 70;
            dtg.Columns[4].Width = 80;
            dtg.Columns[5].Width = 80;
            dtg.Columns[6].Width = 110;
            dtg.Columns[7].Width = 110;
            dtg.Columns[8].Width = 110;
            dtg.Columns[9].Width = 90;
            dtg.Columns[10].Width = 80;
            dtg.Columns[11].Width = 100;
            dtg.Columns[12].Width = 100;
            dtg.Columns[13].Width = 80;
            dtg.Columns[14].Width = 80;
            dtg.Columns[15].Width = 90;
            dtg.Columns[16].Width = 80;
            dtg.EnableHeadersVisualStyles = false;

            dtg.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 0, 0);
            dtg.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(248, 248, 255);
            dtg.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtg.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            dtg.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dtg.DefaultCellStyle.BackColor = Color.FromArgb(248, 248, 255);
            dtg.DefaultCellStyle.ForeColor = Color.FromArgb(0, 0, 0);
        }
        // hien thi du lieu tren datagridView 
        private void hienthidulieulendatagridview()
        {

            string sql = "SELECT * FROM nhanvien";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dtg.DataSource = dt;
            dinhdangdulieutrendata();
        }
        private void loaddulieucombotrinhdo()
        {
            string sql = "SELECT matd FROM trinhdo";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cbbmatd.DataSource = dt;
            cbbmatd.ValueMember = dt.Columns["matd"].ToString();
            cbbmatd.DisplayMember = dt.Columns["matd"].ToString();
        }
        private void loaddulieucombochucvu()
        {
            string sql = "SELECT macv FROM chucvu";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cbbmacv.DataSource = dt;
            cbbmacv.ValueMember = dt.Columns["macv"].ToString();
            cbbmacv.DisplayMember = dt.Columns["macv"].ToString();
        }
        private void loaddulieucombophongban()
        {
            string sql = "SELECT mapb FROM phongban";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cbbmapb.DataSource = dt;
            cbbmapb.ValueMember = dt.Columns["mapb"].ToString();
            cbbmapb.DisplayMember = dt.Columns["mapb"].ToString();
        }

        private void hosonhanvien_Load(object sender, EventArgs e)
        {
            ketNoicsdl();
            hienthidulieulendatagridview();
            loaddulieucombotrinhdo();
            loaddulieucombochucvu();
            loaddulieucombophongban();
            //  btnluuhsnv.Enabled = false;
            btnsuahsnv.Enabled = false;
            btnxoahsnv.Enabled = false;
            txtmanv.Enabled = false;
        }
        // Trả về đường dẫn của ảnh
        public static string GetFieldValues(string sql)
        {
            string chuoiketnoi = "Data Source=DESKTOP-8RC4J29\\SQLEXPRESS;Initial Catalog=QUANLYNHANSU;Integrated Security=True";
            SqlConnection con = new SqlConnection();
            con = new SqlConnection(chuoiketnoi);// Truyền vào chuối kết nối
            con.Open(); // Mở kết nối      
            string ma = "";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            while (reader.Read())
                ma = reader.GetValue(0).ToString();
            reader.Close();
            return ma;
        }

        private void btnthemhsnv_Click(object sender, EventArgs e)
        {
            txtmanv.Enabled = true;
            btnluuhsnv.Enabled = true;
            btnsuahsnv.Enabled = false;
        }

        private void btnsuahsnv_Click(object sender, EventArgs e)
        {
            txtmanv.Enabled = false;
            btnsuahsnv.Enabled = false;
            btnxoahsnv.Enabled = false;
            btnluuhsnv.Enabled = false;
            if (string.IsNullOrWhiteSpace(txtmanv.Text) || string.IsNullOrWhiteSpace(txthoten.Text) || string.IsNullOrWhiteSpace(txtcmnd.Text) || string.IsNullOrWhiteSpace(txtdiachi.Text) || string.IsNullOrWhiteSpace(txtquequan.Text))
            {
                MessageBox.Show("Vui lòng nhập  đầy đủ thông tin dữ liệu !");
            }
            else
            {
                if (rdnam.Checked == false && rdnu.Checked == false)
                {
                    MessageBox.Show("Vui lòng nhập  chọn giới tính !");
                }
                else
                {
                    if (cbt.Checked == false && cbtb.Checked == false && cby.Checked == false)
                    {
                        MessageBox.Show("Vui lòng nhập  chọn trình độ sử dụng ngoại ngữ !");
                    }
                    else
                    {
                        DialogResult h = MessageBox.Show
                    ("Bạn có chắc muốn sửa thông tin nhân viên này không?", " ⚠️Cảnh Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                        if (h == DialogResult.OK)
                        {
                            btnluuhsnv.Enabled = true;
                            string manv = txtmanv.Text.Trim();
                            string hoten = txthoten.Text.Trim();
                            string ngaysinh = dtpngaysinh.Text.Trim();
                            string gioitinh = "";
                            if (rdnam.Checked == true)
                            {
                                rdnu.Checked = false;
                                gioitinh = "Nam";
                            }
                            if (rdnu.Checked == true)
                            {
                                rdnam.Checked = false;
                                gioitinh = "Nữ";
                            }
                            string dantoc = cbbdantoc.Text.Trim();
                            string tongiao = cbbtongiao.Text.Trim();
                            string cmnd = txtcmnd.Text.Trim();
                            string diachi = txtdiachi.Text.Trim();
                            string quequan = txtquequan.Text.Trim();
                            string sdt = txtsdt.Text.Trim();
                            string matd = cbbmatd.Text.Trim();
                            string nn = cbbnn.Text.Trim();
                            string trinhdosudung = "";
                            if (cbt.Checked == true)
                            {
                                cbtb.Checked = false;
                                cby.Checked = false;
                                trinhdosudung = "Tốt";
                            }
                            if (cbtb.Checked == true)
                            {
                                cbt.Checked = false;
                                cby.Checked = false;
                                trinhdosudung = "Trung bình";
                            }
                            if (cby.Checked == true)
                            {
                                cbt.Checked = false;
                                cbtb.Checked = false;
                                trinhdosudung = "Yếu";
                            }
                            string macv = cbbmacv.Text.Trim();
                            string mapb = cbbmapb.Text.Trim();
                            string ngaycongtac = dtpngaycongtac.Text.Trim();
                            string anh = txtanh.Text.Trim();
                            string sqlsua = "update nhanvien set hoten = N'" + hoten + "',ngaysinh = '" + ngaysinh + "',gioitinh = N'" + gioitinh + "',dantoc = N'" + dantoc + "' ,tongiao = N'" + tongiao + "',socmnd = N'" + cmnd + "',diachi = N'" + diachi + "',quequan = N'" + quequan + "',sodienthoai = N'" + sdt + "',matd = N'" + matd + "',ngoaingu = N'" + nn + "',trinhdosudung = N'" + trinhdosudung + "',macv = N'" + macv + "',mapb = N'" + mapb + "',ngaycongtac = N'" + ngaycongtac + "',anh = N'" + anh + "' where manv = '" + manv + "'";
                            try
                            {
                                SqlCommand cmd = new SqlCommand(sqlsua, con);
                                cmd.ExecuteNonQuery();
                                hienthidulieulendatagridview();
                                MessageBox.Show("Sửa thành công !", "", MessageBoxButtons.OK, MessageBoxIcon.None);
                            }
                            catch
                            {
                                MessageBox.Show("Không sửa được");
                            }
                        }
                        else if (h == DialogResult.Cancel)
                        {
                        }
                    }
                }
            }
        }

        private void btnxoahsnv_Click(object sender, EventArgs e)
        {
            txtmanv.Enabled = false;
            btnsuahsnv.Enabled = false;
            btnxoahsnv.Enabled = false;
            btnluuhsnv.Enabled = false;
            DialogResult h = MessageBox.Show
              ("Bạn có chắc muốn xóa thông tin nhân viên này không?", " ⚠️Cảnh Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (h == DialogResult.OK)
            {

                btnluuhsnv.Enabled = true;
                string manv = txtmanv.Text.Trim();
                string sqlxoa = "delete nhanvien where manv='" + manv + "'";
                try
                {
                    SqlCommand cmd = new SqlCommand(sqlxoa, con);
                    cmd.ExecuteNonQuery();
                    hienthidulieulendatagridview();
                    MessageBox.Show("Xóa thành công !", "", MessageBoxButtons.OK, MessageBoxIcon.None);
                }
                catch
                {
                    MessageBox.Show("Không xóa được");
                }
            }
            else if (h == DialogResult.Cancel)
            {
            }
        }

        private void btnmoihsnv_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void btnluuhsnv_Click(object sender, EventArgs e)
        {

            txtmanv.Enabled = false;
            btnsuahsnv.Enabled = false;
            btnxoahsnv.Enabled = false;
            btnluuhsnv.Enabled = false;
            if (string.IsNullOrWhiteSpace(txtmanv.Text) || string.IsNullOrWhiteSpace(txthoten.Text) || string.IsNullOrWhiteSpace(txtcmnd.Text) || string.IsNullOrWhiteSpace(txtdiachi.Text) || string.IsNullOrWhiteSpace(txtquequan.Text))
            {
                MessageBox.Show("Vui lòng nhập  đầy đủ thông tin dữ liệu !");
            }
            else
            {
                if (rdnam.Checked == false && rdnu.Checked == false)
                {
                    MessageBox.Show("Vui lòng nhập  chọn giới tính !");
                }
                else
                {
                    if (cbt.Checked == false && cbtb.Checked == false && cby.Checked == false)
                    {
                        MessageBox.Show("Vui lòng nhập  chọn trình độ sử dụng ngoại ngữ !");
                    }
                    else
                    {
                        string manv = txtmanv.Text.Trim();
                        string hoten = txthoten.Text.Trim();
                        string ngaysinh = dtpngaysinh.Text.Trim();
                        string gioitinh = "";
                        if (rdnam.Checked == true)
                        {
                            rdnu.Checked = false;
                            gioitinh = "Nam";
                        }
                        if (rdnu.Checked == true)
                        {
                            rdnam.Checked = false;
                            gioitinh = "Nữ";
                        }
                        string dantoc = cbbdantoc.Text.Trim();
                        string tongiao = cbbtongiao.Text.Trim();
                        string cmnd = txtcmnd.Text.Trim();
                        string diachi = txtdiachi.Text.Trim();
                        string quequan = txtquequan.Text.Trim();
                        string sdt = txtsdt.Text.Trim();
                        string matd = cbbmatd.Text.Trim();
                        string nn = cbbnn.Text.Trim();
                        string trinhdosudung = "";
                        if (cbt.Checked == true)
                        {
                            cbtb.Checked = false;
                            cby.Checked = false;
                            trinhdosudung = "Tốt";
                        }
                        if (cbtb.Checked == true)
                        {
                            cbt.Checked = false;
                            cby.Checked = false;
                            trinhdosudung = "Trung bình";
                        }
                        if (cby.Checked == true)
                        {
                            cbt.Checked = false;
                            cbtb.Checked = false;
                            trinhdosudung = "Yếu";
                        }
                        string macv = cbbmacv.Text.Trim();
                        string mapb = cbbmapb.Text.Trim();
                        string ngaycongtac = dtpngaycongtac.Text.Trim();
                        string anh = txtanh.Text.Trim();
                        string sql = "Select anh from nhanvien ";
                        txtanh.Text = GetFieldValues(sql);

                        string sqlthem = "insert into nhanvien values('" + manv + "',N'" + hoten + "',N'" + ngaysinh + "',N'" + gioitinh + "',N'" + dantoc + "',N'" + tongiao + "','" + cmnd + "',N'" + diachi + "',N'" + quequan + "',N'" + sdt + "','" + matd + "',N'" + nn + "',N'" + trinhdosudung + "','" + macv + "','" + mapb + "','" + ngaycongtac + "','" + anh + "')";
                        try
                        {

                            SqlCommand cmd = new SqlCommand(sqlthem, con);
                            cmd.ExecuteNonQuery();
                            hienthidulieulendatagridview();
                            MessageBox.Show("Lưu Thông tin thành công !", "", MessageBoxButtons.OK, MessageBoxIcon.None);
                        }
                        catch
                        {
                            MessageBox.Show("Lưu không thành công !");
                        }
                        //  reset();
                    }
                }
            }
        }

        private void btninl_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Export Excel";
            saveFileDialog.Filter = "Excel (*.xlsx)|*.xlsx|Excel 2003 (*.xls)|*.xls ";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Export(saveFileDialog.FileName);
                    MessageBox.Show("Xuất File thành công !");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xuất File không thành công ! Lỗi :" + ex.Message);
                }
            }
        }

        private void dtg_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtmanv.Enabled = false;
            btnluuhsnv.Enabled = true;
            btnxoahsnv.Enabled = true;
            btnsuahsnv.Enabled = true;
            int i;
            i = dtg.CurrentRow.Index;
            txtmanv.Text = dtg.Rows[i].Cells[0].Value.ToString();
            txthoten.Text = dtg.Rows[i].Cells[1].Value.ToString();
            dtpngaysinh.Text = dtg.Rows[i].Cells[2].Value.ToString();

            DataGridViewRow row = dtg.Rows[e.RowIndex];
            string dataToShow = row.Cells["gioitinh"].Value.ToString();

            // Hiển thị dữ liệu lên RadioButton
            if (dataToShow == "Nam")
            {
                rdnam.Checked = true;
            }
            else if (dataToShow == "Nữ")
            {
                rdnu.Checked = true;
            }

            cbbdantoc.Text = dtg.Rows[i].Cells[4].Value.ToString();
            cbbtongiao.Text = dtg.Rows[i].Cells[5].Value.ToString();
            txtcmnd.Text = dtg.Rows[i].Cells[6].Value.ToString();
            txtdiachi.Text = dtg.Rows[i].Cells[7].Value.ToString();
            txtquequan.Text = dtg.Rows[i].Cells[8].Value.ToString();
            txtsdt.Text = dtg.Rows[i].Cells[9].Value.ToString();
            cbbmatd.Text = dtg.Rows[i].Cells[10].Value.ToString();
            cbbnn.Text = dtg.Rows[i].Cells[11].Value.ToString();
            DataGridViewRow row2 = dtg.Rows[e.RowIndex];
            string dataToShow2 = row2.Cells["trinhdosudung"].Value.ToString();

            // Hiển thị dữ liệu lên RadioButton
            if (dataToShow2 == "Tốt")
            {
                cbt.Checked = true;
                cbtb.Checked = false;
                cby.Checked = false;
            }
            else if (dataToShow2 == "Trung bình")
            {
                cbt.Checked = false;
                cbtb.Checked = true;
                cby.Checked = false;
            }
            else if (dataToShow2 == "Yếu")
            {
                cbt.Checked = false;
                cby.Checked = true;
                cbtb.Checked = false;
            }

            cbbmacv.Text = dtg.Rows[i].Cells[13].Value.ToString();
            cbbmapb.Text = dtg.Rows[i].Cells[14].Value.ToString();
            dtpngaycongtac.Text = dtg.Rows[i].Cells[15].Value.ToString();
            string sql = "Select anh from nhanvien where manv=N'" + txtmanv.Text + "'";
            txtanh.Text = GetFieldValues(sql);
            picanh.Image = Image.FromFile(txtanh.Text);
            txtanh.Text = dtg.Rows[i].Cells[16].Value.ToString();
        }
        private void reset()
        {
            txtmanv.Enabled = false;
            btnsuahsnv.Enabled = false;
            btnxoahsnv.Enabled = false;
            btnluuhsnv.Enabled = false;
            txtmanv.Text = "";
            txthoten.Text = "";
            dtpngaysinh.Text = "";
            rdnam.Checked = false;
            rdnu.Checked = false;
            cbbdantoc.SelectedIndex = 0;
            cbbtongiao.SelectedIndex = 0;
            txtcmnd.Text = "";
            txtdiachi.Text = "";
            txtquequan.Text = "";
            txtsdt.Text = "";
            cbbmatd.SelectedIndex = 0;
            cbbnn.SelectedIndex = 0;
            cbt.Checked = false;
            cbtb.Checked = false;
            cby.Checked = false;
            cbbmacv.SelectedIndex = 0;
            cbbmapb.SelectedIndex = 0;
            dtpngaycongtac.Text = "";
            txtanh.Text = "";
            picanh.Image = Properties.Resources.profile_image;

        }

        private void picadd_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlgOpen = new OpenFileDialog();
            dlgOpen.Filter = "Bitmap(*.bmp)|*.bmp|JPEG(*.jpg)|*.jpg|GIF(*.gif)|*.gif|All files(*.*)|*.*";
            dlgOpen.FilterIndex = 2;
            dlgOpen.Title = "Chọn ảnh minh hoạ cho sản phẩm";
            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                picanh.Image = Image.FromFile(dlgOpen.FileName);
                txtanh.Text = dlgOpen.FileName;
            }
        }

        private void cbt_CheckedChanged(object sender, EventArgs e)
        {
            if (cbt.Checked)
            {
                // Đặt hình ảnh mới cho PictureBox khi CheckBox được check
                cbtb.Checked = false;
                cby.Checked = false;
                pictureBox2.Image = Properties.Resources.happyfacechange; // Thay thế bằng hình ảnh mong muốn
            }
            else
            {
                // Đặt hình ảnh khác cho PictureBox khi CheckBox không được check
                pictureBox2.Image = Properties.Resources.happy_face; // Thay thế bằng hình ảnh mong muốn
            }
        }

        private void cbtb_CheckedChanged(object sender, EventArgs e)
        {
            if (cbtb.Checked)
            {
                cbt.Checked = false;
                cby.Checked = false;
                // Đặt hình ảnh mới cho PictureBox khi CheckBox được check
                pictureBox3.Image = Properties.Resources.neutralfacechange; // Thay thế bằng hình ảnh mong muốn
            }
            else
            {
                // Đặt hình ảnh khác cho PictureBox khi CheckBox không được check
                pictureBox3.Image = Properties.Resources.neutral_face; // Thay thế bằng hình ảnh mong muốn
            }
        }

        private void cby_CheckedChanged(object sender, EventArgs e)
        {
            if (cby.Checked)
            {
                cbt.Checked = false;
                cbtb.Checked = false;
                // Đặt hình ảnh mới cho PictureBox khi CheckBox được check
                pictureBox4.Image = Properties.Resources.sadfacechange; // Thay thế bằng hình ảnh mong muốn
            }
            else
            {
                // Đặt hình ảnh khác cho PictureBox khi CheckBox không được check
                pictureBox4.Image = Properties.Resources.sad_face; // Thay thế bằng hình ảnh mong muốn
            }
        }
        // export excel
        private void Export(string path)
        {

            Excel.Application application = new Excel.Application();
            application.Application.Workbooks.Add(Type.Missing);
            for (int i = 0; i < dtg.Columns.Count; i++)
            {
                application.Cells[1, i + 1] = dtg.Columns[i].HeaderText;
            }
            for (int i = 0; i < dtg.Rows.Count; i++)
            {
                for (int j = 0; j < dtg.Columns.Count; j++)
                {
                    application.Cells[i + 2, j + 1] = dtg.Rows[i].Cells[j].Value;
                }
            }
            application.Columns.AutoFit();
            application.ActiveWorkbook.SaveCopyAs(path);
            application.ActiveWorkbook.Saved = true;
        }

        private void btnthemhsnv_MouseEnter(object sender, EventArgs e)
        {
            btnthemhsnv.ForeColor = Color.Black;
            btnthemhsnv.BackColor = Color.White;

        }

        private void btnthemhsnv_MouseLeave(object sender, EventArgs e)
        {

            btnthemhsnv.ForeColor = Color.White;
            btnthemhsnv.BackColor = Color.Black;
        }

        private void btnsuahsnv_MouseEnter(object sender, EventArgs e)
        {
            btnsuahsnv.ForeColor = Color.Black;
            btnsuahsnv.BackColor = Color.White;
        }

        private void btnsuahsnv_MouseLeave(object sender, EventArgs e)
        {
            btnsuahsnv.ForeColor = Color.White;
            btnsuahsnv.BackColor = Color.Black;
        }

        private void btnxoahsnv_MouseEnter(object sender, EventArgs e)
        {
            btnxoahsnv.ForeColor = Color.Black;
            btnxoahsnv.BackColor = Color.White;
        }

        private void btnxoahsnv_MouseLeave(object sender, EventArgs e)
        {
            btnxoahsnv.ForeColor = Color.White;
            btnxoahsnv.BackColor = Color.Black;
        }

        private void btnmoihsnv_MouseEnter(object sender, EventArgs e)
        {
            btnmoihsnv.ForeColor = Color.Black;
            btnmoihsnv.BackColor = Color.White;
        }

        private void btnmoihsnv_MouseLeave(object sender, EventArgs e)
        {
            btnmoihsnv.ForeColor = Color.White;
            btnmoihsnv.BackColor = Color.Black;
        }

        private void btnluuhsnv_MouseEnter(object sender, EventArgs e)
        {
            btnluuhsnv.ForeColor = Color.Black;
            btnluuhsnv.BackColor = Color.White;
        }

        private void btnluuhsnv_MouseLeave(object sender, EventArgs e)
        {
            btnluuhsnv.ForeColor = Color.White;
            btnluuhsnv.BackColor = Color.Black;
        }

        private void btninl_MouseEnter(object sender, EventArgs e)
        {
            btninl.ForeColor = Color.Black;
            btninl.BackColor = Color.White;
        }

        private void btninl_MouseLeave(object sender, EventArgs e)
        {
            btninl.ForeColor = Color.White;
            btninl.BackColor = Color.Black;
        }
        // import excel 
        /*  private void Import(string path)
          {
              using (ExcelPackage excelPackage = new ExcelPackage(new FileInfo(path)))
              {
                  ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets[0];
                  DataTable dataTable = new DataTable();
                  for (int i = excelWorksheet.Dimension.Start.Column; i <= excelWorksheet.Dimension.End.Column; i++)
                  {
                      dataTable.Columns.Add(excelWorksheet.Cells[1, i].Value.ToString());
                  }
                  for (int i = excelWorksheet.Dimension.Start.Row + 1; i <= excelWorksheet.Dimension.End.Row; i++)
                  {
                      List<string> listRow = new List<string>();
                      for (int j = excelWorksheet.Dimension.Start.Column; j <= excelWorksheet.Dimension.End.Column; j++)
                      {
                          listRow.Add(excelWorksheet.Cells[i, j].Value.ToString());
                      }
                      dataTable.Rows.Add(listRow.ToArray());

                  }
                  dtg.DataSource = dataTable;
              }
          }*/

        /*  private void btnimport_Click(object sender, EventArgs e)
       {
         /*  OpenFileDialog openFileDialog = new OpenFileDialog();
           openFileDialog.Title = "Import Excel";
           openFileDialog.Filter = "Excel (*.xlsx)|*.xlsx|Excel 2003 (*.xls)|*.xls ";
           if (openFileDialog.ShowDialog() == DialogResult.OK)
           {
               try
               {
                   Import(openFileDialog.FileName);
                   MessageBox.Show("Nhập File thành công !");
               }
               catch (Exception ex)
               {
                   MessageBox.Show("Nhập File không thành công ! Lỗi :" + ex.Message);
               }
           }
       }*/


    }
}
