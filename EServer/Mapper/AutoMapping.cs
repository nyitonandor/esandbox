using AutoMapper;
using EServer.Dtos;
using EServer.Models;

namespace EServer.Services
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Motorcycle, MotorcycleDto>();
            CreateMap<MotorcycleDto, Motorcycle>();
        }
    }
}
