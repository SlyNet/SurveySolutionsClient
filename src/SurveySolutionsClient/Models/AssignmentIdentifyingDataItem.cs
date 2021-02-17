using System.Runtime.Serialization;

namespace SurveySolutionsClient.Models
{
    public class AssignmentIdentifyingDataItem
    {
        /// <summary>
        /// Question identity
        /// Expected format: GuidWithoutDashes_Int1-Int2, where _Int1-Int2 - codes of parent rosters (empty if question is not inside any roster).
        /// For example: 11111111111111111111111111111111_0-1 should be used for question on the second level
        /// </summary>
        [DataMember]
        public string Identity { get; set; }

        [DataMember]
        public string Variable { get; set; }

        [DataMember]
        public string Answer { get; set; }
    }
}