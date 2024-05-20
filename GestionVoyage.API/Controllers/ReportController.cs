using GestionVoyage.API.Context;
using GestionVoyage.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace GestionVoyage.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RapportController(GestionVoyageDbContext context) : ControllerBase
    {
        private readonly GestionVoyageDbContext _context = context;

        // GET: api/<RapportController>/Mensuels
        [Route("Mensuels")]
        [HttpGet]
        public async Task<IEnumerable<Trajet>> RapportsMensuels(int mois, int annee)
        {
            return await _context.Database.SqlQueryRaw<Trajet>(
                "GenererRapportMensuel @mois, @annee",
                new  SqlParameter("mois", mois),
                new SqlParameter("annee", annee)
            ).ToListAsync();
        }
    }
}
