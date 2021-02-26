using System;
using System.Net.Http;

namespace SurveySolutionsClient.Exceptions
{
    /// <summary>
    /// Thrown in case of non success response status code returned from server and client does not know how to handle it properly. Otherwise typed exception will be thrown.
    /// </summary>
    /// <seealso cref="System.Exception" />
    [Serializable]
    public class ApiCallException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApiCallException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="responseBody">Server response body.</param>
        /// <param name="serverResponse">The Headquarters server response.</param>
        public ApiCallException(string message, string? responseBody, HttpResponseMessage serverResponse) : base(message)
        {
            this.ServerResponse = serverResponse;
            this.ResponseBody = responseBody;
        }

        /// <summary>
        /// Gets the server response returned by Headquarters.
        /// </summary>
        /// <value>
        /// The server response.
        /// </value>
        public HttpResponseMessage ServerResponse { get; }

        /// <summary>
        /// Gets or sets the response body.
        /// </summary>
        /// <value>
        /// The response body.
        /// </value>
        public string? ResponseBody { get;}
    }
}