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
    public partial class trangchu : Form
    {
        public trangchu()
        {
            InitializeComponent();
        }
        bool sidebarExpand;
        bool tk;
        public static string user;
       
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
                MessageBox.Show(" Kết nối thành công !");
            }
            catch
            {
                MessageBox.Show("Kết nối thất bại  ");
            }
        }
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
            panelbody.Controls.Add(childForm);
            panelbody.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

        }
        private void tktimer_Tick(object sender, EventArgs e)
        {
            if (tk)
            {
                paneltk.Height += 10;
                if (paneltk.Height == paneltk.MaximumSize.Height)
                {
                    tk = false;
                    tktimer.Stop();
                }
            }
            else
            {
                paneltk.Height -= 10;
                if (paneltk.Height == paneltk.MinimumSize.Height)
                {
                    tk = true;
                    tktimer.Stop();
                }
            }
        }

        private void sidebartimer_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                // if sidebar is expand, minimize
                sidebar.Width -= 10;
                if (sidebar.Width == sidebar.MinimumSize.Width)
                {
                    sidebarExpand = false;
                    sidebartimer.Stop();
                }
            }
            else
            {
                sidebar.Width += 10;
                if (sidebar.Width == sidebar.MaximumSize.Width)
                {
                    sidebarExpand = true;
                    sidebartimer.Stop();
                }
            }
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            thugontaikhoan();
            isButtonClicked = false;
            btndanhmuc.ForeColor = Color.White;
            btndanhmuc.BackColor = Color.Black;
            isButtonClicked2 = false;
            btnquanly.ForeColor = Color.White;
            btnquanly.BackColor = Color.Black;
            isButtonClicked3 = false;
            btntimkiem.ForeColor = Color.White;
            btntimkiem.BackColor = Color.Black;
            isButtonClicked4 = false;
            btnbaocao.ForeColor = Color.White;
            btnbaocao.BackColor = Color.Black;
            isButtonClicked5 = false;
            btntrogiup.ForeColor = Color.White;
            btntrogiup.BackColor = Color.Black;
            isButtonClicked6 = true;
            btnthoat.ForeColor = Color.Black;
            btnthoat.BackColor = Color.White;
            isButtonClicked7 = false;
            btntaikhoan.ForeColor = Color.White;
            btntaikhoan.BackColor = Color.Black;
            isButtonClicked8 = false;
            label1.ForeColor = Color.White;
            label1.BackColor = Color.Black;
            pictureBox1.ForeColor = Color.White;
            pictureBox1.BackColor = Color.Black;
            panel1.BackColor = Color.Black;
            isButtonClicked9 = false;
            btndx.ForeColor = Color.White;
            btndx.BackColor = Color.Black;
            isButtonClicked10 = false;
            btndoimatkhau.ForeColor = Color.White;
            btndoimatkhau.BackColor = Color.Black;

            DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn thoát không ?", "♠️ Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close(); // Thoát ứng dụng khi người dùng chọn "Yes"
            }
        }

        private void trangchu_Load(object sender, EventArgs e)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            OpenChildForm(new menu());
            isButtonClicked = false;
            btndanhmuc.ForeColor = Color.White;
            btndanhmuc.BackColor = Color.Black;
            isButtonClicked2 = false;
            btnquanly.ForeColor = Color.White;
            btnquanly.BackColor = Color.Black;
            isButtonClicked3 = false;
            btntimkiem.ForeColor = Color.White;
            btntimkiem.BackColor = Color.Black;
            isButtonClicked4 = false;
            btnbaocao.ForeColor = Color.White;
            btnbaocao.BackColor = Color.Black;
            isButtonClicked5 = false;
            btntrogiup.ForeColor = Color.White;
            btntrogiup.BackColor = Color.Black;
            isButtonClicked6 = false;
            btnthoat.ForeColor = Color.White;
            btnthoat.BackColor = Color.Black;
            isButtonClicked7 = false;
            btntaikhoan.ForeColor = Color.White;
            btntaikhoan.BackColor = Color.Black;
            isButtonClicked8 = true;
            label1.ForeColor = Color.Black;
            label1.BackColor = Color.White;
            pictureBox1.ForeColor = Color.Black;
            pictureBox1.BackColor = Color.White;
            panel1.BackColor = Color.White;
            isButtonClicked9 = false;
            btndx.ForeColor = Color.White;
            btndx.BackColor = Color.Black;
            isButtonClicked10 = false;
            btndoimatkhau.ForeColor = Color.White;
            btndoimatkhau.BackColor = Color.Black;
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            sidebartimer.Start();
            isButtonClicked = false;
            btndanhmuc.ForeColor = Color.White;
            btndanhmuc.BackColor = Color.Black;
            isButtonClicked2 = false;
            btnquanly.ForeColor = Color.White;
            btnquanly.BackColor = Color.Black;
            isButtonClicked3 = false;
            btntimkiem.ForeColor = Color.White;
            btntimkiem.BackColor = Color.Black;
            isButtonClicked4 = false;
            btnbaocao.ForeColor = Color.White;
            btnbaocao.BackColor = Color.Black;
            isButtonClicked5 = false;
            btntrogiup.ForeColor = Color.White;
            btntrogiup.BackColor = Color.Black;
            isButtonClicked6 = false;
            btnthoat.ForeColor = Color.White;
            btnthoat.BackColor = Color.Black;
            isButtonClicked7 = false;
            btntaikhoan.ForeColor = Color.White;
            btntaikhoan.BackColor = Color.Black;
            isButtonClicked8 = true;
            label1.ForeColor = Color.Black;
            label1.BackColor = Color.White;
            pictureBox1.ForeColor = Color.Black;
            pictureBox1.BackColor = Color.White;
            panel1.BackColor = Color.White;
            isButtonClicked9 = false;
            btndx.ForeColor = Color.White;
            btndx.BackColor = Color.Black;
            isButtonClicked10 = false;
            btndoimatkhau.ForeColor = Color.White;
            btndoimatkhau.BackColor = Color.Black;
            thugontaikhoan();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            isButtonClicked = false;
            btndanhmuc.ForeColor = Color.White;
            btndanhmuc.BackColor = Color.Black;
            isButtonClicked2 = false;
            btnquanly.ForeColor = Color.White;
            btnquanly.BackColor = Color.Black;
            isButtonClicked3 = false;
            btntimkiem.ForeColor = Color.White;
            btntimkiem.BackColor = Color.Black;
            isButtonClicked4 = false;
            btnbaocao.ForeColor = Color.White;
            btnbaocao.BackColor = Color.Black;
            isButtonClicked5 = false;
            btntrogiup.ForeColor = Color.White;
            btntrogiup.BackColor = Color.Black;
            isButtonClicked6 = false;
            btnthoat.ForeColor = Color.White;
            btnthoat.BackColor = Color.Black;
            isButtonClicked7 = false;
            btntaikhoan.ForeColor = Color.White;
            btntaikhoan.BackColor = Color.Black;
            isButtonClicked8 = true;
            label1.ForeColor = Color.Black;
            label1.BackColor = Color.White;
            pictureBox1.ForeColor = Color.Black;
            pictureBox1.BackColor = Color.White;
            panel1.BackColor = Color.White;
            isButtonClicked9 = false;
            btndx.ForeColor = Color.White;
            btndx.BackColor = Color.Black;
            isButtonClicked10 = false;
            btndoimatkhau.ForeColor = Color.White;
            btndoimatkhau.BackColor = Color.Black;
        }
        bool isButtonClicked = false;
        bool isButtonClicked2 = false;
        bool isButtonClicked3 = false;
        bool isButtonClicked4 = false;
        bool isButtonClicked5 = false;
        bool isButtonClicked6 = false;
        bool isButtonClicked7 = false;
        bool isButtonClicked8 = false;
        bool isButtonClicked9 = false;
        bool isButtonClicked10 = false;

        private void btndanhmuc_Click(object sender, EventArgs e)
        {
            OpenChildForm(new danhmuc());
            // Đặt trạng thái đã click cho button hiện tại
            isButtonClicked = true;

            // Đổi màu chữ thành trắng và màu nền thành đen khi click
            btndanhmuc.ForeColor = Color.Black;
            btndanhmuc.BackColor = Color.White;

            isButtonClicked2 = false;
            btnquanly.ForeColor = Color.White;
            btnquanly.BackColor = Color.Black;
            isButtonClicked3 = false;
            btntimkiem.ForeColor = Color.White;
            btntimkiem.BackColor = Color.Black;
            isButtonClicked4 = false;
            btnbaocao.ForeColor = Color.White;
            btnbaocao.BackColor = Color.Black;
            isButtonClicked5 = false;
            btntrogiup.ForeColor = Color.White;
            btntrogiup.BackColor = Color.Black;
            isButtonClicked6 = false;
            btnthoat.ForeColor = Color.White;
            btnthoat.BackColor = Color.Black;
            isButtonClicked7 = false;
            btntaikhoan.ForeColor = Color.White;
            btntaikhoan.BackColor = Color.Black;
            isButtonClicked8 = false;
            label1.ForeColor = Color.White;
            label1.BackColor = Color.Black;
            pictureBox1.ForeColor = Color.White;
            pictureBox1.BackColor = Color.Black;
            panel1.BackColor = Color.Black;
            isButtonClicked9 = false;
            btndx.ForeColor = Color.White;
            btndx.BackColor = Color.Black;
            isButtonClicked10 = false;
            btndoimatkhau.ForeColor = Color.White;
            btndoimatkhau.BackColor = Color.Black;
            thugontaikhoan();
            // Reset trạng thái của các button khác nếu có
            // Ví dụ: Nếu bạn có nhiều button, hãy đặt trạng thái của chúng thành false
            // để đảm bảo chỉ có một button được chọn màu trắng nền đen
        }

        private void btnquanly_Click(object sender, EventArgs e)
        {
            OpenChildForm(new quanly());
            // Reset trạng thái của button hiện tại khi chọn button khác
            isButtonClicked = false;
            btndanhmuc.ForeColor = Color.White;
            btndanhmuc.BackColor = Color.Black;

            isButtonClicked2 = true;
            btnquanly.ForeColor = Color.Black;
            btnquanly.BackColor = Color.White;
            isButtonClicked3 = false;
            btntimkiem.ForeColor = Color.White;
            btntimkiem.BackColor = Color.Black;
            isButtonClicked4 = false;
            btnbaocao.ForeColor = Color.White;
            btnbaocao.BackColor = Color.Black;
            isButtonClicked5 = false;
            btntrogiup.ForeColor = Color.White;
            btntrogiup.BackColor = Color.Black;
            isButtonClicked6 = false;
            btnthoat.ForeColor = Color.White;
            btnthoat.BackColor = Color.Black;
            isButtonClicked7 = false;
            btntaikhoan.ForeColor = Color.White;
            btntaikhoan.BackColor = Color.Black;
            isButtonClicked8 = false;
            label1.ForeColor = Color.White;
            label1.BackColor = Color.Black;
            pictureBox1.ForeColor = Color.White;
            pictureBox1.BackColor = Color.Black;
            panel1.BackColor = Color.Black;
            isButtonClicked9 = false;
            btndx.ForeColor = Color.White;
            btndx.BackColor = Color.Black;
            isButtonClicked10 = false;
            btndoimatkhau.ForeColor = Color.White;
            btndoimatkhau.BackColor = Color.Black;
            thugontaikhoan();
            // Xử lý các thay đổi khác cho button được chọn mới
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new timkiem());
            isButtonClicked = false;
            btndanhmuc.ForeColor = Color.White;
            btndanhmuc.BackColor = Color.Black;
            isButtonClicked2 = false;
            btnquanly.ForeColor = Color.White;
            btnquanly.BackColor = Color.Black;

            isButtonClicked3 = true;
            btntimkiem.ForeColor = Color.Black;
            btntimkiem.BackColor = Color.White;
            isButtonClicked4 = false;
            btnbaocao.ForeColor = Color.White;
            btnbaocao.BackColor = Color.Black;
            isButtonClicked5 = false;
            btntrogiup.ForeColor = Color.White;
            btntrogiup.BackColor = Color.Black;
            isButtonClicked6 = false;
            btnthoat.ForeColor = Color.White;
            btnthoat.BackColor = Color.Black;
            isButtonClicked7 = false;
            btntaikhoan.ForeColor = Color.White;
            btntaikhoan.BackColor = Color.Black;
            isButtonClicked8 = false;
            label1.ForeColor = Color.White;
            label1.BackColor = Color.Black;
            pictureBox1.ForeColor = Color.White;
            pictureBox1.BackColor = Color.Black;
            panel1.BackColor = Color.Black;
            isButtonClicked9 = false;
            btndx.ForeColor = Color.White;
            btndx.BackColor = Color.Black;
            isButtonClicked10 = false;
            btndoimatkhau.ForeColor = Color.White;
            btndoimatkhau.BackColor = Color.Black;
            thugontaikhoan();
        }

        private void btnbaocao_Click(object sender, EventArgs e)
        {
            OpenChildForm(new baocao());
            isButtonClicked = false;
            btndanhmuc.ForeColor = Color.White;
            btndanhmuc.BackColor = Color.Black;
            isButtonClicked2 = false;
            btnquanly.ForeColor = Color.White;
            btnquanly.BackColor = Color.Black;
            isButtonClicked3 = false;
            btntimkiem.ForeColor = Color.White;
            btntimkiem.BackColor = Color.Black;
            isButtonClicked4 = true;
            btnbaocao.ForeColor = Color.Black;
            btnbaocao.BackColor = Color.White;
            isButtonClicked5 = false;
            btntrogiup.ForeColor = Color.White;
            btntrogiup.BackColor = Color.Black;
            isButtonClicked6 = false;
            btnthoat.ForeColor = Color.White;
            btnthoat.BackColor = Color.Black;
            isButtonClicked7 = false;
            btntaikhoan.ForeColor = Color.White;
            btntaikhoan.BackColor = Color.Black;
            isButtonClicked8 = false;
            label1.ForeColor = Color.White;
            label1.BackColor = Color.Black;
            pictureBox1.ForeColor = Color.White;
            pictureBox1.BackColor = Color.Black;
            panel1.BackColor = Color.Black;
            isButtonClicked9 = false;
            btndx.ForeColor = Color.White;
            btndx.BackColor = Color.Black;
            isButtonClicked10 = false;
            btndoimatkhau.ForeColor = Color.White;
            btndoimatkhau.BackColor = Color.Black;
            thugontaikhoan();
        }

        private void btntrogiup_Click(object sender, EventArgs e)
        {
            OpenChildForm(new trogiup());
            isButtonClicked = false;
            btndanhmuc.ForeColor = Color.White;
            btndanhmuc.BackColor = Color.Black;
            isButtonClicked2 = false;
            btnquanly.ForeColor = Color.White;
            btnquanly.BackColor = Color.Black;
            isButtonClicked3 = false;
            btntimkiem.ForeColor = Color.White;
            btntimkiem.BackColor = Color.Black;
            isButtonClicked4 = false;
            btnbaocao.ForeColor = Color.White;
            btnbaocao.BackColor = Color.Black;
            isButtonClicked5 = true;
            btntrogiup.ForeColor = Color.Black;
            btntrogiup.BackColor = Color.White;
            isButtonClicked6 = false;
            btnthoat.ForeColor = Color.White;
            btnthoat.BackColor = Color.Black;
            isButtonClicked7 = false;
            btntaikhoan.ForeColor = Color.White;
            btntaikhoan.BackColor = Color.Black;
            isButtonClicked8 = false;
            label1.ForeColor = Color.White;
            label1.BackColor = Color.Black;
            pictureBox1.ForeColor = Color.White;
            pictureBox1.BackColor = Color.Black;
            panel1.BackColor = Color.Black;
            isButtonClicked9 = false;
            btndx.ForeColor = Color.White;
            btndx.BackColor = Color.Black;
            isButtonClicked10 = false;
            btndoimatkhau.ForeColor = Color.White;
            btndoimatkhau.BackColor = Color.Black;
            thugontaikhoan();
        }

        private void btntaikhoan_Click(object sender, EventArgs e)
        {
            tktimer.Start();
            isButtonClicked = false;
            btndanhmuc.ForeColor = Color.White;
            btndanhmuc.BackColor = Color.Black;
            isButtonClicked2 = false;
            btnquanly.ForeColor = Color.White;
            btnquanly.BackColor = Color.Black;
            isButtonClicked3 = false;
            btntimkiem.ForeColor = Color.White;
            btntimkiem.BackColor = Color.Black;
            isButtonClicked4 = false;
            btnbaocao.ForeColor = Color.White;
            btnbaocao.BackColor = Color.Black;
            isButtonClicked5 = false;
            btntrogiup.ForeColor = Color.White;
            btntrogiup.BackColor = Color.Black;
            isButtonClicked6 = false;
            btnthoat.ForeColor = Color.White;
            btnthoat.BackColor = Color.Black;
            isButtonClicked7 = true;
            btntaikhoan.ForeColor = Color.Black;
            btntaikhoan.BackColor = Color.White;
            isButtonClicked8 = false;
            label1.ForeColor = Color.White;
            label1.BackColor = Color.Black;
            pictureBox1.ForeColor = Color.White;
            pictureBox1.BackColor = Color.Black;
            panel1.BackColor = Color.Black;
            isButtonClicked9 = false;
            btndx.ForeColor = Color.White;
            btndx.BackColor = Color.Black;
            isButtonClicked10 = false;
            btndoimatkhau.ForeColor = Color.White;
            btndoimatkhau.BackColor = Color.Black;
            user = btntaikhoan.Text.Trim();
        }

        private void btnmin_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnmax_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void btndx_Click(object sender, EventArgs e)
        {
            isButtonClicked9= true;
            btndx.ForeColor = Color.Black;
            btndx.BackColor = Color.WhiteSmoke;
            isButtonClicked10 = false;
            btndoimatkhau.ForeColor = Color.White;
            btndoimatkhau.BackColor = Color.Black;
            isButtonClicked = false;
            btndanhmuc.ForeColor = Color.White;
            btndanhmuc.BackColor = Color.Black;
            isButtonClicked2 = false;
            btnquanly.ForeColor = Color.White;
            btnquanly.BackColor = Color.Black;
            isButtonClicked3 = false;
            btntimkiem.ForeColor = Color.White;
            btntimkiem.BackColor = Color.Black;
            isButtonClicked4 = false;
            btnbaocao.ForeColor = Color.White;
            btnbaocao.BackColor = Color.Black;
            isButtonClicked5 = false;
            btntrogiup.ForeColor = Color.White;
            btntrogiup.BackColor = Color.Black;
            isButtonClicked6 = false;
            btnthoat.ForeColor = Color.White;
            btnthoat.BackColor = Color.Black;
            isButtonClicked7 = true;
            btntaikhoan.ForeColor = Color.Black;
            btntaikhoan.BackColor = Color.White;
            isButtonClicked8 = false;
            label1.ForeColor = Color.White;
            label1.BackColor = Color.Black;
            pictureBox1.ForeColor = Color.White;
            pictureBox1.BackColor = Color.Black;
            panel1.BackColor = Color.Black;

            DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn đăng xuất không ?", "♠️ Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
                dangnhap dn = new dangnhap();
                dn.Show();
            }
        }

        private void btndoimatkhau_Click(object sender, EventArgs e)
        {
            isButtonClicked10 = true;
            btndoimatkhau.ForeColor = Color.Black;
            btndoimatkhau.BackColor = Color.WhiteSmoke;
            isButtonClicked = false;
            btndanhmuc.ForeColor = Color.White;
            btndanhmuc.BackColor = Color.Black;
            isButtonClicked2 = false;
            btnquanly.ForeColor = Color.White;
            btnquanly.BackColor = Color.Black;
            isButtonClicked3 = false;
            btntimkiem.ForeColor = Color.White;
            btntimkiem.BackColor = Color.Black;
            isButtonClicked4 = false;
            btnbaocao.ForeColor = Color.White;
            btnbaocao.BackColor = Color.Black;
            isButtonClicked5 = false;
            btntrogiup.ForeColor = Color.White;
            btntrogiup.BackColor = Color.Black;
            isButtonClicked6 = false;
            btnthoat.ForeColor = Color.White;
            btnthoat.BackColor = Color.Black;
            isButtonClicked7 = true;
            btntaikhoan.ForeColor = Color.Black;
            btntaikhoan.BackColor = Color.White;
            isButtonClicked8 = false;
            label1.ForeColor = Color.White;
            label1.BackColor = Color.Black;
            pictureBox1.ForeColor = Color.White;
            pictureBox1.BackColor = Color.Black;
            panel1.BackColor = Color.Black;
            isButtonClicked9 = false;
           btndx.ForeColor = Color.White;
            btndx.BackColor = Color.Black;
           

            doimatkhau dmk = new doimatkhau();
            dmk.ShowDialog();
        }

        private void btndanhmuc_MouseEnter(object sender, EventArgs e)
        {
            if (!isButtonClicked)
            {
                btndanhmuc.ForeColor = Color.Black;
                btndanhmuc.BackColor = Color.White;
            }
        }

        private void btndanhmuc_MouseLeave(object sender, EventArgs e)
        {

            if (!isButtonClicked)
            {
                btndanhmuc.ForeColor = Color.White;
                btndanhmuc.BackColor = Color.Black;
            }
        }

        private void btnquanly_MouseEnter(object sender, EventArgs e)
        {

            if (!isButtonClicked2)
            {
                btnquanly.ForeColor = Color.Black;
                btnquanly.BackColor = Color.White;
            }
        }

        private void btnquanly_MouseLeave(object sender, EventArgs e)
        {
            if (!isButtonClicked2)
            {
                btnquanly.ForeColor = Color.White;
                btnquanly.BackColor = Color.Black;
            }
        }

        private void btntimkiem_MouseEnter(object sender, EventArgs e)
        {
            if (!isButtonClicked3)
            {
                btntimkiem.ForeColor = Color.Black;
                btntimkiem.BackColor = Color.White;
            }
        }

        private void btntimkiem_MouseLeave(object sender, EventArgs e)
        {

            if (!isButtonClicked3)
            {
                btntimkiem.ForeColor = Color.White;
                btntimkiem.BackColor = Color.Black;
            }
        }

        private void btnbaocao_MouseEnter(object sender, EventArgs e)
        {
            if (!isButtonClicked4)
            {
                btnbaocao.ForeColor = Color.Black;
                btnbaocao.BackColor = Color.White;
            }
        }

        private void btnbaocao_MouseLeave(object sender, EventArgs e)
        {
            if (!isButtonClicked4)
            {
                btnbaocao.ForeColor = Color.White;
                btnbaocao.BackColor = Color.Black;
            }
        }

        private void btntrogiup_MouseEnter(object sender, EventArgs e)
        {
            if (!isButtonClicked5)
            {
                btntrogiup.ForeColor = Color.Black;
                btntrogiup.BackColor = Color.White;
            }
        }

        private void btntrogiup_MouseLeave(object sender, EventArgs e)
        {
            if (!isButtonClicked5)
            {
                btntrogiup.ForeColor = Color.White;
                btntrogiup.BackColor = Color.Black;
            }
        }

        private void btnthoat_MouseEnter(object sender, EventArgs e)
        {
            if (!isButtonClicked6)
            {
                btnthoat.ForeColor = Color.Black;
                btnthoat.BackColor = Color.White;
            }
        }

        private void btnthoat_MouseLeave(object sender, EventArgs e)
        {
            if (!isButtonClicked6)
            {
                btnthoat.ForeColor = Color.White;
                btnthoat.BackColor = Color.Black;
            }
        }

        private void btntaikhoan_MouseEnter(object sender, EventArgs e)
        {
            if (!isButtonClicked7)
            {
                btntaikhoan.ForeColor = Color.Black;
                btntaikhoan.BackColor = Color.White;
            }
        }

        private void btntaikhoan_MouseLeave(object sender, EventArgs e)
        {
            if (!isButtonClicked7)
            {
                btntaikhoan.ForeColor = Color.White;
                btntaikhoan.BackColor = Color.Black;
            }
        }

        private void panel1_MouseEnter(object sender, EventArgs e)
        {
            if (!isButtonClicked8)
            {
                panel1.BackColor = Color.White;
            }

            if (!isButtonClicked8)
            {
                pictureBox1.ForeColor = Color.Black;
                pictureBox1.BackColor = Color.White;
            }
            if (!isButtonClicked8)
            {
                label1.ForeColor = Color.Black;
                label1.BackColor = Color.White;
            }
        }

        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            if (!isButtonClicked8)
            {
                panel1.BackColor = Color.Black;
            }
            if (!isButtonClicked8)
            {
                pictureBox1.ForeColor = Color.White;
                pictureBox1.BackColor = Color.Black;
            }
            if (!isButtonClicked8)
            {
                label1.ForeColor = Color.White;
                label1.BackColor = Color.Black;
            }
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            OpenChildForm(new menu());
            isButtonClicked = false;
            btndanhmuc.ForeColor = Color.White;
            btndanhmuc.BackColor = Color.Black;
            isButtonClicked2 = false;
            btnquanly.ForeColor = Color.White;
            btnquanly.BackColor = Color.Black;
            isButtonClicked3 = false;
            btntimkiem.ForeColor = Color.White;
            btntimkiem.BackColor = Color.Black;
            isButtonClicked4 = false;
            btnbaocao.ForeColor = Color.White;
            btnbaocao.BackColor = Color.Black;
            isButtonClicked5 = false;
            btntrogiup.ForeColor = Color.White;
            btntrogiup.BackColor = Color.Black;
            isButtonClicked6 = false;
            btnthoat.ForeColor = Color.White;
            btnthoat.BackColor = Color.Black;
            isButtonClicked7 = false;
            btntaikhoan.ForeColor = Color.White;
            btntaikhoan.BackColor = Color.Black;
            isButtonClicked8 = true;
            label1.ForeColor = Color.Black;
            label1.BackColor = Color.White;
            pictureBox1.ForeColor = Color.Black;
            pictureBox1.BackColor = Color.White;
            panel1.BackColor = Color.White;
            isButtonClicked9 = false;
            btndx.ForeColor = Color.White;
            btndx.BackColor = Color.Black;
            isButtonClicked10 = false;
            btndoimatkhau.ForeColor = Color.White;
            btndoimatkhau.BackColor = Color.Black;
            thugontaikhoan();
        }
        private void thugontaikhoan()
        {
            paneltk.Height -= 100;
            if (paneltk.Height == paneltk.MinimumSize.Height)
            {
                tk = true;
                tktimer.Stop();
            }
        }

        private void btndx_MouseEnter(object sender, EventArgs e)
        {
            if (!isButtonClicked9)
            {
               btndx.ForeColor = Color.Black;
                btndx.BackColor = Color.White;
            }
        }

        private void btndx_MouseLeave(object sender, EventArgs e)
        {
             if (!isButtonClicked9)
            {
               btndx.ForeColor = Color.White;
                btndx.BackColor = Color.Black;
            }
        }

        private void btndoimatkhau_MouseEnter(object sender, EventArgs e)
        {
            if (!isButtonClicked10)
            {
                btndoimatkhau.ForeColor = Color.Black;
                btndoimatkhau.BackColor = Color.White;
            }
        }

        private void btndoimatkhau_MouseLeave(object sender, EventArgs e)
        {
            if (!isButtonClicked10)
            {
                btndoimatkhau.ForeColor = Color.White;
                btndoimatkhau.BackColor = Color.Black;
            }
        }
    }
}
