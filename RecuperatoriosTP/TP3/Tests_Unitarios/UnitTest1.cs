using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tests_Unitarios
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string saludo = "Hola";

            Assert.AreEqual("Hola", saludo);
        }
    }
}
