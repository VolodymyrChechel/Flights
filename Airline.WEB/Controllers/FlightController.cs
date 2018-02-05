using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Airline.BLL.DTO;
using Airline.BLL.Interfaces;
using Airline.WEB.Filters;
using Airline.WEB.Models;
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
            var selectListItems = new List<SelectListItem>();

            foreach (var airport in airports)
            {
                selectListItems.Add(new SelectListItem{Text = airport.Name, Value = airport.IATA});
            }

            ViewBag.AirportSelectList = selectListItems;

            var model = new FlightViewModel
            {
                PlannedDepartureTime = DateTime.UtcNow
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(FlightViewModel model)
        {

            return View(model);
        }
    }
}