using System.Reflection.Metadata.Ecma335;

namespace SurveySolutionsClient.Tests
{
    public class ClientSettings
    {
        public static SurveySolutionsApiConfiguration GetConfiguration() =>
            new SurveySolutionsApiConfiguration
            {
                BaseUrl = "http://localhost:5001", Credentials = new Credentials {UserName = "api", Password = "Qwerty1234"}
            };
    }
}