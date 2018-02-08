using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Airline.BLL.Interfaces;
using Airline.Common.Enums;
using Airline.WEB.Models;
using Airline.WEB.Util;

namespace Airline.WEB.Controllers
{
    public class CrewController : Controller
    {
        private ICrewService _service;
        private IWorkerService _workerService;

        public CrewController(ICrewService service, IWorkerService workerService)
        {
            _service = service;
            _workerService = workerService;
        }
        
        public ActionResult List()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            var model = new CrewViewModel();

            var compositions = _service.GetCrewCompositions();
            var hostess = _workerService.GetWorkersByCrewmanType(CrewmanType.AirHostess);
            var captains = _workerService.GetWorkersByCrewmanType(CrewmanType.Captain);
            var radioOperators = _workerService.GetWorkersByCrewmanType(CrewmanType.RadioOperator);
            var navigators = _workerService.GetWorkersByCrewmanType(CrewmanType.NavigatorOfficer);
            var pilots = _workerService.GetWorkersByCrewmanType(CrewmanType.AircraftPilot);

            model.CompositionSelectList =
                UtilMethods.CreateListOfSelectItems(compositions, c => c.Id.ToString(),
                c => $"Captain: {c.CaptainAmount}, Pilot: {c.AircraftPilotAmount}, NavigatorOfficer: {c.NavigatorOfficerAmount}, RadioOperator: {c.RadioOperatorAmount}, AirHostess: {c.AirHostessAmount}");
            model.AirHostessSelectList =
                UtilMethods.CreateListOfSelectItems(hostess, w => w.Id.ToString(), w => $"{w.Id}. {w.Name} {w.Surname}");
            model.CaptainSelectList =
                UtilMethods.CreateListOfSelectItems(captains, w => w.Id.ToString(), w => $"{w.Id}. {w.Name} {w.Surname}");
            model.RadioOperatorSelectList =
                UtilMethods.CreateListOfSelectItems(radioOperators, w => w.Id.ToString(), w => $"{w.Id}. {w.Name} {w.Surname}");
            model.NavigatorOfficerSelectList =
                UtilMethods.CreateListOfSelectItems(navigators, w => w.Id.ToString(), w => $"{w.Id}. {w.Name} {w.Surname}");
            model.AircraftPilotSelectList =
                UtilMethods.CreateListOfSelectItems(pilots, w => w.Id.ToString(), w => $"{w.Id}. {w.Name} {w.Surname}");

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(CrewViewModel model)
        {
            return View(model);
        }
    }
}