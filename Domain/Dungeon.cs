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
        public Dictionary<string, int> RewardItems { get; set; }

        public override string ToString()
        {
            RewardItems = new Dictionary<string, int>();
            RewardItems.Add("Item 1", 1);
            RewardItems.Add("Item 2", 2);
            RewardItems.Add("Item 3", 3);
            RewardItems.Add("Item 4", 4);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {Name}");
            sb.AppendLine($"RewardExperience: {RewardExperience}");
            sb.AppendLine($"Dungeon Level: {Level}");
            sb.AppendLine($"Items: [ {string.Join(" ] | [ ", RewardItems.Keys)} ]");
            return sb.ToString();
        }
    }
}
