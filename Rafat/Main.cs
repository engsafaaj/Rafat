using Rafat.Code.Helper;

namespace Rafat
{
    public partial class Main : Form
    {
        private PageHelper pageHelper;

        public Main()
        {
            InitializeComponent();

            pageHelper = new PageHelper(this);

            // Set Home Page
            pageHelper.SetPage(Gui.HomeGui.HomeUserControl.Instance());
            // Get And Set The Window State
            SetScreenState(Properties.Settings.Default.IsMaxScreen);

            SetRoles();
        }

        // Test
        private void SetRoles()
        {
            Code.Models.LocalUser.UserId = "1111235";
            Code.Models.LocalUser.Id = 1;
            Code.Models.LocalUser.Role = "Admin";
            Code.Models.LocalUser.FullName = "Safaa Jassim";
            Code.Models.LocalUser.UserName = "Safaa";

        }
        private void SetScreenState(bool IsMax)
        {
            if (IsMax)
            {
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveWindowStateSettings();
        }

        private void SaveWindowStateSettings()
        {
            // Save Window State
            if (WindowState == FormWindowState.Maximized)
            {
                Properties.Settings.Default.IsMaxScreen = true;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.IsMaxScreen = false;
                Properties.Settings.Default.Save();
            }
        }

        private void buttonHome_Click(object sender, EventArgs e)
        {
            pageHelper.SetPage(Gui.HomeGui.HomeUserControl.Instance());
        }

        private void buttonUsers_Click(object sender, EventArgs e)
        {
            pageHelper.SetPage(Gui.UsersGui.UsersUserControl.Instance(this));
        }

        private void buttonSystemRecords_Click(object sender, EventArgs e)
        {
            pageHelper.SetPage(Gui.SystemRecordsGui.SystemRecordsUserControl.Instance(this));

        }

        private void buttonSalayCategory_Click(object sender, EventArgs e)
        {
            pageHelper.SetPage(Gui.SalaryRateGui.SalaryRateUserControl.Instance(this));

        }
    }
}
