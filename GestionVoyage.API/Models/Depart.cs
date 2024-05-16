using System.ComponentModel.DataAnnotations;

namespace GestionVoyage.API.Models
{
    public class Depart : Trajet
    {
        public DateTime DateHeureDepart { get; set; }

        // Pourrait être un FK de Port
        public string? PortDestination { get; set; }

        public int Quai { get; set; }

        // Pourrait être un Enum lié à la base de données
        public string? TypeCargaison { get; set; }
    }
}
