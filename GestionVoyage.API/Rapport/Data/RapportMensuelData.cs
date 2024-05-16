using System.ComponentModel.DataAnnotations.Schema;

namespace GestionVoyage.API.Rapport.Data
{
    [NotMapped]
    public class RapportMensuelData
    {
        public string? Voyage { get; set; }
        public string? NomNavire { get; set; }
        public DateTime DateHeureVoyage { get; set; }
        public string? Port { get; set; }
        public string? TypeCargaison { get; set; }
    }
}
