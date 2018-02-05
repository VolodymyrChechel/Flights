using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Airline.BLL.DTO;
using Airline.BLL.Interfaces;
using Airline.WEB.Filters;
using Airline.WEB.Models;
using Airline.WEB.Util;
using AutoMapper;

namespace Airline.WEB.Controllers
{
    public class FlightController : Controller
    {
        private readonly IFlightService _service;
        private readonly IAirportService _airportService;
        // GET: Flight
        public FlightController(IFlightService service, IAirportService airportService)
        {
            _service = service;
            _airportService = airportService;
        }

        [MessageFromTempData]
        public ActionResult List()
        {
            var flightDtos = _service.GetFlights();
            var flights = Mapper.Map<IEnumerable<FlightDto>, IEnumerable<FlightViewModel>>(flightDtos);

            return View(flights);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var airports = _airportService.GetAirports();

            ViewBag.AirportSelectList = UtilMethods.CreateListOfSelectItems(airports, airport => airport.IATA, airport => airport.Name);

            return View(new FlightViewModel {PlannedDepartureTime = DateTime.UtcNow});
        }

        [HttpPost]
        public ActionResult Create(FlightViewModel flight)
        {
            if (ModelState.IsValid)
                {
                    var flightDto = Mapper.Map<FlightViewModel, FlightDto>(flight);

                    _service.CreateFlight(flightDto);

                    TempData["Message"] = $"New flight from {flight.FromIATA} to {flight.ToIATA} at {flight.PlannedDepartureTime} was created succesfully";
                    return RedirectToAction("List");
                }

            var airports = _airportService.GetAirports();

            ViewBag.AirportSelectList = UtilMethods.CreateListOfSelectItems(airports, airport => airport.IATA, airport => airport.Name);
            return View(flight);
        }
    }
}