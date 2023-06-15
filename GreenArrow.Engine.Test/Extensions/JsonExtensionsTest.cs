using GreenArrow.Engine.Extensions;

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
    }
}
