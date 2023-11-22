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
    public partial class RevisionMode : Form
    {
        public RevisionMode()
        {
            InitializeComponent();
        }

        public static int slideNumber;//preset number of slides for each topic
        public static int slideCount;//counter for the slides

        private void RevisionMode_Load(object sender, EventArgs e)
        {
            slideCount = 1;//immediately 1 because it's the first slide of the topic
            switch (Game.selectedSubject)//going through the different possible options for selectedSubject
            {
                case "maths"://if maths was selected
                    switch (Game.selectedTopic)//going through the different topics
                    {
                        case "quadratic"://if the quadratic equations topic was chosen
                            slideNumber = 13;//there are 13 slides for the topic
                            topicDisplay.Text = "Quadratic Equations";
                            QuadraticEquations();
                            break;
                        case "topic 2":

                            break;
                        case "topic 3":

                            break;
                        case "topic 4":

                            break;
                    }
                    break;
            }
        }
        void QuadraticEquations()//void to display slides for the quadratic equations topic
        {
            slideCounter.Text = "Slide " + slideCount + " of " + slideNumber;//displaying the slide number
            switch (slideCount)
            {
                case 1:
                    goBackwardBtn.Enabled = false;//disables the backwards button so you can't go back
                    goForwardBtn.Enabled = true;//just double-checking it is enabled :)
                    slideBox.Image = Properties.Resources.quadratic_slide_1;//setting image for the slide
                    break;
                case 2:
                    goBackwardBtn.Enabled = true;//enables the button when on this slide :)
                    goForwardBtn.Enabled = true;//still making sure :)
                    slideBox.Image = Properties.Resources.quadratic_slide_2;//setting image for the slide
                    break;
                case 3:
                    goBackwardBtn.Enabled = true;
                    goForwardBtn.Enabled = true;
                    slideBox.Image = Properties.Resources.quadratic_slide_3;//setting image for the slide
                    break;
                case 4:
                    goBackwardBtn.Enabled = true;
                    goForwardBtn.Enabled = true;
                    slideBox.Image = Properties.Resources.quadratic_slide_4;//setting image for the slide
                    break;
                case 5:
                    goBackwardBtn.Enabled = true;
                    goForwardBtn.Enabled = true;
                    slideBox.Image = Properties.Resources.quadratic_slide_5;//setting image for the slide
                    break;
                case 6:
                    goBackwardBtn.Enabled = true;
                    goForwardBtn.Enabled = true;
                    slideBox.Image = Properties.Resources.quadratic_slide_6;//setting image for the slide
                    break;
                case 7:
                    goBackwardBtn.Enabled = true;
                    goForwardBtn.Enabled = true;
                    slideBox.Image = Properties.Resources.quadratic_slide_7;//setting image for the slide
                    break;
                case 8:
                    goBackwardBtn.Enabled = true;
                    goForwardBtn.Enabled = true;
                    slideBox.Image = Properties.Resources.quadratic_slide_8;//setting image for the slide
                    break;
                case 9:
                    goBackwardBtn.Enabled = true;
                    goForwardBtn.Enabled = true;
                    slideBox.Image = Properties.Resources.quadratic_slide_9;//setting image for the slide
                    break;
                case 10:
                    goBackwardBtn.Enabled = true;
                    goForwardBtn.Enabled = true;
                    slideBox.Image = Properties.Resources.quadratic_slide_10;//setting image for the slide
                    break;
                case 11:
                    goBackwardBtn.Enabled = true;
                    goForwardBtn.Enabled = true;
                    slideBox.Image = Properties.Resources.quadratic_slide_11;//setting image for the slide
                    break;
                case 12:
                    goBackwardBtn.Enabled = true;
                    goForwardBtn.Enabled = true;
                    slideBox.Image = Properties.Resources.quadratic_slide_12;//setting image for the slide
                    break;
                case 13:
                    goBackwardBtn.Enabled = true;
                    goForwardBtn.Enabled = false;//this is the last slide so no need to keep going forward
                    slideBox.Image = Properties.Resources.quadratic_slide_13;//setting image for the slide
                    break;
            }
        }

        private void goForwardBtn_Click(object sender, EventArgs e)
        {
            slideCount++;//adds one to the slide count
            switch (Game.selectedSubject)//going through each subject
            {
                case "maths"://if maths subject was selected
                    switch (Game.selectedTopic)//going through each topic
                    {
                        case "quadratic"://if quadratic equations topic has been selected
                            QuadraticEquations();//goes to the void for the quadratic equations topic
                            break;
                    }
                    break;
            }
        }

        private void goBackwardBtn_Click(object sender, EventArgs e)
        {
            slideCount--;//removes 1 from the slide count
            switch (Game.selectedSubject)//going through each subject
            {
                case "maths"://if maths was subject selected
                    switch (Game.selectedTopic)//going through each topic
                    {
                        case "quadratic"://if quadratic equations topic has been selected
                            QuadraticEquations();//goes to the void for the quadratic equations topic
                            break;
                    }
                    break;
            }
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
