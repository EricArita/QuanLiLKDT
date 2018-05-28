using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanliLKDT
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnProductType_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmProductType f = new frmProductType();
            f.MdiParent = this;
            f.Show();
        }

        private void barbtnProduct_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmProduct f = new frmProduct();
            f.MdiParent = this;
            f.Show();
        }

        private void barbtnCustomer_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmCustomer f = new frmCustomer();
            f.MdiParent = this;
            f.Show();
        }
    }
}

