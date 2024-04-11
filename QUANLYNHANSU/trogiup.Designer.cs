
namespace QUANLYNHANSU
{
    partial class trogiup
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.liênHệVớiChúngTôiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelbodytrogiup = new System.Windows.Forms.Panel();
            this.câuHỏiThườngGặpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Black;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.câuHỏiThườngGặpToolStripMenuItem,
            this.liênHệVớiChúngTôiToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(834, 40);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // liênHệVớiChúngTôiToolStripMenuItem
            // 
            this.liênHệVớiChúngTôiToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.liênHệVớiChúngTôiToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.liênHệVớiChúngTôiToolStripMenuItem.Image = global::QUANLYNHANSU.Properties.Resources.customer_service;
            this.liênHệVớiChúngTôiToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.liênHệVớiChúngTôiToolStripMenuItem.Name = "liênHệVớiChúngTôiToolStripMenuItem";
            this.liênHệVớiChúngTôiToolStripMenuItem.Size = new System.Drawing.Size(233, 36);
            this.liênHệVớiChúngTôiToolStripMenuItem.Text = "Liên Hệ Với Chúng Tôi";
            this.liênHệVớiChúngTôiToolStripMenuItem.Click += new System.EventHandler(this.liênHệVớiChúngTôiToolStripMenuItem_Click);
            // 
            // panelbodytrogiup
            // 
            this.panelbodytrogiup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelbodytrogiup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelbodytrogiup.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelbodytrogiup.Location = new System.Drawing.Point(0, 40);
            this.panelbodytrogiup.Name = "panelbodytrogiup";
            this.panelbodytrogiup.Size = new System.Drawing.Size(834, 814);
            this.panelbodytrogiup.TabIndex = 2;
            // 
            // câuHỏiThườngGặpToolStripMenuItem
            // 
            this.câuHỏiThườngGặpToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.câuHỏiThườngGặpToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.câuHỏiThườngGặpToolStripMenuItem.Image = global::QUANLYNHANSU.Properties.Resources.faq;
            this.câuHỏiThườngGặpToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.câuHỏiThườngGặpToolStripMenuItem.Name = "câuHỏiThườngGặpToolStripMenuItem";
            this.câuHỏiThườngGặpToolStripMenuItem.Size = new System.Drawing.Size(224, 36);
            this.câuHỏiThườngGặpToolStripMenuItem.Text = "Câu Hỏi Thường Gặp";
            this.câuHỏiThườngGặpToolStripMenuItem.Click += new System.EventHandler(this.câuHỏiThườngGặpToolStripMenuItem_Click);
            // 
            // trogiup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(834, 854);
            this.Controls.Add(this.panelbodytrogiup);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "trogiup";
            this.Text = "trogiup";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem câuHỏiThườngGặpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem liênHệVớiChúngTôiToolStripMenuItem;
        private System.Windows.Forms.Panel panelbodytrogiup;
    }
}