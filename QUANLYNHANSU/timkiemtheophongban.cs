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
    public partial class timkiemtheophongban : Form
    {
        public timkiemtheophongban()
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
            dtg.Columns[0].HeaderText = "Mã Nhân Viên";
            dtg.Columns[1].HeaderText = "Họ Tên ";
            dtg.Columns[2].HeaderText = "Quê Quán ";
            dtg.Columns[3].HeaderText = "Số Điện Thoại";
            dtg.Columns[4].HeaderText = "Phòng Ban ";
            dtg.Columns[5].HeaderText = "Chức Vụ";
            dtg.Columns[6].HeaderText = "Trình Độ";


            dtg.Columns[0].Width = 100;
            dtg.Columns[1].Width = 220;
            dtg.Columns[2].Width = 180;
            dtg.Columns[3].Width = 180;
            dtg.Columns[4].Width = 200;
            dtg.Columns[5].Width = 180;
            dtg.Columns[6].Width = 180;
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

            string sql = "select nhanvien.manv,nhanvien.hoten,nhanvien.quequan,nhanvien.sodienthoai,phongban.phongban,chucvu.chucvu,trinhdo.trinhdo FROM phongban,chucvu,nhanvien,trinhdo where phongban.mapb = nhanvien.mapb and nhanvien.macv = chucvu.macv and nhanvien.matd = trinhdo.matd ";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dtg.DataSource = dt;
            dinhdangdulieutrendata();
        }
        private void timkiemtheophongban_Load(object sender, EventArgs e)
        {
            ketNoicsdl();
            hienthidulieulendatagridview();
            cbb.SelectedIndex = 0;
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

                if (selectedValue == "Phòng Ban")
                {
                    string phongban = txttimkiem.Text.Trim();
                    string sqltimkiem = "select nhanvien.manv,nhanvien.hoten,nhanvien.quequan,nhanvien.sodienthoai,phongban.phongban,chucvu.chucvu,trinhdo.trinhdo from phongban,nhanvien,chucvu,trinhdo where phongban.mapb = nhanvien.mapb and nhanvien.macv = chucvu.macv and nhanvien.matd = trinhdo.matd  and phongban.phongban like N'%" + phongban + "%'";
                    try
                    {
                        SqlDataAdapter da = new SqlDataAdapter(sqltimkiem, con);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dtg.DataSource = dt;
                        dtg.Columns[5].DefaultCellStyle.BackColor = Color.White;
                        dtg.Columns[6].DefaultCellStyle.BackColor = Color.White;
                        dtg.Columns[4].DefaultCellStyle.BackColor = Color.Yellow; // Đổi màu cho cột 1
                        dinhdangdulieutrendata();

                    }
                    catch
                    {
                        MessageBox.Show("Không tim thấy mã trong bang dữ liệu");
                    }
                }
                else if (selectedValue == "Chức Vụ")
                {
                    string chucvu = txttimkiem.Text.Trim();
                    string sqltimkiem = "select nhanvien.manv,nhanvien.hoten,nhanvien.quequan,nhanvien.sodienthoai,phongban.phongban,chucvu.chucvu,trinhdo.trinhdo from phongban,nhanvien,chucvu,trinhdo where phongban.mapb = nhanvien.mapb and nhanvien.macv = chucvu.macv and nhanvien.matd = trinhdo.matd  and chucvu.chucvu like N'%" + chucvu + "%' ";
                    try
                    {
                        SqlDataAdapter da = new SqlDataAdapter(sqltimkiem, con);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dtg.DataSource = dt;
                        dtg.Columns[4].DefaultCellStyle.BackColor = Color.White;
                        dtg.Columns[6].DefaultCellStyle.BackColor = Color.White;
                        dtg.Columns[5].DefaultCellStyle.BackColor = Color.Yellow; // Đổi màu cho cột 1
                        dinhdangdulieutrendata();

                    }
                    catch
                    {
                        MessageBox.Show("Không tim thấy mã trong bang dữ liệu");
                    }
                }
                else if (selectedValue == "Trình Độ")
                {
                    string trinhdo = txttimkiem.Text.Trim();
                    string sqltimkiem = "select nhanvien.manv,nhanvien.hoten,nhanvien.quequan,nhanvien.sodienthoai,phongban.phongban,chucvu.chucvu,trinhdo.trinhdo from phongban,nhanvien,chucvu,trinhdo where phongban.mapb = nhanvien.mapb and nhanvien.macv = chucvu.macv and nhanvien.matd = trinhdo.matd   and trinhdo.trinhdo like N'%" + trinhdo + "%' ";
                    try
                    {
                        SqlDataAdapter da = new SqlDataAdapter(sqltimkiem, con);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dtg.DataSource = dt;
                        dtg.Columns[4].DefaultCellStyle.BackColor = Color.White;
                        dtg.Columns[5].DefaultCellStyle.BackColor = Color.White;
                        dtg.Columns[6].DefaultCellStyle.BackColor = Color.Yellow; // Đổi màu cho cột 1
                        dinhdangdulieutrendata();

                    }
                    catch
                    {
                        MessageBox.Show("Không tim thấy mã trong bang dữ liệu");
                    }
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
