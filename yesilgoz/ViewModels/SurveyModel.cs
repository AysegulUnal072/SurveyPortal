using System.ComponentModel.DataAnnotations;
using SurveyPortal.Models;


namespace SurveyPortal.ViewModels
{
    public class SurveyModel : BaseModel
    {



        [Display(Name = "Anket Başlığı")]
        [Required(ErrorMessage = "Anket Başlığı Giriniz!")]
        public string Title { get; set; }


        
        
        [Display(Name = "Soru")]
        [Required(ErrorMessage = "Soru Giriniz!")]
        public List<Question> Questions { get; set; }

       

        
        
        [Display(Name = "Kategori")]
        [Required(ErrorMessage = "Kategori Giriniz!")]
        public int CategoryId {  get; set; }    
    }
}
