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
    public partial class baocaoluong : Form
    {
        public baocaoluong()
        {
            InitializeComponent();
        }

        modify mdf = new modify();
        private void baocaoluong_Load(object sender, EventArgs e)
        {


            try
            {
                // windown/c/
                reportViewer2.LocalReport.ReportEmbeddedResource = "QUANLYNHANSU.Report2.rdlc";
                ReportDataSource reportDataSource = new ReportDataSource();
                reportDataSource.Name = "DataSet2";
                reportDataSource.Value = mdf.getluong();
                reportViewer2.LocalReport.DataSources.Add(reportDataSource);

                this.reportViewer2.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
