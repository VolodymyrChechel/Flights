using System.Collections;
using System.Collections.Generic;
using Airline.BLL.DTO;

namespace Airline.BLL.Interfaces
{
    public interface IWorkerService
    {
        IEnumerable<WorkerDto> GetWorkers();
        WorkerDto GetWorker(object key);
        void CreateWorker(WorkerDto workerDto);
        void EditWorker(WorkerDto workerDto);
        void DeleteWorker(object key);

    }
}