using AutoMapper;
using RoboContext.Domain.Entities;
using RoboContext.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboContext.Domain.AutoMapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<RoboHeadDTO, RoboHeadService>();
            CreateMap<RoboArmsDTO, RoboArmsService>();
        }
    }
}
