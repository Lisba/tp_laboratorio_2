using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Excepciones;
using ClasesInstanciables;
using EntidadesAbstractas;

namespace Tests_Unitarios
{
    [TestClass]
    public class Tests_Exceptions
    {
        [TestMethod]
        [ExpectedException(typeof(AlumnoRepetidoException))]
        public void TestAlumnoRepetidoExceptions()
        {
            Alumno alumnoUno = new Alumno(1, "Ramon", "Gonzalez", "25987547", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.AlDia);
            Alumno alumnoDos = new Alumno(1, "Ramon", "Gonzalez", "25987547", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.AlDia);
            Universidad universidad = new Universidad();
            
            universidad += alumnoUno;
            universidad += alumnoDos;
        }

        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void TestDniInvalidoException()
        {
            new Alumno(1, "Andres", "Castillo", "12234A58", Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.Deudor);
        }
        
        [TestMethod]
        [ExpectedException(typeof(NacionalidadInvalidaException))]
        public void TestNacionalidadInvalidaException()
        {
            new Profesor(1, "Pepe", "Peposo", "95456273", Persona.ENacionalidad.Argentino);
        }
    }
}
