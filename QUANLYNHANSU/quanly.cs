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
    public partial class quanly : Form
    {
        public quanly()
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
            panel1.Controls.Add(childForm);
            panel1.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

        }
        bool ismenuClicked1 = false;
        bool ismenuClicked2 = false;
        bool ismenuClicked3 = false;
        bool ismenuClicked4 = false;
        bool ismenuClicked5 = false;
        private void chấmCôngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new chamcong());
            ismenuClicked1 = true;

            // Đổi màu chữ thành trắng và màu nền thành đen khi click
            chấmCôngToolStripMenuItem.ForeColor = Color.Black;
            chấmCôngToolStripMenuItem.BackColor = Color.White;
            ismenuClicked2 = false;
            lươngToolStripMenuItem.ForeColor = Color.White;
            lươngToolStripMenuItem.BackColor = Color.Black;
            ismenuClicked3 = false;
            hợpĐồngLaoĐộngToolStripMenuItem.ForeColor = Color.White;
            hợpĐồngLaoĐộngToolStripMenuItem.BackColor = Color.Black;
            ismenuClicked4 = false;
            bảoHiểmToolStripMenuItem.ForeColor = Color.White;
            bảoHiểmToolStripMenuItem.BackColor = Color.Black;
            ismenuClicked5 = false;
            khenThưởngKỷLuậtToolStripMenuItem.ForeColor = Color.White;
            khenThưởngKỷLuậtToolStripMenuItem.BackColor = Color.Black;
        }

        private void lươngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new luong());
            ismenuClicked2 = true;

            // Đổi màu chữ thành trắng và màu nền thành đen khi click
            lươngToolStripMenuItem.ForeColor = Color.Black;
            lươngToolStripMenuItem.BackColor = Color.White;
            ismenuClicked1 = false;
            chấmCôngToolStripMenuItem.ForeColor = Color.White;
            chấmCôngToolStripMenuItem.BackColor = Color.Black;
            ismenuClicked3 = false;
            hợpĐồngLaoĐộngToolStripMenuItem.ForeColor = Color.White;
            hợpĐồngLaoĐộngToolStripMenuItem.BackColor = Color.Black;
            ismenuClicked4 = false;
            bảoHiểmToolStripMenuItem.ForeColor = Color.White;
            bảoHiểmToolStripMenuItem.BackColor = Color.Black;
            ismenuClicked5 = false;
            khenThưởngKỷLuậtToolStripMenuItem.ForeColor = Color.White;
            khenThưởngKỷLuậtToolStripMenuItem.BackColor = Color.Black;
        }

        private void hợpĐồngLaoĐộngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new hopdonglaodong());
            ismenuClicked3 = true;

            // Đổi màu chữ thành trắng và màu nền thành đen khi click
            hợpĐồngLaoĐộngToolStripMenuItem.ForeColor = Color.Black;
            hợpĐồngLaoĐộngToolStripMenuItem.BackColor = Color.White;
            ismenuClicked1 = false;
            chấmCôngToolStripMenuItem.ForeColor = Color.White;
            chấmCôngToolStripMenuItem.BackColor = Color.Black;
            ismenuClicked2 = false;
            lươngToolStripMenuItem.ForeColor = Color.White;
            lươngToolStripMenuItem.BackColor = Color.Black;
            ismenuClicked4 = false;
            bảoHiểmToolStripMenuItem.ForeColor = Color.White;
            bảoHiểmToolStripMenuItem.BackColor = Color.Black;
            ismenuClicked5 = false;
            khenThưởngKỷLuậtToolStripMenuItem.ForeColor = Color.White;
            khenThưởngKỷLuậtToolStripMenuItem.BackColor = Color.Black;
        }

        private void bảoHiểmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new baohiem());
            ismenuClicked4 = true;

            // Đổi màu chữ thành trắng và màu nền thành đen khi click
            bảoHiểmToolStripMenuItem.ForeColor = Color.Black;
            bảoHiểmToolStripMenuItem.BackColor = Color.White;
            ismenuClicked1 = false;
            chấmCôngToolStripMenuItem.ForeColor = Color.White;
            chấmCôngToolStripMenuItem.BackColor = Color.Black;
            ismenuClicked2 = false;
            lươngToolStripMenuItem.ForeColor = Color.White;
            lươngToolStripMenuItem.BackColor = Color.Black;
            ismenuClicked3 = false;
            hợpĐồngLaoĐộngToolStripMenuItem.ForeColor = Color.White;
            hợpĐồngLaoĐộngToolStripMenuItem.BackColor = Color.Black;
            ismenuClicked5 = false;
            khenThưởngKỷLuậtToolStripMenuItem.ForeColor = Color.White;
            khenThưởngKỷLuậtToolStripMenuItem.BackColor = Color.Black;
        }

        private void khenThưởngKỷLuậtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new khenthuongkyluat());
            ismenuClicked5 = true;

            // Đổi màu chữ thành trắng và màu nền thành đen khi click
            khenThưởngKỷLuậtToolStripMenuItem.ForeColor = Color.Black;
            khenThưởngKỷLuậtToolStripMenuItem.BackColor = Color.White;
            ismenuClicked1 = false;
            chấmCôngToolStripMenuItem.ForeColor = Color.White;
            chấmCôngToolStripMenuItem.BackColor = Color.Black;
            ismenuClicked2 = false;
            lươngToolStripMenuItem.ForeColor = Color.White;
            lươngToolStripMenuItem.BackColor = Color.Black;
            ismenuClicked3 = false;
            hợpĐồngLaoĐộngToolStripMenuItem.ForeColor = Color.White;
            hợpĐồngLaoĐộngToolStripMenuItem.BackColor = Color.Black;
            ismenuClicked4 = false;
            bảoHiểmToolStripMenuItem.ForeColor = Color.White;
            bảoHiểmToolStripMenuItem.BackColor = Color.Black;
        }
    }
}
