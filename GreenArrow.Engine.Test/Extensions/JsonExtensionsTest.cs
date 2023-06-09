﻿using GreenArrow.Engine.Extensions;
using GreenArrow.Engine.HttpSubmissionApi;

namespace GreenArrow.Engine.Test.Extensions
{
    public class JsonExtensionsTest
    {
        [Fact]
        public void ToJson_should_serialize_in_snake_case()
        {
            // Arrange
            var objectToSerialize = new
            {
                ThisIsAProperty = "this is a property",
            };

            // Act
            var json = objectToSerialize.ToJson();

            // Assert
            Assert.Contains("this_is_a_property", json);
        }

        [Fact]
        public void ToJson_should_ignore_properties_with_null_value()
        {
            // Arrange
            var objectToSerialize = new HttpSubmissionRequest
            {
                Username = "username",
                Password = "password",
                Message = null,
                Messages = null,
            };

            // Act
            var json = objectToSerialize.ToJson();

            // Assert
            Assert.DoesNotContain("message", json);
        }

        /// <summary>
        /// Should deserialize HttpSubmissionResponse examples included in the documentation
        /// </summary>
        /// <see href="https://www.greenarrowemail.com/docs/greenarrow-engine/API-V3/HTTP-Submission-API"/>
        /// <param name="json">json examples</param>
        [InlineData("""{ "success":0, "error": "incorrect username/password"}""")]
        [InlineData("""
            {
                    "success":1,
                    "messages":[
                            {
                                    "success":1,
                                    "message_id":"mid-90df674d4c98c1aa647eaca724086ef0@example.com",
                                    "attempted":1,
                                    "id":"1"
                            },
                            {
                                    "success":1,
                                    "message_id":"mid-e20664ffd71475b270b586889872e4f7@example.com",
                                    "attempted":1,
                                    "id":"2"
                            }
                    ]
            }
            """)]
        [InlineData("""
            {
                    "success":1,
                    "messages":[
                            {
                                    "success":1,
                                    "message_id":"mid-90df674d4c98c1aa647eaca724086ef0@example.com",
                                    "attempted":1,
                                    "id":"1"
                            },
                            {
                                    "success":0,
                                    "error":"internal error: unable to make socket connection (Connection refused)",
                                    "attempted":1,
                                    "id":"2"
                            },
                            {
                                    "success":0,
                                    "error":"not attempting due to previous internal errors",
                                    "attempted":0,
                                    "id":"3"
                            }
                    ]
            }
            """)]
        [Theory]
        public void ToObject_should_deserialize_HttpSubmissionResponse_examples(string json)
        {
            // Arrange

            // Act
            var result = json.ToObject<HttpSubmissionResponse>();

            // Assert
            Assert.NotNull(result);
        }
    }
}
