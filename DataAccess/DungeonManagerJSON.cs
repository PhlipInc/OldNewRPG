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
            this.random = random;
        }

        private readonly Random random = new Random();
        private readonly JsonSerializerOptions jso = new JsonSerializerOptions() { WriteIndented = true };
        public const string DungeonPath = "rpg/OldNewRPG/Dungeons.json";
        private List<Dungeon> Dungeons { get; set; }

        public async Task<List<Dungeon>> GetDungeons()
        {
            if (!File.Exists(DungeonPath))
            {
                MonsterManagerJSON MonsterManager = new MonsterManagerJSON(random);
                ItemManagerJSON ItemManager = new ItemManagerJSON(random);
                await MonsterManager.GetMonsters().ConfigureAwait(false);
                Dungeons = new List<Dungeon>
                {
                    new Dungeon()
                    {
                        Name = "Dungeon 1",
                        Level = 1,
                        RewardExperience = 100,
                        RewardItems = (await ItemManager.GetRandomItems().ConfigureAwait(false)),
                        Monsters = (await MonsterManager.GetRandomMonsters(1).ConfigureAwait(false))
                    },
                    new Dungeon()
                    {
                        Name = "Dungeon 2",
                        Level = 2,
                        RewardExperience = 200,
                        RewardItems = (await ItemManager.GetRandomItems().ConfigureAwait(false)),
                        Monsters = (await MonsterManager.GetRandomMonsters(2).ConfigureAwait(false))
                    },
                    new Dungeon()
                    {
                        Name = "Dungeon 3",
                        Level = 3,
                        RewardExperience = 300,
                        RewardItems = (await ItemManager.GetRandomItems().ConfigureAwait(false)),
                        Monsters = (await MonsterManager.GetRandomMonsters(3).ConfigureAwait(false))
                    },
                    new Dungeon()
                    {
                        Name = "Dungeon 4",
                        Level = 4,
                        RewardExperience = 400,
                        RewardItems = (await ItemManager.GetRandomItems().ConfigureAwait(false)),
                        Monsters = (await MonsterManager.GetRandomMonsters(4).ConfigureAwait(false))
                    }
                };
                await SetDungeons().ConfigureAwait(false);
            }
            else
            {
                using FileStream fs = File.OpenRead(DungeonPath);
                Dungeons = (await JsonSerializer.DeserializeAsync<List<Dungeon>>(fs).ConfigureAwait(false));
            }
            return Dungeons;
        }
        public async Task SetDungeons()
        {
            try
            {
                using FileStream fs = File.Create(DungeonPath);
                await JsonSerializer.SerializeAsync(fs, this.Dungeons, jso).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        public async Task<Dungeon> GetRandomDungeon(Fighter fighter)
        {
            fighter.Dung = (await GetDungeons().ConfigureAwait(false))[random.Next(1, Dungeons.Count)];
            return fighter.Dung;
        }
    }
}
