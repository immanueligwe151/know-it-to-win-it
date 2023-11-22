using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace know_it_to_win_it_program
{
    class Registry
    {
        //registry keys
        //I'm keeping the values constant because that makes them private, so they can't be changed by the program
        const string subKey = @"SOFTWARE\Know It To Win It";//this is the subkey for the program with which it will store information in the registry

        const string userKey = "USERNAME";//key name to store the username
        public string UserKey()//this returns the key for the username as it has been made private by being made constant
        {
            return userKey;
        }

        const string coinKey = "TOTAL COINS";//key name to store the total number of coins earned throughout the game
        public string CoinKey()
        {
            return coinKey;
        }

        const string hintTotal = "TOTAL HINT GEMS";//key name to store the total number of hint gems
        public string HintTotal()
        {
            return hintTotal;
        }

        const string skipTotal = "TOTAL QUESTION SKIPPERS";//key name to store the total number of question skippers
        public string SkipTotal()
        {
            return skipTotal;
        }

        const string fastTotal = "TOTAL FAST TRACK";//key name to store the total number of fast track powerups
        public string FastTotal()
        {
            return fastTotal;
        }

        const string casualEquipped = "CASUAL PLAYER EQUIPPED";//key name to store the boolean value of if the casual player has been equipped
        public string CasualEquipped()
        {
            return casualEquipped;
        }

        const string koolPurchased = "KOOL KID PURCHASED";//key name to store the boolean value of if the kool kid has been purchased
        public string KoolPurchased()
        {
            return koolPurchased;
        }
        const string koolEquipped = "KOOL KID EQUIPPED";//key name to store the boolean value of if the kool kid has been equipped
        public string KoolEquipped()
        {
            return koolEquipped;
        }

        const string funPurchased = "FUN GUY PURCHSED";//key name to store the boolean value of if the fun guy has been purchased
        public string FunPurchased()
        {
            return funPurchased;
        }
        const string funEquipped = "FUN GUY EQUIPPED";//key name to store the boolean valkue of if the fun guy has been equipped
        public string FunEquipped()
        {
            return funEquipped;
        }

        public void CreateDirectoryInRegistry()//creates the registry itself
        {
            RegistryKey sk = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(subKey);//creates the registry object
            sk.SetValue(userKey, "");//creates a default value for the username in the registry
            sk.SetValue(coinKey, "0");//creates a default value for the coin total in the registry
            sk.SetValue(hintTotal, "0");//creates a default value for the Hint Gem total in the registry
            sk.SetValue(skipTotal, "0");//creates a default value for the Question Skipper total in the registry
            sk.SetValue(fastTotal, "0");//creates a default value for the Fast Track total in the registry
            sk.SetValue(casualEquipped, "true");//by default makes the equipped avatar Casual Player
            sk.SetValue(koolPurchased, "false");//by default makes the Kool Kid not purchased
            sk.SetValue(koolEquipped, "false");//by default makes the Kool Kid not equipped
            sk.SetValue(funPurchased, "false");//by default makes the Fun Guy not purchased
            sk.SetValue(funEquipped, "false");//by default makes the Fun Guy not equipped
        }

        public string ReadFromRegistry(string keyName)//this fetches a value from the registry
        {
            RegistryKey sk = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(subKey);
            if (sk == null)//if the subkey doesn't exist
            {
                return null;
            }
            else//if the subkey exists
            {
                return sk.GetValue(keyName).ToString();//fetches the value from that key name in the registry subkey
            }
        }

        public void WriteIntoRegistry(string keyName, string value)//fetches a value from the registry
        {
            RegistryKey sk = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(subKey);//opens a new key in the registry
            sk.SetValue(keyName, value);//writes to the key
        }
    }
}
