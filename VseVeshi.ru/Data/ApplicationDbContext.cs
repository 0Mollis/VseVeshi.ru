using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VseVeshi.ru.Models;

namespace VseVeshi.ru.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Catalog> Catalog { get; set; }
        public DbSet<UsersDB> UsersDB {  get; set; }
        public DbSet<RentItems> RentItems {  get; set; }
        public DbSet<Cart> carts { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
