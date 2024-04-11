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

namespace QUANLYNHANSU
{
    public partial class chamcong : Form
    {
        public chamcong()
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
            dtg.Columns[0].HeaderText = "Mã Chấm Công ";
            dtg.Columns[1].HeaderText = "Mã Nhân viên ";
            dtg.Columns[2].HeaderText = "Thời Gian ";
            dtg.Columns[3].HeaderText = "Giờ Vào ";
            dtg.Columns[4].HeaderText = "Giờ Ra  ";
            dtg.Columns[5].HeaderText = "Số Ngày Làm ";
            dtg.Columns[6].HeaderText = "Số Ngày Nghỉ ";

            dtg.Columns[0].Width = 100;
            dtg.Columns[1].Width = 100;
            dtg.Columns[2].Width = 100;
            dtg.Columns[3].Width = 100;
            dtg.Columns[4].Width = 100;
            dtg.Columns[5].Width = 100;
            dtg.Columns[6].Width = 100;

            dtg.EnableHeadersVisualStyles = false;

            dtg.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 0, 0);
            dtg.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(248, 248, 255);
            dtg.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtg.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 14, FontStyle.Bold);
            dtg.Font = new Font("Times New Roman", 12, FontStyle.Bold);
            dtg.DefaultCellStyle.BackColor = Color.FromArgb(248, 248, 255);
            dtg.DefaultCellStyle.ForeColor = Color.FromArgb(0, 0, 0);
        }
        // hien thi du lieu tren datagridView 
        private void hienthidulieulendatagridview()
        {

            string sql = "SELECT * FROM chamcong";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dtg.DataSource = dt;
            dinhdangdulieutrendata();
        }
        private void chamcong_Load(object sender, EventArgs e)
        {
            ketNoicsdl();
            hienthidulieulendatagridview();
            loaddulieucombomanv();
            txtmacc.Enabled = false;
            cbbmanv.Enabled = false;
            btnsuacc.Enabled = false;
            btnxoacc.Enabled = false;
            btnluucc.Enabled = false;
            //
            // Đặt DateTimePicker vào ngày hiện tại
            dateTimePicker1.Value = DateTime.Now;
            // Load các ô checkbox dựa trên tháng được chọn
            LoadCheckBoxes();
        }
        private void loaddulieucombomanv()
        {
            string sql = "SELECT manv FROM nhanvien";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cbbmanv.DataSource = dt;
            cbbmanv.ValueMember = dt.Columns["manv"].ToString();
            cbbmanv.DisplayMember = dt.Columns["manv"].ToString();
        }

        private void btnthemcc_Click(object sender, EventArgs e)
        {
            txtmacc.Enabled = true;
            cbbmanv.Enabled = true;
            btnsuacc.Enabled = false;
            btnxoacc.Enabled = false;
            btnluucc.Enabled = true;
        }

        private void btnsuacc_Click(object sender, EventArgs e)
        {
            txtmacc.Enabled = false;
            btnsuacc.Enabled = false;
            btnxoacc.Enabled = false;
            btnluucc.Enabled = false;
            if (string.IsNullOrWhiteSpace(txtmacc.Text) || string.IsNullOrWhiteSpace(txtsongaylam.Text) || string.IsNullOrWhiteSpace(txtsongaynghi.Text) )
            {
                MessageBox.Show("Vui lòng nhập  đầy đủ thông tin dữ liệu !");
            }
            else
            {
                DialogResult h = MessageBox.Show
       ("Bạn có chắc muốn sửa thông tin chấm công này không?", "Cảnh Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (h == DialogResult.OK)
                {
                    string macc = txtmacc.Text.Trim();
                    string manv = cbbmanv.Text.Trim();
                    string thoigian = dateTimePicker1.Text.Trim();
                    string giovao = dtpgiovao.Text.Trim();
                    string giora = dtpgiora.Text.Trim();
                    int songaylam = int.Parse(txtsongaylam.Text.Trim());
                    int songaynghi = int.Parse(txtsongaynghi.Text.Trim());
                    string sqlsua = "update chamcong set thoigian = '" + thoigian + "',giovao = '" + giovao + "',giora = '" + giora + "',songaylam = '" + songaylam + "',songaynghi = '" + songaynghi + "' where manv = N'" + manv + "' and macc = '" + macc + "'";
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

        private void btnxoacc_Click(object sender, EventArgs e)
        {
            DialogResult h = MessageBox.Show
           ("Bạn có chắc muốn xóa thông tin trình độ này không?", "Cảnh Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (h == DialogResult.OK)
            {
                txtmacc.Enabled = false;
                cbbmanv.Enabled = false;
                btnsuacc.Enabled = false;
                btnxoacc.Enabled = false;
                btnluucc.Enabled = false;
                string macc = txtmacc.Text.Trim();
                string sqlxoa = "delete chamcong where macc='" + macc + "'";
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

        private void btnmoicc_Click(object sender, EventArgs e)
        {
            txtmacc.Text = "";
            txtsongaylam.Text = "";
            dtpgiora.Text = "";
            dtpgiovao.Text = "";
            txtsongaynghi.Text = "";
            cbbmanv.SelectedIndex= 0;
            dateTimePicker1.Value = DateTime.Now;
        }

        private void btnluucc_Click(object sender, EventArgs e)
        {
            txtmacc.Enabled = false;
            cbbmanv.Enabled = false;
            btnsuacc.Enabled = false;
            btnxoacc.Enabled = false;
            btnluucc.Enabled = false;
            if (string.IsNullOrWhiteSpace(txtmacc.Text) || string.IsNullOrWhiteSpace(txtsongaylam.Text) || string.IsNullOrWhiteSpace(txtsongaynghi.Text))
            {
                MessageBox.Show("Vui lòng nhập  đầy đủ thông tin dữ liệu !");
            }
            else
            {
                string macc = txtmacc.Text.Trim();
                string manv = cbbmanv.Text.Trim();
                string thoigian = dateTimePicker1.Text.Trim();
                string giovao = dtpgiovao.Text.Trim();
                string giora = dtpgiora.Text.Trim();
                int songaylam = int.Parse(txtsongaylam.Text.Trim());
                int songaynghi = int.Parse(txtsongaynghi.Text.Trim());
                string sqlthem = "insert into chamcong values('" + macc + "',N'" + manv + "',N'" + thoigian + "',N'" + giovao + "',N'" + giora + "',N'" + songaylam + "',N'" + songaynghi + "')";
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
            }
        }

        private void dtg_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            /* txtmacc.Enabled = false;
            cbbmanv.Enabled = false;*/
            btnluucc.Enabled = true;
            btnxoacc.Enabled = true;
            btnsuacc.Enabled = true;
            int i;
            i = dtg.CurrentRow.Index;
            txtmacc.Text = dtg.Rows[i].Cells[0].Value.ToString();
            cbbmanv.Text = dtg.Rows[i].Cells[1].Value.ToString();
            dateTimePicker1.Text = dtg.Rows[i].Cells[2].Value.ToString();
            dtpgiovao.Text = dtg.Rows[i].Cells[3].Value.ToString();
            dtpgiora.Text = dtg.Rows[i].Cells[4].Value.ToString();
            txtsongaylam.Text = dtg.Rows[i].Cells[5].Value.ToString();
            txtsongaynghi.Text = dtg.Rows[i].Cells[6].Value.ToString();
        }
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

        private void cbbmanv_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "select chamcong.macc from chamcong,nhanvien where chamcong.manv=nhanvien.manv and nhanvien.manv='" + cbbmanv.SelectedValue + "'";
            txtmacc.Text = GetFieldValues(sql);
            string sqlngay = "select chamcong.thoigian from chamcong,nhanvien where chamcong.manv=nhanvien.manv and nhanvien.manv='" + cbbmanv.SelectedValue + "'";
            dateTimePicker1.Text = GetFieldValues(sqlngay);
            string sqlgiovao = "select chamcong.giovao from chamcong,nhanvien where chamcong.manv=nhanvien.manv and nhanvien.manv='" + cbbmanv.SelectedValue + "'";
            dtpgiovao.Text = GetFieldValues(sqlgiovao);
            string sqlgiora = "select chamcong.giora from chamcong,nhanvien where chamcong.manv=nhanvien.manv and nhanvien.manv='" + cbbmanv.SelectedValue + "'";
            dtpgiora.Text = GetFieldValues(sqlgiora);
            string sqlngaylamviec = "select chamcong.songaylam from chamcong,nhanvien where chamcong.manv=nhanvien.manv and nhanvien.manv='" + cbbmanv.SelectedValue + "'";
            txtsongaylam.Text = GetFieldValues(sqlngaylamviec);
            string sqlngaynghiviec = "select chamcong.songaynghi from chamcong,nhanvien where chamcong.manv=nhanvien.manv and nhanvien.manv='" + cbbmanv.SelectedValue + "'";
            txtsongaynghi.Text = GetFieldValues(sqlngaynghiviec);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            // Reload các ô checkbox khi tháng thay đổi
            LoadCheckBoxes();
        }

        private void LoadCheckBoxes()
        {
            // Xóa các ô checkbox hiện có
            groupBox1.Controls.Clear();

            // Lấy thông tin về tháng và năm từ DateTimePicker
            int nam = dateTimePicker1.Value.Year;
            int thang = dateTimePicker1.Value.Month;

            // Lấy số ngày trong tháng được chọn
            int soNgayTrongThang = DateTime.DaysInMonth(nam, thang);

            // Tính toán số dòng và số cột dựa trên 5 cột và 5 dòng
            int soDong = 5;
            int soCot = (int)Math.Ceiling((double)soNgayTrongThang / soDong);

            // Tạo các ô checkbox cho mỗi ngày và sắp xếp thành 5 cột và 5 dòng
            int index = 1;
            for (int dong = 0; dong < soDong; dong++)
            {
                for (int cot = 0; cot < soCot; cot++)
                {
                    if (index > soNgayTrongThang)
                        break;

                    CheckBox checkBox = new CheckBox();
                    checkBox.Text = "Ngày " + index.ToString();
                    checkBox.AutoSize = true;
                    checkBox.Location = new System.Drawing.Point(10 + cot * 80, 20 + dong * 25); // Điều chỉnh tọa độ X và Y nếu cần thiết

                    // Chọn tất cả các ô checkbox trừ thứ 2 đến thứ 6
                    DateTime ngayHienTai = new DateTime(nam, thang, index);
                    if (ngayHienTai.DayOfWeek != DayOfWeek.Saturday && ngayHienTai.DayOfWeek != DayOfWeek.Sunday)
                    {
                        checkBox.Checked = true;
                    }

                    // Thêm sự kiện CheckedChanged cho mỗi ô checkbox
                    checkBox.CheckedChanged += CheckBox_CheckedChanged;

                    groupBox1.Controls.Add(checkBox);
                    index++;
                }
            }

            // Đếm và hiển thị số ngày được check và số ngày không được check
            UpdateCountText();
        }

        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Gọi hàm cập nhật dữ liệu khi trạng thái của ô checkbox thay đổi
            UpdateCountText();
        }

        private void UpdateCountText()
        {
            int soNgayDuocCheck = 0;
            foreach (Control control in groupBox1.Controls)
            {
                if (control is CheckBox checkBox && checkBox.Checked)
                {
                    soNgayDuocCheck++;
                }
            }

            int soNgayKhongDuocCheck = groupBox1.Controls.Count - soNgayDuocCheck;

            txtsongaylam.Text = $" {soNgayDuocCheck}";
            txtsongaynghi.Text = $" {soNgayKhongDuocCheck}";
        }

        private void btnthemcc_MouseEnter(object sender, EventArgs e)
        {
            btnthemcc.ForeColor = Color.Black;
            btnthemcc.BackColor = Color.White;
        }

        private void btnthemcc_MouseLeave(object sender, EventArgs e)
        {

            btnthemcc.ForeColor = Color.White;
            btnthemcc.BackColor = Color.Black;
        }

        private void btnsuacc_MouseEnter(object sender, EventArgs e)
        {
            btnsuacc.ForeColor = Color.Black;
            btnsuacc.BackColor = Color.White;
        }

        private void btnsuacc_MouseLeave(object sender, EventArgs e)
        {
            btnsuacc.ForeColor = Color.White;
            btnsuacc.BackColor = Color.Black;
        }

        private void btnxoacc_MouseEnter(object sender, EventArgs e)
        {
            btnxoacc.ForeColor = Color.Black;
            btnxoacc.BackColor = Color.White;
        }

        private void btnxoacc_MouseLeave(object sender, EventArgs e)
        {
            btnxoacc.ForeColor = Color.White;
            btnxoacc.BackColor = Color.Black;
        }

        private void btnmoicc_MouseEnter(object sender, EventArgs e)
        {
            btnmoicc.ForeColor = Color.Black;
            btnmoicc.BackColor = Color.White;
        }

        private void btnmoicc_MouseLeave(object sender, EventArgs e)
        {
            btnmoicc.ForeColor = Color.White;
            btnmoicc.BackColor = Color.Black;
        }

        private void btnluucc_MouseEnter(object sender, EventArgs e)
        {
            btnluucc.ForeColor = Color.Black;
            btnluucc.BackColor = Color.White;
        }

        private void btnluucc_MouseLeave(object sender, EventArgs e)
        {
            btnluucc.ForeColor = Color.White;
            btnluucc.BackColor = Color.Black;
        }
    }
}
