using PortfolioApp.Domain.Entities;

namespace PortfolioApp.Infrastructure.Persistence.DummyData
{
    public class DummyItems
    {
        public static List<Item> Get()
        {
            Item c1 = new()
            {
                Id = 1,
                ColorId = ColorSeed.Red,
                Code = "414-AS",
                Comments = "Comment test",
                Name = "317-80"
            };
            Item c2 = new()
            {
                Id = 2,
                ColorId = ColorSeed.Yellow,
                Code = "414-AZ",
                Comments = "Comment test",
                Name = "337-80"
            };
            Item c3 = new()
            {
                Id = 3,
                ColorId = ColorSeed.Green,
                Code = "414-AA",
                Comments = "Comment test",
                Name = "357-81"
            };
            List<Item> p = new()
            {
                c1,
                c2,
                c3
            };

            return p;
        }
    }
}
