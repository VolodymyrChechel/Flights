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
        CrewCompostionDto GetCrewComposition(object key);
        CrewDto CreateEmptyCrewWithComposition(CrewDto crewDto);
        void CreateFullCrew(CrewDto crewDto);
        void EditCrew(CrewDto crewDto);
        void DeleteCrew(object key);

    }
}