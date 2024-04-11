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
    public partial class hopdonglaodong : Form
    {
        public hopdonglaodong()
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
            dtg.Columns[0].HeaderText = "Mã Hợp Đồng ";
            dtg.Columns[1].HeaderText = "Mã Nhân viên ";
            dtg.Columns[2].HeaderText = "Họ Tên ";
            dtg.Columns[3].HeaderText = "Ngày Ký";
            dtg.Columns[4].HeaderText = "Ngày Hết Hạn ";
            dtg.Columns[5].HeaderText = "Lương Cơ Bản";
            dtg.Columns[6].HeaderText = "Chức Vụ ";

            dtg.Columns[0].Width = 150;
            dtg.Columns[1].Width = 150;
            dtg.Columns[2].Width = 180;
            dtg.Columns[3].Width = 150;
            dtg.Columns[4].Width = 150;
            dtg.Columns[5].Width = 150;
            dtg.Columns[6].Width = 150;

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

            string sql = "SELECT * FROM hopdonglaodong";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dtg.DataSource = dt;
            dinhdangdulieutrendata();
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
        private void btnthemhdld_Click(object sender, EventArgs e)
        {
            txtmahdld.Enabled = true;
            cbbmanv.Enabled = true;
            btnsuahdld.Enabled = false;
            btnxoahdld.Enabled = false;
            btnluuhdld.Enabled = true;
        }

        private void hopdonglaodong_Load(object sender, EventArgs e)
        {
            ketNoicsdl();
            hienthidulieulendatagridview();
            loaddulieucombomanv();
            txtmahdld.Enabled = false;
            cbbmanv.Enabled = false;
            btnsuahdld.Enabled = false;
            btnxoahdld.Enabled = false;
            btnluuhdld.Enabled = false;
            txthoten.Enabled = false;
            txtchucvu.Enabled = false;
        }

        private void btnsuahdld_Click(object sender, EventArgs e)
        {
            txtmahdld.Enabled = false;
            btnsuahdld.Enabled = false;
            btnxoahdld.Enabled = false;
            btnluuhdld.Enabled = false;
            if (string.IsNullOrWhiteSpace(txtmahdld.Text) || string.IsNullOrWhiteSpace(txthoten.Text) || string.IsNullOrWhiteSpace(txtluongcoban.Text) || string.IsNullOrWhiteSpace(txtchucvu.Text))
            {
                MessageBox.Show("Vui lòng nhập  đầy đủ thông tin dữ liệu !");
            }
            else
            {
                DialogResult h = MessageBox.Show
       ("Bạn có chắc muốn sửa thông tin hợp đồng này không?", "Cảnh Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (h == DialogResult.OK)
                {
                    string mahd = txtmahdld.Text.Trim();
                    string manv = cbbmanv.Text.Trim();
                    string hoten = txthoten.Text.Trim();
                    string ngaykiket = dtpngaykiket.Text.Trim();
                    string ngayhethan = dtpngayhethan.Text.Trim();
                    string luongcoban = txtluongcoban.Text.Trim();
                    string chucvu = txtchucvu.Text.Trim();

                    string sqlsua = "update hopdonglaodong set ngayky = '" + ngaykiket + "',ngayhethan = '" + ngayhethan + "',luongcoban = '" + luongcoban + "' where manv = N'" + manv + "' and mahd = '" + mahd + "'and hoten = '" + hoten + "'and chucvu = '" + chucvu + "'";
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

        private void btnxoahdld_Click(object sender, EventArgs e)
        {
            DialogResult h = MessageBox.Show
         ("Bạn có chắc muốn xóa thông tin hợp đồng này không?", "Cảnh Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (h == DialogResult.OK)
            {
                txtmahdld.Enabled = false;
                cbbmanv.Enabled = false;
                btnsuahdld.Enabled = false;
                btnxoahdld.Enabled = false;
                btnluuhdld.Enabled = false;
                string mahd = txtmahdld.Text.Trim();
                string sqlxoa = "delete hopdonglaodong where mahd='" + mahd + "'";
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

        private void btnmoihdld_Click(object sender, EventArgs e)
        {
            cbbmanv.SelectedIndex = 0;
            txtmahdld.Text = "";
            txthoten.Text = "";
            dtpngaykiket.Text = "";
            dtpngayhethan.Text = "";
            txtluongcoban.Text = "";
            txtchucvu.Text = "";
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
        private void btnluuhdld_Click(object sender, EventArgs e)
        {
            txtmahdld.Enabled = false;
            cbbmanv.Enabled = false;
            btnsuahdld.Enabled = false;
            btnxoahdld.Enabled = false;
            btnluuhdld.Enabled = false;
            if (string.IsNullOrWhiteSpace(txtmahdld.Text) || string.IsNullOrWhiteSpace(txthoten.Text) || string.IsNullOrWhiteSpace(txtluongcoban.Text) || string.IsNullOrWhiteSpace(txtchucvu.Text))
            {
                MessageBox.Show("Vui lòng nhập  đầy đủ thông tin dữ liệu !");
            }
            else
            {
                string mahd = txtmahdld.Text.Trim();
                string manv = cbbmanv.Text.Trim();
                string hoten = txthoten.Text.Trim();
                string ngaykiket = dtpngaykiket.Text.Trim();
                string ngayhethan = dtpngayhethan.Text.Trim();
                string luongcoban = txtluongcoban.Text.Trim();
                string chucvu = txtchucvu.Text.Trim();
                string sqlthem = "insert into hopdonglaodong values('" + mahd + "',N'" + manv + "',N'" + hoten + "',N'" + ngaykiket + "',N'" + ngayhethan + "',N'" + luongcoban + "',N'" + chucvu + "')";
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

        private void cbbmanv_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "select hopdonglaodong.mahd from hopdonglaodong,nhanvien where hopdonglaodong.manv=nhanvien.manv and hopdonglaodong.manv='" + cbbmanv.SelectedValue + "'";
            txtmahdld.Text = GetFieldValues(sql);
            string sql1 = "select nhanvien.hoten from nhanvien where nhanvien.manv='" + cbbmanv.SelectedValue + "'";
            txthoten.Text = GetFieldValues(sql1);
            string sql2 = "select hopdonglaodong.ngayky from hopdonglaodong,nhanvien where hopdonglaodong.manv=nhanvien.manv and hopdonglaodong.manv='" + cbbmanv.SelectedValue + "'";
            dtpngaykiket.Text = GetFieldValues(sql2);
            string sql3 = "select hopdonglaodong.ngayhethan from hopdonglaodong,nhanvien where hopdonglaodong.manv=nhanvien.manv and hopdonglaodong.manv='" + cbbmanv.SelectedValue + "'";
            dtpngayhethan.Text = GetFieldValues(sql3);
            string sql4 = "select hopdonglaodong.luongcoban from hopdonglaodong,nhanvien where hopdonglaodong.manv=nhanvien.manv and hopdonglaodong.manv='" + cbbmanv.SelectedValue + "'";
            txtluongcoban.Text = GetFieldValues(sql4);
            string sql5 = "select chucvu.chucvu from chucvu,nhanvien where chucvu.macv=nhanvien.macv and nhanvien.manv='" + cbbmanv.SelectedValue + "'";
            txtchucvu.Text = GetFieldValues(sql5);
        }

        private void dtg_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btnluuhdld.Enabled = true;
            btnxoahdld.Enabled = true;
            btnsuahdld.Enabled = true;
            int i;
            i = dtg.CurrentRow.Index;
            txtmahdld.Text = dtg.Rows[i].Cells[0].Value.ToString();
            cbbmanv.Text = dtg.Rows[i].Cells[1].Value.ToString();
            txthoten.Text = dtg.Rows[i].Cells[2].Value.ToString();
            dtpngaykiket.Text = dtg.Rows[i].Cells[3].Value.ToString();
            dtpngayhethan.Text = dtg.Rows[i].Cells[4].Value.ToString();
            txtluongcoban.Text = dtg.Rows[i].Cells[5].Value.ToString();
            txtchucvu.Text = dtg.Rows[i].Cells[6].Value.ToString();
        }

        private void btnthemhdld_MouseEnter(object sender, EventArgs e)
        {

            btnthemhdld.ForeColor = Color.Black;
            btnthemhdld.BackColor = Color.White;
        }

        private void btnthemhdld_MouseLeave(object sender, EventArgs e)
        {
            btnthemhdld.ForeColor = Color.White;
            btnthemhdld.BackColor = Color.Black;
        }

        private void btnsuahdld_MouseEnter(object sender, EventArgs e)
        {
            btnsuahdld.ForeColor = Color.Black;
            btnsuahdld.BackColor = Color.White;
        }

        private void btnsuahdld_MouseLeave(object sender, EventArgs e)
        {
            btnsuahdld.ForeColor = Color.White;
            btnsuahdld.BackColor = Color.Black;
        }

        private void btnxoahdld_MouseEnter(object sender, EventArgs e)
        {
            btnxoahdld.ForeColor = Color.Black;
            btnxoahdld.BackColor = Color.White;
        }

        private void btnxoahdld_MouseLeave(object sender, EventArgs e)
        {
            btnxoahdld.ForeColor = Color.White;
            btnxoahdld.BackColor = Color.Black;
        }

        private void btnmoihdld_MouseEnter(object sender, EventArgs e)
        {
            btnmoihdld.ForeColor = Color.Black;
            btnmoihdld.BackColor = Color.White;
        }

        private void btnmoihdld_MouseLeave(object sender, EventArgs e)
        {
            btnmoihdld.ForeColor = Color.White;
            btnmoihdld.BackColor = Color.Black;
        }

        private void btnluuhdld_MouseEnter(object sender, EventArgs e)
        {
            btnluuhdld.ForeColor = Color.Black;
            btnluuhdld.BackColor = Color.White;
        }

        private void btnluuhdld_MouseLeave(object sender, EventArgs e)
        {
            btnluuhdld.ForeColor = Color.White;
            btnluuhdld.BackColor = Color.Black;
        }
    }
}
