// Copyright 2016-2016 Cédric VERNOU. All rights reserved. See LICENCE.md in the project root for license information.

using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextDataGenerator.Parser;

namespace TextDataGenerator.Tests.Parser
{
    [TestClass]
    public class TagParameterParserTest
    {
        [TestClass]
        public class GetKeyValue
        {
            [TestMethod]
            public void RegularCase()
            {
                const string str = "Key=Value";
                var result = TagParameterParser.GetKeyValue(str);
                Assert.AreEqual("Key", result.Key);
                Assert.AreEqual("Value", result.Value);
            }

            [TestMethod]
            public void WithSomeUglySpaces()
            {
                const string str = "  Key  =  Value  ";
                var result = TagParameterParser.GetKeyValue(str);
                Assert.AreEqual("Key", result.Key);
                Assert.AreEqual("Value", result.Value);
            }

            [TestMethod]
            public void ValueBetweenDoubleQuote()
            {
                const string str = @"Key=""Value""";
                var result = TagParameterParser.GetKeyValue(str);
                Assert.AreEqual("Key", result.Key);
                Assert.AreEqual("Value", result.Value);
            }

            [TestMethod]
            public void ValueBetweenDoubleQuoteWithSomeUglySpaces()
            {
                const string str = @"  Key  =  ""Value""  ";
                var result = TagParameterParser.GetKeyValue(str);
                Assert.AreEqual("Key", result.Key);
                Assert.AreEqual("Value", result.Value);
            }
        }

        [TestClass]
        public class GetInfos
        {
            [TestMethod]
            public void FromEmptyReturnNoParameter()
            {
                var str = "";
                var result = TagParameterParser.GetInfos(str);
                Assert.AreEqual(0, result.Count);
            }

            [TestMethod]
            public void FromOneReturnOneParameter()
            {
                var str = "Key=Value";
                var result = TagParameterParser.GetInfos(str);
                Assert.AreEqual(1, result.Count);
                Assert.AreEqual("Value", result["Key"]);
            }

            [TestMethod]
            public void FromSomeReturnSomeParameters()
            {
                var str = "Key=Value,Key1=Value1,Key2=Value";
                var result = TagParameterParser.GetInfos(str);
                Assert.AreEqual(3, result.Count);
                Assert.AreEqual("Value", result["Key"]);
                Assert.AreEqual("Value1", result["Key1"]);
                Assert.AreEqual("Value", result["Key2"]);
            }
        }
    }
}