using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;
using Entidades;

namespace Tests_Unitarios
{
    [TestClass]
    public class Tests_Cliente
    {
        [TestMethod]
        public void TestMethod1()
        {
            StringBuilder sb = new StringBuilder();
            string esperado = sb.AppendLine($"Rafael Mendoza").ToString();
            Cliente cliente = new Cliente("Rafael", "Mendoza", 30123123);
            string actual;

            actual = cliente.ConcatNombreApellido(cliente.Nombre, cliente.Apellido);

            Assert.AreEqual(esperado, actual);
        }
    }
}
