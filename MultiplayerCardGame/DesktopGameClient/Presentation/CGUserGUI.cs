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
    public partial class CGUserGUI : Form {
        public CGUserGUI() {
            InitializeComponent();
        }

        private void ListBoxCGUsers_SelectedIndexChanged(object sender, EventArgs e) {
            string cGUserText = listBoxCGUsers.Text;
        }
    }
}
