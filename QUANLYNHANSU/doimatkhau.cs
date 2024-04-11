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
    public partial class doimatkhau : Form
    {
        public doimatkhau()
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
                                                             // MessageBox.Show(" Kết nối thành công !");
            }
            catch
            {
                MessageBox.Show("Kết nối thất bại  ");
            }
        }

        private void doimatkhau_Load(object sender, EventArgs e)
        {
            ketNoicsdl();
            string loggedInUsername = dangnhap.LoggedInUsername;
            DisplayAdminInfo(loggedInUsername);
            txttk.Text = dangnhap.LoggedInUsername;
            lbmk.Text = dangnhap.pass;
            // Hiển thị thông tin tương ứng trên Form2
        }
        private string connectionString = "Data Source=DESKTOP-8RC4J29\\SQLEXPRESS;Initial Catalog=QUANLYNHANSU;Integrated Security=True";
        private void DisplayAdminInfo(string username)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT taikhoan,matkhau FROM taikhoan WHERE taikhoan = @Username";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Username", username);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string type = reader["taikhoan"].ToString();
                        string pass = reader["matkhau"].ToString();
                        // Hiển thị tên và ảnh lên form
                        lbmk.Text = pass;
                        txttk.Text = username;
                    }

                    reader.Close();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi hiển thị thông tin admin: " + ex.Message);
            }
        }
        private void btnxacnhan_Click(object sender, EventArgs e)
        {
            string tenDangNhap = txttk.Text;
            string matKhauHienTai = txtmkcu.Text;
            string matKhauMoi = txtmkmoi.Text;
            string xacNhanMatKhauMoi = txtnhaplaimkmoi.Text;

            // Kết nối đến cơ sở dữ liệu
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                // Kiểm tra mật khẩu hiện tại
                string query = "SELECT taikhoan,matkhau FROM taikhoan WHERE taikhoan = @Username AND matkhau = @Password";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", tenDangNhap); // Thay thế bằng tên tài khoản thực tế
                    command.Parameters.AddWithValue("@Password", matKhauHienTai);

                    using (SqlDataReader reader1 = command.ExecuteReader())
                    {
                        if (!reader1.HasRows)
                        {
                            MessageBox.Show("Mật khẩu hiện tại không đúng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }

                // Kiểm tra mật khẩu mới và xác nhận mật khẩu mới
                if (matKhauMoi != xacNhanMatKhauMoi)
                {
                    MessageBox.Show("Mật khẩu mới không khớp với xác nhận mật khẩu mới", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (matKhauHienTai.Length == 0 && matKhauMoi.Length == 0 && xacNhanMatKhauMoi.Length == 0)
                {
                    MessageBox.Show(" Không được để trắng bất cứ thông tin mật khẩu nào !", " ⚠️Thông báo");

                }
                else
                {
                    if (matKhauHienTai == xacNhanMatKhauMoi)
                    {
                        MessageBox.Show(" Mật khẩu cũ trùng mới mật khẩu mới !", " ⚠️Thông báo");
                    }
                    else
                    {
                        // Cập nhật mật khẩu mới vào cơ sở dữ liệu
                        query = "UPDATE taikhoan SET matkhau = @Newpassword WHERE taikhoan = @Username";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@Username", tenDangNhap); // Thay thế bằng tên tài khoản thực tế
                            command.Parameters.AddWithValue("@Newpassword", matKhauMoi);

                            command.ExecuteNonQuery();

                            MessageBox.Show("Đổi mật khẩu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                    }

                }
            }
        }

        private void piceyes_Click(object sender, EventArgs e)
        {
            if (txtmkcu.PasswordChar == '\0')
            {
                txtmkcu.PasswordChar = '*';
                piceyes.Image = Properties.Resources.hide;
            }
            else
            {
                txtmkcu.PasswordChar = '\0';
                piceyes.Image = Properties.Resources.eye;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (txtmkmoi.PasswordChar == '\0')
            {
                txtmkmoi.PasswordChar = '*';
                pictureBox2.Image = Properties.Resources.hide;
            }
            else
            {
                txtmkmoi.PasswordChar = '\0';
                pictureBox2.Image = Properties.Resources.eye;
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (txtnhaplaimkmoi.PasswordChar == '\0')
            {
                txtnhaplaimkmoi.PasswordChar = '*';
                pictureBox3.Image = Properties.Resources.hide;
            }
            else
            {
                txtnhaplaimkmoi.PasswordChar = '\0';
                pictureBox3.Image = Properties.Resources.eye;
            }
        }

        private void picthoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
