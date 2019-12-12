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
            string userName = CGUserNameTextBox.Text;
            if (!string.IsNullOrEmpty(userName)) {
                CGUserModel cgu = cGUserController.GetUserByUserName(userName);
                bool delete = cGUserController.DeleteCGUser(cgu);
                if (delete) {
                    DeleteUserlabel.ForeColor = Color.Green;
                    DeleteUserlabel.Text = "CGUser is deleted " +" User Name: " + CGUserNameTextBox.Text;
                    UpdateCGUsersListBox();
                }
            } else {
                DeleteUserlabel.ForeColor = Color.Red;
                DeleteUserlabel.Text = "Input valid userId !";
            }
        }

        private void listBoxCGUsers_SelectedIndexChanged(object sender, EventArgs e) {
            DeleteUserlabel.Text = "";
            string userName = listBoxCGUsers.Text;
            //string userId = cGUserText.Substring(0, 40);
            CGUserNameTextBox.Text = userName;
            CGUserModel cgu = cGUserController.GetUserByUserName(userName);
            if (cgu != null) {
                CGUserIdTextBox.Text = cgu.Id;
                CGUserEmailTextBox.Text = cgu.Email;
            }
        }
    }
}
