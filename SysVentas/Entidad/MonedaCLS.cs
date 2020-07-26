using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class MonedaCLS
    {
        public int IdMoneda { get; set; }
        public string NombreMoneda { get; set; }
        public string SimboloMoneda { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public bool EstadoMoneda { get; set; }
        public string FechaCreacionJS { get; set; }
    }
}
