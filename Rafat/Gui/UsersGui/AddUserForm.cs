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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rafat.Gui.UsersGui
{
    public partial class AddUserForm : Form
    {
        private readonly IDataHelper<Users> dataHelperForUser;
        private readonly IDataHelper<Roles> dataHelperForRoles;
        private readonly IDataHelper<SystemRecords> dataHelperForSystemRecords;
        private readonly Main main;
        private int Id;
        private DateTime userCreatedDate;
        private readonly UsersUserControl page;

        public AddUserForm(Main main, int id, UsersUserControl page)
        {
            InitializeComponent();

            dataHelperForUser = new UsersEF();
            dataHelperForRoles = new RolesEF();
            dataHelperForSystemRecords = new SystemRecordsEF();

            this.Owner = main;




            AddSecondaryUser();
            SetRoles();
            this.main = main;
            this.Id = id;
            this.page = page;

            if (Id > 0)
            {
                SetDataForEdit();
            }
        }

        private void checkBoxSecondayUser_CheckedChanged(object sender, EventArgs e)
        {
            if (Code.Models.LocalUser.Role == "Admin")
            {
                comboBoxUserId.Enabled = checkBoxSecondayUser.Checked;
            }
            else
            {
                comboBoxUserId.Enabled = false;
            }
        }

        private void SetRoles()
        {
            if (Code.Models.LocalUser.Role == "Admin")
            {
                // Admin
                // Add Roles
                comboBoxRole.Items.Clear();
                comboBoxRole.Items.Add("Admin");
                comboBoxRole.Items.Add("User");
                comboBoxRole.Items.Add("Read");

                comboBoxUserId.Enabled = false;
                checkBoxSecondayUser.Enabled = true;
                comboBoxRole.SelectedIndex = 1;
            }
            else
            {
                // User
                // Add Roles
                comboBoxRole.Items.Clear();
                comboBoxRole.Items.Add("User");
                comboBoxRole.Items.Add("Read");

                checkBoxSecondayUser.Enabled = false;
                comboBoxUserId.Enabled = false;
                checkBoxSecondayUser.Checked = true;
                comboBoxRole.SelectedIndex = 0;
            }


        }

        private void AddSecondaryUser()
        {
            comboBoxUserId.Items.Clear();
            comboBoxUserId.Items.Add(Code.Models.LocalUser.UserId);
            comboBoxUserId.SelectedIndex = 0;
        }

        private void comboBoxRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetRolesByMainRole();
        }

        private void SetRolesByMainRole()
        {
            if (comboBoxRole.SelectedItem.ToString() == "Admin")
            {
                checkBoxAbout.Checked = true;
                checkBoxAdd.Checked = true;
                checkBoxDelete.Checked = true;
                checkBoxEdit.Checked = true;
                checkBoxEmployees.Checked = true;
                checkBoxExport.Checked = true;
                checkBoxHelp.Checked = true;
                checkBoxHome.Checked = true;
                checkBoxHomeSearch.Checked = true;
                checkBoxPrint.Checked = true;
                checkBoxReport.Checked = true;
                checkBoxRetirmnet.Checked = true;
                checkBoxSalary.Checked = true;
                checkBoxSearch.Checked = true;
                checkBoxSettings.Checked = true;
                checkBoxSystemRecords.Checked = true;
                checkBoxUsers.Checked = true;
            }
            else if (comboBoxRole.SelectedItem.ToString() == "User")
            {
                checkBoxAbout.Checked = true;
                checkBoxAdd.Checked = true;
                checkBoxDelete.Checked = true;
                checkBoxEdit.Checked = true;
                checkBoxEmployees.Checked = true;
                checkBoxExport.Checked = true;
                checkBoxHelp.Checked = true;
                checkBoxHome.Checked = true;
                checkBoxHomeSearch.Checked = true;
                checkBoxPrint.Checked = true;
                checkBoxReport.Checked = true;
                checkBoxRetirmnet.Checked = true;
                checkBoxSalary.Checked = true;
                checkBoxSearch.Checked = true;
                checkBoxSettings.Checked = true;
                checkBoxSystemRecords.Checked = true;
                checkBoxUsers.Checked = true;
            }
            else // Read
            {
                checkBoxAbout.Checked = true;
                checkBoxAdd.Checked = false;
                checkBoxDelete.Checked = false;
                checkBoxEdit.Checked = false;
                checkBoxEmployees.Checked = true;
                checkBoxExport.Checked = true;
                checkBoxHelp.Checked = true;
                checkBoxHome.Checked = true;
                checkBoxHomeSearch.Checked = true;
                checkBoxPrint.Checked = true;
                checkBoxReport.Checked = true;
                checkBoxRetirmnet.Checked = true;
                checkBoxSalary.Checked = true;
                checkBoxSearch.Checked = true;
                checkBoxSettings.Checked = true;
                checkBoxSystemRecords.Checked = true;
                checkBoxUsers.Checked = false;
            }
        }

        private bool IsValid()
        {
            if (
                textBoxFullName.Text.Length < 3 ||
                textBoxPassword.Text.Length < 3 ||
                textBoxUserName.Text.Length < 3
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
                if (await Task.Run(() => dataHelperForUser.IsCanConnect()))
                {
                    // Check Duplicated Item

                    string fullName = textBoxFullName.Text;
                    string userName = textBoxUserName.Text;

                    var result = await Task.Run(() => dataHelperForUser
                    .GetAllData()
                    .Where(x => x.Id != Id)
                    .Where(x => x.FullName == fullName || x.UserId == userName)
                    .FirstOrDefault() ?? new Users());

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
            // Set User
            Users users = new Users
            {
                FullName = textBoxFullName.Text,
                Password = textBoxPassword.Text,
                UserName = textBoxUserName.Text,
                Email = textBoxEmail.Text,
                Address = textBoxAddress.Text,
                CreatedDate = DateTime.Now.Date,
                EditedDate = DateTime.Now.Date,
                Role = comboBoxRole.SelectedItem.ToString() ?? "User",
                Phone = textBoxPhone.Text,
                IsSecondaryUser = checkBoxSecondayUser.Checked,
                UserId = SetUserId()
            };

            // Send Data to database
            var result = await Task.Run(() => dataHelperForUser.Add(users));
            if (result == "1")
            {
                // Add User Roles
                foreach (var item in flowLayoutPanelRoles.Controls)
                {
                    CheckBox checkBox = (CheckBox)item;
                    // Set
                    Roles roles = new Roles
                    {
                        Key = checkBox.Name,
                        Value = checkBox.Checked,
                        UsersId = users.Id

                    };

                    // Send
                    await Task.Run(() => dataHelperForRoles.Add(roles));
                }

                // Success
                SystemRecordHelper.Add("اضافة مستخدم",
                    $"تم اضافة مستخدم جديد يحمل الرقم التعريفي {users.Id}");
                page.LoadData();
                ToastHelper.ShowAddToast();
                this.Close();
            }
            else
            {
                // Msg Box with result
                MessageBox.Show(result);
            }
        }

        private async void Edit()
        {
            
            // Set User
            Users users = new Users
            {
                Id=Id,
                FullName = textBoxFullName.Text,
                Password = textBoxPassword.Text,
                UserName = textBoxUserName.Text,
                Email = textBoxEmail.Text,
                Address = textBoxAddress.Text,
                CreatedDate = userCreatedDate,
                EditedDate = DateTime.Now.Date,
                Role = comboBoxRole.SelectedItem.ToString() ?? "User",
                Phone = textBoxPhone.Text,
                IsSecondaryUser = checkBoxSecondayUser.Checked,
                UserId = SetUserId()
            
            };

            // Send Data to database
            var result = await Task.Run(() => dataHelperForUser.Edit(users));
            if (result == "1")
            {
                // Remove Old User Roles
                var oldroles=await Task.Run(()=>dataHelperForRoles.
                GetAllData().Where(x=>x.UsersId==Id).ToList()??new List<Roles>());
                foreach (var role in oldroles)
                {
                    await Task.Run(() => dataHelperForRoles.Delete(role.Id));
                }

                // Add User Roles
                foreach (var item in flowLayoutPanelRoles.Controls)
                {
                    CheckBox checkBox = (CheckBox)item;
                    // Set
                    Roles roles = new Roles
                    {
                        Key = checkBox.Name,
                        Value = checkBox.Checked,
                        UsersId = users.Id

                    };

                    // Send
                    await Task.Run(() => dataHelperForRoles.Add(roles));
                }

                // Success
                // Success
                SystemRecordHelper.Add("تعديل مستخدم",
                    $"تم تعديل مستخدم حالي يحمل الرقم التعريفي {users.Id}");
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


        private string SetUserId()
        {
            if (checkBoxSecondayUser.Checked)
            {
                return comboBoxUserId.SelectedItem.ToString() ?? LocalUser.UserId;
            }
            else
            {
                return Guid.NewGuid().ToString();
            }
        }

        private async void SetDataForEdit()
        {
            // Get Edit User Data
            var _user = await Task.Run(() => dataHelperForUser.Find(Id));
            if (_user!= null)
            {
                textBoxFullName.Text = _user.FullName;
                textBoxPassword.Text = _user.Password;
                textBoxUserName.Text = _user.UserName;
                textBoxEmail.Text = _user.Email;
                textBoxPhone.Text = _user.Phone;
                textBoxAddress.Text = _user.Address;
                comboBoxRole.SelectedItem = _user.Role;
                checkBoxSecondayUser.Checked = _user.IsSecondaryUser;
                userCreatedDate = _user.CreatedDate;
            }

            // Set Roles

            // Add User Roles
            foreach (var item in flowLayoutPanelRoles.Controls)
            {
                CheckBox checkBox = (CheckBox)item;
               
                checkBox.Checked=await Task.Run(()=>dataHelperForRoles
                .GetAllData()
                .Where(x=> x.UsersId == Id && x.Key==checkBox.Name)
                .Select(x=>x.Value).FirstOrDefault());
            }

        }
    }
}
