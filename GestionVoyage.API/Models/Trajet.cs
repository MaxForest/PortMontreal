using System.ComponentModel.DataAnnotations;

namespace GestionVoyage.API.Models
{
  public abstract class Trajet
  {
    [Key]
    public int Id { get; set; }

    public string? NomNavire { get; set; }
  }
}
