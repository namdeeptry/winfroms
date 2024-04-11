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
    public partial class phongban : Form
    {
        public phongban()
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
            dtg.Columns[0].HeaderText = "Mã Phòng Ban";
            dtg.Columns[1].HeaderText = "Tên Phòng Ban ";

            dtg.Columns[0].Width = 100;
            dtg.Columns[1].Width = 250;
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

            string sql = "SELECT * FROM phongban";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dtg.DataSource = dt;
            dinhdangdulieutrendata();
        }

        private void btnthempb_Click(object sender, EventArgs e)
        {
            txtmapb.Enabled = true;
            btnsuapb.Enabled = false;
            btnxoapb.Enabled = false;
            btnluupb.Enabled = true;
        }

        private void btnsuapb_Click(object sender, EventArgs e)
        {

            txtmapb.Enabled = false;
            btnsuapb.Enabled = false;
            btnxoapb.Enabled = false;
            btnluupb.Enabled = false;
            if (string.IsNullOrWhiteSpace(txtmapb.Text) || string.IsNullOrWhiteSpace(txtphongban.Text))
            {
                MessageBox.Show("Vui lòng nhập  đầy đủ thông tin dữ liệu !");
            }
            else
            {
                DialogResult h = MessageBox.Show
               ("Bạn có chắc muốn sửa thông tin phòng ban này không?", "Cảnh Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (h == DialogResult.OK)
                {
                    string mapb = txtmapb.Text.Trim();
                    string phongban = txtphongban.Text.Trim();
                    string sqlsua = "update phongban set phongban = N'" + phongban + "' where mapb = '" + mapb + "'";
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

        private void btnxoapb_Click(object sender, EventArgs e)
        {
            DialogResult h = MessageBox.Show
             ("Bạn có chắc muốn xóa thông tin phòng ban này không?", "Cảnh Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (h == DialogResult.OK)
            {
                txtmapb.Enabled = false;
                btnsuapb.Enabled = false;
                btnxoapb.Enabled = false;
                btnluupb.Enabled = false;
                string mapb = txtmapb.Text.Trim();
                string sqlxoa = "delete phongban where mapb='" + mapb + "'";
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

        private void btnmoipb_Click(object sender, EventArgs e)
        {
            txtmapb.Text = "";
            txtphongban.Text = "";
            txtmapb.Enabled = false;
            btnsuapb.Enabled = false;
            btnxoapb.Enabled = false;
            btnluupb.Enabled = false;
        }

        private void btnluupb_Click(object sender, EventArgs e)
        {
            txtmapb.Enabled = false;
            btnsuapb.Enabled = false;
            btnxoapb.Enabled = false;
            btnluupb.Enabled = false;
            if (string.IsNullOrWhiteSpace(txtmapb.Text) || string.IsNullOrWhiteSpace(txtphongban.Text))
            {
                MessageBox.Show("Vui lòng nhập  đầy đủ thông tin dữ liệu !");
            }
            else
            {
                string mapb = txtmapb.Text.Trim();
                string phongban = txtphongban.Text.Trim();
                string sqlthem = "insert into phongban values('" + mapb + "',N'" + phongban + "')";
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

        private void phongban_Load(object sender, EventArgs e)
        {
            ketNoicsdl();
            hienthidulieulendatagridview();
            txtmapb.Enabled = false;
            btnsuapb.Enabled = false;
            btnxoapb.Enabled = false;
            btnluupb.Enabled = false;
        }

        private void dtg_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtmapb.Enabled = false;
            btnluupb.Enabled = true;
            btnxoapb.Enabled = true;
            btnsuapb.Enabled = true;
            int i;
            i = dtg.CurrentRow.Index;
            txtmapb.Text = dtg.Rows[i].Cells[0].Value.ToString();
            txtphongban.Text = dtg.Rows[i].Cells[1].Value.ToString();
        }

        private void btnthempb_MouseEnter(object sender, EventArgs e)
        {
            btnthempb.ForeColor = Color.White;
            btnthempb.BackColor = Color.Black;
        }

        private void btnthempb_MouseLeave(object sender, EventArgs e)
        {
            btnthempb.ForeColor = Color.Black;
            btnthempb.BackColor = Color.White;
        }

        private void btnsuapb_MouseEnter(object sender, EventArgs e)
        {
            btnsuapb.ForeColor = Color.Black;
            btnsuapb.BackColor = Color.White;
        }

        private void btnsuapb_MouseLeave(object sender, EventArgs e)
        {
            btnsuapb.ForeColor = Color.White;
            btnsuapb.BackColor = Color.Black;
        }

        private void btnxoapb_MouseEnter(object sender, EventArgs e)
        {
            btnxoapb.ForeColor = Color.Black;
            btnxoapb.BackColor = Color.White;
        }

        private void btnxoapb_MouseLeave(object sender, EventArgs e)
        {
            btnxoapb.ForeColor = Color.White;
            btnxoapb.BackColor = Color.Black;
        }

        private void btnmoipb_MouseEnter(object sender, EventArgs e)
        {
            btnmoipb.ForeColor = Color.Black;
            btnmoipb.BackColor = Color.White;
        }

        private void btnmoipb_MouseLeave(object sender, EventArgs e)
        {
            btnmoipb.ForeColor = Color.White;
            btnmoipb.BackColor = Color.Black;
        }

        private void btnluupb_MouseEnter(object sender, EventArgs e)
        {
            btnluupb.ForeColor = Color.Black;
            btnluupb.BackColor = Color.White;
        }

        private void btnluupb_MouseLeave(object sender, EventArgs e)
        {
            btnluupb.ForeColor = Color.White;
            btnluupb.BackColor = Color.Black;
        }
    }
}
