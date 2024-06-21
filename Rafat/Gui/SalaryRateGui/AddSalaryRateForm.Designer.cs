namespace Rafat.Gui.SalaryRateGui
{
    partial class AddSalaryRateForm
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
            numericUpDownPromtion = new NumericUpDown();
            numericUpDownDegree = new NumericUpDown();
            textBoxBonusYear = new TextBox();
            label6 = new Label();
            textBoxSalary = new TextBox();
            label4 = new Label();
            label7 = new Label();
            label5 = new Label();
            label3 = new Label();
            label2 = new Label();
            labelSBonusCurrency = new Label();
            labelSalryCurrency = new Label();
            label1 = new Label();
            buttonSave = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPromtion).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownDegree).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(numericUpDownPromtion);
            groupBox1.Controls.Add(numericUpDownDegree);
            groupBox1.Controls.Add(textBoxBonusYear);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(textBoxSalary);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(labelSBonusCurrency);
            groupBox1.Controls.Add(labelSalryCurrency);
            groupBox1.Controls.Add(label1);
            groupBox1.ForeColor = Color.Blue;
            groupBox1.Location = new Point(12, 26);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(363, 498);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "معلومات الدخول";
            // 
            // numericUpDownPromtion
            // 
            numericUpDownPromtion.Location = new Point(23, 424);
            numericUpDownPromtion.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownPromtion.Name = "numericUpDownPromtion";
            numericUpDownPromtion.Size = new Size(324, 45);
            numericUpDownPromtion.TabIndex = 3;
            numericUpDownPromtion.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // numericUpDownDegree
            // 
            numericUpDownDegree.Location = new Point(23, 93);
            numericUpDownDegree.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownDegree.Name = "numericUpDownDegree";
            numericUpDownDegree.Size = new Size(324, 45);
            numericUpDownDegree.TabIndex = 0;
            numericUpDownDegree.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // textBoxBonusYear
            // 
            textBoxBonusYear.Location = new Point(23, 320);
            textBoxBonusYear.Name = "textBoxBonusYear";
            textBoxBonusYear.Size = new Size(324, 45);
            textBoxBonusYear.TabIndex = 2;
            textBoxBonusYear.Text = "0";
            textBoxBonusYear.TextAlign = HorizontalAlignment.Center;
            textBoxBonusYear.MouseLeave += textBoxBonusYear_MouseLeave;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ForeColor = Color.Red;
            label6.Location = new Point(174, 253);
            label6.Name = "label6";
            label6.Size = new Size(25, 37);
            label6.TabIndex = 0;
            label6.Text = "*";
            // 
            // textBoxSalary
            // 
            textBoxSalary.Location = new Point(23, 205);
            textBoxSalary.Name = "textBoxSalary";
            textBoxSalary.Size = new Size(324, 45);
            textBoxSalary.TabIndex = 1;
            textBoxSalary.Text = "0";
            textBoxSalary.TextAlign = HorizontalAlignment.Center;
            textBoxSalary.MouseLeave += textBoxSalary_MouseLeave;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.Red;
            label4.Location = new Point(181, 152);
            label4.Name = "label4";
            label4.Size = new Size(25, 37);
            label4.TabIndex = 0;
            label4.Text = "*";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.ForeColor = Color.Black;
            label7.Location = new Point(174, 384);
            label7.Name = "label7";
            label7.Size = new Size(168, 37);
            label7.TabIndex = 0;
            label7.Text = "عدد سنوات الترفيع";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = Color.Black;
            label5.Location = new Point(198, 276);
            label5.Name = "label5";
            label5.Size = new Size(144, 37);
            label5.TabIndex = 0;
            label5.Text = "العلاوة السنوية";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.Black;
            label3.Location = new Point(211, 154);
            label3.Name = "label3";
            label3.Size = new Size(131, 37);
            label3.TabIndex = 0;
            label3.Text = "الراتب الاسمي";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.Red;
            label2.Location = new Point(195, 41);
            label2.Name = "label2";
            label2.Size = new Size(25, 37);
            label2.TabIndex = 0;
            label2.Text = "*";
            // 
            // labelSBonusCurrency
            // 
            labelSBonusCurrency.AutoSize = true;
            labelSBonusCurrency.Font = new Font("Cairo", 9F, FontStyle.Regular, GraphicsUnit.Point);
            labelSBonusCurrency.ForeColor = Color.Silver;
            labelSBonusCurrency.Location = new Point(59, 286);
            labelSBonusCurrency.Name = "labelSBonusCurrency";
            labelSBonusCurrency.Size = new Size(31, 29);
            labelSBonusCurrency.TabIndex = 0;
            labelSBonusCurrency.Text = "د.ع";
            // 
            // labelSalryCurrency
            // 
            labelSalryCurrency.AutoSize = true;
            labelSalryCurrency.Font = new Font("Cairo", 9F, FontStyle.Regular, GraphicsUnit.Point);
            labelSalryCurrency.ForeColor = Color.Silver;
            labelSalryCurrency.Location = new Point(59, 164);
            labelSalryCurrency.Name = "labelSalryCurrency";
            labelSalryCurrency.Size = new Size(31, 29);
            labelSalryCurrency.TabIndex = 0;
            labelSalryCurrency.Text = "د.ع";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.Black;
            label1.Location = new Point(275, 43);
            label1.Name = "label1";
            label1.Size = new Size(67, 37);
            label1.TabIndex = 0;
            label1.Text = "الدرجة";
            // 
            // buttonSave
            // 
            buttonSave.ForeColor = Color.Black;
            buttonSave.Image = Properties.Resources.icons8_save_32px;
            buttonSave.ImageAlign = ContentAlignment.MiddleLeft;
            buttonSave.Location = new Point(33, 556);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(319, 50);
            buttonSave.TabIndex = 4;
            buttonSave.Text = "حفظ";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // AddSalaryRateForm
            // 
            AutoScaleDimensions = new SizeF(11F, 37F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(388, 624);
            Controls.Add(groupBox1);
            Controls.Add(buttonSave);
            Font = new Font("Cairo", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4, 6, 4, 6);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddSalaryRateForm";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "اضافة / تعديل مستخدم";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPromtion).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownDegree).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private TextBox textBoxBonusYear;
        private Label label6;
        private TextBox textBoxSalary;
        private Label label4;
        private Label label5;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button buttonSave;
        private Label label7;
        private Label labelSBonusCurrency;
        private Label labelSalryCurrency;
        private NumericUpDown numericUpDownPromtion;
        private NumericUpDown numericUpDownDegree;
    }
}