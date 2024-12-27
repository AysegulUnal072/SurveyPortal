namespace SurveyPortal.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<Question> Questions { get; set; }
    }
}
