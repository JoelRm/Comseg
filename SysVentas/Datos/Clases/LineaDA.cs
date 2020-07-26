using Datos.Modelos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Datos.Clases
{
    public class LineaDA
    {
        public List<LineaCLS> ListarLineas()
        {
            List<LineaCLS> listaLineas = null;
            using (var db = new BDVentasEntities())
            {
                listaLineas = (from lna in db.Linea
                                 where lna.EstadoEliminacion == false
                                 select new LineaCLS
                                 {
                                     IdLinea = lna.IdLinea,
                                     NombreLinea = lna.NombreLinea,
                                     FechaCreacion = lna.FechaCreacion,
                                     UsuarioCreacion = lna.UsuarioCreacion,
                                     FechaModificacion = lna.FechaModificacion,
                                     UsuarioModificacion = lna.UsuarioModificacion,
                                     EstadoLinea = lna.EstadoLinea,
                                     FechaCreacionJS = lna.FechaCreacion.ToString()
                                 }).ToList();

                return listaLineas;
            }    
        }

        public int AgregarLinea(LineaCLS objLineaCls)
        {
            int CodResult = 0;
            try
            {
                using (var db = new BDVentasEntities())
                {
                    Linea objLinea = new Linea();
                    objLinea.NombreLinea = objLineaCls.NombreLinea;
                    objLinea.FechaCreacion = DateTime.Now;
                    objLinea.UsuarioCreacion = "Admin";
                    objLinea.FechaModificacion = DateTime.Now;
                    objLinea.UsuarioModificacion = "Admin";
                    objLinea.EstadoLinea = true;
                    objLinea.EstadoEliminacion = false;
                    db.Linea.Add(objLinea);
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

        public int CambiarEstadoLinea(LineaCLS objLineaCls)
        {
            int codigoRpt = 0;
            try
            {
                using (var db = new BDVentasEntities())
                {
                    Linea oLinea = db.Linea.Where(p => p.IdLinea.Equals(objLineaCls.IdLinea)).First();

                    if (oLinea.EstadoLinea)
                        objLineaCls.EstadoLinea = false;
                    else
                        objLineaCls.EstadoLinea = true;

                    oLinea.EstadoLinea = objLineaCls.EstadoLinea;
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

        public List<LineaCLS> ListarLineasPorFiltro(FiltroCLS objFiltro)
        {
            List<LineaCLS> listaLinea = null;
            bool estado = true;
            if (objFiltro.Estado == 0)
                estado = false;

            using (var db = new BDVentasEntities())
            {
                if (objFiltro.Nombre == "" || objFiltro.Nombre == null)
                {
                    if (objFiltro.Estado == 2)
                    {
                        listaLinea = (from lna in db.Linea
                                         where lna.EstadoEliminacion == false
                                         select new LineaCLS
                                         {
                                             IdLinea = lna.IdLinea,
                                             NombreLinea = lna.NombreLinea,
                                             FechaCreacion = lna.FechaCreacion,
                                             UsuarioCreacion = lna.UsuarioCreacion,
                                             FechaModificacion = lna.FechaModificacion,
                                             UsuarioModificacion = lna.UsuarioModificacion,
                                             EstadoLinea = lna.EstadoLinea,
                                             FechaCreacionJS = lna.FechaCreacion.ToString()
                                         }).ToList();
                    }
                    else
                    {
                        listaLinea = (from lna in db.Linea
                                         where lna.EstadoEliminacion == false && lna.EstadoLinea == estado
                                         select new LineaCLS
                                         {
                                             IdLinea = lna.IdLinea,
                                             NombreLinea = lna.NombreLinea,
                                             FechaCreacion = lna.FechaCreacion,
                                             UsuarioCreacion = lna.UsuarioCreacion,
                                             FechaModificacion = lna.FechaModificacion,
                                             UsuarioModificacion = lna.UsuarioModificacion,
                                             EstadoLinea = lna.EstadoLinea,
                                             FechaCreacionJS = lna.FechaCreacion.ToString()
                                         }).ToList();
                    }
                }
                else
                {
                    if (objFiltro.Estado == 2)
                    {
                        listaLinea = (from lna in db.Linea
                                         where lna.EstadoEliminacion == false && lna.NombreLinea.Contains(objFiltro.Nombre)
                                         select new LineaCLS
                                         {
                                             IdLinea = lna.IdLinea,
                                             NombreLinea = lna.NombreLinea,
                                             FechaCreacion = lna.FechaCreacion,
                                             UsuarioCreacion = lna.UsuarioCreacion,
                                             FechaModificacion = lna.FechaModificacion,
                                             UsuarioModificacion = lna.UsuarioModificacion,
                                             EstadoLinea = lna.EstadoLinea,
                                             FechaCreacionJS = lna.FechaCreacion.ToString()
                                         }).ToList();
                    }
                    else
                    {
                        listaLinea = (from lna in db.Linea
                                         where lna.EstadoEliminacion == false && lna.EstadoLinea == estado && lna.NombreLinea.Contains(objFiltro.Nombre)
                                         select new LineaCLS
                                         {
                                             IdLinea = lna.IdLinea,
                                             NombreLinea = lna.NombreLinea,
                                             FechaCreacion = lna.FechaCreacion,
                                             UsuarioCreacion = lna.UsuarioCreacion,
                                             FechaModificacion = lna.FechaModificacion,
                                             UsuarioModificacion = lna.UsuarioModificacion,
                                             EstadoLinea = lna.EstadoLinea,
                                             FechaCreacionJS = lna.FechaCreacion.ToString()
                                         }).ToList();
                    }
                }
            }
            return listaLinea;
        }

        public int EliminarLineas(LineaCLS objLineaCls)
        {
            int cdgoRpt = 0;
            try
            {
                using (var db = new BDVentasEntities())
                {
                    Linea oLinea = db.Linea.Where(p => p.IdLinea.Equals(objLineaCls.IdLinea)).First();
                    oLinea.EstadoEliminacion = true;
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

        public LineaCLS ObtenerLineaPorId(int idLinea)
        {
            LineaCLS objLineaCLS = new LineaCLS();
            using (var db = new BDVentasEntities())
            {
                Linea oLinea = db.Linea.Where(p => p.IdLinea.Equals(idLinea)).First();
                objLineaCLS.IdLinea = oLinea.IdLinea;
                objLineaCLS.NombreLinea = oLinea.NombreLinea;
            }
            return objLineaCLS;
        }
        
        public int EditarLinea(LineaCLS objLineaCls)
        {
            int cdgoRpt = 0;
            try
            {
                using (var db = new BDVentasEntities())
                {
                    Linea oLinea = db.Linea.Where(p => p.IdLinea.Equals(objLineaCls.IdLinea)).First();
                    oLinea.NombreLinea = objLineaCls.NombreLinea;
                    objLineaCls.FechaModificacion = DateTime.Now;
                    objLineaCls.UsuarioModificacion = "Admin";
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
