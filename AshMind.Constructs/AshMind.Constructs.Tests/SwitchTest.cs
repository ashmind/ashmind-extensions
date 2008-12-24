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
    }
}
