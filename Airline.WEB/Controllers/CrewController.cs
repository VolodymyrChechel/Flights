using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Airline.BLL.DTO;
using Airline.BLL.Interfaces;
using Airline.Common.Enums;
using Airline.WEB.Filters;
using Airline.WEB.Models;
using Airline.WEB.Util;
using AutoMapper;

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
        
        [MessageFromTempData]
        public ActionResult List()
        {
            var crewDtos = _service.GetCrews();
            var crews = Mapper.Map<IEnumerable<CrewDto>, IEnumerable<CrewViewModel>>(crewDtos);

            return View(crews);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var model = new CrewViewModel();
            FillCrewModel(model);

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(CrewViewModel model)
        {
            var compostion = _service.GetCrewComposition(model.CrewCompositionId);

            if (model.SelectedAircraftPilots.Count() == compostion.AircraftPilotAmount &&
                model.SelectedCaptains.Count() == compostion.CaptainAmount &&
                model.SelectedHostess.Count() == compostion.AirHostessAmount &&
                model.SelectedRadioOperators.Count() == compostion.RadioOperatorAmount &&
                model.SelectedNavigatorOfficers.Count() == compostion.NavigatorOfficerAmount)
            {
                try
                {
                    var crewDto = Mapper.Map<CrewViewModel, CrewDto>(model);
                    _service.CreateCrew(crewDto);

                    TempData["Message"] = $"New crew was created succesfully";
                }
                catch (Exception e)
                {
                    TempData["Message"] = e.Message;
                }
            }

            return RedirectToAction("List");
        }

        public JsonResult GetComposition(int id)
        {
            var compostion = _service.GetCrewComposition(id);
            return Json(compostion, JsonRequestBehavior.AllowGet);
        }

        private void FillCrewModel(CrewViewModel model)
        {
            var compositions = _service.GetCrewCompositions();
            var hostess = _workerService.GetWorkersByCrewmanType(CrewmanType.AirHostess, true);
            var captains = _workerService.GetWorkersByCrewmanType(CrewmanType.Captain, true);
            var radioOperators = _workerService.GetWorkersByCrewmanType(CrewmanType.RadioOperator, true);
            var navigators = _workerService.GetWorkersByCrewmanType(CrewmanType.NavigatorOfficer, true);
            var pilots = _workerService.GetWorkersByCrewmanType(CrewmanType.AircraftPilot, true);

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
        }
    }
}