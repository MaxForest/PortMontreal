using GestionVoyage.API.Context;

namespace GestionVoyage.API.Repositories
{
    public class BaseRepository<T>(GestionVoyageDbContext context) where T : class
    {
        protected readonly GestionVoyageDbContext _context = context;

        public async Task Add(T value)
        {
            await _context.AddRangeAsync(value);
        }
    }
}
