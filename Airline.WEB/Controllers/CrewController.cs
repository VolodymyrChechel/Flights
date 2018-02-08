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

            var hostess = _workerService.GetWorkersByCrewmanType(CrewmanType.AirHostess);
            var captains = _workerService.GetWorkersByCrewmanType(CrewmanType.Captain);
            model.AirHostessSelectList =
                UtilMethods.CreateListOfSelectItems(hostess, w => w.Id.ToString(), w => $"{w.Id}. {w.Name} {w.Surname}");
            model.CaptainSelectList =
                UtilMethods.CreateListOfSelectItems(captains, w => w.Id.ToString(), w => $"{w.Id}. {w.Name} {w.Surname}");

            return View(model);
        }
    }
}