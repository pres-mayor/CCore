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
        private readonly IConfiguration _configuration;

        public FIDSController(ILogger<FIDSController> logger, IFlightInfoRepository flightInfoRepository, IConfiguration configuration)
        {
            _logger = logger;
            _flightInfoRepository = flightInfoRepository;
            _configuration = configuration;
        }

        [HttpGet]
        [Route("GetFlights")]
        public IEnumerable<FlightInformation> Get()
        {
            var flights = _flightInfoRepository.GetFlights();
            IEnumerable<FlightInformation> result = flights.Select(x => new FlightInformation
            {
                Type = x.arrdep == "DEP" ? "Departure" : "Arrival",
                ScheduledTime = x.sched_time,
                ActualTime = x.actual_time,
                AirlineCode = x.airlinecode,
                FlightNumber = x.flightnumber,
                City = x.city_name,
                Gate = x.gatecode,
                DefaultDelta = int.Parse(_configuration["DefaultDelta"])
        });
            
            return result;
        }

        [HttpGet]
        [Route("GetFlightByFlightNumber")]
        public IEnumerable<FlightInformation> GetFlightByFlightNumber(int flightNumber)
        {
            var flights = _flightInfoRepository.GetFlightByFlightNumber(flightNumber);
            IEnumerable<FlightInformation> result = flights.Select(x => new FlightInformation
            {
                Type = x.arrdep == "DEP" ? "Departure" : "Arrival",
                ScheduledTime = x.sched_time,
                ActualTime = x.actual_time,
                AirlineCode = x.airlinecode,
                FlightNumber = x.flightnumber,
                City = x.city_name,
                Gate = x.gatecode,
                DefaultDelta = int.Parse(_configuration["DefaultDelta"])
            });
            
            return result;
        }

        [HttpGet]
        [Route("GetDelayedFlightsByDeltaMinutes")]
        public IEnumerable<FlightInformation> GetDelayedFlightsByDeltaMinutes(int delta)
        {
            var flights = _flightInfoRepository.GetDelayedFlightsByDelta(delta);
            IEnumerable<FlightInformation> result = flights.Select(x => new FlightInformation
            {
                Type = x.arrdep == "DEP" ? "Departure" : "Arrival",
                ScheduledTime = x.sched_time,
                ActualTime = x.actual_time,
                AirlineCode = x.airlinecode,
                FlightNumber = x.flightnumber,
                City = x.city_name,
                Gate = x.gatecode,
                DefaultDelta = delta
            });

            return result;
        }

    }
}
