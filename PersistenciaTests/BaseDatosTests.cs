using Microsoft.VisualStudio.TestTools.UnitTesting;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Tests
{
    [TestClass()]
    public class BaseDatosTests
    {
        [TestMethod()]
        public void DaoGetTipoDocumentosTest()
        {
            BaseDatos prueba = new BaseDatos();

            var x = prueba.DaoGetTipoDocumentos();
        }

        [TestMethod()]
        public void DaoSetContactenosTest()
        {
            BaseDatos prueba = new BaseDatos();
            Entidades.EntContactenos contact = new Entidades.EntContactenos()
            {
                Apellidos = "Bolaño",
                Asunto = "Prueba",
                Email = "juceboper@hotmail.com",
                IdTipoDocumento = 1,
                Mensaje = "Esta es una prueba",
                Nombres = "Julio",
                Telefono = "3043684346"

            };

            prueba.DaoSetContactenos(contact);
        }
    }
}