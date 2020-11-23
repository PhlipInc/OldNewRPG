using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public enum State
    {
        IN_DUNGEON_STATE = 0,
        IN_FIGHT_STATE = 1,
        AFTER_FIGHT_STATE = 2,
        NOT_IN_DUNGEON_STATE = 3

    }
    [Serializable]
    public class Fighter
    {
        private string Id = Environment.MachineName;
        public string Name { get; set; }
        public string Weapon { get; set; }
        public string Armor { get; set; }
        public int Level { get; set; }
        public int Experience { get; set; }
        public double HealthPoints { get; set; }
        public Dictionary<string, int> Items { get; set; }
        public bool IsFirstTimePlaying { get; set; }
        public State PlayerState { get; set; }
        private string name = Environment.UserName;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {Name}");
            sb.AppendLine($"Id: {Id}");
            sb.AppendLine($"Weapon: {Weapon}");
            sb.AppendLine($"Armor: {Armor}");
            sb.AppendLine($"Items: {string.Join(" | ", Items.Keys)}");
            sb.AppendLine($"XP: {Experience}");
            sb.AppendLine($"Level: {Level}");
            sb.AppendLine($"HP: {HealthPoints} / {MaxHp(Level)}");
            sb.AppendLine($"First Timer: {IsFirstTimePlaying}");
            sb.AppendLine($"Status: {PlayerState}");
            return sb.ToString();
        }

        public double MaxHp(int level)
        {
            return 10 * level;
        }

        public void AddItem(string item)
        {
            if (Items.ContainsKey(item))
            {
                Items[item]++;
            }
            else
            {
                Items.Add(item, 1);
            }
        }

        public void RemoveItem(string item)
        {
            //Items.Remove[item];
            Items.Remove(item);
        }
        public void AddExp(int exp)
        {
            Experience += exp;
        }
        public void RemoveExp(int exp)
        {
            Experience -= exp;
        }
        public void AddLevel(int level)
        {
            Level += level;
        }
        public void RemoveLevel(int level)
        {
            Level -= level;
        }
        public void AddHP(double hp)
        {
            HealthPoints += hp;
        }
        public void RemoveHP(double hp)
        {
            HealthPoints -= hp;
        }
        public void UpdateStatus(State state)
        {
            PlayerState = state;
        }

        public static Fighter NewFighterInstance()
        {
            Fighter nFighter = new Fighter();
            nFighter.Items = new Dictionary<string, int>();
            nFighter.Items.Add("Nerds", 5);
            nFighter.Items.Add("Are", 5);
            nFighter.Items.Add("Not", 5);
            nFighter.Items.Add("Crzy", 5);

            nFighter.Name = nFighter.name;
            nFighter.Weapon = "Potato Sword[+1]";
            nFighter.Armor = "Potato Armor[+0.5]";
            nFighter.Items = nFighter.Items;
            nFighter.Experience = 0;
            nFighter.Level = 1;
            nFighter.HealthPoints = 10;
            nFighter.IsFirstTimePlaying = true;
            nFighter.PlayerState = State.NOT_IN_DUNGEON_STATE;
            return nFighter;
        }
    }
}
