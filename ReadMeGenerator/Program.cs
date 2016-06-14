using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace AshMind.Extensions.ReadMeGenerator {
    public static class Program {
        public static void Main(string[] args) {
            try {
                var readmePath = FindPathToReadMe();
                using (var writer = new StreamWriter(readmePath)) {
                    new MarkdownGenerator().WriteTo(writer);
                }
            }
            catch (Exception ex) {
                FluentConsole.Red.Text(ex);
            }
        }

        private static string FindPathToReadMe() {
            var initialDirectory = new FileInfo(Assembly.GetExecutingAssembly().Location).Directory;

            var directory = initialDirectory;
            while (!directory.EnumerateFiles("*.sln").Any()) {
                directory = directory.Parent;
                if (directory == null)
                    throw new Exception("Could not find solution folder for path '" + initialDirectory.FullName + "'.");
            }

            return Path.Combine(directory.FullName, "README.md");
        }
    }
}
