using System;
using System.Linq;

using MbUnit.Framework;

using AshMind.Constructs.Tests.Hierarchy;

namespace AshMind.Constructs.Tests {
    [TestFixture]
    public class SwitchTest {
        [Test]
        public void TestCompileWorksCorrectlyWhenThereIsANullInOtherwise() {
            Switch.Type<Sgml>().To<string>()
                  .Case<Xml>("Xml")
                  .Otherwise((string)null)
                  .Compile();
        }

        [Test]
        public void TestOtherwiseThrowThrows() {
            Assert.Throws<ArgumentException>(
                () => Switch.Type(new Sgml())
                            .Case<Xml>(x => {})
                            .OtherwiseThrow<ArgumentException>()
            );
        }

        [Test]
        public void TestOtherwiseOutOfRangeThrowsCorrect() {
            var exception = Assert.Throws<ArgumentOutOfRangeException>(
                () => Switch.Type(new Sgml())
                            .Case<Xml>(x => {})
                            .OtherwiseOutOfRange("test")
            );

            Assert.AreEqual("test", exception.ParamName);
        }
    }
}
