// unset

namespace SurveySolutionsClient
{
    public class SurveySolutionsApiConfiguration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SurveySolutionsApiConfiguration"/> class.
        /// </summary>
        /// <param name="credentials">The credentials.</param>
        /// <param name="baseUrl">The base URL.</param>
        public SurveySolutionsApiConfiguration(Credentials credentials, string baseUrl)
        {
            Credentials = credentials;
            BaseUrl = baseUrl.TrimEnd('/');
        }

        /// <summary>
        /// Gets the credentials.
        /// </summary>
        /// <value>
        /// The credentials.
        /// </value>
        public Credentials Credentials { get; }

        /// <summary>
        /// Gets the Headquarters base URL. Do not add trailing slash or workspace at the end
        /// </summary>
        /// <value>
        /// The base URL.
        /// </value>
        public string BaseUrl { get; }
    }
}