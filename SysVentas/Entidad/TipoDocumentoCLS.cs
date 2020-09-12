using System;

namespace Entidad
{
    public class TipoDocumentoCLS
    {
        public int IdTipoDocumento { get; set; }
        public string DescripcionTipoDocumento { get; set; }
        public string AbreviacionTipoDocumento { get; set; }
        public int LongitudTipoDocumento { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public bool EstadoTipoDocumento { get; set; }
        public bool EstadoEliminacion { get; set; }
        public string FechaCreacionJS { get; set; }
    }
}
