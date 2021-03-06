﻿// Copyright 2016-2016 Cédric VERNOU. All rights reserved. See LICENCE.md in the project root for license information.

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Text;
using TextDataGenerator.Data;
using TextDataGenerator.Factory;

namespace TextDataGenerator.Tests.Factory
{
    [TestClass]
    public class FileLineTests
    {
        [TestMethod]
        public void CreateFileLineSelectorTest()
        {
            {
                var parameters = new Dictionary<string, string>
                {
                    {"Path", @".\rsc\FileLine\NamesList.txt"},
                    {"Encoding", "UTF-8"}
                };
                var generator = (FileLineSelector)FactoryStatic.CreateDataGenerator("TextLine", parameters);
                Assert.AreEqual(@".\rsc\FileLine\NamesList.txt", generator.Path);
                Assert.AreEqual(Encoding.UTF8, generator.Encoding);
            }
        }
    }
}