using PortfolioApp.Domain.Entities;

namespace PortfolioApp.Infrastructure.Persistence.DummyData
{
    public class DummyUsers
    {
        public static List<User> Get()
        {
            User c1 = new()
            {
                Id = 1,
                FirstName = "Jane",
                LastName = "Seymour",
                Email = "jane.seymour@diag.com",
                RoleId = 2,
            };
            User c2 = new()
            {
                Id = 2,
                FirstName = "Kate",
                LastName = "Walsh",
                Email = "kate.walsh@diag.com",
                RoleId = 2,
            };
            User c3 = new()
            {
                Id = 3,
                FirstName = "Omar",
                LastName = "Epps",
                Email = "omar.epps@diag.com",
                RoleId = 1,
            };
            List<User> p = new()
            {
                c1,
                c2,
                c3
            };

            return p;
        }
    }
}
