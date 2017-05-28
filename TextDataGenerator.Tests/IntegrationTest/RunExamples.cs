using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace TextDataGenerator.Tests.IntegrationTest
{
    [TestClass]
    public class RunExamples
    {
        [TestMethod]
        public void Example1()
        {
            TestExample("example1.txt");
        }

        private static void TestExample(string fileName)
        {
            var pathFile = Path.Combine(@"rsc\Example", fileName);
            var stream = new StringWriter();
            Console.SetOut(stream);
            Program.Main(new[] { pathFile });
            var result = stream.ToString();
            var expected = File.ReadAllText(Path.Combine(@"rsc\Expected", fileName));
            //File.WriteAllText(fileName, expected);
            Assert.AreEqual(expected, result);
        }
    }
}
