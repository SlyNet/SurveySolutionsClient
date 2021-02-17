using System;
using System.Net.Http;

namespace SurveySolutionsClient.Exceptions
{
    /// <summary>
    /// Thrown in case of non success response status code returned from server
    /// </summary>
    /// <seealso cref="System.Exception" />
    [Serializable]
    public class ApiCallException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApiCallException"/> class.
        /// </summary>
        public ApiCallException() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiCallException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="serverResponse">The Headquarters server response.</param>
        public ApiCallException(string message, HttpResponseMessage serverResponse) : base(message)
        {
            this.ServerResponse = serverResponse;
        }

        /// <summary>
        /// Gets the server response returned by Headquarters.
        /// </summary>
        /// <value>
        /// The server response.
        /// </value>
        public HttpResponseMessage ServerResponse { get; }
    }
}