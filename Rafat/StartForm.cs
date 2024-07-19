using Rafat.Data.EF;
using Rafat.Gui.UsersGui;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rafat
{
    partial class StartForm : Form
    {
        private DBContext db;
        public StartForm()
        {
            InitializeComponent();
            Code.Helper.ConStringHelper.SetConString();
        }

        private void linkLabelSetServer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Show Settings From
            Gui.SettingsGui.SettingForm settingForm = new Gui.SettingsGui.SettingForm();
            settingForm.Show();
        }

        private void linkLabelExit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Application.Exit();
        }

        private async void timerStart_Tick(object sender, EventArgs e)
        {
            db = new DBContext();

            // Check the con
            labelState.Text = "جاري الاتصال..";
            if(await db.Database.CanConnectAsync())
            {
                // Show Login From
                timerStart.Enabled = false;
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
                this.Hide();
            }
            else
            {
                panelSettings.Visible = true;
                labelState.Text = "فشل الاتصال ... سنعاود الاتصال بعد لحظات";
            }
        }
    }
}
