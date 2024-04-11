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
    public partial class baocao : Form
    {
        public baocao()
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
            panelbodybaocao.Controls.Add(childForm);
            panelbodybaocao.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

        }
        bool ismenuClicked1 = false;
        bool ismenuClicked2 = false;
        bool ismenuClicked3 = false;
        bool ismenuClicked4 = false;

        private void báoCáoChấmCôngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new baocaochamcong());
            ismenuClicked1 = true;

            // Đổi màu chữ thành trắng và màu nền thành đen khi click
            báoCáoChấmCôngToolStripMenuItem.ForeColor = Color.Black;
            báoCáoChấmCôngToolStripMenuItem.BackColor = Color.White;
            ismenuClicked2 = false;
            báoCáoLươngToolStripMenuItem.ForeColor = Color.White;
            báoCáoLươngToolStripMenuItem.BackColor = Color.Black;
            ismenuClicked3 = false;
            khenThưởngKỷLuậtToolStripMenuItem.ForeColor = Color.White;
            khenThưởngKỷLuậtToolStripMenuItem.BackColor = Color.Black;
            ismenuClicked4 = false;
            hồSơNhânViênToolStripMenuItem.ForeColor = Color.White;
            hồSơNhânViênToolStripMenuItem.BackColor = Color.Black;
        }

        private void báoCáoLươngToolStripMenuItem_Click(object sender, EventArgs e)
        {

            OpenChildForm(new baocaoluong());
            ismenuClicked2 = true;

            // Đổi màu chữ thành trắng và màu nền thành đen khi click
            báoCáoLươngToolStripMenuItem.ForeColor = Color.Black;
            báoCáoLươngToolStripMenuItem.BackColor = Color.White;
            ismenuClicked1 = false;
            báoCáoChấmCôngToolStripMenuItem.ForeColor = Color.White;
            báoCáoChấmCôngToolStripMenuItem.BackColor = Color.Black;
            ismenuClicked3 = false;
            khenThưởngKỷLuậtToolStripMenuItem.ForeColor = Color.White;
            khenThưởngKỷLuậtToolStripMenuItem.BackColor = Color.Black;
            ismenuClicked4 = false;
            hồSơNhânViênToolStripMenuItem.ForeColor = Color.White;
            hồSơNhânViênToolStripMenuItem.BackColor = Color.Black;
        }

        private void khenThưởngKỷLuậtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new baocaokhenthuongkyluat());
            ismenuClicked1 = false;
            báoCáoChấmCôngToolStripMenuItem.ForeColor = Color.White;
            báoCáoChấmCôngToolStripMenuItem.BackColor = Color.Black;
            ismenuClicked2 = false;
            báoCáoLươngToolStripMenuItem.ForeColor = Color.White;
            báoCáoLươngToolStripMenuItem.BackColor = Color.Black;
            ismenuClicked3 = true;

            // Đổi màu chữ thành trắng và màu nền thành đen khi click
            khenThưởngKỷLuậtToolStripMenuItem.ForeColor = Color.Black;
            khenThưởngKỷLuậtToolStripMenuItem.BackColor = Color.White;
            ismenuClicked4 = false;
            hồSơNhânViênToolStripMenuItem.ForeColor = Color.White;
            hồSơNhânViênToolStripMenuItem.BackColor = Color.Black;
        }

        private void hồSơNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {

            OpenChildForm(new baocaohosonhanvien());
            ismenuClicked1 = false;
            báoCáoChấmCôngToolStripMenuItem.ForeColor = Color.White;
            báoCáoChấmCôngToolStripMenuItem.BackColor = Color.Black;
            ismenuClicked2 = false;
            báoCáoLươngToolStripMenuItem.ForeColor = Color.White;
            báoCáoLươngToolStripMenuItem.BackColor = Color.Black;
            ismenuClicked3 = false;
            khenThưởngKỷLuậtToolStripMenuItem.ForeColor = Color.White;
            khenThưởngKỷLuậtToolStripMenuItem.BackColor = Color.Black;
            ismenuClicked4 = true;
            hồSơNhânViênToolStripMenuItem.ForeColor = Color.Black;
            hồSơNhânViênToolStripMenuItem.BackColor = Color.White;
        }
    }
}
