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
    public partial class quenmatkhau : Form
    {
        public quenmatkhau()
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
        private string RetrievePasswordFromDatabase(string email)
        {
            // Thực hiện truy vấn SQL để lấy mật khẩu từ cơ sở dữ liệu dựa trên email
            // Thay thế thông tin kết nối và truy vấn SQL theo cấu trúc cơ sở dữ liệu của bạn
            string query = "SELECT matkhau FROM taikhoan WHERE email = @email";

            using (SqlCommand command = new SqlCommand(query, con))
            {
                command.Parameters.AddWithValue("@email", email);

                // Thực hiện truy vấn và trả về mật khẩu 
                object result = command.ExecuteScalar();
                return (result != null) ? result.ToString() : string.Empty;

            }
        }
        private void picthoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnqmkxacnhan_Click(object sender, EventArgs e)
        {
            string email = txtqmkemail.Text;
            // Thực hiện truy vấn SQL để lấy mật khẩu từ cơ sở dữ liệu dựa trên email
            string matkhau = RetrievePasswordFromDatabase(email);

            if (!string.IsNullOrEmpty(matkhau))
            {
                // Hiển thị mật khẩu 
                MessageBox.Show($"Mật khẩu của bạn là: {matkhau}", "Thông tin mật khẩu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            else
            {
                MessageBox.Show("Không tìm thấy mật khẩu cho email này.", " ⚠️Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void quenmatkhau_Load(object sender, EventArgs e)
        {
            ketNoicsdl();
        }

        private void btnqmkxacnhan_MouseEnter(object sender, EventArgs e)
        {
            btnqmkxacnhan.ForeColor = Color.Pink;
            btnqmkxacnhan.BackColor = Color.White;
        }

        private void btnqmkxacnhan_MouseLeave(object sender, EventArgs e)
        {
            btnqmkxacnhan.ForeColor = Color.White;
            btnqmkxacnhan.BackColor = Color.Pink;
        }
    }
}
