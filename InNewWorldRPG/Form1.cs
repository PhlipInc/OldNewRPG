using System;
using Domain;
using DataAccess;
using System.Text;
using System.Windows.Forms;

namespace InNewWorldRPG
{
    public partial class Form1 : Form
    {
        private static Random random = new Random();
        private static FighterManagerJSON DataManager = new FighterManagerJSON(random);
        private static Fighter fighter;
        private static Dungeon dungeon = new Dungeon();
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

        private void StoreButton_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"―――――――――――――――――――――――――――――――――――――――――――――{nl}");
            sb.Append($"{nl}THE ONE THE ONLY HOLY STORE | {fighter.Name.ToUpper()}!!!!!!!{nl}");
            sb.Append($"{nl}―――――――――――――――――――――――――――――――――――――――――――――{nl}");
            for (int i = 0; i < DataManager.GetItems().Count; i++)
            {
                sb.Append($"{DataManager.GetItems()[i]}{nl}");
            }
            sb.Append($"THIS IS JUST A TEMP STORE BUTTON{nl}");
            sb.Append($"FUTURE BUTTON WILL OPEN THE STORE UI{nl}");
            sb.Append($"THERE IS TEMP DATA HERE{nl}");
            sb.Append($"TEMP DATA GOES HERE{nl}");
            sb.Append($"―――――――――――――――――――――――――――――――――――――――――――――{nl}");
            //sb.ToString();
            richTextBox1.AppendText(sb.ToString());
            richTextBox1.ScrollToCaret();
        }

        private void StatsButton_Click(object sender, EventArgs e)
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

        }

        private void button4_Click(object sender, EventArgs e)
        {
            foreach (var item in DataManager.GetDungeons())
            {
                richTextBox1.AppendText(nl + item + nl);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            foreach (var item in DataManager.GetMonsters())
            {
                richTextBox1.AppendText(nl + item + nl);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            Dungeon RandomDungeon = DataManager.GetRandomDungeon();
            sb.Append(RandomDungeon);
            richTextBox1.AppendText(sb.ToString());
        }

        private void button7_Click(object sender, EventArgs e)
        {
            fighter.IncrementLevelFromExperience(Convert.ToInt32(fighter.Experience * 1.1), fighter);
            DataManager.SetFighter(user, fighter);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            fighter.AddLevel(1);
            fighter.Experience = fighter.Experience * 1.5;
            fighter.HealthPoints = fighter.MaxHp(fighter.Level);
            DataManager.SetFighter(user, fighter);
        }

    }
}
