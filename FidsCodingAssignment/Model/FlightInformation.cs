namespace FidsCodingAssignment.DTO
{
    public class FlightInformation
    {
        public int FlightNumber { get; set; }
        public string? Type { get; set; }
        public string? City { get; set; }
        public DateTime? ScheduledTime { get; set; }
        public DateTime? ActualTime { get; set; }
        public string? AirlineCode { get; set; }
        public string? AddressFlightCodeshares
        {
            get
            {
                return string.Format("{0}-{1}", AirlineCode, FlightNumber);
            }
        }
        public string? Gate { get; set; }
        public bool BoardingTime
        {
            get
            {
                bool isBoardingTime = false;
                if(Type == "Departure")
                {
                    isBoardingTime = ActualTime >= DateTime.Now.AddMinutes(-DefaultDelta);
                }
                return isBoardingTime;
            }
        }

        public string Status 
        { 
            get
            {
                return BoardingTime ? "Boarding" : "Closed";
            }
        }
        public int DefaultDelta { get; set; }
        public bool AtGate 
        {
            get
            {
                return ActualTime >= DateTime.Now.AddMinutes(-DefaultDelta) && ActualTime < DateTime.Now.AddMinutes(DefaultDelta);
            }    
        }
    }
}
