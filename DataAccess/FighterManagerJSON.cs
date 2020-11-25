using Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace DataAccess
{
    public class FighterManagerJSON : IDataManager
    {
        //private Random random;
        JsonSerializerOptions jso = new JsonSerializerOptions() { WriteIndented = true };
        public const string FighterPathStart = "rpg/OldNewRPG/";
        public const string FighterPathEnd = "-Fighter.json";
        public const string ItemPath = "rpg/OldNewRPG/Items.json";
        List<Item> itemer { get; set; }
        Fighter fighter;
        public FighterManagerJSON(Random random)
        {
            //this.random = random;
        }

        public List<Item> GetItems()
        {
            if (!File.Exists(ItemPath))
            {
                itemer = new List<Item>
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

                SetItems(itemer);
            }
            else
            {
                using (StreamReader sr = new StreamReader(ItemPath))
                {
                    itemer = JsonSerializer.Deserialize<List<Item>>(sr.ReadToEnd());
                }
            }
            return itemer;
        }

        public async void SetItems(List<Item> itemer)
        {
            try
            {
                using (FileStream fs = File.Create(ItemPath))
                {
                    await JsonSerializer.SerializeAsync(fs, itemer,jso);
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