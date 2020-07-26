using System;

namespace Entidad
{
    public class ImpuestoCLS
    {
        public int IdImpuesto { get; set; }
        public string NombreImpuesto { get; set; }
        public decimal ValorImpuesto { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public bool EstadoImpuesto { get; set; }
        public string FechaCreacionJS { get; set; }
        
        public string ValorImpuestoJS { get; set; }
    }
}
