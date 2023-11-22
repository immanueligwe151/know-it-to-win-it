namespace know_it_to_win_it_program
{
    partial class HintWindow
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
            this.label1 = new System.Windows.Forms.Label();
            this.hintPictureBox = new System.Windows.Forms.PictureBox();
            this.btn_Done = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.hintPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Sans Unicode", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(313, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Here\'s your hint...";
            // 
            // hintPictureBox
            // 
            this.hintPictureBox.Location = new System.Drawing.Point(19, 83);
            this.hintPictureBox.Name = "hintPictureBox";
            this.hintPictureBox.Size = new System.Drawing.Size(855, 315);
            this.hintPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.hintPictureBox.TabIndex = 1;
            this.hintPictureBox.TabStop = false;
            // 
            // btn_Done
            // 
            this.btn_Done.Font = new System.Drawing.Font("MV Boli", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Done.Location = new System.Drawing.Point(704, 413);
            this.btn_Done.Name = "btn_Done";
            this.btn_Done.Size = new System.Drawing.Size(170, 57);
            this.btn_Done.TabIndex = 2;
            this.btn_Done.Text = "Thanks! 👍🏾";
            this.btn_Done.UseVisualStyleBackColor = true;
            this.btn_Done.Click += new System.EventHandler(this.btn_Done_Click);
            // 
            // HintWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Chocolate;
            this.ClientSize = new System.Drawing.Size(916, 482);
            this.Controls.Add(this.btn_Done);
            this.Controls.Add(this.hintPictureBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "HintWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Your Hint!";
            this.Load += new System.EventHandler(this.HintWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.hintPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox hintPictureBox;
        private System.Windows.Forms.Button btn_Done;
    }
}