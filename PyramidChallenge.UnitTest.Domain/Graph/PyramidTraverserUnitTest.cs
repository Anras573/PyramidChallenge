using PyramidChallenge.Domain.Acquaintances;
using PyramidChallenge.Domain.Graphs;
using PyramidChallenge.Domain.Models.Graphs;
using PyramidChallenge.Domain.Models.Node;
using System.Collections.Generic;
using Xunit;

namespace PyramidChallenge.UnitTest.Domain.Graph
{
    public class PyramidTraverserUnitTest
    {
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(4)]
        [InlineData(8)]
        [InlineData(16)]
        public void GivenSingleNodePyramid_WhenTraversingPyramid_ThenSingleNodeValueIsReturnedAsPathAndDistance(int input)
        {
            // Arrange
            var pyramid = new BinaryNode(input);

            ITraverser sut = new PyramidTraverser();

            // Act
            var route = sut.Traverse(pyramid);

            // Assert
            var expected = new PyramidTraverserResult(Distance.Create(input), new List<NodeValue> { NodeValue.Create(input) });
            Assert.Equal(expected.Distance, route.Distance);
            Assert.Equal(expected.Route, route.Route);
        }

        [Fact]
        public void GivenPyramidWithMultiplePaths_WhenTraversingPyramid_ThenLongestDistanceIsReturnedWithThePathTaken()
        {
            // Arrange
            var pyramid = new BinaryNode(1)
            {
                Left = new BinaryNode(8)
                {
                    Left = new BinaryNode(1)
                    {
                        Left = new BinaryNode(4),
                        Right = new BinaryNode(5)
                    },
                    Right = new BinaryNode(5)
                    {
                        Left = new BinaryNode(5),
                        Right = new BinaryNode(2)
                    }
                },
                Right = new BinaryNode(9)
                {
                    Left = new BinaryNode(5)
                    {
                        Left = new BinaryNode(5),
                        Right = new BinaryNode(2)
                    },
                    Right = new BinaryNode(9)
                    {
                        Left = new BinaryNode(2),
                        Right = new BinaryNode(3)
                    }
                }
            };

            ITraverser sut = new PyramidTraverser();

            // Act
            var route = sut.Traverse(pyramid);

            // Assert
            var expected = new PyramidTraverserResult(
                distance: Distance.Create(16),
                route: new List<NodeValue>
                {
                    NodeValue.Create(1),
                    NodeValue.Create(8),
                    NodeValue.Create(5),
                    NodeValue.Create(2)
                });

            Assert.Equal(expected.Distance, route.Distance);
            Assert.Equal(expected.Route, route.Route);
        }

        [Fact]
        public void GivenPyramidWithRouteLeft_WhenTraversingPyramid_ThenLongestDistanceIsReturnedWithThePathTaken()
        {
            // Arrange
            var pyramid = new BinaryNode(1)
            {
                Left = new BinaryNode(2)
                {
                    Left = new BinaryNode(3),
                    Right = new BinaryNode(1)
                },
                Right = new BinaryNode(1)
                {
                    Left = new BinaryNode(1),
                    Right = new BinaryNode(1)
                }
            };

            ITraverser sut = new PyramidTraverser();

            // Act
            var route = sut.Traverse(pyramid);

            // Assert
            var expected = new PyramidTraverserResult(
                distance: Distance.Create(6),
                route: new List<NodeValue>
                {
                    NodeValue.Create(1),
                    NodeValue.Create(2),
                    NodeValue.Create(3)
                });

            Assert.Equal(expected.Distance, route.Distance);
            Assert.Equal(expected.Route, route.Route);
        }

        [Fact]
        public void GivenPyramidWithRouteRight_WhenTraversingPyramid_ThenLongestDistanceIsReturnedWithThePathTaken()
        {
            // Arrange
            var pyramid = new BinaryNode(1)
            {
                Left = new BinaryNode(1)
                {
                    Left = new BinaryNode(1),
                    Right = new BinaryNode(1)
                },
                Right = new BinaryNode(2)
                {
                    Left = new BinaryNode(1),
                    Right = new BinaryNode(3)
                }
            };

            ITraverser sut = new PyramidTraverser();

            // Act
            var route = sut.Traverse(pyramid);

            // Assert
            var expected = new PyramidTraverserResult(
                distance: Distance.Create(6),
                route: new List<NodeValue>
                {
                    NodeValue.Create(1),
                    NodeValue.Create(2),
                    NodeValue.Create(3)
                });

            Assert.Equal(expected.Distance, route.Distance);
            Assert.Equal(expected.Route, route.Route);
        }

        [Fact]
        public void GivenPyramidWithRouteMiddle_WhenTraversingPyramid_ThenLongestDistanceIsReturnedWithThePathTaken()
        {
            // Arrange
            var pyramid = new BinaryNode(1)
            {
                Left = new BinaryNode(1)
                {
                    Left = new BinaryNode(1)
                    {
                        Left = new BinaryNode(1),
                        Right = new BinaryNode(1)
                    },
                    Right = new BinaryNode(1)
                    {
                        Left = new BinaryNode(1),
                        Right = new BinaryNode(1)
                    }
                },
                Right = new BinaryNode(2)
                {
                    Left = new BinaryNode(3)
                    {
                        Left = new BinaryNode(1),
                        Right = new BinaryNode(4)
                    },
                    Right = new BinaryNode(1)
                    {
                        Left = new BinaryNode(1),
                        Right = new BinaryNode(1)
                    }
                }
            };

            ITraverser sut = new PyramidTraverser();

            // Act
            var route = sut.Traverse(pyramid);

            // Assert
            var expected = new PyramidTraverserResult(
                distance: Distance.Create(10),
                route: new List<NodeValue>
                {
                    NodeValue.Create(1),
                    NodeValue.Create(2),
                    NodeValue.Create(3),
                    NodeValue.Create(4)
                });

            Assert.Equal(expected.Distance, route.Distance);
            Assert.Equal(expected.Route, route.Route);
        }

        [Fact]
        public void GivenPyramidWithLongestRouteNotToTheBottom_WhenTraversingPyramid_ThenLongestDistanceToBottomIsReturnedWithThePathTaken()
        {
            // Arrange
            var pyramid = new BinaryNode(1)
            {
                Left = new BinaryNode(2000)
                {
                    Left = new BinaryNode(2)
                    {
                        Left = new BinaryNode(3),
                        Right = new BinaryNode(2)
                    },
                    Right = new BinaryNode(2)
                    {
                        Left = new BinaryNode(4),
                        Right = new BinaryNode(3)
                    }
                },
                Right = new BinaryNode(2)
                {
                    Left = new BinaryNode(1)
                    {
                        Left = new BinaryNode(5),
                        Right = new BinaryNode(4)
                    },
                    Right = new BinaryNode(2)
                    {
                        Left = new BinaryNode(4),
                        Right = new BinaryNode(3)
                    }
                }
            };

            ITraverser sut = new PyramidTraverser();

            // Act
            var route = sut.Traverse(pyramid);

            // Assert
            var expected = new PyramidTraverserResult(
                distance: Distance.Create(8),
                route: new List<NodeValue>
                {
                    NodeValue.Create(1),
                    NodeValue.Create(2),
                    NodeValue.Create(1),
                    NodeValue.Create(4)
                });

            Assert.Equal(expected.Distance, route.Distance);
            Assert.Equal(expected.Route, route.Route);
        }
    }
}
