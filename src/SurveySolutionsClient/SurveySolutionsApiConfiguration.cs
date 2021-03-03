//[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("SurveySolutionsClient.Tests")]

namespace SurveySolutionsClient
{
    public class SurveySolutionsApiConfiguration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SurveySolutionsApiConfiguration" /> class.
        /// </summary>
        /// <param name="credentials">The credentials.</param>
        /// <param name="baseUrl">The base URL.</param>
        /// <param name="workSpace">The work space.</param>
        public SurveySolutionsApiConfiguration(Credentials credentials, string baseUrl, string? workSpace = null)
        {
            Credentials = credentials;
            WorkSpace = workSpace;
            BaseUrl = baseUrl;

            TargetUrlWithWorkspace = baseUrl.TrimEnd('/');
            if (workSpace != null)
            {
                TargetUrlWithWorkspace += $"/{workSpace}";
            }
        }

        /// <summary>
        /// Gets the Headquarters base URL. Do not add trailing slash or workspace at the end
        /// </summary>
        /// <value>
        /// The base URL.
        /// </value>
        public string BaseUrl { get; }

        /// <summary>
        /// Gets the credentials.
        /// </summary>
        /// <value>
        /// The credentials.
        /// </value>
        public Credentials Credentials { get; }

        internal string TargetUrlWithWorkspace { get; }

        /// <summary>
        /// Gets the work space.
        /// </summary>
        /// <remarks>
        /// You can read about work spaces in here https://docs.mysurvey.solutions/release-notes/version-21-01/
        /// </remarks>
        /// <value>
        /// The workspace.
        /// </value>
        public string? WorkSpace { get; }
    }
}