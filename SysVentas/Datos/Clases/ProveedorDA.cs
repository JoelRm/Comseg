using Datos.Modelos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Datos.Clases
{
    public class ProveedorDA
    {
        public int AgregarProveedor(ProveedorCLS objProveedorCLS)
        {
            int CodResult = 0;
            try
            {
                using (var db = new BDVentasEntities())
                {
                    Proveedor objProveedor = new Proveedor();
                    objProveedor.IdTipoPersona = objProveedorCLS.IdTipoPersona;
                    objProveedor.NroDocumentoProveedor = objProveedorCLS.NroDocumento;
                    objProveedor.NombreProveedor = objProveedorCLS.NombreProveedor;
                    objProveedor.DireccionProveedor = objProveedorCLS.DireccionProveedor;
                    objProveedor.NombreContactoProveedor = objProveedorCLS.NombreContacto;
                    objProveedor.NumeroContactoProveedor = objProveedorCLS.NumeroContacto;
                    objProveedor.FechaCreacion = DateTime.Now;
                    objProveedor.UsuarioCreacion = "Admin";
                    objProveedor.FechaModificacion = DateTime.Now;
                    objProveedor.UsuarioModificacion = "Admin";
                    objProveedor.EstadoProveedor = true;
                    objProveedor.EstadoEliminacion = false;
                    db.Proveedor.Add(objProveedor);
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
        
        public List<ProveedorCLS> ListarProveedorPorFiltro(FiltroCLS objFiltro)
        {
            List<ProveedorCLS> listaProveedor = null;
            bool estado = true;
            if (objFiltro.Estado == 0)
                estado = false;

            using (var db = new BDVentasEntities())
            {
                if (objFiltro.Nombre == "" || objFiltro.Nombre == null)
                {
                    if (objFiltro.Estado == 2)
                    {
                        listaProveedor = (from prov in db.Proveedor
                                        where prov.EstadoEliminacion == false
                                        select new ProveedorCLS
                                        {
                                            IdProveedor = prov.IdProveedor,
                                            NroDocumento = prov.NroDocumentoProveedor,
                                            NombreProveedor = prov.NombreProveedor,
                                            DireccionProveedor = prov.DireccionProveedor,
                                            NombreContacto = prov.NombreContactoProveedor,
                                            NumeroContacto = prov.NumeroContactoProveedor,
                                            IdTipoPersona = prov.IdTipoPersona,
                                            FechaCreacion = prov.FechaCreacion,
                                            UsuarioCreacion = prov.UsuarioCreacion,
                                            FechaModificacion = prov.FechaModificacion,
                                            UsuarioModificacion = prov.UsuarioModificacion,
                                            EstadoProveedor = prov.EstadoProveedor,
                                            FechaCreacionJS = prov.FechaCreacion.ToString()
                                        }).ToList();
                    }
                    else
                    {
                        listaProveedor = (from prov in db.Proveedor
                                          where prov.EstadoEliminacion == false && prov.EstadoProveedor == estado
                                          select new ProveedorCLS
                                          {
                                              IdProveedor = prov.IdProveedor,
                                              NroDocumento = prov.NroDocumentoProveedor,
                                              NombreProveedor = prov.NombreProveedor,
                                              DireccionProveedor = prov.DireccionProveedor,
                                              NombreContacto = prov.NombreContactoProveedor,
                                              NumeroContacto = prov.NumeroContactoProveedor,
                                              IdTipoPersona = prov.IdTipoPersona,
                                              FechaCreacion = prov.FechaCreacion,
                                              UsuarioCreacion = prov.UsuarioCreacion,
                                              FechaModificacion = prov.FechaModificacion,
                                              UsuarioModificacion = prov.UsuarioModificacion,
                                              EstadoProveedor = prov.EstadoProveedor,
                                              FechaCreacionJS = prov.FechaCreacion.ToString()
                                          }).ToList();
                    }
                }
                else
                {
                    if (objFiltro.Estado == 2)
                    {
                        listaProveedor = (from prov in db.Proveedor
                                          where prov.EstadoEliminacion == false && prov.NombreProveedor.Equals(objFiltro.Nombre)
                                          select new ProveedorCLS
                                          {
                                              IdProveedor = prov.IdProveedor,
                                              NroDocumento = prov.NroDocumentoProveedor,
                                              NombreProveedor = prov.NombreProveedor,
                                              DireccionProveedor = prov.DireccionProveedor,
                                              NombreContacto = prov.NombreContactoProveedor,
                                              NumeroContacto = prov.NumeroContactoProveedor,
                                              IdTipoPersona = prov.IdTipoPersona,
                                              FechaCreacion = prov.FechaCreacion,
                                              UsuarioCreacion = prov.UsuarioCreacion,
                                              FechaModificacion = prov.FechaModificacion,
                                              UsuarioModificacion = prov.UsuarioModificacion,
                                              EstadoProveedor = prov.EstadoProveedor,
                                              FechaCreacionJS = prov.FechaCreacion.ToString()
                                          }).ToList();
                    }
                    else
                    {
                        listaProveedor = (from prov in db.Proveedor
                                          where prov.EstadoEliminacion == false && prov.EstadoProveedor == estado && prov.NombreProveedor.Equals(objFiltro.Nombre)
                                          select new ProveedorCLS
                                          {
                                              IdProveedor = prov.IdProveedor,
                                              NroDocumento = prov.NroDocumentoProveedor,
                                              NombreProveedor = prov.NombreProveedor,
                                              DireccionProveedor = prov.DireccionProveedor,
                                              NombreContacto = prov.NombreContactoProveedor,
                                              NumeroContacto = prov.NumeroContactoProveedor,
                                              IdTipoPersona = prov.IdTipoPersona,
                                              FechaCreacion = prov.FechaCreacion,
                                              UsuarioCreacion = prov.UsuarioCreacion,
                                              FechaModificacion = prov.FechaModificacion,
                                              UsuarioModificacion = prov.UsuarioModificacion,
                                              EstadoProveedor = prov.EstadoProveedor,
                                              FechaCreacionJS = prov.FechaCreacion.ToString()
                                          }).ToList();
                    }
                }
            }
            return listaProveedor;
        }

        public ProveedorCLS ObtenerProveedorPorId(int idProv)
        {
            ProveedorCLS objProveedorCLS = new ProveedorCLS();
            using (var db = new BDVentasEntities())
            {
                Proveedor oProveedor = db.Proveedor.Where(p => p.IdProveedor.Equals(idProv)).First();
                objProveedorCLS.IdProveedor = oProveedor.IdProveedor;
                objProveedorCLS.IdTipoPersona = oProveedor.IdTipoPersona;
                objProveedorCLS.NombreProveedor = oProveedor.NombreProveedor;
                objProveedorCLS.DireccionProveedor = oProveedor.DireccionProveedor;
                objProveedorCLS.NombreContacto = oProveedor.NombreContactoProveedor;
                objProveedorCLS.NumeroContacto = oProveedor.NumeroContactoProveedor;

            }
            return objProveedorCLS;
        }

        public int EliminarProveedor(ProveedorCLS objProveedorCLS)
        {
            int cdgoRpt = 0;
            try
            {
                using (var db = new BDVentasEntities())
                {
                    Proveedor oProveedor = db.Proveedor.Where(p => p.IdProveedor.Equals(objProveedorCLS.IdProveedor)).First();
                    oProveedor.EstadoEliminacion = true;
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

        public int CambiarEstadoProveedor(ProveedorCLS objProveedorCLS)
        {
            int codigoRpt = 0;
            try
            {
                using (var db = new BDVentasEntities())
                {
                    Proveedor oProveedor = db.Proveedor.Where(p => p.IdProveedor.Equals(objProveedorCLS.IdProveedor)).First();

                    if (oProveedor.EstadoProveedor)
                        objProveedorCLS.EstadoProveedor = false;
                    else
                        objProveedorCLS.EstadoProveedor = true;

                    oProveedor.EstadoProveedor = objProveedorCLS.EstadoProveedor;
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

        public int EditarProveedor(ProveedorCLS objProveedorCLS)
        {
            int cdgoRpt = 0;
            try
            {
                using (var db = new BDVentasEntities())
                {
                    Proveedor oProveedor = db.Proveedor.Where(p => p.IdProveedor.Equals(objProveedorCLS.IdProveedor)).First();
                    oProveedor.NroDocumentoProveedor = objProveedorCLS.NroDocumento;
                    oProveedor.IdProveedor = objProveedorCLS.IdProveedor;
                    oProveedor.IdTipoPersona = objProveedorCLS.IdTipoPersona;
                    oProveedor.NombreProveedor = objProveedorCLS.NombreProveedor;
                    oProveedor.DireccionProveedor = objProveedorCLS.DireccionProveedor;
                    oProveedor.NombreContactoProveedor = objProveedorCLS.NombreContacto;
                    oProveedor.NumeroContactoProveedor = objProveedorCLS.NumeroContacto;
                    oProveedor.FechaModificacion = DateTime.Now;
                    oProveedor.UsuarioModificacion = "Admin";
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
