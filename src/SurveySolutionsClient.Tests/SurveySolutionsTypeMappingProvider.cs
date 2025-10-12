using GraphQlClientGenerator;

namespace SurveySolutionsClient.Tests;

class SurveySolutionsTypeMappingProvider : IScalarFieldTypeMappingProvider
{
    public ScalarFieldTypeDescription GetCustomScalarFieldType(ScalarFieldTypeProviderContext context)
    {
        // valueType = context.FieldType is GraphQlFieldType fieldType ? fieldType.UnwrapIfNonNull() : valueType;

        // DateTime and Byte
        switch (context.FieldType.Name)
        {
            case "Uuid": return new ScalarFieldTypeDescription { NetTypeName = "Guid?", FormatMask = "N" };
            case "Uuid!": return new ScalarFieldTypeDescription { NetTypeName = "Guid", FormatMask = "N" };
            case "Long": return new ScalarFieldTypeDescription { NetTypeName = "long?", FormatMask = null };
            case "DateTime": return new ScalarFieldTypeDescription { NetTypeName = "DateTime?", FormatMask = null };
            case "DateTime!": return new ScalarFieldTypeDescription { NetTypeName = "DateTime", FormatMask = null };
        }

        // fallback - not needed if all fields and arguments are resolved or the expected type is of "object" type
        return DefaultScalarFieldTypeMappingProvider.Instance.GetCustomScalarFieldType(context);
    }
}