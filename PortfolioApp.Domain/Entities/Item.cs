namespace PortfolioApp.Domain.Entities
{
    public class Item
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Comments { get; set; }
        public int ColorId { get; set; }
        public Color Color { get; set; }
    }
}
