using GestionVoyage.API.Context;
using GestionVoyage.API.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionVoyage.API.Repositories
{
    public class TrajetRepository(GestionVoyageDbContext context)
    {
        private readonly GestionVoyageDbContext _context = context;

        public async Task Add(Trajet value)
        {
            await _context.AddRangeAsync(value);
        }

        public async Task<IEnumerable<Trajet>> Get()
        {
            return await _context.Trajets.ToListAsync();
        }

        public async Task<Trajet> Get(int id)
        {
            return await _context.Trajets.FirstAsync(x => x.Id == id);
        }

        public async Task Update(int id, Trajet value)
        {
            try
            {
                await _context.Trajets.Where(x => x.Id == id).ExecuteUpdateAsync(setters => setters.SetProperty(b => b.NomNavire, value.NomNavire)
                                                                                                   .SetProperty(b => b.Depart.Date, value.Depart.Date)
                                                                                                   .SetProperty(b => b.Depart.PortDestination, value.Depart.PortDestination)
                                                                                                   .SetProperty(b => b.Depart.Quai, value.Depart.Quai)
                                                                                                   .SetProperty(b => value.Arrivee, value.Arrivee)
                                                                                                   //.SetProperty(b => b.Arrivee.Date, value.Arrivee.Date)
                                                                                                   //.SetProperty(b => b.Arrivee.PortOrigine, value.Arrivee.PortOrigine)
                                                                                                   //.SetProperty(b => b.Arrivee.Terminal, value.Arrivee.Terminal)
                                                                                                   .SetProperty(b => b.TypeCargaison, value.TypeCargaison)); 
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task Delete(int[] ids)
        {
            await _context.ExecuteDeleteAsync(_context.Trajets.Where(x => ids.Contains(x.Id)));
        }
    }
}
