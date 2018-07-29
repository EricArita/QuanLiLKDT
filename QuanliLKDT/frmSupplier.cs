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
    public partial class frmSupplier : Form
    {
        public frmSupplier()
        {
            InitializeComponent();
        }

        private void enable_button(int stt)
        {
            if (stt == 0)
            {
                btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled = true;
                btnUpdate.Enabled = false;
                txtSupplierCode.Enabled = txtName.Enabled = txtNote.Enabled = false;
            }
            else
            {
                btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled = false;
                btnUpdate.Enabled = true;
                txtSupplierCode.Enabled = txtName.Enabled = txtNote.Enabled = true;
            }
        }

        LogicSupplier server;
        ObjSupplier client, client_edited;
        string button;

        private void frmSupplier_Load(object sender, EventArgs e)
        {
            enable_button(0);

            server = new LogicSupplier();
            DataSet dataset = server.getDataBase("NguonCungCap");
            dataGridView.DataSource = dataset.Tables[0];
            dataGridView.Columns[0].HeaderText = "Mã nguồn";
            dataGridView.Columns[1].HeaderText = "Tên nguồn";
            dataGridView.Columns[2].HeaderText = "Ghi chú";
            dataGridView.Columns[0].Width = 190;
            dataGridView.Columns[1].Width = 190;
            dataGridView.Columns[2].Width = 190;
            dataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.EnableHeadersVisualStyles = false;
            dataGridView.RowHeadersDefaultCellStyle.BackColor = Color.SkyBlue;
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.SkyBlue;
            dataGridView.RowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            dataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.LightCyan;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            enable_button(1);
            txtSupplierCode.Text = txtName.Text = txtNote.Text = "";
            button = "Add";
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            enable_button(1);
            button = "Edit";
            client = new ObjSupplier(txtSupplierCode.Text, txtName.Text, txtNote.Text);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Bạn có chắc muốn xóa loại sản phẩm này?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            button = "Delete";
            if (res == DialogResult.Yes)
            {
                client = new ObjSupplier(txtSupplierCode.Text, txtName.Text, txtNote.Text);
                server = new LogicSupplier();
                server.setDataBase(client, button);
                DataSet dataset_AfterDeleting = server.getDataBase("NguonCungCap");
                dataGridView.DataSource = dataset_AfterDeleting.Tables[0];
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (button == "Add")
            {
                client = new ObjSupplier(txtSupplierCode.Text, txtName.Text, txtNote.Text);
                server = new LogicSupplier();
                DataSet dataset_Check = server.getDataBase(client);
                if (dataset_Check.Tables[0].Rows.Count > 0)
                    MessageBox.Show("Nhà cung cấp này đã tồn tại trong danh sách", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    server.setDataBase(client, button);
                    dataset_Check = server.getDataBase("NguonCungCap");
                    dataGridView.DataSource = dataset_Check.Tables[0];
                }

                enable_button(0);
                button = "";
                return;
            }

            if (button == "Edit")
            {
                client_edited = new ObjSupplier(txtSupplierCode.Text, txtName.Text, txtNote.Text);
                server = new LogicSupplier();
                server.editDataBase(client, client_edited);
                DataSet dataset_edit = server.getDataBase("NguonCungCap");
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
            txtSupplierCode.Text = dataGridView.CurrentRow.Cells[0].Value.ToString();
            txtName.Text = dataGridView.CurrentRow.Cells[1].Value.ToString();
            txtNote.Text = dataGridView.CurrentRow.Cells[2].Value.ToString();
        }

    }
}
