using AutoMapper;
using ElevatorControlSystem.Entities.DTOs;
using ElevatorControlSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorControlSystem.Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Elevator, ElevatorDTO>()
                .ForMember(dest => dest.Direction, opt => opt.MapFrom(src => src.Direction.ToString()));
        }
    }
}
