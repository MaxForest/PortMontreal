using GestionVoyage.API.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionVoyage.API.Context
{
    public class GestionVoyageDbContext(DbContextOptions<GestionVoyageDbContext> options) : DbContext(options)
    {
        public DbSet<Arrivee> Arrivees { get; set; }

        public DbSet<Depart> Departs { get; set; }

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
    }
}
