using Datos.Modelos;
using Entidad;
using System.Collections.Generic;
using System.Linq;

namespace Datos.Clases
{
    public class AlmacenDA
    {
        public List<AlmacenCLS> ListarUnidadesPorFiltroProductoUnd(FiltroCLS objFiltroCLS)
        {
            List<AlmacenCLS> listaAlmacen = null;
            using (var db = new BDVentasEntities())
            {
                if (objFiltroCLS.Cadena == null)
                {
                    listaAlmacen = (from alm in db.Almacen
                                     join scl in db.Sucursal on alm.IdSucursal equals(scl.IdSucursal)
                                     where alm.EstadoEliminacion == false && alm.EstadoAlmacen == true
                                     select new AlmacenCLS
                                     {
                                         IdAlmacen = alm.IdAlmacen,
                                         NombreAlmacen = alm.NombreAlmacen,
                                         DireccionAlmacen = alm.DireccionAlmacen,
                                         FechaCreacion = alm.FechaCreacion,
                                         UsuarioCreacion = alm.UsuarioCreacion,
                                         FechaModificacion = alm.FechaModificacion,
                                         UsuarioModificacion = alm.UsuarioModificacion,
                                         EstadoAlmacen = alm.EstadoAlmacen,
                                         FechaCreacionJS = alm.FechaCreacion.ToString(),
                                         NombreSucursal = scl.NombreSucursal
                                     }).ToList();
                }
                else
                {

                    string[] prueba = objFiltroCLS.Cadena.Split(',');

                    List<AlmacenCLS> obj = new List<AlmacenCLS>();

                    for (int i = 0; i < prueba.Length; i++)
                    {
                        obj.Add(new AlmacenCLS
                        {
                            IdAlmacen = int.Parse(prueba[i])
                        });
                    }


                    listaAlmacen = (from alm in db.Almacen
                                    join scl in db.Sucursal on alm.IdSucursal equals (scl.IdSucursal)
                                    where alm.EstadoEliminacion == false && alm.EstadoAlmacen == true
                                    select new AlmacenCLS
                                    {
                                        IdAlmacen = alm.IdAlmacen,
                                        NombreAlmacen = alm.NombreAlmacen,
                                        DireccionAlmacen = alm.DireccionAlmacen,
                                        FechaCreacion = alm.FechaCreacion,
                                        UsuarioCreacion = alm.UsuarioCreacion,
                                        FechaModificacion = alm.FechaModificacion,
                                        UsuarioModificacion = alm.UsuarioModificacion,
                                        EstadoAlmacen = alm.EstadoAlmacen,
                                        FechaCreacionJS = alm.FechaCreacion.ToString(),
                                        NombreSucursal = scl.NombreSucursal
                                    }).ToList();

                    listaAlmacen = (from list in listaAlmacen
                                    where !(obj.Any(item2 => item2.IdAlmacen == list.IdAlmacen))
                                     select list).ToList();
                }
            }



            return listaAlmacen;
        }
    }
}
