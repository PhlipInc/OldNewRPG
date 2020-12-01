using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

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
        public string Id = Environment.MachineName;
        public string Name { get; set; }
        public int Potatoes { get; set; }
        public string Weapon { get; set; }
        public double WeaponStrength { get; set; }
        public string Armor { get; set; }
        public double ArmorStrength { get; set; }
        public int Level { get; set; }
        public double Experience { get; set; }
        public double HealthPoints { get; set; }
        public List<Item> Items { get; set; }
        public bool IsFirstTimePlaying { get; set; }
        public State PlayerState { get; set; }
        private readonly string name = Environment.UserName;
        public Dungeon Dung { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Name: ").Append(Name).Append(Environment.NewLine);
            sb.Append("Potatoes: ").Append(Potatoes).Append(Environment.NewLine);
            sb.Append("Id: ").Append(Id).Append(Environment.NewLine);
            sb.Append("Weapon: ").Append(Weapon).Append('[').Append(WeaponStrength).Append(']').Append(Environment.NewLine);
            sb.Append("Armor: ").Append(Armor).Append('[').Append(ArmorStrength).Append(']').Append(Environment.NewLine);
            sb.Append("Items: | ");
            foreach (var item in Items)
            {
                sb.Append(item.Name).Append(" | ");
            }
            sb.Append(Environment.NewLine);
            sb.Append("XP: ").Append(Experience).Append(Environment.NewLine);
            sb.Append("Level: ").Append(Level).Append(Environment.NewLine);
            sb.Append("HP: ").Append(HealthPoints).Append('/').Append(MaxHp(Level)).Append(Environment.NewLine);
            sb.Append("First Timer: ").Append(IsFirstTimePlaying).Append(Environment.NewLine);
            sb.Append("Status: ").Append(PlayerState.ToString()).Append(Environment.NewLine);
            return sb.ToString();
        }

        public static double MaxHp(double level)
        {
            return 10 * level;
        }

        public void AddItem(Item item)
        {
            if (Items.Contains(item))
            {
                Debug.WriteLine("Already Contains this item");
            }
            else
            {
                Items.Add(item);
            }
        }

        public void RemoveItem(Item item)
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
            //Fix so the format is 00000.0
            //HealthPoints -= hp;
        }
        public void UpdateStatus(State state)
        {
            PlayerState = state;
        }
        public static void IncrementLevelFromExperience(int experience, Fighter fighter)
        {
            fighter.Experience += experience;
            double level = 1 / (Math.Log(1.5)) * Math.Log(fighter.Experience / 740);
            fighter.Level = Convert.ToInt32(level);
            fighter.HealthPoints = MaxHp(fighter.Level);
        }

        public static Fighter NewFighterInstance()
        {
            Fighter nFighter = new Fighter
            {
                Items = new List<Item>()
                {
                    new Item
                    {
                        Name = "Item 1",
                        Description = "This is the description for Item 1",
                        ShopPrice = 123
                    },
                    new Item
                    {
                        Name = "Item 2",
                        Description = "This is the description for Item 2",
                        ShopPrice = 234
                    },
                    new Item
                    {
                        Name = "Item 3",
                        Description = "This is the description for Item 3",
                        ShopPrice = 324214
                    }
                }
            };

            nFighter.Name = nFighter.name;
            nFighter.Potatoes = 2000;
            nFighter.WeaponStrength = +1;
            nFighter.Weapon = "Potato Sword";
            nFighter.ArmorStrength = +0.5;
            nFighter.Armor = "Potato Armor";

            nFighter.Items = nFighter.Items;
            nFighter.Experience = 1110.5;
            nFighter.Level = 1;
            nFighter.HealthPoints = 10;
            nFighter.IsFirstTimePlaying = true;
            nFighter.PlayerState = State.NOT_IN_DUNGEON_STATE;
            return nFighter;
        }
    }
}