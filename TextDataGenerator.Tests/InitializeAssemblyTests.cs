using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TextDataGenerator.Tests
{
    [TestClass]
    public class InitializeAssemblyTests
    {
        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            Program.InitializeInvariantCuluture();
        }
    }
}
