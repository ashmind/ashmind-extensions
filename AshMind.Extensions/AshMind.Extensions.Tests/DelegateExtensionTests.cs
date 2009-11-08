using System;
using System.Collections.Generic;
using System.Linq;

using MbUnit.Framework;

namespace AshMind.Extensions.Tests {
    [TestFixture]
    public class DelegateExtensionTests {
        [Test]
        public void TestAsPredicate() {
            Func<string, bool> func = x => x == "test";
            var predicate = func.AsPredicate();

            Assert.AreSame(func.Target, predicate.Target);
            Assert.AreSame(func.Method, predicate.Method);
        }

        [Test]
        public void TestAsFunc() {
            Predicate<string> predicate = x => x == "test";
            var func = predicate.AsFunc();

            Assert.AreSame(predicate.Target, func.Target);
            Assert.AreSame(predicate.Method, func.Method);
        }
    }
}
