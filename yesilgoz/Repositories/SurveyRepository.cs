using AutoMapper;
using Microsoft.Identity.Client;
using SurveyPortal.Models;
using SurveyPortal.ViewModels;

namespace SurveyPortal.Repositories
{
    public class SurveyRepository : GenericRepository<Survey>
    {
       public SurveyRepository(AppDbContext context) : base(context) 
       { 
       }

       
    }
}
