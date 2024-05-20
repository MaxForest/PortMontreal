using GestionVoyage.API.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace GestionVoyage.API.Models
{
    public class Trajet
    {
        [Key]
        public int Id { get; set; }

        public string? NomNavire { get; set; }

        public required Depart Depart { get; set; }

        public Arrivee? Arrivee { get; set; }

        public TypeCargaison TypeCargaison { get; set; }
    }
}