using Granto.Models;
using Microsoft.EntityFrameworkCore;

namespace Granto.Data
{
    public class AppGrantoContext : DbContext
    {
        public AppGrantoContext(DbContextOptions<AppGrantoContext> opt) : base(opt)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasIndex(u=>u.email)
                .IsUnique();

            builder.Entity<Oportunidade>()
                .HasOne(oportunidade => oportunidade.User)
                .WithMany(user => user.Oportunidades)
                .HasForeignKey(oportunidade => oportunidade.UserId);

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Oportunidade> Oportunidades { get; set; }
    }
}
