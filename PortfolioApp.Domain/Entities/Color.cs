using System.Text.Json.Serialization;

namespace PortfolioApp.Domain.Entities
{
    public class Color
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public ICollection<Item> Items { get; set; }
    }
}