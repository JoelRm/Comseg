using System;
using System.Collections.Generic;
using System.Linq;
using Entidad;
using Datos.Modelos;

namespace Datos.Clases
{
    public class MonedaDA
    {
        public List<MonedaCLS> ListarMonedas()
        {
            List<MonedaCLS> listaMonedas = null;
            using (var db = new BDVentasEntities())
            {
                listaMonedas = (from mod in db.Moneda
                               where mod.EstadoEliminacion == false
                               select new MonedaCLS
                               {
                                   IdMoneda = mod.IdMoneda,
                                   NombreMoneda = mod.NombreMoneda,
                                   SimboloMoneda = mod.SimboloMoneda,
                                   FechaCreacion = mod.FechaCreacion,
                                   UsuarioCreacion = mod.UsuarioCreacion,
                                   FechaModificacion = mod.FechaModificacion,
                                   UsuarioModificacion = mod.UsuarioModificacion,
                                   EstadoMoneda = mod.EstadoMoneda,
                                   FechaCreacionJS = mod.FechaCreacion.ToString()
                               }).ToList();

                return listaMonedas;
            }
        }

        public int AgregarMoneda(MonedaCLS objMonedaCls)
        {
            int CodResult = 0;
            try
            {
                using (var db = new BDVentasEntities())
                {
                    Moneda objMoneda = new Moneda();
                    objMoneda.NombreMoneda = objMonedaCls.NombreMoneda;
                    objMoneda.SimboloMoneda = objMonedaCls.SimboloMoneda;
                    objMoneda.FechaCreacion = DateTime.Now;
                    objMoneda.UsuarioCreacion = "Admin";
                    objMoneda.FechaModificacion = DateTime.Now;
                    objMoneda.UsuarioModificacion = "Admin";
                    objMoneda.EstadoMoneda = true;
                    objMoneda.EstadoEliminacion = false;
                    db.Moneda.Add(objMoneda);
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

        public int CambiarEstadoMoneda(MonedaCLS objMonedaCls)
        {
            int codigoRpt = 0;
            try
            {
                using (var db = new BDVentasEntities())
                {
                    Moneda oMoneda = db.Moneda.Where(p => p.IdMoneda.Equals(objMonedaCls.IdMoneda)).First();

                    if (oMoneda.EstadoMoneda)
                        objMonedaCls.EstadoMoneda = false;
                    else
                        objMonedaCls.EstadoMoneda = true;

                    oMoneda.EstadoMoneda = objMonedaCls.EstadoMoneda;
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

        public List<MonedaCLS> ListarMonedasPorFiltro(FiltroCLS objFiltro)
        {
            List<MonedaCLS> listaMoneda = null;
            bool estado = true;
            if (objFiltro.Estado == 0)
                estado = false;

            using (var db = new BDVentasEntities())
            {
                if (objFiltro.Nombre == "" || objFiltro.Nombre == null)
                {
                    if (objFiltro.Estado == 2)
                    {
                        listaMoneda = (from mod in db.Moneda
                                      where mod.EstadoEliminacion == false
                                      select new MonedaCLS
                                      {
                                          IdMoneda = mod.IdMoneda,
                                          NombreMoneda = mod.NombreMoneda,
                                          SimboloMoneda = mod.SimboloMoneda,
                                          FechaCreacion = mod.FechaCreacion,
                                          UsuarioCreacion = mod.UsuarioCreacion,
                                          FechaModificacion = mod.FechaModificacion,
                                          UsuarioModificacion = mod.UsuarioModificacion,
                                          EstadoMoneda = mod.EstadoMoneda,
                                          FechaCreacionJS = mod.FechaCreacion.ToString()
                                      }).ToList();
                    }
                    else
                    {
                        listaMoneda = (from mod in db.Moneda
                                      where mod.EstadoEliminacion == false && mod.EstadoMoneda == estado
                                      select new MonedaCLS
                                      {
                                          IdMoneda = mod.IdMoneda,
                                          NombreMoneda = mod.NombreMoneda,
                                          SimboloMoneda = mod.SimboloMoneda,
                                          FechaCreacion = mod.FechaCreacion,
                                          UsuarioCreacion = mod.UsuarioCreacion,
                                          FechaModificacion = mod.FechaModificacion,
                                          UsuarioModificacion = mod.UsuarioModificacion,
                                          EstadoMoneda = mod.EstadoMoneda,
                                          FechaCreacionJS = mod.FechaCreacion.ToString()
                                      }).ToList();
                    }
                }
                else
                {
                    if (objFiltro.Estado == 2)
                    {
                        listaMoneda = (from mod in db.Moneda
                                      where mod.EstadoEliminacion == false && mod.NombreMoneda.Contains(objFiltro.Nombre)
                                      select new MonedaCLS
                                      {
                                          IdMoneda = mod.IdMoneda,
                                          NombreMoneda = mod.NombreMoneda,
                                          SimboloMoneda = mod.SimboloMoneda,
                                          FechaCreacion = mod.FechaCreacion,
                                          UsuarioCreacion = mod.UsuarioCreacion,
                                          FechaModificacion = mod.FechaModificacion,
                                          UsuarioModificacion = mod.UsuarioModificacion,
                                          EstadoMoneda = mod.EstadoMoneda,
                                          FechaCreacionJS = mod.FechaCreacion.ToString()
                                      }).ToList();
                    }
                    else
                    {
                        listaMoneda = (from mod in db.Moneda
                                      where mod.EstadoEliminacion == false && mod.EstadoMoneda == estado && mod.NombreMoneda.Contains(objFiltro.Nombre) && mod.EstadoMoneda == estado
                                      select new MonedaCLS
                                      {
                                          IdMoneda = mod.IdMoneda,
                                          NombreMoneda = mod.NombreMoneda,
                                          SimboloMoneda = mod.SimboloMoneda,
                                          FechaCreacion = mod.FechaCreacion,
                                          UsuarioCreacion = mod.UsuarioCreacion,
                                          FechaModificacion = mod.FechaModificacion,
                                          UsuarioModificacion = mod.UsuarioModificacion,
                                          EstadoMoneda = mod.EstadoMoneda,
                                          FechaCreacionJS = mod.FechaCreacion.ToString()
                                      }).ToList();
                    }
                }
            }
            return listaMoneda;
        }

        public int EliminarMonedas(MonedaCLS objMonedaCls)
        {
            int cdgoRpt = 0;
            try
            {
                using (var db = new BDVentasEntities())
                {
                    Moneda oMoneda = db.Moneda.Where(p => p.IdMoneda.Equals(objMonedaCls.IdMoneda)).First();
                    oMoneda.EstadoEliminacion = true;
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

        public MonedaCLS ObtenerMonedaPorId(int idMoneda)
        {
            MonedaCLS objMonedaCLS = new MonedaCLS();
            using (var db = new BDVentasEntities())
            {
                Moneda oMoneda = db.Moneda.Where(p => p.IdMoneda.Equals(idMoneda)).First();
                objMonedaCLS.IdMoneda = oMoneda.IdMoneda;
                objMonedaCLS.NombreMoneda = oMoneda.NombreMoneda;
            }
            return objMonedaCLS;
        }

        public int EditarMoneda(MonedaCLS objMonedaCls)
        {
            int cdgoRpt = 0;
            try
            {
                using (var db = new BDVentasEntities())
                {
                    Moneda oMoneda = db.Moneda.Where(p => p.IdMoneda.Equals(objMonedaCls.IdMoneda)).First();
                    oMoneda.NombreMoneda = objMonedaCls.NombreMoneda;
                    oMoneda.SimboloMoneda = objMonedaCls.SimboloMoneda;
                    oMoneda.FechaModificacion = DateTime.Now;
                    oMoneda.UsuarioModificacion = "Admin";
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
