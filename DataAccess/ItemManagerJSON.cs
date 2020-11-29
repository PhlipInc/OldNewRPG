using System;
using Domain;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Diagnostics;

namespace DataAccess
{
    public class ItemManagerJSON
    {
        public ItemManagerJSON(Random random)
        {

        }

        private Random random = new Random();
        JsonSerializerOptions jso = new JsonSerializerOptions() { WriteIndented = true };
        public const string ItemPath = "rpg/OldNewRPG/Items.json";
        List<Item> items { get; set; }


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
                    sr.Dispose();
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
                    fs.Dispose();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        public Item GetRandomItem()
        {
            return GetItems()[random.Next(1, items.Count)];
        }

        public List<Item> GetRandomItems()
        {
            List<Item> RandomItems = new List<Item>();
            items = GetItems();
            int RandomItemCount = random.Next(1, items.Count);

            for (int i = 0; i < RandomItemCount; i++)
            {
                RandomItems.Add(items[i]);
            }
            return RandomItems;
        }

    }
}
