using System;
using System.Linq;
using Airline.BLL.DTO;
using Airline.Common.Enums;
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
                    var dt = s.PlannedDepartureTime;
                    var dateTime = DateTime.Today.Add(dt);
                   d.PlannedDepartureTime = dateTime.ToString("hh:mm tt");
                    var ft = s.PlannedFlightTime;
                    d.PlannedFlightTime = string.Format("{0:00}:{1:00}", ft.Hours, ft.Minutes);
                });
            CreateMap<FlightViewModel, FlightDto>().
                AfterMap((s, d) => d.PlannedFlightTime = TimeSpan.Parse(s.PlannedFlightTime));

            CreateMap<LoginModel, UserDto>();

            CreateMap<CreateCrewModel, CrewDto>().AfterMap((s, d) =>
            {
                d.SelectedWorkersId = s.SelectedAircraftPilots.Concat(s.SelectedCaptains).Concat(s.SelectedHostess)
                    .Concat(s.SelectedRadioOperators).Concat(s.SelectedNavigatorOfficers).ToList();
            });
            CreateMap<CrewDto, ShowCrewModel>();
            CreateMap<TimetableCreateModel, TimetableDto>().AfterMap((s, d) =>
            {
                if (s.CrewId == null)
                    d.ApplicationStatus = ApplicationStatus.Attention;
                else
                    d.ApplicationStatus = ApplicationStatus.New;
            });

            CreateMap<TimetableDto, TimetableModel>();
            CreateMap<TimetableModel, TimetableDto>();
        }
    }
}