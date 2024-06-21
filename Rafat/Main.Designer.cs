namespace Rafat
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            flowLayoutPanelNavBar = new FlowLayoutPanel();
            buttonHome = new Button();
            buttonSalayCategory = new Button();
            buttonEmployees = new Button();
            buttonRetirment = new Button();
            buttonUsers = new Button();
            buttonReport = new Button();
            buttonSystemRecords = new Button();
            buttonSettings = new Button();
            buttonHelp = new Button();
            buttonAbout = new Button();
            panelContainer = new Panel();
            toolTip1 = new ToolTip(components);
            flowLayoutPanelNavBar.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanelNavBar
            // 
            flowLayoutPanelNavBar.AutoScroll = true;
            flowLayoutPanelNavBar.Controls.Add(buttonHome);
            flowLayoutPanelNavBar.Controls.Add(buttonSalayCategory);
            flowLayoutPanelNavBar.Controls.Add(buttonEmployees);
            flowLayoutPanelNavBar.Controls.Add(buttonRetirment);
            flowLayoutPanelNavBar.Controls.Add(buttonUsers);
            flowLayoutPanelNavBar.Controls.Add(buttonReport);
            flowLayoutPanelNavBar.Controls.Add(buttonSystemRecords);
            flowLayoutPanelNavBar.Controls.Add(buttonSettings);
            flowLayoutPanelNavBar.Controls.Add(buttonHelp);
            flowLayoutPanelNavBar.Controls.Add(buttonAbout);
            flowLayoutPanelNavBar.Dock = DockStyle.Bottom;
            flowLayoutPanelNavBar.Location = new Point(0, 606);
            flowLayoutPanelNavBar.Name = "flowLayoutPanelNavBar";
            flowLayoutPanelNavBar.Padding = new Padding(3);
            flowLayoutPanelNavBar.Size = new Size(1062, 67);
            flowLayoutPanelNavBar.TabIndex = 0;
            // 
            // buttonHome
            // 
            buttonHome.Image = Properties.Resources.icons8_home_32px;
            buttonHome.ImageAlign = ContentAlignment.MiddleLeft;
            buttonHome.Location = new Point(880, 8);
            buttonHome.Margin = new Padding(5);
            buttonHome.Name = "buttonHome";
            buttonHome.Size = new Size(150, 50);
            buttonHome.TabIndex = 0;
            buttonHome.Text = "الرئيسة";
            toolTip1.SetToolTip(buttonHome, "الصفحة الرئيسية");
            buttonHome.UseVisualStyleBackColor = true;
            buttonHome.Click += buttonHome_Click;
            // 
            // buttonSalayCategory
            // 
            buttonSalayCategory.Image = Properties.Resources.icons8_teacher_hiring_32px;
            buttonSalayCategory.ImageAlign = ContentAlignment.MiddleLeft;
            buttonSalayCategory.Location = new Point(720, 8);
            buttonSalayCategory.Margin = new Padding(5);
            buttonSalayCategory.Name = "buttonSalayCategory";
            buttonSalayCategory.Size = new Size(150, 50);
            buttonSalayCategory.TabIndex = 1;
            buttonSalayCategory.Text = "السلم";
            toolTip1.SetToolTip(buttonSalayCategory, "ادارة سلم الرواتب");
            buttonSalayCategory.UseVisualStyleBackColor = true;
            buttonSalayCategory.Click += buttonSalayCategory_Click;
            // 
            // buttonEmployees
            // 
            buttonEmployees.Image = Properties.Resources.icons8_conference_foreground_selected_32px;
            buttonEmployees.ImageAlign = ContentAlignment.MiddleLeft;
            buttonEmployees.Location = new Point(560, 8);
            buttonEmployees.Margin = new Padding(5);
            buttonEmployees.Name = "buttonEmployees";
            buttonEmployees.Size = new Size(150, 50);
            buttonEmployees.TabIndex = 2;
            buttonEmployees.Text = "   الموظفين";
            toolTip1.SetToolTip(buttonEmployees, "إدارة الموظفين");
            buttonEmployees.UseVisualStyleBackColor = true;
            // 
            // buttonRetirment
            // 
            buttonRetirment.Image = Properties.Resources.icons8_retired_32px;
            buttonRetirment.ImageAlign = ContentAlignment.MiddleLeft;
            buttonRetirment.Location = new Point(400, 8);
            buttonRetirment.Margin = new Padding(5);
            buttonRetirment.Name = "buttonRetirment";
            buttonRetirment.Size = new Size(150, 50);
            buttonRetirment.TabIndex = 8;
            buttonRetirment.Text = "     المتقاعدين";
            toolTip1.SetToolTip(buttonRetirment, "حول النظام واخر التحديثات");
            buttonRetirment.UseVisualStyleBackColor = true;
            // 
            // buttonUsers
            // 
            buttonUsers.Image = Properties.Resources.icons8_users_32px;
            buttonUsers.ImageAlign = ContentAlignment.MiddleLeft;
            buttonUsers.Location = new Point(240, 8);
            buttonUsers.Margin = new Padding(5);
            buttonUsers.Name = "buttonUsers";
            buttonUsers.Size = new Size(150, 50);
            buttonUsers.TabIndex = 3;
            buttonUsers.Text = "    مستخدم";
            toolTip1.SetToolTip(buttonUsers, "إدارة المستخدمين");
            buttonUsers.UseVisualStyleBackColor = true;
            buttonUsers.Click += buttonUsers_Click;
            // 
            // buttonReport
            // 
            buttonReport.Image = Properties.Resources.icons8_Business_Report_32px;
            buttonReport.ImageAlign = ContentAlignment.MiddleLeft;
            buttonReport.Location = new Point(80, 8);
            buttonReport.Margin = new Padding(5);
            buttonReport.Name = "buttonReport";
            buttonReport.Size = new Size(150, 50);
            buttonReport.TabIndex = 4;
            buttonReport.Text = "  التقارير";
            toolTip1.SetToolTip(buttonReport, "توليد تقارير النظام");
            buttonReport.UseVisualStyleBackColor = true;
            // 
            // buttonSystemRecords
            // 
            buttonSystemRecords.Image = Properties.Resources.icons8_moleskine_32px;
            buttonSystemRecords.ImageAlign = ContentAlignment.MiddleLeft;
            buttonSystemRecords.Location = new Point(880, 68);
            buttonSystemRecords.Margin = new Padding(5);
            buttonSystemRecords.Name = "buttonSystemRecords";
            buttonSystemRecords.Size = new Size(150, 50);
            buttonSystemRecords.TabIndex = 9;
            buttonSystemRecords.Text = "     الحركة";
            toolTip1.SetToolTip(buttonSystemRecords, "سجل حركات النظام");
            buttonSystemRecords.UseVisualStyleBackColor = true;
            buttonSystemRecords.Click += buttonSystemRecords_Click;
            // 
            // buttonSettings
            // 
            buttonSettings.Image = Properties.Resources.icons8_settings_32px;
            buttonSettings.ImageAlign = ContentAlignment.MiddleLeft;
            buttonSettings.Location = new Point(720, 68);
            buttonSettings.Margin = new Padding(5);
            buttonSettings.Name = "buttonSettings";
            buttonSettings.Size = new Size(150, 50);
            buttonSettings.TabIndex = 5;
            buttonSettings.Text = "     الاعدادات";
            toolTip1.SetToolTip(buttonSettings, "ضبط الاعدادات العامة للبرنامج");
            buttonSettings.UseVisualStyleBackColor = true;
            // 
            // buttonHelp
            // 
            buttonHelp.Image = Properties.Resources.icons8_help_32px;
            buttonHelp.ImageAlign = ContentAlignment.MiddleLeft;
            buttonHelp.Location = new Point(560, 68);
            buttonHelp.Margin = new Padding(5);
            buttonHelp.Name = "buttonHelp";
            buttonHelp.Size = new Size(150, 50);
            buttonHelp.TabIndex = 6;
            buttonHelp.Text = "     المساعدة";
            toolTip1.SetToolTip(buttonHelp, "الدروس التعليمية");
            buttonHelp.UseVisualStyleBackColor = true;
            // 
            // buttonAbout
            // 
            buttonAbout.Image = Properties.Resources.icons8_about_32px;
            buttonAbout.ImageAlign = ContentAlignment.MiddleLeft;
            buttonAbout.Location = new Point(400, 68);
            buttonAbout.Margin = new Padding(5);
            buttonAbout.Name = "buttonAbout";
            buttonAbout.Size = new Size(150, 50);
            buttonAbout.TabIndex = 7;
            buttonAbout.Text = "     حول";
            toolTip1.SetToolTip(buttonAbout, "حول النظام واخر التحديثات");
            buttonAbout.UseVisualStyleBackColor = true;
            // 
            // panelContainer
            // 
            panelContainer.BackColor = Color.White;
            panelContainer.Dock = DockStyle.Fill;
            panelContainer.Location = new Point(0, 0);
            panelContainer.Name = "panelContainer";
            panelContainer.Size = new Size(1062, 606);
            panelContainer.TabIndex = 1;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(11F, 37F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1062, 673);
            Controls.Add(panelContainer);
            Controls.Add(flowLayoutPanelNavBar);
            Font = new Font("Cairo", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 6, 4, 6);
            Name = "Main";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Rafat";
            WindowState = FormWindowState.Maximized;
            FormClosing += Main_FormClosing;
            flowLayoutPanelNavBar.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanelNavBar;
        private Button buttonHome;
        private Button buttonSalayCategory;
        private Button buttonEmployees;
        private Button buttonUsers;
        private Button buttonReport;
        private Button buttonSettings;
        private Button buttonHelp;
        private Button buttonAbout;
        public Panel panelContainer;
        private ToolTip toolTip1;
        private Button buttonRetirment;
        private Button buttonSystemRecords;
    }
}
