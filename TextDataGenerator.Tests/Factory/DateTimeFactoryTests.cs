﻿// Copyright 2016-2016 Cédric VERNOU. All rights reserved. See LICENCE.md in the project root for license information.

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using TextDataGenerator.Data;
using TextDataGenerator.Factory;

namespace TextDataGenerator.Tests.Factory
{
    [TestClass]
    public class DateTimeFactoryTests
    {
        [TestMethod]
        public void CreateDateTimeGeneratorTest()
        {
            {
                var parameters = new Dictionary<string, string>
                {
                    {"Min", "2015-12-10"},
                    {"Max", "2015-12-15 14:12:03"},
                    {"Format", null}
                };
                var generator = (DateTimeGenerator)FactoryStatic.CreateDataGenerator("DateTime", parameters);
                Assert.AreEqual(new DateTime(2015, 12, 10), generator.Min);
                Assert.AreEqual(new DateTime(2015, 12, 15, 14, 12, 3), generator.Max);
                Assert.AreEqual(null, generator.Format);
            }
            {
                var parameters = new Dictionary<string, string>
                {
                    {"Min", "2015-12-10"},
                    {"Max", "2015-12-15 14:12:03"},
                    {"Format", "s"}
                };
                var generator = (DateTimeGenerator)FactoryStatic.CreateDataGenerator("DateTime", parameters);
                Assert.AreEqual(new DateTime(2015, 12, 10), generator.Min);
                Assert.AreEqual(new DateTime(2015, 12, 15, 14, 12, 3), generator.Max);
                Assert.AreEqual("s", generator.Format);
                generator.GetData();
            }
        }
    }
}