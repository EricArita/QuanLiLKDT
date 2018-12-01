using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DTO;

namespace QuanliLKDT
{
    public partial class frmLogin : Form
    {
        public static bool LoginSuccessfull = false;
        List<string> detailPermissionList;

        public List<string> DetailPermissionList { get => detailPermissionList; set => detailPermissionList = value; }

        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            ObjLogin client = new ObjLogin(txtUsername.Text, txtPassword.Text);
            LogicLogin server = new LogicLogin();

            string ID_User = server.getID_User(client);

            if (ID_User != " ")
            {
                string ID_Permission = server.getID_Permission(ID_User);
                DetailPermissionList = server.getDetailPermission(ID_Permission);

                LoginSuccessfull = true;
                this.Close();
            }
            else
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

    }
}
