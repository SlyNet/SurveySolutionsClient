using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using GraphQlClientGenerator;
using NUnit.Framework;

namespace SurveySolutionsClient.Tests
{
    class SuurveySolutionsTypeMappingProvider : IScalarFieldTypeMappingProvider
    {
        public ScalarFieldTypeDescription GetCustomScalarFieldType(GraphQlGeneratorConfiguration configuration, 
            GraphQlType baseType,
            GraphQlTypeBase valueType, 
            string valueName)
        {
            valueType = valueType is GraphQlFieldType fieldType ? fieldType.UnwrapIfNonNull() : valueType;

            // DateTime and Byte
            switch (valueType.Name)
            {
                case "Uuid": return new ScalarFieldTypeDescription { NetTypeName = "Guid?", FormatMask = "N" };
                case "Uuid!": return new ScalarFieldTypeDescription { NetTypeName = "Guid", FormatMask = "N" };
                case "Long": return new ScalarFieldTypeDescription { NetTypeName = "long?", FormatMask = null };
                case "DateTime": return new ScalarFieldTypeDescription { NetTypeName = "DateTime?", FormatMask = null };
                case "DateTime!": return new ScalarFieldTypeDescription { NetTypeName = "DateTime", FormatMask = null };
            }

            // fallback - not needed if all fields and arguments are resolved or the expected type is of "object" type
            return DefaultScalarFieldTypeMappingProvider.Instance.GetCustomScalarFieldType(configuration, baseType, valueType, valueName);
        }
    }

    public class GrapqlGenerator
    {
        [Test]
        [Ignore("used for schema generate")]
        public async Task GenerateAsync()
        {
            var schema = await GraphQlGenerator.RetrieveSchema("https://localhost:5000/graphql");

            var configuration = new GraphQlGeneratorConfiguration();
            configuration.ScalarFieldTypeMappingProvider = new SuurveySolutionsTypeMappingProvider();
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