using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class ProductoCLS
    {
        public int IdProducto { get; set; }
        public string CodigoProducto { get; set; }
        public string NombreProducto { get; set; }
        public int IdLinea { get; set; }
        public int IdMarca { get; set; }
        public int IdImpuesto { get; set; }
        public int IdMoneda { get; set; }
        public int IdProveedor { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public bool EstadoProducto { get; set; }
        public bool EstadoEliminacion { get; set; }

        public string FechaCreacionJS { get; set; }
        public string NombreLinea { get; set; }
        public string NombreMarca { get; set; }
        public string NombreImpuesto { get; set; }
        public string NombreMoneda { get; set; }
        public string NombreProveedor { get; set; }

        public string CadenaAlm { get; set; }
        public string CadenaUnd { get; set; }
    }
}
