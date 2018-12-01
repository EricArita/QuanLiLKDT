using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;

namespace QuanliLKDT
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            BonusSkins.Register();
            SkinManager.EnableFormSkins();

            frmLogin frm = new frmLogin();
            Application.Run(frm);

            if (frmLogin.LoginSuccessfull)
            {
                frmMain frm1 = new frmMain();
                frm1.DetailPermissionList = frm.DetailPermissionList;
                Application.Run(frm1);
            }
        }
    }
}
