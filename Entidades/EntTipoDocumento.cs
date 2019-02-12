using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [DataContract]
    public class EntTipoDocumento
    {
        [DataMember]
        public int IdTipoDocumento { get; set; }
        [DataMember]
        public string TipoDocumento { get; set; }
    }
}
