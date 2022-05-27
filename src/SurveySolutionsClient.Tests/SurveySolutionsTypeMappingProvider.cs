using GraphQlClientGenerator;

namespace SurveySolutionsClient.Tests;

class SurveySolutionsTypeMappingProvider : IScalarFieldTypeMappingProvider
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