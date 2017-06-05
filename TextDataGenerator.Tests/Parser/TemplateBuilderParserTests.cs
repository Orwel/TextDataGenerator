// Copyright 2016-2016 Cédric VERNOU. All rights reserved. See LICENCE.md in the project root for license information.

using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextDataGenerator.Data;
using TextDataGenerator.Parser;

namespace TextDataGenerator.Tests.Parser
{
    [TestClass]
    public class TemplateBuilderParserTests
    {
        [TestMethod]
        public void CreateBuilderTextTest1()
        {
            const string text = @"@{Integer} + @{Double}";
            var template = (TemplateData)TemplateBuilderParser.CreateBuilderText(text).CreateDataGenerator();
            Assert.AreEqual(3, template.Datas.Count);
            Assert.IsInstanceOfType(template.Datas[0], typeof(IntegerGenerator));
            Assert.AreEqual(" + ", template.Datas[1].GetData());
            Assert.IsInstanceOfType(template.Datas[2], typeof(DoubleGenerator));
        }

        [TestMethod]
        public void CreateBuilderTextTest2()
        {
            const string text = @"
@{Repeat Min=10 Max=30}
Easy Test => @{Integer}
@{EndRepeat}
";
            var template = (TemplateData)TemplateBuilderParser.CreateBuilderText(text).CreateDataGenerator();
            Assert.AreEqual(2, template.Datas.Count);
            Assert.AreEqual(Environment.NewLine, template.Datas[0].GetData());
            Assert.IsInstanceOfType(template.Datas[1], typeof(RepeatData));

            var repeat = (RepeatData)template.Datas[1];
            Assert.AreEqual(10, repeat.Min);
            Assert.AreEqual(30, repeat.Max);
            Assert.AreEqual(3, repeat.Datas.Count);
            Assert.AreEqual("Easy Test => ", repeat.Datas[0].GetData());
            Assert.IsInstanceOfType(repeat.Datas[1], typeof(IntegerGenerator));
            Assert.AreEqual(Environment.NewLine, repeat.Datas[2].GetData());
        }

        [TestMethod]
        public void CreateBuilderTextTest3()
        {
            try
            {
                const string text = @"
@{Repeat Min=10 Max=30}
Easy Test => @{FailLine 3}
@{EndRepeat}
";
                TemplateBuilderParser.CreateBuilderText(text).CreateDataGenerator();
                Assert.Fail();
            }
            catch (BuilderParserException ex)
            {
                Assert.AreEqual(3, ex.Line);
            }
        }

        [TestMethod]
        public void CreateBuilderTextTest4()
        {
            const string text = @"@{Repeat Min=""10"" Max=""30""} ""Test""=> @{Integer} @{EndRepeat}";
            var template = (TemplateData)TemplateBuilderParser.CreateBuilderText(text).CreateDataGenerator();
            Assert.AreEqual(1, template.Datas.Count);
            Assert.IsInstanceOfType(template.Datas[0], typeof(RepeatData));

            var repeat = (RepeatData)template.Datas[0];
            Assert.AreEqual(10, repeat.Min);
            Assert.AreEqual(30, repeat.Max);
            Assert.AreEqual(3, repeat.Datas.Count);
            Assert.AreEqual(@" ""Test""=> ", repeat.Datas[0].GetData());
            Assert.IsInstanceOfType(repeat.Datas[1], typeof(IntegerGenerator));
            Assert.AreEqual(" ", repeat.Datas[2].GetData());
        }

        //[TestMethod]
        public void CreateBuilderTextTest5()
        {
            const string text = @"@{Integer Id=MyInteger} = @{MyInteger}";
            var template = (TemplateData)TemplateBuilderParser.CreateBuilderText(text).CreateDataGenerator();
            Assert.AreEqual(3, template.Datas.Count);
            Assert.IsInstanceOfType(template.Datas[0], typeof(IntegerGenerator));
            Assert.AreEqual(" = ", template.Datas[1].GetData());
            Assert.IsInstanceOfType(template.Datas[2], typeof(DoubleGenerator));
        }

        [TestMethod]
        public void RunExamples()
        {
            var pathFiles = Directory.GetFiles(@"rsc\Example");
            foreach (var pathFile in pathFiles)
            {
                var text = File.ReadAllText(pathFile);
                TemplateBuilderParser.CreateBuilderText(text).CreateDataGenerator().GetData();
            }
        }
    }
}