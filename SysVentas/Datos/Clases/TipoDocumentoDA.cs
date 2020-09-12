using Datos.Modelos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Datos.Clases
{
    public class TipoDocumentoDA
    {
        public List<TipoDocumentoCLS> ListarTipoDocumento()
        {
            List<TipoDocumentoCLS> listaTipoDocumento = null;
            using (var db = new BDVentasEntities())
            {
                listaTipoDocumento = (from TipoD in db.TipoDocumento
                                    where TipoD.EstadoEliminacion == false && TipoD.EstadoTipoDocumento == true
                                    select new TipoDocumentoCLS
                                    {
                                        IdTipoDocumento = TipoD.IdTipoDocumento,
                                        DescripcionTipoDocumento = TipoD.DescripcionTipoDocumento,
                                        AbreviacionTipoDocumento = TipoD.AbreviacionTipoDocumento,
                                        LongitudTipoDocumento = TipoD.LongitudTipoDocumento,
                                        FechaCreacion = TipoD.FechaCreacion,
                                        UsuarioCreacion = TipoD.UsuarioCreacion,
                                        FechaModificacion = TipoD.FechaModificacion,
                                        UsuarioModificacion = TipoD.UsuarioModificacion,
                                        EstadoTipoDocumento = TipoD.EstadoTipoDocumento,
                                        FechaCreacionJS = TipoD.FechaCreacion.ToString()
                                    }).ToList();

                return listaTipoDocumento;
            }
        }


        public int AgregarTipoDocumento(TipoDocumentoCLS objTipoDocumentoCLS)
        {
            int CodResult = 0;
            try
            {
                using (var db = new BDVentasEntities())
                {
                    TipoDocumento objTipoDocumento = new TipoDocumento();
                    objTipoDocumento.DescripcionTipoDocumento = objTipoDocumentoCLS.DescripcionTipoDocumento;
                    objTipoDocumento.AbreviacionTipoDocumento = objTipoDocumentoCLS.AbreviacionTipoDocumento;
                    objTipoDocumento.LongitudTipoDocumento = objTipoDocumentoCLS.LongitudTipoDocumento;
                    objTipoDocumento.FechaCreacion = DateTime.Now;
                    objTipoDocumento.UsuarioCreacion = "Admin";
                    objTipoDocumento.FechaModificacion = DateTime.Now;
                    objTipoDocumento.UsuarioModificacion = "Admin";
                    objTipoDocumento.EstadoTipoDocumento = true;
                    objTipoDocumento.EstadoEliminacion = false;
                    db.TipoDocumento.Add(objTipoDocumento);
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


        public int CambiarEstadoTipoDocumento(TipoDocumentoCLS objTipoDocumentoCLS)
        {
            int codigoRpt = 0;
            try
            {
                using (var db = new BDVentasEntities())
                {
                    TipoDocumento oTipoDocumento = db.TipoDocumento.Where(p => p.IdTipoDocumento.Equals(objTipoDocumentoCLS.IdTipoDocumento)).First();

                    if (oTipoDocumento.EstadoTipoDocumento)
                        objTipoDocumentoCLS.EstadoTipoDocumento = false;
                    else
                        objTipoDocumentoCLS.EstadoTipoDocumento = true;

                    oTipoDocumento.EstadoTipoDocumento = objTipoDocumentoCLS.EstadoTipoDocumento;
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


        public List<TipoDocumentoCLS> ListarTipoDocumentoPorFiltro(FiltroCLS objFiltro)
        {
            List<TipoDocumentoCLS> listaTipoDocumento = null;
            bool estado = true;
            if (objFiltro.Estado == 0)
                estado = false;

            using (var db = new BDVentasEntities())
            {
                if (objFiltro.Nombre == "" || objFiltro.Nombre == null)
                {
                    if (objFiltro.Estado == 2)
                    {
                        listaTipoDocumento = (from TipoD in db.TipoDocumento
                                            where TipoD.EstadoEliminacion == false
                                            select new TipoDocumentoCLS
                                            {
                                                IdTipoDocumento = TipoD.IdTipoDocumento,
                                                DescripcionTipoDocumento = TipoD.DescripcionTipoDocumento,
                                                AbreviacionTipoDocumento = TipoD.AbreviacionTipoDocumento,
                                                LongitudTipoDocumento = TipoD.LongitudTipoDocumento,
                                                FechaCreacion = TipoD.FechaCreacion,
                                                UsuarioCreacion = TipoD.UsuarioCreacion,
                                                FechaModificacion = TipoD.FechaModificacion,
                                                UsuarioModificacion = TipoD.UsuarioModificacion,
                                                EstadoTipoDocumento = TipoD.EstadoTipoDocumento,
                                                FechaCreacionJS = TipoD.FechaCreacion.ToString()
                                            }).ToList();
                    }
                    else
                    {
                        listaTipoDocumento = (from TipoD in db.TipoDocumento
                                              where TipoD.EstadoEliminacion == false && TipoD.EstadoTipoDocumento == estado
                                            select new TipoDocumentoCLS
                                            {
                                                IdTipoDocumento = TipoD.IdTipoDocumento,
                                                DescripcionTipoDocumento = TipoD.DescripcionTipoDocumento,
                                                AbreviacionTipoDocumento = TipoD.AbreviacionTipoDocumento,
                                                LongitudTipoDocumento = TipoD.LongitudTipoDocumento,
                                                FechaCreacion = TipoD.FechaCreacion,
                                                UsuarioCreacion = TipoD.UsuarioCreacion,
                                                FechaModificacion = TipoD.FechaModificacion,
                                                UsuarioModificacion = TipoD.UsuarioModificacion,
                                                EstadoTipoDocumento = TipoD.EstadoTipoDocumento,
                                                FechaCreacionJS = TipoD.FechaCreacion.ToString()
                                            }).ToList();
                    }
                }
                else
                {
                    if (objFiltro.Estado == 2)
                    {
                        listaTipoDocumento = (from TipoD in db.TipoDocumento
                                              where TipoD.EstadoEliminacion == false && TipoD.DescripcionTipoDocumento.Contains(objFiltro.Nombre)
                                            select new TipoDocumentoCLS
                                            {
                                                IdTipoDocumento = TipoD.IdTipoDocumento,
                                                DescripcionTipoDocumento = TipoD.DescripcionTipoDocumento,
                                                AbreviacionTipoDocumento = TipoD.AbreviacionTipoDocumento,
                                                LongitudTipoDocumento = TipoD.LongitudTipoDocumento,
                                                FechaCreacion = TipoD.FechaCreacion,
                                                UsuarioCreacion = TipoD.UsuarioCreacion,
                                                FechaModificacion = TipoD.FechaModificacion,
                                                UsuarioModificacion = TipoD.UsuarioModificacion,
                                                EstadoTipoDocumento = TipoD.EstadoTipoDocumento,
                                                FechaCreacionJS = TipoD.FechaCreacion.ToString()
                                            }).ToList();
                    }
                    else
                    {
                        listaTipoDocumento = (from TipoD in db.TipoDocumento
                                              where TipoD.EstadoEliminacion == false && TipoD.EstadoTipoDocumento == estado && TipoD.DescripcionTipoDocumento.Contains(objFiltro.Nombre)
                                            select new TipoDocumentoCLS
                                            {
                                                IdTipoDocumento = TipoD.IdTipoDocumento,
                                                DescripcionTipoDocumento = TipoD.DescripcionTipoDocumento,
                                                AbreviacionTipoDocumento = TipoD.AbreviacionTipoDocumento,
                                                LongitudTipoDocumento = TipoD.LongitudTipoDocumento,
                                                FechaCreacion = TipoD.FechaCreacion,
                                                UsuarioCreacion = TipoD.UsuarioCreacion,
                                                FechaModificacion = TipoD.FechaModificacion,
                                                UsuarioModificacion = TipoD.UsuarioModificacion,
                                                EstadoTipoDocumento = TipoD.EstadoTipoDocumento,
                                                FechaCreacionJS = TipoD.FechaCreacion.ToString()
                                            }).ToList();
                    }
                }
            }
            return listaTipoDocumento;
        }


        public int EliminarTipoDocumento(TipoDocumentoCLS objTipoDocumentoCLS)
        {
            int cdgoRpt = 0;
            try
            {
                using (var db = new BDVentasEntities())
                {
                    TipoDocumento oTipoDocumento = db.TipoDocumento.Where(p => p.IdTipoDocumento.Equals(objTipoDocumentoCLS.IdTipoDocumento)).First();
                    oTipoDocumento.EstadoEliminacion = true;
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


        public TipoDocumentoCLS ObtenerTipoDocumentoPorId(int idTipoDocumento)
        {
            TipoDocumentoCLS objTipoDocumentoCls = new TipoDocumentoCLS();
            using (var db = new BDVentasEntities())
            {
                TipoDocumento oTipoDocumento = db.TipoDocumento.Where(p => p.IdTipoDocumento.Equals(idTipoDocumento)).First();
                objTipoDocumentoCls.IdTipoDocumento = oTipoDocumento.IdTipoDocumento;
                objTipoDocumentoCls.DescripcionTipoDocumento = oTipoDocumento.DescripcionTipoDocumento;
                objTipoDocumentoCls.AbreviacionTipoDocumento = oTipoDocumento.AbreviacionTipoDocumento;
                objTipoDocumentoCls.LongitudTipoDocumento = oTipoDocumento.LongitudTipoDocumento;
            }
            return objTipoDocumentoCls;
        }


        public int EditarTipoDocumento(TipoDocumentoCLS objTipoDocumentoCLS)
        {
            int cdgoRpt = 0;
            try
            {
                using (var db = new BDVentasEntities())
                {
                    TipoDocumento oTipoDocumento = db.TipoDocumento.Where(p => p.IdTipoDocumento.Equals(objTipoDocumentoCLS.IdTipoDocumento)).First();
                    oTipoDocumento.DescripcionTipoDocumento = objTipoDocumentoCLS.DescripcionTipoDocumento;
                    oTipoDocumento.AbreviacionTipoDocumento = objTipoDocumentoCLS.AbreviacionTipoDocumento;
                    oTipoDocumento.LongitudTipoDocumento = objTipoDocumentoCLS.LongitudTipoDocumento;
                    oTipoDocumento.FechaModificacion = DateTime.Now;
                    oTipoDocumento.UsuarioModificacion = "Admin";
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
