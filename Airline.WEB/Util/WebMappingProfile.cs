﻿using System;
using System.Linq;
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
                d.PlannedFlightTime = ft.ToString(@"hh\:mm");
            });
            CreateMap<FlightViewModel, FlightDto>().
                AfterMap((s, d) => d.PlannedFlightTime = TimeSpan.Parse(s.PlannedFlightTime));

            CreateMap<LoginModel, UserDto>();

            CreateMap<CrewViewModel, CrewDto>().AfterMap((s, d) =>
            {
                d.SelectedWorkersId = s.SelectedAircraftPilots.Concat(s.SelectedCaptains).Concat(s.SelectedHostess)
                    .Concat(s.SelectedRadioOperators).Concat(s.SelectedNavigatorOfficers).ToList();
            });
            CreateMap<CrewDto, CrewViewModel>();
        }
    }
}