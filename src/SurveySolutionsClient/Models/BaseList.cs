namespace SurveySolutionsClient.Models
{
    public abstract class BaseList
    {
        public string Order { get; set; }

        public int Limit { get; set; }

        public int TotalCount { get; set; }

        public int Offset { get; set; }
    }
}