using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Airline.BLL.DTO;
using Airline.BLL.Infrastructure;
using Airline.BLL.Interfaces;
using Airline.BLL.Util;
using Airline.Common.Enums;
using Airline.DAL.Entities;
using Airline.DAL.Interfaces;
using AutoMapper;
using Castle.Core.Internal;

namespace Airline.BLL.Services
{
    public class WorkerService : IWorkerService
    {
        private IUnitOfWork Database { get; set; }

        public WorkerService(IUnitOfWork uow)
        {
            Database = uow;
            //Mapper.Initialize(cfg =>
            //{
            //    cfg.AddProfile(new BllMappingProfile());
            //});
        }

        public IEnumerable<WorkerDto> GetWorkers()
        {
            var workers = Database.Workers.GetAll();
            var workerDtos = Mapper.Map<IEnumerable<Worker>, IEnumerable<WorkerDto>>(workers);
            return workerDtos;
        }

        public IEnumerable<WorkerDto> GetWorkersByCrewmanType(CrewmanType type, bool isVacant)
        {
            Func<Worker, bool> predicate = w => w.CrewmanType == type;

            if(isVacant)
                predicate = w => w.CrewmanType == type && w.Crews == null;

            var workers = Database.Workers.Find(predicate);
            var workerDtos = Mapper.Map<IEnumerable<Worker>, IEnumerable<WorkerDto>>(workers);
            return workerDtos;
        }

        public WorkerDto GetWorker(object key)
        {
            if (key == null)
                throw new ArgumentException("Worker's id was not set");

            var worker = Database.Workers.Get(key);

            if (worker == null)
                throw new ArgumentException($"Worker with key={key} was not found");

            var workerDto = Mapper.Map<Worker, WorkerDto>(worker);

            return workerDto;
        }

        public void CreateWorker(WorkerDto workerDto)
        {
            if(workerDto == null)
                throw new ArgumentException("Worker's object was not passed");

            var worker = Mapper.Map<WorkerDto, Worker>(workerDto);

            Database.Workers.Create(worker);
            Database.Save();
        }

        public void EditWorker(WorkerDto workerDto)
        {
            if (workerDto == null)
                throw new ArgumentException("Worker's object was not passed");
            var worker = Mapper.Map<WorkerDto, Worker>(workerDto);

            Database.Workers.Update(worker);
            Database.Save();
        }

        public void DeleteWorker(object key)
        {
            if (key == null)
                throw new ArgumentException("Worker's id was not set");

            var hasCrew = Database.Workers.GetAll().Include(x => x.Crews).
                Any(x => x.Crews.Count > 0 && x.Id == (int)key);

            if (hasCrew)
                throw new ArgumentException("Removal is forbidden. Worker is in crew");

            Database.Workers.Delete(key);
            Database.Save();
        }
    }
}