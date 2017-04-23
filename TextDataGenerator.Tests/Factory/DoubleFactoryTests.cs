// Copyright 2016-2016 Cédric VERNOU. All rights reserved. See LICENCE.md in the project root for license information.

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using TextDataGenerator.Data;
using TextDataGenerator.Factory;

namespace TextDataGenerator.Tests.Factory
{
    [TestClass]
    public class DoubleFactoryTests
    {
        [TestMethod]
        public void CreateDoubleGeneratorTest()
        {
            {
                var parameters = new Dictionary<string, string> {{"Min", "10"}, {"Max", "15"}, {"Format", ".00"}};
                var doubleGenerator = (DoubleGenerator)FactoryStatic.CreateDataGenerator("Double", parameters);
                Assert.AreEqual(15, doubleGenerator.Max);
                Assert.AreEqual(10, doubleGenerator.Min);
                Assert.AreEqual(".00", doubleGenerator.Format);
                doubleGenerator.GetData();
            }
        }
    }
}