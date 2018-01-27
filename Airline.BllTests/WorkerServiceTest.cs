using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Airline.BLL.DTO;
using Airline.BLL.Interfaces;
using Airline.BLL.Services;
using Airline.Common.Enums;
using Airline.DAL.Entities;
using Airline.DAL.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Airline.BllTests
{
    [TestClass]
    public class WorkerServiceTest
    {
        private static readonly List<Worker> workers = new List<Worker> { 
            new Worker() { Name = "Oleksii", Surname = "Bondarenko", BirthDate = DateTime.Parse("1974-3-5"), PhoneNumber = "+380634709089", CrewmanType = CrewmanType.AircraftPilot},
            new Worker() { Name = "Yevhen", Surname = "Momot", BirthDate = DateTime.Parse("1969-5-28"), PhoneNumber = "+380994249474", CrewmanType = CrewmanType.AircraftPilot},
            new Worker() { Name = "Yakiv", Surname = "Oliynyk", BirthDate = DateTime.Parse("1961-4-29"), PhoneNumber = "+380509131890", CrewmanType = CrewmanType.AircraftPilot}
            };

        private static readonly IEnumerable<WorkerDto> workerDtos = new List<WorkerDto> {
            new WorkerDto() { Name = "Oleksii", Surname = "Bondarenko", BirthDate = DateTime.Parse("1974-3-5"), PhoneNumber = "+380634709089", CrewmanType = CrewmanType.AircraftPilot},
            new WorkerDto() { Name = "Yevhen", Surname = "Momot", BirthDate = DateTime.Parse("1969-5-28"), PhoneNumber = "+380994249474", CrewmanType = CrewmanType.AircraftPilot},
            new WorkerDto() { Name = "Yakiv", Surname = "Oliynyk", BirthDate = DateTime.Parse("1961-4-29"), PhoneNumber = "+380509131890", CrewmanType = CrewmanType.AircraftPilot}
        };

        private IWorkerService service;

        [TestMethod]
        public void MustAddNewObject()
        {
            var mock = new Mock<IUnitOfWork>();
            mock.Setup(a => a.Workers.GetAll()).Returns(workers.AsQueryable());

            service = new WorkerService(mock.Object);
            var gtw = service.GetWorkers();

            var hashMoch = gtw.GetHashCode();
            var hash = workerDtos.GetHashCode();

            var hashMoch1 = gtw.GetHashCode();
            var hash1 = workerDtos.GetHashCode();

            //CollectionAssert.AreEqual(gtw, workerDtos);
            Assert.IsTrue(gtw.SequenceEqual(workerDtos));
        }
    }
}