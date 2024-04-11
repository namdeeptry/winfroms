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
    public partial class timkiemtheomanhanvien : Form
    {
        public timkiemtheomanhanvien()
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
            dtg.Columns[0].HeaderText = "Mã Nhân Viên ";
            dtg.Columns[1].HeaderText = "Họ Tên ";
            dtg.Columns[2].HeaderText = "Giới Tính ";
            dtg.Columns[3].HeaderText = "Địa Chỉ ";
            dtg.Columns[4].HeaderText = "Số Điện Thoại";
            dtg.Columns[5].HeaderText = "Ngày Công Tác";

            dtg.Columns[0].Width = 190;
            dtg.Columns[1].Width = 190;
            dtg.Columns[2].Width = 200;
            dtg.Columns[3].Width = 200;
            dtg.Columns[4].Width = 200;
            dtg.Columns[5].Width = 200;
            dtg.EnableHeadersVisualStyles = false;

            dtg.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 0, 0);
            dtg.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(248, 248, 255);
            dtg.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtg.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            dtg.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            dtg.DefaultCellStyle.BackColor = Color.FromArgb(248, 248, 255);
            dtg.DefaultCellStyle.ForeColor = Color.FromArgb(0, 0, 0);
        }
        // hien thi du lieu tren datagridView 
        private void hienthidulieulendatagridview()
        {

            string sql = "SELECT nhanvien.manv,nhanvien.hoten,nhanvien.gioitinh,nhanvien.diachi,nhanvien.sodienthoai,nhanvien.ngaycongtac FROM nhanvien";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dtg.DataSource = dt;
            dinhdangdulieutrendata();
        }

        private void timkiemtheomanhanvien_Load(object sender, EventArgs e)
        {
            ketNoicsdl();
            hienthidulieulendatagridview();
            cbb.SelectedIndex = 0;
            dtp.Hide();
            txttimkiem.Show();
        }

        private void txttimkiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txttimkiem.Focus();
            }
        }

        private void pictimkiem_Click(object sender, EventArgs e)
        {
            if (cbb.SelectedItem != null)
            {
                string selectedValue = cbb.SelectedItem?.ToString();

                if (selectedValue == "Mã Nhân Viên")
                {
                    /*txttimkiem.Show();
                    dtp.Hide();*/
                    string manv = txttimkiem.Text.Trim();
                    string sqltimkiem = "SELECT nhanvien.manv,nhanvien.hoten,nhanvien.gioitinh,nhanvien.diachi,nhanvien.sodienthoai,nhanvien.ngaycongtac FROM nhanvien where nhanvien.manv like '%" + manv + "%'";
                    try
                    {
                        SqlDataAdapter da = new SqlDataAdapter(sqltimkiem, con);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dtg.DataSource = dt;
                        dtg.Columns[5].DefaultCellStyle.BackColor = Color.White;
                        dtg.Columns[1].DefaultCellStyle.BackColor = Color.White;
                        dtg.Columns[0].DefaultCellStyle.BackColor = Color.Yellow; // Đổi màu cho cột 1
                        dinhdangdulieutrendata();

                    }
                    catch
                    {
                        //   MessageBox.Show("Không tim thấy mã trong bang dữ liệu");
                    }
                }
                else if (selectedValue == "Họ Tên")
                {
                    /* txttimkiem.Show();
                     dtp.Hide();*/
                    string hoten = txttimkiem.Text.Trim();
                    string sqltimkiem = "SELECT nhanvien.manv,nhanvien.hoten,nhanvien.gioitinh,nhanvien.diachi,nhanvien.sodienthoai,nhanvien.ngaycongtac FROM nhanvien where nhanvien.hoten like N'%" + hoten + "%' ";
                    try
                    {
                        SqlDataAdapter da = new SqlDataAdapter(sqltimkiem, con);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dtg.DataSource = dt;
                        dtg.Columns[5].DefaultCellStyle.BackColor = Color.White;
                        dtg.Columns[0].DefaultCellStyle.BackColor = Color.White;
                        dtg.Columns[1].DefaultCellStyle.BackColor = Color.Yellow; // Đổi màu cho cột 1
                        dinhdangdulieutrendata();

                    }
                    catch
                    {
                        //  MessageBox.Show("Không tim thấy mã trong bang dữ liệu");
                    }
                }
                else if (selectedValue == "Ngày Làm Việc")
                {
                    /*txttimkiem.Hide();
                    dtp.Show();*/
                    string ngaylamviec = dtp.Text.Trim().ToString();
                    string sqltimkiem = "SELECT nhanvien.manv,nhanvien.hoten,nhanvien.gioitinh,nhanvien.diachi,nhanvien.sodienthoai,nhanvien.ngaycongtac FROM nhanvien where nhanvien.ngaycongtac = '" + ngaylamviec + "' ";
                    try
                    {
                        SqlDataAdapter da = new SqlDataAdapter(sqltimkiem, con);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dtg.DataSource = dt;
                        dtg.Columns[1].DefaultCellStyle.BackColor = Color.White;
                        dtg.Columns[0].DefaultCellStyle.BackColor = Color.White;
                        dtg.Columns[5].DefaultCellStyle.BackColor = Color.Yellow; // Đổi màu cho cột 1
                        dinhdangdulieutrendata();

                    }
                    catch
                    {
                        // MessageBox.Show("Không tim thấy kết quả trong bang dữ liệu");
                    }
                }
            }
        }

        private void cbb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbb.SelectedItem != null)
            {
                string selectedValue = cbb.SelectedItem.ToString();

                if (selectedValue == "Mã Nhân Viên")
                {
                    txttimkiem.Show();
                    dtp.Hide();
                    panel3.Show();

                }
                else if (selectedValue == "Họ Tên")
                {
                    txttimkiem.Show();
                    panel3.Show();
                    dtp.Hide();

                }
                else if (selectedValue == "Ngày Làm Việc")
                {
                    txttimkiem.Hide();
                    dtp.Show();
                    panel3.Hide();
                }
            }
        }

        private void pictimkiem_MouseEnter(object sender, EventArgs e)
        {
            pictimkiem.Width = 62;
            pictimkiem.Height = 32;
        }

        private void pictimkiem_MouseLeave(object sender, EventArgs e)
        {
            pictimkiem.Width = 58;
            pictimkiem.Height = 24;
        }
    }
}
