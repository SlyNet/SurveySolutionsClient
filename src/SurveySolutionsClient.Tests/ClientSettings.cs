using System;
using SurveySolutionsClient.Models;

namespace SurveySolutionsClient.Tests
{
    public class ClientSettings
    {
        public static SurveySolutionsApiConfiguration GetConfiguration(string workspace = null) =>
            new SurveySolutionsApiConfiguration(new Credentials("api", "Qwerty1234"), "http://localhost:5001", workspace);

        public static QuestionnaireIdentity Questionnaire => new QuestionnaireIdentity(Guid.Parse("1949c957-f891-4b93-be78-37cf41baa0a9"), 1);
    }
}