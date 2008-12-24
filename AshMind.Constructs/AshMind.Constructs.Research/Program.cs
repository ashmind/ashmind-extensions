using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using AshMind.Constructs.Research.ObjectModel;
using System.Threading;

namespace AshMind.Constructs.Research
{
    public class Program
    {
        static void Main(string[] args)
        {
            XsltDocument xslt = new XsltDocument();
            TextDocument text = new TextDocument();

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Benchmark overhead:         ");
            Benchmark(xslt, text, d => "do nothing", false);
            Console.ResetColor();

            Console.Write("Direct cast:                ");
            Benchmark(xslt, text, TestCaseDirect);

            Console.WriteLine("Fluent switch");             
            Console.Write("    on lambdas:             ");
            Benchmark(xslt, text, TestCaseFluentLambdaSwitch);

            Console.Write("    on lambdas (compiled):  ");
            Benchmark(xslt, text, TestCaseCompiledFluentLambdaSwitch);

            Console.Write("    on constants:           ");
            Benchmark(xslt, text, TestCaseFluentConstantSwitch);

            Console.Write("    on constants (compiled):");
            Benchmark(xslt, text, TestCaseCompiledFluentConstantSwitch);

            Console.Write("Many overloads switch:      ");
            Benchmark(xslt, text, TestCaseOverloadedSwitch);

            Console.Write("Object initializer switch:  ");
            Benchmark(xslt, text, TestCaseObjectInitializerSwitch);

            Console.ReadKey();
        }

        private static bool Validate(XsltDocument d1, TextDocument d2, Func<Document, string> @switch)
        {
            string result = @switch(d1);
            if (result != "Xslt")
            {
                Console.WriteLine("fail ({0} != {1})", result, "Xslt");
                return false;
            }
            result = @switch(d2);
            if (result != "Not Xml and not Xslt")
            {
                Console.WriteLine("fail ({0} != {1})", result, "Not Xml and not Xslt");
                return false;
            }

            return true;
        }

        private static double BenchmarkRun(XsltDocument d1, TextDocument d2, Func<Document, string> @switch)
        {
            var start = DateTime.Now;
            for (int i = 0; i < 1000000; i++)
            {
                @switch(d1);
                @switch(d2);
            }
            return (DateTime.Now - start).TotalMilliseconds;            
        }

        private static void Benchmark(XsltDocument d1, TextDocument d2, Func<Document, string> @switch)
        {
            Benchmark(d1, d2, @switch, true);
        }

        private static void Benchmark(XsltDocument d1, TextDocument d2, Func<Document, string> @switch, bool validate)
        {
            if (validate && !Validate(d1, d2, @switch))
                return;

            var results = new double[4];
            for (int i = 0; i < results.Length; i++)
            {
                results[i] = BenchmarkRun(d1, d2, @switch);
                Console.Write("{0,7:f1}ms", results[i]);
                Thread.Sleep(100);
            }
            var average = results.Average();
            Console.WriteLine(" | {0,7:f1}ms", average);
        }

        static string TestCaseDirect(Document document)
        {
            var xslt = document as XsltDocument;
            if (xslt != null) {
                return "Xslt";
            }

            var xml = document as XmlDocument;
            if (xml != null) {
                return "Xml";
            }

            return "Not Xml and not Xslt";
        }

        static string TestCaseFluentLambdaSwitch(Document document)
        {
            return Switch.Type(document).
                Case(
                    (XsltDocument d) => "Xslt"
                ).
                Case(
                    (XmlDocument d) => "Xml"
                ).
                Otherwise(
                    d => "Not Xml and not Xslt"
                ).
                Result;
        }

        private static readonly Func<Document, string> CompiledFluentLambdaSwitch = Switch.Type<Document>().To<string>().
            Case(
                (XsltDocument d) => "Xslt"
            ).
            Case(
                (XmlDocument d) => "Xml"
            ).
            Otherwise(
                d => "Not Xml and not Xslt"
            ).
            ToExpression().
            Compile();
        static string TestCaseCompiledFluentLambdaSwitch(Document document)
        {
            return CompiledFluentLambdaSwitch(document);
        }

        static string TestCaseFluentConstantSwitch(Document document)
        {
            return Switch.Type(document).To<string>().
                Case<XsltDocument>("Xslt").
                Case<XmlDocument>("Xml").
                Otherwise("Not Xml and not Xslt").
                Result;
        }

        private static readonly Func<Document, string> CompiledFluentConstantSwitch = Switch.Type<Document>().To<string>().
                Case<XsltDocument>("Xslt").
                Case<XmlDocument>("Xml").
                Otherwise("Not Xml and not Xslt").
                ToExpression().
                Compile();
        private static string TestCaseCompiledFluentConstantSwitch(Document document)
        {
            return CompiledFluentConstantSwitch(document);
        }

        static string TestCaseOverloadedSwitch(Document document)
        {
            return Switch2.Type(
                document, 
                    (XsltDocument d) => "Xslt",
                    (XmlDocument d) => "Xml",
                    d => "Not Xml and not Xslt"
            );
        }

        static string TestCaseObjectInitializerSwitch(Document document)
        {
            return new TypeSwitch<Document, string>(document) {
                (XsltDocument d) => "Xslt",
                (XmlDocument d) => "Xml",
                d => "Not Xml and not Xslt"
            };
        }

    }
}
