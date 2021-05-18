using System;
using SurveySolutionsClient.Models;

namespace SurveySolutionsClient.Tests
{
    public class ClientSettings
    {
        public const string HqUrl = "http://localhost:5001";

        public static SurveySolutionsApiConfiguration GetConfiguration(string workspace = null) =>
            new(new Credentials("api", "Qwerty1234"), HqUrl, workspace);

        public static QuestionnaireIdentity Questionnaire => new QuestionnaireIdentity(Guid.Parse("bb930378-1037-4a53-9dfd-26029b419925"), 1);
    }
}