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
    public partial class dangnhap : Form
    {
        public dangnhap()
        {
            InitializeComponent();
        }

        private void piceyes_Click(object sender, EventArgs e)
        {
            if (txtmk.PasswordChar == '\0')
            {
                txtmk.PasswordChar = '*';
                piceyes.Image = Properties.Resources.hide;
            }
            else
            {
                txtmk.PasswordChar = '\0';
                piceyes.Image = Properties.Resources.eye;
            }
        }
        public static string LoggedInUsername;
        public static string pass;

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

        private void picthoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        int count ;
        private void btndangnhap_Click(object sender, EventArgs e)
        {
            string tk = txttk.Text;
            string mk = txtmk.Text;
            string sql = " SELECT * from taikhoan WHERE taikhoan='" + tk + "' and matkhau='" + mk + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dta = cmd.ExecuteReader();
            if (dta.Read() == true)
            {
                LoggedInUsername = tk;
                pass = mk;
                MessageBox.Show(" Đăng nhập thành công !");
                this.Hide();
                // Lấy dữ liệu từ textbox
                string data = txttk.Text;

                trangchu tc = new trangchu();
                tc.Name = "home";
                tc.Show();

                // Gắn dữ liệu cho label bên form B
                tc.btntaikhoan.Text = "                " + data;


            }
            else
            {
                MessageBox.Show(" Đăng nhập thất bại do sai tài khoản hoặc mật khẩu !", " ⚠️Thông báo");
                count++;
                dta.Close();
            }
            if (count == 3)
            {
                MessageBox.Show("Đăng nhập thất bại , vui lòng thử lại trong ít phút ", " ⚠️Thông báo");
                this.Close();

            }
        }

        private void lbdk_Click(object sender, EventArgs e)
        {
            OpenChildForm(new dangky());
        }

        private void lbqmk_Click(object sender, EventArgs e)
        {
            OpenChildForm(new quenmatkhau());
        }
        private void panelright_Paint(object sender, PaintEventArgs e)
        {

        }
        // mở form con trên form cha 
        private Form currentFormChild;
        private void OpenChildForm(Form childForm)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            currentFormChild = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelright.Controls.Add(childForm);
            panelright.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

        }
        private void dangnhap_Load(object sender, EventArgs e)
        {
            ketNoicsdl();
            txttk.Focus();
        }

        private void btndangnhap_MouseEnter(object sender, EventArgs e)
        {
            btndangnhap.ForeColor = Color.Pink;
            btndangnhap.BackColor = Color.White;
        }

        private void btndangnhap_MouseLeave(object sender, EventArgs e)
        {
            btndangnhap.ForeColor = Color.White;
            btndangnhap.BackColor = Color.Pink;
        }
    }
}
