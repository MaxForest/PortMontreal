using System.ComponentModel.DataAnnotations;

namespace GestionVoyage.API.Models
{
    public class Arrivee
    {
        [Key]
        public int Id { get; set; }
        public string? NomNavire { get; set; }
        public DateTime DateHeureArrivee { get; set; }
        public string? PortOrigine { get; set; }
        public int Terminal { get; set; }
        public string? TypeCargaison { get; set; }
    }
}
