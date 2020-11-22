using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Entidades;

namespace Tests_Unitarios
{
    [TestClass]
    public class Tests_Precios
    {
        [TestMethod]
        public void TestPrecioTotalPagarClienteSinDescuento()
        {
            double subTotal = 200.30;
            double totalEsperado = 200.30;
            double totalRecibido;
            Cliente cliente = new Cliente("Jose", "Perez", 30123123);

            totalRecibido = CarritoCompras.GetPrecioTotalAPagar(subTotal, cliente);

            Assert.AreEqual(totalEsperado, totalRecibido);
        }

        [TestMethod]
        public void TestPrecioTotalPagarClienteConDescuento()
        {
            double subTotal = 100.50;
            double totalEsperado = 87.435;
            double totalRecibido;
            Cliente cliente = new Cliente("Jesus", "Ojeda", 30123123);

            totalRecibido = CarritoCompras.GetPrecioTotalAPagar(subTotal, cliente);

            Assert.AreEqual(totalEsperado, totalRecibido);
        }
    }
}
