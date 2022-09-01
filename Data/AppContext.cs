using Granto.Models;
using Microsoft.EntityFrameworkCore;

namespace Granto.Data
{
    public class AppContext : DbContext
    {
        public AppContext(DbContextOptions<AppContext> opts) : base(opts)
        {

        }

        public DbSet<User> Users { get; set; }
    }
}
