using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Tengella.Survey.Data.Models;
using Tengella.Survey.WebApp.Models;


namespace Tengella.Survey.Data.Mapper
{
    public class MapperConfig : Profile
    {
        public MapperConfig() 
        {
            CreateMap<SurveyViewModel, SurveyObject>();
            CreateMap<SurveyViewModel, SurveyObject>().ReverseMap();
        }
    }
}
