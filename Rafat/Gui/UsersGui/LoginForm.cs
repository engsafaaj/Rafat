using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.VisualBasic.ApplicationServices;
using Rafat.Code.Helper;
using Rafat.Code.Models;
using Rafat.Core;
using Rafat.Data.EF;
using Rafat.Gui.LoadingGui;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rafat.Gui.UsersGui
{
    public partial class LoginForm : Form
    {
        private readonly IDataHelper<Core.Users> dataHelperForUser;
        private readonly IDataHelper<Roles> dataHelperForRoles;
        private readonly IDataHelper<SystemRecords> dataHelperForSystemRecords;
        Main main;
        public LoginForm()
        {
            InitializeComponent();

            dataHelperForUser = new UsersEF();
            dataHelperForRoles = new RolesEF();
            dataHelperForSystemRecords = new SystemRecordsEF();
        }


        private bool IsValid()
        {
            if (

                textBoxPassword.Text.Length < 3 ||
                textBoxUserName.Text.Length < 3
                )
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        private async void buttonSave_Click(object sender, EventArgs e)
        {
            // Check the fields
            if (!IsValid())
            {
                MsgHelper.ShowRequiredFields();
            }
            else
            {
                // Show Loading
                pictureBoxLoding.Visible = true;
                // Check Connection
                if (await Task.Run(() => dataHelperForUser.IsCanConnect()))
                {

                    Login();

                }

                else
                {
                    pictureBoxLoding.Visible = false;

                    MsgHelper.ShowServerError();
                }

                pictureBoxLoding.Visible = false;

            }

        }

        private async void Login()
        {

            // Check user Name and Password
            string userName = textBoxUserName.Text,
                    password = textBoxPassword.Text;
            Core.Users user = await Task.Run(() =>
            dataHelperForUser.GetAllData()
            .Where(x => x.UserName == userName && x.Password == password).FirstOrDefault() ?? new Core.Users());
            if (user.Id > 0)
            {
                // Set User Info
                LocalUser.Id = user.Id;
                LocalUser.UserName = user.UserName;
                LocalUser.Password = user.Password;
                LocalUser.Address = user.Address;
                LocalUser.UserId = user.UserId;
                LocalUser.FullName = user.FullName;
                LocalUser.Email = user.Email;
                LocalUser.IsSecondaryUser = user.IsSecondaryUser;

                // Get and set roles
                RolesHelper.localRoles = await Task.Run(() => dataHelperForRoles
                    .GetAllData()
                    .Where(x => x.UsersId == user.Id).ToList());

                // Success
                SystemRecordHelper.Add("تسجيل الدخول",
                    $"تم تسجيل دخول مستخدم     {user.FullName}");

                Main main = new Main();
                main.Show();
                this.Hide();
            }
            else
            {

                MessageBox.Show("معلومات تسجيل الدخول خاطئة", "خطأ في تسجيل الدخول", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
