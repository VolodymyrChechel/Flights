using System.Collections;
using System.Collections.Generic;
using Airline.BLL.DTO;
using Airline.Common.Enums;

namespace Airline.BLL.Interfaces
{
    public interface IWorkerService
    {
        IEnumerable<WorkerDto> GetWorkers();
        IEnumerable<WorkerDto> GetWorkersByCrewmanType(CrewmanType type, bool isVacant = false);
        WorkerDto GetWorker(object key);
        void CreateWorker(WorkerDto workerDto);
        void EditWorker(WorkerDto workerDto);
        void DeleteWorker(object key);

    }
}