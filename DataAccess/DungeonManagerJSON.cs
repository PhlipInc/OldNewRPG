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
        List<Dungeon> dungeons { get; set; }
        List<Monster> monsters { get; set; }

        public async Task<List<Dungeon>> GetDungeons()
        {
            if (!File.Exists(DungeonPath))
            {
                MonsterManagerJSON MonsterManager = new MonsterManagerJSON(random);
                ItemManagerJSON ItemManager = new ItemManagerJSON(random);
                await MonsterManager.GetMonsters();
                dungeons = new List<Dungeon>
                {
                    new Dungeon()
                    {
                        Name = "Dungeon 1",
                        Level = 1,
                        RewardExperience = 100,
                        RewardItems = (await ItemManager.GetRandomItems()),
                        Monsters = (await MonsterManager.GetRandomMonsters(1))
                    },
                    new Dungeon()
                    {
                        Name = "Dungeon 2",
                        Level = 2,
                        RewardExperience = 200,
                        RewardItems = (await ItemManager.GetRandomItems()),
                        Monsters = (await MonsterManager.GetRandomMonsters(2))
                    },
                    new Dungeon()
                    {
                        Name = "Dungeon 3",
                        Level = 3,
                        RewardExperience = 300,
                        RewardItems = (await ItemManager.GetRandomItems()),
                        Monsters = (await MonsterManager.GetRandomMonsters(3))
                    },
                    new Dungeon()
                    {
                        Name = "Dungeon 4",
                        Level = 4,
                        RewardExperience = 400,
                        RewardItems = (await ItemManager.GetRandomItems()),
                        Monsters = (await MonsterManager.GetRandomMonsters(4))
                    }
                };
                await SetDungeons(dungeons);
            }
            else
            {
                using (FileStream fs = File.OpenRead(DungeonPath))
                {
                    dungeons = (await JsonSerializer.DeserializeAsync<List<Dungeon>>(fs));
                }
            }
            return dungeons;
        }
        public async Task SetDungeons(List<Dungeon> dungeons)
        {
            try
            {
                using (FileStream fs = File.Create(DungeonPath))
                {
                    await JsonSerializer.SerializeAsync(fs, this.dungeons, jso);
                    fs.Dispose();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        public async Task<Dungeon> GetRandomDungeon(Fighter fighter)
        {
            Debug.WriteLine(fighter.Name);
            fighter.Dung = (await GetDungeons())[random.Next(1, dungeons.Count)];
            return fighter.Dung;
        }
    }
}
