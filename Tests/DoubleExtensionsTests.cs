using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Extensions;

namespace AshMind.Extensions.Tests {
    public class DoubleExtensionsTests {
        [Theory]
        [InlineData(0)]
        [InlineData(Double.NaN)]
        public void IsNaN_IsEqualTo_Double_IsNaN(double value) {
            Assert.Equal(value.IsNaN(), Double.IsNaN(value));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(Double.PositiveInfinity)]
        [InlineData(Double.NegativeInfinity)]
        public void IsInfinity_IsEqual_ToDoubleIsInfinity(double value) {
            Assert.Equal(value.IsInfinity(), Double.IsInfinity(value));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(Double.PositiveInfinity)]
        [InlineData(Double.NegativeInfinity)]
        public void IsPositiveInfinity_IsEqual_ToDoubleIsPositiveInfinity(double value) {
            Assert.Equal(value.IsPositiveInfinity(), Double.IsPositiveInfinity(value));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(Double.PositiveInfinity)]
        [InlineData(Double.NegativeInfinity)]
        public void IsNegativeInfinity_IsEqual_ToDoubleIsNegativeInfinity(double value) {
            Assert.Equal(value.IsNegativeInfinity(), Double.IsNegativeInfinity(value));
        }
    }
}
