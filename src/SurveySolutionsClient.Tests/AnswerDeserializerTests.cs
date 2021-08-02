using System;
using System.Collections.Generic;
using System.Text.Json;
using NUnit.Framework;
using SurveySolutionsClient.Models;

namespace SurveySolutionsClient.Tests
{
    public class AnswerDeserializerTests
    {
        [TestCaseSource(nameof(TestCases))]
        public object should_be_able_to_deserialize_answer(string json)
        {
            var deserialized = JsonSerializer.Deserialize<Answer>(json);
            return deserialized.Value;
        }

        [Test]
        public void should_be_able_to_deserialize_multiple_choice()
        {
            string json = @"{ ""CheckedValues"": [1,10]}";
            var deserialized = JsonSerializer.Deserialize<Answer>(json);
            Assert.That(deserialized.CheckedValues, Is.EquivalentTo(new[] {1, 10}));
        }

        [Test]
        public void should_be_able_to_deserialize_yes_no()
        {
            string json = @"{
        ""CheckedOptions"": [
            {
                ""Value"": 1,
                ""Yes"": true,
                ""No"": false
            }
            ]
        }";
            var deserialized = JsonSerializer.Deserialize<Answer>(json);
            Assert.That(deserialized.CheckedOptions, Is.EquivalentTo(new[]
            {
                new YesNoAnswer
                {
                    Value = 1,
                    Yes = true,
                    No = false
                }
            }));
        }

        static IEnumerable<TestCaseData> TestCases
        {
            get
            {
                yield return new TestCaseData(@"{ ""Value"": ""test answer"" }").SetName("text question")
                    .Returns("test answer");
                yield return new TestCaseData(@"{ ""Value"": 1 }").SetName("numeric question")
                    .Returns(1);
                yield return new TestCaseData(@"{ ""Value"": ""2021-05-12T00:00:00"" }").SetName("date time question")
                    .Returns(new DateTime(2021, 05, 12));
                yield return new TestCaseData(@"{
        ""Value"": {
                ""Latitude"": 49.995061,
                ""Longitude"": 36.2375366,
                ""Accuracy"": 0,
                ""Altitude"": 0,
                ""Timestamp"": ""1970-01-01T00:00:00+00:00""
            }
        }").SetName("Gps question").Returns(new GeoPosition
                {
                    Latitude = 49.995061,
                    Longitude = 36.2375366,
                    Timestamp = new DateTimeOffset(1970, 01, 01, 0, 0, 0, TimeSpan.Zero)
                });
            }
        }
    }
}