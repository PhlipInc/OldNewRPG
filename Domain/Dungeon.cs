using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    [Serializable]
    public class Dungeon
    {
        public string Name { get; set; }
        public double RewardExperience { get; set; }
        public int Level { get; set; }
        public List<Item> RewardItems { get; set; }
        public List<Monster> Monsters { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {Name}");
            sb.AppendLine($"RewardExperience: {RewardExperience}");
            sb.AppendLine($"Dungeon Level: {Level}");
            sb.AppendLine($"Items: [ {RewardItems} ]");
            sb.AppendLine("Monsters: " + Monsters);
            return sb.ToString();
        }
    }
}
