namespace ParkingBotAPI.Models
{
    public class ParkingGarage
    {
        public int ParkingId { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public int MaxPlaces { get; set; }

        public ICollection<Reservation> Reservations { get; set; }
    }
}
