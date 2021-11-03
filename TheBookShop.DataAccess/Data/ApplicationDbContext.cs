using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TheBookShop.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options) { }

        public DbSet<BookShopAsset> BookShopAssets { get; set; }
        public DbSet<Patron> Patrons { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
    }
}
