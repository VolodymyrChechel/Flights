using System;
using System.Collections;
using System.Collections.Generic;
using Airline.BLL.DTO;

namespace Airline.BLL.Interfaces
{
    public interface ICrewService
    {
        IEnumerable<CrewDto> GetCrews();
        CrewDto GetCrew(object key);
        IEnumerable<CrewCompostionDto> GetCrewCompositions();
        /// <summary>
        /// Allow get data of plane accessibility (date and airport)
        /// </summary>
        void GetLastFlightDataForCrew(object key, out DateTime date, out string airportId);
        CrewCompostionDto GetCrewComposition(object key);
        void CreateCrew(CrewDto crewDto);
        void EditCrew(CrewDto crewDto);
        void DeleteCrew(object key);

    }
}