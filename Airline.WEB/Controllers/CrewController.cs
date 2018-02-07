using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Airline.BLL.Interfaces;
using Airline.WEB.Models;

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
            _workerService.ge
            var model = new WorkerViewModel();
            return View();
        }
    }
}