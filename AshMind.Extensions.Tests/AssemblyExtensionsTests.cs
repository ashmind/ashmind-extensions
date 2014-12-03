using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Xunit;

namespace AshMind.Extensions.Tests {
    public class AssemblyExtensionsTests {
        [Fact]
        public void GetAssemblyFile_ReturnsFileBasedOnAssemblyLocation() {
            var assembly = Assembly.GetExecutingAssembly();
            var file = assembly.GetAssemblyFile();

            Assert.Equal(assembly.Location, file.FullName);
        }
        
        [Fact]
        public void GetAssemblyFileFromCodeBase_ReturnsFileBasedOnAssemblyCodeBase() {
            var assembly = Assembly.GetExecutingAssembly();
            var file = assembly.GetAssemblyFileFromCodeBase();
            var url = new Uri(assembly.EscapedCodeBase);

            Assert.Equal(url.LocalPath, file.FullName);
        }
    }
}
