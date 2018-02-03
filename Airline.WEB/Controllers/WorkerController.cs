using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Airline.BLL.DTO;
using Airline.BLL.Infrastructure;
using Airline.BLL.Interfaces;
using Airline.WEB.Filters;
using Airline.WEB.Models;
using AutoMapper;

namespace Airline.WEB.Controllers
{
    public class WorkerController : Controller
    {
        private IWorkerService _service;

        public WorkerController(IWorkerService service)
        {
            _service = service;
        }

        [MessageFromTempData]
        public ActionResult List()
        {
            var workerDtos = _service.GetWorkers();
            var workers = Mapper.Map<IEnumerable<WorkerDto>, IEnumerable<WorkerViewModel>>(workerDtos);
            
            return View(workers);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var model = new WorkerViewModel() {BirthDate = DateTime.Parse("1/1/1980")};
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(WorkerViewModel worker)
        {
            if (ModelState.IsValid)
            {
                var workerDto = Mapper.Map<WorkerViewModel, WorkerDto>(worker);

                _service.CreateWorker(workerDto);

                TempData["Message"] = $"New worker {workerDto.Name} {workerDto.Surname} was created succesfully";

                return RedirectToAction("List");
            }
            return View(worker);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            try
            {
                var workerDro = _service.GetWorker(id);
                var worker = Mapper.Map<WorkerDto, WorkerViewModel>(workerDro);

                return View(worker);
            }
            catch (ArgumentException e)
            {
                TempData["Message"] = e.Message;
                return RedirectToAction("List");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(WorkerViewModel worker)
        {
            if (ModelState.IsValid)
            {
                var workerDto = Mapper.Map<WorkerViewModel, WorkerDto>(worker);

                _service.EditWorker(workerDto);

                TempData["Message"] = $"Worker {workerDto.Name} {workerDto.Surname} was edited succesfully";

                return RedirectToAction("List");
            }
            return View(worker);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            try
            {
                var workerDro = _service.GetWorker(id);
                var worker = Mapper.Map<WorkerDto, WorkerViewModel>(workerDro);

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
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                _service.DeleteWorker(id);
                TempData["Message"] = $"Worker {id} was deleted";
            }
            catch (ArgumentException e)
            {
                TempData["Message"] = e.Message;
            }

            return RedirectToAction("List");
        }
    }
}