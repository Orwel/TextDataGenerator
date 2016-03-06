// Copyright 2016-2016 Cédric VERNOU. All rights reserved. See LICENCE.md in the project root for license information.

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TextDataGenerator.Core;

namespace TextDataGenerator.Tests.Core
{
    [TestClass]
    public class TextExtractorTests
    {
        private static int NbCharInNewLine = Environment.NewLine.Length;

        [TestMethod]
        public void TextExtractorMethodTest()
        {
            var parser = new TextExtractor(@"
Test1
Test2
Test3
");
            var subText1 = parser.Next("1", false);
            Assert.AreEqual(Environment.NewLine + "Test1", subText1);
            Assert.AreEqual(1, parser.Line);
            Assert.AreEqual(2, parser.NextLine);
            Assert.AreEqual(5 + NbCharInNewLine, parser.Cursor);

            parser.SkeepNewLine();
            Assert.AreEqual(1, parser.Line);
            Assert.AreEqual(3, parser.NextLine);
            Assert.AreEqual(5 + (NbCharInNewLine * 2), parser.Cursor);

            var subText2 = parser.Next("st", true);
            Assert.AreEqual("Te", subText2);
            Assert.AreEqual(3, parser.Line);
            Assert.AreEqual(3, parser.NextLine);
            Assert.AreEqual(7 + (NbCharInNewLine * 2), parser.Cursor);

            parser.SkeepNewLine();
            Assert.AreEqual(3, parser.Line);
            Assert.AreEqual(3, parser.NextLine);
            Assert.AreEqual(7 + (NbCharInNewLine * 2), parser.Cursor);
        }
    }
}