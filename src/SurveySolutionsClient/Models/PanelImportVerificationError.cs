using System.Collections.Generic;

namespace SurveySolutionsClient.Models
{
    public class PanelImportVerificationError
    {
        public string Code { get; }
        public string Message { get; }
        public IEnumerable<InterviewImportReference> References { get; }

        public override string ToString() => $"{this.Code}: {this.Message}";
    }
}