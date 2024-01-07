using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace please2.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
 
    }
        public DbSet<please2.Models.Livre> Livre { get; set; } = default!;
        public DbSet<please2.Models.Category> Category { get; set; } = default!;
        public DbSet<please2.Models.Author> Author { get; set; } = default!;
        public DbSet<please2.Models.Reservation> Reservation { get; set; } = default!;
    }
}
