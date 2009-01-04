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
        public void TestOtherwiseOutOfRangeThrowsCorrectException() {
            var exception = Assert.Throws<ArgumentOutOfRangeException>(
                () => Switch.Type(new Sgml())
                            .Case<Xml>(x => {})
                            .OtherwiseOutOfRange("test")
            );

            Assert.AreEqual("test", exception.ParamName);
        }

        [Test]
        public void TestCaseNull() {
            var result = Switch.Type((Sgml)null).To<bool>()
                               .CaseNull(true)
                               .Otherwise(false)
                               .Result;

            Assert.IsTrue(result);
        }
    }
}
