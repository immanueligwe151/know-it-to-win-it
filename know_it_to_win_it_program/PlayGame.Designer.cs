namespace know_it_to_win_it_program
{
    partial class QuizMode
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
            this.avatarPictureBox = new System.Windows.Forms.PictureBox();
            this.fastTrackNumber = new System.Windows.Forms.Label();
            this.questionSkipNumber = new System.Windows.Forms.Label();
            this.gemNumber = new System.Windows.Forms.Label();
            this.movingRightTimer = new System.Windows.Forms.Timer(this.components);
            this.movingDownTimer = new System.Windows.Forms.Timer(this.components);
            this.movingUpTimer = new System.Windows.Forms.Timer(this.components);
            this.fastTrackActivate = new System.Windows.Forms.PictureBox();
            this.questionSkipperActivate = new System.Windows.Forms.PictureBox();
            this.hintGemActivate = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.questionPictureBox = new System.Windows.Forms.PictureBox();
            this.btn_DoneNext = new System.Windows.Forms.Button();
            this.btn_Endgame = new System.Windows.Forms.Button();
            this.btn_Restart = new System.Windows.Forms.Button();
            this.btn_Pause = new System.Windows.Forms.Button();
            this.optionD = new System.Windows.Forms.RadioButton();
            this.optionC = new System.Windows.Forms.RadioButton();
            this.optionB = new System.Windows.Forms.RadioButton();
            this.optionA = new System.Windows.Forms.RadioButton();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.usingFastTrack = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.avatarPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fastTrackActivate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.questionSkipperActivate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hintGemActivate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.questionPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // avatarPictureBox
            // 
            this.avatarPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.avatarPictureBox.Location = new System.Drawing.Point(393, 458);
            this.avatarPictureBox.Name = "avatarPictureBox";
            this.avatarPictureBox.Size = new System.Drawing.Size(87, 86);
            this.avatarPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.avatarPictureBox.TabIndex = 0;
            this.avatarPictureBox.TabStop = false;
            // 
            // fastTrackNumber
            // 
            this.fastTrackNumber.AutoSize = true;
            this.fastTrackNumber.BackColor = System.Drawing.Color.Transparent;
            this.fastTrackNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fastTrackNumber.Location = new System.Drawing.Point(1118, 116);
            this.fastTrackNumber.Name = "fastTrackNumber";
            this.fastTrackNumber.Size = new System.Drawing.Size(55, 59);
            this.fastTrackNumber.TabIndex = 6;
            this.fastTrackNumber.Text = "2";
            // 
            // questionSkipNumber
            // 
            this.questionSkipNumber.AutoSize = true;
            this.questionSkipNumber.BackColor = System.Drawing.Color.Transparent;
            this.questionSkipNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.questionSkipNumber.Location = new System.Drawing.Point(961, 116);
            this.questionSkipNumber.Name = "questionSkipNumber";
            this.questionSkipNumber.Size = new System.Drawing.Size(55, 59);
            this.questionSkipNumber.TabIndex = 5;
            this.questionSkipNumber.Text = "1";
            // 
            // gemNumber
            // 
            this.gemNumber.AutoSize = true;
            this.gemNumber.BackColor = System.Drawing.Color.Transparent;
            this.gemNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gemNumber.Location = new System.Drawing.Point(829, 116);
            this.gemNumber.Name = "gemNumber";
            this.gemNumber.Size = new System.Drawing.Size(55, 59);
            this.gemNumber.TabIndex = 4;
            this.gemNumber.Text = "3";
            // 
            // movingRightTimer
            // 
            this.movingRightTimer.Tick += new System.EventHandler(this.movingRightTimer_Tick);
            // 
            // movingDownTimer
            // 
            this.movingDownTimer.Tick += new System.EventHandler(this.movingDownTimer_Tick);
            // 
            // movingUpTimer
            // 
            this.movingUpTimer.Tick += new System.EventHandler(this.movingUpTimer_Tick);
            // 
            // fastTrackActivate
            // 
            this.fastTrackActivate.BackColor = System.Drawing.Color.Transparent;
            this.fastTrackActivate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.fastTrackActivate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.fastTrackActivate.Image = global::know_it_to_win_it_program.Properties.Resources.fast_track_icon;
            this.fastTrackActivate.Location = new System.Drawing.Point(249, 562);
            this.fastTrackActivate.Name = "fastTrackActivate";
            this.fastTrackActivate.Size = new System.Drawing.Size(87, 57);
            this.fastTrackActivate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.fastTrackActivate.TabIndex = 13;
            this.fastTrackActivate.TabStop = false;
            this.fastTrackActivate.Click += new System.EventHandler(this.fastTrackActivate_Click);
            this.fastTrackActivate.MouseHover += new System.EventHandler(this.fastTrackActivate_MouseHover);
            // 
            // questionSkipperActivate
            // 
            this.questionSkipperActivate.BackColor = System.Drawing.Color.Transparent;
            this.questionSkipperActivate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.questionSkipperActivate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.questionSkipperActivate.Image = global::know_it_to_win_it_program.Properties.Resources.question_skip_icon;
            this.questionSkipperActivate.Location = new System.Drawing.Point(139, 562);
            this.questionSkipperActivate.Name = "questionSkipperActivate";
            this.questionSkipperActivate.Size = new System.Drawing.Size(81, 57);
            this.questionSkipperActivate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.questionSkipperActivate.TabIndex = 12;
            this.questionSkipperActivate.TabStop = false;
            this.questionSkipperActivate.Click += new System.EventHandler(this.questionSkipperActivate_Click);
            this.questionSkipperActivate.MouseHover += new System.EventHandler(this.questionSkipperActivate_MouseHover);
            // 
            // hintGemActivate
            // 
            this.hintGemActivate.BackColor = System.Drawing.Color.Transparent;
            this.hintGemActivate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.hintGemActivate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.hintGemActivate.Image = global::know_it_to_win_it_program.Properties.Resources.hint_gem_icon;
            this.hintGemActivate.Location = new System.Drawing.Point(38, 562);
            this.hintGemActivate.Name = "hintGemActivate";
            this.hintGemActivate.Size = new System.Drawing.Size(61, 75);
            this.hintGemActivate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.hintGemActivate.TabIndex = 11;
            this.hintGemActivate.TabStop = false;
            this.hintGemActivate.Click += new System.EventHandler(this.hintGemActivate_Click);
            this.hintGemActivate.MouseHover += new System.EventHandler(this.hintGemActivate_MouseHover);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Lucida Bright", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 522);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 36);
            this.label1.TabIndex = 10;
            this.label1.Text = "Powerups";
            // 
            // questionPictureBox
            // 
            this.questionPictureBox.Location = new System.Drawing.Point(8, 163);
            this.questionPictureBox.Name = "questionPictureBox";
            this.questionPictureBox.Size = new System.Drawing.Size(379, 334);
            this.questionPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.questionPictureBox.TabIndex = 9;
            this.questionPictureBox.TabStop = false;
            // 
            // btn_DoneNext
            // 
            this.btn_DoneNext.Font = new System.Drawing.Font("Microsoft YaHei", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_DoneNext.Location = new System.Drawing.Point(12, 475);
            this.btn_DoneNext.Name = "btn_DoneNext";
            this.btn_DoneNext.Size = new System.Drawing.Size(100, 44);
            this.btn_DoneNext.TabIndex = 14;
            this.btn_DoneNext.Text = "Done";
            this.btn_DoneNext.UseVisualStyleBackColor = true;
            this.btn_DoneNext.Click += new System.EventHandler(this.btn_DoneNext_Click);
            // 
            // btn_Endgame
            // 
            this.btn_Endgame.Font = new System.Drawing.Font("Mangal", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Endgame.Location = new System.Drawing.Point(1028, 12);
            this.btn_Endgame.Name = "btn_Endgame";
            this.btn_Endgame.Size = new System.Drawing.Size(167, 59);
            this.btn_Endgame.TabIndex = 17;
            this.btn_Endgame.Text = "End Game";
            this.btn_Endgame.UseVisualStyleBackColor = true;
            this.btn_Endgame.Click += new System.EventHandler(this.btn_Endgame_Click);
            // 
            // btn_Restart
            // 
            this.btn_Restart.Font = new System.Drawing.Font("Mangal", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Restart.Location = new System.Drawing.Point(839, 12);
            this.btn_Restart.Name = "btn_Restart";
            this.btn_Restart.Size = new System.Drawing.Size(143, 59);
            this.btn_Restart.TabIndex = 16;
            this.btn_Restart.Text = "Restart";
            this.btn_Restart.UseVisualStyleBackColor = true;
            this.btn_Restart.Click += new System.EventHandler(this.btn_Restart_Click);
            // 
            // btn_Pause
            // 
            this.btn_Pause.Font = new System.Drawing.Font("Mangal", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Pause.Location = new System.Drawing.Point(667, 12);
            this.btn_Pause.Name = "btn_Pause";
            this.btn_Pause.Size = new System.Drawing.Size(143, 59);
            this.btn_Pause.TabIndex = 15;
            this.btn_Pause.Text = "Pause";
            this.btn_Pause.UseVisualStyleBackColor = true;
            this.btn_Pause.Click += new System.EventHandler(this.btn_Pause_Click);
            // 
            // optionD
            // 
            this.optionD.AutoSize = true;
            this.optionD.BackColor = System.Drawing.Color.White;
            this.optionD.Location = new System.Drawing.Point(349, 417);
            this.optionD.Name = "optionD";
            this.optionD.Size = new System.Drawing.Size(21, 20);
            this.optionD.TabIndex = 21;
            this.optionD.TabStop = true;
            this.optionD.UseVisualStyleBackColor = false;
            // 
            // optionC
            // 
            this.optionC.AutoSize = true;
            this.optionC.BackColor = System.Drawing.Color.White;
            this.optionC.Location = new System.Drawing.Point(349, 391);
            this.optionC.Name = "optionC";
            this.optionC.Size = new System.Drawing.Size(21, 20);
            this.optionC.TabIndex = 20;
            this.optionC.TabStop = true;
            this.optionC.UseVisualStyleBackColor = false;
            // 
            // optionB
            // 
            this.optionB.AutoSize = true;
            this.optionB.BackColor = System.Drawing.Color.White;
            this.optionB.Location = new System.Drawing.Point(349, 365);
            this.optionB.Name = "optionB";
            this.optionB.Size = new System.Drawing.Size(21, 20);
            this.optionB.TabIndex = 19;
            this.optionB.TabStop = true;
            this.optionB.UseVisualStyleBackColor = false;
            // 
            // optionA
            // 
            this.optionA.AutoSize = true;
            this.optionA.BackColor = System.Drawing.Color.White;
            this.optionA.Location = new System.Drawing.Point(349, 339);
            this.optionA.Name = "optionA";
            this.optionA.Size = new System.Drawing.Size(21, 20);
            this.optionA.TabIndex = 18;
            this.optionA.TabStop = true;
            this.optionA.UseVisualStyleBackColor = false;
            // 
            // usingFastTrack
            // 
            this.usingFastTrack.Tick += new System.EventHandler(this.usingFastTrack_Tick);
            // 
            // QuizMode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::know_it_to_win_it_program.Properties.Resources.background_with_track_1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1258, 664);
            this.Controls.Add(this.optionD);
            this.Controls.Add(this.optionC);
            this.Controls.Add(this.optionB);
            this.Controls.Add(this.optionA);
            this.Controls.Add(this.btn_Endgame);
            this.Controls.Add(this.btn_Restart);
            this.Controls.Add(this.btn_Pause);
            this.Controls.Add(this.btn_DoneNext);
            this.Controls.Add(this.fastTrackActivate);
            this.Controls.Add(this.questionSkipperActivate);
            this.Controls.Add(this.hintGemActivate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.questionPictureBox);
            this.Controls.Add(this.fastTrackNumber);
            this.Controls.Add(this.questionSkipNumber);
            this.Controls.Add(this.gemNumber);
            this.Controls.Add(this.avatarPictureBox);
            this.Name = "QuizMode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quiz Mode";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.QuizMode_Load);
            ((System.ComponentModel.ISupportInitialize)(this.avatarPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fastTrackActivate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.questionSkipperActivate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hintGemActivate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.questionPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox avatarPictureBox;
        private System.Windows.Forms.Label fastTrackNumber;
        private System.Windows.Forms.Label questionSkipNumber;
        private System.Windows.Forms.Label gemNumber;
        private System.Windows.Forms.Timer movingRightTimer;
        private System.Windows.Forms.Timer movingDownTimer;
        private System.Windows.Forms.Timer movingUpTimer;
        private System.Windows.Forms.PictureBox fastTrackActivate;
        private System.Windows.Forms.PictureBox questionSkipperActivate;
        private System.Windows.Forms.PictureBox hintGemActivate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox questionPictureBox;
        private System.Windows.Forms.Button btn_DoneNext;
        private System.Windows.Forms.Button btn_Endgame;
        private System.Windows.Forms.Button btn_Restart;
        private System.Windows.Forms.Button btn_Pause;
        private System.Windows.Forms.RadioButton optionD;
        private System.Windows.Forms.RadioButton optionC;
        private System.Windows.Forms.RadioButton optionB;
        private System.Windows.Forms.RadioButton optionA;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Timer usingFastTrack;
    }
}