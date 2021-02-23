using System;

namespace SurveySolutionsClient.Models
{
    public class AuditLogRecord
    {
        public DateTime Time { get; set; }
        public string Message { get; set; }
    }
}
