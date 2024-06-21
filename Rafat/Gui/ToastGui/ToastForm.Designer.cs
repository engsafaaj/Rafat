namespace Rafat.Gui.ToastGui
{
    partial class ToastForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            pictureBox1 = new PictureBox();
            labelTitle = new Label();
            labelDescription = new Label();
            timerToast = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Right;
            pictureBox1.Image = Properties.Resources.icons8_Notification_512px;
            pictureBox1.Location = new Point(293, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(75, 79);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // labelTitle
            // 
            labelTitle.Dock = DockStyle.Top;
            labelTitle.Font = new Font("Cairo", 14F, FontStyle.Bold, GraphicsUnit.Point);
            labelTitle.Location = new Point(0, 0);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(293, 37);
            labelTitle.TabIndex = 1;
            // 
            // labelDescription
            // 
            labelDescription.Dock = DockStyle.Top;
            labelDescription.Font = new Font("Cairo", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelDescription.Location = new Point(0, 37);
            labelDescription.Name = "labelDescription";
            labelDescription.Size = new Size(293, 37);
            labelDescription.TabIndex = 2;
            // 
            // timerToast
            // 
            timerToast.Enabled = true;
            timerToast.Interval = 2000;
            timerToast.Tick += timerToast_Tick;
            // 
            // ToastForm
            // 
            AutoScaleDimensions = new SizeF(11F, 37F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(368, 79);
            Controls.Add(labelDescription);
            Controls.Add(labelTitle);
            Controls.Add(pictureBox1);
            Font = new Font("Cairo", 12F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 6, 4, 6);
            Name = "ToastForm";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.Manual;
            Text = "Toast";
            TopMost = true;
            Activated += ToastForm_Activated;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private System.Windows.Forms.Timer timerToast;
        private Label labelTitle;
        private Label labelDescription;
    }
}