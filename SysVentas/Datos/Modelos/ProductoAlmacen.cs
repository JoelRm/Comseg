//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Datos.Modelos
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProductoAlmacen
    {
        public int IdProductoAlmacen { get; set; }
        public int IdProducto { get; set; }
        public int IdAlmacen { get; set; }
        public int StockFisico { get; set; }
        public int StockSistema { get; set; }
        public bool IsActivo { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public System.DateTime FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public bool EstadoEliminación { get; set; }
    }
}
