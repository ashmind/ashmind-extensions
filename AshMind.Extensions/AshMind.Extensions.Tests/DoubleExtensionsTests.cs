using System;
using System.Collections.Generic;
using System.Linq;
using MbUnit.Framework;

namespace AshMind.Extensions.Tests {
    [TestFixture]
    public class DoubleExtensionsTests {
        [Test]
        [Row(0)]
        [Row(Double.NaN)]
        public void TestIsNaNIsEqualToDoubleIsNaN(double value) {
            AssertEx.That(
                () => value.IsNaN() == Double.IsNaN(value)
            );
        }

        [Test]
        [Row(0)]
        [Row(Double.PositiveInfinity)]
        [Row(Double.NegativeInfinity)]
        public void TestIsInfinityIsEqualToDoubleIsInfinity(double value) {
            AssertEx.That(
                () => value.IsInfinity() == Double.IsInfinity(value)
            );
        }

        [Test]
        [Row(0)]
        [Row(Double.PositiveInfinity)]
        [Row(Double.NegativeInfinity)]
        public void TestIsPositiveInfinityIsEqualToDoubleIsPositiveInfinity(double value) {
            AssertEx.That(
                () => value.IsPositiveInfinity() == Double.IsPositiveInfinity(value)
            );
        }

        [Test]
        [Row(0)]
        [Row(Double.PositiveInfinity)]
        [Row(Double.NegativeInfinity)]
        public void TestIsNegativeInfinityIsEqualToDoubleIsNegativeInfinity(double value) {
            AssertEx.That(
                () => value.IsNegativeInfinity() == Double.IsNegativeInfinity(value)
            );
        }
    }
}
