using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfServicios.Servicios
{
    /// <summary>
    /// Interfaz del servicio web Contactenos
    /// </summary>
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IServicioContactenos" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServicioContactenos
    {
        /// <summary>
        /// Metodo Get que devuelve los Tipos de Documentos
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "GetTiposDocumentos")]
        List<Entidades.EntTipoDocumento> GetTiposDocumentos();

        /// <summary>
        /// Metodo Post que permite guardar la información de los contactos
        /// </summary>
        /// <param name="contactenos"></param>
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "SetContactenos")]
        void SetContactenos(Entidades.EntContactenos contactenos);
    }
}
