// Copyright 2016-2016 Cédric VERNOU. All rights reserved. See LICENCE.md in the project root for license information.

using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextDataGenerator.Tests.Core;

namespace TextDataGenerator.Tests
{
    [TestClass]
    public class InitializeAssemblyTests
    {
        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            Program.InitializeInvariantCuluture();
            FakeRandomNumberProvider.Initialize();
        }
    }
}