using System.ComponentModel.DataAnnotations;

namespace GestionVoyage.API.Models
{
    public class Arrivee
    {
        [Key]
        public int Id { get; set; }
        public string? NomNavire { get; set; }
        public DateTime DateHeureArrivee { get; set; }

        // Pourrait être un FK de Port
        public string? PortOrigine { get; set; }
        public int Terminal { get; set; }

        // Pourrait être un Enum lié à la base de données
        public string? TypeCargaison { get; set; }
    }
}
