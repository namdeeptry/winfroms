using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QUANLYNHANSU
{
    public partial class timkiem : Form
    {
        public timkiem()
        {
            InitializeComponent();
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
            panelbodytimkiem.Controls.Add(childForm);
            panelbodytimkiem.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

        }
        bool ismenuClicked1 = false;
        bool ismenuClicked2 = false;
        private void timToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new timkiemtheophongban());
            ismenuClicked1 = true;

            // Đổi màu chữ thành trắng và màu nền thành đen khi click
            timToolStripMenuItem.ForeColor = Color.Black;
            timToolStripMenuItem.BackColor = Color.White;
            ismenuClicked2 = false;
            tìmKiếmTheoMãNhânViênToolStripMenuItem.ForeColor = Color.White;
            tìmKiếmTheoMãNhânViênToolStripMenuItem.BackColor = Color.Black;
        }

        private void tìmKiếmTheoMãNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new timkiemtheomanhanvien());
            ismenuClicked1 = false;

            // Đổi màu chữ thành trắng và màu nền thành đen khi click
            timToolStripMenuItem.ForeColor = Color.White;
            timToolStripMenuItem.BackColor = Color.Black;
            ismenuClicked2 = true;
            tìmKiếmTheoMãNhânViênToolStripMenuItem.ForeColor = Color.Black;
            tìmKiếmTheoMãNhânViênToolStripMenuItem.BackColor = Color.White;
        }
    }
}
