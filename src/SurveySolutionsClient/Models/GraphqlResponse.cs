using System.Collections.Generic;
using SurveySolutionsClient.GraphQl;

namespace SurveySolutionsClient.Models
{
    public class GraphqlResponse
    {
        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        public HeadquartersQuery Data { get; set; }

        /// <summary>
        /// Gets or sets the errors.
        /// </summary>
        /// <value>
        /// The errors.
        /// </value>
        public List<GrapQlError>? Errors { get; set; }
    }
}