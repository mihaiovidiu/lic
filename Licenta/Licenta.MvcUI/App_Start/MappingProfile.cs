using AutoMapper;
using Licenta.DAL;
using Licenta.MvcUI.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Licenta.MvcUI.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Symptom, SymptomDto>();
        }
    }
}