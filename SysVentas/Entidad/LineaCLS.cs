using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class LineaCLS
    {
        public int IdLinea { get; set; }
        public string NombreLinea { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public bool EstadoLinea { get; set; }
        public string FechaCreacionJS { get; set; }


    }
}
