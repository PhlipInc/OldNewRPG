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
    public class MonsterManagerJSON
    {
        public MonsterManagerJSON(Random random)
        {

        }

        private Random random = new Random();
        JsonSerializerOptions jso = new JsonSerializerOptions() { WriteIndented = true };
        public const string MonsterPath = "rpg/OldNewRPG/Monsters.json";
        List<Monster> monsters { get; set; }

        public async Task<List<Monster>> GetMonsters()
        {
            if (!File.Exists(MonsterPath))
            {
                monsters = new List<Monster>
                {
                    new Monster()
                    {
                        Name ="Monster 1",
                        Armor = "The Armor 1",
                        ArmorStrength = 1,
                        Weapon = "The Weapon 1",
                        WeaponStrength = 1,
                        HealthPoints = 10,
                        Level = 1,
                        RewardExperience = 100
                    },
                    new Monster()
                    {
                        Name ="Monster 2",
                        Armor = "The Armor 2",
                        ArmorStrength = 2,
                        Weapon = "The Weapon 2",
                        WeaponStrength = 2,
                        HealthPoints = 20,
                        Level = 2,
                        RewardExperience = 200
                    },
                    new Monster()
                    {
                        Name ="Monster 3",
                        Armor = "The Armor 3",
                        ArmorStrength = 3,
                        Weapon = "The Weapon 3",
                        WeaponStrength = 3,
                        HealthPoints = 30,
                        Level = 3,
                        RewardExperience = 300
                    },
                    new Monster()
                    {
                        Name ="Monster 4",
                        Armor = "The Armor 4",
                        ArmorStrength = 4,
                        Weapon = "The Weapon 4",
                        WeaponStrength = 4,
                        HealthPoints = 40,
                        Level = 4,
                        RewardExperience = 400,
                        IsBoss = true
                    }

                };
                await SetMonsters(monsters);
            }
            else
            {
                using (FileStream fs = File.OpenRead(MonsterPath))
                {
                    monsters = await JsonSerializer.DeserializeAsync<List<Monster>>(fs);
                }
            }
            return monsters;
        }
        public async Task SetMonsters(List<Monster> monsters)
        {
            try
            {
                using (FileStream fs = File.Create(MonsterPath))
                {
                    await JsonSerializer.SerializeAsync(fs, this.monsters, jso);
                    fs.Dispose();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
        public async Task<Monster> GetRandomMonster()
        {
            return (await GetMonsters())[random.Next(1, monsters.Count)];
        }

        public async Task<List<Monster>> GetRandomMonsters(int Level)
        {
            List<Monster> DungeonMonsters = new List<Monster>();
            int RandomMonsterCount = random.Next(1, monsters.Count);
            monsters = (await GetMonsters()).Where(x => x.Level <= Level + 2).ToList();

            for (int i = 0; i < RandomMonsterCount; i++)
            {
                DungeonMonsters.Add(monsters[i]);
            }
            return DungeonMonsters;
        }
    }
}
