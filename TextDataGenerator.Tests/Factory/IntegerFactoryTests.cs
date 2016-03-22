// Copyright 2016-2016 Cédric VERNOU. All rights reserved. See LICENCE.md in the project root for license information.

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using TextDataGenerator.Data;
using TextDataGenerator.Factory;

namespace TextDataGenerator.Tests.Factory
{
    [TestClass]
    public class IntegerFactoryTests
    {
        [TestMethod()]
        public void CreateIntegerGeneratorTest()
        {
            {
                var parameters = new Dictionary<string, string>();
                parameters.Add("Min", "10");
                parameters.Add("Max", "15");
                parameters.Add("Format", "X.");
                var integerGenerator = (IntegerGenerator)FactoryStatic.CreateDataGenerator("Integer", parameters);
                Assert.AreEqual(15, integerGenerator.Max);
                Assert.AreEqual(10, integerGenerator.Min);
                Assert.AreEqual("X.", integerGenerator.Format);
                integerGenerator.GetData();
            }
        }
    }
}