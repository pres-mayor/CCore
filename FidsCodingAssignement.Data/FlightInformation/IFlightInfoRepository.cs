using FidsCodingAssignment.DTO.FlightInformation;

namespace FidsCodingAssignment.Data.FlightInformation
{
    public interface IFlightInfoRepository
    {
        IEnumerable<FligtInformationDTO>? GetFlights();
        IEnumerable<FligtInformationDTO>? GetFlightByFlightNumber(int flightNumber);
    }
}