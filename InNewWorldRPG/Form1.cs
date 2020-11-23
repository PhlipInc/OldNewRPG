using System;
using Domain;
using DataAccess;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InNewWorldRPG
{
    public partial class Form1 : Form
    {
        private static Random random = new Random();
        private static FighterManagerJSON DataManager = new FighterManagerJSON(random);
        private static Fighter fighter;
        private string user = Environment.MachineName;
        private string nl = Environment.NewLine;
        //string tempuser = "12342342";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            fighter = fighter ?? DataManager.GetFighter(user);
            if (fighter.IsFirstTimePlaying)
            {
                NewUser(fighter);
            }
            else
            {
                ExistingUser(fighter);
            }
        }

        private void ExistingUser(Fighter fighter)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"――――――――――――――――――――――――――――――――――――――――――――――{nl}");
            sb.Append($"{nl}WELCOME BACK {fighter.Name}!!!!!!!{nl}");
            sb.Append($"{nl}――――――――――――――――――――――――――――――――――――――――――――――{nl}");
            sb.Append($"{nl}{fighter}{nl}");
            sb.Append($"――――――――――――――――――――――――――――――――――――――――――――――{nl}");
            //sb.ToString();
            richTextBox1.AppendText(sb.ToString());
        }

        private void NewUser(Fighter fighter)
        {
            fighter.IsFirstTimePlaying = false;
            DataManager.SetFighter(user, fighter);
            StringBuilder sb = new StringBuilder();
            sb.Append($"――――――――――――――――――――――――――――――――――――――――――――――{nl}");
            sb.Append($"{nl}WELCOME IN TO THE NEW OLD WORLD(HELL){nl}");
            sb.Append($"――――――――――――――――――――――――――――――――――――――――――――――{nl}");
            sb.Append($"{fighter}{nl}");
            sb.Append($"――――――――――――――――――――――――――――――――――――――――――――――{nl}");
            //sb.ToString();
            richTextBox1.AppendText(sb.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"――――――――――――――――――――――――――――――――――――――――――――――{nl}");
            sb.Append($"{nl}YOUR STATS SIR {fighter.Name.ToUpper()}!!!!!!!{nl}");
            sb.Append($"{nl}――――――――――――――――――――――――――――――――――――――――――――――{nl}");
            sb.Append($"{fighter}{nl}");
            sb.Append($"――――――――――――――――――――――――――――――――――――――――――――――{nl}");
            richTextBox1.AppendText(sb.ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"―――――――――――――――――――――――――――――――――――――――――――――{nl}");
            sb.Append($"{nl}THE ONE THE HOLY STORE | {fighter.Name.ToUpper()}!!!!!!!{nl}");
            sb.Append($"{nl}―――――――――――――――――――――――――――――――――――――――――――――{nl}");
            sb.Append($"THIS IS JUST A TEMP STORE BUTTON{nl}");
            sb.Append($"FUTURE BUTTON WILL OPEN THE STORE UI{nl}");
            sb.Append($"THERE IS TEMP DATA HERE{nl}");
            sb.Append($"TEMP DATA GOES HERE{nl}");
            sb.Append($"―――――――――――――――――――――――――――――――――――――――――――――{nl}");
            //sb.ToString();
            richTextBox1.AppendText(sb.ToString());
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            fighter.AddLevel(1);
            fighter.MaxHp(fighter.Level);
            DataManager.SetFighter(user, fighter);
        }
    }
}
