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
    public partial class trogiup : Form
    {
        public trogiup()
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
            panelbodytrogiup.Controls.Add(childForm);
            panelbodytrogiup.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

        }
        bool ismenuClicked1 = false;
        bool ismenuClicked2 = false;
        private void câuHỏiThườngGặpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new trogiupcauhoithuonggap());
            ismenuClicked1 = true;

            // Đổi màu chữ thành trắng và màu nền thành đen khi click
            câuHỏiThườngGặpToolStripMenuItem.ForeColor = Color.Black;
            câuHỏiThườngGặpToolStripMenuItem.BackColor = Color.White;
            ismenuClicked2 = false;
            liênHệVớiChúngTôiToolStripMenuItem.ForeColor = Color.White;
            liênHệVớiChúngTôiToolStripMenuItem.BackColor = Color.Black;
        }

        private void liênHệVớiChúngTôiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new trogiuplienhevoichungtoi());
            ismenuClicked1 = false;

            // Đổi màu chữ thành trắng và màu nền thành đen khi click
            câuHỏiThườngGặpToolStripMenuItem.ForeColor = Color.White;
            câuHỏiThườngGặpToolStripMenuItem.BackColor = Color.Black;
            ismenuClicked2 = true;
            liênHệVớiChúngTôiToolStripMenuItem.ForeColor = Color.Black;
            liênHệVớiChúngTôiToolStripMenuItem.BackColor = Color.White;
        }
    }
}
