using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using SurveyPortal.Models;

namespace SurveyPortal.Models
{
    public static class SeedData
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Category>().HasData(
                new Category() { Id = 1, Name = "Categori 1", IsActive = true },
                new Category() { Id = 2, Name = "Categori 1", IsActive = true },
                new Category() { Id = 3, Name = "Categori 2", IsActive = true }
                );
           


            modelBuilder.Entity<Survey>().HasData(new Survey()  { Id = 1, Title = "Şehir", IsActive = true, CategoryId = 1  },

                new Survey() { Id = 2, Title = "Aktivite", IsActive = true, CategoryId = 2 },
                new Survey() { Id = 3, Title = "Manzara", IsActive = true, CategoryId = 3 }

            );


        }
    }
}




  

