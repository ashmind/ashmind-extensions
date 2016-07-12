using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;

namespace AshMind.Extensions.ReadMeGenerator {
    public class MarkdownGenerator {
        public void WriteTo([NotNull] TextWriter writer) {
            writer.WriteLine("[![Build status](https://ci.appveyor.com/api/projects/status/jg5841626qcwpc6b)](https://ci.appveyor.com/project/ashmind/ashmind-extensions)");
            writer.WriteLine();
            writer.WriteLine("A set of very conservative extension methods — most of those closely follow common naming and implementation patterns in the .NET framework. You can get it from NuGet as [AshMind.Extensions](https://www.nuget.org/packages/AshMind.Extensions/).");
            writer.WriteLine("");
            writer.WriteLine("Below is an auto-generated list of the methods provided:");

            var extensionsAssembly = typeof(EnumerableExtensions).GetTypeInfo().Assembly;
            var extensionTypes = extensionsAssembly.GetExportedTypes();

            foreach (var type in extensionTypes.OrderBy(t => t.Name)) {
                if (type.GetTypeInfo().IsDefined(typeof(ObsoleteAttribute)))
                    continue;

                writer.WriteLine("### {0}", type.Name.RemoveEnd("Extensions"));

                var methodNames = type.GetMethods(BindingFlags.Static | BindingFlags.Public)
                                      .Where(m => !m.IsDefined(typeof(ObsoleteAttribute)))
                                      .Select(m => m.Name)
                                      .Distinct()
                                      .OrderBy(n => n);

                var index = 1;
                foreach (var methodName in methodNames) {
                    writer.Write("  {0}. {1}", index, methodName);
                    writer.WriteLine();
                    index += 1;
                }

                writer.WriteLine();
            }
        }
    }
}
