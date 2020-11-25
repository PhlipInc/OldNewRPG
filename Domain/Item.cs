using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Domain
{
    [Serializable]
    public class Item
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int ShopPrice { get; set; }
        public List<Item> Items { get; set; }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {Name}");
            sb.AppendLine($"Description: {Description}");
            sb.AppendLine($"Shop Price: {ShopPrice}");
            return sb.ToString();
        }

        public void DefaultItemList()
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
        }
    }
}
