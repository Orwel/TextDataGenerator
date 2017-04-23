// Copyright 2016-2016 Cédric VERNOU. All rights reserved. See LICENCE.md in the project root for license information.

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using TextDataGenerator.Data;
using TextDataGenerator.Factory;

namespace TextDataGenerator.Tests.Factory
{
    [TestClass]
    public class RepeatFactoryTests
    {
        [TestMethod]
        public void CreateRepeatGeneratorTest_Fail_MinIsRequired()
        {
            try
            {
                var parameters = new Dictionary<string, string>();
                FactoryStatic.CreateDataGenerator("Repeat", parameters);
                Assert.Fail();
            }
            catch (InvalidOperationException) { }
        }

        [TestMethod]
        public void CreateRepeatGeneratorTest_Fail_MinGreaterMax()
        {
            try
            {
                var parameters = new Dictionary<string, string> {{"Min", "10"}, {"Max", "5"}};
                FactoryStatic.CreateDataGenerator("Repeat", parameters);
                Assert.Fail();
            }
            catch (InvalidOperationException) { }
        }

        [TestMethod]
        public void CreateRepeatGeneratorTest_Fail_BadParameter()
        {
            try
            {
                var parameters = new Dictionary<string, string> {{"Bad", "Bad"}, {"Min", "10"}, {"Max", "5"}};
                FactoryStatic.CreateDataGenerator("Repeat", parameters);
                Assert.Fail();
            }
            catch (InvalidOperationException) { }
        }

        [TestMethod]
        public void CreateRepeatGeneratorTest()
        {
            {
                var parameters = new Dictionary<string, string> {{"Min", "10"}};
                var repeat = (RepeatData)FactoryStatic.CreateDataGenerator("Repeat", parameters);
                Assert.AreEqual(10, repeat.Max);
                Assert.AreEqual(10, repeat.Min);
                repeat.GetData();
            }

            {
                var parameters = new Dictionary<string, string> {{"Min", "10"}, {"Max", "15"}};
                var repeat = (RepeatData)FactoryStatic.CreateDataGenerator("Repeat", parameters);
                Assert.AreEqual(15, repeat.Max);
                Assert.AreEqual(10, repeat.Min);
                repeat.GetData();
            }
        }
    }
}