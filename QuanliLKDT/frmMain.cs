using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraTab;
using DevExpress.XtraTab.ViewInfo;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;

namespace QuanliLKDT
{
    public delegate void Processor1();
    public delegate void Processor2(string data1, string data2, string data3, int data4, string data5);

    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        List<string> detailPermissionList;
        static FormCollection frmCollection = Application.OpenForms;

        public List<string> DetailPermissionList { get => detailPermissionList; set => detailPermissionList = value; }

        public frmMain()
        {
            InitializeComponent();
        }
 
        private void frmMain_Load(object obj, EventArgs e)
        {
            RibbonBarItems items = this.ribbonControl1.Items;
            foreach(string name in DetailPermissionList)
            {
                foreach(BarButtonItem button in items)
                {
                    if(button.Name == name)
                    {
                        button.Enabled = false;
                        break;
                    }
                }
            }
        } 

        private void frmMain_SizeChanged(object sender, EventArgs e)
        {
            foreach (Form f in frmCollection)
            {
                if (f.Name != "frmMain")
                       f.Size = xtraTabControl_Function.Size;
            }
        }

        private Form checkForm(Type ftype)
        {
            foreach (Form f in frmCollection)
            {
                if (f.GetType() == ftype)
                {
                    return f;
                }
            }
            return null;
        }

        private void addTab(Form frm)
        {
            if (xtraTabControl_Function.Visible == false)
                 xtraTabControl_Function.Visible = true;
                                    
            XtraTabPage tab = new XtraTabPage();
            tab.Text = frm.Text;
            tab.Name = "tab" + frm.Name.Substring(3);
            frm.TopLevel = false;
            frm.Size = xtraTabControl_Function.Size;
            tab.Controls.Add(frm);
            xtraTabControl_Function.TabPages.Add(tab);
            xtraTabControl_Function.SelectedTabPage = tab;                   
        }

        private void focusOnTab(Form frm)
        {
            foreach(XtraTabPage t in xtraTabControl_Function.TabPages)
            {
                if (t.Text == frm.Text)
                {
                    if (t.PageVisible == false)
                        t.PageVisible = true;

                    xtraTabControl_Function.SelectedTabPage = t;                 
                    return;
                }
            }
        }
        
        private void btnProductType_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = checkForm(typeof(frmProductType));
            
            if (frm == null)
            {              
                frmProductType f = new frmProductType();
                addTab(f);
                f.Show();
            }
            else
            {
                focusOnTab(frm);
                frm.Activate();              
            }
        }

        private void barbtnProduct_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = checkForm(typeof(frmProduct));
            if (frm == null)
            {
                frmProduct f = new frmProduct();
                addTab(f);
                f.Show();
            }
            else
            {
                focusOnTab(frm);
                frm.Activate();              
            }
        }

        private void barbtnCustomer_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = checkForm(typeof(frmCustomer));
            if (frm == null) { 
                frmCustomer f = new frmCustomer();
                addTab(f);
                f.Show();
            }
            else{
                focusOnTab(frm);
                frm.Activate();
            }
        }

        private void barbtnProviders_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = checkForm(typeof(frmSupplier));
            if (frm == null)
            {
                frmSupplier f = new frmSupplier();
                addTab(f);
                f.Show();
            }
            else
            {
                focusOnTab(frm);
                frm.Activate();
            }
        }

        private void barbtnImport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm1 = checkForm(typeof(frmManageRepository_1));
            Form frm2 = checkForm(typeof(frmManageRepository_2));

            if (frm1 == null && frm2 == null)
            {
                frmManageRepository_1 f1 = new frmManageRepository_1();
                frmManageRepository_2 f2 = new frmManageRepository_2();
                f1.ClosingFormPort = f2.closeForm;
                f1.DataTransmissionPort = f2.updateDataGridview;
                addTab(f1);
                addTab(f2);
                focusOnTab(f1);
                f1.Show();
                f2.Show();
                return;
            }

            focusOnTab(frm2);
            focusOnTab(frm1);
            frm1.Activate();
            frm2.Activate();
        }

        private void xtraTabControl_Function_CloseButtonClick(object sender, EventArgs e)
        {
            ClosePageButtonEventArgs arg = e as ClosePageButtonEventArgs;
            (arg.Page as XtraTabPage).PageVisible = false;
        }

        private void barbtnImportReport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = checkForm(typeof(frmImportProductReport));

            if (frm == null)
            {
                frmImportProductReport f = new frmImportProductReport();
                addTab(f);
                f.Show();
            }
            else
            {
                focusOnTab(frm);
                frm.Activate();
            }
        }
    }
}