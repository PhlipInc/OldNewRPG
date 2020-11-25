using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    [Serializable]
    public class Monster
    {
        public string Name { get; set; }
        public double RewardExperience { get; set; }
        public string Weapon { get; set; }
        public double WeaponStrength { get; set; }
        public string Armor { get; set; }
        public double ArmorStrength { get; set; }
        public int Level { get; set; }
        public double HealthPoints { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {Name}");
            sb.AppendLine($"RewardExperience: {RewardExperience}");
            sb.AppendLine($"Weapon: {Weapon}[{WeaponStrength}]");
            sb.AppendLine($"Armor: {Armor}[{ArmorStrength}]");
            sb.AppendLine($"Level: {Level}");
            sb.AppendLine($"HP: {HealthPoints}");
            return sb.ToString();
        }
    }
}
