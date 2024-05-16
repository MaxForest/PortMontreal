using System.ComponentModel.DataAnnotations;

namespace GestionVoyage.API.Models
{
    public class Depart
    {
        [Key]
        public int Id { get; set; }
        public string? NomNavire { get; set; }
        public DateTime DateHeureDepart { get; set; }

        // Pourrait être un FK de Port
        public string? PortDestination { get; set; }

        public int Quai { get; set; }

        // Pourrait être un Enum lié à la base de données
        public string? TypeCargaison { get; set; }
    }
}
