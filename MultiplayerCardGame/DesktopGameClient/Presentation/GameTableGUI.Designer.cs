namespace DesktopGameClient.Presentation {
    partial class GameTableGUI {
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
            this.GameTableListBox = new System.Windows.Forms.ListBox();
            this.PlayersListBox = new System.Windows.Forms.ListBox();
            this.GameTablelabel = new System.Windows.Forms.Label();
            this.TableIdlabel = new System.Windows.Forms.Label();
            this.GameTableIdTextBox = new System.Windows.Forms.TextBox();
            this.GameTableNameLabel = new System.Windows.Forms.Label();
            this.GameTableNameTextBox = new System.Windows.Forms.TextBox();
            this.PlayersLabel = new System.Windows.Forms.Label();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonBack = new System.Windows.Forms.Button();
            this.labelDelete = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // GameTableListBox
            // 
            this.GameTableListBox.FormattingEnabled = true;
            this.GameTableListBox.ItemHeight = 20;
            this.GameTableListBox.Location = new System.Drawing.Point(566, 84);
            this.GameTableListBox.Name = "GameTableListBox";
            this.GameTableListBox.Size = new System.Drawing.Size(329, 384);
            this.GameTableListBox.TabIndex = 0;
            this.GameTableListBox.SelectedIndexChanged += new System.EventHandler(this.GameTableListBox_SelectedIndexChanged_1);
            // 
            // PlayersListBox
            // 
            this.PlayersListBox.FormattingEnabled = true;
            this.PlayersListBox.ItemHeight = 20;
            this.PlayersListBox.Location = new System.Drawing.Point(196, 189);
            this.PlayersListBox.Name = "PlayersListBox";
            this.PlayersListBox.Size = new System.Drawing.Size(165, 144);
            this.PlayersListBox.TabIndex = 1;
            // 
            // GameTablelabel
            // 
            this.GameTablelabel.AutoSize = true;
            this.GameTablelabel.Location = new System.Drawing.Point(562, 45);
            this.GameTablelabel.Name = "GameTablelabel";
            this.GameTablelabel.Size = new System.Drawing.Size(100, 20);
            this.GameTablelabel.TabIndex = 2;
            this.GameTablelabel.Text = "GameTables";
            // 
            // TableIdlabel
            // 
            this.TableIdlabel.AutoSize = true;
            this.TableIdlabel.Location = new System.Drawing.Point(77, 101);
            this.TableIdlabel.Name = "TableIdlabel";
            this.TableIdlabel.Size = new System.Drawing.Size(113, 20);
            this.TableIdlabel.TabIndex = 3;
            this.TableIdlabel.Text = "GameTableID:";
            // 
            // GameTableIdTextBox
            // 
            this.GameTableIdTextBox.Location = new System.Drawing.Point(196, 101);
            this.GameTableIdTextBox.Name = "GameTableIdTextBox";
            this.GameTableIdTextBox.Size = new System.Drawing.Size(165, 26);
            this.GameTableIdTextBox.TabIndex = 4;
            // 
            // GameTableNameLabel
            // 
            this.GameTableNameLabel.AutoSize = true;
            this.GameTableNameLabel.Location = new System.Drawing.Point(52, 137);
            this.GameTableNameLabel.Name = "GameTableNameLabel";
            this.GameTableNameLabel.Size = new System.Drawing.Size(138, 20);
            this.GameTableNameLabel.TabIndex = 5;
            this.GameTableNameLabel.Text = "GameTableName:";
            // 
            // GameTableNameTextBox
            // 
            this.GameTableNameTextBox.Location = new System.Drawing.Point(196, 137);
            this.GameTableNameTextBox.Name = "GameTableNameTextBox";
            this.GameTableNameTextBox.Size = new System.Drawing.Size(165, 26);
            this.GameTableNameTextBox.TabIndex = 6;
            // 
            // PlayersLabel
            // 
            this.PlayersLabel.AutoSize = true;
            this.PlayersLabel.Location = new System.Drawing.Point(65, 181);
            this.PlayersLabel.Name = "PlayersLabel";
            this.PlayersLabel.Size = new System.Drawing.Size(125, 20);
            this.PlayersLabel.TabIndex = 7;
            this.PlayersLabel.Text = "Players on table:";
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(109, 367);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(127, 36);
            this.buttonDelete.TabIndex = 8;
            this.buttonDelete.Text = "Delete Table";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonBack
            // 
            this.buttonBack.Location = new System.Drawing.Point(271, 367);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(127, 36);
            this.buttonBack.TabIndex = 9;
            this.buttonBack.Text = "Back to Main";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // labelDelete
            // 
            this.labelDelete.AutoSize = true;
            this.labelDelete.Location = new System.Drawing.Point(105, 433);
            this.labelDelete.Name = "labelDelete";
            this.labelDelete.Size = new System.Drawing.Size(0, 20);
            this.labelDelete.TabIndex = 10;
            // 
            // GameTableGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(997, 568);
            this.Controls.Add(this.labelDelete);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.PlayersLabel);
            this.Controls.Add(this.GameTableNameTextBox);
            this.Controls.Add(this.GameTableNameLabel);
            this.Controls.Add(this.GameTableIdTextBox);
            this.Controls.Add(this.TableIdlabel);
            this.Controls.Add(this.GameTablelabel);
            this.Controls.Add(this.PlayersListBox);
            this.Controls.Add(this.GameTableListBox);
            this.Name = "GameTableGUI";
            this.Text = "GameTableGUI";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox GameTableListBox;
        private System.Windows.Forms.ListBox PlayersListBox;
        private System.Windows.Forms.Label GameTablelabel;
        private System.Windows.Forms.Label TableIdlabel;
        private System.Windows.Forms.TextBox GameTableIdTextBox;
        private System.Windows.Forms.Label GameTableNameLabel;
        private System.Windows.Forms.TextBox GameTableNameTextBox;
        private System.Windows.Forms.Label PlayersLabel;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Label labelDelete;
    }
}