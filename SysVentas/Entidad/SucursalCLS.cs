using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class SucursalCLS
    {
        public int IdSucursal { get; set; }
        public string NombreSucursal { get; set; }
        public int IdTipoTienda { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public bool EstadoSucursal { get; set; }

        public string FechaCreacionJS { get; set; }
    }
}
