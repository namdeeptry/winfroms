
namespace QUANLYNHANSU
{
    partial class timkiem
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
            this.tìmKiếmTheoMãNhânViênToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelbodytimkiem = new System.Windows.Forms.Panel();
            this.timToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Black;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.timToolStripMenuItem,
            this.tìmKiếmTheoMãNhânViênToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(917, 40);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tìmKiếmTheoMãNhânViênToolStripMenuItem
            // 
            this.tìmKiếmTheoMãNhânViênToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tìmKiếmTheoMãNhânViênToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.tìmKiếmTheoMãNhânViênToolStripMenuItem.Image = global::QUANLYNHANSU.Properties.Resources.research;
            this.tìmKiếmTheoMãNhânViênToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tìmKiếmTheoMãNhânViênToolStripMenuItem.Name = "tìmKiếmTheoMãNhânViênToolStripMenuItem";
            this.tìmKiếmTheoMãNhânViênToolStripMenuItem.Size = new System.Drawing.Size(207, 36);
            this.tìmKiếmTheoMãNhânViênToolStripMenuItem.Text = "Theo mã nhân viên";
            this.tìmKiếmTheoMãNhânViênToolStripMenuItem.Click += new System.EventHandler(this.tìmKiếmTheoMãNhânViênToolStripMenuItem_Click);
            // 
            // panelbodytimkiem
            // 
            this.panelbodytimkiem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelbodytimkiem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelbodytimkiem.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelbodytimkiem.Location = new System.Drawing.Point(0, 40);
            this.panelbodytimkiem.Name = "panelbodytimkiem";
            this.panelbodytimkiem.Size = new System.Drawing.Size(917, 703);
            this.panelbodytimkiem.TabIndex = 2;
            // 
            // timToolStripMenuItem
            // 
            this.timToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.timToolStripMenuItem.Image = global::QUANLYNHANSU.Properties.Resources.job_offer1;
            this.timToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.timToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Red;
            this.timToolStripMenuItem.Name = "timToolStripMenuItem";
            this.timToolStripMenuItem.Size = new System.Drawing.Size(187, 36);
            this.timToolStripMenuItem.Text = "Theo phòng ban";
            this.timToolStripMenuItem.Click += new System.EventHandler(this.timToolStripMenuItem_Click);
            // 
            // timkiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(917, 743);
            this.Controls.Add(this.panelbodytimkiem);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "timkiem";
            this.Text = "timkiem";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem timToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tìmKiếmTheoMãNhânViênToolStripMenuItem;
        private System.Windows.Forms.Panel panelbodytimkiem;
    }
}