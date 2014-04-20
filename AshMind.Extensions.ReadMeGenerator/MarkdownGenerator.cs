using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
//using ClariusLabs.NuDoc;
using JetBrains.Annotations;

namespace AshMind.Extensions.ReadMeGenerator {
    public class MarkdownGenerator {
        [NotNull]
        private readonly IReadOnlyDictionary<Type, string> CSharpTypeNames = new Dictionary<Type, string> {
            { typeof(void),   "void" },
            { typeof(int),    "int"  },
            { typeof(bool),   "bool" },
            { typeof(char),   "char" },
            { typeof(object), "object" },
            { typeof(string), "string" }
        };

        public void WriteTo([NotNull] TextWriter writer) {
            var extensionsAssembly = typeof(EnumerableExtensions).Assembly;
            var extensionTypes = extensionsAssembly.GetExportedTypes();
            //var docMap = MapAssemblyDocs(extensionsAssembly);

            foreach (var type in extensionTypes.OrderBy(t => t.Name)) {
                writer.Write("## ");
                if (type.IsDefined<ObsoleteAttribute>(false))
                    writer.Write("[Obsolete] ");

                writer.WriteLine(type.Name);
                writer.WriteLine();

                var methods = type.GetMethods(BindingFlags.Static | BindingFlags.Public);
                foreach (var method in methods.OrderBy(m => m.Name)) {
                    writer.Write("    ");
                    WriteMethod(writer, method);
                    writer.WriteLine();
                    writer.WriteLine();

                    //var methodDoc = docMap.GetValueOrDefault(method);
                    //if (methodDoc != null)
                    //    WriteMethodDoc(writer, methodDoc);
                }

                writer.WriteLine();
            }
        }

        private void WriteMethod([NotNull] TextWriter writer, [NotNull] MethodInfo method) {
            if (method.IsDefined<ObsoleteAttribute>(false))
                writer.Write("[Obsolete] ");

            WriteType(writer, method.ReturnType);
            writer.Write(" {0}", method.Name);
            if (method.IsGenericMethod)
                WriteGenericParameters(writer, method.GetGenericArguments());

            writer.Write("(");
            var first = true;
            foreach (var parameter in method.GetParameters()) {
                if (first) {
                    if (method.IsDefined<ExtensionAttribute>(false))
                        writer.Write("this ");
                }
                else {
                    writer.Write(", ");
                }

                WriteType(writer, parameter.ParameterType);
                writer.Write(" ");
                writer.Write(parameter.Name);
                first = false;
            }
            writer.Write(")");
        }

        private void WriteType([NotNull] TextWriter writer, [NotNull] Type type) {
            var csharpName = CSharpTypeNames.GetValueOrDefault(type);
            if (csharpName != null) {
                writer.Write(csharpName);
                return;
            }

            writer.Write(type.Name.SubstringBefore("`"));
            if (type.IsGenericType)
                WriteGenericParameters(writer, type.GetGenericArguments());
        }

        private void WriteGenericParameters([NotNull] TextWriter writer, [NotNull] Type[] typeParameters) {
            writer.Write("<");
            var first = true;
            foreach (var type in typeParameters) {
                if (!first)
                    writer.Write(", ");

                WriteType(writer, type);
                first = false;
            }
            writer.Write(">");
        }

        //private void WriteMethodDoc([NotNull] TextWriter writer, [NotNull] Member methodDoc) {
        //    var summary = methodDoc.Elements.OfType<Summary>().FirstOrDefault();
        //    if (summary == null)
        //        return;

        //    writer.WriteLine(summary.ToText());
        //}

        //[NotNull]
        //private static IReadOnlyDictionary<MemberInfo, Member> MapAssemblyDocs([NotNull] Assembly extensionsAssembly) {
        //    var docs = DocReader.Read(extensionsAssembly);
        //    var docMap = new Dictionary<MemberInfo, Member>();
        //    docs.Accept(new DelegateVisitor(new VisitorDelegates {
        //        VisitClass = c => docMap[c.Info] = c,
        //        VisitMethod = m => docMap[m.Info] = m
        //    }));
        //    return docMap;
        //}
    }
}
