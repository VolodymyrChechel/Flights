using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Airline.WEB.Models;

namespace Airline.WEB.Controllers
{
    public class TimetableController : Controller
    {
        // GET: Timetable
        public ActionResult List(SearchViewModel searchModel)
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Create(string id)
        {
            @ViewBag.Args = id;

            return View();
        }


    }
}