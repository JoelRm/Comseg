using System;

namespace Entidad
{
    public class TipoPersonaCLS
    {
        public int IdTipoPersona { get; set; }
        public string NombreTipoPersona { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public bool EstadoTipoPersona { get; set; }
        public bool EstadoEliminacion { get; set; }
        public string FechaCreacionJS { get; set; }
    }
}
