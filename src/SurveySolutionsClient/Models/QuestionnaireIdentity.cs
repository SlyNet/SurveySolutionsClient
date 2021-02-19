using System;

namespace SurveySolutionsClient.Models
{
    /// <summary>
    /// Represents id of questionnaire
    /// </summary>
    public class QuestionnaireIdentity
    {
        /// <summary>Initializes a new instance of the <see cref="QuestionnaireIdentity" /> class.</summary>
        public QuestionnaireIdentity() : this(Guid.Empty, 0)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QuestionnaireIdentity"/> class.
        /// </summary>
        /// <param name="questionnaireId">The questionnaire identifier.</param>
        /// <param name="version">The version of imported questionnaire.</param>
        public QuestionnaireIdentity(Guid questionnaireId, long version)
        {
            this.QuestionnaireId = questionnaireId;
            this.Version = version;
        }

        /// <summary>
        /// Version of questionnaire imported on Headquarters
        /// </summary>
        public long Version { get; set; }

        /// <summary>
        /// Questionnaire id (same as on Designer)
        /// </summary>
        public Guid QuestionnaireId { get; set; }

        /// <summary>
        /// Equality comparison
        /// </summary>
        /// <param name="other"></param>
        public bool Equals(QuestionnaireIdentity? other)
        {
            if ((object?)other == null)
            {
                return false;
            }

            return this.Version == other.Version && this.QuestionnaireId.Equals(other.QuestionnaireId);
        }

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return this.QuestionnaireId.ToString("N") + "$" + this.Version;
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            unchecked
            {
                return (this.Version.GetHashCode() * 863) ^ this.QuestionnaireId.GetHashCode();
            }
        }

        /// <summary>Determines whether the specified <see cref="System.Object" />, is equal to this instance.</summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.</returns>
        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            return obj is QuestionnaireIdentity other && this.Equals(other);
        }

        /// <summary>Implements the operator ==.</summary>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(QuestionnaireIdentity? a, QuestionnaireIdentity? b)
        {
            if (ReferenceEquals(a, b))
                return true;

            if (((object?)a == null) || ((object?)b == null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(QuestionnaireIdentity? a, QuestionnaireIdentity? b) => !(a == b);

        public static QuestionnaireIdentity Parse(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentNullException(nameof(id), "the id is null or empty string");

            var idParameters = id.Split('$');
            if (idParameters.Length != 2)
                throw new FormatException($"id value '{id}' is not in the correct format.");

            try
            {
                var questionnaireId = Guid.Parse(idParameters[0]);
                var version = long.Parse(idParameters[1]);

                return new QuestionnaireIdentity(questionnaireId, version);
            }
            catch (Exception e)
            {
                throw new FormatException($"id value '{id}' is not in the correct format.", e);
            }
        }
    }
}