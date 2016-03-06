// Copyright 2016-2016 Cédric VERNOU. All rights reserved. See LICENCE.md in the project root for license information.

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using TextDataGenerator.Builder;
using TextDataGenerator.Data;

namespace TextDataGenerator.Tests.Builder
{
    [TestClass()]
    public class BuilderTests
    {
        [TestMethod()]
        public void CreateBuilderTextTest1()
        {
            {
                var text = @"@{Integer} + @{Double}";
                var builder = (TextBuilder)BuilderStatic.CreateBuilderText(text);
                Assert.AreEqual(3, builder.Datas.Count);
                Assert.IsInstanceOfType(builder.Datas[0], typeof(IntegerGenerator));
                Assert.AreEqual(" + ", builder.Datas[1].GetData());
                Assert.IsInstanceOfType(builder.Datas[2], typeof(DoubleGenerator));
            }
        }

        [TestMethod()]
        public void CreateBuilderTextTest2()
        {
            {
                var text = @"
@{Repeat Min=10,Max=30}
Easy Test => @{Integer}
@{EndRepeat}
";
                var builder = (TextBuilder)BuilderStatic.CreateBuilderText(text);
                Assert.AreEqual(2, builder.Datas.Count);
                Assert.AreEqual(Environment.NewLine, builder.Datas[0].GetData());
                Assert.IsInstanceOfType(builder.Datas[1], typeof(RepeatBuilder));

                var repeat = (RepeatBuilder)builder.Datas[1];
                Assert.AreEqual(10, repeat.Min);
                Assert.AreEqual(30, repeat.Max);
                Assert.AreEqual(3, repeat.Datas.Count);
                Assert.AreEqual("Easy Test => ", repeat.Datas[0].GetData());
                Assert.IsInstanceOfType(repeat.Datas[1], typeof(IntegerGenerator));
                Assert.AreEqual(Environment.NewLine, repeat.Datas[2].GetData());
            }
        }

        [TestMethod()]
        public void CreateBuilderTextTest3()
        {
            {
                try
                {
                    var text = @"
@{Repeat Min=10,Max=30}
Easy Test => @{FailLine 3}
@{EndRepeat}
";
                    var builder = (TextBuilder)BuilderStatic.CreateBuilderText(text);
                    Assert.Fail();
                }
                catch (BuilderException ex)
                {
                    Assert.AreEqual(3, ex.Line);
                }
            }
        }

        [TestMethod()]
        public void RunExamples()
        {
            var pathFiles = Directory.GetFiles(@"rsc\Example");
            foreach (var pathFile in pathFiles)
            {
                string text = File.ReadAllText(pathFile);
                BuilderStatic.CreateBuilderText(text);
            }
        }
    }
}