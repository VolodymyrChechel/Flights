using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Airline.BLL.Interfaces;
using Airline.BLL.Services;
using Airline.WEB.Models;

namespace Airline.WEB.Controllers
{
    public class TimetableController : Controller
    {
        private ITimetableService _service;

        public TimetableController(ITimetableService service)
        {
            _service = service;
        }

        // GET: Timetable
        public ActionResult List(SearchViewModel searchModel)
        {
            return View();
        }

        public ActionResult Create()
        {
            var model = new TimetableModel();

            return View();
        }

        public ActionResult Create(string id)
        {
            @ViewBag.Args = id;

            return View();
        }


    }
}