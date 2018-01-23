using System.Collections.Generic;
using Airline.BLL.DTO;
using Airline.BLL.Interfaces;
using Airline.BLL.Util;
using Airline.DAL.Entities;
using Airline.DAL.Interfaces;
using AutoMapper;

namespace Airline.BLL.Services
{
    public class WorkerService : IWorkerService
    {
        private IUnitOfWork Database { get; set; }

        public WorkerService(IUnitOfWork uow)
        {
            Database = uow;
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile(new BllMappingProfile());
            });
        }

        public IEnumerable<WorkerDto> GetWorkers()
        {
            var workers = Database.Workers.GetAll();
            var workerDtos = Mapper.Map<IEnumerable<Worker>, IEnumerable<WorkerDto>>(workers);
            return workerDtos;
        }

        public WorkerDto GetWorker(object key)
        {
            throw new System.NotImplementedException();
        }

        public void CreateWorker(WorkerDto missing_name)
        {
            throw new System.NotImplementedException();
        }

        public void EditWorker(WorkerDto missing_name)
        {
            throw new System.NotImplementedException();
        }
    }
}