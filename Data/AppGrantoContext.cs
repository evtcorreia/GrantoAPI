using Granto.Models;
using Microsoft.EntityFrameworkCore;

namespace Granto.Data
{
    public class AppGrantoContext : DbContext
    {
        public AppGrantoContext(DbContextOptions<AppGrantoContext> opt) : base(opt)
        {

        }

        public DbSet<User> Users { get; set; }
    }
}
