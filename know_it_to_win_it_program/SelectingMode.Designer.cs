namespace know_it_to_win_it_program
{
    partial class SelectingMode
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
            this.btn_GoForward = new System.Windows.Forms.Button();
            this.btn_GoBackward = new System.Windows.Forms.Button();
            this.labelText = new System.Windows.Forms.Label();
            this.option1 = new System.Windows.Forms.RadioButton();
            this.option2 = new System.Windows.Forms.RadioButton();
            this.option3 = new System.Windows.Forms.RadioButton();
            this.option4 = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // btn_GoForward
            // 
            this.btn_GoForward.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_GoForward.Location = new System.Drawing.Point(788, 474);
            this.btn_GoForward.Name = "btn_GoForward";
            this.btn_GoForward.Size = new System.Drawing.Size(139, 56);
            this.btn_GoForward.TabIndex = 0;
            this.btn_GoForward.Text = "Next";
            this.btn_GoForward.UseVisualStyleBackColor = true;
            this.btn_GoForward.Click += new System.EventHandler(this.btn_GoForward_Click);
            // 
            // btn_GoBackward
            // 
            this.btn_GoBackward.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_GoBackward.Location = new System.Drawing.Point(12, 474);
            this.btn_GoBackward.Name = "btn_GoBackward";
            this.btn_GoBackward.Size = new System.Drawing.Size(153, 56);
            this.btn_GoBackward.TabIndex = 1;
            this.btn_GoBackward.Text = "Previous";
            this.btn_GoBackward.UseVisualStyleBackColor = true;
            this.btn_GoBackward.Click += new System.EventHandler(this.btn_GoBackward_Click);
            // 
            // labelText
            // 
            this.labelText.AutoSize = true;
            this.labelText.Font = new System.Drawing.Font("Lucida Fax", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelText.Location = new System.Drawing.Point(28, 39);
            this.labelText.Name = "labelText";
            this.labelText.Size = new System.Drawing.Size(192, 32);
            this.labelText.TabIndex = 2;
            this.labelText.Text = "default_text";
            // 
            // option1
            // 
            this.option1.AutoSize = true;
            this.option1.Font = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.option1.Location = new System.Drawing.Point(34, 137);
            this.option1.Name = "option1";
            this.option1.Size = new System.Drawing.Size(185, 33);
            this.option1.TabIndex = 3;
            this.option1.TabStop = true;
            this.option1.Text = "radioButton1";
            this.option1.UseVisualStyleBackColor = true;
            // 
            // option2
            // 
            this.option2.AutoSize = true;
            this.option2.Font = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.option2.Location = new System.Drawing.Point(32, 205);
            this.option2.Name = "option2";
            this.option2.Size = new System.Drawing.Size(185, 33);
            this.option2.TabIndex = 4;
            this.option2.TabStop = true;
            this.option2.Text = "radioButton1";
            this.option2.UseVisualStyleBackColor = true;
            // 
            // option3
            // 
            this.option3.AutoSize = true;
            this.option3.Font = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.option3.Location = new System.Drawing.Point(34, 274);
            this.option3.Name = "option3";
            this.option3.Size = new System.Drawing.Size(185, 33);
            this.option3.TabIndex = 5;
            this.option3.TabStop = true;
            this.option3.Text = "radioButton1";
            this.option3.UseVisualStyleBackColor = true;
            // 
            // option4
            // 
            this.option4.AutoSize = true;
            this.option4.Font = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.option4.Location = new System.Drawing.Point(32, 344);
            this.option4.Name = "option4";
            this.option4.Size = new System.Drawing.Size(185, 33);
            this.option4.TabIndex = 6;
            this.option4.TabStop = true;
            this.option4.Text = "radioButton1";
            this.option4.UseVisualStyleBackColor = true;
            // 
            // SelectingMode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(939, 542);
            this.Controls.Add(this.option4);
            this.Controls.Add(this.option3);
            this.Controls.Add(this.option2);
            this.Controls.Add(this.option1);
            this.Controls.Add(this.labelText);
            this.Controls.Add(this.btn_GoBackward);
            this.Controls.Add(this.btn_GoForward);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SelectingMode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "default";
            this.Load += new System.EventHandler(this.SelectingMode_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_GoForward;
        private System.Windows.Forms.Button btn_GoBackward;
        private System.Windows.Forms.Label labelText;
        private System.Windows.Forms.RadioButton option1;
        private System.Windows.Forms.RadioButton option2;
        private System.Windows.Forms.RadioButton option3;
        private System.Windows.Forms.RadioButton option4;
    }
}