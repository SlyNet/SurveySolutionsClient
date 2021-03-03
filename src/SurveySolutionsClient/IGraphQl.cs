using System.Threading;
using System.Threading.Tasks;
using SurveySolutionsClient.GraphQl;

namespace SurveySolutionsClient
{
    /// <summary>
    /// Wraps GraphQL calls
    /// </summary>
    public interface IGraphQl
    {
        Task<T> ExecuteAsync<T>(GraphQlQueryBuilder query, CancellationToken cancellationToken = default);
    }
}