using Airline.BLL.DTO;
using Airline.DAL.Entities;
using AutoMapper;

namespace Airline.BLL.Util
{
    public class BllMappingProfile : Profile
    {
        public BllMappingProfile()
        {
            CreateMap<Worker, WorkerDto>();
            CreateMap<Worker, WorkerDto>().ReverseMap();

            CreateMap<Flight, FlightDto>();
            CreateMap<FlightDto, Flight>().BeforeMap((s, d) =>
            {
                s.FromName = null;
                s.ToName = null;
            });

            CreateMap<Airport, AirportDto>();
            CreateMap<AirportDto, Airport>();

            CreateMap<CrewComposition, CrewCompostionDto>();
        }
    }
}