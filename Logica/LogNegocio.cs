using Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class LogNegocio
    {
        public List<Entidades.EntTipoDocumento> LogGetTipoDocumentos()
        {
            try
            {
                BaseDatos datos = new BaseDatos();

                return datos.DaoGetTipoDocumentos();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void LogSetContactenos(Entidades.EntContactenos contactenos)
        {
            try
            {
                BaseDatos datos = new BaseDatos();

                datos.DaoSetContactenos(contactenos);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
