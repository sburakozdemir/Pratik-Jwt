using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Pratik_Jwt.Data
{
    public class JwtDbContext:IdentityDbContext<IdentityUser>
    {
        public JwtDbContext(DbContextOptions<JwtDbContext>options):base(options)
        {
            
        }
        public DbSet<User> Users { get; set; }
    }
}
