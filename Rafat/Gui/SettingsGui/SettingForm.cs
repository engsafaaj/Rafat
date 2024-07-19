using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rafat.Gui.SettingsGui
{
    partial class SettingForm : Form
    {
        public SettingForm()
        {
            InitializeComponent();
            GetSettings();
        }

        private void buttonSaveGenralSettings_Click(object sender, EventArgs e)
        {
            SaveGenralSettings();
        }

        private void SaveGenralSettings()
        {
            // Set Settings
            Properties.Settings.Default.CompanyName = textBoxCompnayName.Text;
            Properties.Settings.Default.Currency = textBoxCurrency.Text;
            Properties.Settings.Default.NoOfDataGirdViewItems = (int)numericUpDownNoOfItmes.Value;



            // Save
            Properties.Settings.Default.Save();
            MessageBox.Show("تم حفظ الاعدادات");
        }

        private void GetSettings()
        {
            // General Settings
            textBoxCompnayName.Text = Properties.Settings.Default.CompanyName;
            textBoxCurrency.Text = Properties.Settings.Default.Currency;
            numericUpDownNoOfItmes.Value = Properties.Settings.Default.NoOfDataGirdViewItems;

            // Connection Settings
            if (Properties.Settings.Default.ConType == "local")
            {
                radioButtonLocal.Checked = true;
                textBoxUserName.Enabled = false;
                textBoxPassword.Enabled = false;
                numericUpDownDuration.Enabled = false;
            }
            else
            {
                radioButtonNetwork.Checked = true;
                textBoxUserName.Enabled = true;
                textBoxPassword.Enabled = true;
                numericUpDownDuration.Enabled = true;
            }
            textBoxServer.Text = Properties.Settings.Default.Server;
            textBoxDataBase.Text = Properties.Settings.Default.DataBase;
            textBoxUserName.Text = Properties.Settings.Default.UserName;
            textBoxPassword.Text = Properties.Settings.Default.Password;
            numericUpDownDuration.Value = Properties.Settings.Default.NoOfDataGirdViewItems;
        }

        private void buttonSaveConnection_Click(object sender, EventArgs e)
        {
            // Connection Settings
            if (radioButtonLocal.Checked)
            {
                Properties.Settings.Default.ConType = "local";
            }
            else
            {
                Properties.Settings.Default.ConType = "network";
            }
            Properties.Settings.Default.Server = textBoxServer.Text;
            Properties.Settings.Default.DataBase = textBoxDataBase.Text;
            Properties.Settings.Default.UserName = textBoxUserName.Text;
            Properties.Settings.Default.Password = textBoxPassword.Text;
            Properties.Settings.Default.ConDuration = (int)numericUpDownDuration.Value;
            Properties.Settings.Default.Save();
            MessageBox.Show("تم حفظ الاعدادات");

            Application.Restart();
        }

        private void radioButtonLocal_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonLocal.Checked)
            {
                textBoxUserName.Enabled = false;
                textBoxPassword.Enabled = false;
                numericUpDownDuration.Enabled = false;
            }
        }

        private void radioButtonNetwork_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonNetwork.Checked)
            {
                textBoxUserName.Enabled = true;
                textBoxPassword.Enabled = true;
                numericUpDownDuration.Enabled = true;
            }
        }
    }
}
