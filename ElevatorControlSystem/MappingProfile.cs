using AutoMapper;
using ElevatorControlSystem.Entities;
using ElevatorControlSystem.Entities.DTOs;
using System;

namespace ElevatorControlSystem.ConsoleApp
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Elevator, ElevatorDTO>();
        }
    }
}
