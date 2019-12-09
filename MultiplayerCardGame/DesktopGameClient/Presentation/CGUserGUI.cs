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
            string cGUserText = listBoxCGUsers.Text;
            string userId = cGUserText.Substring(0, 40);
            CGUserIdTextBox.Text = userId;
            CGUserModel cgu = cGUserController.GetById(userId);
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
    }
}
