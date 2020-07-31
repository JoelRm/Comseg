using Datos.Modelos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Datos.Clases
{
    public class AlmacenDA
    {

        public int AgregarAlmacen(AlmacenCLS objAlmacenCLS)
        {
            int CodResult = 0;
            try
            {
                using (var db = new BDVentasEntities())
                {
                    Almacen objAlmacen = new Almacen();
                    objAlmacen.NombreAlmacen = objAlmacenCLS.NombreAlmacen;
                    objAlmacen.DireccionAlmacen = objAlmacenCLS.DireccionAlmacen;
                    objAlmacen.IdSucursal = objAlmacenCLS.IdSucursal;
                    objAlmacen.IsPrincipal = objAlmacenCLS.IsPrincipal;
                    objAlmacen.FechaCreacion = DateTime.Now;
                    objAlmacen.UsuarioCreacion = "Admin";
                    objAlmacen.FechaModificacion = DateTime.Now;
                    objAlmacen.UsuarioModificacion = "Admin";
                    objAlmacen.EstadoAlmacen = true;
                    objAlmacen.EstadoEliminacion = false;
                    db.Almacen.Add(objAlmacen);
                    db.SaveChanges();

                    CodResult = 1;
                }
            }
            catch (Exception)
            {
                CodResult = 0;
            }
            return CodResult;
        }

        public List<AlmacenCLS> ListarAlmacenPorFiltroProductoAlm(FiltroCLS objFiltroCLS)
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

        public List<AlmacenCLS> ListarAlmacenPorFiltro(FiltroCLS objFiltro)
        {
            List<AlmacenCLS> listaAlmacen = null;
            bool estado = true;
            if (objFiltro.Estado == 0)
                estado = false;

            using (var db = new BDVentasEntities())
            {
                if (objFiltro.Nombre == "" || objFiltro.Nombre == null)
                {
                    if (objFiltro.Estado == 2)
                    {
                        listaAlmacen = (from alm in db.Almacen
                                        join suc in db.Sucursal on alm.IdSucursal equals suc.IdSucursal
                                        where alm.EstadoEliminacion == false && suc.EstadoEliminacion == false 
                                        && suc.EstadoSucursal == true
                                        select new AlmacenCLS
                                        {
                                            IdAlmacen = alm.IdAlmacen,
                                            NombreAlmacen = alm.NombreAlmacen,
                                            DireccionAlmacen = alm.DireccionAlmacen,
                                            IsPrincipal = alm.IsPrincipal,
                                            IdSucursal = alm.IdSucursal,
                                            NombreSucursal = suc.NombreSucursal,
                                            FechaCreacion = alm.FechaCreacion,
                                            UsuarioCreacion = alm.UsuarioCreacion,
                                            FechaModificacion = alm.FechaModificacion,
                                            UsuarioModificacion = alm.UsuarioModificacion,
                                            EstadoAlmacen = alm.EstadoAlmacen,
                                            FechaCreacionJS = alm.FechaCreacion.ToString()
                                        }).ToList();
                    }
                    else
                    {
                        listaAlmacen = (from alm in db.Almacen
                                        join suc in db.Sucursal on alm.IdSucursal equals suc.IdSucursal
                                        where alm.EstadoEliminacion == false && suc.EstadoEliminacion == false
                                        && alm.EstadoAlmacen == estado && suc.EstadoSucursal == true
                                        select new AlmacenCLS
                                        {
                                            IdAlmacen = alm.IdAlmacen,
                                            NombreAlmacen = alm.NombreAlmacen,
                                            DireccionAlmacen = alm.DireccionAlmacen,
                                            IsPrincipal = alm.IsPrincipal,
                                            IdSucursal = alm.IdSucursal,
                                            NombreSucursal = suc.NombreSucursal,
                                            FechaCreacion = alm.FechaCreacion,
                                            UsuarioCreacion = alm.UsuarioCreacion,
                                            FechaModificacion = alm.FechaModificacion,
                                            UsuarioModificacion = alm.UsuarioModificacion,
                                            EstadoAlmacen = alm.EstadoAlmacen,
                                            FechaCreacionJS = alm.FechaCreacion.ToString()
                                        }).ToList();
                    }
                }
                else
                {
                    if (objFiltro.Estado == 2)
                    {
                        listaAlmacen = (from alm in db.Almacen
                                        join suc in db.Sucursal on alm.IdSucursal equals suc.IdSucursal
                                        where alm.EstadoEliminacion == false && suc.EstadoEliminacion == false
                                        && suc.EstadoSucursal == true && alm.NombreAlmacen == objFiltro.Nombre
                                        select new AlmacenCLS
                                        {
                                            IdAlmacen = alm.IdAlmacen,
                                            NombreAlmacen = alm.NombreAlmacen,
                                            DireccionAlmacen = alm.DireccionAlmacen,
                                            IsPrincipal = alm.IsPrincipal,
                                            IdSucursal = alm.IdSucursal,
                                            NombreSucursal = suc.NombreSucursal,
                                            FechaCreacion = alm.FechaCreacion,
                                            UsuarioCreacion = alm.UsuarioCreacion,
                                            FechaModificacion = alm.FechaModificacion,
                                            UsuarioModificacion = alm.UsuarioModificacion,
                                            EstadoAlmacen = alm.EstadoAlmacen,
                                            FechaCreacionJS = alm.FechaCreacion.ToString()
                                        }).ToList();
                    }
                    else
                    {
                        listaAlmacen = (from alm in db.Almacen
                                        join suc in db.Sucursal on alm.IdSucursal equals suc.IdSucursal
                                        where alm.EstadoEliminacion == false && suc.EstadoEliminacion == false
                                        && alm.EstadoAlmacen == estado && suc.EstadoSucursal == true && alm.NombreAlmacen == objFiltro.Nombre
                                        select new AlmacenCLS
                                        {
                                            IdAlmacen = alm.IdAlmacen,
                                            NombreAlmacen = alm.NombreAlmacen,
                                            DireccionAlmacen = alm.DireccionAlmacen,
                                            IsPrincipal = alm.IsPrincipal,
                                            IdSucursal = alm.IdSucursal,
                                            NombreSucursal = suc.NombreSucursal,
                                            FechaCreacion = alm.FechaCreacion,
                                            UsuarioCreacion = alm.UsuarioCreacion,
                                            FechaModificacion = alm.FechaModificacion,
                                            UsuarioModificacion = alm.UsuarioModificacion,
                                            EstadoAlmacen = alm.EstadoAlmacen,
                                            FechaCreacionJS = alm.FechaCreacion.ToString()
                                        }).ToList();
                    }
                }
            }
            return listaAlmacen;
        }

        public AlmacenCLS ObtenerAlmacenPorId(int idAlm)
        {
            AlmacenCLS objAlmacenCLS = new AlmacenCLS();
            using (var db = new BDVentasEntities())
            {
                Almacen oAlmacen = db.Almacen.Where(p => p.IdAlmacen.Equals(idAlm)).First();
                objAlmacenCLS.IdAlmacen = oAlmacen.IdAlmacen;
                objAlmacenCLS.NombreAlmacen = oAlmacen.NombreAlmacen;
                objAlmacenCLS.DireccionAlmacen = oAlmacen.DireccionAlmacen;
                objAlmacenCLS.IsPrincipal = oAlmacen.IsPrincipal;
                objAlmacenCLS.IdSucursal = oAlmacen.IdSucursal;

                Sucursal oSucursal = db.Sucursal.Where(p => p.IdSucursal.Equals(objAlmacenCLS.IdSucursal)).First();
                objAlmacenCLS.NombreSucursal = oSucursal.NombreSucursal;

            }
            return objAlmacenCLS;
        }

        public int EliminarAlmacen(AlmacenCLS objAlmacenCLS)
        {
            int cdgoRpt = 0;
            try
            {
                using (var db = new BDVentasEntities())
                {
                    Almacen oAlmacen = db.Almacen.Where(p => p.IdAlmacen.Equals(objAlmacenCLS.IdAlmacen)).First();
                    oAlmacen.EstadoEliminacion = true;
                    db.SaveChanges();
                    cdgoRpt = 1;
                }
            }
            catch (Exception e)
            {
                cdgoRpt = 0;
            }
            return cdgoRpt;
        }

        public int CambiarEstadoAlmacen(AlmacenCLS objAlmacenCls)
        {
            int codigoRpt = 0;
            try
            {
                using (var db = new BDVentasEntities())
                {
                    Almacen oAlmacen = db.Almacen.Where(p => p.IdAlmacen.Equals(objAlmacenCls.IdAlmacen)).First();

                    if (oAlmacen.EstadoAlmacen)
                        objAlmacenCls.EstadoAlmacen = false;
                    else
                        objAlmacenCls.EstadoAlmacen = true;

                    oAlmacen.EstadoAlmacen = objAlmacenCls.EstadoAlmacen;
                    db.SaveChanges();

                    codigoRpt = 1;
                }
            }
            catch (Exception e)
            {
                codigoRpt = 0;
                throw;
            }

            return codigoRpt;
        }

        public int EditarAlmacen(AlmacenCLS objAlmacenCLS)
        {
            int cdgoRpt = 0;
            try
            {
                using (var db = new BDVentasEntities())
                {
                    Almacen oAlmacen = db.Almacen.Where(p => p.IdAlmacen.Equals(objAlmacenCLS.IdAlmacen)).First();
                    oAlmacen.NombreAlmacen = objAlmacenCLS.NombreAlmacen;
                    oAlmacen.DireccionAlmacen = objAlmacenCLS.DireccionAlmacen;
                    oAlmacen.IdSucursal = objAlmacenCLS.IdSucursal;
                    oAlmacen.IsPrincipal = objAlmacenCLS.IsPrincipal;
                    oAlmacen.FechaModificacion = DateTime.Now;
                    oAlmacen.UsuarioModificacion = "Admin";
                    db.SaveChanges();
                    cdgoRpt = 1;
                }
            }
            catch (Exception e)
            {
                cdgoRpt = 0;
            }
            return cdgoRpt;
        }
    }
}
