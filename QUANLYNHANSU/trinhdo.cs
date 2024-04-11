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
    public partial class trinhdo : Form
    {
        public trinhdo()
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
            dtg.Columns[0].HeaderText = "Mã Trình Độ";
            dtg.Columns[1].HeaderText = "Tên Trình Độ ";

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

            string sql = "SELECT * FROM trinhdo";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dtg.DataSource = dt;
            dinhdangdulieutrendata();
        }

        private void trinhdo_Load(object sender, EventArgs e)
        {
            ketNoicsdl();
            hienthidulieulendatagridview();
            txtmatd.Enabled = false;
            btnsuatd.Enabled = false;
            btnxoatd.Enabled = false;
            btnluutd.Enabled = false;
        }

        private void btnthemtd_Click(object sender, EventArgs e)
        {
            txtmatd.Enabled = true;
            btnsuatd.Enabled = false;
            btnxoatd.Enabled = false;
            btnluutd.Enabled = true;
        }

        private void btnsuatd_Click(object sender, EventArgs e)
        {
            txtmatd.Enabled = false;
            btnsuatd.Enabled = false;
            btnxoatd.Enabled = false;
            btnluutd.Enabled = false;
            if (string.IsNullOrWhiteSpace(txtmatd.Text) || string.IsNullOrWhiteSpace(txttrinhdo.Text))
            {
                MessageBox.Show("Vui lòng nhập  đầy đủ thông tin dữ liệu !");
            }
            else
            {
                DialogResult h = MessageBox.Show
          ("Bạn có chắc muốn sửa thông tin trình độ này không?", "Cảnh Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (h == DialogResult.OK)
                {
                    string matd = txtmatd.Text.Trim();
                    string trinhdo = txttrinhdo.Text.Trim();
                    string sqlsua = "update trinhdo set trinhdo = N'" + trinhdo + "' where matd = '" + matd + "'";
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

        private void btnxoatd_Click(object sender, EventArgs e)
        {

            DialogResult h = MessageBox.Show
            ("Bạn có chắc muốn xóa thông tin trình độ này không?", "Cảnh Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (h == DialogResult.OK)
            {
                txtmatd.Enabled = false;
                btnsuatd.Enabled = false;
                btnxoatd.Enabled = false;
                btnluutd.Enabled = false;
                string matd = txtmatd.Text.Trim();
                string sqlxoa = "delete trinhdo where matd='" + matd + "'";
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

        private void btnmoitd_Click(object sender, EventArgs e)
        {
            txtmatd.Text = "";
            txttrinhdo.Text = "";
            txtmatd.Enabled = false;
            btnsuatd.Enabled = false;
            btnxoatd.Enabled = false;
            btnluutd.Enabled = false;
        }

        private void btnluutd_Click(object sender, EventArgs e)
        {
            txtmatd.Enabled = false;
            btnsuatd.Enabled = false;
            btnxoatd.Enabled = false;
            btnluutd.Enabled = false;
            if (string.IsNullOrWhiteSpace(txtmatd.Text) || string.IsNullOrWhiteSpace(txttrinhdo.Text))
            {
                MessageBox.Show("Vui lòng nhập  đầy đủ thông tin dữ liệu !");
            }
            else
            {
                string matd = txtmatd.Text.Trim();
                string trinhdo = txttrinhdo.Text.Trim();
                string sqlthem = "insert into trinhdo values('" + matd + "',N'" + trinhdo + "')";
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

            txtmatd.Enabled = false;
            btnluutd.Enabled = true;
            btnxoatd.Enabled = true;
            btnsuatd.Enabled = true;
            int i;
            i = dtg.CurrentRow.Index;
            txtmatd.Text = dtg.Rows[i].Cells[0].Value.ToString();
            txttrinhdo.Text = dtg.Rows[i].Cells[1].Value.ToString();
        }

        private void btnthemtd_MouseEnter(object sender, EventArgs e)
        {
            btnthemtd.ForeColor = Color.Black;
            btnthemtd.BackColor = Color.White;
        }

        private void btnthemtd_MouseLeave(object sender, EventArgs e)
        {
            btnthemtd.ForeColor = Color.White;
            btnthemtd.BackColor = Color.Black;
        }

        private void btnsuatd_MouseEnter(object sender, EventArgs e)
        {
            btnsuatd.ForeColor = Color.Black;
            btnsuatd.BackColor = Color.White;
        }

        private void btnsuatd_MouseLeave(object sender, EventArgs e)
        {
            btnsuatd.ForeColor = Color.White;
            btnsuatd.BackColor = Color.Black;
        }

        private void btnxoatd_MouseEnter(object sender, EventArgs e)
        {
            btnxoatd.ForeColor = Color.Black;
            btnxoatd.BackColor = Color.White;
        }

        private void btnxoatd_MouseLeave(object sender, EventArgs e)
        {
            btnxoatd.ForeColor = Color.White;
            btnxoatd.BackColor = Color.Black;
        }

        private void btnmoitd_MouseEnter(object sender, EventArgs e)
        {
            btnmoitd.ForeColor = Color.Black;
            btnmoitd.BackColor = Color.White;
        }

        private void btnmoitd_MouseLeave(object sender, EventArgs e)
        {
            btnmoitd.ForeColor = Color.White;
            btnmoitd.BackColor = Color.Black;
        }

        private void btnluutd_MouseEnter(object sender, EventArgs e)
        {
            btnluutd.ForeColor = Color.Black;
            btnluutd.BackColor = Color.White;
        }

        private void btnluutd_MouseLeave(object sender, EventArgs e)
        {
            btnluutd.ForeColor = Color.White;
            btnluutd.BackColor = Color.Black;
        }
    }
}
