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
    public partial class trogiupcauhoithuonggap : Form
    {
        public trogiupcauhoithuonggap()
        {
            InitializeComponent();
        }
        bool cogian = false;
        bool cogian2 = false;
        bool cogian3 = false;
        bool cogian4 = false;
        bool cogian5 = false;
        bool cogian6 = false;
        bool cogian7 = false;
        private void trogiupcauhoithuonggap_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (cogian == false)
            {
                button1.Image = Properties.Resources.down;
                panel1.Height += 15;
                if (panel1.Height >= panel1.MaximumSize.Height)
                {
                    timer1.Stop();
                    cogian = true;

                }
            }
            else
            {
                button1.Image = Properties.Resources.right;
                panel1.Height -= 15;
                if (panel1.Height <= panel1.MinimumSize.Height)
                {
                    timer1.Stop();
                    cogian = false;
                }
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (cogian2 == false)
            {
                button5.Image = Properties.Resources.down;
                panel2.Height += 15;
                if (panel2.Height >= panel2.MaximumSize.Height)
                {
                    timer2.Stop();
                    cogian2 = true;

                }

            }
            else
            {
                button5.Image = Properties.Resources.right;
                panel2.Height -= 25;
                if (panel2.Height <= panel2.MinimumSize.Height)
                {
                    timer2.Stop();
                    cogian2 = false;
                }
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (cogian3 == false)
            {
                button7.Image = Properties.Resources.down;
                panel3.Height += 15;
                if (panel3.Height >= panel3.MaximumSize.Height)
                {
                    timer3.Stop();
                    cogian3 = true;

                }
            }
            else
            {
                button7.Image = Properties.Resources.right;
                panel3.Height -= 25;
                if (panel3.Height <= panel3.MinimumSize.Height)
                {
                    timer3.Stop();
                    cogian3 = false;
                }
            }
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            if (cogian4 == false)
            {
                button9.Image = Properties.Resources.down;
                panel4.Height += 15;
                if (panel4.Height >= panel4.MaximumSize.Height)
                {
                    timer4.Stop();
                    cogian4 = true;

                }
            }
            else
            {
                button9.Image = Properties.Resources.right;
                panel4.Height -= 25;
                if (panel4.Height <= panel4.MinimumSize.Height)
                {
                    timer4.Stop();
                    cogian4 = false;
                }
            }
        }

        private void timer5_Tick(object sender, EventArgs e)
        {
            if (cogian5 == false)
            {
                button11.Image = Properties.Resources.down;
                panel5.Height += 15;
                if (panel5.Height >= panel5.MaximumSize.Height)
                {
                    timer5.Stop();
                    cogian5 = true;

                }
            }
            else
            {
                button11.Image = Properties.Resources.right;
                panel5.Height -= 25;
                if (panel5.Height <= panel5.MinimumSize.Height)
                {
                    timer5.Stop();
                    cogian5 = false;
                }
            }
        
    }

        private void timer6_Tick(object sender, EventArgs e)
        {
            if (cogian6 == false)
            {
                button15.Image = Properties.Resources.down;
                panel6.Height += 15;
                if (panel6.Height >= panel6.MaximumSize.Height)
                {
                    timer6.Stop();
                    cogian6 = true;

                }
            }
            else
            {
                button15.Image = Properties.Resources.right;
                panel6.Height -= 25;
                if (panel6.Height <= panel6.MinimumSize.Height)
                {
                    timer6.Stop();
                    cogian6 = false;
                }
            }
        }

        private void timer7_Tick(object sender, EventArgs e)
        {
            if (cogian7 == false)
            {
                button12.Image = Properties.Resources.down;
                panel7.Height += 15;
                if (panel7.Height >= panel7.MaximumSize.Height)
                {
                    timer7.Stop();
                    cogian7 = true;

                }
            }
            else
            {
                button12.Image = Properties.Resources.right;
                panel7.Height -= 25;
                if (panel7.Height <= panel7.MinimumSize.Height)
                {
                    timer7.Stop();
                    cogian7 = false;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
            button5.Image = Properties.Resources.right;
            panel2.Height -= 85;
            if (panel2.Height <= panel2.MinimumSize.Height)
            {
                timer2.Stop();
                cogian2 = false;
            }
            //
            button7.Image = Properties.Resources.right;
            panel3.Height -= 85;
            if (panel3.Height <= panel3.MinimumSize.Height)
            {
                timer3.Stop();
                cogian3 = false;
            }
            //
            button9.Image = Properties.Resources.right;
            panel4.Height -= 85;
            if (panel4.Height <= panel4.MinimumSize.Height)
            {
                timer4.Stop();
                cogian4 = false;
            }
            //
            button11.Image = Properties.Resources.right;
            panel5.Height -= 85;
            if (panel5.Height <= panel5.MinimumSize.Height)
            {
                timer5.Stop();
                cogian5 = false;
            }
            //
            button15.Image = Properties.Resources.right;
            panel6.Height -= 85;
            if (panel6.Height <= panel6.MinimumSize.Height)
            {
                timer6.Stop();
                cogian6 = false;
            }
            //
            button12.Image = Properties.Resources.right;
            panel7.Height -= 85;
            if (panel7.Height <= panel7.MinimumSize.Height)
            {
                timer7.Stop();
                cogian7 = false;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            timer2.Start();
            button1.Image = Properties.Resources.right;
            panel1.Height -= 85;
            if (panel1.Height <= panel1.MinimumSize.Height)
            {
                timer1.Stop();
                cogian = false;
            }

            //
            button7.Image = Properties.Resources.right;
            panel3.Height -= 85;
            if (panel3.Height <= panel3.MinimumSize.Height)
            {
                timer3.Stop();
                cogian3 = false;
            }
            //
            button9.Image = Properties.Resources.right;
            panel4.Height -= 85;
            if (panel4.Height <= panel4.MinimumSize.Height)
            {
                timer4.Stop();
                cogian4 = false;
            }
            //
            button11.Image = Properties.Resources.right;
            panel5.Height -= 85;
            if (panel5.Height <= panel5.MinimumSize.Height)
            {
                timer5.Stop();
                cogian5 = false;
            }
            //
            button15.Image = Properties.Resources.right;
            panel6.Height -= 85;
            if (panel6.Height <= panel6.MinimumSize.Height)
            {
                timer6.Stop();
                cogian6 = false;
            }
            //
            button12.Image = Properties.Resources.right;
            panel7.Height -= 85;
            if (panel7.Height <= panel7.MinimumSize.Height)
            {
                timer7.Stop();
                cogian7 = false;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            timer3.Start();
            button1.Image = Properties.Resources.right;
            panel1.Height -= 85;
            if (panel1.Height <= panel1.MinimumSize.Height)
            {
                timer1.Stop();
                cogian = false;
            }
            //
            button5.Image = Properties.Resources.right;
            panel2.Height -= 85;
            if (panel2.Height <= panel2.MinimumSize.Height)
            {
                timer2.Stop();
                cogian2 = false;
            }

            //
            button9.Image = Properties.Resources.right;
            panel4.Height -= 85;
            if (panel4.Height <= panel4.MinimumSize.Height)
            {
                timer4.Stop();
                cogian4 = false;
            }
            //
            button11.Image = Properties.Resources.right;
            panel5.Height -= 85;
            if (panel5.Height <= panel5.MinimumSize.Height)
            {
                timer5.Stop();
                cogian5 = false;
            }
            //
            button15.Image = Properties.Resources.right;
            panel6.Height -= 85;
            if (panel6.Height <= panel6.MinimumSize.Height)
            {
                timer6.Stop();
                cogian6 = false;
            }
            //
            button12.Image = Properties.Resources.right;
            panel7.Height -= 85;
            if (panel7.Height <= panel7.MinimumSize.Height)
            {
                timer7.Stop();
                cogian7 = false;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            timer4.Start();
            button1.Image = Properties.Resources.right;
            panel1.Height -= 85;
            if (panel1.Height <= panel1.MinimumSize.Height)
            {
                timer1.Stop();
                cogian = false;
            }
            //
            button5.Image = Properties.Resources.right;
            panel2.Height -= 85;
            if (panel2.Height <= panel2.MinimumSize.Height)
            {
                timer2.Stop();
                cogian2 = false;
            }

            //
            button7.Image = Properties.Resources.right;
            panel3.Height -= 85;
            if (panel3.Height <= panel3.MinimumSize.Height)
            {
                timer3.Stop();
                cogian3 = false;
            }
            //
            button11.Image = Properties.Resources.right;
            panel5.Height -= 85;
            if (panel5.Height <= panel5.MinimumSize.Height)
            {
                timer5.Stop();
                cogian5 = false;
            }
            //
            button15.Image = Properties.Resources.right;
            panel6.Height -= 85;
            if (panel6.Height <= panel6.MinimumSize.Height)
            {
                timer6.Stop();
                cogian6 = false;
            }
            //
            button12.Image = Properties.Resources.right;
            panel7.Height -= 85;
            if (panel7.Height <= panel7.MinimumSize.Height)
            {
                timer7.Stop();
                cogian7 = false;
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            timer5.Start();
            button1.Image = Properties.Resources.right;
            panel1.Height -= 85;
            if (panel1.Height <= panel1.MinimumSize.Height)
            {
                timer1.Stop();
                cogian = false;
            }
            //
            button5.Image = Properties.Resources.right;
            panel2.Height -= 85;
            if (panel2.Height <= panel2.MinimumSize.Height)
            {
                timer2.Stop();
                cogian2 = false;
            }

            //
            button7.Image = Properties.Resources.right;
            panel3.Height -= 85;
            if (panel3.Height <= panel3.MinimumSize.Height)
            {
                timer3.Stop();
                cogian3 = false;
            }
            //
            button9.Image = Properties.Resources.right;
            panel4.Height -= 85;
            if (panel4.Height <= panel4.MinimumSize.Height)
            {
                timer4.Stop();
                cogian4 = false;
            }
            //

            //
            button15.Image = Properties.Resources.right;
            panel6.Height -= 85;
            if (panel6.Height <= panel6.MinimumSize.Height)
            {
                timer6.Stop();
                cogian6 = false;
            }
            //
            button12.Image = Properties.Resources.right;
            panel7.Height -= 85;
            if (panel7.Height <= panel7.MinimumSize.Height)
            {
                timer7.Stop();
                cogian7 = false;
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            timer6.Start();
            button1.Image = Properties.Resources.right;
            panel1.Height -= 85;
            if (panel1.Height <= panel1.MinimumSize.Height)
            {
                timer1.Stop();
                cogian = false;
            }
            //
            button5.Image = Properties.Resources.right;
            panel2.Height -= 85;
            if (panel2.Height <= panel2.MinimumSize.Height)
            {
                timer2.Stop();
                cogian2 = false;
            }

            //
            button7.Image = Properties.Resources.right;
            panel3.Height -= 85;
            if (panel3.Height <= panel3.MinimumSize.Height)
            {
                timer3.Stop();
                cogian3 = false;
            }
            //
            button9.Image = Properties.Resources.right;
            panel4.Height -= 85;
            if (panel4.Height <= panel4.MinimumSize.Height)
            {
                timer4.Stop();
                cogian4 = false;
            }
            //
            button11.Image = Properties.Resources.right;
            panel5.Height -= 85;
            if (panel5.Height <= panel5.MinimumSize.Height)
            {
                timer5.Stop();
                cogian5 = false;
            }
            //
            button12.Image = Properties.Resources.right;
            panel7.Height -= 85;
            if (panel7.Height <= panel7.MinimumSize.Height)
            {
                timer7.Stop();
                cogian7 = false;
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            timer7.Start();
            button1.Image = Properties.Resources.right;
            panel1.Height -= 85;
            if (panel1.Height <= panel1.MinimumSize.Height)
            {
                timer1.Stop();
                cogian = false;
            }
            //
            button5.Image = Properties.Resources.right;
            panel2.Height -= 85;
            if (panel2.Height <= panel2.MinimumSize.Height)
            {
                timer2.Stop();
                cogian2 = false;
            }

            //
            button7.Image = Properties.Resources.right;
            panel3.Height -= 85;
            if (panel3.Height <= panel3.MinimumSize.Height)
            {
                timer3.Stop();
                cogian3 = false;
            }
            //
            button9.Image = Properties.Resources.right;
            panel4.Height -= 85;
            if (panel4.Height <= panel4.MinimumSize.Height)
            {
                timer4.Stop();
                cogian4 = false;
            }
            //
            button11.Image = Properties.Resources.right;
            panel5.Height -= 85;
            if (panel5.Height <= panel5.MinimumSize.Height)
            {
                timer5.Stop();
                cogian5 = false;
            }
            //
            button15.Image = Properties.Resources.right;
            panel6.Height -= 85;
            if (panel6.Height <= panel6.MinimumSize.Height)
            {
                timer6.Stop();
                cogian6 = false;
            }
        }
    }
}
