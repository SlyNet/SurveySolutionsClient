using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json.Serialization;

namespace SurveySolutionsClient.Models
{
    [DebuggerDisplay("{" + nameof(ToString) + "()}")]
    public class RosterVector : IEnumerable<int>
    {
        private int? cachedHashCode;
        private readonly int[] coordinates;

        [JsonConstructor]
        public RosterVector(params int[] coordinates)
        {
            var asArray = coordinates;
            this.coordinates = asArray;
        }

        /// <inheritdoc />
        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;

            if (obj.GetType() == typeof(RosterVector))
                return this.Identical((RosterVector)obj);

            if (obj.GetType() == typeof(int[]))
                return this.coordinates.SequenceEqual((int[])obj);

            return false;
        }

        public static RosterVector Parse(string value)
        {
            value = value.Trim('_');

            if (string.IsNullOrWhiteSpace(value))
            {
                return new RosterVector(Array.Empty<int>());
            }

            return new RosterVector(ParseMinusDelimitedIntArray(value));
        }

        static int[] ParseMinusDelimitedIntArray(string? arrayString)
        {
            if (string.IsNullOrWhiteSpace(arrayString) || string.IsNullOrWhiteSpace(arrayString.Trim('_'))) 
                return Array.Empty<int>();

            //"-1-2--3".Split('-') => string[5] { "", "1", "2", "", "3" }
            // every empty space mean that we encounter negative number
            var items = arrayString.Split('-');
            var result = new List<int>();

            for (int i = 0; i < items.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(items[i]))
                {
                    if (i == items.Length - 1) // if this is last item in array
                        continue;

                    // parse next item and increment index
                    result.Add(-int.Parse(items[++i]));
                }
                else
                    result.Add(int.Parse(items[i]));
            }

            return result.ToArray();
        }

        public override int GetHashCode()
        {
            if (!this.cachedHashCode.HasValue)
            {
                var hc = this.coordinates.Length;

                for (var i = 0; i < this.coordinates.Length; i++)
                {
                    var hashCode = this.coordinates[i].GetHashCode();
                    hc = unchecked(hc * 13 + hashCode);
                }

                this.cachedHashCode = hc;
            }

            return this.cachedHashCode.Value;
        }

        public static bool operator ==(RosterVector? a, RosterVector? b)
            => ReferenceEquals(a, b)
               || (a?.Equals(b) ?? false);

        public static bool operator !=(RosterVector? a, RosterVector? b)
            => !(a == b);

        /// <inheritdoc />
        public override string ToString()
        {
            if (this.coordinates.Length > 0)
                return $"_{String.Join("-", this.coordinates.Select(c => c))}";
            return string.Empty;
        }

        public int Length => this.coordinates.Length;

        public bool Identical(RosterVector other)
        {
            if (other == null) return false;

            if (this.Length == 0 && other.Length == 0 || ReferenceEquals(this, other))
                return true;

            if (this.Length != other.Length)
                return false;

            return this.coordinates.SequenceEqual(other.coordinates);
        }

        IEnumerator<int> IEnumerable<int>.GetEnumerator() => ((IEnumerable<int>)this.coordinates).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => this.coordinates.GetEnumerator();
    }
}