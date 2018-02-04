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
        // GET: Flight
        public FlightController(IFlightService service)
        {
            _service = service;
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
            var selectListItems = new List<SelectListItem>();
            selectListItems.Add();
            return View();
        }

    }
}