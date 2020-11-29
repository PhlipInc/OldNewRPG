using System;
using Domain;
using DataAccess;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace InNewWorldRPG
{
    public partial class Form1 : Form
    {
        private static Random random = new Random();
        private static FighterManagerJSON FighterDataManager = new FighterManagerJSON(random);
        private static ItemManagerJSON ItemDataManager = new ItemManagerJSON(random);
        private static DungeonManagerJSON DungeonDataManager = new DungeonManagerJSON(random);
        private static MonsterManagerJSON MonsterDataManager = new MonsterManagerJSON(random);
        private static Fighter fighter;
        private static Dungeon dungeon = new Dungeon();
        private string user = Environment.MachineName;
        private string nl = Environment.NewLine;
        private string tempuser = "12342342";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            fighter = fighter ?? FighterDataManager.GetFighter(user, fighter);
            ItemDataManager.GetItems();
            MonsterDataManager.GetMonsters();
            DungeonDataManager.GetDungeons();
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
            FighterDataManager.SetFighter(user, fighter);
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
            for (int i = 0; i < ItemDataManager.GetItems().Count; i++)
            {
                sb.Append($"{ItemDataManager.GetItems()[i]}{nl}");
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

        }

        private void button5_Click(object sender, EventArgs e)
        {
            foreach (var item in MonsterDataManager.GetMonsters())
            {
                richTextBox1.AppendText(nl + item + nl);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            Dungeon RandomDungeon = DungeonDataManager.GetRandomDungeon(fighter);
            fighter.Dung = RandomDungeon;
            FighterDataManager.SetFighter(user, fighter);
            sb.Append(RandomDungeon);
            richTextBox1.AppendText(sb.ToString());
        }

        private void button7_Click(object sender, EventArgs e)
        {
        }

        private void button8_Click(object sender, EventArgs e)
        {
            fighter.Dung = DungeonDataManager.GetRandomDungeon(fighter);
            fighter.PlayerState = State.IN_DUNGEON_STATE;
            FighterDataManager.SetFighter(user, fighter);
        }

        private void ManageFighterDungeon(State state)
        {
            switch (state)
            {
                case State.IN_DUNGEON_STATE:
                    richTextBox1.AppendText($"{nl}{fighter.Name} is in dungeon, and ready to fight{nl}");
                    richTextBox1.AppendText($"{nl}{fighter.Name} entered {fighter.Dung.Name}.{nl}");
                    break;
                case State.IN_FIGHT_STATE:
                    richTextBox1.AppendText($"{nl}{fighter.Name} is in a fight, choose to fight the Monster or run away{nl}");
                    break;
                case State.AFTER_FIGHT_STATE:
                    richTextBox1.AppendText($"{nl}{fighter.Name} just finised the fight and is ready to receive their rewards{nl}");
                    break;
                case State.NOT_IN_DUNGEON_STATE:
                    richTextBox1.AppendText($"{nl}{fighter.Name} is not in a dungeon, Lets enter a dungeon to fight monsters{nl}");
                    break;
                default:
                    Debug.WriteLine("Sorry an erorr occured while checked and setting the fighters status");
                    break;
            }
        }
    }
}
