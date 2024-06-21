using Rafat.Code.Helper;
using Rafat.Code.Models;
using Rafat.Core;
using Rafat.Data.EF;
using Rafat.Gui.LoadingGui;
using System.Data;

namespace Rafat.Gui.SalaryRateGui
{
    public partial class AddSalaryRateForm : Form
    {
        private readonly IDataHelper<SalaryRate> dataHelperForSalary;
        private readonly IDataHelper<SystemRecords> dataHelperForSystemRecords;
        private readonly Main main;
        private int Id;
        private DateTime userCreatedDate;
        private readonly SalaryRateUserControl page;

        public AddSalaryRateForm(Main main, int id, SalaryRateUserControl page)
        {
            InitializeComponent();

            dataHelperForSalary = new SalaryRateEF();
            dataHelperForSystemRecords = new SystemRecordsEF();

            this.Owner = main;



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

        }

    




        private bool IsValid()
        {
            if (
                numericUpDownDegree.Value>=0
                )
            {
                return true;
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
                if (await Task.Run(() => dataHelperForSalary.IsCanConnect()))
                {
                    // Check Duplicated Item

                    int degree = (int)numericUpDownDegree.Value;

                    var result = await Task.Run(() => dataHelperForSalary
                    .GetDataByUser(LocalUser.UserId)
                    .Where(x => x.Id != Id)
                    .Where(x => x.Degree == degree)
                    .FirstOrDefault() ?? new SalaryRate());

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
            // Set Salary
            SalaryRate salaryRate = new SalaryRate
            {
                Degree= (int)numericUpDownDegree.Value,
                PromotionYear= (int)numericUpDownPromtion.Value,
                Salary= (float)Convert.ToDecimal( textBoxSalary.Text),
                BonusYearRate= (float)Convert.ToDecimal( textBoxBonusYear.Text),
                UsersId = LocalUser.UserId,
            };

            // Send Data to database
            var result = await Task.Run(() => dataHelperForSalary.Add(salaryRate));
            if (result == "1")
            {

                // Success
                SystemRecordHelper.Add("اضافة درجة",
                    $"تم اضافة درجة جديد تحمل الرقم التعريفي {salaryRate.Id}");
                page.LoadData();
                ToastHelper.ShowAddToast();
            }
            else
            {
                // Msg Box with result
                MessageBox.Show(result);
            }
        }

        private async void Edit()
        {

            // Set Salary
            SalaryRate salaryRate = new SalaryRate
            {
                Degree = (int)numericUpDownDegree.Value,
                PromotionYear = (int)numericUpDownPromtion.Value,
                Salary = (float)Convert.ToDecimal(textBoxSalary.Text),
                BonusYearRate = (float)Convert.ToDecimal(textBoxBonusYear.Text),
                UsersId = LocalUser.UserId,
                Id=Id
            };

            // Send Data to database
            var result = await Task.Run(() => dataHelperForSalary.Edit(salaryRate));
            if (result == "1")
            {

                // Success
                SystemRecordHelper.Add("تعديل درجة",
                    $"تم تعديل درجة حالية تحمل الرقم التعريفي {salaryRate.Id}");
                page.LoadData();
                ToastHelper.ShowEditToast();
                this.Close();
            }
            else
            {
                // Msg Box with result
                MessageBox.Show(result);
            }
        }



        private async void SetDataForEdit()
        {
            // Get Edit Salary Data
            var _salary = await Task.Run(() => dataHelperForSalary.Find(Id));
            if (_salary != null)
            {
                textBoxSalary.Text = _salary.Salary.ToString();
                textBoxBonusYear.Text = _salary.BonusYearRate.ToString();
                numericUpDownDegree.Value = _salary.Degree;
                numericUpDownPromtion.Value=_salary.PromotionYear; 
            }
        }

        private void textBoxSalary_MouseLeave(object sender, EventArgs e)
        {
            if (!float.TryParse(textBoxSalary.Text, out float salaryRate) || salaryRate < 0)
            {
                textBoxSalary.Text = "0";
                MsgHelper.ShowNumberValid();
            }
        }

        private void textBoxBonusYear_MouseLeave(object sender, EventArgs e)
        {
            if (!float.TryParse(textBoxBonusYear.Text, out float salaryRate) || salaryRate < 0)
            {
                textBoxBonusYear.Text = "0";
                MsgHelper.ShowNumberValid();
            }
        }
    }
}
