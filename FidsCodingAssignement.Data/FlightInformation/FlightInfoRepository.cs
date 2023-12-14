using FidsCodingAssignment.DTO.FlightInformation;
using Newtonsoft.Json;

namespace FidsCodingAssignment.Data.FlightInformation
{
    public class FlightInfoRepository : IFlightInfoRepository
    {
        readonly string jsonContent = System.IO.File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory() + "\\Data", @"rawData.json"));

        public IEnumerable<FligtInformationDTO>? GetFlights()
        {
            IEnumerable<FligtInformationDTO>? flightList = JsonConvert.DeserializeObject<IEnumerable<FligtInformationDTO>>(jsonContent);
            return flightList;
        }

        public IEnumerable<FligtInformationDTO>? GetFlightByFlightNumber(int flightNumber)
        {
            IEnumerable<FligtInformationDTO>? flightList = JsonConvert.DeserializeObject<IEnumerable<FligtInformationDTO>>(jsonContent);
            return flightList?.Where(x => x.flightnumber == flightNumber);
        }

    }
}
