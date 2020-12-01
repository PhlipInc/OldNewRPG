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
            this.random = random;
        }

        private readonly Random random = new Random();
        private readonly JsonSerializerOptions jso = new JsonSerializerOptions() { WriteIndented = true };
        private const string ItemPath = "rpg/OldNewRPG/Items.json";
        private List<Item> Items { get; set; }

        public async Task<List<Item>> GetItems()
        {
            if (!File.Exists(ItemPath))
            {
                Items = new List<Item>
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
                await SetItems().ConfigureAwait(false);
            }
            else
            {
                using FileStream fs = File.OpenRead(ItemPath);
                Items = await JsonSerializer.DeserializeAsync<List<Item>>(fs).ConfigureAwait(false);
            }
            return Items;
        }

        public async Task SetItems()
        {
            try
            {
                using FileStream fs = File.Create(ItemPath);
                await JsonSerializer.SerializeAsync(fs, this.Items, jso).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        public async Task<Item> GetRandomItem()
        {
            return (await GetItems().ConfigureAwait(false))[random.Next(1, Items.Count)];
        }

        public async Task<List<Item>> GetRandomItems()
        {
            List<Item> RandomItems = new List<Item>();
            Items = (await GetItems().ConfigureAwait(false));
            int RandomItemCount = random.Next(1, Items.Count);

            for (int i = 0; i < RandomItemCount; i++)
            {
                RandomItems.Add(Items[i]);
            }
            return RandomItems;
        }
    }
}
