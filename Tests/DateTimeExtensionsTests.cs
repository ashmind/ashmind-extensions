using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// ReSharper disable PossibleNullReferenceException

namespace AshMind.Extensions.Tests {
    public class DateTimeExtensionsTests {
        [Fact]
        public void TruncateToMilliseconds_ReturnsSameTimeTruncatedToMilliseconds_ForDateTimeOffset() {
            var date = new DateTimeOffset(2000, 10, 10, 10, 10, 10, 10, TimeSpan.FromHours(10));
            Assert.Equal(date, date.AddMilliseconds(0.3).TruncateToMilliseconds());
        }

        [Fact]
        public void TruncateToSeconds_ReturnsSameTimeTruncatedToSeconds_ForDateTimeOffset() {
            var date = new DateTimeOffset(2000, 10, 10, 10, 10, 10, TimeSpan.FromHours(10));
            Assert.Equal(date, date.AddSeconds(0.55).TruncateToSeconds());
        }

        [Fact]
        public void TruncateToMinutes_ReturnsSameTimeTruncatedToMinutes_ForDateTimeOffset() {
            var date = new DateTimeOffset(2000, 10, 10, 10, 10, 0, TimeSpan.FromHours(10));
            Assert.Equal(date, date.AddSeconds(35.5).TruncateToMinutes());
        }

        [Fact]
        public void TruncateToHours_ReturnsSameTimeTruncatedToHours_ForDateTimeOffset() {
            var date = new DateTimeOffset(2000, 10, 10, 10, 0, 0, TimeSpan.FromHours(10));
            Assert.Equal(date, date.AddMinutes(35.55).TruncateToHours());
        }

        [Fact]
        public void TruncateToMilliseconds_ReturnsSameTimeTruncatedToMilliseconds_ForDateTime() {
            var date = new DateTime(2000, 10, 10, 10, 10, 10, 10);
            Assert.Equal(date, date.AddMilliseconds(0.3).TruncateToMilliseconds());
        }

        [Fact]
        public void TruncateToSeconds_ReturnsSameTimeTruncatedToSeconds_ForDateTime() {
            var date = new DateTime(2000, 10, 10, 10, 10, 10);
            Assert.Equal(date, date.AddSeconds(0.55).TruncateToSeconds());
        }

        [Fact]
        public void TruncateToMinutes_ReturnsSameTimeTruncatedToMinutes_ForDateTime() {
            var date = new DateTime(2000, 10, 10, 10, 10, 0);
            Assert.Equal(date, date.AddSeconds(35.5).TruncateToMinutes());
        }

        [Fact]
        public void TruncateToHours_ReturnsSameTimeTruncatedToHours_ForDateTime() {
            var date = new DateTime(2000, 10, 10, 10, 0, 0);
            Assert.Equal(date, date.AddMinutes(35.55).TruncateToHours());
        }
    }
}