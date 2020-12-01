using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    [Serializable]
    public class Monster
    {
        public string Name { get; set; }
        public int RewardPotatoes { get; set; }
        public double RewardExperience { get; set; }
        public string Weapon { get; set; }
        public double WeaponStrength { get; set; }
        public string Armor { get; set; }
        public double ArmorStrength { get; set; }
        public int Level { get; set; }
        public double HealthPoints { get; set; }
        public bool IsBoss { get; set; } = false;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Name: ").Append(Name).Append(Environment.NewLine);
            sb.Append("Reward Potatoes: ").Append(RewardPotatoes).Append(Environment.NewLine);
            sb.Append("Reward Experience: ").Append(RewardExperience).Append(Environment.NewLine);
            sb.Append("Weapon: ").Append(Weapon).Append('[').Append(WeaponStrength).Append(']').Append(Environment.NewLine);
            sb.Append("Armor: ").Append(Armor).Append('[').Append(ArmorStrength).Append(']').Append(Environment.NewLine);
            sb.Append("Level: ").Append(Level).Append(Environment.NewLine);
            sb.Append("HP: ").Append(HealthPoints).Append(Environment.NewLine);
            sb.Append("Boss: ").Append(IsBoss).Append(Environment.NewLine);
            return sb.ToString();
        }
    }
}
