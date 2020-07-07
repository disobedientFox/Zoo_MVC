using Microsoft.EntityFrameworkCore;
using Zoo_w57047.Entity;

namespace Zoo_w57047.Database
{
    public class ZooContext : DbContext
    {
        public DbSet<Zoo> Zoos { get; set; }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Aviary> Aviaries { get; set; }
        public ZooContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Zoo>(m =>
            {
                m.ToTable("Zoo");
                m.HasKey(x => x.Id);
            });

            modelBuilder.Entity<Animal>(m =>
            {
                m.ToTable("Animal");
                m.HasKey(x => x.Id);
            });

            modelBuilder.Entity<Aviary>(m =>
            {
                m.ToTable("Aviary");
                m.HasKey(x => x.Id);
            });
        }
    }
}
