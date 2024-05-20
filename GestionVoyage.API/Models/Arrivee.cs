namespace GestionVoyage.API.Models
{
    public class Arrivee
    {
        public DateTime? Date { get; set; }

        public required virtual Port? PortOrigine { get; set; }

        public int? Terminal { get; set; }
    }
}
