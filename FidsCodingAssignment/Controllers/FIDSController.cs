using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using FidsCodingAssignment.DTO;
using FidsCodingAssignment.Data.FlightInformation;
using Microsoft.AspNetCore.Http;
using System.Globalization;

namespace FidsCodingAssignment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FIDSController : ControllerBase
    {
        private readonly ILogger<FIDSController> _logger;
        private readonly IFlightInfoRepository _flightInfoRepository;
       
        public FIDSController(ILogger<FIDSController> logger, IFlightInfoRepository flightInfoRepository)
        {
            _logger = logger;
            _flightInfoRepository = flightInfoRepository;
        }

        [HttpGet]
        [Route("GetFlights")]
        public IEnumerable<FlightInformation> Get()
        {
            var flights = _flightInfoRepository.GetFlights();
            var t = flights.Select(x => new FlightInformation
            {
                City = x.city_name
            });

            return t;
        }

        [HttpGet]
        [Route("GetFlightByFlightNumber")]
        public IEnumerable<FlightInformation> GetFlightByFlightNumber(int flightNumber)
        {
            var flights = _flightInfoRepository.GetFlightByFlightNumber(flightNumber);
            var t = flights.Select(x => new FlightInformation
            {
                Type = x.arrdep == "DEP" ? "Departure" : "Arrival",
                ScheduledTime = x.sched_time,
                ActualTime = x.actual_time,
                AirlineCode = x.airlinecode,
                FlightNumber = x.flightnumber,
                City = x.city_name,
                x.de
                
            });

            return t;
        }

    }
}
