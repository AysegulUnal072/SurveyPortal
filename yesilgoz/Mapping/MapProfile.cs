using AutoMapper;
using SurveyPortal.Models;
using SurveyPortal.ViewModels;

namespace SurveyPortal.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile() 
        {
            CreateMap<Survey, SurveyModel>().ReverseMap();
            CreateMap<Category, CategoryModel>().ReverseMap();
            CreateMap<AppUser, UserModel>().ReverseMap();
            CreateMap<AppUser, RegisterModel>().ReverseMap();
        }
    }
}
