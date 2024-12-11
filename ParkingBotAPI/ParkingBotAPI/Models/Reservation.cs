namespace ParkingBotAPI.Models
{
    public class Reservation
    {
        public Guid ReservationId { get; set; }
        public int CustomerId { get; set; }
        public int ParkingId { get; set; }
        public string LicensePlate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public Customer Customer { get; set; }
        public ParkingGarage Garage { get; set; }
    }
}
