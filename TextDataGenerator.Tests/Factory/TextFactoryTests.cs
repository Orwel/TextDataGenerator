// Copyright 2016-2016 Cédric VERNOU. All rights reserved. See LICENCE.md in the project root for license information.

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using TextDataGenerator.Data;
using TextDataGenerator.Factory;

namespace TextDataGenerator.Tests.Factory
{
    [TestClass]
    public class TextFactoryTests
    {
        [TestMethod]
        public void CreateTextGeneratorTest()
        {
            {
                var parameters = new Dictionary<string, string>();
                parameters.Add("MinParagraph", "5");
                parameters.Add("MaxParagraph", "9");
                parameters.Add("MinSentence", "10");
                parameters.Add("MaxSentence", "20");
                parameters.Add("MinWord", "100");
                parameters.Add("MaxWord", "200");
                var generator = (TextGenerator)FactoryStatic.CreateDataGenerator("Text", parameters);
                Assert.AreEqual(5, generator.MinParagraph);
                Assert.AreEqual(9, generator.MaxParagraph);
                Assert.AreEqual(10, generator.MinSentence);
                Assert.AreEqual(20, generator.MaxSentence);
                Assert.AreEqual(100, generator.MinWord);
                Assert.AreEqual(200, generator.MaxWord);
                generator.GetData();
            }
        }
    }
}
