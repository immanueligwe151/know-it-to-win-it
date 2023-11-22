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
    public partial class User_Name : Form
    {
        public User_Name()
        {
            InitializeComponent();
        }

        public static bool valid = false;//a boolean value to help in changing the username

        private void User_Name_Load(object sender, EventArgs e)//event called when the form is loaded
        {
            Registry r = new Registry();//creates an object for the registry
            if (r.ReadFromRegistry(r.UserKey()) == "")//if the stored username in the registry is "", its default value
            {
                this.Text = "Create a Username";//the text read on the menu bar
                default_text.Text = "Create a new username";//the label text
                MessageBox.Show("Welcome to Know It To Win It! Please create your first username to get started!", "Welcome!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                //message box to welcome the user into the game
            }
            else//registry exists hence there is already a pre-saved username
            {
                this.Text = "Change Username";//changes the text read on the menu bar
                default_text.Text = "Enter your old username";//changes the text of the label
            }
        }

        private void btn_Done_Click(object sender, EventArgs e)
        {
            Registry registryValues = new Registry();//creates the registryValues object
            if (nameEntry.Text == "" || nameEntry.Text.Contains(" ") || nameEntry.Text.Length < 5)//in case the user mischieviously (or accidentaly) doesn't enter anything into the textbox or their username doesn't fit with the standards
            {
                MessageBox.Show("The value you have entered is invalid. Please enter a username with 5 or more characters and no spaces.", "Invalid entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (registryValues.ReadFromRegistry(registryValues.UserKey()) != null && valid == true)//if there has been an entry into the textbox which meets the requirements and there is a value stored in the registry for the username and the user has already previously entered their former username
            {
                registryValues.WriteIntoRegistry(registryValues.UserKey(), nameEntry.Text);//saves the new value into the registry
                MessageBox.Show("You have succesfully changed your username!", "Username changed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                System.Threading.Thread.Sleep(750);
                valid = false;//resets the value back to false
                this.Close();//closes this window
            }
            else//if the user has entered something and it doesn't meet the conditions above
            {
                if (registryValues.ReadFromRegistry(registryValues.UserKey()) == "")//if there hasn't been a new saved value for the username in the registry; it's still the default value of ""
                {
                    registryValues.WriteIntoRegistry(registryValues.UserKey(), nameEntry.Text);//writes the value into the registry
                    MessageBox.Show("You have succesfully entered a username!", "Well done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    System.Threading.Thread.Sleep(750);
                    this.Close();//eventually closes the program after the menu form has been closed
                }
                else//if there is already a saved value in the registry for the username
                {
                    if (nameEntry.Text == registryValues.ReadFromRegistry(registryValues.UserKey()))//if the user has correctly entered their current username
                    {
                        valid = true;//changes the boolean value to true
                        default_text.Text = "Enter your new username";
                    }
                    else//if the username entered is not correct
                    {
                        valid = false;//keeps the boolean value false
                        MessageBox.Show("You have entered the wrong username. Please try again.", "Wrong entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            nameEntry.Text = "";//empties the textbox of any values entered
        }
    }

}
