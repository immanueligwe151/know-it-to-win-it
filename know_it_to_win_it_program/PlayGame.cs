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
    public partial class QuizMode : Form
    {
        public QuizMode()
        {
            InitializeComponent();
        }

        public int trackID;//variable to hold the random number generated for the track to be used
        public int cell;//variable to hold the number of cells the avatar is to move
        public int originalX;//variable to store the original x coordinate of the picture box
        public int originalY;//variable to store the original y coordinate of the picture box
        public bool stoppedMoving;//bool to determine when the avatar has stopped moving and the next question can be loaded

        //setting up the initial display
        private void QuizMode_Load(object sender, EventArgs e)
        {
            Game gameValues = new Game();
            gameValues.SettingDefaultValues();//runs the void in the Game class to set the default values
            Arrangements();
            DetermineTrack(gameValues);
            DetermineAvatar(gameValues);
            FetchPowerups(gameValues);
            System.Threading.Thread.Sleep(500);//sleeps by 500ms
            MessageBox.Show("Welcome, " + gameValues.ReadFromRegistry(gameValues.UserKey()) + ", to the Quiz Mode! Test yourself and your knowledge and see if you're smart enough to escape" +
                " the forest! The rules of the game are simple: answer a question and if you're right, your avatar moves forward" +
                " along the track! Answer all 10 questions correctly, and you're out! You can use powerups to help you should the" +
                " peril of the journey prove more unbearable than expected. All the best!", "Welcome to The Quiz Mode", MessageBoxButtons.OK, MessageBoxIcon.Information);
            SelectRandomQuestions();
        }
        private void Arrangements()//arranges the elements in the form; not really important, just to keep the code tidy :)
        {
            gemNumber.Location = new Point(845, 120);//positins the gem number label
            questionSkipNumber.Location = new Point(990, 120);//positions the question skipper number label
            fastTrackNumber.Location = new Point(1145, 120);//positions the fast track number label
            questionPictureBox.Size = new Size(370, 370);//sets the size of the question picture box
            questionPictureBox.Location = new Point(8, 120);//sets the location of the question picture box
            btn_DoneNext.Location = new Point(8, 500);//sets the location of the done button
            label1.Location = new Point(8, 540);//sets the location of the "Powerups" text
            hintGemActivate.Location = new Point(8, 570);//sets the location of the hint gem activation button
            questionSkipperActivate.Location = new Point(90, 570);//sets the location of the question skipper activation button
            fastTrackActivate.Location = new Point(180, 570);//sets the location of the fast track activation button
            optionA.Location = new Point(25, 346);//sets the position of radio button 1
            optionB.Location = new Point(25, 384);//sets the position of radio button 2
            optionC.Location = new Point(25, 422);//sets the position of radio button 3
            optionD.Location = new Point(25, 458);//sets the position of radio button 4
        }
        private void DetermineTrack(Game gameValues)//this determines which track is used for a particular game session
        {
            trackID = gameValues.randomTrackNumber();//assigns the random number here to be used by the program
            switch (trackID)
            {
                case 1:
                    this.BackgroundImage = Properties.Resources.background_with_track_1;//selects the background with track 1
                    avatarPictureBox.Location = new Point(410, 476);//positions the avatar at the start point of this track
                    Game.cellMoveList = new List<int> { 2, 3, 1, 5, 2, 3, 6, 2, 4, 2 };//assigns the random number of cells
                    //in here which will total up to the number of cells in this track minus 1, which is 31-1=30
                    break;
                case 2:
                    this.BackgroundImage = Properties.Resources.background_with_track_2;//selects the background with track 2
                    avatarPictureBox.Location = new Point(430, 300);//positions the avatar at the start point of this track
                    Game.cellMoveList = new List<int> { 3, 2, 4, 5, 2, 6, 3, 5, 3, 2 };//in this case all numbers sum up to 36-1=35
                    break;
                case 3:
                    this.BackgroundImage = Properties.Resources.background_with_track_3;//selects the background with track 3
                    avatarPictureBox.Location = new Point(415, 545);//positions the avatar at the start point of this track
                    Game.cellMoveList = new List<int> { 1, 3, 2, 1, 2, 4, 3, 2, 4, 3 };//in this case all numbers add up to 26-1=25
                    break;
            }
        }
        private void DetermineAvatar(Game gameValues)//selects the avatar to be displayed
        {
            if (bool.Parse(gameValues.ReadFromRegistry(gameValues.CasualEquipped())) == true)//if the casual player is equipped
            {
                avatarPictureBox.Image = Properties.Resources.casual_player_icon;//displays the casual player
            }
            else if (bool.Parse(gameValues.ReadFromRegistry(gameValues.KoolEquipped())) == true)//if the kool kid is equipped
            {
                avatarPictureBox.Image = Properties.Resources.kool_kid_icon;//displays the kool kid
            }
            else if (bool.Parse(gameValues.ReadFromRegistry(gameValues.FunEquipped())) == true)//if the fun guy is equipped
            {
                avatarPictureBox.Image = Properties.Resources.fun_guy_icon;//displays the fun guy
            }
        }
        private void FetchPowerups(Game gameValues)//fetches the values of each powerup into the game environment
        {
            gemNumber.Text = gameValues.ReadFromRegistry(gameValues.HintTotal());//fetches the number of hint gems from the registry
            questionSkipNumber.Text = gameValues.ReadFromRegistry(gameValues.SkipTotal());//fetches the number of question skippers from the registry
            fastTrackNumber.Text = gameValues.ReadFromRegistry(gameValues.FastTotal());//fetches the number of fast track powerups from the registry
        }

        //setting up the questions
        private void SelectRandomQuestions()//to randomly select a question
        {
            Game gameValues = new Game();
            optionA.Checked = false;
            optionB.Checked = false;
            optionC.Checked = false;
            optionD.Checked = false;//unchecks all the radio buttons so as to not confuse the user as the previously checked radio
            //button remains checked
            btn_DoneNext.Enabled = true;//enables the Done button if in the event it has been disabled by the moving of the avatar
            int randomQuestion;//stores the number for the randomly selected question
            Random rnd = new Random();
            randomQuestion = Game.questionList[rnd.Next(0, Game.questionList.Count - 1)];
            Game.questionList.Remove(randomQuestion);
            DisplayQuestions(randomQuestion);
            //randomQuestion = rnd.Next(1, 21);//generates a random number
            //if (Game.questionList.Contains(randomQuestion) == true)//checks if the random number exists in the list
            //{//if it does
            //    Game.questionList.Remove(randomQuestion);//removes the number from the list
            //    DisplayQuestions(randomQuestion);//goes to the DisplayQuestions void to display the question
            //}
            //else//if the number doesn't exist/has been removed from the list
            //{
            //    SelectRandomQuestions();//reruns the void; recursive ;)
            //}
        }
        private void DisplayQuestions(int randomQuestion)
        {
            Game gameValues = new Game();
            Game.triesNumber = 0;//sets this to 0
            switch (randomQuestion)//to switch between different question numbers
            {
                case 1://if it's question 1
                    switch (Game.selectedTopic)
                    {
                        case "quadratic":
                            Game.questionIdentifier = "quad1";//identifier for question 1 for quadratic equations; used in the Answers() void
                            questionPictureBox.Image = Properties.Resources.quadratic_question_1;//brings question 1 for quadratic equations
                            break;
                    }
                    break;
                case 2://if it's question 2
                    switch (Game.selectedTopic)
                    {
                        case "quadratic":
                            Game.questionIdentifier = "quad2";//identifier for question 2 for quadratic equations; used in the Answers() void and so on...
                            questionPictureBox.Image = Properties.Resources.quadratic_question_2;//brings question 2 for quadratic equations
                            break;
                    }
                    break;
                case 3://if it's question 3 and so on...
                    switch (Game.selectedTopic)
                    {
                        case "quadratic":
                            Game.questionIdentifier = "quad3";
                            questionPictureBox.Image = Properties.Resources.quadratic_question_3;//brings question 3 for quadratic equations and so on
                            break;
                    }
                    break;
                case 4:
                    switch (Game.selectedTopic)
                    {
                        case "quadratic":
                            Game.questionIdentifier = "quad4";
                            questionPictureBox.Image = Properties.Resources.quadratic_question_4;
                            break;
                    }
                    break;
                case 5:
                    switch (Game.selectedTopic)
                    {
                        case "quadratic":
                            Game.questionIdentifier = "quad5";
                            questionPictureBox.Image = Properties.Resources.quadratic_question_5;
                            break;
                    }
                    break;
                case 6:
                    switch (Game.selectedTopic)
                    {
                        case "quadratic":
                            Game.questionIdentifier = "quad6";
                            questionPictureBox.Image = Properties.Resources.quadratic_question_6;
                            break;
                    }
                    break;
                case 7:
                    switch (Game.selectedTopic)
                    {
                        case "quadratic":
                            Game.questionIdentifier = "quad7";
                            questionPictureBox.Image = Properties.Resources.quadratic_question_7;
                            break;
                    }
                    break;
                case 8:
                    switch (Game.selectedTopic)
                    {
                        case "quadratic":
                            Game.questionIdentifier = "quad8";
                            questionPictureBox.Image = Properties.Resources.quadratic_question_8;
                            break;
                    }
                    break;
                case 9:
                    switch (Game.selectedTopic)
                    {
                        case "quadratic":
                            Game.questionIdentifier = "quad9";
                            questionPictureBox.Image = Properties.Resources.quadratic_question_9;
                            break;
                    }
                    break;
                case 10:
                    switch (Game.selectedTopic)
                    {
                        case "quadratic":
                            Game.questionIdentifier = "quad10";
                            questionPictureBox.Image = Properties.Resources.quadratic_question_10;
                            break;
                    }
                    break;
                case 11:
                    switch (Game.selectedTopic)
                    {
                        case "quadratic":
                            Game.questionIdentifier = "quad11";
                            questionPictureBox.Image = Properties.Resources.quadratic_question_11;
                            break;
                    }
                    break;
                case 12:
                    switch (Game.selectedTopic)
                    {
                        case "quadratic":
                            Game.questionIdentifier = "quad12";
                            questionPictureBox.Image = Properties.Resources.quadratic_question_12;
                            break;
                    }
                    break;
                case 13:
                    switch (Game.selectedTopic)
                    {
                        case "quadratic":
                            Game.questionIdentifier = "quad13";
                            questionPictureBox.Image = Properties.Resources.quadratic_question_13;
                            break;
                    }
                    break;
                case 14:
                    switch (Game.selectedTopic)
                    {
                        case "quadratic":
                            Game.questionIdentifier = "quad14";
                            questionPictureBox.Image = Properties.Resources.quadratic_question_14;
                            break;
                    }
                    break;
                case 15:
                    switch (Game.selectedTopic)
                    {
                        case "quadratic":
                            Game.questionIdentifier = "quad15";
                            questionPictureBox.Image = Properties.Resources.quadratic_question_15;
                            break;
                    }
                    break;
                case 16:
                    switch (Game.selectedTopic)
                    {
                        case "quadratic":
                            Game.questionIdentifier = "quad16";
                            questionPictureBox.Image = Properties.Resources.quadratic_question_16;
                            break;
                    }
                    break;
                case 17:
                    switch (Game.selectedTopic)
                    {
                        case "quadratic":
                            Game.questionIdentifier = "quad17";
                            questionPictureBox.Image = Properties.Resources.quadratic_question_17;
                            break;
                    }
                    break;
                case 18:
                    switch (Game.selectedTopic)
                    {
                        case "quadratic":
                            Game.questionIdentifier = "quad18";
                            questionPictureBox.Image = Properties.Resources.quadratic_question_18;
                            break;
                    }
                    break;
                case 19:
                    switch (Game.selectedTopic)
                    {
                        case "quadratic":
                            Game.questionIdentifier = "quad19";
                            questionPictureBox.Image = Properties.Resources.quadratic_question_19;
                            break;
                    }
                    break;
                case 20:
                    switch (Game.selectedTopic)
                    {
                        case "quadratic":
                            Game.questionIdentifier = "quad20";
                            questionPictureBox.Image = Properties.Resources.quadratic_question_20;
                            break;
                    }
                    break;
            }
        }

        //determining answers
        private void btn_DoneNext_Click(object sender, EventArgs e)//when the Done button is clicked
        {
            Game gameValues = new Game();
            Game.triesNumber++;//adds one to triesNumber
            MarkAnswer();
        }
        public void MarkAnswer()//marks the questions
        {
            bool correct = false;//the boolean to determine if the answer is correct or not
            Game gameValues = new Game();//creating object for Game
            switch (Game.questionIdentifier)//going through 
            {
                case "quad1"://if the previous 
                    if (optionC.Checked == true)//option C is the correct answer for quad1
                    {
                        correct = true;
                    }
                    break;
                case "quad2":
                    if (optionB.Checked == true)
                    {
                        correct = true;
                    }
                    break;
                case "quad3":
                    if (optionB.Checked == true)
                    {
                        correct = true;
                    }
                    break;
                case "quad4":
                    if (optionC.Checked == true)
                    {
                        correct = true;
                    }
                    break;
                case "quad5":
                    if (optionD.Checked == true)
                    {
                        correct = true;
                    }
                    break;
                case "quad6":
                    if (optionC.Checked == true)
                    {
                        correct = true;
                    }
                    break;
                case "quad7":
                    if (optionC.Checked == true)
                    {
                        correct = true;
                    }
                    break;
                case "quad8":
                    if (optionB.Checked == true)
                    {
                        correct = true;
                    }
                    break;
                case "quad9":
                    if (optionB.Checked == true)
                    {
                        correct = true;
                    }
                    break;
                case "quad10":
                    if (optionB.Checked == true)
                    {
                        correct = true;
                    }
                    break;
                case "quad11":
                    if (optionD.Checked == true)
                    {
                        correct = true;
                    }
                    break;
                case "quad12":
                    if (optionA.Checked == true)
                    {
                        correct = true;
                    }
                    break;
                case "quad13":
                    if (optionD.Checked == true)
                    {
                        correct = true;
                    }
                    break;
                case "quad14":
                    if (optionA.Checked == true)
                    {
                        correct = true;
                    }
                    break;
                case "quad15":
                    if (optionC.Checked == true)
                    {
                        correct = true;
                    }
                    break;
                case "quad16":
                    if (optionB.Checked == true)
                    {
                        correct = true;
                    }
                    break;
                case "quad17":
                    if (optionA.Checked == true)
                    {
                        correct = true;
                    }
                    break;
                case "quad18":
                    if (optionD.Checked == true)
                    {
                        correct = true;
                    }
                    break;
                case "quad19":
                    if (optionB.Checked == true)
                    {
                        correct = true;
                    }
                    break;
                case "quad20":
                    if (optionD.Checked == true)
                    {
                        correct = true;
                    }
                    break;
            }//determines if the user got the answer
            if (gameValues.AddingResults(correct) == true)
            {
                btn_DoneNext.Enabled = false;//disables this button so the user makes no action while the avatar is moving
                MoveAvatar(gameValues, false);
                Game.triesNumber = 0;//sets this back to default)
            }
            else
            {
                if (Game.triesNumber == 3)//if AddingResults() is false and all tries have been exhausted
                {
                    Game.triesNumber = 0;//sets this back to default
                    NextStep(false);
                }
            }

        }
        public void NextStep(bool gameEnded)//going to the next step after a question has been answered
        {
            Game gameValues = new Game();
            if (Game.questionCount == 10 || gameEnded == true)//if 10 questions have been answered or the game was ended
            {
                gameValues.DisplayEndResults();//calls this void to display the end results
                this.Close();//closes this form
            }
            else if (Game.questionCount < 10 && usingFastTrack.Enabled == false)//if 10 questions haven't been answered yet by the user and the fast track isn't in use
            {
                System.Threading.Thread.Sleep(500);
                SelectRandomQuestions();
            }
        }

        //moving the avatar
        private void MoveAvatar(Game gameValues, bool fastTrackUsed)
        {
            stoppedMoving = false;//assigns the value of false so that it is changed from true before the avatar is moved again
            cell = gameValues.randomCellNumber();//gets the random number
            Game.totalCoinsEarned = Game.totalCoinsEarned + cell;//adds the randomly generated cell number to the total of coins earned
            if (fastTrackUsed == false)//if the Fast Track is not in use
            {
                MessageBox.Show("Congratulations on getting this question right! Now you get to move " + cell.ToString() + " cells across the track!",
                  "Move along!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            originalX = avatarPictureBox.Location.X;//x position of the picture box
            originalY = avatarPictureBox.Location.Y;//y position of the picture
            switch (trackID)//depending on which track is in use
            {
                case 1://if track 1 is in use
                    if ((originalX >= 410 && originalX < 590 && originalY == 476) || (originalX >= 590 && originalX < 960 && originalY == 306) || (originalX >= 960 && originalX < 1200 && originalY == 536))
                    //determining the positions at which the avatar is to move to the right
                    {
                        movingRightTimer.Start();//starts the event which will enable the avatar to move to the right
                    }
                    else if ((originalX == 590 && originalY <= 476 && originalY > 306) || (originalX == 1200 && originalY <= 536 && originalY > 366))
                    //determining the positions at which the avatar is to move up
                    {
                        movingUpTimer.Start();//starts the event which will enable the avatar to move up
                    }
                    else if ((originalX == 960 && originalY >= 306 && originalY < 536))
                    //determining the positions at which the avatar is to move down
                    {
                        movingDownTimer.Start();//starts the event which will enable the avatar to move down
                    }
                    break;

                case 2://if track 2 is in use
                    if ((originalX >= 430 && originalX < 560 && originalY == 300) || (originalX >= 560 && originalX < 840 && originalY == 580) || (originalX >= 840 && originalX < 1120 && originalY == 180) || (originalX == 1120 && originalY == 550))
                    //positions of the avatar at which it is to move to the right
                    {
                        movingRightTimer.Start();
                    }
                    else if ((originalX == 560 && originalY >= 300 && originalY < 580) || (originalX == 1120 && originalY >= 180 && originalY < 550))
                    //positions of the avatar at which it is to move down
                    {
                        movingDownTimer.Start();
                    }
                    else if ((originalX == 840 && originalY <= 580 && originalY > 180))
                    {
                        movingUpTimer.Start();
                    }
                    break;

                case 3://if track 3 is in use
                    if ((originalX == 415 && originalY == 545) || (originalY == 365 && originalX >= 495 && originalX < 635) || (originalX >= 635 && originalX < 985 && originalY == 215) || (originalX >= 985 && originalX < 1125 && originalY == 355) || (originalX == 1125 && originalY == 545))
                    {
                        movingRightTimer.Start();
                    }
                    else if ((originalX == 985 && originalY >= 215 && originalY < 355) || (originalX == 1125 && originalY >= 355 && originalY < 545))
                    {
                        movingDownTimer.Start();
                    }
                    else if ((originalX == 495 && originalY <= 545 && originalY > 365) || (originalX == 635 && originalY <= 365 && originalY > 215))
                    {
                        movingUpTimer.Start();
                    }
                    break;
            }
        }
        private void ContinueMovement(bool movingRight, bool movingUp, bool movingDown, int remainingCells)//this is to continue the movement
            //depending on which direction the avatar is to continue moving
        {
            StopTimers();//calls this to stop the current timer in use
            cell = remainingCells;//assigns the remaining number of cells to cell
            if (movingRight == true && movingUp == false && movingDown == false)//if the avatar is to continue by moving right
            {
                movingRightTimer.Start();//starts this timer
            }
            else if (movingRight == false && movingUp == true && movingDown == false)//if the avatar is to continue by moving up
            {
                movingUpTimer.Start();//starts this timer
            }
            else if (movingRight == false && movingUp == false && movingDown == true)//if the avatar is to continue by moving down
            {
                movingDownTimer.Start();
            }
            else//if the avatar is to just stop moving
            {
                stoppedMoving = true;//sets this to true
                NextStep(false);
            }
        }
        public void StopTimers()//this is just to stop the timers
        {
            originalX = avatarPictureBox.Location.X;//sets the new x-location to originalX
            originalY = avatarPictureBox.Location.Y;//sets the new y-location to originalY
            stoppedMoving = false;//sets this to false by default, is set to true if the avatar has stopped moving
            if (movingRightTimer.Enabled == true)//if movingRightTimer is currently in use
            {
                movingRightTimer.Stop();
            }
            else if (movingUpTimer.Enabled == true)//if movingUpTimer is currently in use
            {
                movingUpTimer.Stop();
            }
            else if (movingDownTimer.Enabled == true)//if movingUpTimer is currently in use
            {
                movingDownTimer.Stop();
            }
        }
        private void movingRightTimer_Tick(object sender, EventArgs e)//timer for moving the avatar to the right
        {
            int x = avatarPictureBox.Location.X;
            int y = avatarPictureBox.Location.Y;//setting the x and y co-ordinates
            avatarPictureBox.Location = new Point(x + 10, y);//moves the avatar to the right by increasing its x coordinate value
            switch (cell)//switching between all the possible numbers that could be assigned to cell, which is 1 through 6
            {
                case 1://if 1 is assigned to cell
                    switch (trackID)
                    {
                        case 1:
                            switch (originalX)
                            {
                                case 410:
                                    if (avatarPictureBox.Location.X == 480)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 480:
                                    if (avatarPictureBox.Location.X == 530)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 530:
                                    if (avatarPictureBox.Location.X == 590)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 590:
                                    if (avatarPictureBox.Location.X == 630)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 630:
                                    if (avatarPictureBox.Location.X == 710)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 710:
                                    if (avatarPictureBox.Location.X == 750)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 750:
                                    if (avatarPictureBox.Location.X == 790)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 790:
                                    if (avatarPictureBox.Location.X == 830)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 830:
                                    if (avatarPictureBox.Location.X == 870)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 870:
                                    if (avatarPictureBox.Location.X == 910)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 910:
                                    if (avatarPictureBox.Location.X == 960)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 960:
                                    if (avatarPictureBox.Location.X == 1020)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 1020:
                                    if (avatarPictureBox.Location.X == 1080)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 1080:
                                    if (avatarPictureBox.Location.X == 1140)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 1140:
                                    if (avatarPictureBox.Location.X == 1200)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                            }
                            break;
                        case 2://1 may not exist in cellMoveList for track 2, but however it might still need to move 1 cell to
                               //complete a previously started movement so this will be needed as well
                            switch (originalX)
                            {//showing only the possible values of originalX at where it will need to complete a movement with 1 cell left
                                case 560:
                                    if (avatarPictureBox.Location.X == 630)
                                    {
                                        ContinueMovement(false, false, false, 0);//goes here to determine that the timer is to be stopped
                                    }
                                    break;
                                case 840:
                                    if (avatarPictureBox.Location.X == 910)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 1120:
                                    if (avatarPictureBox.Location.X == 1190)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                            }
                            break;
                        case 3:
                            switch (originalX)
                            {
                                case 415:
                                    if (avatarPictureBox.Location.X == 495)
                                    {
                                        ContinueMovement(false, false, false, 0);//goes here to determine that the timer is to be stopped
                                    }
                                    break;
                                case 495:
                                    if (avatarPictureBox.Location.X == 565)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 565:
                                    if (avatarPictureBox.Location.X == 635)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 635:
                                    if (avatarPictureBox.Location.X == 705)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 705:
                                    if (avatarPictureBox.Location.X == 775)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 775:
                                    if (avatarPictureBox.Location.X == 845)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 845:
                                    if (avatarPictureBox.Location.X == 915)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 915:
                                    if (avatarPictureBox.Location.X == 985)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 985:
                                    if (avatarPictureBox.Location.X == 1055)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 1055:
                                    if (avatarPictureBox.Location.X == 1125)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 1125:
                                    if (avatarPictureBox.Location.X == 1205)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                            }
                            break;
                    }
                    break;
                case 2:
                    switch (trackID)
                    {
                        case 1:
                            switch (originalX)
                            {
                                case 410:
                                    if (avatarPictureBox.Location.X == 530)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 480:
                                    if (avatarPictureBox.Location.X == 590)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 530:
                                    if (avatarPictureBox.Location.X == 590)
                                    {
                                        ContinueMovement(false, true, false, 1);
                                    }
                                    break;
                                case 590:
                                    if (avatarPictureBox.Location.X == 670)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 630:
                                    if (avatarPictureBox.Location.X == 710)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 670:
                                    if (avatarPictureBox.Location.X == 750)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 710:
                                    if (avatarPictureBox.Location.X == 790)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 750:
                                    if (avatarPictureBox.Location.X == 830)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 790:
                                    if (avatarPictureBox.Location.X == 870)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 830:
                                    if (avatarPictureBox.Location.X == 910)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 870:
                                    if (avatarPictureBox.Location.X == 960)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 910:
                                    if (avatarPictureBox.Location.X == 960)
                                    {
                                        ContinueMovement(false, false, true, 1);
                                    }
                                    break;
                                case 960:
                                    if (avatarPictureBox.Location.X == 1080)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 1020:
                                    if (avatarPictureBox.Location.X == 1140)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 1080:
                                    if (avatarPictureBox.Location.X == 1200)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 1140:
                                    if (avatarPictureBox.Location.X == 1200)
                                    {
                                        ContinueMovement(false, true, false, 1);
                                    }
                                    break;
                            }
                            break;
                        case 2:
                            switch (originalX)
                            {
                                case 430:
                                    if (avatarPictureBox.Location.X == 560)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 490:
                                    if (avatarPictureBox.Location.X == 560)
                                    {
                                        ContinueMovement(false, false, true, 1);
                                    }
                                    break;
                                case 560:
                                    if (avatarPictureBox.Location.X == 700)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 630:
                                    if (avatarPictureBox.Location.X == 770)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 700:
                                    if (avatarPictureBox.Location.X == 840)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 770:
                                    if (avatarPictureBox.Location.X == 840)
                                    {
                                        ContinueMovement(false, true, false, 1);
                                    }
                                    break;
                                case 840:
                                    if (avatarPictureBox.Location.X == 980)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 910:
                                    if (avatarPictureBox.Location.X == 1050)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 980:
                                    if (avatarPictureBox.Location.X == 1120)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 1050:
                                    if (avatarPictureBox.Location.X == 1120)
                                    {
                                        ContinueMovement(false, false, true, 1);
                                    }
                                    break;
                            }
                            break;
                        case 3:
                            switch (originalX)
                            {
                                case 415:
                                    if (avatarPictureBox.Location.X == 495)
                                    {
                                        ContinueMovement(false, true, false, 1);
                                    }
                                    break;
                                case 495:
                                    if (avatarPictureBox.Location.X == 635)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 565:
                                    if (avatarPictureBox.Location.X == 635)
                                    {
                                        ContinueMovement(false, true, false, 1);
                                    }
                                    break;
                                case 635:
                                    if (avatarPictureBox.Location.X == 775)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 705:
                                    if (avatarPictureBox.Location.X == 845)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 775:
                                    if (avatarPictureBox.Location.X == 915)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 845:
                                    if (avatarPictureBox.Location.X == 985)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 915:
                                    if (avatarPictureBox.Location.X == 985)
                                    {
                                        ContinueMovement(false, false, true, 1);
                                    }
                                    break;
                                case 985:
                                    if (avatarPictureBox.Location.X == 1125)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 1055:
                                    if (avatarPictureBox.Location.X == 1125)
                                    {
                                        ContinueMovement(false, false, true, 1);
                                    }
                                    break;
                            }
                            break;
                    }
                    break;
                case 3:
                    switch (trackID)
                    {
                        case 1:
                            switch (originalX)
                            {
                                case 410:
                                    if (avatarPictureBox.Location.X == 590)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 480:
                                    if (avatarPictureBox.Location.X == 590)
                                    {
                                        ContinueMovement(false, true, false, 1);
                                    }
                                    break;
                                case 530:
                                    if (avatarPictureBox.Location.X == 590)
                                    {
                                        ContinueMovement(false, true, false, 2);
                                    }
                                    break;
                                case 590:
                                    if (avatarPictureBox.Location.X == 710)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 630:
                                    if (avatarPictureBox.Location.X == 750)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 670:
                                    if (avatarPictureBox.Location.X == 790)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 710:
                                    if (avatarPictureBox.Location.X == 830)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 750:
                                    if (avatarPictureBox.Location.X == 870)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 790:
                                    if (avatarPictureBox.Location.X == 910)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 830:
                                    if (avatarPictureBox.Location.X == 960)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 870:
                                    if (avatarPictureBox.Location.X == 960)
                                    {
                                        ContinueMovement(false, false, true, 1);
                                    }
                                    break;
                                case 910:
                                    if (avatarPictureBox.Location.X == 960)
                                    {
                                        ContinueMovement(false, false, true, 2);
                                    }
                                    break;
                                case 960:
                                    if (avatarPictureBox.Location.X == 1140)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 1020:
                                    if (avatarPictureBox.Location.X == 1200)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 1080:
                                    if (avatarPictureBox.Location.X == 1200)
                                    {
                                        ContinueMovement(false, true, false, 1);
                                    }
                                    break;
                                case 1140:
                                    if (avatarPictureBox.Location.X == 1200)
                                    {
                                        ContinueMovement(false, true, false, 2);
                                    }
                                    break;
                            }
                            break;
                        case 2:
                            switch (originalX)
                            {
                                case 430:
                                    if (avatarPictureBox.Location.X == 560)
                                    {
                                        ContinueMovement(false, false, true, 1);
                                    }
                                    break;
                                case 490:
                                    if (avatarPictureBox.Location.X == 560)
                                    {
                                        ContinueMovement(false, false, true, 2);
                                    }
                                    break;
                                case 560:
                                    if (avatarPictureBox.Location.X == 770)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 630:
                                    if (avatarPictureBox.Location.X == 840)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 700:
                                    if (avatarPictureBox.Location.X == 840)
                                    {
                                        ContinueMovement(false, true, false, 1);
                                    }
                                    break;
                                case 770:
                                    if (avatarPictureBox.Location.X == 840)
                                    {
                                        ContinueMovement(false, true, false, 2);
                                    }
                                    break;
                                case 840:
                                    if (avatarPictureBox.Location.X == 1050)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 910:
                                    if (avatarPictureBox.Location.X == 1120)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 980:
                                    if (avatarPictureBox.Location.X == 1120)
                                    {
                                        ContinueMovement(false, false, true, 1);
                                    }
                                    break;
                                case 1050:
                                    if (avatarPictureBox.Location.X == 1120)
                                    {
                                        ContinueMovement(false, false, true, 2);
                                    }
                                    break;
                            }
                            break;
                        case 3:
                            switch (originalX)
                            {
                                case 415:
                                    if (avatarPictureBox.Location.X == 495)
                                    {
                                        ContinueMovement(false, true, false, 2);
                                    }
                                    break;
                                case 495:
                                    if (avatarPictureBox.Location.X == 635)
                                    {
                                        ContinueMovement(false, true, false, 1);
                                    }
                                    break;
                                case 565:
                                    if (avatarPictureBox.Location.X == 635)
                                    {
                                        ContinueMovement(false, true, false, 2);
                                    }
                                    break;
                                case 635:
                                    if (avatarPictureBox.Location.X == 845)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 705:
                                    if (avatarPictureBox.Location.X == 915)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 775:
                                    if (avatarPictureBox.Location.X == 985)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 845:
                                    if (avatarPictureBox.Location.X == 985)
                                    {
                                        ContinueMovement(false, false, true, 1);
                                    }
                                    break;
                                case 915:
                                    if (avatarPictureBox.Location.X == 985)
                                    {
                                        ContinueMovement(false, false, true, 2);
                                    }
                                    break;
                                case 985:
                                    if (avatarPictureBox.Location.X == 1125)
                                    {
                                        ContinueMovement(false, false, true, 1);
                                    }
                                    break;
                                case 1055:
                                    if (avatarPictureBox.Location.X == 1125)
                                    {
                                        ContinueMovement(false, false, true, 2);
                                    }
                                    break;
                            }
                            break;
                    }
                    break;
                case 4:
                    switch (trackID)
                    {
                        case 1:
                            switch (originalX)
                            {
                                case 410:
                                    if (avatarPictureBox.Location.X == 590)
                                    {
                                        ContinueMovement(false, true, false, 1);
                                    }
                                    break;
                                case 480:
                                    if (avatarPictureBox.Location.X == 590)
                                    {
                                        ContinueMovement(false, true, false, 2);
                                    }
                                    break;
                                case 530:
                                    if (avatarPictureBox.Location.X == 590)
                                    {
                                        ContinueMovement(false, true, false, 3);
                                    }
                                    break;
                                case 590:
                                    if (avatarPictureBox.Location.X == 750)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 630:
                                    if (avatarPictureBox.Location.X == 790)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 670:
                                    if (avatarPictureBox.Location.X == 830)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 710:
                                    if (avatarPictureBox.Location.X == 870)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 750:
                                    if (avatarPictureBox.Location.X == 910)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 790:
                                    if (avatarPictureBox.Location.X == 960)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 830:
                                    if (avatarPictureBox.Location.X == 960)
                                    {
                                        ContinueMovement(false, false, true, 1);
                                    }
                                    break;
                                case 870:
                                    if (avatarPictureBox.Location.X == 960)
                                    {
                                        ContinueMovement(false, false, true, 2);
                                    }
                                    break;
                                case 910:
                                    if (avatarPictureBox.Location.X == 960)
                                    {
                                        ContinueMovement(false, false, true, 3);
                                    }
                                    break;
                                case 960:
                                    if (avatarPictureBox.Location.X == 1200)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 1020:
                                    if (avatarPictureBox.Location.X == 1200)
                                    {
                                        ContinueMovement(false, true, false, 1);
                                    }
                                    break;
                                case 1080:
                                    if (avatarPictureBox.Location.X == 1200)
                                    {
                                        ContinueMovement(false, true, false, 2);
                                    }
                                    break;
                                case 1140:
                                    if (avatarPictureBox.Location.X == 1200)
                                    {
                                        ContinueMovement(false, true, false, 3);
                                    }
                                    break;
                            }
                            break;
                        case 2:
                            switch (originalX)
                        {
                            case 430:
                                if (avatarPictureBox.Location.X == 560)
                                {
                                    ContinueMovement(false, false, true, 2);
                                }
                                break;
                            case 490:
                                if (avatarPictureBox.Location.X == 560)
                                {
                                    ContinueMovement(false, false, true, 3);
                                }
                                break;
                            case 560:
                                if (avatarPictureBox.Location.X == 840)
                                {
                                    ContinueMovement(false, false, false, 0);
                                }
                                break;
                            case 630:
                                if (avatarPictureBox.Location.X == 840)
                                {
                                    ContinueMovement(false, true, false, 1);
                                }
                                break;
                            case 700:
                                if (avatarPictureBox.Location.X == 840)
                                {
                                    ContinueMovement(false, true, false, 2);
                                }
                                break;
                            case 770:
                                if (avatarPictureBox.Location.X == 840)
                                {
                                    ContinueMovement(false, true, false, 3);
                                }
                                break;
                            case 840:
                                if (avatarPictureBox.Location.X == 1120)
                                {
                                    ContinueMovement(false, false, false, 0);
                                }
                                break;
                            case 910:
                                if (avatarPictureBox.Location.X == 1120)
                                {
                                    ContinueMovement(false, false, true, 1);
                                }
                                break;
                            case 980:
                                if (avatarPictureBox.Location.X == 1120)
                                {
                                    ContinueMovement(false, false, true, 2);
                                }
                                break;
                            case 1050:
                                if (avatarPictureBox.Location.X == 1120)
                                {
                                    ContinueMovement(false, false, true, 3);
                                }
                                break;
                        }
                            break;
                        case 3:
                            switch (originalX)
                            {
                                case 415:
                                    if (avatarPictureBox.Location.X == 495)
                                    {
                                        ContinueMovement(false, true, false, 3);
                                    }
                                    break;
                                case 495:
                                    if (avatarPictureBox.Location.X == 635)
                                    {
                                        ContinueMovement(false, true, false, 2);
                                    }
                                    break;
                                case 565:
                                    if (avatarPictureBox.Location.X == 635)
                                    {
                                        ContinueMovement(false, true, false, 3);
                                    }
                                    break;
                                case 635:
                                    if (avatarPictureBox.Location.X == 915)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 705:
                                    if (avatarPictureBox.Location.X == 985)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 775:
                                    if (avatarPictureBox.Location.X == 985)
                                    {
                                        ContinueMovement(false, false, true, 1);
                                    }
                                    break;
                                case 845:
                                    if (avatarPictureBox.Location.X == 985)
                                    {
                                        ContinueMovement(false, false, true, 2);
                                    }
                                    break;
                                case 915:
                                    if (avatarPictureBox.Location.X == 985)
                                    {
                                        ContinueMovement(false, false, true, 3);
                                    }
                                    break;
                                case 985:
                                    if (avatarPictureBox.Location.X == 1125)
                                    {
                                        ContinueMovement(false, false, true, 2);
                                    }
                                    break;
                                case 1055:
                                    if (avatarPictureBox.Location.X == 1125)
                                    {
                                        ContinueMovement(false, false, true, 3);
                                    }
                                    break;
                            }
                            break;
                    }
                    break;
                case 5:
                    switch (trackID)
                    {
                        case 1:
                            switch (originalX)
                            {
                                case 410:
                                    if (avatarPictureBox.Location.X == 590)
                                    {
                                        ContinueMovement(false, true, false, 2);
                                    }
                                    break;
                                case 480:
                                    if (avatarPictureBox.Location.X == 590)
                                    {
                                        ContinueMovement(false, true, false, 3);
                                    }
                                    break;
                                case 530:
                                    if (avatarPictureBox.Location.X == 590)
                                    {
                                        ContinueMovement(false, true, false, 4);
                                    }
                                    break;
                                case 590:
                                    if (avatarPictureBox.Location.X == 790)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 630:
                                    if (avatarPictureBox.Location.X == 830)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 670:
                                    if (avatarPictureBox.Location.X == 870)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 710:
                                    if (avatarPictureBox.Location.X == 910)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 750:
                                    if (avatarPictureBox.Location.X == 960)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 790:
                                    if (avatarPictureBox.Location.X == 960)
                                    {
                                        ContinueMovement(false, false, true, 1);
                                    }
                                    break;
                                case 830:
                                    if (avatarPictureBox.Location.X == 960)
                                    {
                                        ContinueMovement(false, false, false, 2);
                                    }
                                    break;
                                case 870:
                                    if (avatarPictureBox.Location.X == 960)
                                    {
                                        ContinueMovement(false, false, true, 3);
                                    }
                                    break;
                                case 910:
                                    if (avatarPictureBox.Location.X == 960)
                                    {
                                        ContinueMovement(false, false, true, 4);
                                    }
                                    break;
                                case 960:
                                    if (avatarPictureBox.Location.X == 1200)
                                    {
                                        ContinueMovement(false, true, false, 1);
                                    }
                                    break;
                                case 1020:
                                    if (avatarPictureBox.Location.X == 1200)
                                    {
                                        ContinueMovement(false, true, false, 2);
                                    }
                                    break;
                                case 1080:
                                    if (avatarPictureBox.Location.X == 1200)
                                    {
                                        ContinueMovement(false, true, false, 3);
                                    }
                                    break;
                                case 1140:
                                    if (avatarPictureBox.Location.X == 1200)
                                    {
                                        ContinueMovement(false, true, false, 4);
                                    }
                                    break;
                            }
                            break;
                        case 2:
                            switch (originalX)
                            {
                                case 430:
                                    if (avatarPictureBox.Location.X == 560)
                                    {
                                        ContinueMovement(false, false, true, 3);
                                    }
                                    break;
                                case 490:
                                    if (avatarPictureBox.Location.X == 560)
                                    {
                                        ContinueMovement(false, false, true, 4);
                                    }
                                    break;
                                case 560:
                                    if (avatarPictureBox.Location.X == 840)
                                    {
                                        ContinueMovement(false, true, false, 1);
                                    }
                                    break;
                                case 630:
                                    if (avatarPictureBox.Location.X == 840)
                                    {
                                        ContinueMovement(false, true, false, 2);
                                    }
                                    break;
                                case 700:
                                    if (avatarPictureBox.Location.X == 840)
                                    {
                                        ContinueMovement(false, true, false, 3);
                                    }
                                    break;
                                case 770:
                                    if (avatarPictureBox.Location.X == 840)
                                    {
                                        ContinueMovement(false, true, false, 4);
                                    }
                                    break;
                                case 840:
                                    if (avatarPictureBox.Location.X == 1120)
                                    {
                                        ContinueMovement(false, false, true, 1);
                                    }
                                    break;
                                case 910:
                                    if (avatarPictureBox.Location.X == 1120)
                                    {
                                        ContinueMovement(false, false, true, 2);
                                    }
                                    break;
                                case 980:
                                    if (avatarPictureBox.Location.X == 1120)
                                    {
                                        ContinueMovement(false, false, true, 3);
                                    }
                                    break;
                                case 1050:
                                    if (avatarPictureBox.Location.X == 1120)
                                    {
                                        ContinueMovement(false, false, true, 4);
                                    }
                                    break;
                            }
                            break;
                    }
                    break;
                case 6:
                    switch (trackID)
                    {
                        case 1:
                            switch (originalX)
                            {
                                case 410:
                                    if (avatarPictureBox.Location.X == 590)
                                    {
                                        ContinueMovement(false, true, false, 3);
                                    }
                                    break;
                                case 480:
                                    if (avatarPictureBox.Location.X == 590)
                                    {
                                        ContinueMovement(false, true, false, 4);
                                    }
                                    break;
                                case 530:
                                    if (avatarPictureBox.Location.X == 590)
                                    {
                                        ContinueMovement(false, true, false, 5);
                                    }
                                    break;
                                case 590:
                                    if (avatarPictureBox.Location.X == 830)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 630:
                                    if (avatarPictureBox.Location.X == 870)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 670:
                                    if (avatarPictureBox.Location.X == 910)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 710:
                                    if (avatarPictureBox.Location.X == 960)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 750:
                                    if (avatarPictureBox.Location.X == 960)
                                    {
                                        ContinueMovement(false, false, true, 1);
                                    }
                                    break;
                                case 790:
                                    if (avatarPictureBox.Location.X == 960)
                                    {
                                        ContinueMovement(false, false, true, 2);
                                    }
                                    break;
                                case 830:
                                    if (avatarPictureBox.Location.X == 960)
                                    {
                                        ContinueMovement(false, false, true, 3);
                                    }
                                    break;
                                case 870:
                                    if (avatarPictureBox.Location.X == 960)
                                    {
                                        ContinueMovement(false, false, true, 4);
                                    }
                                    break;
                                case 910:
                                    if (avatarPictureBox.Location.X == 960)
                                    {
                                        ContinueMovement(false, false, true, 5);
                                    }
                                    break;
                                case 960:
                                    if (avatarPictureBox.Location.X == 1200)
                                    {
                                        ContinueMovement(false, true, false, 2);
                                    }
                                    break;
                                case 1020:
                                    if (avatarPictureBox.Location.X == 1200)
                                    {
                                        ContinueMovement(false, true, false, 3);
                                    }
                                    break;
                                case 1080:
                                    if (avatarPictureBox.Location.X == 1200)
                                    {
                                        ContinueMovement(false, true, false, 4);
                                    }
                                    break;
                            }
                            break;
                        case 2:
                            switch (originalX)
                            {
                                case 430:
                                    if (avatarPictureBox.Location.X == 560)
                                    {
                                        ContinueMovement(false, false, true, 4);
                                    }
                                    break;
                                case 490:
                                    if (avatarPictureBox.Location.X == 560)
                                    {
                                        ContinueMovement(false, false, true, 5);
                                    }
                                    break;
                                case 560:
                                    if (avatarPictureBox.Location.X == 840)
                                    {
                                        ContinueMovement(false, true, false, 2);
                                    }
                                    break;
                                case 630:
                                    if (avatarPictureBox.Location.X == 840)
                                    {
                                        ContinueMovement(false, true, false, 3);
                                    }
                                    break;
                                case 700:
                                    if (avatarPictureBox.Location.X == 840)
                                    {
                                        ContinueMovement(false, true, false, 4);
                                    }
                                    break;
                                case 770:
                                    if (avatarPictureBox.Location.X == 840)
                                    {
                                        ContinueMovement(false, true, false, 5);
                                    }
                                    break;
                                case 840:
                                    if (avatarPictureBox.Location.X == 1120)
                                    {
                                        ContinueMovement(false, false, true, 2);
                                    }
                                    break;
                                case 910:
                                    if (avatarPictureBox.Location.X == 1120)
                                    {
                                        ContinueMovement(false, false, true, 3);
                                    }
                                    break;
                                case 980:
                                    if (avatarPictureBox.Location.X == 1120)
                                    {
                                        ContinueMovement(false, false, true, 4);
                                    }
                                    break;
                                case 1050:
                                    if (avatarPictureBox.Location.X == 1120)
                                    {
                                        ContinueMovement(false, false, true, 5);
                                    }
                                    break;
                            }
                            break;
                    }
                    break;
            }
        }
        private void movingDownTimer_Tick(object sender, EventArgs e)//timer for moving avatar down
        {
            int x = avatarPictureBox.Location.X;
            int y = avatarPictureBox.Location.Y;//setting the x and y co-ordinates
            avatarPictureBox.Location = new Point(x, y + 10);//moves the avatar to the right by increasing its y coordinate value
            switch (cell)//switching between all the possible numbers that could be assigned to cell, which is 1 through 6
            {
                case 1:
                    switch (trackID)
                    {
                        case 1:
                            switch (originalY)
                            {
                                case 306:
                                    if (avatarPictureBox.Location.Y == 346)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 346:
                                    if (avatarPictureBox.Location.Y == 386)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 386:
                                    if (avatarPictureBox.Location.Y == 426)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 426:
                                    if (avatarPictureBox.Location.Y == 466)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 466:
                                    if (avatarPictureBox.Location.Y == 496)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 496:
                                    if (avatarPictureBox.Location.Y == 536)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                            }
                            break;
                        case 2://1 doesn't show up in cellMoveList for track 2, but there is an instance at which the avatar will need
                            //to move down by one cell to complete a previous movement so I'll include it in here as well
                            switch (originalY)
                            {
                                case 300:
                                    if (avatarPictureBox.Location.Y == 350 && avatarPictureBox.Location.X == 560)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    else if (avatarPictureBox.Location.Y == 340 && avatarPictureBox.Location.X == 1120)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 180:
                                    if (avatarPictureBox.Location.Y == 220)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                            }
                            break;
                        case 3:
                            switch (originalY)
                            {
                                case 215:
                                    if (avatarPictureBox.Location.Y == 265)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 265:

                                    if (avatarPictureBox.Location.Y == 315)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 315:

                                    if (avatarPictureBox.Location.Y == 355)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 355:

                                    if (avatarPictureBox.Location.Y == 405)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 405:

                                    if (avatarPictureBox.Location.Y == 455)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 455:

                                    if (avatarPictureBox.Location.Y == 495)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 495:

                                    if (avatarPictureBox.Location.Y == 545)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                            }
                            break;
                    }
                    break;
                case 2:
                    switch (trackID)
                    {
                        case 1:
                            switch (originalY)
                            {
                                case 306:
                                    if (avatarPictureBox.Location.Y == 386)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 346:
                                    if (avatarPictureBox.Location.Y == 426)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 386:
                                    if (avatarPictureBox.Location.Y == 466)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 426:
                                    if (avatarPictureBox.Location.Y == 496)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 466:
                                    if (avatarPictureBox.Location.Y == 536)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 496:
                                    if (avatarPictureBox.Location.Y == 536)
                                    {
                                        ContinueMovement(true, false, false, 1);
                                    }
                                    break;
                            }
                            break;
                        case 2:
                            switch (originalY)
                            {
                                case 300:
                                    if (avatarPictureBox.Location.X == 560 && avatarPictureBox.Location.Y == 400)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    else if (avatarPictureBox.Location.X == 1120 && avatarPictureBox.Location.Y == 380)//due to a slight difference in the size of the different cells at points (560, 300) and (1120, 560)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 350:
                                    if (avatarPictureBox.Location.Y == 440)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 400:
                                    if (avatarPictureBox.Location.Y == 490)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 440:
                                    if (avatarPictureBox.Location.Y == 540)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 490:
                                    if (avatarPictureBox.Location.Y == 580)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 540:
                                    if (avatarPictureBox.Location.Y == 580)
                                    {
                                        ContinueMovement(true, false, false, 1);
                                    }
                                    break;
                                case 180:
                                    if (avatarPictureBox.Location.Y == 260)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 220:
                                    if (avatarPictureBox.Location.Y == 300)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 260:
                                    if (avatarPictureBox.Location.Y == 340)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 340:
                                    if (avatarPictureBox.Location.Y == 420)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 380:
                                    if (avatarPictureBox.Location.Y == 460)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 420:
                                    if (avatarPictureBox.Location.Y == 510)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 460:
                                    if (avatarPictureBox.Location.Y == 550)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 510:
                                    if (avatarPictureBox.Location.Y == 550)
                                    {
                                        ContinueMovement(true, false, false, 1);
                                    }
                                    break;
                            }
                            break;
                        case 3:
                            switch (originalY)
                            {
                                case 215:
                                    if (avatarPictureBox.Location.Y == 315)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 265:

                                    if (avatarPictureBox.Location.Y == 355)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 315:

                                    if (avatarPictureBox.Location.Y == 355)
                                    {
                                        ContinueMovement(true, false, false, 1);
                                    }
                                    break;
                                case 355:

                                    if (avatarPictureBox.Location.Y == 455)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 405:

                                    if (avatarPictureBox.Location.Y == 495)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 455:

                                    if (avatarPictureBox.Location.Y == 545)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 495:

                                    if (avatarPictureBox.Location.Y == 545)
                                    {
                                        ContinueMovement(true, false, false, 1);
                                    }
                                    break;
                            }
                            break;
                    }
                    break;
                case 3:
                    switch (trackID)
                    {
                        case 1:
                            switch (originalY)
                            {
                                case 306:
                                    if (avatarPictureBox.Location.Y == 426)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 346:
                                    if (avatarPictureBox.Location.Y == 466)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 386:
                                    if (avatarPictureBox.Location.Y == 496)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 426:
                                    if (avatarPictureBox.Location.Y == 536)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 466:
                                    if (avatarPictureBox.Location.Y == 536)
                                    {
                                        ContinueMovement(true, false, false, 1);
                                    }
                                    break;
                                case 496:
                                    if (avatarPictureBox.Location.Y == 536)
                                    {
                                        ContinueMovement(true, false, false, 2);
                                    }
                                    break;
                            }
                            break;
                        case 2:
                            switch (originalY)
                            {
                                case 300:
                                    if (avatarPictureBox.Location.X == 560 && avatarPictureBox.Location.Y == 440)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    else if (avatarPictureBox.Location.X == 1120 && avatarPictureBox.Location.Y == 420)//due to a slight difference in the size of the different cells at points (560, 300) and (1120, 560)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 350:
                                    if (avatarPictureBox.Location.Y == 490)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 400:
                                    if (avatarPictureBox.Location.Y == 540)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 440:
                                    if (avatarPictureBox.Location.Y == 580)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 490:
                                    if (avatarPictureBox.Location.Y == 580)
                                    {
                                        ContinueMovement(true, false, false, 1);
                                    }
                                    break;
                                case 540:
                                    if (avatarPictureBox.Location.Y == 580)
                                    {
                                        ContinueMovement(true, false, false, 2);
                                    }
                                    break;
                                case 180:
                                    if (avatarPictureBox.Location.Y == 300)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 220:
                                    if (avatarPictureBox.Location.Y == 340)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 260:
                                    if (avatarPictureBox.Location.Y == 380)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 340:
                                    if (avatarPictureBox.Location.Y == 460)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 380:
                                    if (avatarPictureBox.Location.Y == 510)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 420:
                                    if (avatarPictureBox.Location.Y == 550)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 460:
                                    if (avatarPictureBox.Location.Y == 550)
                                    {
                                        ContinueMovement(true, false, false, 1);
                                    }
                                    break;
                                case 510:
                                    if (avatarPictureBox.Location.Y == 550)
                                    {
                                        ContinueMovement(true, false, false, 2);
                                    }
                                    break;

                            }
                            break;
                        case 3:
                            switch (originalY)
                            {
                                case 215:
                                    if (avatarPictureBox.Location.Y == 355)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 265:

                                    if (avatarPictureBox.Location.Y == 355)
                                    {
                                        ContinueMovement(true, false, false, 1);
                                    }
                                    break;
                                case 315:

                                    if (avatarPictureBox.Location.Y == 355)
                                    {
                                        ContinueMovement(true, false, false, 2);
                                    }
                                    break;
                                case 355:

                                    if (avatarPictureBox.Location.Y == 495)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 405:

                                    if (avatarPictureBox.Location.Y == 545)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 455:

                                    if (avatarPictureBox.Location.Y == 545)
                                    {
                                        ContinueMovement(true, false, false, 1);
                                    }
                                    break;
                                case 495:

                                    if (avatarPictureBox.Location.Y == 545)
                                    {
                                        ContinueMovement(true, false, false, 2);
                                    }
                                    break;
                            }
                            break;
                    }
                    break;
                case 4:
                    switch (trackID)
                    {
                        case 1:
                            switch (originalY)
                            {
                                case 306:
                                    if (avatarPictureBox.Location.Y == 466)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 346:
                                    if (avatarPictureBox.Location.Y == 496)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 386:
                                    if (avatarPictureBox.Location.Y == 536)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 426:
                                    if (avatarPictureBox.Location.Y == 536)
                                    {
                                        ContinueMovement(true, false, false, 1);
                                    }
                                    break;
                                case 466:
                                    if (avatarPictureBox.Location.Y == 536)
                                    {
                                        ContinueMovement(true, false, false, 2);
                                    }
                                    break;
                                case 496:
                                    if (avatarPictureBox.Location.Y == 536)
                                    {
                                        ContinueMovement(true, false, false, 3);
                                    }
                                    break;
                            }
                            break;
                        case 2:
                            switch (originalY)
                            {
                                case 300:
                                    if (avatarPictureBox.Location.X == 560 && avatarPictureBox.Location.Y == 490)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    else if (avatarPictureBox.Location.X == 1120 && avatarPictureBox.Location.Y == 460)//due to a slight difference in the size of the different cells at points (560, 300) and (1120, 560)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 350:
                                    if (avatarPictureBox.Location.Y == 540)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 400:
                                    if (avatarPictureBox.Location.Y == 580)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 440:
                                    if (avatarPictureBox.Location.Y == 580)
                                    {
                                        ContinueMovement(true, false, false, 1);
                                    }
                                    break;
                                case 490:
                                    if (avatarPictureBox.Location.Y == 580)
                                    {
                                        ContinueMovement(true, false, false, 2);
                                    }
                                    break;
                                case 540:
                                    if (avatarPictureBox.Location.Y == 580)
                                    {
                                        ContinueMovement(true, false, false, 3);
                                    }
                                    break;
                                case 180:
                                    if (avatarPictureBox.Location.Y == 340)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 220:
                                    if (avatarPictureBox.Location.Y == 380)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 260:
                                    if (avatarPictureBox.Location.Y == 420)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 340:
                                    if (avatarPictureBox.Location.Y == 510)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 380:
                                    if (avatarPictureBox.Location.Y == 550)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 420:
                                    if (avatarPictureBox.Location.Y == 550)
                                    {
                                        ContinueMovement(true, false, false, 1);
                                    }
                                    break;
                                case 460:
                                    if (avatarPictureBox.Location.Y == 550)
                                    {
                                        ContinueMovement(true, false, false, 2);
                                    }
                                    break;
                                case 510:
                                    if (avatarPictureBox.Location.Y == 550)
                                    {
                                        ContinueMovement(true, false, false, 3);
                                    }
                                    break;

                            }
                            break;
                        case 3:
                            switch (originalY)
                            {
                                case 215:
                                    if (avatarPictureBox.Location.Y == 355)
                                    {
                                        ContinueMovement(true, false, false, 1);
                                    }
                                    break;
                                case 265:

                                    if (avatarPictureBox.Location.Y == 355)
                                    {
                                        ContinueMovement(true, false, false, 2);
                                    }
                                    break;
                                case 315:

                                    if (avatarPictureBox.Location.Y == 355)
                                    {
                                        ContinueMovement(true, false, false, 3);
                                    }
                                    break;
                                case 355:

                                    if (avatarPictureBox.Location.Y == 545)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 405:

                                    if (avatarPictureBox.Location.Y == 545)
                                    {
                                        ContinueMovement(true, false, false, 1);
                                    }
                                    break;
                            }
                            break;
                    }
                    break;
                case 5:
                    switch (trackID)
                    {
                        case 1:
                            switch (originalY)
                            {
                                case 306:
                                    if (avatarPictureBox.Location.Y == 496)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 346:
                                    if (avatarPictureBox.Location.Y == 536)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 386:
                                    if (avatarPictureBox.Location.Y == 536)
                                    {
                                        ContinueMovement(true, false, false, 1);
                                    }
                                    break;
                                case 426:
                                    if (avatarPictureBox.Location.Y == 536)
                                    {
                                        ContinueMovement(true, false, false, 2);
                                    }
                                    break;
                                case 466:
                                    if (avatarPictureBox.Location.Y == 536)
                                    {
                                        ContinueMovement(true, false, false, 3);
                                    }
                                    break;
                                case 496:
                                    if (avatarPictureBox.Location.Y == 536)
                                    {
                                        ContinueMovement(true, false, false, 4);
                                    }
                                    break;
                            }
                            break;
                        case 2:
                            switch (originalY)
                            {
                                case 300:
                                    if (avatarPictureBox.Location.X == 560 && avatarPictureBox.Location.Y == 540)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    else if (avatarPictureBox.Location.X == 1120 && avatarPictureBox.Location.Y == 510)//due to a slight difference in the size of the different cells at points (560, 300) and (1120, 560)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 350:
                                    if (avatarPictureBox.Location.Y == 580)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 400:
                                    if (avatarPictureBox.Location.Y == 580)
                                    {
                                        ContinueMovement(true, false, false, 1);
                                    }
                                    break;
                                case 440:
                                    if (avatarPictureBox.Location.Y == 580)
                                    {
                                        ContinueMovement(true, false, false, 2);
                                    }
                                    break;
                                case 490:
                                    if (avatarPictureBox.Location.Y == 580)
                                    {
                                        ContinueMovement(true, false, false, 3);
                                    }
                                    break;
                                case 540:
                                    if (avatarPictureBox.Location.Y == 580)
                                    {
                                        ContinueMovement(true, false, false, 4);
                                    }
                                    break;
                                case 180:
                                    if (avatarPictureBox.Location.Y == 380)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 220:
                                    if (avatarPictureBox.Location.Y == 420)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 260:
                                    if (avatarPictureBox.Location.Y == 460)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 340:
                                    if (avatarPictureBox.Location.Y == 550)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 380:
                                    if (avatarPictureBox.Location.Y == 550)
                                    {
                                        ContinueMovement(true, false, false, 1);
                                    }
                                    break;
                            }
                            break;
                    }
                    break;
                case 6:
                    switch (trackID)
                    {
                        case 1:
                            switch (originalY)
                            {
                                case 306:
                                    if (avatarPictureBox.Location.Y == 536)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 346:
                                    if (avatarPictureBox.Location.Y == 536)
                                    {
                                        ContinueMovement(true, false, false, 1);
                                    }
                                    break;
                                case 386:
                                    if (avatarPictureBox.Location.Y == 536)
                                    {
                                        ContinueMovement(true, false, false, 2);
                                    }
                                    break;
                                case 426:
                                    if (avatarPictureBox.Location.Y == 536)
                                    {
                                        ContinueMovement(true, false, false, 3);
                                    }
                                    break;
                                case 466:
                                    if (avatarPictureBox.Location.Y == 536)
                                    {
                                        ContinueMovement(true, false, false, 4);
                                    }
                                    break;
                                case 496:
                                    if (avatarPictureBox.Location.Y == 536)
                                    {
                                        ContinueMovement(true, false, false, 5);
                                    }
                                    break;
                            }
                            break;
                        case 2:
                            switch (originalY)
                            {
                                case 300:
                                    if (avatarPictureBox.Location.X == 560 && avatarPictureBox.Location.Y == 580)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    else if (avatarPictureBox.Location.X == 1120 && avatarPictureBox.Location.Y == 550)//due to a slight difference in the size of the different cells at points (560, 300) and (1120, 560)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 350:
                                    if (avatarPictureBox.Location.Y == 580)
                                    {
                                        ContinueMovement(true, false, false, 1);
                                    }
                                    break;
                                case 400:
                                    if (avatarPictureBox.Location.Y == 580)
                                    {
                                        ContinueMovement(true, false, false, 2);
                                    }
                                    break;
                                case 440:
                                    if (avatarPictureBox.Location.Y == 580)
                                    {
                                        ContinueMovement(true, false, false, 3);
                                    }
                                    break;
                                case 490:
                                    if (avatarPictureBox.Location.Y == 580)
                                    {
                                        ContinueMovement(true, false, false, 4);
                                    }
                                    break;
                                case 540:
                                    if (avatarPictureBox.Location.Y == 580)
                                    {
                                        ContinueMovement(true, false, false, 5);
                                    }
                                    break;
                                case 180:
                                    if (avatarPictureBox.Location.Y == 420)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 220:
                                    if (avatarPictureBox.Location.Y == 460)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 260:
                                    if (avatarPictureBox.Location.Y == 510)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 340:
                                    if (avatarPictureBox.Location.Y == 550)
                                    {
                                        ContinueMovement(true, false, false, 1);
                                    }
                                    break;
                            }
                            break;
                    }
                    break;
            }
        }
        private void movingUpTimer_Tick(object sender, EventArgs e)//timer for moving up
        {
            int x = avatarPictureBox.Location.X;
            int y = avatarPictureBox.Location.Y;//setting the x and y co-ordinates
            avatarPictureBox.Location = new Point(x, y - 10);//moves the avatar to the right by decreasing its y coordinate value
            switch (cell)//switching between all the possible numbers that could be assigned to cell, which is 1 through 6
            {
                case 1:
                    switch (trackID)
                    {
                        case 1:
                            switch (originalY)
                            {
                                case 476:
                                    if (avatarPictureBox.Location.Y == 436)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 436:
                                    if (avatarPictureBox.Location.Y == 396)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 396:
                                    if (avatarPictureBox.Location.Y == 356)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 356:
                                    if (avatarPictureBox.Location.Y == 306)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 536:
                                    if (avatarPictureBox.Location.Y == 496)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 496:
                                    if (avatarPictureBox.Location.Y == 456)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 456:
                                    if (avatarPictureBox.Location.Y == 416)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 416:
                                    if (avatarPictureBox.Location.Y == 366)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                            }
                            break;
                        case 2:
                            switch (originalY)
                            {
                                case 580://the only condition at which cell could be 1 for track 2
                                    if (avatarPictureBox.Location.Y == 540)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                            }
                            break;
                        case 3:
                            switch (originalY)
                            {
                                case 545:
                                    if (avatarPictureBox.Location.Y == 495)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 495:
                                    if (avatarPictureBox.Location.Y == 455)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 455:
                                    if (avatarPictureBox.Location.Y == 405)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 405:
                                    if (avatarPictureBox.Location.Y == 365)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 365:
                                    if (avatarPictureBox.Location.Y == 315)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 315:
                                    if (avatarPictureBox.Location.Y == 265)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 265:
                                    if (avatarPictureBox.Location.Y == 215)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                            }
                            break;
                    }
                    break;
                case 2:
                    switch (trackID)
                    {
                        case 1:
                            switch (originalY)
                            {
                                case 476:
                                    if (avatarPictureBox.Location.Y == 396)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 436:
                                    if (avatarPictureBox.Location.Y == 356)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 396:
                                    if (avatarPictureBox.Location.Y == 306)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 356:
                                    if (avatarPictureBox.Location.Y == 306)
                                    {
                                        ContinueMovement(true, false, false, 1);
                                    }
                                    break;
                                case 536:
                                    if (avatarPictureBox.Location.Y == 456)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 496:
                                    if (avatarPictureBox.Location.Y == 416)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 456:
                                    if (avatarPictureBox.Location.Y == 366)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                            }
                            break;
                        case 2:
                            switch (originalY)
                            {
                                case 580:
                                    if (avatarPictureBox.Location.Y == 490)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 540:
                                    if (avatarPictureBox.Location.Y == 450)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 490:
                                    if (avatarPictureBox.Location.Y == 400)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 450:
                                    if (avatarPictureBox.Location.Y == 360)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 400:
                                    if (avatarPictureBox.Location.Y == 310)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 360:
                                    if (avatarPictureBox.Location.Y == 270)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 310:
                                    if (avatarPictureBox.Location.Y == 220)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 270:
                                    if (avatarPictureBox.Location.Y == 180)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 220:
                                    if (avatarPictureBox.Location.Y == 180)
                                    {
                                        ContinueMovement(true, false, false, 1);
                                    }
                                    break;
                            }
                            break;
                        case 3:
                            switch (originalY)
                            {
                                case 545:
                                    if (avatarPictureBox.Location.Y == 455)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 495:
                                    if (avatarPictureBox.Location.Y == 405)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 455:
                                    if (avatarPictureBox.Location.Y == 365)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 405:
                                    if (avatarPictureBox.Location.Y == 365)
                                    {
                                        ContinueMovement(true, false, false, 1);
                                    }
                                    break;
                                case 365:
                                    if (avatarPictureBox.Location.Y == 265)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 315:
                                    if (avatarPictureBox.Location.Y == 215)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 265:
                                    if (avatarPictureBox.Location.Y == 215)
                                    {
                                        ContinueMovement(true, false, false, 1);
                                    }
                                    break;
                            }
                            break;
                    }
                    break;
                case 3:
                    switch (trackID)
                    {
                        case 1:
                            switch (originalY)
                            {
                                case 476:
                                    if (avatarPictureBox.Location.Y == 356)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 436:
                                    if (avatarPictureBox.Location.Y == 306)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 396:
                                    if (avatarPictureBox.Location.Y == 306)
                                    {
                                        ContinueMovement(true, false, false, 1);
                                    }
                                    break;
                                case 356:
                                    if (avatarPictureBox.Location.Y == 306)
                                    {
                                        ContinueMovement(true, false, false, 2);
                                    }
                                    break;
                                case 536:
                                    if (avatarPictureBox.Location.Y == 416)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 496:
                                    if (avatarPictureBox.Location.Y == 366)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                            }
                            break;
                        case 2:
                            switch (originalY)
                            {
                                case 580:
                                    if (avatarPictureBox.Location.Y == 450)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 540:
                                    if (avatarPictureBox.Location.Y == 400)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 490:
                                    if (avatarPictureBox.Location.Y == 360)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 450:
                                    if (avatarPictureBox.Location.Y == 310)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 400:
                                    if (avatarPictureBox.Location.Y == 270)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 360:
                                    if (avatarPictureBox.Location.Y == 220)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 310:
                                    if (avatarPictureBox.Location.Y == 180)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 270:
                                    if (avatarPictureBox.Location.Y == 180)
                                    {
                                        ContinueMovement(true, false, false, 1);
                                    }
                                    break;
                                case 220:
                                    if (avatarPictureBox.Location.Y == 180)
                                    {
                                        ContinueMovement(true, false, false, 2);
                                    }
                                    break;
                            }
                            break;
                        case 3:
                            switch (originalY)
                            {
                                case 545:
                                    if (avatarPictureBox.Location.Y == 405)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 495:
                                    if (avatarPictureBox.Location.Y == 365)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 455:
                                    if (avatarPictureBox.Location.Y == 365)
                                    {
                                        ContinueMovement(true, false, false, 1);
                                    }
                                    break;
                                case 405:
                                    if (avatarPictureBox.Location.Y == 365)
                                    {
                                        ContinueMovement(true, false, false, 2);
                                    }
                                    break;
                                case 365:
                                    if (avatarPictureBox.Location.Y == 215)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 315:
                                    if (avatarPictureBox.Location.Y == 215)
                                    {
                                        ContinueMovement(true, false, false, 1);
                                    }
                                    break;
                                case 265:
                                    if (avatarPictureBox.Location.Y == 215)
                                    {
                                        ContinueMovement(true, false, false, 2);
                                    }
                                    break;
                            }
                            break;
                    }
                    break;
                case 4:
                    switch (trackID)
                    {
                        case 1:
                            switch (originalY)
                            {
                                case 476:
                                    if (avatarPictureBox.Location.Y == 306)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 436:
                                    if (avatarPictureBox.Location.Y == 306)
                                    {
                                        ContinueMovement(true, false, false, 1);
                                    }
                                    break;
                                case 396:
                                    if (avatarPictureBox.Location.Y == 306)
                                    {
                                        ContinueMovement(true, false, false, 2);
                                    }
                                    break;
                                case 356:
                                    if (avatarPictureBox.Location.Y == 306)
                                    {
                                        ContinueMovement(true, false, false, 3);
                                    }
                                    break;
                                case 536:
                                    if (avatarPictureBox.Location.Y == 366)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                            }
                            break;
                        case 2:
                            switch (originalY)
                            {
                                case 580:
                                    if (avatarPictureBox.Location.Y == 400)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 540:
                                    if (avatarPictureBox.Location.Y == 360)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 490:
                                    if (avatarPictureBox.Location.Y == 310)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 450:
                                    if (avatarPictureBox.Location.Y == 270)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 400:
                                    if (avatarPictureBox.Location.Y == 220)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 360:
                                    if (avatarPictureBox.Location.Y == 180)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 310:
                                    if (avatarPictureBox.Location.Y == 180)
                                    {
                                        ContinueMovement(true, false, false, 1);
                                    }
                                    break;
                                case 270:
                                    if (avatarPictureBox.Location.Y == 180)
                                    {
                                        ContinueMovement(true, false, false, 2);
                                    }
                                    break;
                                case 220:
                                    if (avatarPictureBox.Location.Y == 180)
                                    {
                                        ContinueMovement(true, false, false, 3);
                                    }
                                    break;
                            }
                            break;
                        case 3:
                            switch (originalY)
                            {
                                case 545:
                                    if (avatarPictureBox.Location.Y == 365)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 495:
                                    if (avatarPictureBox.Location.Y == 365)
                                    {
                                        ContinueMovement(true, false, false, 1);
                                    }
                                    break;
                                case 455:
                                    if (avatarPictureBox.Location.Y == 365)
                                    {
                                        ContinueMovement(true, false, false, 2);
                                    }
                                    break;
                                case 405:
                                    if (avatarPictureBox.Location.Y == 365)
                                    {
                                        ContinueMovement(true, false, false, 3);
                                    }
                                    break;
                                case 365:
                                    if (avatarPictureBox.Location.Y == 215)
                                    {
                                        ContinueMovement(true, false, false, 1);
                                    }
                                    break;
                                case 315:
                                    if (avatarPictureBox.Location.Y == 215)
                                    {
                                        ContinueMovement(true, false, false, 2);
                                    }
                                    break;
                                case 265:
                                    if (avatarPictureBox.Location.Y == 215)
                                    {
                                        ContinueMovement(true, false, false, 3);
                                    }
                                    break;
                            }
                            break;
                    }
                    break;
                case 5:
                    switch (trackID)
                    {
                        case 1:
                            switch (originalY)
                            {
                                case 476:
                                    if (avatarPictureBox.Location.Y == 306)
                                    {
                                        ContinueMovement(true, false, false, 1);
                                    }
                                    break;
                                case 436:
                                    if (avatarPictureBox.Location.Y == 306)
                                    {
                                        ContinueMovement(true, false, false, 2);
                                    }
                                    break;
                                case 396:
                                    if (avatarPictureBox.Location.Y == 306)
                                    {
                                        ContinueMovement(true, false, false, 3);
                                    }
                                    break;
                                case 356:
                                    if (avatarPictureBox.Location.Y == 306)
                                    {
                                        ContinueMovement(true, false, false, 4);
                                    }
                                    break;
                            }
                            break;
                        case 2:
                            switch (originalY)
                            {
                                case 580:
                                    if (avatarPictureBox.Location.Y == 360)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 540:
                                    if (avatarPictureBox.Location.Y == 310)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 490:
                                    if (avatarPictureBox.Location.Y == 270)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 450:
                                    if (avatarPictureBox.Location.Y == 220)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 400:
                                    if (avatarPictureBox.Location.Y == 180)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 360:
                                    if (avatarPictureBox.Location.Y == 180)
                                    {
                                        ContinueMovement(true, false, false, 1);
                                    }
                                    break;
                                case 310:
                                    if (avatarPictureBox.Location.Y == 180)
                                    {
                                        ContinueMovement(true, false, false, 2);
                                    }
                                    break;
                                case 270:
                                    if (avatarPictureBox.Location.Y == 180)
                                    {
                                        ContinueMovement(true, false, false, 3);
                                    }
                                    break;
                                case 220:
                                    if (avatarPictureBox.Location.Y == 180)
                                    {
                                        ContinueMovement(true, false, false, 4);
                                    }
                                    break;
                            }
                            break;
                    }
                    break;
                case 6:
                    switch (trackID)
                    {
                        case 1:
                            switch (originalY)
                            {
                                case 476:
                                    if (avatarPictureBox.Location.Y == 306)
                                    {
                                        ContinueMovement(true, false, false, 2);
                                    }
                                    break;
                                case 436:
                                    if (avatarPictureBox.Location.Y == 306)
                                    {
                                        ContinueMovement(true, false, false, 3);
                                    }
                                    break;
                                case 396:
                                    if (avatarPictureBox.Location.Y == 306)
                                    {
                                        ContinueMovement(true, false, false, 4);
                                    }
                                    break;
                                case 356:
                                    if (avatarPictureBox.Location.Y == 306)
                                    {
                                        ContinueMovement(true, false, false, 5);
                                    }
                                    break;
                            }
                            break;
                        case 2:
                            switch (originalY)
                            {
                                case 580:
                                    if (avatarPictureBox.Location.Y == 310)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 540:
                                    if (avatarPictureBox.Location.Y == 270)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 490:
                                    if (avatarPictureBox.Location.Y == 220)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 450:
                                    if (avatarPictureBox.Location.Y == 180)
                                    {
                                        ContinueMovement(false, false, false, 0);
                                    }
                                    break;
                                case 400:
                                    if (avatarPictureBox.Location.Y == 180)
                                    {
                                        ContinueMovement(true, false, false, 1);
                                    }
                                    break;
                                case 360:
                                    if (avatarPictureBox.Location.Y == 180)
                                    {
                                        ContinueMovement(true, false, false, 2);
                                    }
                                    break;
                                case 310:
                                    if (avatarPictureBox.Location.Y == 180)
                                    {
                                        ContinueMovement(true, false, false, 3);
                                    }
                                    break;
                                case 270:
                                    if (avatarPictureBox.Location.Y == 180)
                                    {
                                        ContinueMovement(true, false, false, 4);
                                    }
                                    break;
                                case 220:
                                    if (avatarPictureBox.Location.Y == 180)
                                    {
                                        ContinueMovement(true, false, false, 5);
                                    }
                                    break;
                            }
                            break;
                    }
                    break;
            }
        }

        //using powerups
        private void hintGemActivate_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(hintGemActivate, "Stuck? Need a hint? Use the Hint Gem to see a hint\nto help you out of a quandary.");
        }
        private void questionSkipperActivate_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(questionSkipperActivate, "Use this to skip a question! This can only be used\ntwice in a game session tho...");
        }
        private void fastTrackActivate_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(fastTrackActivate, "Use this to skip this question and the next\nquestion, and you still get to move across the track!\nHow cool is that...?");
        }
        private void hintGemActivate_Click(object sender, EventArgs e)//if the user is going to use the hint gem
        {
            Game g = new Game();
            int gemNumber = int.Parse(g.ReadFromRegistry(g.HintTotal()));//fetches the total number of hint gems from the registry
            if (gemNumber > 0)//the user has at least 1 Hint Gem
            {
                DialogResult message = MessageBox.Show("Are you sure you need to use a hint? This will use up" +
                    " 1 Hint Gem!", "Use a Hint Gem", MessageBoxButtons.YesNo, MessageBoxIcon.Question);//asking the user if they need to use the gem
                if (message == DialogResult.Yes)
                {
                    HintWindow window = new HintWindow();
                    window.ShowDialog();//displays the hint as a dialog window
                    Game.usedGemTotal++;//adds 1 to the total used gems
                    gemNumber--;//subtracts 1 from the total number of gems
                    g.WriteIntoRegistry(g.HintTotal(), gemNumber.ToString());//writes the new value into the registry
                    FetchPowerups(g);//displays the new value using this void which already does that
                }
            }
            else//if there are no gems
            {
                MessageBox.Show("Sorry, you don't have any Hint Gems. Purchase some from the Store and try again.", "Insufficient Hint Gems", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void questionSkipperActivate_Click(object sender, EventArgs e)//if the user is going to use the question skipper
        {
            Game gameValues = new Game();
            int skipperCount = int.Parse(gameValues.ReadFromRegistry(gameValues.SkipTotal()));//gets the total question skippers stored in the registry
            if (skipperCount > 0)
            {
                if (Game.skipperUseCount < 2)
                {
                    DialogResult message = MessageBox.Show("Are you sure you want to use the Question Skipper? You have "
                    + (2 - Game.skipperUseCount).ToString() + " out of 2 uses remaining.", "Use the Question Skipper",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (message == DialogResult.Yes)//if the user selected yes
                    {
                        Game.skipperUseCount++;//adds 1 to the usage count
                        skipperCount--;//removes one from the total number of question skippers
                        gameValues.WriteIntoRegistry(gameValues.SkipTotal(), skipperCount.ToString());//writes the new value into the registry
                        FetchPowerups(gameValues);//displays the new number of powerups
                        SelectRandomQuestions();//goes to choose another random question without adding 1 to questionCount
                    }
                }
                else//when the skipper can't be used again in this session
                {
                    MessageBox.Show("Sorry, you can't use the Question Skipper again in this session.", "Uses exhausted", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
            else//if the user doesn't have at least 1 question skipper
            {
                MessageBox.Show("Sorry, you don't have any Question Skippers. Purchase some from the Store and try again.", "Insufficient Question Skippers", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void fastTrackActivate_Click(object sender, EventArgs e)
        {
            Game gameValues = new Game();
            int fastTrackCount = int.Parse(gameValues.ReadFromRegistry(gameValues.FastTotal()));//gets the total fast track from the registry
            if (fastTrackCount > 0)//if there are enough fast track powerups
            {
                if (Game.fastTrackUsed == false && Game.questionCount < 9)//the user hasn't yet used it and the user isn't at the last question
                {
                    DialogResult message = MessageBox.Show("Are you sure you want to use the Fast Track? You won't be able to use it again in this session!",
                        "Use the Fast Track", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (message == DialogResult.Yes)//if the user selected yes
                    {
                        Game.questionCount = Game.questionCount + 2;//adds 2 to the number of total answered question
                        Game.firstTryAnswers = Game.firstTryAnswers + 2;//adds two on here so that the user earns coins from here
                        Game.fastTrackUsed = true;//sets thhis as used so that it can't be used again
                        fastTrackCount--;//subtracts 1 from the total count
                        gameValues.WriteIntoRegistry(gameValues.FastTotal(), fastTrackCount.ToString());//writes the new total into the registry
                        btn_DoneNext.Enabled = false;//makes this disabled
                        FetchPowerups(gameValues);//calls this to display the number of remaining powerups
                        MoveAvatar(gameValues, true);//starts to move the avatar for the first time
                        usingFastTrack.Start();//starts the timer for the using of the fast track
                    }
                }
                else if (Game.fastTrackUsed == true && Game.questionCount < 9)//if it has been used
                {
                    MessageBox.Show("Sorry, you can't use the Fast Track again as you've already used it.", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (Game.questionCount == 9)//if the user is almost done
                {
                    MessageBox.Show("Sorry, you can't use this since you're almost done answering the questions!", "You're almost done!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else//insufficient fast track
            {
                MessageBox.Show("Sorry, you don't have any Fast Track powerups. Purchase some from the Store and try again.", "Insufficient Fast Track", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void usingFastTrack_Tick(object sender, EventArgs e)
        {
            if (stoppedMoving == true)
            {
                Game g = new Game();
                usingFastTrack.Stop();//stops this timer so the remaining code will only run once
                MoveAvatar(g, true);//calls this void to move the avatar again
            }
        }

        //pause and restart system
        private void btn_Pause_Click(object sender, EventArgs e)//when pause is clicked
        {
            MessageBox.Show("Game paused. Click OK to continue.", "Game paused", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btn_Restart_Click(object sender, EventArgs e)//when restart game is clicked
        {
            Game g = new Game();
            DialogResult message = MessageBox.Show("Are you sure you want to restart? You'll lose ALL your progress!",
                "Restart Game", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (message == DialogResult.Yes)//if the user chooses yes
            {
                System.Threading.Thread.Sleep(2000);
                g.SettingDefaultValues();
                Arrangements();
                DetermineTrack(g);
                DetermineAvatar(g);
                FetchPowerups(g);
                //basically run every procedure that happens when the form is loaded
                SelectRandomQuestions();
                System.Threading.Thread.Sleep(500);
                MessageBox.Show("You have restarted the game!", "Game restarted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btn_Endgame_Click(object sender, EventArgs e)//when end game is clicked
        {
            DialogResult message = MessageBox.Show("Are you sure you want to end the game? This will end all your " +
                "current progress!", "End Game", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (message == DialogResult.Yes)//if the user selected yes
            {
                System.Threading.Thread.Sleep(1500);
                NextStep(true);//takes this there so that the necessary actions are taken
            }
        }
    }
}