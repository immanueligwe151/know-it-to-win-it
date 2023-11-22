using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace know_it_to_win_it_program
{
    class Game : Registry
    {
        //static values as they'll be needed across forms
        public static string selectedSubject;//identifier for different subjects
        public static string selectedTopic;//value to store the chosen topic
        public static string selectedMode;//identifier for the revision mode
        public static int firstTryAnswers;//number of quesions the user answered correctly on first try
        public static int correctAnswers;//number of questions the user answered correctly
        public static int wrongAnswers;//number of questions the user answered wrongly
        public static int totalCoinsEarned;//total number of coins earned by the user
        public static string questionIdentifier;//a string identifier for each question
        public static int triesNumber;//total number of tries by the user on attempting to answer a question, default value is 0
        public static List<int> questionList = new List<int> { };//list to contain question numbers, set when PlayGame loads
        public static int questionCount;//counts the number of questions answered by the user
        //public int trackNumber;//the number of cells in a given track, assigned when the game is loaded
        public static List<int> cellMoveList = new List<int> { };//list for the number of cells the avatar is going to move,
        //which will all total to the total number of cells in each track. initially empty; assigned when a track is randomly chosen
        public static int skipperUseCount;//the number of times the question skipper is used
        public static bool fastTrackUsed;//a bool to determine if the fast track has been used
        public static int usedGemTotal;//stores the total number of gems that are used in a game session

        public int randomTrackNumber()//to generate a random number of tracks 
        {
            Random rnd = new Random();
            return rnd.Next(1, 4);//at the moment I have currently have 3 tracks so it will randomly select one from either 3
        }

        public void SettingDefaultValues()//void to set the default values; called whenever the form is loaded
        {
            questionCount = 0;//sets the default value of answered questions to 0, as the questions won't start to be answered until one has been displayed
            //whereby it will now become 1
            triesNumber = 0;//sets the value to 0 by default
            totalCoinsEarned = 0;//set to 0 by default
            firstTryAnswers = 0;//set to 0 by default
            correctAnswers = 0;//set to 0 by default
            wrongAnswers = 0;//set to 0 by default
            skipperUseCount = 0;//set to 0 by default
            usedGemTotal = 0;//setting this value to 0 by default
            fastTrackUsed = false;//set to false by default
            cellMoveList = new List<int> { };//set to null by default
            questionList = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };//sets the values for questionList
        }
        
        public int randomCellNumber()//determines a random number to be selected from cellMoveList
        {
            Random rnd = new Random();
            int number = cellMoveList[rnd.Next(0, cellMoveList.Count - 1)];//gets the number from a random index point
            cellMoveList.Remove(number);//removes the selected number from the list
            return number;
        }

        public bool AddingResults(bool correct)
        {
            if (triesNumber < 3)//if the user hasn't yet exhausted 3 tries
            {
                if (triesNumber == 1 && correct == true)//if answer is correct on first try
                {
                    firstTryAnswers++;//adds one to firstTryAnswers
                    correctAnswers++;//adds 1 to correctAnswers
                    MessageBox.Show("Correct! Well done!", "Correct!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    questionCount++;//the question has been answered so adds 1
                    return true;
                }
                else if (correct == true)
                {
                    correctAnswers++;//adds 1 to correctAnswers
                    MessageBox.Show("Correct! Well done!", "Correct!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    questionCount++;//the question has been answered so adds 1
                    return true;
                }
                else if (correct == false)
                {
                    MessageBox.Show("Sorry, not quite right. Don't worry, you still have " + (3 - triesNumber).ToString() +
                        " tries left.", "Incorrect answer", MessageBoxButtons.OK, MessageBoxIcon.Information);//displays the end result
                    return false;
                }
            }
            else//once triesNumber == 3
            {
                if (correct == true)
                {
                    correctAnswers++;//adds 1 to correctAnswers
                    MessageBox.Show("Correct! Well done!", "Correct!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    questionCount++;//the question has been answered so adds 1
                    return true;
                }
                else
                {
                    wrongAnswers++;//adds 1 to wrong answers as user has exhausted all 3 tries without getting the answer right
                    MessageBox.Show("Sorry, still not quite right :( Hopefully you'll do better next time!", "Still wrong...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    questionCount++;//the question has been answered (even though wrongly) so adds 1
                    //so time to go of to the next question but the avatar is NOT going
                    return false;

                }
            }
            return false;
        }//this is to add the results and display appropriate message

        public int AddCoins()//void to add the total coins
        {
            int previousCoins = int.Parse(ReadFromRegistry(CoinKey()));//getting the former total of coins from the registry
            totalCoinsEarned = totalCoinsEarned + (2 * correctAnswers) + (4 * firstTryAnswers);//determining the total of coins earned
            previousCoins = previousCoins + totalCoinsEarned;//adding the new value of earned coins to previousCoins
            WriteIntoRegistry(CoinKey(), previousCoins.ToString());//writing the new value of total earned coins into the registry
            return totalCoinsEarned;
        }

        public void DisplayEndResults()//void to display the end results of the game
        {
            string information;//a string to display the information of the game session.
            information = "Total coins earned: " + AddCoins().ToString() + "\nQuestions answered correctly: "
                + correctAnswers.ToString() + "\nQuestions answered wrongly: " + wrongAnswers.ToString() + "\nTotal" +
                " Hint Gems used: " + usedGemTotal.ToString() + "\nTotal Questions Skippers used: " + skipperUseCount.ToString()
                + "\nFast Track used: ";//determining the value in information
            if (fastTrackUsed == true)//if it was used
            {
                information = information + "yes";//adding that to the string value if it was used
            }
            else//if it wasn't used
            {
                information = information + "no";//adding that to the string value if it wasn't used
            }
            System.Threading.Thread.Sleep(1000);
            MessageBox.Show(information, "GAME FINISHED!", MessageBoxButtons.OK, MessageBoxIcon.Information);//message box to display the information
        }
    }
}
