using System;
using Domain;
using DataAccess;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace InNewWorldRPG
{
    public partial class Form1 : Form
    {
        #region Instances
        private static readonly Random random = new Random();
        private static readonly FighterManagerJSON FighterDataManager = new FighterManagerJSON();
        private static readonly ItemManagerJSON ItemDataManager = new ItemManagerJSON(random);
        private static readonly DungeonManagerJSON DungeonDataManager = new DungeonManagerJSON(random);
        private static readonly MonsterManagerJSON MonsterDataManager = new MonsterManagerJSON(random);
        private static Fighter fighter;
        private readonly string user = Environment.MachineName;
        //private readonly string tempuser = "12342342";
        #endregion
        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            fighter ??= await FighterDataManager.GetFighter(user, fighter).ConfigureAwait(true);
            await ItemDataManager.GetItems().ConfigureAwait(true);
            await MonsterDataManager.GetMonsters().ConfigureAwait(true);
            await DungeonDataManager.GetDungeons().ConfigureAwait(true);
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
            sb.Append("――――――――――――――――――――――――――――――――――――――――――――――").Append(Environment.NewLine);
            sb.Append(Environment.NewLine).Append("WELCOME BACK ").Append(fighter.Name).Append("!!!!!!!").Append(Environment.NewLine);
            sb.Append(Environment.NewLine).Append("――――――――――――――――――――――――――――――――――――――――――――――").Append(Environment.NewLine);
            sb.Append(Environment.NewLine).Append(fighter).Append(Environment.NewLine);
            sb.Append("――――――――――――――――――――――――――――――――――――――――――――――").Append(Environment.NewLine);
            GamePadRichText.Text = (sb.ToString());
            ManageFighterStates(fighter.PlayerState);
        }

        private async void NewUser(Fighter fighter)
        {
            fighter.IsFirstTimePlaying = false;
            await FighterDataManager.SetFighter(user, fighter).ConfigureAwait(true);
            StringBuilder sb = new StringBuilder();
            sb.Append("――――――――――――――――――――――――――――――――――――――――――――――").Append(Environment.NewLine);
            sb.Append(Environment.NewLine).Append("WELCOME IN TO THE NEW OLD WORLD(HELL)").Append(Environment.NewLine);
            sb.Append("――――――――――――――――――――――――――――――――――――――――――――――").Append(Environment.NewLine);
            sb.Append(fighter).Append(Environment.NewLine);
            sb.Append("――――――――――――――――――――――――――――――――――――――――――――――").Append(Environment.NewLine);
            GamePadRichText.AppendText(sb.ToString());
            ManageFighterStates(fighter.PlayerState);
        }

        #region Button Click Events
        private async void StoreButton_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("―――――――――――――――――――――――――――――――――――――――――――――").Append(Environment.NewLine);
            sb.Append(Environment.NewLine).Append("THE ONE THE OEnvironment.NewLineY HOLY STORE | ").Append(fighter.Name.ToUpper()).Append("!!!!!!!").Append(Environment.NewLine);
            sb.Append(Environment.NewLine).Append("―――――――――――――――――――――――――――――――――――――――――――――").Append(Environment.NewLine);
            for (int i = 0; i < (await ItemDataManager.GetItems().ConfigureAwait(true)).Count; i++)
            {
                sb.Append((await ItemDataManager.GetItems().ConfigureAwait(true))[i]).Append(Environment.NewLine);
            }
            sb.Append("THIS IS JUST A TEMP STORE BUTTON").Append(Environment.NewLine);
            sb.Append("FUTURE BUTTON WILL OPEN THE STORE UI").Append(Environment.NewLine);
            sb.Append("THERE IS TEMP DATA HERE").Append(Environment.NewLine);
            sb.Append("TEMP DATA GOES HERE").Append(Environment.NewLine);
            sb.Append("―――――――――――――――――――――――――――――――――――――――――――――").Append(Environment.NewLine);
            GamePadRichText.AppendText(sb.ToString());
            GamePadRichText.ScrollToCaret();
        }

        private void StatsButton_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("――――――――――――――――――――――――――――――――――――――――――――――").Append(Environment.NewLine);
            sb.Append(Environment.NewLine).Append("YOUR STATS SIR ").Append(fighter.Name.ToUpper()).Append("!!!!!!!").Append(Environment.NewLine);
            sb.Append(Environment.NewLine).Append("――――――――――――――――――――――――――――――――――――――――――――――").Append(Environment.NewLine);
            sb.Append(fighter).Append(Environment.NewLine);
            sb.Append("――――――――――――――――――――――――――――――――――――――――――――――").Append(Environment.NewLine);
            GamePadRichText.AppendText(sb.ToString());
            GamePadRichText.ScrollToCaret();
        }

        private void GameHelpButton_Click(object sender, EventArgs e)
        {
            GamePadRichText.AppendText("test");
            //Help Button
        }

        private void FighterItemsButton_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in fighter.Items)
            {
                sb.Append("Name: ").Append(item.Name).Append(Environment.NewLine)
                    .Append("Description: ").Append(item.Description).Append(Environment.NewLine).Append(Environment.NewLine);
            }
            GamePadRichText.AppendText(sb.ToString());
            GamePadRichText.ScrollToCaret();
        }

        private async void EnterDungeonButton_Click(object sender, EventArgs e)
        {
            if (fighter.PlayerState == State.NOT_IN_DUNGEON_STATE)
            {
                fighter.Dung = (await DungeonDataManager.GetRandomDungeon(fighter).ConfigureAwait(true));
                fighter.PlayerState = State.IN_DUNGEON_STATE;
                await FighterDataManager.SetFighter(user, fighter).ConfigureAwait(true);
                //set proper buttons to enabled and disabled
                ManageFighterStates(fighter.PlayerState);
            }
            else
            {
                ManageFighterStates(fighter.PlayerState);
            }
            GamePadRichText.ScrollToCaret();
        }

        private async void LeaveDungeonButton_Click(object sender, EventArgs e)
        {
            if (fighter.PlayerState == State.IN_DUNGEON_STATE)
            {
                fighter.PlayerState = State.NOT_IN_DUNGEON_STATE;
                fighter.Dung = null;
                await FighterDataManager.SetFighter(user, fighter).ConfigureAwait(true);
                GamePadRichText.AppendText("What are you... scared?" + Environment.NewLine);
                ManageFighterStates(fighter.PlayerState);
            }
            else
            {
                ManageFighterStates(fighter.PlayerState);
            }
            GamePadRichText.ScrollToCaret();
        }

        private async void FightButton_Click(object sender, EventArgs e)
        {
            if (fighter.PlayerState == State.IN_DUNGEON_STATE)
            {
                fighter.PlayerState = State.IN_FIGHT_STATE;
                await FighterDataManager.SetFighter(user, fighter).ConfigureAwait(true);
                ManageFighterStates(fighter.PlayerState);
            }
            else
            {
                ManageFighterStates(fighter.PlayerState);
            }
            GamePadRichText.ScrollToCaret();
        }

        private async void RunAwayButton_Click(object sender, EventArgs e)
        {
            if (fighter.PlayerState == State.IN_FIGHT_STATE)
            {
                double HpDamage = HPTakenAfterRunningAway();
                StringBuilder sb = new StringBuilder();
                sb.Append("You are going to run away and take a chance of losing HP")
                .Append("You took the chance and lost ").Append(HpDamage);
                GamePadRichText.AppendText(sb.ToString());
                fighter.RemoveHP(HpDamage);
                fighter.PlayerState = State.NOT_IN_DUNGEON_STATE;
                await FighterDataManager.SetFighter(user, fighter).ConfigureAwait(true);
                ManageFighterStates(fighter.PlayerState);
            }
            else
            {
                ManageFighterStates(fighter.PlayerState);
            }
            GamePadRichText.ScrollToCaret();
        }
        #endregion

        private void ManageFighterStates(State state)
        {
            StringBuilder sb;
            switch (state)
            {
                case State.IN_DUNGEON_STATE:
                    sb = new StringBuilder();
                    sb.Append(Environment.NewLine).Append("You are entered ").Append(fighter.Dung.Name).Append(Environment.NewLine);
                    sb.Append(Environment.NewLine).Append("This dungeons level is ").Append(fighter.Dung.Level).Append(Environment.NewLine);
                    sb.Append(Environment.NewLine).Append("If you complete this dungeon you will recieve ").Append(fighter.Dung.RewardExperience).Append(" experience points, and these items,").Append(Environment.NewLine);
                    foreach (var item in fighter.Dung.RewardItems)
                    {
                        sb.Append(Environment.NewLine)
                            .Append("Name: ").Append(item.Name).Append(Environment.NewLine)
                            .Append("Description: ").Append(item.Description).Append(Environment.NewLine).Append(Environment.NewLine);
                    }
                    sb.Append(Environment.NewLine).Append("There are ").Append(fighter.Dung.Monsters.Count).Append(" Monsters in this dungeon").Append(Environment.NewLine).Append(Environment.NewLine);
                    foreach (var item in fighter.Dung.Monsters)
                    {
                        sb.Append(Environment.NewLine)
                            .Append(item.ToString()).Append(Environment.NewLine);
                    }

                    GamePadRichText.AppendText(sb.ToString());
                    LeaveDungeonButton.Enabled = true;
                    FightButton.Enabled = true;
                    RunAwayButton.Enabled = false;
                    EnterDungeonButton.Enabled = false;
                    break;
                case State.IN_FIGHT_STATE:
                    GamePadRichText.AppendText($"{Environment.NewLine}{fighter.Name} is in a fight, choose to fight the Monster(s) or run away{Environment.NewLine}");
                    LeaveDungeonButton.Enabled = false;
                    FightButton.Enabled = false;
                    RunAwayButton.Enabled = true;
                    EnterDungeonButton.Enabled = false;
                    FightMonsters(fighter);
                    break;
                case State.AFTER_FIGHT_STATE:
                    sb = new StringBuilder();
                    sb.Append(Environment.NewLine).Append(fighter.Name).Append(" just finised the fight and is ready to receive their rewards").Append(Environment.NewLine);
                    sb.Append(Environment.NewLine).Append(String.Join($"{Environment.NewLine}", fighter.Dung.RewardItems)).Append(Environment.NewLine);
                    GamePadRichText.AppendText($"{sb}");
                    LeaveDungeonButton.Enabled = false;
                    FightButton.Enabled = false;
                    RunAwayButton.Enabled = false;
                    EnterDungeonButton.Enabled = true;
                    break;
                case State.NOT_IN_DUNGEON_STATE:
                    GamePadRichText.AppendText($"{Environment.NewLine}{fighter.Name} is not in a dungeon, Lets enter a dungeon to fight monsters{Environment.NewLine}{Environment.NewLine}");
                    LeaveDungeonButton.Enabled = false;
                    FightButton.Enabled = false;
                    RunAwayButton.Enabled = false;
                    EnterDungeonButton.Enabled = true;
                    break;
                default:
                    Debug.WriteLine("Sorry an erorr occured while checked and setting the fighters status");
                    break;
            }
        }

        private static double HPTakenAfterRunningAway()
        {
            return Convert.ToDouble(((random.NextDouble() * (2.5 - 1.5)) + 1.5).ToString("#.#"));
        }

        private void FightMonster(Fighter fighter)
        {
            int i = fighter.Dung.Monsters.Count;
            double MonsterStrength = fighter.Dung.Monsters[i].WeaponStrength;
            double FighterStrength = fighter.WeaponStrength;

            if (i != 0 || i != -1)
            {
                fighter.Dung.Monsters[1].HealthPoints -= FighterStrength;
                GamePadRichText.AppendText(Environment.NewLine + $"{fighter.Name}: did {FighterStrength} damage points." + Environment.NewLine);
                fighter.HealthPoints -= MonsterStrength;
                GamePadRichText.AppendText($"{fighter.Dung.Monsters[1].Name} did {MonsterStrength} damage points");
            }
            else
            {
                GamePadRichText.AppendText("You defeated the dungeon");
            }
        }

        private void FightMonsters(Fighter fighter)
        {

            for (int i = 0; i < fighter.Dung.Monsters.Count; i++)
            {
                double MonsterStrength = fighter.Dung.Monsters[i].WeaponStrength;
                double FighterStrength = fighter.WeaponStrength;
                if (fighter.HealthPoints >= 0 && fighter.Dung.Monsters[i].HealthPoints >= 0)
                {
                    do
                    {
                        GamePadRichText.AppendText($"{fighter.Name}: did {FighterStrength} damage points.");
                        GamePadRichText.AppendText($"{fighter.Dung.Monsters[i].Name} did {MonsterStrength} damage points");
                    }
                    while (fighter.HealthPoints >= 1 && fighter.Dung.Monsters[i].HealthPoints >= 1);
                }
                else
                {
                    do
                    {
                    } while (fighter.HealthPoints <= 0 && fighter.Dung.Monsters[i].HealthPoints <= 0);
                }
            }
        }
    }
}
