using PyramidChallenge.Domain.Models.Node;
using Xunit;

namespace PyramidChallenge.UnitTest.Domain.Models.Node
{
    public class BinaryNodeUnitTest
    {
        [Theory]
        [InlineData(2)]
        [InlineData(12)]
        [InlineData(1234)]
        public void GivenEvenValue_WhenAskingIsEven_ThenTrueIsReturned(int value)
        {
            // Arrange
            var node = new BinaryNode(value);

            // Act
            var isEven = node.Value.IsEven;

            // Assert
            Assert.True(isEven);
        }

        [Theory]
        [InlineData(3)]
        [InlineData(9)]
        [InlineData(4321)]
        public void GivenOddValue_WhenAskingIsEven_ThenFalseIsReturned(int value)
        {
            // Arrange
            var node = new BinaryNode(value);

            // Act
            var isEven = node.Value.IsEven;

            // Assert
            Assert.False(isEven);
        }

        [Theory]
        [InlineData(2)]
        [InlineData(12)]
        [InlineData(1234)]
        public void GivenEvenValue_WhenAskingIsOdd_ThenFalseIsReturned(int value)
        {
            // Arrange
            var node = new BinaryNode(value);

            // Act
            var isOdd = node.Value.IsOdd;

            // Assert
            Assert.False(isOdd);
        }

        [Theory]
        [InlineData(3)]
        [InlineData(9)]
        [InlineData(4321)]
        public void GivenOddValue_WhenAskingIsOdd_ThenTrueIsReturned(int value)
        {
            // Arrange
            var node = new BinaryNode(value);

            // Act
            var isOdd = node.Value.IsOdd;

            // Assert
            Assert.True(isOdd);
        }
    }
}
