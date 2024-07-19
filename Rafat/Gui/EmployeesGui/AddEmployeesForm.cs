using DocumentFormat.OpenXml.Drawing;
using Rafat.Code.Helper;
using Rafat.Code.Models;
using Rafat.Core;
using Rafat.Data.EF;
using Rafat.Gui.BookThanksGui;
using Rafat.Gui.EmployeesRecordGui;
using Rafat.Gui.LoadingGui;
using System.Data;
using System.Net.NetworkInformation;
using System.Security.Cryptography.Xml;

namespace Rafat.Gui.EmployeesGui
{
    public partial class AddEmployeesForm : Form
    {
        private readonly IDataHelper<Employees> dataHelperForEmployees;
        private readonly IDataHelper<EmployeesRecords> dataHelperForEmployeesRecords;
        private readonly IDataHelper<SalaryRate> dataHelperForSalaryRate;
        private readonly IDataHelper<SystemRecords> dataHelperForSystemRecords;
        private readonly Main main;
        private int Id;
        private DateTime userCreatedDate;
        private List<SalaryRate> salaryList;
        private readonly EmployeesUserControl page;

        public AddEmployeesForm(Main main, int id, EmployeesUserControl page)
        {
            InitializeComponent();

            dataHelperForEmployees = new EmployeesEF();
            dataHelperForEmployeesRecords = new EmployeesRecordsRecordsEF();
            dataHelperForSystemRecords = new SystemRecordsEF();
            dataHelperForSalaryRate = new SalaryRateEF();
            this.Owner = main;
            salaryList = new List<SalaryRate>();


            this.main = main;
            this.Id = id;
            this.page = page;

            if (Id > 0)
            {
                SetDataForEdit();
            }

            // Set Gui
            labelSBonusCurrency.Text = Properties.Settings.Default.Currency;
            labelSalryCurrency.Text = Properties.Settings.Default.Currency;
            SetRoleOfTabs();
            AutoFillData();
            GetSalryRates();
        }



        private async void AutoFillData()
        {
            List<string?> dataList = new List<string?>();

            LoadingForm.Instance(main).Show();
            if (await Task.Run(() => dataHelperForEmployees.IsCanConnect()))
            {
                // AutoFill Job Title
                // Get Data
                dataList = await Task.Run(() => dataHelperForEmployees
                .GetDataByUser(LocalUser.UserId)
                .Select(x => x.JobTitle).Distinct().ToList());
                // Fill ComboBox
                comboBoxJobTitle.DataSource = dataList;
                comboBoxJobTitle.AutoCompleteCustomSource = ConvertToAutoCompleteStringCollection(dataList);


                // AutoFill Job Title
                // Get Data
                dataList = await Task.Run(() => dataHelperForEmployees
                .GetDataByUser(LocalUser.UserId)
                .Select(x => x.EmpState).Distinct().ToList());
                // Fill ComboBox
                dataList.Add("علاوة");
                dataList.Add("ترفيع");
                dataList.Add("قيد علاوة");
                dataList.Add("قيد ترفيع");
                comboBoxEmpState.DataSource = dataList.Distinct().ToList();
                comboBoxEmpState.AutoCompleteCustomSource = ConvertToAutoCompleteStringCollection(dataList);

            }
            LoadingForm.Instance(main).Hide();
        }

        private async void GetSalryRates()
        {

            LoadingForm.Instance(main).Show();
            if (await Task.Run(() => dataHelperForEmployees.IsCanConnect()))
            {

                salaryList = await Task.Run(() => dataHelperForSalaryRate.GetDataByUser(LocalUser.UserId));
            }
            LoadingForm.Instance(main).Hide();
        }
        private void AutoComplete(List<SalaryRate> salaryRateslist)
        {

            // Get Current Data
            int currentDegree = (int)numericUpDownCurrentDegree.Value;
            int currentStage = (int)numericUpDownCurrentStage.Value;

            var currentRate = salaryRateslist.Where(x => x.Degree == currentDegree)
                .FirstOrDefault() ?? new SalaryRate();
            if (currentRate != null)
            {
                if (currentRate.PromotionYear == currentStage)
                {
                    // ترفيع
                    numericUpDownNextDegree.Value = currentDegree > 1 ? currentDegree - 1 : currentDegree;
                    numericUpDownNextStage.Value = 1;
                    comboBoxEmpState.SelectedItem = "ترفيع";
                }
                else
                {
                    // علاوة

                    numericUpDownNextDegree.Value = currentDegree;
                    numericUpDownNextStage.Value = currentStage + 1;
                    comboBoxEmpState.SelectedItem = "علاوة";
                }

                // Set Date

                dateTimePickerNextDate.Value = dateTimePickerCurrentDate.Value.AddYears(1);

                // Set Salary

                textBoxCurrentSalary.Text = GetSalary(currentStage, currentRate).ToString();
                textBoxNextSalary.Text = GetSalary((int)numericUpDownNextStage.Value, currentRate).ToString();
            }


        }

        private double GetSalary(int stage, SalaryRate salaryRate)
        {
            if (stage == 1)
            {
                return salaryRate.Salary;
            }
            else
            {
                return (--stage * salaryRate.BonusYearRate) + salaryRate.Salary;
            }
        }
        private AutoCompleteStringCollection ConvertToAutoCompleteStringCollection(List<string?> dataList)
        {
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
            collection.Clear();
            foreach (var item in dataList)
            {
                collection.Add(item);
            }

            return collection;
        }

        private bool IsValid()
        {
            if (
                textBoxFullName.Text.Length < 3 ||
                comboBoxJobTitle.Text.Length < 3 ||
                comboBoxEmpState.Text.Length < 2
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
                LoadingForm.Instance(main).Show();
                // Check Connection
                if (await Task.Run(() => dataHelperForEmployees.IsCanConnect()))
                {
                    // Check Duplicated Item

                    string FullName = textBoxFullName.Text;

                    var result = await Task.Run(() => dataHelperForEmployees
                    .GetDataByUser(LocalUser.UserId)
                    .Where(x => x.Id != Id)
                    .Where(x => x.Name == FullName)
                    .FirstOrDefault() ?? new Employees());

                    if (result.Id > 0)
                    {
                        // Msg
                        LoadingForm.Instance(main).Hide();
                        MsgHelper.ShowDuplicatedItems();
                    }
                    else
                    {
                        // Add
                        if (Id == 0)
                        {
                            Add();
                        }
                        else
                        {
                            // Edit
                            Edit();
                        }
                    }


                }
                else
                {
                    LoadingForm.Instance(main).Hide();
                    MsgHelper.ShowServerError();
                }

                LoadingForm.Instance(main).Hide();
            }

        }

        private async void Add()
        {
            // Set Employees
            Employees employees = new Employees
            {
                Name = textBoxFullName.Text,
                JobTitle = comboBoxJobTitle.Text,
                EmpState = comboBoxEmpState.Text,
                LastPromotionDate = dateTimePickerLastPromotion.Value.Date,

                CurrentDegree = (int)numericUpDownCurrentDegree.Value,
                CurrentStage = (int)numericUpDownCurrentStage.Value,
                CurrentSalary = (float)Convert.ToDouble(textBoxCurrentSalary.Text),
                CurrentDate = dateTimePickerCurrentDate.Value.Date,

                NextDegree = (int)numericUpDownNextDegree.Value,
                NextStage = (int)numericUpDownNextStage.Value,
                NextSalary = (float)Convert.ToDouble(textBoxNextSalary.Text),
                NextDate = dateTimePickerNextDate.Value.Date,

                Note = richTextBoxNote.Text,

                AddedDate = DateTime.Now,
                UpdateDate = DateTime.Now,

                UsersId = LocalUser.UserId,
            };

            // Send Data to database
            var result = await Task.Run(() => dataHelperForEmployees.Add(employees));
            if (result == "1")
            {

                // Success
                SystemRecordHelper.Add("اضافة موظف",
                    $"تم اضافة موظف جديد يحمل الرقم التعريفي {employees.Id}");
                page.LoadData();
                ToastHelper.ShowAddToast();
                Id = employees.Id;
                SetRoleOfTabs();
            }
            else
            {
                // Msg Box with result
                MessageBox.Show(result);
            }
        }

        private async void AddRecored()
        {
            // Set Employees
            EmployeesRecords employees = new EmployeesRecords
            {
                Name = textBoxFullName.Text,
                JobTitle = comboBoxJobTitle.Text,
                EmpState = comboBoxEmpState.Text,
                LastPromotionDate = dateTimePickerLastPromotion.Value.Date,

                CurrentDegree = (int)numericUpDownCurrentDegree.Value,
                CurrentStage = (int)numericUpDownCurrentStage.Value,
                CurrentSalary = (float)Convert.ToDouble(textBoxCurrentSalary.Text),
                CurrentDate = dateTimePickerCurrentDate.Value.Date,

                NextDegree = (int)numericUpDownNextDegree.Value,
                NextStage = (int)numericUpDownNextStage.Value,
                NextSalary = (float)Convert.ToDouble(textBoxNextSalary.Text),
                NextDate = dateTimePickerNextDate.Value.Date,

                Note = richTextBoxNote.Text,

                AddedDate = DateTime.Now,
                UpdateDate = DateTime.Now,

                UsersId = LocalUser.UserId,
                EmployeesId = Id
            };

            // Send Data to database
            var result = await Task.Run(() => dataHelperForEmployeesRecords.Add(employees));
            if (result == "1")
            {

                // Success
                SystemRecordHelper.Add("اضافة سجل موظف",
                    $"تم اضافة سجل جديد يحمل الرقم التعريفي {employees.Id}");
                page.LoadData();
                ToastHelper.ShowAddToast();
                Id = employees.Id;
                SetRoleOfTabs();
            }
            else
            {
                // Msg Box with result
                MessageBox.Show(result);
            }
        }
        private async void Edit()
        {

            // Set Employees
            Employees employees = new Employees
            {
                Name = textBoxFullName.Text,
                JobTitle = comboBoxJobTitle.Text,
                EmpState = comboBoxEmpState.Text,
                LastPromotionDate = dateTimePickerLastPromotion.Value.Date,

                CurrentDegree = (int)numericUpDownCurrentDegree.Value,
                CurrentStage = (int)numericUpDownCurrentStage.Value,
                CurrentSalary = (float)Convert.ToDouble(textBoxCurrentSalary.Text),
                CurrentDate = dateTimePickerCurrentDate.Value.Date,

                NextDegree = (int)numericUpDownNextDegree.Value,
                NextStage = (int)numericUpDownNextStage.Value,
                NextSalary = (float)Convert.ToDouble(textBoxNextSalary.Text),
                NextDate = dateTimePickerNextDate.Value.Date,

                Note = richTextBoxNote.Text,

                AddedDate = DateTime.Now,
                UpdateDate = DateTime.Now,



                UsersId = LocalUser.UserId,
                Id = Id
            };

            // Send Data to database
            var result = await Task.Run(() => dataHelperForEmployees.Edit(employees));
            if (result == "1")
            {

                // Success
                SystemRecordHelper.Add("تعديل موظف",
                    $"تم تعديل موظف حالة يحمل الرقم التعريفي {employees.Id}");
                page.LoadData();
                ToastHelper.ShowEditToast();
            }
            else
            {
                // Msg Box with result
                MessageBox.Show(result);
            }
        }



        private async void SetDataForEdit()
        {
            // Get Edit Employees Data
            var _employees = await Task.Run(() => dataHelperForEmployees.Find(Id));
            if (_employees.Id > 0)
            {
                textBoxFullName.Text = _employees.Name;
                comboBoxJobTitle.Text = _employees.JobTitle;
                comboBoxEmpState.Text = _employees.EmpState;
                dateTimePickerLastPromotion.Value = _employees.LastPromotionDate;

                numericUpDownCurrentDegree.Value = _employees.CurrentDegree;
                numericUpDownCurrentStage.Value = _employees.CurrentStage;
                textBoxCurrentSalary.Text = _employees.CurrentSalary.ToString();
                dateTimePickerCurrentDate.Value = _employees.CurrentDate;

                numericUpDownNextDegree.Value = _employees.NextDegree;
                numericUpDownNextStage.Value = _employees.NextStage;
                textBoxNextSalary.Text = _employees.NextSalary.ToString();
                dateTimePickerNextDate.Value = _employees.NextDate;

                richTextBoxNote.Text = _employees.Note;

            }
        }

        private void textBoxCurrentSalary_MouseLeave(object sender, EventArgs e)
        {
            if (!float.TryParse(textBoxCurrentSalary.Text, out float value) || value < 0)
            {
                textBoxCurrentSalary.Text = "0";
                MsgHelper.ShowNumberValid();
            }
        }

        private void textBoxNextSalary_MouseLeave(object sender, EventArgs e)
        {
            if (!float.TryParse(textBoxNextSalary.Text, out float value) || value < 0)
            {
                textBoxNextSalary.Text = "0";
                MsgHelper.ShowNumberValid();
            }
        }

        private async void SetRoleOfTabs()
        {
            if (Id == 0)
            {
                buttonAutoCal.Enabled = false;
                buttonNew.Enabled = false;
                buttonUpgrade.Enabled = false;

                foreach (TabPage tab in tabControl1.TabPages)
                {
                    if (tab.Name != "tabPage1")
                    {
                        tab.Enabled = false;
                    }
                }


            }
            else
            {
                buttonAutoCal.Enabled = true;
                buttonNew.Enabled = true;
                buttonUpgrade.Enabled = true;

                foreach (TabPage tab in tabControl1.TabPages)
                {
                    if (tab.Name != "tabPage1")
                    {
                        tab.Enabled = true;
                    }
                }

                AddUserControlEffetValueGui();
            }
        }

        private async void AddUserControlEffetValueGui()
        {
            // Book Thanks
            tabControl1.TabPages[1].Controls.Clear();
            Employees employees = await Task.Run(() => dataHelperForEmployees.Find(Id));
            BookThankUserControl bookThankUserControl = new BookThankUserControl(employees);
            bookThankUserControl.Dock = DockStyle.Fill;
            tabControl1.TabPages[1].Controls.Add(bookThankUserControl);

            // Bonus Records
            tabControl1.TabPages[4].Controls.Clear();
            EmployeesRecordUserControl employeesRecordUserControl = new EmployeesRecordUserControl(employees);
            employeesRecordUserControl.Dock = DockStyle.Fill;
            tabControl1.TabPages[4].Controls.Add(employeesRecordUserControl);
        }
        private void numericUpDownCurrentDegree_ValueChanged(object sender, EventArgs e)
        {
            AutoComplete(salaryList);
        }

        private void numericUpDownCurrentStage_ValueChanged(object sender, EventArgs e)
        {
            AutoComplete(salaryList);
        }

        private void numericUpDownNextDegree_ValueChanged(object sender, EventArgs e)
        {
            AutoComplete(salaryList);
        }

        private void numericUpDownNextStage_ValueChanged(object sender, EventArgs e)
        {
            AutoComplete(salaryList);
        }

        private void buttonAutoCal_Click(object sender, EventArgs e)
        {
            SetDataForEdit();
            AutoComplete(salaryList);
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            this.Close();
            page.buttonAdd_Click(sender, e);
        }

        private void AddEmployeesForm_Load(object sender, EventArgs e)
        {

        }

        private void buttonUpgrade_Click(object sender, EventArgs e)
        {

            var reuslt = MessageBox.Show("هل انت متأكد من هذا الاجراء", "اجراء ترقية", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (reuslt == DialogResult.Yes)
            {
                // Save Record
                AddRecored();

                // Update Data
                UpdateBeforeSaveRecord();

                // Save Data
                Edit();
            }

        }

        private void UpdateBeforeSaveRecord()
        {
            numericUpDownCurrentDegree.Value = numericUpDownNextDegree.Value;
            numericUpDownCurrentStage.Value = numericUpDownNextStage.Value;
            textBoxCurrentSalary.Text = textBoxNextSalary.Text;
            dateTimePickerCurrentDate.Value = dateTimePickerNextDate.Value;
            richTextBoxNote.Text = string.Empty;
            AutoComplete(salaryList);
        }
    }
}
