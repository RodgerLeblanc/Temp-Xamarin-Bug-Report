using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nevitium.Test
{
    class TestClassTemplate
    {
       
        [AssemblyInitialize()]
        public static void AssemblyInit(TestContext context) { }

        [ClassInitialize()]
        public static void ClassInit(TestContext context) { }

        [TestInitialize()]
        public void Initialize() { }

        [TestCleanup()]
        public void Cleanup() { }

        [ClassCleanup()]
        public static void ClassCleanup() { }

        [AssemblyCleanup()]
        public static void AssemblyCleanup() { }
    }
}
