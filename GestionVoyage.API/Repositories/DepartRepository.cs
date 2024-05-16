using GestionVoyage.API.Context;
using GestionVoyage.API.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionVoyage.API.Repositories
{
    public class DepartRepository(GestionVoyageDbContext context)
    {
        private readonly GestionVoyageDbContext _context = context;

        public async Task Add(Depart value)
        {
            await _context.AddRangeAsync(value);
        }

        public async Task<IEnumerable<Depart>> Get()
        {
            return await _context.Departs.ToListAsync();
        }

        public async Task<Depart> Get(int id)
        {
            return await _context.Departs.FirstAsync(x => x.Id == id);
        }

        public async Task Update(int id, Depart value)
        {
            await _context.Departs.Where(x => x.Id == id).ExecuteUpdateAsync(setters => setters.SetProperty(b => b.NomNavire, value.NomNavire)
                                                                                               .SetProperty(b => b.DateHeureDepart, value.DateHeureDepart)
                                                                                               .SetProperty(b => b.PortDestination, value.PortDestination)
                                                                                               .SetProperty(b => b.Quai, value.Quai)
                                                                                               .SetProperty(b => b.TypeCargaison, value.TypeCargaison));
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int[] ids)
        {
            await _context.ExecuteDeleteAsync(_context.Departs.Where(x => ids.Contains(x.Id)));
        }
    }
}
