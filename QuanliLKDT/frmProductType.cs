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
    public partial class frmProductType : Form
    {
        public frmProductType()
        {
            InitializeComponent();
        }

        private void enable_button(int stt)
        {
            if (stt == 0)
            {
                btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled = true;
                btnUpdate.Enabled = false;
                txtTypeCode.Enabled = txtTypeName.Enabled = false;
            }
            else
            {
                btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled = false;
                btnUpdate.Enabled = true;              
                txtTypeCode.Enabled = txtTypeName.Enabled = true;
            }
        }

        LogicProductType server;
        ObjProductType client, client_edited;
        string button;

        private void frmProductType_Load(object sender, EventArgs e)
        {
            enable_button(0);

            server = new LogicProductType();
            DataSet dataset = server.getDataBase("LoaiSP");
            dataGridView.DataSource = dataset.Tables[0];
            dataGridView.Columns[0].Width = 372;
            dataGridView.Columns[1].Width = 375;
            dataGridView.Columns[0].HeaderText = "Mã Loại";
            dataGridView.Columns[1].HeaderText = "Tên Loại";
            dataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.EnableHeadersVisualStyles = false;
            dataGridView.RowHeadersDefaultCellStyle.BackColor = Color.SkyBlue;
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.SkyBlue;
            dataGridView.RowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            dataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.LightCyan;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            enable_button(1);
            txtTypeCode.Text = txtTypeName.Text = "";
            button = "Add";
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            enable_button(1);
            button = "Edit";
            client = new ObjProductType(txtTypeCode.Text, txtTypeName.Text);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Bạn có chắc muốn xóa loại sản phẩm này?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            button = "Delete";
            if (res == DialogResult.Yes)
            {
                client = new ObjProductType(txtTypeCode.Text, txtTypeName.Text);
                server = new LogicProductType();
                server.setDataBase(client, button);
                DataSet dataset_AfterDeleting = server.getDataBase("LoaiSP");
                dataGridView.DataSource = dataset_AfterDeleting.Tables[0];
            }
        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (button == "Add")
            {
                client = new ObjProductType(txtTypeCode.Text, txtTypeName.Text);
                server = new LogicProductType();
                DataSet dataset_Check = server.getDataBase(client);
                if (dataset_Check.Tables[0].Rows.Count > 0)
                    MessageBox.Show("Sản phẩm này đã tồn tại trong danh sách", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    server.setDataBase(client, button);
                    dataset_Check = server.getDataBase("LoaiSP");
                    dataGridView.DataSource = dataset_Check.Tables[0];
                }

                enable_button(0);
                button = "";
                return;
            }

            if (button == "Edit")
            {
                client_edited = new ObjProductType(txtTypeCode.Text, txtTypeName.Text);
                server = new LogicProductType();
                server.editDataBase(client, client_edited);
                DataSet dataset_edit = server.getDataBase("LoaiSP");
                dataGridView.DataSource = dataset_edit.Tables[0];
                enable_button(0);
                button = "";
                return;
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
            txtTypeCode.Text = dataGridView.CurrentRow.Cells[0].Value.ToString();
            txtTypeName.Text = dataGridView.CurrentRow.Cells[1].Value.ToString();
        }


        /*private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            admin = new Logic();
            DataSet search = admin.getDB();
            DataView dv_search = new DataView(search.Tables[0]);
            dv_search.RowFilter = "NameOfElement like '%" + txtSearch.Text + "%' or Sign like '%" + txtSearch.Text + "%'";
            //string.Format("NameOfElement LIKE '{0}%'", txtSearch.Text);
            dataGridView.DataSource = dv_search;
        }*/
    }
}

