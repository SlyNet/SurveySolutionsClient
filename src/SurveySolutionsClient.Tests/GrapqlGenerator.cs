using System.IO;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using GraphQlClientGenerator;
using NUnit.Framework;

namespace SurveySolutionsClient.Tests
{
    public class GrapqlGenerator
    {
        [Test]
        public async Task GenerateAsync()
        {
            var schema = await GraphQlGenerator.RetrieveSchema(
                HttpMethod.Get, 
                "http://localhost:9700/graphql"
                );

            var configuration = new GraphQlGeneratorConfiguration();
            configuration.ScalarFieldTypeMappingProvider = new SurveySolutionsTypeMappingProvider();
            configuration.FloatTypeMapping = FloatTypeMapping.Double;
            configuration.IntegerTypeMapping = IntegerTypeMapping.Int32;
            configuration.CSharpVersion = CSharpVersion.NewestWithNullableReferences;
            configuration.IdTypeMapping = IdTypeMapping.String;


            var generator = new GraphQlGenerator(configuration);   
            var csharpCode = generator.GenerateFullClientCSharpFile(schema, "SurveySolutionsClient.GraphQl");
            File.WriteAllText(@"C:\projects\SuSoClient\Repository\src\SurveySolutionsClient\Graphql.cs", csharpCode);
        }
    }
}