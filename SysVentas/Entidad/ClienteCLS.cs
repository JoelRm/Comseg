using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class ClienteCLS
    {
        public int IdCliente { get; set; }
        public int IdTipoDocumento { get; set; }
        public string NroDocumentoCliente { get; set; }
        public string NombreCliente { get; set; }
        public string DireccionCliente { get; set; }
        public string NumeroContactoCliente { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public bool EstadoCliente { get; set; }
        public string FechaCreacionJS { get; set; }

        public string NombreTipoDocumento { get; set; }
    }
}
