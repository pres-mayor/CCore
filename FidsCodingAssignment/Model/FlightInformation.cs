namespace FidsCodingAssignment.DTO
{
    public class FlightInformation
    {
        public int FlightNumber { get; set; }
        public string Type { get; set; }
        public string City { get; set; }
        public DateTime? ScheduledTime { get; set; }
        public DateTime? ActualTime { get; set; }
        public string AirlineCode { get; set; }
        public string AddressFlightCodeshares { get; set; }

    }
}
