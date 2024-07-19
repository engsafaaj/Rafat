namespace Rafat.Gui.BookThanksGui
{
    partial class AddBookThankForm
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
            groupBox1 = new GroupBox();
            numericUpDownEffect = new NumericUpDown();
            label6 = new Label();
            textBoxRef = new TextBox();
            label4 = new Label();
            label7 = new Label();
            label5 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            buttonSave = new Button();
            richTextBoxNote = new RichTextBox();
            dateTimePickerdate = new DateTimePicker();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownEffect).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dateTimePickerdate);
            groupBox1.Controls.Add(richTextBoxNote);
            groupBox1.Controls.Add(numericUpDownEffect);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(textBoxRef);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.ForeColor = Color.Blue;
            groupBox1.Location = new Point(12, 26);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(363, 569);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "معلومات كتاب الشكر";
            // 
            // numericUpDownEffect
            // 
            numericUpDownEffect.Location = new Point(23, 93);
            numericUpDownEffect.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownEffect.Name = "numericUpDownEffect";
            numericUpDownEffect.Size = new Size(324, 45);
            numericUpDownEffect.TabIndex = 0;
            numericUpDownEffect.Value = new decimal(new int[] { 30, 0, 0, 0 });
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ForeColor = Color.Red;
            label6.Location = new Point(246, 274);
            label6.Name = "label6";
            label6.Size = new Size(25, 37);
            label6.TabIndex = 0;
            label6.Text = "*";
            // 
            // textBoxRef
            // 
            textBoxRef.Location = new Point(23, 205);
            textBoxRef.Name = "textBoxRef";
            textBoxRef.Size = new Size(324, 45);
            textBoxRef.TabIndex = 1;
            textBoxRef.TextAlign = HorizontalAlignment.Center;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.Red;
            label4.Location = new Point(253, 165);
            label4.Name = "label4";
            label4.Size = new Size(25, 37);
            label4.TabIndex = 0;
            label4.Text = "*";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.ForeColor = Color.Black;
            label7.Location = new Point(253, 382);
            label7.Name = "label7";
            label7.Size = new Size(89, 37);
            label7.TabIndex = 0;
            label7.Text = "التفاصيل";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = Color.Black;
            label5.Location = new Point(277, 285);
            label5.Name = "label5";
            label5.Size = new Size(65, 37);
            label5.TabIndex = 0;
            label5.Text = "التاريخ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.Black;
            label3.Location = new Point(284, 165);
            label3.Name = "label3";
            label3.Size = new Size(62, 37);
            label3.TabIndex = 0;
            label3.Text = "العدد";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.Red;
            label2.Location = new Point(253, 41);
            label2.Name = "label2";
            label2.Size = new Size(25, 37);
            label2.TabIndex = 0;
            label2.Text = "*";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.Black;
            label1.Location = new Point(285, 41);
            label1.Name = "label1";
            label1.Size = new Size(57, 37);
            label1.TabIndex = 0;
            label1.Text = "التأثير";
            // 
            // buttonSave
            // 
            buttonSave.ForeColor = Color.Black;
            buttonSave.Image = Properties.Resources.icons8_save_32px;
            buttonSave.ImageAlign = ContentAlignment.MiddleLeft;
            buttonSave.Location = new Point(33, 593);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(319, 50);
            buttonSave.TabIndex = 4;
            buttonSave.Text = "حفظ";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // richTextBoxNote
            // 
            richTextBoxNote.Location = new Point(6, 422);
            richTextBoxNote.Name = "richTextBoxNote";
            richTextBoxNote.Size = new Size(336, 125);
            richTextBoxNote.TabIndex = 3;
            richTextBoxNote.Text = "";
            // 
            // dateTimePickerdate
            // 
            dateTimePickerdate.Anchor = AnchorStyles.Left;
            dateTimePickerdate.Format = DateTimePickerFormat.Short;
            dateTimePickerdate.Location = new Point(23, 325);
            dateTimePickerdate.Name = "dateTimePickerdate";
            dateTimePickerdate.Size = new Size(319, 45);
            dateTimePickerdate.TabIndex = 7;
            // 
            // AddBookThankForm
            // 
            AutoScaleDimensions = new SizeF(11F, 37F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(388, 655);
            Controls.Add(groupBox1);
            Controls.Add(buttonSave);
            Font = new Font("Cairo", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4, 6, 4, 6);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddBookThankForm";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "اضافة كتاب شكر";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownEffect).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label6;
        private TextBox textBoxRef;
        private Label label4;
        private Label label5;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button buttonSave;
        private Label label7;
        private NumericUpDown numericUpDownEffect;
        private RichTextBox richTextBoxNote;
        private DateTimePicker dateTimePickerdate;
    }
}