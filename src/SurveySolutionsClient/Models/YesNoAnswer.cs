namespace SurveySolutionsClient.Models
{
    public record YesNoAnswer 
    {
        public int Value { get; set; }
        public bool Yes { get; set; }
        public bool No { get; set; }
    }
}