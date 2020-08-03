using System;
using System.Collections.Generic;
using System.Linq;
using Entidad;
using Datos.Modelos;

namespace Datos.Clases
{
    public class SucursalDA
    {
        public List<SucursalCLS> ListarSucursales()
        {
            List<SucursalCLS> listaSucursales = null;
            using (var db = new BDVentasEntities())
            {
                listaSucursales = (from scl in db.Sucursal
                                   join TipoT in db.TipoTienda on scl.IdTipoTienda equals TipoT.IdTipoTienda
                                   where scl.EstadoEliminacion == false
                                   select new SucursalCLS
                                   {
                                       IdSucursal = scl.IdSucursal,
                                       NombreSucursal = scl.NombreSucursal,
                                       IdTipoTienda = scl.IdTipoTienda,
                                       FechaCreacion = scl.FechaCreacion,
                                       UsuarioCreacion = scl.UsuarioCreacion,
                                       FechaModificacion = scl.FechaModificacion,
                                       UsuarioModificacion = scl.UsuarioModificacion,
                                       EstadoSucursal = scl.EstadoSucursal,
                                       FechaCreacionJS = scl.FechaCreacion.ToString(),
                                       NombreTipoTienda = TipoT.NombreTipoTienda.ToString()
                                     
                                 }).ToList();

                return listaSucursales;
            }
        }

        public int AgregarSucursal(SucursalCLS objSucursalCls)
        {
            int CodResult = 0;
            try
            {
                using (var db = new BDVentasEntities())
                {
                    Sucursal objSucursal = new Sucursal();
                    objSucursal.NombreSucursal = objSucursalCls.NombreSucursal;
                    objSucursal.IdTipoTienda = objSucursalCls.IdTipoTienda;
                    objSucursal.FechaCreacion = DateTime.Now;
                    objSucursal.UsuarioCreacion = "Admin";
                    objSucursal.FechaModificacion = DateTime.Now;
                    objSucursal.UsuarioModificacion = "Admin";
                    objSucursal.EstadoSucursal = true;
                    objSucursal.EstadoEliminacion = false;
                    db.Sucursal.Add(objSucursal);
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

        public int CambiarEstado(SucursalCLS objSucursalCls)
        {
            int codigoRpt = 0;
            try
            {
                using (var db = new BDVentasEntities())
                {
                    Sucursal oSucursal = db.Sucursal.Where(p => p.IdSucursal.Equals(objSucursalCls.IdSucursal)).First();

                    if (oSucursal.EstadoSucursal)
                        objSucursalCls.EstadoSucursal = false;
                    else
                        objSucursalCls.EstadoSucursal = true;

                    oSucursal.EstadoSucursal = objSucursalCls.EstadoSucursal;
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

        public List<SucursalCLS> ListarSucursalesPorFiltro(FiltroCLS objFiltro)
        {
            List<SucursalCLS> listaSucursales = null;
            bool estado = true;
            if (objFiltro.Estado == 0)
                estado = false;

            using (var db = new BDVentasEntities())
            {
                if (objFiltro.Nombre == "" || objFiltro.Nombre == null)
                {
                    if (objFiltro.Estado == 2)
                    {
                        listaSucursales = (from scl in db.Sucursal join TipoT in db.TipoTienda on scl.IdTipoTienda equals TipoT.IdTipoTienda
                                         where scl.EstadoEliminacion == false
                                         select new SucursalCLS
                                         {
                                             IdSucursal = scl.IdSucursal,
                                             NombreSucursal = scl.NombreSucursal,
                                             IdTipoTienda = scl.IdTipoTienda,
                                             FechaCreacion = scl.FechaCreacion,
                                             UsuarioCreacion = scl.UsuarioCreacion,
                                             FechaModificacion = scl.FechaModificacion,
                                             UsuarioModificacion = scl.UsuarioModificacion,
                                             EstadoSucursal = scl.EstadoSucursal,
                                             FechaCreacionJS = scl.FechaCreacion.ToString(),
                                             NombreTipoTienda = TipoT.NombreTipoTienda

                                         }).ToList();
                    }
                    else
                    {
                        listaSucursales = (from scl in db.Sucursal
                                           join TipoT in db.TipoTienda on scl.IdTipoTienda equals TipoT.IdTipoTienda
                                           where scl.EstadoEliminacion == false && scl.EstadoSucursal == estado 
                                         select new SucursalCLS
                                         {
                                             IdSucursal = scl.IdSucursal,
                                             NombreSucursal = scl.NombreSucursal,
                                             IdTipoTienda = scl.IdTipoTienda,
                                             FechaCreacion = scl.FechaCreacion,
                                             UsuarioCreacion = scl.UsuarioCreacion,
                                             FechaModificacion = scl.FechaModificacion,
                                             UsuarioModificacion = scl.UsuarioModificacion,
                                             EstadoSucursal = scl.EstadoSucursal,
                                             FechaCreacionJS = scl.FechaCreacion.ToString(),
                                             NombreTipoTienda = TipoT.NombreTipoTienda
                                         }).ToList();
                    }
                }
                else
                {
                    if (objFiltro.Estado == 2)
                    {
                        listaSucursales = (from scl in db.Sucursal
                                           join TipoT in db.TipoTienda on scl.IdTipoTienda equals TipoT.IdTipoTienda
                                           where scl.EstadoEliminacion == false && scl.NombreSucursal.Contains(objFiltro.Nombre)
                                         select new SucursalCLS
                                         {
                                             IdSucursal = scl.IdSucursal,
                                             NombreSucursal = scl.NombreSucursal,
                                             IdTipoTienda = scl.IdTipoTienda,
                                             FechaCreacion = scl.FechaCreacion,
                                             UsuarioCreacion = scl.UsuarioCreacion,
                                             FechaModificacion = scl.FechaModificacion,
                                             UsuarioModificacion = scl.UsuarioModificacion,
                                             EstadoSucursal = scl.EstadoSucursal,
                                             FechaCreacionJS = scl.FechaCreacion.ToString(),
                                             NombreTipoTienda = TipoT.NombreTipoTienda
                                         }).ToList();
                    }
                    else
                    {
                        listaSucursales = (from scl in db.Sucursal
                                           join TipoT in db.TipoTienda on scl.IdTipoTienda equals TipoT.IdTipoTienda
                                           where scl.EstadoEliminacion == false && scl.EstadoSucursal == estado && scl.NombreSucursal.Contains(objFiltro.Nombre) && scl.EstadoSucursal == estado
                                         select new SucursalCLS
                                         {
                                             IdSucursal = scl.IdSucursal,
                                             NombreSucursal = scl.NombreSucursal,
                                             IdTipoTienda = scl.IdTipoTienda,
                                             FechaCreacion = scl.FechaCreacion,
                                             UsuarioCreacion = scl.UsuarioCreacion,
                                             FechaModificacion = scl.FechaModificacion,
                                             UsuarioModificacion = scl.UsuarioModificacion,
                                             EstadoSucursal = scl.EstadoSucursal,
                                             FechaCreacionJS = scl.FechaCreacion.ToString(),
                                             NombreTipoTienda = TipoT.NombreTipoTienda
                                         }).ToList();
                    }
                }
            }
            return listaSucursales;
        }

        public int EliminarSucursal(SucursalCLS objSucursalCls)
        {
            int cdgoRpt = 0;
            try
            {
                using (var db = new BDVentasEntities())
                {
                    Sucursal oSucursal = db.Sucursal.Where(p => p.IdSucursal.Equals(objSucursalCls.IdSucursal)).First();
                    oSucursal.EstadoEliminacion = true;
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

        public SucursalCLS ObtenerSucursalPorId(int idscl)
        {
            SucursalCLS objSucursalCLS = new SucursalCLS();
            using (var db = new BDVentasEntities())
            {
                Sucursal oSucursal = db.Sucursal.Where(p => p.IdSucursal.Equals(idscl)).First();
                objSucursalCLS.IdSucursal = oSucursal.IdSucursal;
                objSucursalCLS.NombreSucursal = oSucursal.NombreSucursal;
                objSucursalCLS.IdTipoTienda = oSucursal.IdTipoTienda;
            }
            return objSucursalCLS;
        }

        public int EditarSucursal(SucursalCLS objSucursalCls)
        {
            int cdgoRpt = 0;
            try
            {
                using (var db = new BDVentasEntities())
                {
                    Sucursal oSucursal = db.Sucursal.Where(p => p.IdSucursal.Equals(objSucursalCls.IdSucursal)).First();
                    oSucursal.NombreSucursal = objSucursalCls.NombreSucursal;
                    oSucursal.IdTipoTienda = objSucursalCls.IdTipoTienda;
                    objSucursalCls.FechaModificacion = DateTime.Now;
                    objSucursalCls.UsuarioModificacion = "Admin";
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
