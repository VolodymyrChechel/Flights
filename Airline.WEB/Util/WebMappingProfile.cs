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
            CreateMap<WorkerViewModel, WorkerDto>();

            CreateMap<FlightDto, FlightViewModel>().
            AfterMap((s, d) =>
            {
                var ft = s.PlannedFlightTime;
                d.PlannedFlightTime = s.PlannedFlightTime.ToString(@"hh\:mm");
            });
            CreateMap<FlightViewModel, FlightDto>().
                AfterMap((s, d) => d.PlannedFlightTime = TimeSpan.Parse(s.PlannedFlightTime));
        }
    }
}