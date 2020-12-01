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
        public int RewardPotatoes { get; set; }
        public int Level { get; set; }
        public List<Item> RewardItems { get; set; }
        public List<Monster> Monsters { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Name: ").AppendLine(Name);
            sb.Append("Reward Potatoes: ").Append(RewardPotatoes);
            sb.Append("RewardExperience: ").AppendLine(RewardExperience.ToString());
            sb.Append("Dungeon Level: ").AppendLine(Level.ToString());
            foreach (var item in RewardItems)
            {
                sb.Append("Items: [ {RewardItems} ]").AppendLine(item.Name);
            }
            foreach (var item in Monsters)
            {
                sb.Append("Monsters: ").Append(item.Name);
            }
            return sb.ToString();
        }
    }
}
