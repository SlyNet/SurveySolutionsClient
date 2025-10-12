using System;
using SurveySolutionsClient.Models;

namespace SurveySolutionsClient.Tests
{
    public class ClientSettings
    {
        public const string HqUrl = "http://localhost:9700";

        public static SurveySolutionsApiConfiguration GetConfiguration(string workspace = null) =>
            new(new Credentials("api", "Qwerty1234"), HqUrl, workspace);

        public static QuestionnaireIdentity Questionnaire => new QuestionnaireIdentity(Guid.Parse("4cbce5d5-6218-46b3-ac9c-7a8e64c43506"), 2);
    }
}