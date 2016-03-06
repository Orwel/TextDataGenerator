// Copyright 2016-2016 Cédric VERNOU. All rights reserved. See LICENCE.md in the project root for license information.

using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextDataGenerator.Builder;

namespace TextDataGenerator.Tests.Builder
{
    [TestClass]
    public class ParsingTests
    {
        [TestMethod]
        public void GetKeyValueTest()
        {
            {
                var str = "Key=Value";
                var result = Parsing.GetKeyValue(str);
                Assert.AreEqual("Key", result.Key);
                Assert.AreEqual("Value", result.Value);
            }
            {
                var str = "Julie=QdGTHJjSDqf";
                var result = Parsing.GetKeyValue(str);
                Assert.AreEqual("Julie", result.Key);
                Assert.AreEqual("QdGTHJjSDqf", result.Value);
            }
        }

        [TestMethod]
        public void GetInfosTest()
        {
            {
                var str = "";
                var result = Parsing.GetInfos(str);
                Assert.AreEqual(0, result.Count);
            }
            {
                var str = "Key=Value";
                var result = Parsing.GetInfos(str);
                Assert.AreEqual(1, result.Count);
                Assert.AreEqual("Value", result["Key"]);
            }
            {
                var str = "Key=Value,Key1=Value1,Key2=Value";
                var result = Parsing.GetInfos(str);
                Assert.AreEqual(3, result.Count);
                Assert.AreEqual("Value", result["Key"]);
                Assert.AreEqual("Value1", result["Key1"]);
                Assert.AreEqual("Value", result["Key2"]);
            }
        }
    }
}