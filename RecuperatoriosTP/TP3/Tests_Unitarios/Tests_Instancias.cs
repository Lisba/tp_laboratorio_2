using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ClasesInstanciables;
using EntidadesAbstractas;

namespace Tests_Unitarios
{
    [TestClass]
    public class Tests_Instancias
    {
        [TestMethod]
        public void TestInstanciaAlumno()
        {
            bool resultado = false;
            Universidad universidad = new Universidad();
            Alumno alumno1 = new Alumno(1, "Andres", "Castillo", "12234458", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.Deudor);
            Profesor profesor1 = new Profesor(1, "Profesor", "Jirafales", "95456273", Persona.ENacionalidad.Extranjero);

            universidad += profesor1;
            universidad += alumno1;

            if (universidad.Alumnos.Count > 0 && universidad.Instructores.Count > 0 && universidad.Jornadas.Count == 0)
            {
                resultado = true;
            }

            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void TestSobrecargaOperadorProfesorUniversidad()
        {
            bool resultado = false;
            Profesor profesor = new Profesor();
            Universidad universidad = new Universidad();

            universidad += profesor;

            if (universidad == profesor)
            {
                resultado = true;
            }

            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void TestInstanciaProfesor()
        {
            bool resultado = false;
            Profesor profesor1 = new Profesor(1, "Profesor", "Jirafales", "95456273", Persona.ENacionalidad.Extranjero);
            Jornada jornada1 = new Jornada(Universidad.EClases.Laboratorio, profesor1);

            if (jornada1.Instructor == profesor1)
            {
                resultado = true;
            }

            Assert.IsTrue(resultado);
        }

    }
}
