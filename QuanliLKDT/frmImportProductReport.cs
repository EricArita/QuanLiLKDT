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
using BLL;

namespace QuanliLKDT
{
    public partial class frmImportProductReport : Form
    {
        public frmImportProductReport()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {          
            rpvReport.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
            rpvReport.LocalReport.ReportPath = "rptImportProduct.rdlc";

            LogicReport server = new LogicReport();
            DataSet temporary_ds = server.getDataBase(dtpFromDate.Value.ToString(), dtpToDate.Value.ToString());

            if (temporary_ds == null || temporary_ds.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("Không có sản phẩm nào được nhập trong khoảng thời gian này để lập báo cáo", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (temporary_ds.Tables[0].Rows.Count > 0)
            {
                ReportDataSource reportData = new ReportDataSource("dataReport", temporary_ds.Tables[0]);
                rpvReport.LocalReport.DataSources.Clear();
                rpvReport.LocalReport.DataSources.Add(reportData);
                rpvReport.RefreshReport();
            }
        }
    }
}
