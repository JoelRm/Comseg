using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Datos.Modelos;
using Entidad;


namespace Datos.Clases
{
    public class TipoTiendaDA
    {
        public List<TipoTiendaCLS> ListarTipoTiendas()
        {
            List<TipoTiendaCLS> listaTipoTienda = null;
            using (var db = new BDVentasEntities())
            {
                listaTipoTienda = (from tnd in db.TipoTienda
                              where tnd.EstadoEliminacion == false
                              select new TipoTiendaCLS
                              {
                                  IdTipoTienda = tnd.IdTipoTienda,
                                  NombreTipoTienda = tnd.NombreTipoTienda,
                                  FechaCreacion = tnd.FechaCreacion,
                                  UsuarioCreacion = tnd.UsuarioCreacion,
                                  FechaModificacion = tnd.FechaModificacion,
                                  UsuarioModificacion = tnd.UsuarioModificacion,
                                  EstadoTipoTienda = tnd.EstadoTipoTienda,
                                  FechaCreacionJS = tnd.FechaCreacion.ToString()
                              }).ToList();

                return listaTipoTienda;
            }
        }


        public int AgregarTipoTienda(TipoTiendaCLS objTipoTiendaCls)
        {
            int CodResult = 0;
            try
            {
                using (var db = new BDVentasEntities())
                {
                    TipoTienda objTipoTienda = new TipoTienda();
                    objTipoTienda.NombreTipoTienda = objTipoTiendaCls.NombreTipoTienda;
                    objTipoTienda.FechaCreacion = DateTime.Now;
                    objTipoTienda.UsuarioCreacion = "Admin";
                    objTipoTienda.FechaModificacion = DateTime.Now;
                    objTipoTienda.UsuarioModificacion = "Admin";
                    objTipoTienda.EstadoTipoTienda = true;
                    objTipoTienda.EstadoEliminacion = false;
                    db.TipoTienda.Add(objTipoTienda);
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


        public int CambiarEstadoTipoTienda(TipoTiendaCLS objTipoTiendaCls)
        {
            int codigoRpt = 0;
            try
            {
                using (var db = new BDVentasEntities())
                {
                    TipoTienda oTipoTienda = db.TipoTienda.Where(p => p.IdTipoTienda.Equals(objTipoTiendaCls.IdTipoTienda)).First();

                    if (oTipoTienda.EstadoTipoTienda)
                        objTipoTiendaCls.EstadoTipoTienda = false;
                    else
                        objTipoTiendaCls.EstadoTipoTienda = true;

                    oTipoTienda.EstadoTipoTienda = objTipoTiendaCls.EstadoTipoTienda;
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


        public List<TipoTiendaCLS> ListarTipoTiendaPorFiltro(FiltroCLS objFiltro)
        {
            List<TipoTiendaCLS> listaTipoTienda = null;
            bool estado = true;
            if (objFiltro.Estado == 0)
                estado = false;

            using (var db = new BDVentasEntities())
            {
                if (objFiltro.Nombre == "" || objFiltro.Nombre == null)
                {
                    if (objFiltro.Estado == 2)
                    {
                        listaTipoTienda = (from tnd in db.TipoTienda
                                      where tnd.EstadoEliminacion == false
                                      select new TipoTiendaCLS
                                      {
                                          IdTipoTienda = tnd.IdTipoTienda,
                                          NombreTipoTienda = tnd.NombreTipoTienda,
                                          FechaCreacion = tnd.FechaCreacion,
                                          UsuarioCreacion = tnd.UsuarioCreacion,
                                          FechaModificacion = tnd.FechaModificacion,
                                          UsuarioModificacion = tnd.UsuarioModificacion,
                                          EstadoTipoTienda = tnd.EstadoTipoTienda,
                                          FechaCreacionJS = tnd.FechaCreacion.ToString()
                                      }).ToList();
                    }
                    else
                    {
                        listaTipoTienda = (from tnd in db.TipoTienda
                                      where tnd.EstadoEliminacion == false && tnd.EstadoTipoTienda == estado
                                      select new TipoTiendaCLS
                                      {
                                          IdTipoTienda = tnd.IdTipoTienda,
                                          NombreTipoTienda = tnd.NombreTipoTienda,
                                          FechaCreacion = tnd.FechaCreacion,
                                          UsuarioCreacion = tnd.UsuarioCreacion,
                                          FechaModificacion = tnd.FechaModificacion,
                                          UsuarioModificacion = tnd.UsuarioModificacion,
                                          EstadoTipoTienda = tnd.EstadoTipoTienda,
                                          FechaCreacionJS = tnd.FechaCreacion.ToString()
                                      }).ToList();
                    }
                }
                else
                {
                    if (objFiltro.Estado == 2)
                    {
                        listaTipoTienda = (from tnd in db.TipoTienda
                                      where tnd.EstadoEliminacion == false && tnd.NombreTipoTienda.Contains(objFiltro.Nombre)
                                      select new TipoTiendaCLS
                                      {
                                          IdTipoTienda = tnd.IdTipoTienda,
                                          NombreTipoTienda = tnd.NombreTipoTienda,
                                          FechaCreacion = tnd.FechaCreacion,
                                          UsuarioCreacion = tnd.UsuarioCreacion,
                                          FechaModificacion = tnd.FechaModificacion,
                                          UsuarioModificacion = tnd.UsuarioModificacion,
                                          EstadoTipoTienda = tnd.EstadoTipoTienda,
                                          FechaCreacionJS = tnd.FechaCreacion.ToString()
                                      }).ToList();
                    }
                    else
                    {
                        listaTipoTienda = (from tnd in db.TipoTienda
                                      where tnd.EstadoEliminacion == false && tnd.EstadoTipoTienda == estado && tnd.NombreTipoTienda.Contains(objFiltro.Nombre) && tnd.EstadoTipoTienda == estado
                                      select new TipoTiendaCLS
                                      {
                                          IdTipoTienda = tnd.IdTipoTienda,
                                          NombreTipoTienda = tnd.NombreTipoTienda,
                                          FechaCreacion = tnd.FechaCreacion,
                                          UsuarioCreacion = tnd.UsuarioCreacion,
                                          FechaModificacion = tnd.FechaModificacion,
                                          UsuarioModificacion = tnd.UsuarioModificacion,
                                          EstadoTipoTienda = tnd.EstadoTipoTienda,
                                          FechaCreacionJS = tnd.FechaCreacion.ToString()
                                      }).ToList();
                    }
                }
            }
            return listaTipoTienda;
        }


        public int EliminarTipoTienda(TipoTiendaCLS objTipoTiendaCls)
        {
            int cdgoRpt = 0;
            try
            {
                using (var db = new BDVentasEntities())
                {
                    TipoTienda oTipoTienda = db.TipoTienda.Where(p => p.IdTipoTienda.Equals(objTipoTiendaCls.IdTipoTienda)).First();
                    oTipoTienda.EstadoEliminacion = true;
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


        public TipoTiendaCLS ObtenerTipoTiendaPorId(int idTipoTienda)
        {
            TipoTiendaCLS objTipoTiendaCls = new TipoTiendaCLS();
            using (var db = new BDVentasEntities())
            {
                TipoTienda oTipoTienda = db.TipoTienda.Where(p => p.IdTipoTienda.Equals(idTipoTienda)).First();
                objTipoTiendaCls.IdTipoTienda = oTipoTienda.IdTipoTienda;
                objTipoTiendaCls.NombreTipoTienda = oTipoTienda.NombreTipoTienda;
            }
            return objTipoTiendaCls;
        }


        public int EditarTipoTienda(TipoTiendaCLS objTipoTiendaCls)
        {
            int cdgoRpt = 0;
            try
            {
                using (var db = new BDVentasEntities())
                {
                    TipoTienda oLinea = db.TipoTienda.Where(p => p.IdTipoTienda.Equals(objTipoTiendaCls.IdTipoTienda)).First();
                    oLinea.NombreTipoTienda = objTipoTiendaCls.NombreTipoTienda;
                    objTipoTiendaCls.FechaModificacion = DateTime.Now;
                    objTipoTiendaCls.UsuarioModificacion = "Admin";
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
