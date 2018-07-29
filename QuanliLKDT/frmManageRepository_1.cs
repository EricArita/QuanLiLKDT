using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Windows.Forms;
using DevExpress.XtraTab;
using DTO;
using BLL;

namespace QuanliLKDT
{
    public partial class frmManageRepository_1 : Form
    {
        public frmManageRepository_1()
        {
            InitializeComponent();
        }

        private void enable_button(int stt)
        {
            if (stt == 0)
            {
                btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled = true;
                btnUpdate.Enabled = false;
                txtProductCode.Enabled = txtProductName.Enabled = txtSupplierCode.Enabled = txtNote.Enabled = txtAmount.Enabled = txtDate.Enabled = txtStatus.Enabled = false; 
            }
            else
            {
                btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled = false;
                btnUpdate.Enabled = true;
                txtProductCode.Enabled = txtProductName.Enabled = txtSupplierCode.Enabled = txtNote.Enabled = txtAmount.Enabled = txtDate.Enabled = txtStatus.Enabled = true;
            }
        }

        LogicManageRepository server = new LogicManageRepository();
        ObjManageRepository client, client_edited;
        DataSet Temporary_Dataset;
        string button;
        static int num1 = 0, num2 = 0;


        private void frmManageRepository_1_Load(object sender, EventArgs e)
        {
            enable_button(0);

            server = new LogicManageRepository();
            Temporary_Dataset = server.getDataBase("Kho");
            dataGridView.DataSource = Temporary_Dataset.Tables[0];
            dataGridView.Columns[0].HeaderText = "ID";
            dataGridView.Columns[1].HeaderText = "Mã sản phẩm";
            dataGridView.Columns[2].HeaderText = "Tên sản phẩm";
            dataGridView.Columns[3].HeaderText = "Mã nguồn";
            dataGridView.Columns[4].HeaderText = "Ngày nhập";
            dataGridView.Columns[5].HeaderText = "Trạng thái";
            dataGridView.Columns[6].HeaderText = "Số lượng";
            dataGridView.Columns[7].HeaderText = "Ghi chú";
            dataGridView.Columns[0].Width = 65;
            dataGridView.Columns[1].Width = 110;
            dataGridView.Columns[2].Width = 190;
            dataGridView.Columns[7].Width = 230;
            dataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.EnableHeadersVisualStyles = false;
            dataGridView.RowHeadersDefaultCellStyle.BackColor = Color.SkyBlue;
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.SkyBlue;
            dataGridView.RowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            dataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.LightCyan;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            enable_button(1);
            txtProductCode.Text = txtProductName.Text = txtSupplierCode.Text = txtNote.Text = txtAmount.Text = txtStatus.Text = "";
            txtDate.Text = DateTime.Today.ToString("dd/MM/yyyy");
            button = "Add";
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            enable_button(1);
            button = "Edit";
        }

        private bool checkAmountProducts() // This function is used to check amount of products left in repository
        {
            int num = int.Parse(txtAmount.Text);

            if (num == 0)
                return false;
            
            Temporary_Dataset = server.getDataBase(client, " view_TongSPNhap ");

            if (Temporary_Dataset.Tables[0].Rows[0][0] != null)
                num1 = int.Parse(Temporary_Dataset.Tables[0].Rows[0][0].ToString());

            Temporary_Dataset = server.getDataBase(client, " view_TongSPXuat ");

            if (Temporary_Dataset.Tables[0].Rows[0][0] != null)
                num2 = int.Parse(Temporary_Dataset.Tables[0].Rows[0][0].ToString());

            if (num > num1 - num2)
                return false;
            else
                return true;
        } 

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (button == "Add")
            {
                client = new ObjManageRepository(txtProductCode.Text, txtProductName.Text, txtSupplierCode.Text, txtDate.Text, txtStatus.Text, txtAmount.Text, txtNote.Text);
               
                if (txtStatus.Text == "Xuất" || txtStatus.Text == "xuất")
                {
                    bool isPossible = checkAmountProducts();
            
                    if (!isPossible)
                    {
                        MessageBox.Show("Mặt hàng này hiện còn " + (num1 - num2).ToString() + " sản phẩm trong kho, không đủ số lượng để xuất. Vui lòng nhập lại số lượng!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtAmount.Text = "";
                        txtAmount.Focus();
                    }
                    else
                    {
                        string ID = dataGridView.CurrentRow.Cells[0].Value.ToString();
                        server.setDataBase(client, button, ID);
                        Temporary_Dataset = server.getDataBase("Kho");
                        dataGridView.DataSource = Temporary_Dataset.Tables[0];

                        enable_button(0);
                        button = "";
                        return;
                    }
                }
                else
                {
                    string ID = dataGridView.CurrentRow.Cells[0].Value.ToString();
                    server.setDataBase(client, button, ID);
                    dataGridView.DataSource = Temporary_Dataset.Tables[0];

                    enable_button(0);
                    button = "";
                    return;
                }             
            }

            if (button == "Edit")
            {
                client_edited = new ObjManageRepository(txtProductCode.Text, txtProductName.Text, txtSupplierCode.Text, txtDate.Text, txtStatus.Text, txtAmount.Text, txtNote.Text);
               
                if (txtStatus.Text == "Xuất" && txtStatus.Text == "xuất")
                {
                    bool isPossible = checkAmountProducts();

                    if (!isPossible)
                    {
                        MessageBox.Show("Mặt hàng này hiện còn " + (num1 - num2).ToString() + " sản phẩm trong kho, không đủ số lượng để xuất. Vui lòng nhập lại số lượng!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtAmount.Text = "";
                        txtAmount.Focus();
                    }
                    else
                    {
                        string ID = dataGridView.CurrentRow.Cells[0].Value.ToString();
                        server.editDataBase(ID, client_edited);
                        Temporary_Dataset = server.getDataBase("Kho");
                        dataGridView.DataSource = Temporary_Dataset.Tables[0];

                        enable_button(0);
                        button = "";
                        return;
                    }
                }
                else
                {
                    string ID = dataGridView.CurrentRow.Cells[0].Value.ToString();
                    server.editDataBase(ID, client_edited);
                    Temporary_Dataset = server.getDataBase("Kho");
                    dataGridView.DataSource = Temporary_Dataset.Tables[0];

                    enable_button(0);
                    button = "";
                    return;
                }
            }                          
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Bạn có chắc muốn xóa loại sản phẩm này?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            button = "Delete";
            if (res == DialogResult.Yes)
            {
                client = new ObjManageRepository(txtProductCode.Text, txtProductName.Text, txtSupplierCode.Text, txtDate.Text, txtStatus.Text, txtAmount.Text, txtNote.Text);
                string ID = dataGridView.CurrentRow.Cells[0].Value.ToString();
                server.setDataBase(client, button, ID);
                Temporary_Dataset = server.getDataBase("Kho");
                dataGridView.DataSource = Temporary_Dataset.Tables[0];
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult res;

            if (btnUpdate.Enabled == true)
                res = MessageBox.Show("Bạn chưa cập nhật thông tin hiện tại. Bạn có chắc muốn thoát?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            else
                res = MessageBox.Show("Bạn có chắc muốn thoát?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (res == DialogResult.Yes)
            {
                this.Close();

                foreach (frmMain f in Application.OpenForms)
                {
                    foreach (XtraTabPage tab in f.xtraTabControl_Function.TabPages)
                    {
                        if (tab.Name == this.Name)
                        {
                            f.xtraTabControl_Function.TabPages.Remove(tab);
                            return;
                        }
                    }
                }
            }
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtProductCode.Text = dataGridView.CurrentRow.Cells[1].Value.ToString();
            txtProductName.Text = dataGridView.CurrentRow.Cells[2].Value.ToString();
            txtSupplierCode.Text = dataGridView.CurrentRow.Cells[3].Value.ToString();
            txtDate.Text = dataGridView.CurrentRow.Cells[4].Value.ToString();
            txtStatus.Text = dataGridView.CurrentRow.Cells[5].Value.ToString();
            txtAmount.Text = dataGridView.CurrentRow.Cells[6].Value.ToString();
            txtNote.Text = dataGridView.CurrentRow.Cells[7].Value.ToString();
        }

    }
}
