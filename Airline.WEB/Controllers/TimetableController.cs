using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Airline.BLL.Interfaces;
using Airline.BLL.Services;
using Airline.WEB.Models;
using Airline.WEB.Util;

namespace Airline.WEB.Controllers
{
    public class TimetableController : Controller
    {
        private ITimetableService _service;
        private ICrewService _crewService;
        private IFlightService _flightService;
        private IFlightParkService _flightParkService;

        public TimetableController(ITimetableService service,
            ICrewService crewService,
            IFlightService flightService,
            IFlightParkService flightParkService)
        {
            _service = service;
            _crewService = crewService;
            _flightService = flightService;
            _flightParkService = flightParkService;
        }

        // GET: Timetable
        public ActionResult List(SearchViewModel searchModel)
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            var model = new TimetableCreateModel();
            model.DateTime = DateTime.UtcNow;
            model.CrewSelectListItems = UtilMethods.CreateListOfSelectItems(_crewService.GetCrews(), c => c.Id.ToString(), c => c.WorkersDescription);
            model.FlightSelectListItems = UtilMethods.CreateListOfSelectItems(_flightService.GetFlights(), f => f.Id,
                f => $"From {f.FromName}({f.FromIATA}) to {f.ToName}({f.ToIATA}) at {f.PlannedDepartureTime}");
            model.FlightParkSelectListItems = UtilMethods.CreateListOfSelectItems(_flightParkService.GetFlightParks(), f => f.Id.ToString(),
                f => $"Plane {f.Id}. {f.Name}");

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(TimetableCreateModel model)
        {

            return View(model);
        }

    }
}