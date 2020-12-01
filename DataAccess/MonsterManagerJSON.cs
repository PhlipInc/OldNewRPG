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
            this.random = random;
        }

        private readonly Random random = new Random();
        private readonly JsonSerializerOptions jso = new JsonSerializerOptions() { WriteIndented = true };
        public const string MonsterPath = "rpg/OldNewRPG/Monsters.json";
        private List<Monster> Monsters { get; set; }

        public async Task<List<Monster>> GetMonsters()
        {
            if (!File.Exists(MonsterPath))
            {
                Monsters = new List<Monster>
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
                        RewardExperience = 100,
                        RewardPotatoes = 1000
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
                        RewardExperience = 200,
                        RewardPotatoes = 2000
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
                        RewardExperience = 300,
                        RewardPotatoes = 3000
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
                        RewardPotatoes = 4000,
                        IsBoss = true
                    }
                };
                await SetMonsters().ConfigureAwait(false);
            }
            else
            {
                using FileStream fs = File.OpenRead(MonsterPath);
                Monsters = await JsonSerializer.DeserializeAsync<List<Monster>>(fs).ConfigureAwait(false);
            }
            return Monsters;
        }
        public async Task SetMonsters()
        {
            try
            {
                using FileStream fs = File.Create(MonsterPath);
                await JsonSerializer.SerializeAsync(fs, this.Monsters, jso).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
        public async Task<Monster> GetRandomMonster()
        {
            return (await GetMonsters().ConfigureAwait(false))[random.Next(1, Monsters.Count)];
        }

        public async Task<List<Monster>> GetRandomMonsters(int Level)
        {
            List<Monster> DungeonMonsters = new List<Monster>();
            int RandomMonsterCount = random.Next(1, Monsters.Count);
            Monsters = (await GetMonsters().ConfigureAwait(false)).Where(x => x.Level <= Level + 2).ToList();

            for (int i = 0; i < RandomMonsterCount; i++)
            {
                DungeonMonsters.Add(Monsters[i]);
            }
            return DungeonMonsters;
        }
    }
}
