using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Airline.BLL.DTO;
using Airline.BLL.Interfaces;
using Airline.BLL.Services;
using Airline.Common.Enums;
using Airline.WEB.Models;
using Airline.WEB.Util;
using AutoMapper;

namespace Airline.WEB.Areas.Admin.Controllers
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
            //   if (searchModel == null)

            var timetableDtos = _service.GetTimetables();
            var timetables = Mapper.Map<IEnumerable<TimetableDto>, IEnumerable<TimetableModel>>(timetableDtos);

            var timetableViewModel = new TimetableViewModel { TimetableList = timetables };
            return View(timetableViewModel);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var model = new TimetableCreateModel();
            FillTimetableCreateModel(model);

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(TimetableCreateModel model)
        {
            // it is possible when timetable has no crew
            // when it happens admin must resolve it (create new worker/crew or delete timetable)
            if (model.CrewId != null)
            {
                var crewCompositionOfCrew = _crewService.GetCrew(model.CrewId).CrewCompositionId;
                var crewCompositionOfFlightPark = _flightParkService.GetFlightPark(model.FlightParkId).CrewCompositionId;

                if (crewCompositionOfCrew == crewCompositionOfFlightPark)
                    ModelState.AddModelError("FlightParkId",
                        "Selected flight park and selected crew has different compostion");
            }

            if (model.DateTime < DateTime.UtcNow.AddHours(3))
                ModelState.AddModelError("DateTime", "It's too late create timetable for this time");

            if (ModelState.IsValid)
            {
                var timetableDto = Mapper.Map<TimetableCreateModel, TimetableDto>(model);
                _service.CreateTimetable(timetableDto);
                TempData["Message"] = $"New timetable was created ";
                return RedirectToAction("List");
            }

            FillTimetableCreateModel(model);
            return View(model);
        }


        private void FillTimetableCreateModel(TimetableCreateModel model)
        {
            model.DateTime = DateTime.UtcNow.AddHours(3);

            var crews = _crewService.GetCrews();
            // when there are no crews this timetable will be with attention status
            if (crews.Count() != 0)
                model.CrewSelectListItems = UtilMethods.CreateListOfSelectItems(crews, c => c.Id.ToString(), c => c.WorkersDescription);

            var flights = _flightService.GetFlights();
            model.FlightSelectListItems = UtilMethods.CreateListOfSelectItems(flights, f => f.Id,
                f => $"From {f.FromName}({f.FromIATA}) to {f.ToName}({f.ToIATA}) at {f.PlannedDepartureTime}");
            model.FlightParkSelectListItems = UtilMethods.CreateListOfSelectItems(_flightParkService.GetFlightParks(), f => f.Id.ToString(),
                f => $"Plane {f.Id}. {f.Name}");
        }
    }
}