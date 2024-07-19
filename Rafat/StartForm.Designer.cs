namespace Rafat
{
    partial class StartForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            progressBar1 = new ProgressBar();
            labelState = new Label();
            pictureBox1 = new PictureBox();
            panelSettings = new Panel();
            linkLabelExit = new LinkLabel();
            linkLabelSetServer = new LinkLabel();
            timerStart = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panelSettings.SuspendLayout();
            SuspendLayout();
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(20, 323);
            progressBar1.Margin = new Padding(4, 6, 4, 6);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(542, 39);
            progressBar1.Style = ProgressBarStyle.Marquee;
            progressBar1.TabIndex = 0;
            // 
            // labelState
            // 
            labelState.Location = new Point(91, 280);
            labelState.Name = "labelState";
            labelState.RightToLeft = RightToLeft.Yes;
            labelState.Size = new Size(471, 37);
            labelState.TabIndex = 1;
            labelState.Text = "جاري الاتصال ...";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Rafat_Logo;
            pictureBox1.Location = new Point(127, 29);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(326, 240);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // panelSettings
            // 
            panelSettings.Controls.Add(linkLabelExit);
            panelSettings.Controls.Add(linkLabelSetServer);
            panelSettings.Location = new Point(-1, 366);
            panelSettings.Name = "panelSettings";
            panelSettings.Size = new Size(590, 41);
            panelSettings.TabIndex = 3;
            panelSettings.Visible = false;
            // 
            // linkLabelExit
            // 
            linkLabelExit.AutoSize = true;
            linkLabelExit.Font = new Font("Cairo", 10F, FontStyle.Regular, GraphicsUnit.Point);
            linkLabelExit.Location = new Point(269, 2);
            linkLabelExit.Name = "linkLabelExit";
            linkLabelExit.Size = new Size(111, 32);
            linkLabelExit.TabIndex = 0;
            linkLabelExit.TabStop = true;
            linkLabelExit.Text = "اغلاق البرنامج";
            linkLabelExit.LinkClicked += linkLabelExit_LinkClicked;
            // 
            // linkLabelSetServer
            // 
            linkLabelSetServer.AutoSize = true;
            linkLabelSetServer.Font = new Font("Cairo", 10F, FontStyle.Regular, GraphicsUnit.Point);
            linkLabelSetServer.Location = new Point(393, 2);
            linkLabelSetServer.Name = "linkLabelSetServer";
            linkLabelSetServer.Size = new Size(170, 32);
            linkLabelSetServer.TabIndex = 0;
            linkLabelSetServer.TabStop = true;
            linkLabelSetServer.Text = "تعديل اعدادات الاتصال";
            linkLabelSetServer.LinkClicked += linkLabelSetServer_LinkClicked;
            // 
            // timerStart
            // 
            timerStart.Enabled = true;
            timerStart.Interval = 5000;
            timerStart.Tick += timerStart_Tick;
            // 
            // StartForm
            // 
            AutoScaleDimensions = new SizeF(11F, 37F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(587, 421);
            Controls.Add(panelSettings);
            Controls.Add(pictureBox1);
            Controls.Add(labelState);
            Controls.Add(progressBar1);
            Font = new Font("Cairo", 12F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(6, 9, 6, 9);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "StartForm";
            Padding = new Padding(16, 26, 16, 26);
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "StartForm";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panelSettings.ResumeLayout(false);
            panelSettings.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ProgressBar progressBar1;
        private Label labelState;
        private PictureBox pictureBox1;
        private Panel panelSettings;
        private LinkLabel linkLabelExit;
        private LinkLabel linkLabelSetServer;
        private System.Windows.Forms.Timer timerStart;
    }
}
