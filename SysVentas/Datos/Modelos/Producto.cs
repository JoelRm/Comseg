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
    
    public partial class Producto
    {
        public int IdProducto { get; set; }
        public string CodigoProducto { get; set; }
        public string NombreProducto { get; set; }
        public int IdLinea { get; set; }
        public int IdMarca { get; set; }
        public int IdImpuesto { get; set; }
        public int IdMoneda { get; set; }
        public int IdProveedor { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public System.DateTime FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public bool EstadoProducto { get; set; }
        public bool EstadoEliminacion { get; set; }
    }
}
