namespace QuanliLKDT
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barbtnProduct = new DevExpress.XtraBars.BarButtonItem();
            this.barbtnProductType = new DevExpress.XtraBars.BarButtonItem();
            this.barbtnCustomer = new DevExpress.XtraBars.BarButtonItem();
            this.barbtnProviders = new DevExpress.XtraBars.BarButtonItem();
            this.barbtnImport = new DevExpress.XtraBars.BarButtonItem();
            this.barbtnSale = new DevExpress.XtraBars.BarButtonItem();
            this.barbtnStatistics = new DevExpress.XtraBars.BarButtonItem();
            this.barbtnFinacialReport = new DevExpress.XtraBars.BarButtonItem();
            this.barbtnImportProductReport = new DevExpress.XtraBars.BarButtonItem();
            this.barbtnExportProductReport = new DevExpress.XtraBars.BarButtonItem();
            this.barbtnStaffReport = new DevExpress.XtraBars.BarButtonItem();
            this.barbtnManageReceipt = new DevExpress.XtraBars.BarButtonItem();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.ribbonPageCategory1 = new DevExpress.XtraBars.Ribbon.RibbonPageCategory();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup6 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup7 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage4 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage5 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup5 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage3 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.xtraTabControl_Function = new DevExpress.XtraTab.XtraTabControl();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl_Function)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.barbtnProduct,
            this.barbtnProductType,
            this.barbtnCustomer,
            this.barbtnProviders,
            this.barbtnImport,
            this.barbtnSale,
            this.barbtnStatistics,
            this.barbtnFinacialReport,
            this.barbtnImportProductReport,
            this.barbtnExportProductReport,
            this.barbtnStaffReport,
            this.barbtnManageReceipt});
            this.ribbonControl1.LargeImages = this.imageCollection1;
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 24;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.PageCategories.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageCategory[] {
            this.ribbonPageCategory1});
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1,
            this.ribbonPage2,
            this.ribbonPage4,
            this.ribbonPage5});
            this.ribbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            this.ribbonControl1.Size = new System.Drawing.Size(1149, 143);
            // 
            // barbtnProduct
            // 
            this.barbtnProduct.Caption = "Sản phẩm";
            this.barbtnProduct.Id = 6;
            this.barbtnProduct.ImageOptions.LargeImageIndex = 1;
            this.barbtnProduct.Name = "barbtnProduct";
            this.barbtnProduct.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barbtnProduct_ItemClick);
            // 
            // barbtnProductType
            // 
            this.barbtnProductType.Caption = "Loại sản phẩm";
            this.barbtnProductType.Id = 8;
            this.barbtnProductType.ImageOptions.ImageIndex = 0;
            this.barbtnProductType.ImageOptions.LargeImageIndex = 0;
            this.barbtnProductType.Name = "barbtnProductType";
            this.barbtnProductType.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnProductType_ItemClick);
            // 
            // barbtnCustomer
            // 
            this.barbtnCustomer.Caption = "Khách hàng";
            this.barbtnCustomer.Id = 12;
            this.barbtnCustomer.ImageOptions.LargeImageIndex = 2;
            this.barbtnCustomer.Name = "barbtnCustomer";
            this.barbtnCustomer.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barbtnCustomer_ItemClick);
            // 
            // barbtnProviders
            // 
            this.barbtnProviders.Caption = "Nhà cung cấp";
            this.barbtnProviders.Id = 13;
            this.barbtnProviders.ImageOptions.LargeImageIndex = 3;
            this.barbtnProviders.Name = "barbtnProviders";
            this.barbtnProviders.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barbtnProviders_ItemClick);
            // 
            // barbtnImport
            // 
            this.barbtnImport.Caption = "Nhập hàng";
            this.barbtnImport.Id = 14;
            this.barbtnImport.ImageOptions.LargeImageIndex = 4;
            this.barbtnImport.Name = "barbtnImport";
            this.barbtnImport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barbtnImport_ItemClick);
            // 
            // barbtnSale
            // 
            this.barbtnSale.Caption = "Bán hàng";
            this.barbtnSale.Id = 15;
            this.barbtnSale.ImageOptions.LargeImageIndex = 5;
            this.barbtnSale.Name = "barbtnSale";
            // 
            // barbtnStatistics
            // 
            this.barbtnStatistics.Caption = "Thống kê";
            this.barbtnStatistics.Id = 16;
            this.barbtnStatistics.ImageOptions.LargeImageIndex = 6;
            this.barbtnStatistics.Name = "barbtnStatistics";
            // 
            // barbtnFinacialReport
            // 
            this.barbtnFinacialReport.Caption = "Báo cáo doanh thu";
            this.barbtnFinacialReport.Id = 17;
            this.barbtnFinacialReport.ImageOptions.LargeImageIndex = 11;
            this.barbtnFinacialReport.Name = "barbtnFinacialReport";
            // 
            // barbtnImportProductReport
            // 
            this.barbtnImportProductReport.Caption = "Báo cáo sản phẩm nhập";
            this.barbtnImportProductReport.Id = 18;
            this.barbtnImportProductReport.ImageOptions.LargeImageIndex = 8;
            this.barbtnImportProductReport.Name = "barbtnImportProductReport";
            this.barbtnImportProductReport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barbtnImportReport_ItemClick);
            // 
            // barbtnExportProductReport
            // 
            this.barbtnExportProductReport.Caption = "Báo cáo sản phẩm bán";
            this.barbtnExportProductReport.Id = 19;
            this.barbtnExportProductReport.ImageOptions.LargeImageIndex = 9;
            this.barbtnExportProductReport.Name = "barbtnExportProductReport";
            // 
            // barbtnStaffReport
            // 
            this.barbtnStaffReport.Caption = "Báo cáo nhân viên";
            this.barbtnStaffReport.Id = 20;
            this.barbtnStaffReport.ImageOptions.LargeImageIndex = 7;
            this.barbtnStaffReport.Name = "barbtnStaffReport";
            // 
            // barbtnManageReceipt
            // 
            this.barbtnManageReceipt.Caption = "Quản lí hóa đơn";
            this.barbtnManageReceipt.Id = 21;
            this.barbtnManageReceipt.ImageOptions.LargeImageIndex = 10;
            this.barbtnManageReceipt.Name = "barbtnManageReceipt";
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageSize = new System.Drawing.Size(32, 32);
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.Images.SetKeyName(0, "Product Type.png");
            this.imageCollection1.Images.SetKeyName(1, "Product.png");
            this.imageCollection1.Images.SetKeyName(2, "Customers.png");
            this.imageCollection1.Images.SetKeyName(3, "Providers.png");
            this.imageCollection1.Images.SetKeyName(4, "Import_Products.ico");
            this.imageCollection1.Images.SetKeyName(5, "Sale_Products.ico");
            this.imageCollection1.Images.SetKeyName(6, "Statistics.ico");
            this.imageCollection1.InsertGalleryImage("boresume_32x32.png", "images/business%20objects/boresume_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/business%20objects/boresume_32x32.png"), 7);
            this.imageCollection1.Images.SetKeyName(7, "boresume_32x32.png");
            this.imageCollection1.InsertGalleryImage("report2_32x32.png", "images/toolbox%20items/report2_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/toolbox%20items/report2_32x32.png"), 8);
            this.imageCollection1.Images.SetKeyName(8, "report2_32x32.png");
            this.imageCollection1.InsertGalleryImage("boreport2_32x32.png", "images/business%20objects/boreport2_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/business%20objects/boreport2_32x32.png"), 9);
            this.imageCollection1.Images.SetKeyName(9, "boreport2_32x32.png");
            this.imageCollection1.Images.SetKeyName(10, "Management of receipts.ico");
            this.imageCollection1.Images.SetKeyName(11, "Financial report.ico");
            // 
            // ribbonPageCategory1
            // 
            this.ribbonPageCategory1.Name = "ribbonPageCategory1";
            this.ribbonPageCategory1.Text = "ribbonPageCategory1";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Danh mục";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.barbtnProduct, true);
            this.ribbonPageGroup1.ItemLinks.Add(this.barbtnProductType, true);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.barbtnCustomer, true);
            this.ribbonPageGroup2.ItemLinks.Add(this.barbtnProviders, true);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup3,
            this.ribbonPageGroup6,
            this.ribbonPageGroup7});
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "Chức năng";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.barbtnImport);
            this.ribbonPageGroup3.ItemLinks.Add(this.barbtnSale);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "Giao dịch";
            // 
            // ribbonPageGroup6
            // 
            this.ribbonPageGroup6.ItemLinks.Add(this.barbtnStatistics);
            this.ribbonPageGroup6.ItemLinks.Add(this.barbtnFinacialReport);
            this.ribbonPageGroup6.ItemLinks.Add(this.barbtnImportProductReport);
            this.ribbonPageGroup6.ItemLinks.Add(this.barbtnExportProductReport);
            this.ribbonPageGroup6.ItemLinks.Add(this.barbtnStaffReport);
            this.ribbonPageGroup6.Name = "ribbonPageGroup6";
            this.ribbonPageGroup6.Text = "Thống kê - Báo cáo";
            // 
            // ribbonPageGroup7
            // 
            this.ribbonPageGroup7.ItemLinks.Add(this.barbtnManageReceipt);
            this.ribbonPageGroup7.Name = "ribbonPageGroup7";
            this.ribbonPageGroup7.Text = "Hóa đơn";
            // 
            // ribbonPage4
            // 
            this.ribbonPage4.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup4});
            this.ribbonPage4.Name = "ribbonPage4";
            this.ribbonPage4.Text = "Hệ thống";
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            this.ribbonPageGroup4.Text = "ribbonPageGroup4";
            // 
            // ribbonPage5
            // 
            this.ribbonPage5.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup5});
            this.ribbonPage5.Name = "ribbonPage5";
            this.ribbonPage5.Text = "Cài đặt";
            // 
            // ribbonPageGroup5
            // 
            this.ribbonPageGroup5.Name = "ribbonPageGroup5";
            this.ribbonPageGroup5.Text = "ribbonPageGroup5";
            // 
            // ribbonPage3
            // 
            this.ribbonPage3.Name = "ribbonPage3";
            this.ribbonPage3.Text = "ribbonPage3";
            // 
            // xtraTabControl_Function
            // 
            this.xtraTabControl_Function.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InAllTabPageHeaders;
            this.xtraTabControl_Function.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl_Function.Location = new System.Drawing.Point(0, 143);
            this.xtraTabControl_Function.Name = "xtraTabControl_Function";
            this.xtraTabControl_Function.Size = new System.Drawing.Size(1149, 525);
            this.xtraTabControl_Function.TabIndex = 5;
            this.xtraTabControl_Function.Visible = false;
            this.xtraTabControl_Function.CloseButtonClick += new System.EventHandler(this.xtraTabControl_Function_CloseButtonClick);
            // 
            // frmMain
            // 
            this.AllowFormGlass = DevExpress.Utils.DefaultBoolean.False;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1149, 668);
            this.Controls.Add(this.xtraTabControl_Function);
            this.Controls.Add(this.ribbonControl1);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            this.IsMdiContainer = true;
            this.Name = "frmMain";
            this.Ribbon = this.ribbonControl1;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.SizeChanged += new System.EventHandler(this.frmMain_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl_Function)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage3;
        private DevExpress.XtraBars.BarButtonItem barbtnProduct;
        private DevExpress.XtraBars.BarButtonItem barbtnProductType;
        private DevExpress.XtraBars.Ribbon.RibbonPageCategory ribbonPageCategory1;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarButtonItem barbtnCustomer;
        private DevExpress.XtraBars.BarButtonItem barbtnProviders;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage4;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage5;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup5;
        private DevExpress.XtraBars.BarButtonItem barbtnImport;
        private DevExpress.XtraBars.BarButtonItem barbtnSale;
        private DevExpress.XtraBars.BarButtonItem barbtnStatistics;
        private DevExpress.XtraBars.BarButtonItem barbtnFinacialReport;
        private DevExpress.XtraBars.BarButtonItem barbtnImportProductReport;
        private DevExpress.XtraBars.BarButtonItem barbtnExportProductReport;
        private DevExpress.XtraBars.BarButtonItem barbtnStaffReport;
        private DevExpress.XtraBars.BarButtonItem barbtnManageReceipt;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup6;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup7;
        public DevExpress.XtraTab.XtraTabControl xtraTabControl_Function;
    }
}

