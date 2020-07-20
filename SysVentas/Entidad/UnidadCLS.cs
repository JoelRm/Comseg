using System;

namespace Entidad
{
    public class UnidadCLS
    {
        public int IdUnidad { get; set; }
        public string NombreUnidad { get; set; }
        public int Factor { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public bool EstadoUnidad { get; set; }

        public string FechaCreacionJS { get; set; }
    }
}
