using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace StolenTests
{
    public class NumberHelperTests
    {
        /*
         * This section contains a very basic test example
         * The test in this document should be re-written, as it does not represent best practices
         */

        private readonly INumberHelper _uut;

        /// <summary>
        /// Not sure if the order of the returned numbers are relevant.
        /// Could have written more tests but I'm not spending that long writing tests for this.
        /// </summary>
        public NumberHelperTests()
        {
            _uut = new NumberHelper();
        }

        #region FindClosestNumbers - Testcases from specification

        [Theory]
        [InlineData(1, new[] { 1, 2, 3 }, 1, new[] { 1 })]
        [InlineData(6, new[] { 4, 5 }, 1, new[] { 5 })]
        [InlineData(12, new[] { 2, 3, 10 }, 2, new[] { 10, 3 })]
        [InlineData(4, new[] { 3, 5 }, 1, new[] { 3 })]
        public void FindClosestNumbers_BaseSpecifications_ReturnsCorrect(int needle, IEnumerable<int> haystack, int n, IEnumerable<int> expected)
        {
            // Arrange
            // Done with InlineData

            // Act
            var result = _uut.FindClosestNumbers(needle, haystack, n);

            // Assert
            Assert.Equal(result, expected);
        }

        #endregion

        #region FindClosestNumbers - Testing correct value of Count with n=1

        [Theory]
        [InlineData(1, new[] { 1, 2, 3 })]
        [InlineData(0, new[] { -1, 0, 1 })]
        [InlineData(-3, new[] { -1, -2, -3 })]
        public void FindClosestNumbers_NeedleInHaystackAndNEquals1_ReturnsCountEqual1(int needle, IEnumerable<int> haystack)
        {
            // Arrange
            // Done with InlineData

            // Act
            var result = _uut.FindClosestNumbers(needle, haystack, 1);

            // Assert
            Assert.Equal(result.Count(), 1);
        }

        [Theory]
        [InlineData(4, new[] { 1, 2, 3 })]
        [InlineData(2, new[] { -1, 0, 1 })]
        [InlineData(-4, new[] { -1, -2, -3 })]
        public void FindClosestNumbers_NeedleNotInHaystackAndNEquals1_ReturnsCountEqual1(int needle, IEnumerable<int> haystack)
        {
            // Arrange
            // Done with InlineData

            // Act
            var result = _uut.FindClosestNumbers(needle, haystack, 1);

            // Assert
            Assert.Equal(result.Count(), 1);
        }

        #endregion

        #region FindClosestNumbers - Testing correct value of Count with different n's

        [Theory]
        [InlineData(-1)] // would need testing, not sure what the expected result should be...
        [InlineData(0)]
        [InlineData(2)]
        public void FindClosestNumbers_ArrayWithOneElementAndNDifferentFrom1_ReturnsCountEqual1(int n)
        {
            // Arrange
            // Done with InlineData
            var haystack = new[] { 1 };

            // Act
            var result = _uut.FindClosestNumbers(1, haystack, n);

            // Assert
            Assert.Equal(result.Count(), 1);
        }

        [Theory]
        [InlineData(5, new[] { 3, 7, 10 }, new[] { 3, 7 })]
        [InlineData(-5, new[] { -2, -8, 9 }, new[] { -2, -8 })]
        [InlineData(0, new[] { -5, 5, 8 }, new[] { -5, 5 })]
        public void FindClosestNumbers_2NumbersWithEqualDistance_ReturnsCorrectCount(int needle, IEnumerable<int> haystack, int expected)
        {
            // Arrange
            // Done with InlineData

            // Act
            var result = _uut.FindClosestNumbers(needle, haystack, 2);

            // Assert
            Assert.Equal(result.Count(), expected);
        }

        [Theory]
        [InlineData(1, new[] { 0, 2 }, new[] { 0 })]
        [InlineData(10, new[] { 12, 8, 2 }, new[] { 8 })]
        [InlineData(0, new[] { -5, 5 }, new[] { -5 })]
        public void FindClosestNumbers_2NumbersWithEqualDistanceAndNEqual1_ReturnsCorrectNumber(int needle, IEnumerable<int> haystack, IEnumerable<int> expected)
        {
            // Arrange
            // Done with InlineData

            // Act
            var result = _uut.FindClosestNumbers(needle, haystack, 1);

            // Assert
            Assert.Equal(result, expected);
        }

        #endregion

        #region FindClosestNumbers - Testing with needle being higher and lower than numbers

        [Theory]
        [InlineData(new[] { 1, 2, 3 }, new[] { 3, 2 })]
        [InlineData(new[] { -1, 5, 8 }, new[] { 8, 5 })]
        [InlineData(new[] { -10, -9, 3 }, new[] { 3, -9 })]
        public void FindClosestNumbers_NeedleHigherThanOtherNumbers_ReturnsCorrectNumbers(IEnumerable<int> haystack, IEnumerable<int> expected)
        {
            // Arrange
            // Done with InlineData

            // Act
            var result = _uut.FindClosestNumbers(10, haystack, 2);

            // Assert
            Assert.Equal(result, expected);
        }

        [Theory]
        [InlineData(new[] { 1, 2, 3 }, new[] { 1, 2 })]
        [InlineData(new[] { -1, 5, 8 }, new[] { -1, 5 })]
        [InlineData(new[] { -10, -9, 3 }, new[] { -10, -9 })]
        public void FindClosestNumbers_NeedleLowerThanOtherNumbers_ReturnsCorrectNumbers(IEnumerable<int> haystack, IEnumerable<int> expected)
        {
            // Arrange
            // Done with InlineData

            // Act
            var result = _uut.FindClosestNumbers(-10, haystack, 2);

            // Assert
            Assert.Equal(result, expected);
        }

        #endregion
    }
}
