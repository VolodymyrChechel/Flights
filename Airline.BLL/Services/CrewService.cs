using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Airline.BLL.DTO;
using Airline.BLL.Interfaces;
using Airline.DAL.Entities;
using Airline.DAL.Interfaces;
using AutoMapper;

namespace Airline.BLL.Services
{
    public class CrewService : ICrewService
    {
        private IUnitOfWork Database { get; set; }

        public CrewService(IUnitOfWork database)
        {
            Database = database;
        }

        public IEnumerable<CrewDto> GetCrews()
        {
            var crews = Database.Crews.GetAll().Include(c => c.Workers);
            var crewDtos = new List<CrewDto>();

            foreach (var crew in crews)
            {
                string workerSummary = $"{crew.Id}. Crew composition - {crew.CrewCompositionId}, Workers: ";
                var workers = crew.Workers;
                foreach (var worker in workers)
                {
                    workerSummary += worker.Surname + " ";
                }

                crewDtos.Add(new CrewDto
                {
                    Id = crew.Id,CrewCompositionId = crew.CrewCompositionId,
                    WorkersDescription = workerSummary
                });
            }
            return crewDtos;
        }

        public CrewDto GetCrew(object key)
        {
            if (key == null)
                throw new ArgumentException("Crew's id was not set");

            var crew = Database.Crews.Get(key);

            if (crew == null)
                throw new ArgumentException($"Crew with key={key} was not found");

            var crewDto = new CrewDto();

                string workerSummary = $"{crew.Id}. Crew composition - {crew.CrewCompositionId}, Workers: ";
                var workers = crew.Workers;
                foreach (var worker in workers)
                {
                    workerSummary += worker.Surname + " ";
                }

 return new CrewDto
                {
                    Id = crew.Id,
                    CrewCompositionId = crew.CrewCompositionId,
                    WorkersDescription = workerSummary
                };
        }
        
        public IEnumerable<CrewCompostionDto> GetCrewCompositions()
        {
            var compositions = Database.CrewCompositions.GetAll();
            var compostionDtos =
                Mapper.Map<IEnumerable<CrewComposition>, IEnumerable<CrewCompostionDto>>(compositions);

            return compostionDtos;
        }

        public void GetLastFlightDataForCrew(object key, out DateTime date, out string airportId)
        {
            if (key == null)
                throw new ArgumentException("Crew's id was not set");

            var crew = Database.Crews.GetAll().Where(x => x.Id == (int) key).Include(x => x.TimeTables)
                .FirstOrDefault();

            if (crew == null)
                throw new ArgumentException("Crew was not found");

            var lastTimeTable = crew.TimeTables.OrderByDescending(x => x.DateTime).First();
            airportId = Database.Flights.Get(lastTimeTable.FlightId).ToIATA;

            var crewDateTime = lastTimeTable.DateTime.AddDays(1);
            date = DateTime.UtcNow.AddDays(1);

            if (crewDateTime > date)
                date = crewDateTime;
        }

        public CrewCompostionDto GetCrewComposition(object key)
        {
            if (key == null)
                throw new ArgumentException("Crew composition's id was not set");

            var crewComposition = Database.CrewCompositions.Get(key);

            if (crewComposition == null)
                throw new ArgumentException($"Crew composition with key={key} was not found");

            var crewCompostionDto = Mapper.Map<CrewComposition, CrewCompostionDto>(crewComposition);

            return crewCompostionDto;
        }

        public void CreateCrew(CrewDto crewDto)
        {
            if (crewDto == null)
                throw new ArgumentException("Crew's object was not passed");

            var crew = Mapper.Map<CrewDto, Crew>(crewDto);
            var workers = Database.Workers.Find(x => crewDto.SelectedWorkersId.Contains(x.Id)).ToList();
            crew.Workers = workers;

            Database.Crews.Create(crew);
            Database.Save();
        }

        public void EditCrew(CrewDto crewDto)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteCrew(object key)
        {
            throw new System.NotImplementedException();
        }
    }
}