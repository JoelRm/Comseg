using System;

namespace Entidad
{
    public class AlmacenCLS
    {
        public int IdAlmacen { get; set; }
        public string NombreAlmacen { get; set; }
        public string DireccionAlmacen { get; set; }
        public int IdSucursal { get; set; }
        public string IsPrincipal { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public bool EstadoAlmacen { get; set; }
        public bool EstadoEliminacion { get; set; }

        public string FechaCreacionJS { get; set; }
        public string NombreSucursal { get; set; }
    }
}
