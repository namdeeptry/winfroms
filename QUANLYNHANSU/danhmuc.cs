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
    public partial class danhmuc : Form
    {
        public danhmuc()
        {
            InitializeComponent();
        }
        bool ismenuClicked1 = false;
        bool ismenuClicked2 = false;
        bool ismenuClicked3 = false;
        bool ismenuClicked4 = false;
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
            panelbodyhsnv.Controls.Add(childForm);
            panelbodyhsnv.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

        }

        private void hồSơNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new hosonhanvien());
            ismenuClicked1 = true;

            // Đổi màu chữ thành trắng và màu nền thành đen khi click
            hồSơNhânViênToolStripMenuItem.ForeColor = Color.Black;
            hồSơNhânViênToolStripMenuItem.BackColor = Color.White;
            ismenuClicked2 = false;
            phòngBanToolStripMenuItem.ForeColor = Color.White;
            phòngBanToolStripMenuItem.BackColor = Color.Black;
            ismenuClicked3 = false;
            chứcVụToolStripMenuItem.ForeColor = Color.White;
            chứcVụToolStripMenuItem.BackColor = Color.Black;
            ismenuClicked4 = false;
            trìnhĐộToolStripMenuItem.ForeColor = Color.White;
            trìnhĐộToolStripMenuItem.BackColor = Color.Black;
        }

        private void phòngBanToolStripMenuItem_Click(object sender, EventArgs e)
        {

            OpenChildForm(new phongban());
            ismenuClicked2 = true;

            // Đổi màu chữ thành trắng và màu nền thành đen khi click
            phòngBanToolStripMenuItem.ForeColor = Color.Black;
            phòngBanToolStripMenuItem.BackColor = Color.White;
            ismenuClicked1 = false;
            hồSơNhânViênToolStripMenuItem.ForeColor = Color.White;
            hồSơNhânViênToolStripMenuItem.BackColor = Color.Black;
            ismenuClicked3 = false;
            chứcVụToolStripMenuItem.ForeColor = Color.White;
            chứcVụToolStripMenuItem.BackColor = Color.Black;
            ismenuClicked4 = false;
            trìnhĐộToolStripMenuItem.ForeColor = Color.White;
            trìnhĐộToolStripMenuItem.BackColor = Color.Black;
        }

        private void chứcVụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new chucvu());
            ismenuClicked3 = true;

            // Đổi màu chữ thành trắng và màu nền thành đen khi click
            chứcVụToolStripMenuItem.ForeColor = Color.Black;
            chứcVụToolStripMenuItem.BackColor = Color.White;
            ismenuClicked1 = false;
            hồSơNhânViênToolStripMenuItem.ForeColor = Color.White;
            hồSơNhânViênToolStripMenuItem.BackColor = Color.Black;
            ismenuClicked2 = false;
            phòngBanToolStripMenuItem.ForeColor = Color.White;
            phòngBanToolStripMenuItem.BackColor = Color.Black;
            ismenuClicked4 = false;
            trìnhĐộToolStripMenuItem.ForeColor = Color.White;
            trìnhĐộToolStripMenuItem.BackColor = Color.Black;
        }

        private void trìnhĐộToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new trinhdo());
            ismenuClicked4 = true;

            // Đổi màu chữ thành trắng và màu nền thành đen khi click
            trìnhĐộToolStripMenuItem.ForeColor = Color.Black;
            trìnhĐộToolStripMenuItem.BackColor = Color.White;
            ismenuClicked1 = false;
            hồSơNhânViênToolStripMenuItem.ForeColor = Color.White;
            hồSơNhânViênToolStripMenuItem.BackColor = Color.Black;
            ismenuClicked2 = false;
            phòngBanToolStripMenuItem.ForeColor = Color.White;
            phòngBanToolStripMenuItem.BackColor = Color.Black;
            ismenuClicked3 = false;
            chứcVụToolStripMenuItem.ForeColor = Color.White;
            chứcVụToolStripMenuItem.BackColor = Color.Black;
        }
    }
}
