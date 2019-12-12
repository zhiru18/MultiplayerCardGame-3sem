namespace DesktopGameClient.Presentation {
    partial class CGUserGUI {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.btnDeleteCGUser = new System.Windows.Forms.Button();
            this.btnBackToMain = new System.Windows.Forms.Button();
            this.lblAllCGUsers = new System.Windows.Forms.Label();
            this.CGUserIdTextBox = new System.Windows.Forms.TextBox();
            this.UserIdlabel = new System.Windows.Forms.Label();
            this.UserNamelabel = new System.Windows.Forms.Label();
            this.CGUserNameTextBox = new System.Windows.Forms.TextBox();
            this.CGUserEmailTextBox = new System.Windows.Forms.TextBox();
            this.Emaillabel = new System.Windows.Forms.Label();
            this.DeleteUserlabel = new System.Windows.Forms.Label();
            this.listBoxCGUsers = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btnDeleteCGUser
            // 
            this.btnDeleteCGUser.Location = new System.Drawing.Point(75, 325);
            this.btnDeleteCGUser.Name = "btnDeleteCGUser";
            this.btnDeleteCGUser.Size = new System.Drawing.Size(144, 41);
            this.btnDeleteCGUser.TabIndex = 0;
            this.btnDeleteCGUser.Text = "Delete user";
            this.btnDeleteCGUser.UseVisualStyleBackColor = true;
            this.btnDeleteCGUser.Click += new System.EventHandler(this.btnDeleteCGUser_Click);
            // 
            // btnBackToMain
            // 
            this.btnBackToMain.Location = new System.Drawing.Point(358, 325);
            this.btnBackToMain.Name = "btnBackToMain";
            this.btnBackToMain.Size = new System.Drawing.Size(123, 41);
            this.btnBackToMain.TabIndex = 1;
            this.btnBackToMain.Text = "Back To Main";
            this.btnBackToMain.UseVisualStyleBackColor = true;
            this.btnBackToMain.Click += new System.EventHandler(this.btnBackToMain_Click);
            // 
            // lblAllCGUsers
            // 
            this.lblAllCGUsers.AutoSize = true;
            this.lblAllCGUsers.Location = new System.Drawing.Point(75, 30);
            this.lblAllCGUsers.Name = "lblAllCGUsers";
            this.lblAllCGUsers.Size = new System.Drawing.Size(69, 20);
            this.lblAllCGUsers.TabIndex = 3;
            this.lblAllCGUsers.Text = "All users";
            // 
            // CGUserIdTextBox
            // 
            this.CGUserIdTextBox.Location = new System.Drawing.Point(675, 47);
            this.CGUserIdTextBox.Name = "CGUserIdTextBox";
            this.CGUserIdTextBox.Size = new System.Drawing.Size(260, 26);
            this.CGUserIdTextBox.TabIndex = 5;
            // 
            // UserIdlabel
            // 
            this.UserIdlabel.AutoSize = true;
            this.UserIdlabel.CausesValidation = false;
            this.UserIdlabel.Location = new System.Drawing.Point(505, 53);
            this.UserIdlabel.Name = "UserIdlabel";
            this.UserIdlabel.Size = new System.Drawing.Size(68, 20);
            this.UserIdlabel.TabIndex = 6;
            this.UserIdlabel.Text = "User ID:";
            // 
            // UserNamelabel
            // 
            this.UserNamelabel.AutoSize = true;
            this.UserNamelabel.CausesValidation = false;
            this.UserNamelabel.Location = new System.Drawing.Point(480, 115);
            this.UserNamelabel.Name = "UserNamelabel";
            this.UserNamelabel.Size = new System.Drawing.Size(93, 20);
            this.UserNamelabel.TabIndex = 7;
            this.UserNamelabel.Text = "User Name:";
            // 
            // CGUserNameTextBox
            // 
            this.CGUserNameTextBox.Location = new System.Drawing.Point(675, 112);
            this.CGUserNameTextBox.Name = "CGUserNameTextBox";
            this.CGUserNameTextBox.Size = new System.Drawing.Size(260, 26);
            this.CGUserNameTextBox.TabIndex = 8;
            // 
            // CGUserEmailTextBox
            // 
            this.CGUserEmailTextBox.Location = new System.Drawing.Point(675, 183);
            this.CGUserEmailTextBox.Name = "CGUserEmailTextBox";
            this.CGUserEmailTextBox.Size = new System.Drawing.Size(260, 26);
            this.CGUserEmailTextBox.TabIndex = 9;
            // 
            // Emaillabel
            // 
            this.Emaillabel.AutoSize = true;
            this.Emaillabel.CausesValidation = false;
            this.Emaillabel.Location = new System.Drawing.Point(483, 189);
            this.Emaillabel.Name = "Emaillabel";
            this.Emaillabel.Size = new System.Drawing.Size(90, 20);
            this.Emaillabel.TabIndex = 10;
            this.Emaillabel.Text = "User Email:";
            // 
            // DeleteUserlabel
            // 
            this.DeleteUserlabel.AutoSize = true;
            this.DeleteUserlabel.CausesValidation = false;
            this.DeleteUserlabel.Location = new System.Drawing.Point(75, 396);
            this.DeleteUserlabel.Name = "DeleteUserlabel";
            this.DeleteUserlabel.Size = new System.Drawing.Size(0, 20);
            this.DeleteUserlabel.TabIndex = 11;
            // 
            // listBoxCGUsers
            // 
            this.listBoxCGUsers.FormattingEnabled = true;
            this.listBoxCGUsers.ItemHeight = 20;
            this.listBoxCGUsers.Location = new System.Drawing.Point(79, 58);
            this.listBoxCGUsers.Name = "listBoxCGUsers";
            this.listBoxCGUsers.Size = new System.Drawing.Size(357, 224);
            this.listBoxCGUsers.TabIndex = 12;
            this.listBoxCGUsers.SelectedIndexChanged += new System.EventHandler(this.listBoxCGUsers_SelectedIndexChanged);
            // 
            // CGUserGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 499);
            this.Controls.Add(this.listBoxCGUsers);
            this.Controls.Add(this.DeleteUserlabel);
            this.Controls.Add(this.Emaillabel);
            this.Controls.Add(this.CGUserEmailTextBox);
            this.Controls.Add(this.CGUserNameTextBox);
            this.Controls.Add(this.UserNamelabel);
            this.Controls.Add(this.UserIdlabel);
            this.Controls.Add(this.CGUserIdTextBox);
            this.Controls.Add(this.lblAllCGUsers);
            this.Controls.Add(this.btnBackToMain);
            this.Controls.Add(this.btnDeleteCGUser);
            this.Name = "CGUserGUI";
            this.Text = "CGUserGUI";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDeleteCGUser;
        private System.Windows.Forms.Button btnBackToMain;
        private System.Windows.Forms.Label lblAllCGUsers;
        private System.Windows.Forms.TextBox CGUserIdTextBox;
        private System.Windows.Forms.Label UserIdlabel;
        private System.Windows.Forms.Label UserNamelabel;
        private System.Windows.Forms.TextBox CGUserNameTextBox;
        private System.Windows.Forms.TextBox CGUserEmailTextBox;
        private System.Windows.Forms.Label Emaillabel;
        private System.Windows.Forms.Label DeleteUserlabel;
        private System.Windows.Forms.ListBox listBoxCGUsers;
    }
}