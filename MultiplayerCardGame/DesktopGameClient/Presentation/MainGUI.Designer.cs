namespace DesktopGameClient {
    partial class MainGUI {
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
            this.buttonGameTable = new System.Windows.Forms.Button();
            this.buttonCGUser = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonGameTable
            // 
            this.buttonGameTable.Location = new System.Drawing.Point(97, 114);
            this.buttonGameTable.Name = "buttonGameTable";
            this.buttonGameTable.Size = new System.Drawing.Size(264, 46);
            this.buttonGameTable.TabIndex = 1;
            this.buttonGameTable.Text = "GameTableManagement";
            this.buttonGameTable.UseVisualStyleBackColor = true;
            this.buttonGameTable.Click += new System.EventHandler(this.buttonGameTable_Click);
            // 
            // buttonCGUser
            // 
            this.buttonCGUser.Location = new System.Drawing.Point(97, 202);
            this.buttonCGUser.Name = "buttonCGUser";
            this.buttonCGUser.Size = new System.Drawing.Size(264, 46);
            this.buttonCGUser.TabIndex = 2;
            this.buttonCGUser.Text = "CGUserManagement";
            this.buttonCGUser.UseVisualStyleBackColor = true;
            this.buttonCGUser.Click += new System.EventHandler(this.ButtonCGUser_Click);
            // 
            // MainGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 450);
            this.Controls.Add(this.buttonCGUser);
            this.Controls.Add(this.buttonGameTable);
            this.Name = "MainGUI";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonGameTable;
        private System.Windows.Forms.Button buttonCGUser;
    }
}

