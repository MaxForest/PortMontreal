namespace GestionVoyage.API.Models
{
    public class Depart
    {
        public DateTime Date { get; set; }

        public required virtual Port PortDestination { get; set; }

        public int Quai { get; set; }
    }
}
