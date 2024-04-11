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
using System.Text.RegularExpressions;

namespace QUANLYNHANSU
{
    public partial class dangky : Form
    {
        public dangky()
        {
            InitializeComponent();
        }
        // kết nối cơ sở dữ liệu 

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

        private void dangky_Load(object sender, EventArgs e)
        {
            txtdktk.Focus();
            ketNoicsdl();
        }
        static bool ContainsSpecialCharacters(string input)
        {
            // Biểu thức chính quy để kiểm tra chuỗi có chứa kí tự đặc biệt hay không
            Regex regex = new Regex("[^a-zA-Z0-9]"); // Loại bỏ ký tự không phải chữ cái và số

            return regex.IsMatch(input);
        }
        // kiểm tra tồn tại của tài khoản 
        static bool IsDataExists(string taikhoan)
        {
            string connectionString = "Data Source=DESKTOP-8RC4J29\\SQLEXPRESS;Initial Catalog=QUANLYNHANSU;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM taikhoan WHERE taikhoan = @taikhoan";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@taikhoan", taikhoan);

                int count = (int)command.ExecuteScalar();
                return count > 0; // Trả về true nếu dữ liệu đã tồn tại trong cơ sở dữ liệu
            }
        }
        // kiểm tra tồn tại của email
        static bool IsEmailExists(string email)
        {
            string connectionString = "Data Source=DESKTOP-8RC4J29\\SQLEXPRESS;Initial Catalog=QUANLYNHANSU;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM taikhoan WHERE email = @email";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@email", email);

                int count = (int)command.ExecuteScalar();
                return count > 0; // Trả về true nếu dữ liệu đã tồn tại trong cơ sở dữ liệu
            }
        }
        // kiểm tra có phải là email hay không 
        private bool IsValidGmailAddress(string email)
        {
            Regex regex = new Regex(@"^[a-zA-Z0-9._%+-]+@gmail\.com$");
            return regex.IsMatch(email);
        }
        private void reset()
        {
            txtdktk.Text = "";
            txtdkmk.Text = "";
            txtdkxnmk.Text = "";
            txtdkemail.Text = "";
        }
        private void btndangky_Click(object sender, EventArgs e)
        {
            string dktk = txtdktk.Text.Trim();
            string dkmk = txtdkmk.Text.Trim();
            string dkxnmk = txtdkxnmk.Text.Trim();
            string dkemail = txtdkemail.Text.Trim();
            string sqlthem = "insert into taikhoan values('" + dktk + "','" + dkmk + "','" + dkemail + "') ";
            if (!dktk.Equals("") && !dkmk.Equals("") && !dkxnmk.Equals("") && !dkemail.Equals(""))
            {
                if (!ContainsSpecialCharacters(dktk))
                {
                    if (!IsDataExists(dktk))
                    {
                        if (!IsEmailExists(dkemail))
                        {
                            if (dkmk == dkxnmk)
                            {
                                if (IsValidGmailAddress(dkemail))
                                {
                                    if (txtdktk.Text.Length <= 20)
                                    {
                                        try
                                        {
                                            SqlCommand cmd = new SqlCommand(sqlthem, con);
                                            cmd.ExecuteNonQuery();
                                            MessageBox.Show("Tạo tài khoản thành công nhấn OK để Quay lại trang đăng nhập  ");
                                            reset();
                                            Close();

                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show("Không thêm được do lỗi :" + ex.Message);
                                        }
                                    }
                                    else
                                    {
                                        txtdktk.SelectionStart = txtdktk.Text.Length; // Đặt vị trí con trỏ về cuối chuỗi
                                        MessageBox.Show("Chỉ được nhập tối đa 6-20 ký tự.", " ⚠️Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);// Thông báo cho người dùng khi vượt quá giới hạn ký tự
                                    }

                                }
                                else { MessageBox.Show("Email phải có định dạng @gmail.com", " ⚠️ Email không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning); txtdkemail.Focus(); }

                            }
                            else { MessageBox.Show("Mật khẩu nhập lại không trùng khớp vui lòng nhập lại mật khẩu   ! ", " ⚠️Thông báo"); txtdkmk.Focus(); txtdkmk.Text = ""; txtdkxnmk.Text = ""; }
                        }
                        else { MessageBox.Show("Email đã được đăng kí. Vui lòng chọn lại Email khác  ! ", " ⚠️Thông báo"); txtdkemail.Focus(); txtdkemail.Text = ""; }
                    }
                    // Thông báo cho người dùng nhập lại

                    else { MessageBox.Show("Tên tài khoản đã được dùng bởi user khác. Vui lòng tạo lại tài khoản ! ", " ⚠️Thông báo"); txtdktk.Focus(); txtdktk.Text = ""; }
                }
                else { MessageBox.Show("Tài khoản mật khẩu không chưa kí tự đặc biệt ! ", " ⚠️Thông báo"); txtdktk.Focus(); }
            }
            else { MessageBox.Show("Vui lòng nhập đầy đủ thông tin ! ", " ⚠️Thông báo"); }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btndangky_MouseEnter(object sender, EventArgs e)
        {
            btndangky.ForeColor = Color.Pink;
            btndangky.BackColor = Color.White;
        }

        private void btndangky_MouseLeave(object sender, EventArgs e)
        {
            btndangky.ForeColor = Color.White;
            btndangky.BackColor = Color.Pink;
        }
    }
}
