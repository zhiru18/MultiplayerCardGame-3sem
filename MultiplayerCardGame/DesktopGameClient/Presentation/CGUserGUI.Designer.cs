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
            this.button2 = new System.Windows.Forms.Button();
            this.listBoxCGUsers = new System.Windows.Forms.ListBox();
            this.lblAllCGUsers = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnDeleteCGUser
            // 
            this.btnDeleteCGUser.Location = new System.Drawing.Point(75, 292);
            this.btnDeleteCGUser.Name = "btnDeleteCGUser";
            this.btnDeleteCGUser.Size = new System.Drawing.Size(144, 41);
            this.btnDeleteCGUser.TabIndex = 0;
            this.btnDeleteCGUser.Text = "Delete user";
            this.btnDeleteCGUser.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(542, 214);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // listBoxCGUsers
            // 
            this.listBoxCGUsers.FormattingEnabled = true;
            this.listBoxCGUsers.ItemHeight = 20;
            this.listBoxCGUsers.Location = new System.Drawing.Point(75, 56);
            this.listBoxCGUsers.Name = "listBoxCGUsers";
            this.listBoxCGUsers.Size = new System.Drawing.Size(190, 224);
            this.listBoxCGUsers.TabIndex = 2;
            this.listBoxCGUsers.SelectedIndexChanged += new System.EventHandler(this.ListBoxCGUsers_SelectedIndexChanged);
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
            // CGUserGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblAllCGUsers);
            this.Controls.Add(this.listBoxCGUsers);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnDeleteCGUser);
            this.Name = "CGUserGUI";
            this.Text = "CGUserGUI";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDeleteCGUser;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListBox listBoxCGUsers;
        private System.Windows.Forms.Label lblAllCGUsers;
    }
}