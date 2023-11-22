using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace know_it_to_win_it_program
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Registry r = new Registry();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (r.ReadFromRegistry(r.UserKey()) == null || r.ReadFromRegistry(r.UserKey()) == "")//if the registry doesn't exist
            {
                r.CreateDirectoryInRegistry();//this creates the registry directory once the program is opened the first time
                Application.Run(new User_Name());//opens the Username form
                if (r.ReadFromRegistry(r.UserKey()) != "")
                    Application.Run(new MainMenu());//opens the main menu if the user has entered a username
            }
            else
            {
                Application.Run(new MainMenu());//opens the main menu form if the registry exists
            }
            
            
        }
    }
}
