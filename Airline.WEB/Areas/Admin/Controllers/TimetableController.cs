using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Airline.BLL.DTO;
using Airline.BLL.Interfaces;
using Airline.BLL.Services;
using Airline.Common.Enums;
using Airline.WEB.Filters;
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

        [MessageFromTempData]
        public ActionResult List(SearchViewModel searchModel)
        {
            IEnumerable<TimetableDto> timetableDtos = null;

            if (searchModel.SearchKeyword != null)
                timetableDtos = _service.GetSearchedTimetables(searchModel.SelectionKeyword);
            else if (searchModel.SelectionKeyword != null)
                timetableDtos = _service.GetSelectedTimetables(searchModel.Selection, searchModel.SelectionKeyword);
            else if (searchModel.SortField != SortOptions.NoSelect)
                timetableDtos = _service.GetSortedTimetables(searchModel.SortField);
            else timetableDtos = _service.GetTimetables();

            var timetables = Mapper.Map<IEnumerable<TimetableDto>, IEnumerable<TimetableModel>>(timetableDtos);

            var timetableViewModel = new TimetableViewModel { TimetableList = timetables };
            return View(timetableViewModel);
        }

        [HttpGet]
        public ActionResult Approve(int? id)
        {
            try
            {
                var timetableDto = _service.GetTimetable(id);
                var model = Mapper.Map<TimetableDto, TimetableModel>(timetableDto);
                
                return View(model);
            }
            catch (Exception e)
            {
                TempData["Message"] = e.Message;
                return RedirectToAction("List");
            }
        }

        [HttpPost]
        [ActionName("Approve")]
        [ValidateAntiForgeryToken]
        public ActionResult ApproveConfirmed(int? id)
        {
            try
            {
                _service.ApproveTimetable(id);
                TempData["Message"] = $"Timetable {id} was approved";
            }
            catch (ArgumentException e)
            {
                TempData["Message"] = e.Message;
            }

            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            try
            {
                var timetableDto = _service.GetTimetable(id);
                var model = Mapper.Map<TimetableDto, TimetableModel>(timetableDto);

                return View(model);
            }
            catch (Exception e)
            {
                TempData["Message"] = e.Message;
                return RedirectToAction("List");
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                _service.DeleteTimetable(id);
                TempData["Message"] = $"Timetable {id} was deleted";
            }
            catch (ArgumentException e)
            {
                TempData["Message"] = e.Message;
            }

            return RedirectToAction("List");
        }


        [HttpGet]
        public ActionResult Edit(int? id)
        {
            try
            {
                var timetableDto = _service.GetTimetable(id);
                var model = Mapper.Map<TimetableDto, TimetableCreateModel>(timetableDto);

                FillTimetableCreateModel(model);

                return View(model);
            }
            catch (Exception e)
            {
                TempData["Message"] = e.Message;
                return RedirectToAction("List");
            }
        }

        [HttpPost]
        public ActionResult Edit(TimetableCreateModel model)
        {
            if (model.CrewId != null)
            {
                var crewCompositionOfCrew = _crewService.GetCrew(model.CrewId).CrewCompositionId;
                var crewCompositionOfFlightPark = _flightParkService.GetFlightPark(model.FlightParkId).CrewCompositionId;

                if (crewCompositionOfCrew == crewCompositionOfFlightPark)
                    ModelState.AddModelError("FlightParkId",
                        "Selected flight park and selected crew has different compostion");
            }

            if (model.DateTime < DateTime.UtcNow.AddHours(3))
                ModelState.AddModelError("DateTime", "It's too late timetable schedule for this time");

            if (ModelState.IsValid)
            {
                var timetableDto = Mapper.Map<TimetableCreateModel, TimetableDto>(model);
                _service.EditTimetable(timetableDto);
                TempData["Message"] = $"Timetable {model.Id} was edited";
                return RedirectToAction("List");
            }

            FillTimetableCreateModel(model);
            return View(model);
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

                if (crewCompositionOfCrew != crewCompositionOfFlightPark)
                    ModelState.AddModelError("FlightParkId",
                        "Selected flight park and selected crew has different compostion");
            }

            DateTime lastDateForCrew, lastDateForFlightPark;
            string lastAirportForCrew, lastAirportForFlightPark;

            lastDateForCrew = _crewService.GetLastFlightDateForCrew(model.CrewId);
            lastDateForFlightPark = _flightParkService.GetLastFlightDateForFlightPark(model.FlightParkId);
            lastAirportForCrew = _crewService.GetLastFlightAirportForCrew(model.CrewId);
            lastAirportForFlightPark = _flightParkService.GetLastAiportForFlightPark(model.FlightParkId);

            if (lastAirportForFlightPark != lastAirportForCrew || lastAirportForFlightPark != _flightService.GetFlight(model.FlightId).FromIATA)
                ModelState.AddModelError("FlightId", "Please, check airport data in crew or flight park. They must be equal");

            if (model.DateTime < lastDateForCrew || model.DateTime < lastDateForFlightPark)
                ModelState.AddModelError("DateTime", "Chosen data too early. Check suiatable in crew or flight park fields");

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

        // method for filling inputs data
        private void FillTimetableCreateModel(TimetableCreateModel model)
        {
            model.DateTime = DateTime.UtcNow.AddHours(4);

            var crews = _crewService.GetCrews();
            if (crews.Count() != 0)
                model.CrewSelectListItems = UtilMethods.CreateListOfSelectItems(crews, c => c.Id.ToString(), c => c.WorkersDescription);

            var flights = _flightService.GetFlights();
            model.FlightSelectListItems = UtilMethods.CreateListOfSelectItems(flights, f => f.Id,
                f => $"From {f.FromName}({f.FromIATA}) to {f.ToName}({f.ToIATA}) at {f.PlannedDepartureTime}");

            model.FlightParkSelectListItems = UtilMethods.CreateListOfSelectItems(_flightParkService.GetFlightParks(), f => f.Id.ToString(),
                f => f.Summary);
        }
    }
}