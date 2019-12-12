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
    
    public partial class GameTableGUI : Form {
        private GameTableController gameTableController;
        public GameTableGUI() {
            InitializeComponent();
            gameTableController = new GameTableController();
            UpdateGameTableListBox();
        }

        private void buttonBack_Click(object sender, EventArgs e) {
            MainGUI openForm = new MainGUI();
            openForm.Show();
            this.Hide();
        }

        private void UpdateGameTableListBox() {
            var allGameTables = gameTableController.GetAll();
            GameTableListBox.Items.Clear();
            foreach (GameTableModel gt in allGameTables) {
                GameTableListBox.Items.Add(gt);
            }
        }

        private void UpdatePlayersListBox(List<CGUserModel> users) {
            PlayersListBox.Items.Clear();
            foreach (CGUserModel cgu in users) {
                PlayersListBox.Items.Add(cgu.UserName);
            }
        }
       
        private void buttonDelete_Click(object sender, EventArgs e) {
            try {
                string id = GameTableIdTextBox.Text;
                if (!string.IsNullOrEmpty(id)) {
                    int tableId = Int32.Parse(id);
                    bool delete = gameTableController.Delete(tableId);
                    if (delete) {
                        labelDelete.ForeColor = Color.Green;
                        labelDelete.Text = "Table is deleted " + "Table ID: " + GameTableIdTextBox.Text + " Table Name: " + GameTableNameTextBox.Text;
                        UpdateGameTableListBox();
                    }
                } else {
                    labelDelete.ForeColor = Color.Red;
                    labelDelete.Text = "Input valid tableId !";
                }
            } catch (Exception) {

                MessageBox.Show("Bordet er i brug", "Bordet kan ikke slettes");
            }          
        }

        private void GameTableListBox_SelectedIndexChanged_1(object sender, EventArgs e) {
            labelDelete.Text = "";
            string gameTableText = GameTableListBox.Text;
            string id = gameTableText.Substring(0, 4);
            int tableId = Int32.Parse(id);
            GameTableIdTextBox.Text = id;
            GameTableModel gt = gameTableController.GetById(tableId);
            if (gt != null) {
                //GameTableIdTextBox.Text = "" + gt.Id;
                GameTableNameTextBox.Text = gt.TableName;
                var users = gt.Users;
                UpdatePlayersListBox(users);
            }
        }
    }
}
