using System;

namespace SurveySolutionsClient.Models
{
    public class AuditLogApiView
    {
        public DateTime? NextBatchRecordDate { get; set; }
        public AuditLogRecordApiView[] Records { get; set; }
    }

    public class AuditLogRecordApiView
    {
        public DateTime Time { get; set; }
        public string Message { get; set; }
    }
}
