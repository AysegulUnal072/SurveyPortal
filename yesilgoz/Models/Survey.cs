using System.ComponentModel.DataAnnotations;

namespace SurveyPortal.Models
{
    public class Survey : BaseEntity
    {
        
        public string Title { get; set; }
        public List<Question> Questions { get; set; }
        public bool IsActive { get; set; }  

        
        
        public int CategoryId {  get; set; }    
        
        public Category Category { get; set; }
     
    }
    
}
