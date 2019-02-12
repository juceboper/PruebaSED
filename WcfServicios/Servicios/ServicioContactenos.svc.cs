using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using Entidades;

namespace WcfServicios.Servicios
{
    /// <summary>
    /// Servicio web Contactenos
    /// </summary>
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServicioContactenos" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServicioContactenos.svc o ServicioContactenos.svc.cs en el Explorador de soluciones e inicie la depuración.
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class ServicioContactenos : IServicioContactenos
    {
        /// <summary>
        /// Metodo Get que devuelve los Tipos de Documentos
        /// </summary>
        /// <returns></returns>
        public List<EntTipoDocumento> GetTiposDocumentos()
        {
            try
            {
                Logica.LogNegocio logica = new Logica.LogNegocio();

                return logica.LogGetTipoDocumentos();
            }
            catch (FaultException ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
            catch(CommunicationException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Metodo Post que permite guardar la información de los contactos
        /// </summary>
        /// <param name="contactenos"></param>
        public void SetContactenos(EntContactenos contactenos)
        {
            try
            {
                Logica.LogNegocio logica = new Logica.LogNegocio();

                logica.LogSetContactenos(contactenos);
            }
            catch (FaultException ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
            catch (CommunicationException ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
