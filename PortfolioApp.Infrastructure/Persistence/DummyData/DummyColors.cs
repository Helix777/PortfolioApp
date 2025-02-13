using PortfolioApp.Domain.Entities;

namespace PortfolioApp.Infrastructure.Persistence.DummyData
{
    public class DummyColors
    {
        public static List<Color> Get()
        {
            Color c1 = new Color()
            {
                Id = ColorSeed.Red,
                Name = "Red",
            };
            Color c2 = new Color()
            {
                Id = ColorSeed.Green,
                Name = "Green",
            };
            Color c3 = new Color()
            {
                Id = ColorSeed.Yellow,
                Name = "Yellow",
            };

            List<Color> p = new()
            {
                c1,
                c3,
                c2
            };

            return p;
        }
    }
}
