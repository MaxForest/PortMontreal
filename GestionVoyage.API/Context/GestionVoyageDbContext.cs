using GestionVoyage.API.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionVoyage.API.Context
{
    public class GestionVoyageDbContext(DbContextOptions<GestionVoyageDbContext> options) : DbContext(options)
    {
        public DbSet<Trajet> Trajets { get; set; }

        public DbSet<Port> Ports { get; set; }

        public async Task AddRangeAsync<T>(params T[] values) where T : class
        {
            await Set<T>().AddRangeAsync(values);
            await SaveChangesAsync();
        }

        public async Task ExecuteDeleteAsync<T>(IQueryable<T> query) where T : class
        {
            await query.ExecuteDeleteAsync();
            await SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Trajet>()
                .OwnsOne(b => b.Depart);

            modelBuilder.Entity<Trajet>()
                .OwnsOne(b => b.Arrivee);
        }
    }
}