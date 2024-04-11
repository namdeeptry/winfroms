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
    public partial class baohiem : Form
    {
        public baohiem()
        {
            InitializeComponent();
        }

        private void baohiem_Load(object sender, EventArgs e)
        {
            ketNoicsdl();
            hienthidulieulendatagridview();
            loaddulieucombomanv();
            txtmabh.Enabled = false;
            cbbmanv.Enabled = false;
            btnsuabh.Enabled = false;
            btnxoabh.Enabled = false;
            btnluubh.Enabled = false;
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
            dtg.Columns[0].HeaderText = "Mã Bảo Hiểm ";
            dtg.Columns[1].HeaderText = "Mã Nhân viên ";
            dtg.Columns[2].HeaderText = "Loại Bảo Hiểm ";
            dtg.Columns[3].HeaderText = "Số Bảo Hiểm ";

            dtg.Columns[0].Width = 200;
            dtg.Columns[1].Width = 200;
            dtg.Columns[2].Width = 200;
            dtg.Columns[3].Width = 200;

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

            string sql = "SELECT * FROM baohiem";
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

        private void btnthembh_Click(object sender, EventArgs e)
        {
            txtmabh.Enabled = true;
            cbbmanv.Enabled = true;
            btnsuabh.Enabled = false;
            btnxoabh.Enabled = false;
            btnluubh.Enabled = true;
        }

        private void btnsuabh_Click(object sender, EventArgs e)
        {
            txtmabh.Enabled = false;
            btnsuabh.Enabled = false;
            btnxoabh.Enabled = false;
            btnluubh.Enabled = false;
            if (string.IsNullOrWhiteSpace(txtmabh.Text) || string.IsNullOrWhiteSpace(txtsobaohiem.Text) )
            {
                MessageBox.Show("Vui lòng nhập  đầy đủ thông tin dữ liệu !");
            }
            else
            {
                DialogResult h = MessageBox.Show
       ("Bạn có chắc muốn sửa thông tin bảo hiểm này không?", "Cảnh Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (h == DialogResult.OK)
                {
                    string mabh = txtmabh.Text.Trim();
                    string manv = cbbmanv.Text.Trim();
                    string loaibaohiem = cbbloaibaohiem.Text.Trim();
                    string sobaohiem = txtsobaohiem.Text.Trim();
                    string sqlsua = "update baohiem set loaibaohiem = '" + loaibaohiem + "',sobaohiem = '" + sobaohiem + "' where manv = N'" + manv + "' and mabh = '" + mabh + "'";
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

        private void btnxoabh_Click(object sender, EventArgs e)
        {
            DialogResult h = MessageBox.Show
          ("Bạn có chắc muốn xóa thông tin bảo hiểm này không?", "Cảnh Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (h == DialogResult.OK)
            {
                txtmabh.Enabled = false;
                cbbmanv.Enabled = false;
                btnsuabh.Enabled = false;
                btnxoabh.Enabled = false;
                btnluubh.Enabled = false;
                string mabh = txtmabh.Text.Trim();
                string sqlxoa = "delete baohiem where mabh='" + mabh + "'";
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

        private void btnmoibh_Click(object sender, EventArgs e)
        {
            cbbmanv.SelectedIndex = 0;
            txtmabh.Text = "";
            txtsobaohiem.Text = "";
            cbbloaibaohiem.SelectedIndex=0;
        }

        private void btnluubh_Click(object sender, EventArgs e)
        {
            txtmabh.Enabled = false;
            cbbmanv.Enabled = false;
            btnsuabh.Enabled = false;
            btnxoabh.Enabled = false;
            btnluubh.Enabled = false;
            if (string.IsNullOrWhiteSpace(txtmabh.Text) || string.IsNullOrWhiteSpace(txtsobaohiem.Text))
            {
                MessageBox.Show("Vui lòng nhập  đầy đủ thông tin dữ liệu !");
            }
            else
            {
                string mabh = txtmabh.Text.Trim();
                string manv = cbbmanv.Text.Trim();
                string loaibaohiem = cbbloaibaohiem.Text.Trim();
                string sobaohiem = txtsobaohiem.Text.Trim();
                string sqlthem = "insert into baohiem values('" + mabh + "',N'" + manv + "',N'" + loaibaohiem + "',N'" + sobaohiem + "')";
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
            btnluubh.Enabled = true;
            btnxoabh.Enabled = true;
            btnsuabh.Enabled = true;
            int i;
            i = dtg.CurrentRow.Index;
            txtmabh.Text = dtg.Rows[i].Cells[0].Value.ToString();
            cbbmanv.Text = dtg.Rows[i].Cells[1].Value.ToString();
            cbbloaibaohiem.Text = dtg.Rows[i].Cells[2].Value.ToString();
            txtsobaohiem.Text = dtg.Rows[i].Cells[3].Value.ToString();
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
            string sql = "select baohiem.mabh from baohiem,nhanvien where baohiem.manv=nhanvien.manv and baohiem.manv='" + cbbmanv.SelectedValue + "'";
            txtmabh.Text = GetFieldValues(sql);
            string sql1 = "select baohiem.loaibaohiem from baohiem,nhanvien where baohiem.manv=nhanvien.manv and baohiem.manv='" + cbbmanv.SelectedValue + "'";
            cbbloaibaohiem.Text = GetFieldValues(sql1);
            string sql2 = "select baohiem.sobaohiem from baohiem,nhanvien where baohiem.manv=nhanvien.manv and baohiem.manv='" + cbbmanv.SelectedValue + "'";
            txtsobaohiem.Text = GetFieldValues(sql2);
        }

        private void btnthembh_MouseEnter(object sender, EventArgs e)
        {
            btnthembh.ForeColor = Color.Black;
            btnthembh.BackColor = Color.White;
        }

        private void btnthembh_MouseLeave(object sender, EventArgs e)
        {
            btnthembh.ForeColor = Color.White;
            btnthembh.BackColor = Color.Black;
        }

        private void btnsuabh_MouseEnter(object sender, EventArgs e)
        {
            btnsuabh.ForeColor = Color.Black;
            btnsuabh.BackColor = Color.White;
        }

        private void btnsuabh_MouseLeave(object sender, EventArgs e)
        {
            btnsuabh.ForeColor = Color.White;
            btnsuabh.BackColor = Color.Black;
        }

        private void btnxoabh_MouseEnter(object sender, EventArgs e)
        {
            btnxoabh.ForeColor = Color.Black;
            btnxoabh.BackColor = Color.White;
        }

        private void btnxoabh_MouseLeave(object sender, EventArgs e)
        {
            btnxoabh.ForeColor = Color.White;
            btnxoabh.BackColor = Color.Black;
        }

        private void btnmoibh_MouseEnter(object sender, EventArgs e)
        {
            btnmoibh.ForeColor = Color.Black;
            btnmoibh.BackColor = Color.White;
        }

        private void btnmoibh_MouseLeave(object sender, EventArgs e)
        {
            btnmoibh.ForeColor = Color.White;
            btnmoibh.BackColor = Color.Black;
        }

        private void btnluubh_MouseEnter(object sender, EventArgs e)
        {
            btnluubh.ForeColor = Color.Black;
            btnluubh.BackColor = Color.White;
        }

        private void btnluubh_MouseLeave(object sender, EventArgs e)
        {
            btnluubh.ForeColor = Color.White;
            btnluubh.BackColor = Color.Black;
        }
    }
}
