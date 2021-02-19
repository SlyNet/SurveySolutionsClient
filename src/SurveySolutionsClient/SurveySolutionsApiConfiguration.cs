// unset

namespace SurveySolutionsClient
{
    public class SurveySolutionsApiConfiguration
    {
        public SurveySolutionsApiConfiguration(Credentials credentials, string baseUrl)
        {
            Credentials = credentials;
            BaseUrl = baseUrl.TrimEnd('/');
        }

        public Credentials Credentials { get; set; }
        public string BaseUrl { get; set; }
    }
}