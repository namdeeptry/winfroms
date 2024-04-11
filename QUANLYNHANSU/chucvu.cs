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
    public partial class chucvu : Form
    {
        public chucvu()
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
            dtg.Columns[0].HeaderText = "Mã Chức Vụ";
            dtg.Columns[1].HeaderText = "Tên Chức vụ ";

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

            string sql = "SELECT * FROM chucvu";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dtg.DataSource = dt;
            dinhdangdulieutrendata();
        }
        private void chucvu_Load(object sender, EventArgs e)
        {
           
        }

        private void btnthemcv_Click(object sender, EventArgs e)
        {
            txtmacv.Enabled = true;
            btnsuacv.Enabled = false;
            btnxoacv.Enabled = false;
            btnluucv.Enabled = true;
        }

        private void btnsuacv_Click(object sender, EventArgs e)
        {
            txtmacv.Enabled = false;
            btnsuacv.Enabled = false;
            btnxoacv.Enabled = false;
            btnluucv.Enabled = false;
            if (string.IsNullOrWhiteSpace(txtmacv.Text) || string.IsNullOrWhiteSpace(txtchucvu.Text))
            {
                MessageBox.Show("Vui lòng nhập  đầy đủ thông tin dữ liệu !");
            }
            else
            {
                DialogResult h = MessageBox.Show
          ("Bạn có chắc muốn sửa thông tin chức vụ này không?", "Cảnh Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (h == DialogResult.OK)
                {
                    string macv = txtmacv.Text.Trim();
                    string chucvu = txtchucvu.Text.Trim();
                    string sqlsua = "update chucvu set chucvu = N'" + chucvu + "' where macv = '" + macv + "'";
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

        private void btnxoacv_Click(object sender, EventArgs e)
        {
            DialogResult h = MessageBox.Show
           ("Bạn có chắc muốn xóa thông tin chức vụ này không?", "Cảnh Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (h == DialogResult.OK)
            {
                txtmacv.Enabled = false;
                btnsuacv.Enabled = false;
                btnxoacv.Enabled = false;
                btnluucv.Enabled = false;
                string macv = txtmacv.Text.Trim();
                string sqlxoa = "delete chucvu where macv='" + macv + "'";
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

        private void btnmoicv_Click(object sender, EventArgs e)
        {
            txtmacv.Text = "";
            txtchucvu.Text = "";
            txtmacv.Enabled = false;
            btnsuacv.Enabled = false;
            btnxoacv.Enabled = false;
            btnluucv.Enabled = false;
        }

        private void btnluucv_Click(object sender, EventArgs e)
        {
            txtmacv.Enabled = false;
            btnsuacv.Enabled = false;
            btnxoacv.Enabled = false;
            btnluucv.Enabled = false;
            if (string.IsNullOrWhiteSpace(txtmacv.Text) || string.IsNullOrWhiteSpace(txtchucvu.Text))
            {
                MessageBox.Show("Vui lòng nhập  đầy đủ thông tin dữ liệu !");
            }
            else
            {
                string macv = txtmacv.Text.Trim();
                string chucvu = txtchucvu.Text.Trim();
                string sqlthem = "insert into chucvu values('" + macv + "',N'" + chucvu + "')";
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
            txtmacv.Enabled = false;
            btnluucv.Enabled = true;
            btnxoacv.Enabled = true;
            btnsuacv.Enabled = true;
            int i;
            i = dtg.CurrentRow.Index;
            txtmacv.Text = dtg.Rows[i].Cells[0].Value.ToString();
            txtchucvu.Text = dtg.Rows[i].Cells[1].Value.ToString();
        }

        private void btnthemcv_MouseEnter(object sender, EventArgs e)
        {
            btnthemcv.ForeColor = Color.Black;
            btnthemcv.BackColor = Color.White;
        }

        private void btnthemcv_MouseLeave(object sender, EventArgs e)
        {
            btnthemcv.ForeColor = Color.White;
            btnthemcv.BackColor = Color.Black;
        }

        private void btnsuacv_MouseEnter(object sender, EventArgs e)
        {
            btnsuacv.ForeColor = Color.Black;
            btnsuacv.BackColor = Color.White;
        }

        private void btnsuacv_MouseLeave(object sender, EventArgs e)
        {
            btnsuacv.ForeColor = Color.White;
            btnsuacv.BackColor = Color.Black;
        }

        private void btnxoacv_MouseEnter(object sender, EventArgs e)
        {
            btnxoacv.ForeColor = Color.Black;
            btnxoacv.BackColor = Color.White;
        }

        private void btnxoacv_MouseLeave(object sender, EventArgs e)
        {
            btnxoacv.ForeColor = Color.White;
            btnxoacv.BackColor = Color.Black;
        }

        private void btnmoicv_MouseEnter(object sender, EventArgs e)
        {
            btnmoicv.ForeColor = Color.Black;
            btnmoicv.BackColor = Color.White;
        }

        private void btnmoicv_MouseLeave(object sender, EventArgs e)
        {
            btnmoicv.ForeColor = Color.White;
            btnmoicv.BackColor = Color.Black;
        }

        private void btnluucv_MouseEnter(object sender, EventArgs e)
        {
            btnluucv.ForeColor = Color.Black;
            btnluucv.BackColor = Color.White;
        }

        private void btnluucv_MouseLeave(object sender, EventArgs e)
        {
            btnluucv.ForeColor = Color.White;
            btnluucv.BackColor = Color.Black;
        }

        private void chucvu_Load_1(object sender, EventArgs e)
        {
            ketNoicsdl();
            hienthidulieulendatagridview();
            txtmacv.Enabled = false;
            btnsuacv.Enabled = false;
            btnxoacv.Enabled = false;
            btnluucv.Enabled = false;
        }
    }
}
