using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopGameClient.Presentation {
    private GameTableController gameTableController;
    public partial class GameTableGUI : Form {
        public GameTableGUI() {
            InitializeComponent();
            gameTableController = new GameTableController();
        }

        private void buttonBack_Click(object sender, EventArgs e) {
            MainGUI openForm = new MainGUI();
            openForm.Show();
            this.Hide();
        }

        private void UpdateGameTableListBox() {
            var allGameTables = gameTableController.GetAll();
            //MessageBox.Show("" + allProducts.Count());
            GameTableListBox.Items.Clear();
            foreach (GameTableModel gt in allGameTables) {
                GameTableListBox.Items.Add(gt);
            }
        }

        private void GameTableListBox_SelectedIndexChanged(object sender, System.EventArgs e) {
            //string gameTableText = GameTableListBox.Text;
            string gameTableText = GameTableListBox.SelectedItem.ToString();
            string id = gameTableText.Substring(0, 2);
            int tableId = Int32.Parse(id);
            GameTableModel gt = gameTableController.GetById(tableId);
            if (gt != null) { 
                GameTableIdTextBox.Text = "" + gt.Id;
                GameTableNameTextBox.Text = gt.TableName;
                var users = gt.Users;
                UpdatePlayersListBox(users);
            }
        }

        private void UpdatePlayersListBox(List<CGUserModel> users) {
            PlayersListBox.Items.Clear();
            foreach (CGUserModel cgu in users) {
                GameTableListBox.Items.Add(cgu);
            }
        }
       
        private void buttonDelete_Click(object sender, EventArgs e) {
            string id = GameTableIdTextBox.Text;
            if (!string.IsNullOrEmpty(id)) {
                int tableId = Int32.Parse(id);
                bool delete = gameTableController.Delete(tableId);
                if (delete) {
                    labelDelete.Text = "Table is deleted !";
                }
            } else {
                labelDelete.Text = "Input valid tableId !";
            }            
        }
    }
}
