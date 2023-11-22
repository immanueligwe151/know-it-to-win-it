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
    public partial class SelectingMode : Form
    {
        public SelectingMode()
        {
            InitializeComponent();
        }

        public static bool topicSelected = false;//returns a boolean value to tell the Play Game function in the main menu what to do in the
        //event that a topic wasn't selected and the dialog box was just closed
        int menuNumber = 1;//a counter for the different submenus that appear, automatically starts from 1
        int subMenu;//identifier fot the different submenus

        void SelectSubject()//first submenu
        {
            Selections();//calls the void. It makes the assignment before running any of the other lines of code as the options
            //are made immediately after the user has clicked the next or previous button
            subMenu = 1;//assigns the identifier 1 to the variable
            this.Text = "Select a subject";//text displayed on the menu bar
            labelText.Visible = true;//making sure the label is made visible
            labelText.Text = "Select a subject you want to revise:";//the text displayed by the label
            option1.Visible = true;//makes the first radio button visible
            option1.Text = "Mathematics";
            option2.Visible = false;
            option3.Visible = false;
            option4.Visible = false;//other radio buttons are not visible
            btn_GoBackward.Enabled = false;//the go back button is being disabled
        }

        void SelectTopic()//second submenu
        {
            Selections();//calls the void. It makes the assignment before running any of the other lines of code as the options
            //are made immediately after the user has clicked the next or previous button
            subMenu = 2;//assigns the identifier 1 to the variable
            this.Text = "Select a topic";//text displayed on the menu bar
            labelText.Visible = true;//making sure the label is made visible
            labelText.Text = "Select a topic you want to revise:";//the text displayed by the label
            option1.Visible = true;//makes the first radio button visible
            option1.Text = "Quadratic Equations";//this is only temporary
            option2.Visible = false;//makes this radio button visible
            option2.Text = "Topic 2";//this is also only temporary
            option3.Visible = false;//makes this radio button visible
            option3.Text = "Topic 3";//also temporary
            option4.Visible = false;//makes this radio button visible
            option4.Text = "Topic 4";//also temporary
            //as I mentioned earlier I'm doing only a maximum of 4 topics
            btn_GoBackward.Enabled = true;//the go back button is being abled
        }

        void SelectRevisionMode()//third submenu
        {
            Selections();//calls the void. It makes the assignment before running any of the other lines of code as the options
            //are made immediately after the user has clicked the next or previous button
            subMenu = 3;//assigns the identifier 1 to the variable
            this.Text = "Select a mode for learning";//text displayed on the menu bar
            labelText.Visible = true;//making sure the label is made visible
            labelText.Text = "How would you like to revise?";//the text displayed by the label
            option1.Visible = true;//makes the first radio button visible
            option1.Text = "Revision Mode";
            option2.Visible = true;//makes this radio button visible
            option2.Text = "Quiz Mode";
            option3.Visible = false;
            option4.Visible = false;//other radio buttons are not visible
        }

        void Selections()//this writes to the variables the selections made by the student
        {
            switch (subMenu)//going through the different submenu possibilities
            {
                case 1:
                    if (option1.Checked == true)//if the user selected Mathematics (the only subject available for the sake of the project)
                    {
                        Game.selectedSubject = "maths";//assigns the identifier to the variable
                    }
                    break;
                case 2:
                    if (option1.Checked == true)//if the first topic was selected
                    {
                        Game.selectedTopic = "quadratic";//the topic selected
                    }
                    else if (option2.Checked == true)//if the 2nd topic was selected
                    {
                        Game.selectedTopic = "topic 2";//the topic selected
                    }
                    else if (option3.Checked == true)//if the 3rd topic was selected
                    {
                        Game.selectedTopic = "topic 3";//the topic selected
                    }
                    else if (option4.Checked == true)//if the 4th topic was selected
                    {
                        Game.selectedTopic = "topic 4";//the topic selected
                    }
                    break;
                case 3:
                    if (option1.Checked == true)//if revision mode was selected
                    {
                        Game.selectedMode = "revision";//the mode selected
                    }
                    else if (option2.Checked == true)//if quiz mode was selected
                    {
                        Game.selectedMode = "quiz";//the mode selected
                    }
                    break;
            }
        }

        private void SelectingMode_Load(object sender, EventArgs e)//event for when the form loads
        {
            btn_GoBackward.Enabled = false;//still making sure that it is disabled
            SelectSubject();//calls the procedure
        }

        private void btn_GoForward_Click(object sender, EventArgs e)//when the next button is clicked
        {
            menuNumber++;//adds 1 to the counter
            switch (menuNumber)
            {
                case 2:
                    btn_GoBackward.Enabled = true;
                    SelectTopic();
                    break;
                case 3:
                    btn_GoForward.Text = "Done";
                    SelectRevisionMode();
                    break;
                case 4:
                    topicSelected = true;//the user is done with all their selections and ready to begin revising
                    Selections();//applies the final selections for the last submenu
                    this.Close();//closes this form
                    break;
            }
        }

        private void btn_GoBackward_Click(object sender, EventArgs e)//when the previous button is clicked
        {
            menuNumber--;//subtracts 1 from the counter
            switch (menuNumber)
            {
                case 1:
                    btn_GoBackward.Enabled = false;
                    SelectSubject();
                    break;
                case 2:
                    btn_GoBackward.Visible = true;
                    btn_GoForward.Text = "Next";
                    SelectTopic();
                    break;
            }
        }
    }
}