using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace know_it_to_win_it_program
{
    public partial class Store : Form
    {
        static int totalCoinNumber;//total number of coins
        static int powerupNumber;//the total number of that powerup
        static int price;//the price of the powerup or avatar to be purchased
        static string powerUp;//the powerup to be purchased
        static string keyName;//the keyname that will be used to write something into the registry
        static int powerupToBePurchased;//this is an integer identifier for the powerup to be purchased, which is identified from 1 to 3

        static string avatar;//the avatar to be purchased or equipped

        void ShowingCoinsAndPowerups()//the procedure for displaying the number of coins and powerups
        {
            Registry r = new Registry();//creating object for the registry class
            coinNumber.Text = r.ReadFromRegistry(r.CoinKey());//fetching value of total coins from registry and displaying it on the screen
            hintGemNumber.Text = r.ReadFromRegistry(r.HintTotal());//fetching value of total hint gems from registry and displaying it on the screen
            questionSkipNumber.Text = r.ReadFromRegistry(r.SkipTotal());//fetching value of question skippers from registry and displaying it on the screen
            fastTrackNum.Text = r.ReadFromRegistry(r.FastTotal());//fetching the value of total fast track powerups from the registry and displaying it on the screen
            HandlingCasualPlayer();//calls this to handle the displaying of the Casual Player Avatar
            HandlingKoolKid();//calls this to handle the displaying of the Kool Kid avatar
            HandlingFunGuy();//calls this to handle the displaying of the Fun Guy avatar
        }

        void HandlingCasualPlayer()//this handles how the Casual Player is being displayed in the store
        {
            Registry r = new Registry();
            if (bool.Parse(r.ReadFromRegistry(r.CasualEquipped())) == true)//if the Casual Player is equipped
            {
                equipCasualPlayer.Text = "✔";//shows the tick to indicate it's been equipped
                casualPlayerText.Text = "Equipped";//shows the text to indicate it's been equipped as well
            }
            else//if the casual player is not equipped
            {
                equipCasualPlayer.Text = "✖";//shows the x to indicate it's not equipped
                casualPlayerText.Text = "NIL";//shows NIL to indicate it's not equipped as well
            }
        }

        void HandlingKoolKid()//this handles how the Kool Kid is being displayed in the store
        {
            Registry r = new Registry();
            if (bool.Parse(r.ReadFromRegistry(r.KoolEquipped())) == true && bool.Parse(r.ReadFromRegistry(r.KoolPurchased())) == true)//if the kool kid has been purchased and has been equipped
            {
                equipKoolKid.Text = "✔";//shows the kool kid has been equipped
                koolKidCoin.Visible = false;//makes the coin icon invisible signifying that the user has purchased it
                koolKidText.Location = koolKidCoin.Location;//gives the text for the kool kid the same location as the picture
                koolKidText.Text = "Equipped";//shows the text to indicate it has been equipped
            }
            else if (bool.Parse(r.ReadFromRegistry(r.KoolPurchased())) == false && bool.Parse(r.ReadFromRegistry(r.KoolEquipped())) == false)//if it hasn't been purchased
            {
                equipKoolKid.Text = "+";//shows the + sign so the user can purchase the avatar
                //KoolPurchased() is only false until it has been purchased, and so KoolEquipped() remains false till it has been
                //purchased and equipped. Once KoolPurchased() is true, it can never go back to false
            }
            else if (bool.Parse(r.ReadFromRegistry(r.KoolEquipped())) == false && bool.Parse(r.ReadFromRegistry(r.KoolPurchased())) == true)//if purchased but not equipped
            {
                koolKidText.Text = "NIL";//shows the text to indicate it has been purchased but not equipped
                equipKoolKid.Text = "✖";//shows the kool kid has been purchased but not equipped
                koolKidCoin.Visible = false;//makes the coin icon invisible signifying that the user has purchased it
                koolKidText.Location = koolKidCoin.Location;//gives the text for the kool kid the same location as the picture
            }
        }
        
        void HandlingFunGuy()//this handles how the Fun Guy is being displayed in the store
        {
            Registry r = new Registry();
            if (bool.Parse(r.ReadFromRegistry(r.FunEquipped())) == true && bool.Parse(r.ReadFromRegistry(r.FunPurchased())) == true)//if the Fun Guy has been purchased and has been equipped
            {
                equipFunGuy.Text = "✔";//shows the Fun Guy has been equipped
                funGuyCoin.Visible = false;//makes the coin icon invisible signifying that the user has purchased it
                funGuyText.Location = funGuyCoin.Location;//gives the text for the Fun Guy the same location as the picture
                funGuyText.Text = "Equipped";//shows the text to indicate it has been equipped
            }
            else if (bool.Parse(r.ReadFromRegistry(r.FunPurchased())) == false && bool.Parse(r.ReadFromRegistry(r.FunEquipped())) == false)//if it hasn't been purchased
            {
                equipFunGuy.Text = "+";//shows the + sign so the user can purchase the avatar
                //FunPurchased() is only false until it has been purchased, and so FunEquipped() remains false till it has been
                //purchased and equipped. Once FunPurchased() is true, it can never go back to false
            }
            else if (bool.Parse(r.ReadFromRegistry(r.FunEquipped())) == false && bool.Parse(r.ReadFromRegistry(r.FunPurchased())) == true)//if purchased but not equipped
            {
                equipFunGuy.Text = "✖";//shows the kool kid has been purchased but not equipped
                funGuyCoin.Visible = false;//makes the coin icon invisible signifying that the user has purchased it
                funGuyText.Location = funGuyCoin.Location;//gives the text for the Fun Guy the same location as the picture
                funGuyText.Text = "NIL";//shows the text to indicate it has been purchased but not equipped
            }
        }

        void PurchasingPowerup()//this handles the purchasing of a powerup
        {
            totalCoinNumber = int.Parse(coinNumber.Text);//gets the value of the coin number which has already been fetched from the registry
            Registry r = new Registry();//object for the registry
            switch (powerupToBePurchased)
            {
                case 1://if the hint gem was to be purchased
                    price = int.Parse(hintGemPrice.Text);//taking the value already presented in the store and converting it to an int
                    powerUp = "Hint Gem";
                    powerupNumber = int.Parse(hintGemNumber.Text);//gets the value of the total number of hint gems
                    keyName = r.HintTotal();//the keyname to store total hint gems
                    break;
                case 2://if the question skipper was to be purchased
                    price = int.Parse(questionSkipperPrice.Text);//taking the value already presented in the store and converting it to an int
                    powerUp = "Question Skipper";
                    powerupNumber = int.Parse(questionSkipNumber.Text);//gets the value of the total number of question skippers
                    keyName = r.SkipTotal();//the keyname to store total question skippers
                    break;
                case 3://if the fast track was to be purchased
                    price = int.Parse(fastTrackPrice.Text);//taking the value already presented in the store and converting it to an int
                    powerUp = "Fast Track";
                    powerupNumber = int.Parse(fastTrackNum.Text);//gets the value of the total number of fast track powerups
                    keyName = r.FastTotal();//the keyname to store total fast track
                    break;
            }
            if (totalCoinNumber >= price)//the user has enough coins to purchase the powerup
            {
                powerupNumber++;
                r.WriteIntoRegistry(keyName, powerupNumber.ToString());//writes the new number of that powerup into the registry
                r.WriteIntoRegistry(r.CoinKey(), (totalCoinNumber - price).ToString());//writes the new number of total coins to the registry
                MessageBox.Show("You have succesfully purchased a " + powerUp + " powerup!", "Purchase succesful", MessageBoxButtons.OK, MessageBoxIcon.Information);//displays the message that the user has purchased a new powerup
                ShowingCoinsAndPowerups();//this reruns the void to display the new amounts of coins and powerups
            }
            else//user doesn't have enough coins
            {
                Thread.Sleep(500);//delays the time by 500ms
                MessageBox.Show("Sorry, you do not have enough coins to purchase The " + powerUp + " as you do not have enough coins. Earn some more coins and then try again.", "Not enough coins!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //displays a message to show that the user doesn't have enough coins
            }
        }

        void PurchasingAvatar(int number)//this handles the purchasing of an avatar
        {
            totalCoinNumber = int.Parse(coinNumber.Text);//gets the value of the coin number which has already been loaded from the registry
            Registry r = new Registry();//creates an object for the registry
            if (bool.Parse(r.ReadFromRegistry(r.KoolPurchased())) == false || bool.Parse(r.ReadFromRegistry(r.FunPurchased())) == false)
            {
                switch (number)
                {
                    case 1://if Kool Kid were to be purchased
                        price = int.Parse(koolKidText.Text);//gets the price from the store
                        avatar = "Kool Kid";//the name of the powerup
                        keyName = r.KoolPurchased();//the keyname to store it in the registry
                        break;
                    case 2://if Fun Guy were to be purchased
                        price = int.Parse(funGuyText.Text);//gets the price from the store
                        avatar = "Fun Guy";//the name of the powerup
                        keyName = r.FunPurchased();//the keyname to store it in the registr
                        break;
                }
                if (totalCoinNumber >= price)//if the user has enough coins
                {
                    r.WriteIntoRegistry(keyName, "true");//notifies that the powerup is now purchased
                    r.WriteIntoRegistry(r.CoinKey(), (totalCoinNumber - price).ToString());//writes the new number of total coins to the registry
                    MessageBox.Show("You have succesfully purchased the " + avatar + " avatar!", "Purchase succesful", MessageBoxButtons.OK, MessageBoxIcon.Information);//displays the message that the user has purchased a new powerup
                    ShowingCoinsAndPowerups();//this reruns the void to display the purchase and equipping of these avatars
                }
                else
                {
                    Thread.Sleep(500);//delays the time by 500ms
                    MessageBox.Show("Sorry, you do not have enough coins to purchase The " + powerUp + " as you do not have enough coins. Earn some more coins and then try again.", "Not enough coins!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //displays a message to show that the user doesn't have enough coins
                }
            }
            
        }

        void EquippingAvatar(int number)//this handles the equipping of an avatar
        {
            Registry r = new Registry();//object for the registry
            switch (number)
            {
                case 1://if casual player were to be equipped
                    keyName = r.CasualEquipped();//the keyname for the casual player
                    avatar = "Casual Player";
                    r.WriteIntoRegistry(r.KoolEquipped(), "false");//makes the Kool Kid unequipped
                    r.WriteIntoRegistry(r.FunEquipped(), "false");//makes the Fun Guy unequipped
                    break;
                case 2://if kool kid were to be equipped
                    keyName = r.KoolEquipped();//the keyname for the Kool Kid
                    avatar = "Kool Kid";
                    r.WriteIntoRegistry(r.CasualEquipped(), "false");//makes the Casual Player unequipped
                    r.WriteIntoRegistry(r.FunEquipped(), "false");//makes the Fun Guy unequipped
                    break;
                case 3://if fun guy were to be equipped
                    keyName = r.FunEquipped();//the keyname for the casual player
                    avatar = "Fun Guy";
                    r.WriteIntoRegistry(r.KoolEquipped(), "false");//makes the Kool Kid unequipped
                    r.WriteIntoRegistry(r.CasualEquipped(), "false");//makes the Casual Player unequipped
                    break;
            }
            r.WriteIntoRegistry(keyName, "true");//makes the selected avatar equipped
            MessageBox.Show("You have succesfully equipped the " + avatar + " Avatar!", "Avatar equipped", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //the dialog box to show that the avatar has been equipped
            ShowingCoinsAndPowerups();//this reruns this void to show the purchase and equipping of avatars and powerups
        }

        public Store()
        {
            InitializeComponent();
        }

        private void fastTrackPic_MouseHover(object sender, EventArgs e)//for when the mouse hovers over the Fast Track
        {
            toolTip1.SetToolTip(fastTrackPic, "The Fast Track powerup will enable you to move\nfaster in the game whilst answering lesser questions.");
        }

        private void questionSkipperPic_MouseHover(object sender, EventArgs e)//for when the mouse hovers over the question skipper
        {
            toolTip1.SetToolTip(questionSkipperPic, "Finding a question difficult? The Question Skipper\nwill enable you to skip the question and move on\nto the next one without affecting your number of\ncorrectly answered questions! How cool is that?");
        }

        private void hintGemPic_MouseHover(object sender, EventArgs e)//for when the mouse hovers over the hint gem
        {
            toolTip1.SetToolTip(hintGemPic, "Are you stuck in a question and don't know where to\ngo from there? Use the Hint Gem to get yourself a\nhint to handle that question! ;)");
        }

        private void casualPlayerIcon_MouseHover(object sender, EventArgs e)//for when the mouse hovers over the casual player
        {
            toolTip1.SetToolTip(casualPlayerIcon, "The Casual Player");
        }

        private void koolKidIcon_MouseHover(object sender, EventArgs e)//for when the mouse hovers over the kool kid
        {
            toolTip1.SetToolTip(koolKidIcon, "The Kool Kid");
        }

        private void funGuyIcon_MouseHover(object sender, EventArgs e)//for when the mouse hovers over the fun guy
        {
            toolTip1.SetToolTip(funGuyIcon, "The Fun Guy");
        }

        private void Store_Load(object sender, EventArgs e)//when the store is loaded
        {
            Registry r = new Registry();
            ShowingCoinsAndPowerups();//void to display the coins
            MessageBox.Show("Welcome " + r.ReadFromRegistry(r.UserKey()) + " to the store! Here, you can make some purchases to enhance" +
                " your game-playing and revision? Fancy a new avatar? Want a powerup to make your gaming experience better? You can find them" +
                " here in the store! To know what a powerup does, simply hover your mouse over the icon and get a brief description of their" +
                " jobs! And you can also find out the names of your avatars too! Enjoy, " + r.ReadFromRegistry(r.UserKey()) + "!", "Welcome to the store!",
                MessageBoxButtons.OK, MessageBoxIcon.Information);//displaying store information
        }

        private void addHintGem_Click(object sender, EventArgs e)//event for purchasing a Hint Gem
        {
            powerupToBePurchased = 1;//assigns the number 1
            PurchasingPowerup();//calls the procedure to purchase the powerup 
        }

        private void addQuestionSkipper_Click(object sender, EventArgs e)//event for purchasing a Question Skipper
        {
            powerupToBePurchased = 2;//assigns the number 2
            PurchasingPowerup();//calls the procedure to purchase the powerup
        }

        private void addFastTrack_Click(object sender, EventArgs e)//event for purchasing a Fast Track
        {
            powerupToBePurchased = 3;//assigns the number 3
            PurchasingPowerup();//calls the procedure to purchase the powerup
        }

        private void equipCasualPlayer_Click(object sender, EventArgs e)//event when the button for the casual player is clicked
        {
            int avatar = 1;
            EquippingAvatar(avatar);//goes straight to equip the avatar since it doesn't need to be purchased
        }

        private void equipKoolKid_Click(object sender, EventArgs e)//event when the button for the Kool Kid is clicked
        {
            Registry r = new Registry();//creating the registry for the object
            if (bool.Parse(r.ReadFromRegistry(r.KoolPurchased())) == false)//if the Kool Kid has not been purchased
            {
                int avatar = 1;
                PurchasingAvatar(avatar);//goes to purchase the avatar
            }
            else//if the avatar has been purchased
            {
                int avatar = 2;
                EquippingAvatar(avatar);//goes to equip the avatar
            }
        }

        private void equipFunGuy_Click(object sender, EventArgs e)//event when the Fun Guy is clicked
        {
            Registry r = new Registry();//creating the registry for the object
            if (bool.Parse(r.ReadFromRegistry(r.FunPurchased())) == false)//if the Fun Guy has not been purchased
            {
                int avatar = 2;
                PurchasingAvatar(avatar);//goes to purchase the avatar
            }
            else//if the avatar has been purchased
            {
                int avatar = 3;
                EquippingAvatar(avatar);//goes to equip the avatar
            }
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            Thread.Sleep(500);//making it sleep by 500 milliseconds
            this.Close();//closing this form
        }
    }
}
