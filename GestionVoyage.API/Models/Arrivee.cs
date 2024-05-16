using System.ComponentModel.DataAnnotations;

namespace GestionVoyage.API.Models
{
    public class Arrivee : Trajet
    {
        public DateTime DateHeureArrivee { get; set; }

        // Pourrait �tre un FK de Port
        public string? PortOrigine { get; set; }
        public int Terminal { get; set; }

        // Pourrait �tre un Enum li� � la base de donn�es
        public string? TypeCargaison { get; set; }
    }
}
