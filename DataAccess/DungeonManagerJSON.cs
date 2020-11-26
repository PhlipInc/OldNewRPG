using System;
using Domain;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Diagnostics;

namespace DataAccess
{
    public class DungeonManagerJSON
    {
        public DungeonManagerJSON(Random random)
        {

        }

        private Random random = new Random();
        JsonSerializerOptions jso = new JsonSerializerOptions() { WriteIndented = true };
        public const string DungeonPath = "rpg/OldNewRPG/Dungeons.json";
        Dungeon dungeon = new Dungeon();
        List<Dungeon> dungeons { get; set; }

        public List<Dungeon> GetDungeons()
        {
            if (!File.Exists(DungeonPath))
            {
                dungeons = new List<Dungeon>
                {
                    new Dungeon()
                    {
                        Name = "Dungeon 1",
                        Level = 1,
                        RewardExperience = 100
                    },
                    new Dungeon()
                    {
                        Name = "Dungeon 2",
                        Level = 2,
                        RewardExperience = 200
                    },
                    new Dungeon()
                    {
                        Name = "Dungeon 3",
                        Level = 3,
                        RewardExperience = 300
                    },
                    new Dungeon()
                    {
                        Name = "Dungeon 4",
                        Level = 4,
                        RewardExperience = 400
                    }
                };
                SetDungeons(dungeons);
            }
            else
            {
                using (StreamReader sr = new StreamReader(DungeonPath))
                {
                    dungeons = JsonSerializer.Deserialize<List<Dungeon>>(sr.ReadToEnd());
                }
            }
            return dungeons;
        }
        public async void SetDungeons(List<Dungeon> dungeons)
        {
            try
            {
                using (FileStream fs = File.Create(DungeonPath))
                {
                    await JsonSerializer.SerializeAsync(fs, this.dungeons, jso);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        public Dungeon GetRandomDungeon()
        {
            return GetDungeons()[random.Next(1, dungeons.Count)];
        }
    }
}
