using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class ProveedorCLS
    {
        public int IdProveedor { get; set; }
        public int IdTipoPersona { get; set; }
        public string NroDocumento { get; set; }
        public string NombreProveedor { get; set; }
        public string DireccionProveedor { get; set; }
        public string NombreContacto { get; set; }
        public string NumeroContacto { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public bool EstadoProveedor { get; set; }
        public bool EstadoEliminación { get; set; }
        public string FechaCreacionJS { get; set; }
    }
}
