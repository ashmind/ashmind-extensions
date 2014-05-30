using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;

namespace AshMind.Extensions.ReadMeGenerator {
    public class MarkdownGenerator {
        public void WriteTo([NotNull] TextWriter writer) {
            var extensionsAssembly = typeof(EnumerableExtensions).Assembly;
            var extensionTypes = extensionsAssembly.GetExportedTypes();

            foreach (var type in extensionTypes.OrderBy(t => t.Name)) {
                writer.Write("## ");
                if (type.IsDefined<ObsoleteAttribute>(false))
                    continue;

                writer.Write(type.Name);
                writer.WriteLine();

                var methodNames = type.GetMethods(BindingFlags.Static | BindingFlags.Public)
                                      .Where(m => !m.IsDefined<ObsoleteAttribute>(false))
                                      .Select(m => m.Name)
                                      .Distinct()
                                      .OrderBy(n => n);

                var index = 1;
                foreach (var methodName in methodNames) {
                    writer.Write("  {0,2}. {1}", index, methodName);
                    writer.WriteLine();
                    index += 1;
                }

                writer.WriteLine();
            }
        }
    }
}
