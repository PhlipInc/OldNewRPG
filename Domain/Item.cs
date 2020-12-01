using System;
using System.Text;

namespace Domain
{
    [Serializable]
    public class Item
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int ShopPrice { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Name: ").Append(Name);
            sb.Append("Description: ").Append(Description);
            sb.Append("Shop Price: ").Append(ShopPrice);
            return sb.ToString();
        }
    }
}
