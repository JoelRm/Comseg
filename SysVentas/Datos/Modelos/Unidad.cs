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
    
    public partial class Unidad
    {
        public int IdUnidad { get; set; }
        public string NombreUnidad { get; set; }
        public int Factor { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public System.DateTime FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public bool EstadoUnidad { get; set; }
        public Nullable<bool> EstadoEliminacion { get; set; }
    }
}
