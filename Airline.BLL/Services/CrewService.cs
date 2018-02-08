using System.Collections;
using System.Collections.Generic;
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
            throw new System.NotImplementedException();
        }

        public CrewDto GetCrew(object key)
        {
            throw new System.NotImplementedException();
        }
        
        public IEnumerable<CrewCompostionDto> GetCrewCompositions()
        {
            var compositions = Database.CrewCompositions.GetAll();
            var compostionDtos =
                Mapper.Map<IEnumerable<CrewComposition>, IEnumerable<CrewCompostionDto>>(compositions);

            return compostionDtos;
        }

        public CrewDto CreateEmptyCrewWithComposition(CrewDto crewDto)
        {
            throw new System.NotImplementedException();
        }

        public void CreateFullCrew(CrewDto crewDto)
        {
            throw new System.NotImplementedException();
        }

        public void CreateCrew(CrewDto crewDto)
        {
            throw new System.NotImplementedException();
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