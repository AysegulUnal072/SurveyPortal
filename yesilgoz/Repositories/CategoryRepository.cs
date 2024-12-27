using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SurveyPortal.Models;
using SurveyPortal.ViewModels;

namespace SurveyPortal.Repositories
{
    public class CategoryRepository : GenericRepository<Category>
    {
        public CategoryRepository(AppDbContext context) : base(context) 
        {
        }
       
    }
}
