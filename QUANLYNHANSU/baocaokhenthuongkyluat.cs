using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Data.SqlClient;

namespace QUANLYNHANSU
{
    public partial class baocaokhenthuongkyluat : Form
    {
        public baocaokhenthuongkyluat()
        {
            InitializeComponent();
        }
        SqlDataAdapter dataAdapter;
        SqlCommand sqlCommand;
        modify mdf = new modify();
        private void baocaokhenthuongkyluat_Load(object sender, EventArgs e)
        {

            try
            {
                // windown/c/
                reportViewer1.LocalReport.ReportEmbeddedResource = "QUANLYNHANSU.Report3.rdlc";
                ReportDataSource reportDataSource = new ReportDataSource();
                reportDataSource.Name = "DataSet3";
                reportDataSource.Value = mdf.getkhenthuongkyluat();
                reportViewer1.LocalReport.DataSources.Add(reportDataSource);

                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
