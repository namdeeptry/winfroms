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
    public partial class khenthuongkyluat : Form
    {
        public khenthuongkyluat()
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
            dtg.Columns[0].HeaderText = "Mã Khen Thưởng && Kỷ Luật ";
            dtg.Columns[1].HeaderText = "Mã Nhân viên ";
            dtg.Columns[2].HeaderText = "Nội Dung Khen Thưởng ";
            dtg.Columns[3].HeaderText = "Ngày Khen Thưởng";
            dtg.Columns[4].HeaderText = "Nội Dung Kỷ Luật";
            dtg.Columns[5].HeaderText = "Ngày Kỷ Luật";

            dtg.Columns[0].Width = 200;
            dtg.Columns[1].Width = 170;
            dtg.Columns[2].Width = 200;
            dtg.Columns[3].Width = 150;
            dtg.Columns[4].Width = 200;
            dtg.Columns[5].Width = 150;

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

            string sql = "SELECT * FROM khenthuongkyluat";
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
        private void khenthuongkyluat_Load(object sender, EventArgs e)
        {
            ketNoicsdl();
            hienthidulieulendatagridview();
            loaddulieucombomanv();
            txtmaktkl.Enabled = false;
            cbbmanv.Enabled = true;
            btnsua.Enabled = false;
            btnxoa.Enabled = false;
            btnluu.Enabled = false;
            txtnoidungkhenthuong.Enabled = false;
            txtnoidungkyluat.Enabled = false;
            dtpngaykhenthuong.Enabled = false;
            dtpngaykyluat.Enabled = false;
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            txtmaktkl.Enabled = true;
            cbbmanv.Enabled = true;
            btnsua.Enabled = false;
            btnxoa.Enabled = false;
            btnluu.Enabled = true;
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            txtmaktkl.Enabled = false;
            btnsua.Enabled = false;
            btnxoa.Enabled = false;
            btnluu.Enabled = false;
            if (string.IsNullOrWhiteSpace(txtmaktkl.Text) || string.IsNullOrWhiteSpace(txtnoidungkhenthuong.Text) || string.IsNullOrWhiteSpace(txtnoidungkyluat.Text))
            {
                MessageBox.Show("Vui lòng nhập  đầy đủ thông tin dữ liệu !");
            }
            else
            {
                DialogResult h = MessageBox.Show
       ("Bạn có chắc muốn sửa thông tin khen thưởng kỷ luật này không?", "Cảnh Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (h == DialogResult.OK)
                {
                    string maktkl = txtmaktkl.Text.Trim();
                    string manv = cbbmanv.Text.Trim();
                    string ndkt = txtnoidungkhenthuong.Text.Trim();
                    string ngaykhenthuong = dtpngaykhenthuong.Text.Trim();
                    string ndkl = txtnoidungkyluat.Text.Trim();
                    string ngaykyluat = dtpngaykyluat.Text.Trim();
                    string sqlsua = "update khenthuongkyluat set noidungkhenthuong = N'" + ndkt + "',ngaykhenthuong = '" + ngaykhenthuong + "',noidungkyluat = N'" + ndkl + "',ngaykyluat = '" + ngaykyluat + "' where manv = N'" + manv + "' and maktkl = '" + maktkl + "'";
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

        private void btnxoa_Click(object sender, EventArgs e)
        {

            DialogResult h = MessageBox.Show
      ("Bạn có chắc muốn xóa thông tin khen thưởng kỷ luật này không?", "Cảnh Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (h == DialogResult.OK)
            {
                txtmaktkl.Enabled = false;
                cbbmanv.Enabled = false;
                btnsua.Enabled = false;
                btnxoa.Enabled = false;
                btnluu.Enabled = false;
                string maktkl = txtmaktkl.Text.Trim();
                string sqlxoa = "delete khenthuongkyluat where maktkl='" + maktkl + "'";
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

        private void btnmoi_Click(object sender, EventArgs e)
        {
            txtmaktkl.Text = "";
            txtnoidungkhenthuong.Text = "";
            txtnoidungkyluat.Text = "";
            dtpngaykyluat.Text = "";
            dtpngaykhenthuong.Text = "";
            cbbmanv.SelectedIndex = 0;
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            txtmaktkl.Enabled = false;
            cbbmanv.Enabled = true;
            btnsua.Enabled = false;
            btnxoa.Enabled = false;
            btnluu.Enabled = false;
            if (string.IsNullOrWhiteSpace(txtmaktkl.Text) || string.IsNullOrWhiteSpace(txtnoidungkhenthuong.Text) || string.IsNullOrWhiteSpace(txtnoidungkyluat.Text))
            {
                MessageBox.Show("Vui lòng nhập  đầy đủ thông tin dữ liệu !");
            }
            else
            {
                string maktkl = txtmaktkl.Text.Trim();
                string manv = cbbmanv.Text.Trim();
                string ndkt = txtnoidungkhenthuong.Text.Trim();
                string ngaykhenthuong = dtpngaykhenthuong.Text.Trim();
                string ndkl = txtnoidungkyluat.Text.Trim();
                string ngaykyluat = dtpngaykyluat.Text.Trim();
                string sqlthem = "insert into khenthuongkyluat values('" + maktkl + "',N'" + manv + "',N'" + ndkt + "',N'" + ngaykhenthuong + "',N'" + ndkl + "',N'" + ngaykyluat + "')";
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
            btnluu.Enabled = true;
            btnxoa.Enabled = true;
            btnsua.Enabled = true;
            cbbmanv.Enabled = false;
            txtnoidungkhenthuong.Enabled = true;
            txtnoidungkyluat.Enabled = true;
            dtpngaykhenthuong.Enabled = true;
            dtpngaykyluat.Enabled = true;
            int i;
            i = dtg.CurrentRow.Index;
            txtmaktkl.Text = dtg.Rows[i].Cells[0].Value.ToString();
            cbbmanv.Text = dtg.Rows[i].Cells[1].Value.ToString();
            txtnoidungkhenthuong.Text = dtg.Rows[i].Cells[2].Value.ToString();
            dtpngaykhenthuong.Text = dtg.Rows[i].Cells[3].Value.ToString();
            txtnoidungkyluat.Text = dtg.Rows[i].Cells[4].Value.ToString();
            dtpngaykyluat.Text = dtg.Rows[i].Cells[5].Value.ToString();
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
            string sql = "select khenthuongkyluat.maktkl from khenthuongkyluat,nhanvien where khenthuongkyluat.manv=nhanvien.manv and khenthuongkyluat.manv='" + cbbmanv.SelectedValue + "'";
            txtmaktkl.Text = GetFieldValues(sql);
            string sql1 = "select khenthuongkyluat.noidungkhenthuong from khenthuongkyluat,nhanvien where khenthuongkyluat.manv=nhanvien.manv and khenthuongkyluat.manv='" + cbbmanv.SelectedValue + "'";
            txtnoidungkhenthuong.Text = GetFieldValues(sql1);
            string sql2 = "select khenthuongkyluat.ngaykhenthuong from khenthuongkyluat,nhanvien where khenthuongkyluat.manv=nhanvien.manv and khenthuongkyluat.manv='" + cbbmanv.SelectedValue + "'";
            dtpngaykhenthuong.Text = GetFieldValues(sql2);
            string sql3 = "select khenthuongkyluat.noidungkyluat from khenthuongkyluat,nhanvien where khenthuongkyluat.manv=nhanvien.manv and khenthuongkyluat.manv='" + cbbmanv.SelectedValue + "'";
            txtnoidungkyluat.Text = GetFieldValues(sql3);
            string sql4 = "select khenthuongkyluat.ngaykyluat from khenthuongkyluat,nhanvien where khenthuongkyluat.manv=nhanvien.manv and khenthuongkyluat.manv='" + cbbmanv.SelectedValue + "'";
            dtpngaykyluat.Text = GetFieldValues(sql4);
        }

        private void btnthem_MouseEnter(object sender, EventArgs e)
        {
            btnthem.ForeColor = Color.Black;
            btnthem.BackColor = Color.White;
        }

        private void btnthem_MouseLeave(object sender, EventArgs e)
        {
            btnthem.ForeColor = Color.White;
            btnthem.BackColor = Color.Black;
        }

        private void btnsua_MouseEnter(object sender, EventArgs e)
        {
            btnsua.ForeColor = Color.Black;
            btnsua.BackColor = Color.White;
        }

        private void btnsua_MouseLeave(object sender, EventArgs e)
        {
            btnsua.ForeColor = Color.White;
            btnsua.BackColor = Color.Black;
        }

        private void btnxoa_MouseEnter(object sender, EventArgs e)
        {
            btnxoa.ForeColor = Color.Black;
            btnxoa.BackColor = Color.White;
        }

        private void btnxoa_MouseLeave(object sender, EventArgs e)
        {
            btnxoa.ForeColor = Color.White;
            btnxoa.BackColor = Color.Black;
        }

        private void btnmoi_MouseEnter(object sender, EventArgs e)
        {
            btnmoi.ForeColor = Color.Black;
            btnmoi.BackColor = Color.White;
        }

        private void btnmoi_MouseLeave(object sender, EventArgs e)
        {
            btnmoi.ForeColor = Color.White;
            btnmoi.BackColor = Color.Black;
        }

        private void btnluu_MouseEnter(object sender, EventArgs e)
        {
            btnluu.ForeColor = Color.Black;
            btnluu.BackColor = Color.White;
        }

        private void btnluu_MouseLeave(object sender, EventArgs e)
        {
            btnluu.ForeColor = Color.White;
            btnluu.BackColor = Color.Black;
        }
    }
}
