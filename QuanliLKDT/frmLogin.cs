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
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            ObjLogin client = new ObjLogin(txtUsername.Text, txtPassword.Text);
            LogicLogin server = new LogicLogin();
            string ID_User = server.getID_User(client);
            MessageBox.Show(ID_User);
        }
    }
}
