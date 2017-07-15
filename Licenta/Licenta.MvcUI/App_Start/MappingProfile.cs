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
            CreateMap<Condition, ConditionDto>().ForMember(dest => dest.symptoms,
                opts => opts.MapFrom(src => src.symptoms_conditions.Select(symptomCond => Mapper.Map<Symptom, SymptomDto>(symptomCond.symptom)).ToList()));
        }
    }
}