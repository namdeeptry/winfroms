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
    public partial class luong : Form
    {
        public luong()
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
            dtg.Columns[0].HeaderText = "Mã Bảng Lương ";
            dtg.Columns[1].HeaderText = "Mã Nhân viên ";
            dtg.Columns[2].HeaderText = "Lương Cơ Bản ";
            dtg.Columns[3].HeaderText = "Hệ Số Lương ";
            dtg.Columns[4].HeaderText = "Phụ Cấp  ";
            dtg.Columns[5].HeaderText = "Khoản Trừ  ";
            dtg.Columns[6].HeaderText = "Thực Lãnh  ";

            dtg.Columns[0].Width = 210;
            dtg.Columns[1].Width = 210;
            dtg.Columns[2].Width = 210;
            dtg.Columns[3].Width = 190;
            dtg.Columns[4].Width = 180;
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

            string sql = "SELECT * FROM bangluong";
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

        private void luong_Load(object sender, EventArgs e)
        {
            ketNoicsdl();
            hienthidulieulendatagridview();
            loaddulieucombomanv();
            txtmabl.Enabled = false;
            txtthuclanh.Enabled = false;
            btnsual.Enabled = false;
            btnxoal.Enabled = false;
            txtsongaylamviec.Enabled = false;
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

        private void cbbmanv_SelectedIndexChanged(object sender, EventArgs e)
        {

            string sql = "select ((bangluong.luongcoban*bangluong.hesoluong)*chamcong.songaylam)-bangluong.khoantru+bangluong.phucap as thuclanh from bangluong,chamcong where chamcong.manv= bangluong.manv and bangluong.manv='" + cbbmanv.SelectedValue + "'";
            txtthuclanh.Text = GetFieldValues(sql);
            string sqlbacluong = "select bangluong.mabl from bangluong,nhanvien where bangluong.manv = nhanvien.manv and nhanvien.manv ='" + cbbmanv.SelectedValue + "'";
            txtmabl.Text = GetFieldValues(sqlbacluong);
            string sqlsongaylamviec = "select chamcong.songaylam from chamcong,nhanvien where chamcong.manv=nhanvien.manv and  nhanvien.manv  ='" + cbbmanv.SelectedValue + "'";
            txtsongaylamviec.Text = GetFieldValues(sqlsongaylamviec);
            string sqllcb = "select hopdonglaodong.luongcoban from hopdonglaodong,nhanvien where hopdonglaodong.manv = nhanvien.manv and hopdonglaodong.manv = '" + cbbmanv.SelectedValue + "'";
            txtluongcoban.Text = GetFieldValues(sqllcb);
            string sqlhsl = "select bangluong.hesoluong from bangluong,nhanvien where bangluong.manv = nhanvien.manv and bangluong.manv = '" + cbbmanv.SelectedValue + "'";
            txthesoluong.Text = GetFieldValues(sqlhsl);
            string sqlphucap = "select bangluong.phucap from bangluong,nhanvien where bangluong.manv = nhanvien.manv and bangluong.manv = '" + cbbmanv.SelectedValue + "'";
            txtphucap.Text = GetFieldValues(sqlphucap);
            string sqlkhoantru = "select bangluong.khoantru from bangluong,nhanvien where bangluong.manv = nhanvien.manv and bangluong.manv = '" + cbbmanv.SelectedValue + "'";
            txtkhoantru.Text = GetFieldValues(sqlkhoantru);
        }

        private void btntheml_Click(object sender, EventArgs e)
        {

            txtmabl.Enabled = true;
            cbbmanv.Enabled = true;
            btnsual.Enabled = false;
            btnxoal.Enabled = false;
            btnluul.Enabled = true;
        }

        private void btnsual_Click(object sender, EventArgs e)
        {
            txtmabl.Enabled = false;
            btnsual.Enabled = false;
            btnxoal.Enabled = false;
            btnluul.Enabled = false;
            if (string.IsNullOrWhiteSpace(txtmabl.Text) || string.IsNullOrWhiteSpace(txtluongcoban.Text) || string.IsNullOrWhiteSpace(txthesoluong.Text) || string.IsNullOrWhiteSpace(txtkhoantru.Text) || string.IsNullOrWhiteSpace(txtphucap.Text))
            {
                MessageBox.Show("Vui lòng nhập  đầy đủ thông tin dữ liệu !");
            }
            else
            {
                DialogResult h = MessageBox.Show
       ("Bạn có chắc muốn sửa thông tin bảng lương này không?", " ⚠️Cảnh Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (h == DialogResult.OK)
                {
                    string mabl = txtmabl.Text.Trim();
                    string manv = cbbmanv.Text.Trim();
                    int luongcoban = int.Parse(txtluongcoban.Text.Trim());
                    int hesoluong = int.Parse(txthesoluong.Text.Trim());
                    int phucap = int.Parse(txtphucap.Text.Trim());
                    int khoantru = int.Parse(txtkhoantru.Text.Trim());
                    int thuclanh = int.Parse(txtthuclanh.Text.Trim());
                    string sqlsua = "update bangluong set luongcoban = '" + luongcoban + "',hesoluong = '" + hesoluong + "',phucap = '" + phucap + "',khoantru = '" + khoantru + "',tongluong = '" + thuclanh + "' where mabl = N'" + mabl + "' and manv = '" + manv + "'";
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

        private void btnxoal_Click(object sender, EventArgs e)
        {
            DialogResult h = MessageBox.Show
      ("Bạn có chắc muốn xóa thông tin bảng lương này không?", " ⚠️Cảnh Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (h == DialogResult.OK)
            {
                txtmabl.Enabled = false;
                cbbmanv.Enabled = false;
                btnsual.Enabled = false;
                btnxoal.Enabled = false;
                btnluul.Enabled = false;
                string mabl = txtmabl.Text.Trim();
                string sqlxoa = "delete bangluong where mabl='" + mabl + "'";
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

        private void btnmoil_Click(object sender, EventArgs e)
        {
            cbbmanv.SelectedIndex=0;
            txtmabl.Text = "";
            txthesoluong.Text = "";
            txtluongcoban.Text = "";
            txtphucap.Text = "";
            txtthuclanh.Text = "";
            txtkhoantru.Text = "";
            txtsongaylamviec.Text = "";
            lbchu.ForeColor = Color.White;
        }

        private void btnluul_Click(object sender, EventArgs e)
        {
            txtmabl.Enabled = false;
            cbbmanv.Enabled = false;
            btnsual.Enabled = false;
            btnxoal.Enabled = false;
            btnluul.Enabled = false;
            if (string.IsNullOrWhiteSpace(txtmabl.Text) || string.IsNullOrWhiteSpace(txtluongcoban.Text) || string.IsNullOrWhiteSpace(txthesoluong.Text) || string.IsNullOrWhiteSpace(txtkhoantru.Text) || string.IsNullOrWhiteSpace(txtphucap.Text))
            {
                MessageBox.Show("Vui lòng nhập  đầy đủ thông tin dữ liệu !");
            }
            else
            {
                string mabl = txtmabl.Text.Trim();
                string manv = cbbmanv.Text.Trim();
                int luongcoban = int.Parse(txtluongcoban.Text.Trim());
                int hesoluong = int.Parse(txthesoluong.Text.Trim());
                int phucap = int.Parse(txtphucap.Text.Trim());
                int khoantru = int.Parse(txtkhoantru.Text.Trim());
                int thuclanh = int.Parse(txtthuclanh.Text.Trim());

                string sqlthem = "insert into bangluong values('" + mabl + "',N'" + manv + "',N'" + luongcoban + "',N'" + hesoluong + "',N'" + khoantru + "',N'" + phucap + "',N'" + thuclanh + "')";
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

        private void txtkhoantru_TextChanged(object sender, EventArgs e)
        {
            double lcb, hsl, pc, kt, tl, snlv;
            if (txtsongaylamviec.Text == "")
            {
                snlv = 0;
            }
            else snlv = Convert.ToDouble(txtsongaylamviec.Text);
            if (txtluongcoban.Text == "")
            {
                lcb = 0;
            }
            else lcb = Convert.ToDouble(txtluongcoban.Text);
            if (txthesoluong.Text == "")
            {
                hsl = 0;
            }
            else hsl = Convert.ToDouble(txthesoluong.Text);
            if (txtphucap.Text == "")
            {
                pc = 0;
            }
            else pc = Convert.ToDouble(txtphucap.Text);
            if (txtkhoantru.Text == "")
            {
                kt = 0;
            }
            else kt = Convert.ToDouble(txtkhoantru.Text);

            tl = lcb * hsl * snlv - kt + pc;
            txtthuclanh.Text = tl.ToString();
            string str;
            str = "select bangluong.tongluong from   nhanvien,bangluong where nhanvien.manv = bangluong.manv and bangluong.manv='" + cbbmanv.SelectedValue + "' ";
            txtthuclanh.Text = GetFieldValues(str);
            lbchu.Text = " " + ChuyenSoSangChuoi(double.Parse(txtthuclanh.Text));
            lbchu.ForeColor = Color.Red;
        }

        private void dtg_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btnluul.Enabled = true;
            btnxoal.Enabled = true;
            btnsual.Enabled = true;
            int i;
            i = dtg.CurrentRow.Index;
            txtmabl.Text = dtg.Rows[i].Cells[0].Value.ToString();
            cbbmanv.Text = dtg.Rows[i].Cells[1].Value.ToString();
            txtluongcoban.Text = dtg.Rows[i].Cells[2].Value.ToString();
            txthesoluong.Text = dtg.Rows[i].Cells[3].Value.ToString();
            txtphucap.Text = dtg.Rows[i].Cells[4].Value.ToString();
            txtkhoantru.Text = dtg.Rows[i].Cells[5].Value.ToString();
            txtthuclanh.Text = dtg.Rows[i].Cells[6].Value.ToString();
            string str;
            str = "select bangluong.tongluong from   nhanvien,bangluong where nhanvien.manv = bangluong.manv and bangluong.manv='" + cbbmanv.SelectedValue + "' ";
            txtthuclanh.Text = GetFieldValues(str);
            lbchu.Text = " " + ChuyenSoSangChuoi(double.Parse(txtthuclanh.Text));
            lbchu.ForeColor = Color.Red;
        }

        private void txthesoluong_TextChanged(object sender, EventArgs e)
        {
            double lcb, hsl, pc, kt, tl, snlv;
            if (txtsongaylamviec.Text == "")
            {
                snlv = 0;
            }
            else snlv = Convert.ToDouble(txtsongaylamviec.Text);
            if (txtluongcoban.Text == "")
            {
                lcb = 0;
            }
            else lcb = Convert.ToDouble(txtluongcoban.Text);
            if (txthesoluong.Text == "")
            {
                hsl = 0;
            }
            else hsl = Convert.ToDouble(txthesoluong.Text);
            if (txtphucap.Text == "")
            {
                pc = 0;
            }
            else pc = Convert.ToDouble(txtphucap.Text);
            if (txtkhoantru.Text == "")
            {
                kt = 0;
            }
            else kt = Convert.ToDouble(txtkhoantru.Text);

            tl = lcb * hsl * snlv - kt + pc;
            txtthuclanh.Text = tl.ToString();
            string str;
            str = "select bangluong.tongluong from   nhanvien,bangluong where nhanvien.manv = bangluong.manv and bangluong.manv='" + cbbmanv.SelectedValue + "' ";
            txtthuclanh.Text = GetFieldValues(str);
            lbchu.Text = " " + ChuyenSoSangChuoi(double.Parse(txtthuclanh.Text));
            lbchu.ForeColor = Color.Red;
        }

        private void txtluongcoban_TextChanged(object sender, EventArgs e)
        {
            double lcb, hsl, pc, kt, tl, snlv;
            if (txtsongaylamviec.Text == "")
            {
                snlv = 0;
            }
            else snlv = Convert.ToDouble(txtsongaylamviec.Text);
            if (txtluongcoban.Text == "")
            {
                lcb = 0;
            }
            else lcb = Convert.ToDouble(txtluongcoban.Text);
            if (txthesoluong.Text == "")
            {
                hsl = 0;
            }
            else hsl = Convert.ToDouble(txthesoluong.Text);
            if (txtphucap.Text == "")
            {
                pc = 0;
            }
            else pc = Convert.ToDouble(txtphucap.Text);
            if (txtkhoantru.Text == "")
            {
                kt = 0;
            }
            else kt = Convert.ToDouble(txtkhoantru.Text);

            tl = lcb * hsl * snlv - kt + pc;
            txtthuclanh.Text = tl.ToString();
            string str;
           
        }

        private void txtphucap_TextChanged(object sender, EventArgs e)
        {
            double lcb, hsl, pc, kt, tl, snlv;
            if (txtsongaylamviec.Text == "")
            {
                snlv = 0;
            }
            else snlv = Convert.ToDouble(txtsongaylamviec.Text);
            if (txtluongcoban.Text == "")
            {
                lcb = 0;
            }
            else lcb = Convert.ToDouble(txtluongcoban.Text);
            if (txthesoluong.Text == "")
            {
                hsl = 0;
            }
            else hsl = Convert.ToDouble(txthesoluong.Text);
            if (txtphucap.Text == "")
            {
                pc = 0;
            }
            else pc = Convert.ToDouble(txtphucap.Text);
            if (txtkhoantru.Text == "")
            {
                kt = 0;
            }
            else kt = Convert.ToDouble(txtkhoantru.Text);

            tl = lcb * hsl * snlv - kt + pc;
            txtthuclanh.Text = tl.ToString();
            string str;
            str = "select bangluong.tongluong from   nhanvien,bangluong where nhanvien.manv = bangluong.manv and bangluong.manv='" + cbbmanv.SelectedValue + "' ";
            txtthuclanh.Text = GetFieldValues(str);
            lbchu.Text = " " + ChuyenSoSangChuoi(double.Parse(txtthuclanh.Text));
            lbchu.ForeColor = Color.Red;
        }
        //Chuyển đổi từ số sang chữ
        //123 => một trăm hai ba đồng
        //1,123,000=>một triệu một trăm hai ba nghìn đồng
        //1,123,345,000 => một tỉ một trăm hai ba triệu ba trăm bốn lăm ngàn đồng
        static string[] mNumText = "không;một;hai;ba;bốn;năm;sáu;bảy;tám;chín".Split(';');
        //Viết hàm chuyển số hàng chục, giá trị truyền vào là số cần chuyển và một biến đọc phần lẻ hay không ví dụ 101 => một trăm lẻ một
        private static string DocHangChuc(double so, bool daydu)
        {
            string chuoi = "";
            //Hàm để lấy số hàng chục ví dụ 21/10 = 2
            Int64 chuc = Convert.ToInt64(Math.Floor((double)(so / 10)));
            //Lấy số hàng đơn vị bằng phép chia 21 % 10 = 1
            Int64 donvi = (Int64)so % 10;
            //Nếu số hàng chục tồn tại tức >=20
            if (chuc > 1)
            {
                chuoi = " " + mNumText[chuc] + " mươi";
                if (donvi == 1)
                {
                    chuoi += " mốt";
                }
            }
            else if (chuc == 1)
            {//Số hàng chục từ 10-19
                chuoi = " mười";
                if (donvi == 1)
                {
                    chuoi += " một";
                }
            }
            else if (daydu && donvi > 0)
            {//Nếu hàng đơn vị khác 0 và có các số hàng trăm ví dụ 101 => thì biến daydu = true => và sẽ đọc một trăm lẻ một
                chuoi = " lẻ";
            }
            if (donvi == 5 && chuc >= 1)
            {//Nếu đơn vị là số 5 và có hàng chục thì chuỗi sẽ là " lăm" chứ không phải là " năm"
                chuoi += " lăm";
            }
            else if (donvi > 1 || (donvi == 1 && chuc == 0))
            {
                chuoi += " " + mNumText[donvi];
            }
            return chuoi;
        }
        private static string DocHangTram(double so, bool daydu)
        {
            string chuoi = "";
            //Lấy số hàng trăm ví du 434 / 100 = 4 (hàm Floor sẽ làm tròn số nguyên bé nhất)
            Int64 tram = Convert.ToInt64(Math.Floor((double)so / 100));
            //Lấy phần còn lại của hàng trăm 434 % 100 = 34 (dư 34)
            so = so % 100;
            if (daydu || tram > 0)
            {
                chuoi = " " + mNumText[tram] + " trăm";
                chuoi += DocHangChuc(so, true);
            }
            else
            {
                chuoi = DocHangChuc(so, false);
            }
            return chuoi;
        }
        private static string DocHangTrieu(double so, bool daydu)
        {
            string chuoi = "";
            //Lấy số hàng triệu
            Int64 trieu = Convert.ToInt64(Math.Floor((double)so / 1000000));
            //Lấy phần dư sau số hàng triệu ví dụ 2,123,000 => so = 123,000
            so = so % 1000000;
            if (trieu > 0)
            {
                chuoi = DocHangTram(trieu, daydu) + " triệu";
                daydu = true;
            }
            //Lấy số hàng nghìn
            Int64 nghin = Convert.ToInt64(Math.Floor((double)so / 1000));
            //Lấy phần dư sau số hàng nghin 
            so = so % 1000;
            if (nghin > 0)
            {
                chuoi += DocHangTram(nghin, daydu) + " nghìn";
                daydu = true;
            }
            if (so > 0)
            {
                chuoi += DocHangTram(so, daydu);
            }
            return chuoi;
        }
        public static string ChuyenSoSangChuoi(double so)
        {
            if (so == 0)
                return mNumText[0];
            string chuoi = "", hauto = "";
            Int64 ty;
            do
            {
                //Lấy số hàng tỷ
                ty = Convert.ToInt64(Math.Floor((double)so / 1000000000));
                //Lấy phần dư sau số hàng tỷ
                so = so % 1000000000;
                if (ty > 0)
                {
                    chuoi = DocHangTrieu(so, true) + hauto + chuoi;
                }
                else
                {
                    chuoi = DocHangTrieu(so, false) + hauto + chuoi;
                }
                hauto = " tỷ";
            } while (ty > 0);
            return chuoi + " đồng";
        }

        private void btntheml_MouseEnter(object sender, EventArgs e)
        {
            btntheml.ForeColor = Color.Black;
            btntheml.BackColor = Color.White;
        }

        private void btntheml_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void btntheml_MouseLeave(object sender, EventArgs e)
        {
            btntheml.ForeColor = Color.White;
            btntheml.BackColor = Color.Black;
        }

        private void btnsual_MouseEnter(object sender, EventArgs e)
        {

            btnsual.ForeColor = Color.Black;
            btnsual.BackColor = Color.White;
        }

        private void btnsual_MouseLeave(object sender, EventArgs e)
        {

            btnsual.ForeColor = Color.White;
            btnsual.BackColor = Color.Black;
        }

        private void btnxoal_MouseEnter(object sender, EventArgs e)
        {

            btnxoal.ForeColor = Color.Black;
            btnxoal.BackColor = Color.White;
        }

        private void btnxoal_MouseLeave(object sender, EventArgs e)
        {
            btnxoal.ForeColor = Color.White;
            btnxoal.BackColor = Color.Black;
        }

        private void btnmoil_MouseEnter(object sender, EventArgs e)
        {
            btnmoil.ForeColor = Color.Black;
            btnmoil.BackColor = Color.White;
        }

        private void btnmoil_MouseLeave(object sender, EventArgs e)
        {
            btnmoil.ForeColor = Color.White;
            btnmoil.BackColor = Color.Black;
        }

        private void btnluul_MouseEnter(object sender, EventArgs e)
        {
            btnluul.ForeColor = Color.Black;
            btnluul.BackColor = Color.White;
        }

        private void btnluul_MouseLeave(object sender, EventArgs e)
        {
            btnluul.ForeColor = Color.White;
            btnluul.BackColor = Color.Black;
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
    }
}
