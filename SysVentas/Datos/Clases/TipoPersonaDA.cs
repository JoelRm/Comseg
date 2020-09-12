using System;
using System.Collections.Generic;
using System.Linq;
using Datos.Modelos;
using Entidad;



namespace Datos.Clases
{
    public class TipoPersonaDA
    {
        public List<TipoPersonaCLS> ListarTipoPersona()
        {
            List<TipoPersonaCLS> listaTipoPersona = null;
            using (var db = new BDVentasEntities())
            {
                listaTipoPersona = (from per in db.TipoPersona
                                   where per.EstadoEliminacion == false && per.EstadoTipoPersona == true
                                   select new TipoPersonaCLS
                                   {
                                       IdTipoPersona = per.IdTipoPersona,
                                       NombreTipoPersona = per.NombreTipoPersona,
                                       FechaCreacion = per.FechaCreacion,
                                       UsuarioCreacion = per.UsuarioCreacion,
                                       FechaModificacion = per.FechaModificacion,
                                       UsuarioModificacion = per.UsuarioModificacion,
                                       EstadoTipoPersona = per.EstadoTipoPersona,
                                       FechaCreacionJS = per.FechaCreacion.ToString()
                                   }).ToList();

                return listaTipoPersona;
            }
        }


        public int AgregarTipoPersona(TipoPersonaCLS objTipoPersonaCls)
        {
            int CodResult = 0;
            try
            {
                using (var db = new BDVentasEntities())
                {
                    TipoPersona objTipoPersona = new TipoPersona();
                    objTipoPersona.NombreTipoPersona = objTipoPersonaCls.NombreTipoPersona;
                    objTipoPersona.FechaCreacion = DateTime.Now;
                    objTipoPersona.UsuarioCreacion = "Admin";
                    objTipoPersona.FechaModificacion = DateTime.Now;
                    objTipoPersona.UsuarioModificacion = "Admin";
                    objTipoPersona.EstadoTipoPersona = true;
                    objTipoPersona.EstadoEliminacion = false;
                    db.TipoPersona.Add(objTipoPersona);
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


        public int CambiarEstadoTipoPersona(TipoPersonaCLS objTipoPersonaCls)
        {
            int codigoRpt = 0;
            try
            {
                using (var db = new BDVentasEntities())
                {
                    TipoPersona oTipoPersona = db.TipoPersona.Where(p => p.IdTipoPersona.Equals(objTipoPersonaCls.IdTipoPersona)).First();

                    if (oTipoPersona.EstadoTipoPersona)
                        objTipoPersonaCls.EstadoTipoPersona = false;
                    else
                        objTipoPersonaCls.EstadoTipoPersona = true;

                    oTipoPersona.EstadoTipoPersona = objTipoPersonaCls.EstadoTipoPersona;
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


        public List<TipoPersonaCLS> ListarTipoPersonaPorFiltro(FiltroCLS objFiltro)
        {
            List<TipoPersonaCLS> listaTipoPersona = null;
            bool estado = true;
            if (objFiltro.Estado == 0)
                estado = false;

            using (var db = new BDVentasEntities())
            {
                if (objFiltro.Nombre == "" || objFiltro.Nombre == null)
                {
                    if (objFiltro.Estado == 2)
                    {
                        listaTipoPersona = (from per in db.TipoPersona
                                           where per.EstadoEliminacion == false
                                           select new TipoPersonaCLS
                                           {
                                               IdTipoPersona = per.IdTipoPersona,
                                               NombreTipoPersona = per.NombreTipoPersona,
                                               FechaCreacion = per.FechaCreacion,
                                               UsuarioCreacion = per.UsuarioCreacion,
                                               FechaModificacion = per.FechaModificacion,
                                               UsuarioModificacion = per.UsuarioModificacion,
                                               EstadoTipoPersona = per.EstadoTipoPersona,
                                               FechaCreacionJS = per.FechaCreacion.ToString()
                                           }).ToList();
                    }
                    else
                    {
                        listaTipoPersona = (from per in db.TipoPersona
                                           where per.EstadoEliminacion == false && per.EstadoTipoPersona == estado
                                           select new TipoPersonaCLS
                                           {
                                               IdTipoPersona = per.IdTipoPersona,
                                               NombreTipoPersona = per.NombreTipoPersona,
                                               FechaCreacion = per.FechaCreacion,
                                               UsuarioCreacion = per.UsuarioCreacion,
                                               FechaModificacion = per.FechaModificacion,
                                               UsuarioModificacion = per.UsuarioModificacion,
                                               EstadoTipoPersona = per.EstadoTipoPersona,
                                               FechaCreacionJS = per.FechaCreacion.ToString()
                                           }).ToList();
                    }
                }
                else
                {
                    if (objFiltro.Estado == 2)
                    {
                        listaTipoPersona = (from per in db.TipoPersona
                                           where per.EstadoEliminacion == false && per.NombreTipoPersona.Contains(objFiltro.Nombre)
                                           select new TipoPersonaCLS
                                           {
                                               IdTipoPersona = per.IdTipoPersona,
                                               NombreTipoPersona = per.NombreTipoPersona,
                                               FechaCreacion = per.FechaCreacion,
                                               UsuarioCreacion = per.UsuarioCreacion,
                                               FechaModificacion = per.FechaModificacion,
                                               UsuarioModificacion = per.UsuarioModificacion,
                                               EstadoTipoPersona = per.EstadoTipoPersona,
                                               FechaCreacionJS = per.FechaCreacion.ToString()
                                           }).ToList();
                    }
                    else
                    {
                        listaTipoPersona = (from per in db.TipoPersona
                                           where per.EstadoEliminacion == false && per.EstadoTipoPersona == estado && per.NombreTipoPersona.Contains(objFiltro.Nombre)
                                           select new TipoPersonaCLS
                                           {
                                               IdTipoPersona = per.IdTipoPersona,
                                               NombreTipoPersona = per.NombreTipoPersona,
                                               FechaCreacion = per.FechaCreacion,
                                               UsuarioCreacion = per.UsuarioCreacion,
                                               FechaModificacion = per.FechaModificacion,
                                               UsuarioModificacion = per.UsuarioModificacion,
                                               EstadoTipoPersona = per.EstadoTipoPersona,
                                               FechaCreacionJS = per.FechaCreacion.ToString()
                                           }).ToList();
                    }
                }
            }
            return listaTipoPersona;
        }


        public int EliminarTipoPersona(TipoPersonaCLS objTipoPersonaCls)
        {
            int cdgoRpt = 0;
            try
            {
                using (var db = new BDVentasEntities())
                {
                    TipoPersona oTipoPersona = db.TipoPersona.Where(p => p.IdTipoPersona.Equals(objTipoPersonaCls.IdTipoPersona)).First();
                    oTipoPersona.EstadoEliminacion = true;
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


        public TipoPersonaCLS ObtenerTipoPersonaPorId(int idTipoPersona)
        {
            TipoPersonaCLS objTipoPersonaCls = new TipoPersonaCLS();
            using (var db = new BDVentasEntities())
            {
                TipoPersona oTipoPersona = db.TipoPersona.Where(p => p.IdTipoPersona.Equals(idTipoPersona)).First();
                objTipoPersonaCls.IdTipoPersona = oTipoPersona.IdTipoPersona;
                objTipoPersonaCls.NombreTipoPersona = oTipoPersona.NombreTipoPersona;
            }
            return objTipoPersonaCls;
        }


        public int EditarTipoPersona(TipoPersonaCLS objTipoPersonaCls)
        {
            int cdgoRpt = 0;
            try
            {
                using (var db = new BDVentasEntities())
                {
                    TipoPersona oTipoPersona = db.TipoPersona.Where(p => p.IdTipoPersona.Equals(objTipoPersonaCls.IdTipoPersona)).First();
                    oTipoPersona.NombreTipoPersona = objTipoPersonaCls.NombreTipoPersona;
                    oTipoPersona.FechaModificacion = DateTime.Now;
                    oTipoPersona.UsuarioModificacion = "Admin";
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
