using System.ComponentModel.DataAnnotations;

namespace GestionVoyage.API.Models
{
    public class Port
    {
        [Key]
        public int Id { get; set; }

        public string? Nom { get; set; }
    }
}
