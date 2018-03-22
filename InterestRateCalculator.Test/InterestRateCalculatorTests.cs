using System;
using FluentAssertions;
using Xunit;

namespace InterestRateCalculator.Test
{
    public class InterestRateCalculatorTests
    {
        [Theory]
        [InlineData(0D)]
        [InlineData(-1D)]
        public void InitializeRate_WithIllegalValues_ThrowsException(double r)
        {
            // Act
            var exception = Record.Exception(() => new InterestRateCalculator(12, r));

            // Assert
            exception.Should().NotBeNull();
            exception.Should().BeOfType(typeof(ArgumentException));
            exception.Message.Should().Be("Illegal value for rate.");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void InitializeNumberOfPeriods_WithIllegalValues_ThrowsException(int numberPeriods)
        {
            // Act
            var exception = Record.Exception(() => new InterestRateCalculator(numberPeriods, 2));

            // Assert
            exception.Should().NotBeNull();
            exception.Should().BeOfType(typeof(ArgumentException));
            exception.Message.Should().Be("Illegal value for number periods.");
        }

        [Fact]
        public void Initialize_WithLegalValues_DoesNotThrowException()
        {
            // Arrange 
            var r = 2D;
            var numberPeriods = 12;

            // Act
            var exception = Record.Exception(() => new InterestRateCalculator(numberPeriods, r));

            // Assert
            exception.Should().BeNull();
        }

    }
}
