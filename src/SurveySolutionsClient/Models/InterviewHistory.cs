using System;
using System.Collections.Generic;

namespace SurveySolutionsClient.Models
{
    public class InterviewHistory
    {
        public Guid InterviewId { get; set; }
        public Guid QuestionnaireId { get; set; }
        public long QuestionnaireVersion { get; set; }
        public List<InterviewHistoricalRecord> Records { get; set; }
    }
}
