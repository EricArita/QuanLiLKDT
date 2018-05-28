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
using DTO;
using BLL;

namespace QuanliLKDT
{
    public partial class frmCustomer : Form
    {
        public frmCustomer()
        {
            InitializeComponent();
        }

        private void enable_button(int stt)
        {
            if (stt == 0)
            {
                btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled = true;
                btnUpdate.Enabled = false;
                txtCodeCustomer.Enabled = txtNameCustomer.Enabled = txtPhone.Enabled = txtNote.Enabled = false;
            }
            else
            {
                btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled = false;
                btnUpdate.Enabled = true;
                txtCodeCustomer.Enabled = txtNameCustomer.Enabled = txtPhone.Enabled = txtNote.Enabled = true;
            }
        }

        LogicCustomer server;
        ObjCustomer client, client_edited;
        string button;

        private void frmCustomer_Load(object sender, EventArgs e)
        {
            enable_button(0);

            server = new LogicCustomer();
            DataSet dataset = server.getDataBase("KhachHang");
            dataGridView.DataSource = dataset.Tables[0];
            dataGridView.Columns[0].HeaderText = "Mã Khách hàng";
            dataGridView.Columns[1].HeaderText = "Tên khách hàng";
            dataGridView.Columns[2].HeaderText = "Số ĐT";
            dataGridView.Columns[3].HeaderText = "Ghi chú";
            dataGridView.Columns[0].Width = 190;
            dataGridView.Columns[1].Width = 190;
            dataGridView.Columns[2].Width = 190;
            dataGridView.Columns[3].Width = 193;
            dataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.EnableHeadersVisualStyles = false;
            dataGridView.RowHeadersDefaultCellStyle.BackColor = Color.SkyBlue;
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.SkyBlue;
            dataGridView.RowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            dataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.LightCyan;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            enable_button(1);
            txtCodeCustomer.Text = txtNameCustomer.Text = txtPhone.Text = txtNote.Text = " ";
            button = "Add";
        }


        private void btnEdit_Click(object sender, EventArgs e)
        {
            enable_button(1);
            button = "Edit";
            client = new ObjCustomer(txtCodeCustomer.Text, txtNameCustomer.Text, txtPhone.Text, txtNote.Text);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (button == "Add")
            {
                client = new ObjCustomer(txtCodeCustomer.Text, txtNameCustomer.Text, txtPhone.Text, txtNote.Text);
                server = new LogicCustomer();
                DataSet dataset_Check = server.getDataBase(client);
                if (dataset_Check.Tables[0].Rows.Count > 0)
                    MessageBox.Show("Sản phẩm này đã tồn tại trong danh sách", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    server.setDataBase(client, button);
                    dataset_Check = server.getDataBase("KhachHang");
                    dataGridView.DataSource = dataset_Check.Tables[1];
                }

                enable_button(0);
                button = "";
                return;
            }

            if (button == "Edit")
            {
                client_edited = new ObjCustomer(txtCodeCustomer.Text, txtNameCustomer.Text, txtPhone.Text, txtNote.Text);
                server = new LogicCustomer();
                server.editDataBase(client, client_edited);
                DataSet dataset_edit = server.getDataBase("KhachHang");
                dataGridView.DataSource = dataset_edit.Tables[0];
                enable_button(0);
                button = "";
                return;
            }
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Bạn có chắc muốn xóa loại sản phẩm này?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            button = "Delete";
            if (res == DialogResult.Yes)
            {
                client = new ObjCustomer(txtCodeCustomer.Text, txtNameCustomer.Text, txtPhone.Text, txtNote.Text);
                server = new LogicCustomer();
                server.setDataBase(client, button);
                DataSet dataset_AfterDeleting = server.getDataBase("KhachHang");
                dataGridView.DataSource = dataset_AfterDeleting.Tables[0];
            }
        }
 
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Bạn có chắc muón thoát?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
                this.Close();
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodeCustomer.Text = dataGridView.CurrentRow.Cells[0].Value.ToString();
            txtNameCustomer.Text = dataGridView.CurrentRow.Cells[1].Value.ToString();
            txtPhone.Text = dataGridView.CurrentRow.Cells[2].Value.ToString();
            txtNote.Text = dataGridView.CurrentRow.Cells[3].Value.ToString();
        }

    }
}
