using System;
using System.Reflection;
using Xunit;

namespace AshMind.Extensions.Tests {
    public class ReflectionExtensionsTests {
        #region Test Classes
        public interface IInterface {}
        public interface ISubInterface : IInterface { }
        public class ClassWithInterface : IInterface {}
        public class SubclassOfClassWithInterface : ClassWithInterface { }
        public class ClassWithSubInterface : ISubInterface { }
        public class ClassWithoutInterface {}
        #endregion

        [Theory]
        [InlineData(typeof(ClassWithInterface), true)]
        [InlineData(typeof(SubclassOfClassWithInterface), true)]
        [InlineData(typeof(ClassWithSubInterface), true)]
        [InlineData(typeof(ISubInterface), true)]
        [InlineData(typeof(IInterface), false)]
        [InlineData(typeof(ClassWithoutInterface), false)]
        public void HasInterface(Type type, bool expectedResult) {
            Assert.Equal(expectedResult, type.GetTypeInfo().HasInterface<IInterface>());
        }
    }
}
