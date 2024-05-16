using GestionVoyage.API.Context;
using GestionVoyage.API.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionVoyage.API.Repositories
{
    public class ArriveRepository(GestionVoyageDbContext context)
    {
        private readonly GestionVoyageDbContext _context = context;

        public async Task Add(Arrivee value)
        {
            await _context.AddRangeAsync(value);
        }

        public async Task<IEnumerable<Arrivee>> Get()
        {
            return await _context.Arrivees.ToListAsync();
        }

        public async Task<Arrivee> Get(int id)
        {
            return await _context.Arrivees.FirstAsync(x => x.Id == id);
        }

        public async Task Update(int id, Arrivee value)
        {
            _context.Entry(await _context.Arrivees.FirstAsync(x => x.Id == id)).CurrentValues.SetValues(value);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int[] ids)
        {
            await _context.ExecuteDeleteAsync(_context.Arrivees.Where(x => ids.Contains(x.Id)));
        }
    }
}
