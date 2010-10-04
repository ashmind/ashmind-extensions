using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

using Microsoft.Pex.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using MbUnit.Framework;

using AshMind.Extensions;
using AshMind.Net.Caching.Http;

using Assert = MbUnit.Framework.Assert;

namespace AshMind.Net.Tests.Of.Caching {
    [TestClass]
    [TestFixture]
    [PexClass(typeof(CacheControl))]
    public partial class CacheControlTest {
        [PexMethod]
        [PexArguments("max-age=15")]
        [PexArguments("s-maxage=15, max-age=15")]
        [PexArguments("s-maxage=15, private=\"field1, field2\", max-age=15")]
        public void TestParseCorrectlyParsesMaxAge(string value) {
            TestParseWorksCorrectlyWithTimeIn("max-age", value, c => c.MaxAge);
        }

        [PexMethod]
        [PexArguments("s-maxage=15")]
        [PexArguments("s-maxage=15, max-age=15")]
        [PexArguments("max-age=15, private=\"field1, field2\", s-maxage=15")]
        public void TestParseCorrectlyParsesSharedMaxAge(string value) {
            TestParseWorksCorrectlyWithTimeIn("s-maxage", value, c => c.SharedMaxAge);
        }

        [Test]
        [Row("no-cache", "")]
        [Row("max-age=15, private=\"field1, field2\", no-cache", "")]
        [Row("max-age=15, no-cache=\"field1, field2\"", "field1, field2")]
        public void TestParseCorrectlyParsesNoCache(string value, string fields) {
            var cacheControl = CacheControl.Parse(value);
            Assert.IsTrue(cacheControl.NoCache);
            Assert.AreElementsEqualIgnoringOrder(
                fields.Split(", ", StringSplitOptions.RemoveEmptyEntries),
                cacheControl.NoCacheHeaderNames
            );
        }

        private void TestParseWorksCorrectlyWithTimeIn(string field, string value, Func<CacheControl, TimeSpan?> getTime) {
            PexAssume.IsNotNull(value);
            PexAssume.IsFalse(value.Contains('\0'));

            var quotesValid = value.Count(c => c == '"') % 2 == 0;
            PexAssume.IsTrue(quotesValid);

            var cacheControl = CacheControl.Parse(value);
            var timeMatch = Regex.Match(value, @"(?:^|,)\s*" + field + @"\s*=\s*(\d+|-0)\s*(?:$|,)", RegexOptions.IgnoreCase);
            if (timeMatch.Success) {
                var seconds = int.Parse(timeMatch.Groups[1].Value);

                var time = getTime(cacheControl);
                PexAssert.IsNotNull(time);
                PexAssert.AreEqual(seconds, time.Value.TotalSeconds);
            }
            else {
                PexAssert.IsNull(getTime(cacheControl));
            }
        }
    }
}
