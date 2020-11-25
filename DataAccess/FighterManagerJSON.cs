using Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.Json;

namespace DataAccess
{
    public class FighterManagerJSON : IDataManager
    {
        private Random random = new Random();
        JsonSerializerOptions jso = new JsonSerializerOptions() { WriteIndented = true };
        public const string FighterPathStart = "rpg/OldNewRPG/";
        public const string FighterPathEnd = "-Fighter.json";
        public const string ItemPath = "rpg/OldNewRPG/Items.json";
        public const string DungeonPath = "rpg/OldNewRPG/Dungeons.json";
        public const string MonsterPath = "rpg/OldNewRPG/Monsters.json";
        List<Item> items { get; set; }
        Dungeon dungeon = new Dungeon();
        List<Dungeon> dungeons { get; set; }
        List<Monster> monsters { get; set; }
        Fighter fighter;
        public FighterManagerJSON(Random random)
        {
            //this.random = random;
        }

        public Dungeon GetRandomDungeon()
        {
            return GetDungeons()[random.Next(1, dungeons.Count)];
        }

        public Dungeon SetRandomDungeon(Dungeon dungeon)
        {
            return dungeon;
        }

        public List<Monster> GetMonsters()
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
                        RewardExperience = 400
                    }

                };
                SetMonsters(monsters);
            }
            else
            {
                using (StreamReader sr = new StreamReader(MonsterPath))
                {
                    monsters = JsonSerializer.Deserialize<List<Monster>>(sr.ReadToEnd());
                }
            }
            return monsters;
        }
        public async void SetMonsters(List<Monster> monsters)
        {
            try
            {
                using (FileStream fs = File.Create(MonsterPath))
                {
                    await JsonSerializer.SerializeAsync(fs, this.monsters, jso);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

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

        public List<Item> GetItems()
        {
            if (!File.Exists(ItemPath))
            {
                items = new List<Item>
                {
                    new Item()
                    {
                        Name = "Item 1",
                        Description = "This is the description for Item 1",
                        ShopPrice = 123
                    },
                    new Item()
                    {
                        Name = "Item 3",
                        Description = "This is the description for Item 2",
                        ShopPrice = 234
                    },
                    new Item()
                    {
                        Name = "Item 3",
                        Description = "This is the description for Item 3",
                        ShopPrice = 324214
                    },
                    new Item()
                    {
                        Name = "Item 4",
                        Description= "This is the description for Item 4",
                        ShopPrice = 42341
                    }
                };
                SetItems(items);
            }
            else
            {
                using (StreamReader sr = new StreamReader(ItemPath))
                {
                    items = JsonSerializer.Deserialize<List<Item>>(sr.ReadToEnd());
                }
            }
            return items;
        }
        public async void SetItems(List<Item> items)
        {
            try
            {
                using (FileStream fs = File.Create(ItemPath))
                {
                    await JsonSerializer.SerializeAsync(fs, this.items, jso);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        public Fighter GetFighter(string id)
        {
            if(!File.Exists(FighterPathStart + id + FighterPathEnd))
            {
                fighter = Fighter.NewFighterInstance();
                SetFighter(id, fighter);
            }
            else
            {
                using (StreamReader sr =  new  StreamReader(FighterPathStart + id + FighterPathEnd))
                {
                    fighter = JsonSerializer.Deserialize<Fighter>(sr.ReadToEnd());
                }
            }
            return fighter;
        }
        public async void SetFighter(string id, Fighter fighter)
        {
            try
            {
                using (FileStream fs = File.Create(FighterPathStart + id + FighterPathEnd))
                {
                    await JsonSerializer.SerializeAsync(fs, fighter, jso);
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}