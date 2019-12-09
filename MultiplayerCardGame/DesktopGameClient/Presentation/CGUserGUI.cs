using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DesktopGameClient.Controllers;
using DesktopGameClient.Models;

namespace DesktopGameClient.Presentation {
    public partial class CGUserGUI : Form {
        private CGUserController cGUserController;
        public CGUserGUI() {
            InitializeComponent();
            cGUserController = new CGUserController();
            UpdateCGUsersListBox();
        }

        private void ListBoxCGUsers_SelectedIndexChanged(object sender, EventArgs e) {
            DeleteUserlabel.Text = "";
            string cGUserText = listBoxCGUsers.Text;
            string userId = cGUserText.Substring(0, 40);
            CGUserIdTextBox.Text = userId;
            CGUserModel cgu = cGUserController.GetById(userId);
            if (cgu != null) {
                CGUserNameTextBox.Text = cgu.UserName;
                CGUserEmailTextBox.Text = cgu.Email;
            }
        }

        private void btnBackToMain_Click(object sender, EventArgs e) {
            MainGUI openForm = new MainGUI();
            openForm.Show();
            this.Hide();
        }

        private void UpdateCGUsersListBox() {
            var allUsers = cGUserController.GetAll();
            listBoxCGUsers.Items.Clear();
            foreach (CGUserModel cgu in allUsers) {
                listBoxCGUsers.Items.Add(cgu);
            }
        }

        private void btnDeleteCGUser_Click(object sender, EventArgs e) {
            string id = CGUserIdTextBox.Text;
            if (!string.IsNullOrEmpty(id)) {
                CGUserModel cgu = cGUserController.GetById(id);
                bool delete = cGUserController.DeleteCGUser(cgu);
                if (delete) {
                    DeleteUserlabel.Text = "CGUser is deleted " +" User Name: " + CGUserNameTextBox.Text;
                    UpdateCGUsersListBox();
                }
            } else {
                DeleteUserlabel.Text = "Input valid userId !";
            }
        }
    }
}
