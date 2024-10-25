using Microsoft.EntityFrameworkCore;

namespace FirstDotNetMVC.Models
{
    public class UsersDbContext :DbContext
    {
       public DbSet<User> Users { get; set; }

        public UsersDbContext(DbContextOptions<UsersDbContext> options)
            :base(options) { }
    
    }
}
