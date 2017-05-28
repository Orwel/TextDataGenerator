using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextDataGenerator.Parser;

namespace TextDataGenerator.Tests.Parser
{
    [TestClass]
    public class TagParserTest
    {
        public Tag ExecuteParseTag(string text)
        {
            var browseText = new BrowseText(text);
            var tagParser = new TagParser(browseText);
            return tagParser.ParseTag();
        }

        [TestMethod]
        public void ParseEmptyTag()
        {
            var result = ExecuteParseTag("@{}");
            Assert.AreEqual("", result.Type);
            Assert.AreEqual(0, result.Parameters.Count);
        }

        [TestMethod]
        public void ParseTagWithType()
        {
            var result = ExecuteParseTag("@{TagName}");
            Assert.AreEqual("TagName", result.Type);
            Assert.AreEqual(0, result.Parameters.Count);
        }

        [TestMethod]
        public void ParseTagWithTypeAndSomeBadSpace()
        {
            var result = ExecuteParseTag("@{ TagName  }");
            Assert.AreEqual("TagName", result.Type);
            Assert.AreEqual(0, result.Parameters.Count);
        }

        [TestMethod]
        public void ParseTagWithTypeAndParameter()
        {
            var result = ExecuteParseTag("@{TagName param1=val1 param2=val2 param3}");
            Assert.AreEqual("TagName", result.Type);
            Assert.AreEqual(3, result.Parameters.Count);
            Assert.IsTrue(result.Parameters.ContainsKey("param1"));
            Assert.AreEqual("val1", result.Parameters["param1"]);
            Assert.IsTrue(result.Parameters.ContainsKey("param2"));
            Assert.AreEqual("val2", result.Parameters["param2"]);
            Assert.IsTrue(result.Parameters.ContainsKey("param3"));
            Assert.AreEqual("", result.Parameters["param3"]);
        }

        [TestMethod]
        public void ParseTagWithTypeAndParameterAndSomeBadSpace()
        {
            var result = ExecuteParseTag("@{  TagName  param1  =  val1    param2  =  val2   param3  }");
            Assert.AreEqual("TagName", result.Type);
            Assert.AreEqual(3, result.Parameters.Count);
            Assert.IsTrue(result.Parameters.ContainsKey("param1"));
            Assert.AreEqual("val1", result.Parameters["param1"]);
            Assert.IsTrue(result.Parameters.ContainsKey("param2"));
            Assert.AreEqual("val2", result.Parameters["param2"]);
            Assert.IsTrue(result.Parameters.ContainsKey("param3"));
            Assert.AreEqual("", result.Parameters["param3"]);
        }

        [TestMethod]
        public void ParseTagWithTypeAndParameterAndValueBetweenDoubleQuote()
        {
            var result = ExecuteParseTag(@"@{TagName param1=val1 param2=""val2"" param3}");
            Assert.AreEqual("TagName", result.Type);
            Assert.AreEqual(3, result.Parameters.Count);
            Assert.IsTrue(result.Parameters.ContainsKey("param1"));
            Assert.AreEqual("val1", result.Parameters["param1"]);
            Assert.IsTrue(result.Parameters.ContainsKey("param2"));
            Assert.AreEqual("val2", result.Parameters["param2"]);
            Assert.IsTrue(result.Parameters.ContainsKey("param3"));
            Assert.AreEqual("", result.Parameters["param3"]);
        }

        [TestMethod]
        public void ParseTagWithTypeAndParameterAndValueBetweenDoubleQuoteAndSomeBadSpace()
        {
            var result = ExecuteParseTag(@"@{  TagName  param1  =  val1    param2  =  ""{val2}""   param3  }");
            Assert.AreEqual("TagName", result.Type);
            Assert.AreEqual(3, result.Parameters.Count);
            Assert.IsTrue(result.Parameters.ContainsKey("param1"));
            Assert.AreEqual("val1", result.Parameters["param1"]);
            Assert.IsTrue(result.Parameters.ContainsKey("param2"));
            Assert.AreEqual("{val2}", result.Parameters["param2"]);
            Assert.IsTrue(result.Parameters.ContainsKey("param3"));
            Assert.AreEqual("", result.Parameters["param3"]);
        }
    }
}
