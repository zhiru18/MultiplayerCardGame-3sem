using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DesktopGameClient.Presentation;

namespace DesktopGameClient {
    public partial class MainGUI : Form {
        public MainGUI() {
            InitializeComponent();
        }

        private void buttonGameTable_Click(object sender, EventArgs e) {
            GameTableGUI openForm = new GameTableGUI();
            openForm.Show();
            this.Hide();
        }

        private void ButtonCGUser_Click(object sender, EventArgs e) {
            CGUserGUI openForm = new CGUserGUI();
            openForm.Show();
            this.Hide();
        }
    }
}
