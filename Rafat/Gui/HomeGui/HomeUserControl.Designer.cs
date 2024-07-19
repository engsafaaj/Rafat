namespace Rafat.Gui.HomeGui
{
    partial class HomeUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            labelWelcome = new Label();
            labelCompnayName = new Label();
            SuspendLayout();
            // 
            // labelWelcome
            // 
            labelWelcome.Anchor = AnchorStyles.None;
            labelWelcome.Location = new Point(372, 321);
            labelWelcome.Name = "labelWelcome";
            labelWelcome.Size = new Size(363, 37);
            labelWelcome.TabIndex = 0;
            labelWelcome.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelCompnayName
            // 
            labelCompnayName.Anchor = AnchorStyles.None;
            labelCompnayName.Font = new Font("Cairo", 24F, FontStyle.Regular, GraphicsUnit.Point);
            labelCompnayName.Location = new Point(301, 246);
            labelCompnayName.Name = "labelCompnayName";
            labelCompnayName.Size = new Size(504, 75);
            labelCompnayName.TabIndex = 0;
            labelCompnayName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // HomeUserControl
            // 
            AutoScaleDimensions = new SizeF(11F, 37F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(labelCompnayName);
            Controls.Add(labelWelcome);
            Font = new Font("Cairo", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4, 6, 4, 6);
            Name = "HomeUserControl";
            Size = new Size(1062, 606);
            ResumeLayout(false);
        }

        #endregion

        private Label labelWelcome;
        private Label labelCompnayName;
    }
}
