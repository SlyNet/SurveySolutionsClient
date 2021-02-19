using System;

namespace SurveySolutionsClient.Models
{
    public class ExportJobLinks
    {
        /// <summary>
        /// Link for cancelling export process
        /// </summary>
        public string Cancel { get; set; } = String.Empty;
        /// <summary>
        /// Link for downloading file with data
        /// </summary>
        public string Download { get; set; } = String.Empty;
    }
}