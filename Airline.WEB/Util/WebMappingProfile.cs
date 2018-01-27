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


        }
    }
}