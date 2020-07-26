using System;

namespace Entidad
{
    public class MarcaCLS
    {
        public int IdMarca { get; set; }
        public string NombreMarca { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public bool EstadoMarca { get; set; }
        public string FechaCreacionJS { get; set; }
    }
}
