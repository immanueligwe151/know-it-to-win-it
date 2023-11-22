namespace know_it_to_win_it_program
{
    partial class RevisionMode
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
            this.label2 = new System.Windows.Forms.Label();
            this.topicDisplay = new System.Windows.Forms.Label();
            this.btn_Back = new System.Windows.Forms.Button();
            this.slideCounter = new System.Windows.Forms.Label();
            this.goBackwardBtn = new System.Windows.Forms.PictureBox();
            this.goForwardBtn = new System.Windows.Forms.PictureBox();
            this.slideBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.goBackwardBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.goForwardBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.slideBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Libre Bodoni", 20F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(480, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(298, 50);
            this.label1.TabIndex = 0;
            this.label1.Text = "Revision Mode";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Palatino Linotype", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(60, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 44);
            this.label2.TabIndex = 1;
            this.label2.Text = "Topic:";
            // 
            // topicDisplay
            // 
            this.topicDisplay.AutoSize = true;
            this.topicDisplay.Font = new System.Drawing.Font("Palatino Linotype", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.topicDisplay.Location = new System.Drawing.Point(223, 50);
            this.topicDisplay.Name = "topicDisplay";
            this.topicDisplay.Size = new System.Drawing.Size(189, 44);
            this.topicDisplay.TabIndex = 2;
            this.topicDisplay.Text = "topic_name";
            // 
            // btn_Back
            // 
            this.btn_Back.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Back.Location = new System.Drawing.Point(23, 595);
            this.btn_Back.Name = "btn_Back";
            this.btn_Back.Size = new System.Drawing.Size(97, 44);
            this.btn_Back.TabIndex = 6;
            this.btn_Back.Text = "Home";
            this.btn_Back.UseVisualStyleBackColor = true;
            this.btn_Back.Click += new System.EventHandler(this.btn_Back_Click);
            // 
            // slideCounter
            // 
            this.slideCounter.AutoSize = true;
            this.slideCounter.Font = new System.Drawing.Font("Palatino Linotype", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.slideCounter.Location = new System.Drawing.Point(873, 50);
            this.slideCounter.Name = "slideCounter";
            this.slideCounter.Size = new System.Drawing.Size(222, 44);
            this.slideCounter.TabIndex = 7;
            this.slideCounter.Text = "slide_number";
            // 
            // goBackwardBtn
            // 
            this.goBackwardBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.goBackwardBtn.Image = global::know_it_to_win_it_program.Properties.Resources.backward_arrow_icon;
            this.goBackwardBtn.Location = new System.Drawing.Point(164, 529);
            this.goBackwardBtn.Name = "goBackwardBtn";
            this.goBackwardBtn.Size = new System.Drawing.Size(111, 62);
            this.goBackwardBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.goBackwardBtn.TabIndex = 5;
            this.goBackwardBtn.TabStop = false;
            this.goBackwardBtn.Click += new System.EventHandler(this.goBackwardBtn_Click);
            // 
            // goForwardBtn
            // 
            this.goForwardBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.goForwardBtn.Image = global::know_it_to_win_it_program.Properties.Resources.forward_arrow_icon;
            this.goForwardBtn.Location = new System.Drawing.Point(984, 529);
            this.goForwardBtn.Name = "goForwardBtn";
            this.goForwardBtn.Size = new System.Drawing.Size(111, 62);
            this.goForwardBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.goForwardBtn.TabIndex = 4;
            this.goForwardBtn.TabStop = false;
            this.goForwardBtn.Click += new System.EventHandler(this.goForwardBtn_Click);
            // 
            // slideBox
            // 
            this.slideBox.Location = new System.Drawing.Point(164, 98);
            this.slideBox.Name = "slideBox";
            this.slideBox.Size = new System.Drawing.Size(930, 425);
            this.slideBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.slideBox.TabIndex = 3;
            this.slideBox.TabStop = false;
            // 
            // RevisionMode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SaddleBrown;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1258, 664);
            this.Controls.Add(this.slideCounter);
            this.Controls.Add(this.btn_Back);
            this.Controls.Add(this.goBackwardBtn);
            this.Controls.Add(this.goForwardBtn);
            this.Controls.Add(this.slideBox);
            this.Controls.Add(this.topicDisplay);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "RevisionMode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Revision Mode";
            this.Load += new System.EventHandler(this.RevisionMode_Load);
            ((System.ComponentModel.ISupportInitialize)(this.goBackwardBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.goForwardBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.slideBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label topicDisplay;
        private System.Windows.Forms.PictureBox slideBox;
        private System.Windows.Forms.PictureBox goForwardBtn;
        private System.Windows.Forms.PictureBox goBackwardBtn;
        private System.Windows.Forms.Button btn_Back;
        private System.Windows.Forms.Label slideCounter;
    }
}