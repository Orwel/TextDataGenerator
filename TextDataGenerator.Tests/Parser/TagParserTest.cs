// Copyright 2016-2016 Cédric VERNOU. All rights reserved. See LICENCE.md in the project root for license information.

using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextDataGenerator.Parser;

namespace TextDataGenerator.Tests.Parser
{
    [TestClass]
    public class TagParserTest
    {
        [TestMethod]
        public void ParseEmptyTag()
        {
            var result = TagParser.Parse("@{}");
            Assert.AreEqual("", result.Type);
            Assert.AreEqual(0, result.Parameters.Count);
        }

        [TestMethod]
        public void ParseTagWithoutParameter()
        {
            var result = TagParser.Parse("@{TagName}");
            Assert.AreEqual("TagName", result.Type);
            Assert.AreEqual(0, result.Parameters.Count);
        }

        [TestMethod]
        public void ParseTagWithParameter()
        {
            var result = TagParser.Parse("@{TagName param1=val1, param2=val1}");
            Assert.AreEqual("TagName", result.Type);
            Assert.AreEqual(2, result.Parameters.Count);
        }
    }
}
