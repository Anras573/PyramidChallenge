using Newtonsoft.Json;
using PyramidChallenge.Domain.Models.Node;
using PyramidChallenge.Domain.Parsers;
using System.Collections.Generic;
using Xunit;

namespace PyramidChallenge.UnitTest.Domain.Parsers
{
    public class StringPyramidParserUnitTest
    {
        [Fact]
        public void GivenSingleLine_WhenParsingPyramid_ThenPyramidIsReturned()
        {
            // Arrange
            var lines = new List<string> { "12" };
            var sut = new StringPyramidParser();

            // Act
            var pyramid = sut.Parse(lines);

            // Assert
            var expected = new BinaryNode(12);
            Assert.Equal(expected, pyramid);
        }

        [Fact]
        public void GivenDoubleLines_WhenParsingPyramid_ThenPyramidIsReturned()
        {
            // Arrange
            var lines = new List<string> { "12", "23 34" };
            var sut = new StringPyramidParser();

            // Act
            var pyramid = sut.Parse(lines);

            // Assert
            var expected = new BinaryNode(12)
            {
                Left = new BinaryNode(23),
                Right = new BinaryNode(34)
            };

            Assert.Equal(expected, pyramid);
        }

        [Fact]
        public void GivenMultipleLines_WhenParsingPyramid_ThenPyramidIsReturned()
        {
            // Arrange
            var lines = new List<string> { "12", "23 34", "45 56 67", "78 89 100 111" };
            var sut = new StringPyramidParser();

            // Act
            var pyramid = sut.Parse(lines);

            // Assert
            var expected = new BinaryNode(12)
            {
                Left = new BinaryNode(23)
                { 
                    Left = new BinaryNode(45)
                    {
                        Left = new BinaryNode(78),
                        Right = new BinaryNode(89)
                    },
                    Right = new BinaryNode(56)
                    {
                        Left = new BinaryNode(89),
                        Right = new BinaryNode(100)
                    }
                },
                Right = new BinaryNode(34)
                {
                    Left = new BinaryNode(56)
                    {
                        Left = new BinaryNode(89),
                        Right = new BinaryNode(100)
                    },
                    Right = new BinaryNode(67)
                    {
                        Left = new BinaryNode(100),
                        Right = new BinaryNode(111)
                    }
                }
            };

            Assert.Equal(expected, pyramid);
        }
    }
}
