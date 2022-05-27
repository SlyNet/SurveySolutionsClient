using System;
using SurveySolutionsClient.Models;

namespace SurveySolutionsClient.Tests
{
    public class ClientSettings
    {
        public const string HqUrl = "http://localhost:9700";

        public static SurveySolutionsApiConfiguration GetConfiguration(string workspace = null) =>
            new(new Credentials("api", "Qwerty1234"), HqUrl, workspace);

        public static QuestionnaireIdentity Questionnaire => new QuestionnaireIdentity(Guid.Parse("1949c957-f891-4b93-be78-37cf41baa0a9"), 1);
    }
}