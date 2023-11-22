using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace know_it_to_win_it_program
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void btn_PlayGame_MouseHover(object sender, EventArgs e)//event for when the mouse hovers over the Play Game button
        {
            toolTip1.SetToolTip(btn_PlayGame, "Ready to play and test your knowledge? Click here to begin!");//the text to be displayed
        }

        private void btn_OpenStore_MouseHover(object sender, EventArgs e)//event for when the mouse hovers over the Store button
        {
            toolTip1.SetToolTip(btn_OpenStore, "Need a powerup or a new avatar? Come to the Store and make\nyour purchases to make your game experiece spectacular!");
        }

        private void btn_ChangeUsername_MouseHover(object sender, EventArgs e)//event for when the mouse hovers over the Change Username button
        {
            toolTip1.SetToolTip(btn_ChangeUsername, "Not feeling your old username? Come on here and change\nit to something more exciting!"); ;
        }

        private void btn_Quit_MouseHover(object sender, EventArgs e)//event for when the mouse hovers over the Quit button
        {
            toolTip1.SetToolTip(btn_Quit, "Click here to quit. Hope to see you soon!");
        }

        private void btn_Quit_Click(object sender, EventArgs e)//when the quit button is clicked
        {
            System.Threading.Thread.Sleep(500);//delays the response by 500 milliseconds
            MessageBox.Show("Thanks for coming on to play. See you soon!", "Bye!", MessageBoxButtons.OK, MessageBoxIcon.Information);//displaying farewell message
            System.Threading.Thread.Sleep(500);
            this.Close();//closes this form
        }

        private void btn_ChangeUsername_Click(object sender, EventArgs e)//when the Change Username button is clicked
        {
            User_Name userName = new User_Name();//creates the object
            userName.ShowDialog();//opens the Enter Username form as a dialog window
        }

        private void btn_OpenStore_Click(object sender, EventArgs e)//when the Store button is clicked
        {
            Store theStore = new Store();
            this.Hide();//hides this form
            theStore.ShowDialog();//displays the Store
            this.Show();//shows this form after the store has been closed
        }

        private void btn_PlayGame_Click(object sender, EventArgs e)//when the Play Game button is clicked
        {
            SelectingMode selectMode = new SelectingMode();
            selectMode.ShowDialog();
            if (SelectingMode.topicSelected == true)//if a topic has been selected.
            {
                this.Hide();//hides this form
                switch (Game.selectedMode)
                {
                    case "revision"://if revision mode was selected
                        RevisionMode revisionMode = new RevisionMode();
                        revisionMode.ShowDialog();//shows the revision mode form
                        break;
                    case "quiz"://if quiz mode was selected
                        QuizMode quizMode = new QuizMode();
                        quizMode.ShowDialog();
                        break;
                }
                this.Show();//shows this form after any opened form has been closed
            }
        }
    }
}
