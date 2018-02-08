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
        public ActionResult List(SearchViewModel searchModel)
        {
            
            var flightDtos = _service.GetFlights();
            var flights = Mapper.Map<IEnumerable<FlightDto>, IEnumerable<FlightViewModel>>(flightDtos);
            
            var listFlightsViewModel = new ListFlightViewModel {FlightsList = flights};
            if (searchModel != null)
                listFlightsViewModel.SearchModel = searchModel;

                return View(listFlightsViewModel);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var airports = _airportService.GetAirports();

            ViewBag.AirportSelectList = UtilMethods.CreateListOfSelectItems(airports, airport => airport.IATA, airport => airport.Name);

            return View(new FlightViewModel {PlannedDepartureTime = TimeSpan.MinValue});
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

        [HttpGet]
        public ActionResult Edit(string id)
        {
            try
            {
                var flightDto = _service.GetFlight(id);
                var flight = Mapper.Map<FlightDto, FlightViewModel>(flightDto);
                var airports = _airportService.GetAirports();
                ViewBag.AirportSelectList = UtilMethods.CreateListOfSelectItems(airports, airport => airport.IATA, airport => airport.Name);
                return View(flight);
            }
            catch (ArgumentException e)
            {
                TempData["Message"] = e.Message;
                return RedirectToAction("List");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FlightViewModel flight)
        {
            if (ModelState.IsValid)
            {
                var flightDto = Mapper.Map<FlightViewModel, FlightDto>(flight);

                _service.EditFlight(flightDto);

                TempData["Message"] = $"Flight {flight.FromIATA} to {flight.ToIATA} at {flight.PlannedDepartureTime} was edited succesfully";

                return RedirectToAction("List");
            }
            var airports = _airportService.GetAirports();
            ViewBag.AirportSelectList = UtilMethods.CreateListOfSelectItems(airports, airport => airport.IATA, airport => airport.Name);
            return View(flight);
        }


        [HttpGet]
        public ActionResult Delete(string id)
        {
            try
            {
                var flightDto = _service.GetFlight(id);
                var worker = Mapper.Map<FlightDto, FlightViewModel>(flightDto);

                return View(worker);
            }
            catch (ArgumentException e)
            {
                TempData["Message"] = e.Message;
                return RedirectToAction("List");
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            try
            {
                _service.DeleteFlight(id);
                TempData["Message"] = $"Flight {id} was deleted";
            }
            catch (ArgumentException e)
            {
                TempData["Message"] = e.Message;
            }

            return RedirectToAction("List");
        }
    }
}