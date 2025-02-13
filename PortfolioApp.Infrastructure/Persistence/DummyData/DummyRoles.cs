using PortfolioApp.Domain.Entities;

namespace PortfolioApp.Infrastructure.Persistence.DummyData
{
    public class DummyRoles
    {
        public static List<Role> Get()
        {
            Role c1 = new Role()
            {
                Id = RolesSeed.AdminItemsManagement,
                Name = "AdminItemsManagement",
            };
            Role c2 = new Role()
            {
                Id = RolesSeed.SuperAdmin,
                Name = "SuperAdmin",
            };

            List<Role> p = new()
            {
                c1,
                c2
            };

            return p;
        }
    }
}
