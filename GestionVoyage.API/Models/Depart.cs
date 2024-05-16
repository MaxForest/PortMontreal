using System.ComponentModel.DataAnnotations;

namespace GestionVoyage.API.Models
{
    public class Depart
    {
        [Key]
        public int Id { get; set; }
        public string? NomNavire { get; set; }
        public DateTime DateHeureDepart { get; set; }
        public string? PortDestination { get; set; }
        public int Quai { get; set; }
        public string? TypeCargaison { get; set; }
    }
}
