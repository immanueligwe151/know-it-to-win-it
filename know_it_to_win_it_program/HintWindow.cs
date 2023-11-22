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
    public partial class HintWindow : Form
    {
        public HintWindow()
        {
            InitializeComponent();
        }

        private void btn_Done_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(1000);
            this.Close();
        }

        private void HintWindow_Load(object sender, EventArgs e)
        {
            string quesID = Game.questionIdentifier;
            if (quesID == "quad1" || quesID == "quad4" || quesID == "quad6" || quesID == "quad16" || quesID == "quad18" || quesID == "quad20")
            {
                hintPictureBox.Image = Properties.Resources.hint_1;
            }
            else if (quesID == "quad2" || quesID == "quad7" || quesID == "quad8" || quesID == "quad9" || quesID == "quad14" || quesID == "quad17" || quesID == "quad19")
            {
                hintPictureBox.Image = Properties.Resources.hint_2;
            }
            else if (quesID == "quad3" || quesID == "quad5" || quesID == "quad10" || quesID == "quad11" || quesID =="quad12" || quesID == "quad13")
            {
                hintPictureBox.Image = Properties.Resources.hint_3;
            }
        }
    }
}
