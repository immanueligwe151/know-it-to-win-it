namespace know_it_to_win_it_program
{
    partial class MainMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btn_PlayGame = new System.Windows.Forms.Button();
            this.btn_OpenStore = new System.Windows.Forms.Button();
            this.btn_ChangeUsername = new System.Windows.Forms.Button();
            this.btn_Quit = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // btn_PlayGame
            // 
            this.btn_PlayGame.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_PlayGame.FlatAppearance.BorderSize = 3;
            this.btn_PlayGame.Font = new System.Drawing.Font("Footlight MT Light", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_PlayGame.ForeColor = System.Drawing.Color.Blue;
            this.btn_PlayGame.Location = new System.Drawing.Point(59, 470);
            this.btn_PlayGame.Name = "btn_PlayGame";
            this.btn_PlayGame.Size = new System.Drawing.Size(207, 73);
            this.btn_PlayGame.TabIndex = 0;
            this.btn_PlayGame.Text = "Play Game";
            this.btn_PlayGame.UseVisualStyleBackColor = true;
            this.btn_PlayGame.Click += new System.EventHandler(this.btn_PlayGame_Click);
            this.btn_PlayGame.MouseHover += new System.EventHandler(this.btn_PlayGame_MouseHover);
            // 
            // btn_OpenStore
            // 
            this.btn_OpenStore.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_OpenStore.FlatAppearance.BorderSize = 3;
            this.btn_OpenStore.Font = new System.Drawing.Font("Footlight MT Light", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_OpenStore.ForeColor = System.Drawing.Color.Blue;
            this.btn_OpenStore.Location = new System.Drawing.Point(362, 470);
            this.btn_OpenStore.Name = "btn_OpenStore";
            this.btn_OpenStore.Size = new System.Drawing.Size(207, 73);
            this.btn_OpenStore.TabIndex = 1;
            this.btn_OpenStore.Text = "Store";
            this.btn_OpenStore.UseVisualStyleBackColor = true;
            this.btn_OpenStore.Click += new System.EventHandler(this.btn_OpenStore_Click);
            this.btn_OpenStore.MouseHover += new System.EventHandler(this.btn_OpenStore_MouseHover);
            // 
            // btn_ChangeUsername
            // 
            this.btn_ChangeUsername.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_ChangeUsername.FlatAppearance.BorderSize = 3;
            this.btn_ChangeUsername.Font = new System.Drawing.Font("Footlight MT Light", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ChangeUsername.ForeColor = System.Drawing.Color.Blue;
            this.btn_ChangeUsername.Location = new System.Drawing.Point(668, 462);
            this.btn_ChangeUsername.Name = "btn_ChangeUsername";
            this.btn_ChangeUsername.Size = new System.Drawing.Size(207, 88);
            this.btn_ChangeUsername.TabIndex = 2;
            this.btn_ChangeUsername.Text = "Change\r\nUsername";
            this.btn_ChangeUsername.UseVisualStyleBackColor = true;
            this.btn_ChangeUsername.Click += new System.EventHandler(this.btn_ChangeUsername_Click);
            this.btn_ChangeUsername.MouseHover += new System.EventHandler(this.btn_ChangeUsername_MouseHover);
            // 
            // btn_Quit
            // 
            this.btn_Quit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Quit.FlatAppearance.BorderSize = 3;
            this.btn_Quit.Font = new System.Drawing.Font("Footlight MT Light", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Quit.ForeColor = System.Drawing.Color.Blue;
            this.btn_Quit.Location = new System.Drawing.Point(993, 470);
            this.btn_Quit.Name = "btn_Quit";
            this.btn_Quit.Size = new System.Drawing.Size(207, 73);
            this.btn_Quit.TabIndex = 3;
            this.btn_Quit.Text = "Quit";
            this.btn_Quit.UseVisualStyleBackColor = true;
            this.btn_Quit.Click += new System.EventHandler(this.btn_Quit_Click);
            this.btn_Quit.MouseHover += new System.EventHandler(this.btn_Quit_MouseHover);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::know_it_to_win_it_program.Properties.Resources.menu_background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1258, 664);
            this.Controls.Add(this.btn_Quit);
            this.Controls.Add(this.btn_ChangeUsername);
            this.Controls.Add(this.btn_OpenStore);
            this.Controls.Add(this.btn_PlayGame);
            this.MaximizeBox = false;
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Know It To Win It";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_PlayGame;
        private System.Windows.Forms.Button btn_OpenStore;
        private System.Windows.Forms.Button btn_ChangeUsername;
        private System.Windows.Forms.Button btn_Quit;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}