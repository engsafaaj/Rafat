﻿using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.VisualBasic.ApplicationServices;
using Rafat.Code.Helper;
using Rafat.Code.Models;
using Rafat.Core;
using Rafat.Data.EF;
using Rafat.Gui.LoadingGui;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rafat.Gui.UsersGui
{
    public partial class UsersUserControl : UserControl
    {
        private static UsersUserControl? usersUserControl;
        private AddUserForm addUserForm;
        private static Main _main;
        private IDataHelper<Core.Users> dataHelper;
        private List<Core.Users> data;
        private List<int> IdDeleteList;
        public UsersUserControl()
        {
            InitializeComponent();
            dataHelper = new UsersEF();
            data = new List<Core.Users>();
            IdDeleteList = new List<int>();
            LoadData();
        }

        public static UsersUserControl Instance(Main main)
        {
            _main = main;
            return usersUserControl ?? (usersUserControl = new UsersUserControl());
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (addUserForm == null || addUserForm.IsDisposed)
            {
                addUserForm = new AddUserForm(_main, 0, this);
                addUserForm.Show();
            }
            else
            {
                addUserForm.Focus();
            }


        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            Edit();

        }

        private async void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                // Check Data if not empty
                if (!dgvHelper.IsEmpty(dataGridView1))
                {

                    // Get Id
                    SetIdDeleteList();
                    if (IdDeleteList.Count > 0)
                    {
                        if (MsgHelper.ShowDeleteDialog())
                        {
                            LoadingForm.Instance(_main).Show();
                            if (await Task.Run(() => dataHelper.IsCanConnect()))
                            {
                                // Loop into Id List
                                foreach (int Id in IdDeleteList)
                                {
                                    await Task.Run(() => dataHelper.Delete(Id));
                                    SystemRecordHelper.Add("حذف مستخدم",
                   $"تم حذف مستخدم حالي يحمل الرقم التعريفي {Id.ToString()}");
                                }
                                ToastHelper.ShowDeleteToast();
                                LoadData();
                            }
                            else
                            {
                                LoadingForm.Instance(_main).Hide();
                                MsgHelper.ShowServerError();
                            }

                            LoadingForm.Instance(_main).Hide();
                        }
                    }
                    else
                    {
                        MsgHelper.ShowDeleteSelectRow();
                    }
                }

                else
                {
                    LoadingForm.Instance(_main).Hide();
                    MsgHelper.ShowEmptyDataGridView();
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }

        private void SetIdDeleteList()
        {
            IdDeleteList.Clear();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Selected)
                {
                    IdDeleteList.Add(Convert.ToInt32(row.Cells[0].Value));
                }

            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            Search();
        }


        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private async void buttonExport_Click(object sender, EventArgs e)
        {
            // Show Loading
            LoadingForm.Instance(_main).Show();
            if (await Task.Run(() => dataHelper.IsCanConnect()))
            {
                // Start Load Data
                // Check if Admin or not
                if (LocalUser.Role == "Admin")
                {
                    // Get All Data
                    data = await Task.Run(() => dataHelper.GetAllData());
                }
                else
                {
                    // Get Data By User
                    data = await Task.Run(() => dataHelper.GetDataByUser(LocalUser.UserId));
                }
                LoadingForm.Instance(_main).Hide();

                ExportExcel(data);
            }
            else
            {
                // No Connection
                LoadingForm.Instance(_main).Hide();
                ShowServerErrorState();
                MsgHelper.ShowServerError();
            }

            // Hide Loading
            LoadingForm.Instance(_main).Hide();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Edit();
        }

        // Methods
        public async void LoadData()
        {
            // Show Loading
            LoadingForm.Instance(_main).Show();
            if (await Task.Run(() => dataHelper.IsCanConnect()))
            {
                // Start Load Data
                // Check if Admin or not
                if (LocalUser.Role == "Admin")
                {
                    // Get All Data
                    data = await Task.Run(() => dataHelper.GetAllData());
                }
                else
                {
                    // Get Data By User
                    data = await Task.Run(() => dataHelper.GetDataByUser(LocalUser.UserId));
                }
                labelNofOfItmes.Text = data.Count.ToString();
                // Fill DataGridView
                dataGridView1.DataSource = data.Take(Properties.Settings.Default.NoOfDataGirdViewItems).ToList();
                if (data.Count <= Properties.Settings.Default.NoOfDataGirdViewItems)
                {
                    comboBoxNoOfPages.Items.Clear();
                    comboBoxNoOfPages.Items.Add(0);

                }
                else
                {
                    // Get and Add No of pages
                    double value = Convert.ToDouble(data.Count) / Convert.ToDouble(Properties.Settings.Default.NoOfDataGirdViewItems);
                    int noOfPage = Convert.ToInt32(Math.Round(value, MidpointRounding.AwayFromZero));
                    comboBoxNoOfPages.Items.Clear();
                    for (int i = 0; i <= noOfPage; i++)
                    {
                        comboBoxNoOfPages.Items.Add(i);
                    }
                }


                //
                // Set Columns Title
                SetColumns();

                // Show Empty Data
                ShowEmptyDataState();

                // Clear Data
                data.Clear();
                LoadingForm.Instance(_main).Hide();
            }
            else
            {
                // No Connection
                LoadingForm.Instance(_main).Hide();
                ShowServerErrorState();
                MsgHelper.ShowServerError();
            }

            // Hide Loading
            LoadingForm.Instance(_main).Hide();


        }

        public async void Search()
        {
            // Show Loading
            LoadingForm.Instance(_main).Show();
            if (await Task.Run(() => dataHelper.IsCanConnect()))
            {
                // Start Load Data
                string searchItem = textBoxSearch.Text;
                // Check if Admin or not
                if (LocalUser.Role == "Admin")
                {
                    // Get All Data
                    data = await Task.Run(() => dataHelper.SearchAll(searchItem));
                }
                else
                {
                    // Get Data By User
                    data = await Task.Run(() => dataHelper.SearchByUser(LocalUser.UserId, searchItem));
                }

                // Fill DataGridView
                dataGridView1.DataSource = data.ToList();


                // Set Columns Title
                //SetColumns();

                // Show Empty Data
                ShowEmptyDataState();

                // Clear Data
                data.Clear();
                LoadingForm.Instance(_main).Hide();
            }
            else
            {
                // No Connection
                LoadingForm.Instance(_main).Hide();
                ShowServerErrorState();
                MsgHelper.ShowServerError();
            }

            // Hide Loading
            LoadingForm.Instance(_main).Hide();


        }

        private void ShowEmptyDataState()
        {
            // Set Title and Descripton
            labelStateTitle.Text = Properties.Resources.EmptyDataStateTitle;
            labelStateDescription.Text = Properties.Resources.EmptyDataStateDescription;
            panelState.Visible = dgvHelper.IsEmpty(dataGridView1);
        }

        private void ShowServerErrorState()
        {
            // Set Title and Descripton
            labelStateTitle.Text = Properties.Resources.ServerErrorTitle;
            labelStateDescription.Text = Properties.Resources.ServerErrorDescription;
            panelState.Visible = true;
        }

        private void SetColumns()
        {
            dataGridView1.Columns[0].HeaderCell.Value = "المعرف";
            dataGridView1.Columns[1].HeaderCell.Value = "الاسم الكامل";
            dataGridView1.Columns[2].HeaderCell.Value = "اسم المستخدم";
            dataGridView1.Columns[3].HeaderCell.Value = "كلمة السر";
            dataGridView1.Columns[4].HeaderCell.Value = "الصلاحية";
            dataGridView1.Columns[5].HeaderCell.Value = "هل المستخدم ثانوي";
            dataGridView1.Columns[6].HeaderCell.Value = "المعرف الاساس";
            dataGridView1.Columns[7].HeaderCell.Value = "رقم الهاتف";
            dataGridView1.Columns[8].HeaderCell.Value = "البريد الالكتروني";
            dataGridView1.Columns[9].HeaderCell.Value = "السكن";
            dataGridView1.Columns[10].HeaderCell.Value = "تاريخ الانشاء";
            dataGridView1.Columns[11].HeaderCell.Value = "تاريخ التعديل";

            // Visible of Columns
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible = false;


        }

        private void Edit()
        {
            // Check Data if not empty
            if (!dgvHelper.IsEmpty(dataGridView1))
            {
                // Get Id
                int Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                if (addUserForm == null || addUserForm.IsDisposed)
                {
                    addUserForm = new AddUserForm(_main, Id, this);
                    addUserForm.Show();
                }
                else
                {
                    addUserForm.Focus();
                }
            }
            else
            {
                MsgHelper.ShowEmptyDataGridView();
            }
        }

        private void textBoxSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Search();
            }
        }

        private async void comboBoxNoOfPages_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // Show Loading
                LoadingForm.Instance(_main).Show();
                if (await Task.Run(() => dataHelper.IsCanConnect()))
                {
                    // Start Load Data
                    // Check if Admin or not
                    if (LocalUser.Role == "Admin")
                    {
                        // Get All Data
                        data = await Task.Run(() => dataHelper.GetAllData());
                    }
                    else
                    {
                        // Get Data By User
                        data = await Task.Run(() => dataHelper.GetDataByUser(LocalUser.UserId));
                    }

                    // Get and Set Param
                    var idlist = data.Select(x => x.Id).ToArray();
                    int index = comboBoxNoOfPages.SelectedIndex;
                    int noOfItemIndex = index * Properties.Settings.Default.NoOfDataGirdViewItems;

                    // Fill DataGridView
                    dataGridView1.DataSource = data.Where(x => x.Id <= idlist[noOfItemIndex])
                        .Take(Properties.Settings.Default.NoOfDataGirdViewItems).ToList();

                    // Show Empty Data
                    ShowEmptyDataState();

                    // Clear Data
                    data.Clear();
                    LoadingForm.Instance(_main).Hide();
                }
                else
                {
                    // No Connection
                    LoadingForm.Instance(_main).Hide();
                    ShowServerErrorState();
                    MsgHelper.ShowServerError();
                }

                // Hide Loading
                LoadingForm.Instance(_main).Hide();

            }
            catch { }

        }

        private void buttonPrev_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxNoOfPages.SelectedIndex != 0)
                {
                    comboBoxNoOfPages.SelectedIndex = comboBoxNoOfPages.SelectedIndex - 1;
                }
            }
            catch { }
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            try
            {

                comboBoxNoOfPages.SelectedIndex = comboBoxNoOfPages.SelectedIndex + 1;

            }
            catch { }
        }

        private void buttonExportDataGridView_Click(object sender, EventArgs e)
        {
            // Get Data
            var data = (List<Core.Users>)dataGridView1.DataSource;
            ExportExcel(data);

        }

        private void ExportExcel(List<Core.Users> data)
        {
            // Define Data Table
            DataTable dataTable = new DataTable();

            // Convert to Data Table
            using (var reader = FastMember.ObjectReader.Create(data))
            {
                dataTable.Load(reader);
            }

            // Re-Set DataTable
            dataTable = arrangedDataTable(dataTable);

            // Send to export
            ExcelHelper.Export(dataTable, "Users");
        }
        private DataTable arrangedDataTable(DataTable dataTable)
        {
            dataTable.Columns["Id"].SetOrdinal(0);
            dataTable.Columns["Id"].ColumnName = "ت";

            dataTable.Columns["FullName"].SetOrdinal(1);
            dataTable.Columns["FullName"].ColumnName = "الاسم الكامل";


            dataTable.Columns["UserName"].SetOrdinal(2);
            dataTable.Columns["UserName"].ColumnName = "اسم المستخدم";


            dataTable.Columns["Password"].SetOrdinal(3);
            dataTable.Columns["Password"].ColumnName = "كلمة السر";

            dataTable.Columns["Role"].SetOrdinal(4);
            dataTable.Columns["Role"].ColumnName = "الصلاحية";

            dataTable.Columns["IsSecondaryUser"].SetOrdinal(5);
            dataTable.Columns["IsSecondaryUser"].ColumnName = "هل المستخدم ثانوي";

            dataTable.Columns["UserId"].SetOrdinal(6);
            dataTable.Columns["UserId"].ColumnName = "معرف المستخدم";

            dataTable.Columns["Phone"].SetOrdinal(7);
            dataTable.Columns["Phone"].ColumnName = "رقم الهاتف ";


            dataTable.Columns["Email"].SetOrdinal(8);
            dataTable.Columns["Email"].ColumnName = "البريد الالكتروني  ";


            dataTable.Columns["Address"].SetOrdinal(9);
            dataTable.Columns["Address"].ColumnName = "العنوان  ";


            dataTable.Columns["CreatedDate"].SetOrdinal(10);
            dataTable.Columns["CreatedDate"].ColumnName = "تاريخ الانشاء  ";


            dataTable.Columns["EditedDate"].SetOrdinal(11);
            dataTable.Columns["EditedDate"].ColumnName = "تاريخ التعديل  ";


            // Removed columns
            dataTable.Columns.Remove("Roles");
            dataTable.Columns.Remove("SystemRecords");

            return dataTable;
        }
    }
}
