using System;
using Airline.BLL.DTO;
using Airline.WEB.Models;
using AutoMapper;

namespace Airline.WEB.Util
{
    public class WebMappingProfile : Profile
    {
        public WebMappingProfile()
        {
            CreateMap<WorkerDto, WorkerViewModel>();
            CreateMap<WorkerDto, WorkerViewModel>().ReverseMap();

            CreateMap<FlightDto, FlightViewModel>().
                BeforeMap((s, d) => d.PlannedFlightTime = s.PlannedFlightTime.ToString("hh:mm"));
            CreateMap<FlightDto, FlightViewModel>().ReverseMap().
                BeforeMap((s, d) => d.PlannedFlightTime = TimeSpan.Parse(s.PlannedFlightTime));
        }
    }
}