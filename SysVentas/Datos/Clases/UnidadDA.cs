using Datos.Modelos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Datos.Clases
{
    public class UnidadDA
    {
        public List<UnidadCLS> ListarUnidades()
        {
            List<UnidadCLS> listaUnidades = null;
            using (var db = new BDVentasEntities())
            {
                listaUnidades = (from und in db.Unidad
                                 where und.EstadoEliminacion == false
                                 select new UnidadCLS
                                 {
                                     IdUnidad = und.IdUnidad,
                                     NombreUnidad = und.NombreUnidad,
                                     Factor = und.Factor,
                                     FechaCreacion = und.FechaCreacion,
                                     UsuarioCreacion = und.UsuarioCreacion,
                                     FechaModificacion = und.FechaModificacion,
                                     UsuarioModificacion = und.UsuarioModificacion,
                                     EstadoUnidad = und.EstadoUnidad,
                                     FechaCreacionJS = und.FechaCreacion.ToString()
                                 }).ToList();

                return listaUnidades;
            }
        }

        public int AgregarUnidad(UnidadCLS objUnidadCls)
        {
            int CodResult = 0;
            try
            {
                using (var db = new BDVentasEntities())
                {
                    Unidad objUnidad = new Unidad();
                    objUnidad.NombreUnidad = objUnidadCls.NombreUnidad;
                    objUnidad.Factor = objUnidadCls.Factor;
                    objUnidad.FechaCreacion = DateTime.Now;
                    objUnidad.UsuarioCreacion = "Admin";
                    objUnidad.FechaModificacion = DateTime.Now;
                    objUnidad.UsuarioModificacion = "Admin";
                    objUnidad.EstadoUnidad = true;
                    objUnidad.EstadoEliminacion = false;
                    db.Unidad.Add(objUnidad);
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
        
        public int CambiarEstado(UnidadCLS objUnidadCls)
        {
            int codigoRpt = 0;
            try
            {
                using (var db = new BDVentasEntities())
                {
                    Unidad oUnidad = db.Unidad.Where(p => p.IdUnidad.Equals(objUnidadCls.IdUnidad)).First();

                    if (oUnidad.EstadoUnidad)
                        objUnidadCls.EstadoUnidad = false;
                    else
                        objUnidadCls.EstadoUnidad = true;

                    oUnidad.EstadoUnidad = objUnidadCls.EstadoUnidad;
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

        public List<UnidadCLS> ListarUnidadesPorFiltro(FiltroCLS objFiltro)
        {
            List<UnidadCLS> listaUnidades = null;
            bool estado = true;
            if (objFiltro.Estado == 0)
                estado = false;

            using (var db = new BDVentasEntities())
            {
                if (objFiltro.Nombre == "" || objFiltro.Nombre == null)
                {
                    if (objFiltro.Estado == 2)
                    {
                        listaUnidades = (from und in db.Unidad
                                         where und.EstadoEliminacion == false
                                         select new UnidadCLS
                                         {
                                             IdUnidad = und.IdUnidad,
                                             NombreUnidad = und.NombreUnidad,
                                             Factor = und.Factor,
                                             FechaCreacion = und.FechaCreacion,
                                             UsuarioCreacion = und.UsuarioCreacion,
                                             FechaModificacion = und.FechaModificacion,
                                             UsuarioModificacion = und.UsuarioModificacion,
                                             EstadoUnidad = und.EstadoUnidad,
                                             FechaCreacionJS = und.FechaCreacion.ToString()
                                         }).ToList();
                    }
                    else
                    {
                        listaUnidades = (from und in db.Unidad
                                         where und.EstadoEliminacion == false && und.EstadoUnidad == estado
                                         select new UnidadCLS
                                         {
                                             IdUnidad = und.IdUnidad,
                                             NombreUnidad = und.NombreUnidad,
                                             Factor = und.Factor,
                                             FechaCreacion = und.FechaCreacion,
                                             UsuarioCreacion = und.UsuarioCreacion,
                                             FechaModificacion = und.FechaModificacion,
                                             UsuarioModificacion = und.UsuarioModificacion,
                                             EstadoUnidad = und.EstadoUnidad,
                                             FechaCreacionJS = und.FechaCreacion.ToString()
                                         }).ToList();
                    }
                }
                else
                {
                    if (objFiltro.Estado == 2)
                    {
                        listaUnidades = (from und in db.Unidad
                                         where und.EstadoEliminacion == false && und.NombreUnidad.Contains(objFiltro.Nombre)
                                         select new UnidadCLS
                                         {
                                             IdUnidad = und.IdUnidad,
                                             NombreUnidad = und.NombreUnidad,
                                             Factor = und.Factor,
                                             FechaCreacion = und.FechaCreacion,
                                             UsuarioCreacion = und.UsuarioCreacion,
                                             FechaModificacion = und.FechaModificacion,
                                             UsuarioModificacion = und.UsuarioModificacion,
                                             EstadoUnidad = und.EstadoUnidad,
                                             FechaCreacionJS = und.FechaCreacion.ToString()
                                         }).ToList();
                    }
                    else
                    {
                        listaUnidades = (from und in db.Unidad
                                         where und.EstadoEliminacion == false && und.EstadoUnidad == estado && und.NombreUnidad.Contains(objFiltro.Nombre) && und.EstadoUnidad == estado
                                         select new UnidadCLS
                                         {
                                             IdUnidad = und.IdUnidad,
                                             NombreUnidad = und.NombreUnidad,
                                             Factor = und.Factor,
                                             FechaCreacion = und.FechaCreacion,
                                             UsuarioCreacion = und.UsuarioCreacion,
                                             FechaModificacion = und.FechaModificacion,
                                             UsuarioModificacion = und.UsuarioModificacion,
                                             EstadoUnidad = und.EstadoUnidad,
                                             FechaCreacionJS = und.FechaCreacion.ToString()
                                         }).ToList();
                    }
                }
            }
            return listaUnidades;
        }

        public int EliminarUnidad(UnidadCLS objUnidadCls)
        {
            int cdgoRpt = 0;
            try
            {
                using (var db = new BDVentasEntities())
                {
                    Unidad oUnidad = db.Unidad.Where(p => p.IdUnidad.Equals(objUnidadCls.IdUnidad)).First();
                    oUnidad.EstadoEliminacion = true;
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

        public UnidadCLS ObtenerUnidadPorId(int idUnd)
        {
            UnidadCLS objUnidadCLS = new UnidadCLS();
            using (var db = new BDVentasEntities())
            {
                Unidad oUnidad = db.Unidad.Where(p => p.IdUnidad.Equals(idUnd)).First();
                objUnidadCLS.IdUnidad = oUnidad.IdUnidad;
                objUnidadCLS.NombreUnidad = oUnidad.NombreUnidad;
                objUnidadCLS.Factor = oUnidad.Factor;
            }
            return objUnidadCLS;
        }

        public int EditarUnidad(UnidadCLS objUnidadCls)
        {
            int cdgoRpt = 0;
            try
            {
                using (var db = new BDVentasEntities())
                {
                    Unidad oUnidad = db.Unidad.Where(p => p.IdUnidad.Equals(objUnidadCls.IdUnidad)).First();
                    oUnidad.NombreUnidad = objUnidadCls.NombreUnidad;
                    oUnidad.Factor = objUnidadCls.Factor;
                    oUnidad.FechaModificacion = DateTime.Now;
                    oUnidad.UsuarioModificacion = "Admin";
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

        public List<UnidadCLS> ListarUnidadesPorFiltroProductoUnd(FiltroCLS objFiltroCLS)
        {
            List<UnidadCLS> listaUnidades = null;
            using (var db = new BDVentasEntities())
            {
                if (objFiltroCLS.Cadena == null)
                {
                    listaUnidades = (from und in db.Unidad
                                     where und.EstadoEliminacion == false
                                     select new UnidadCLS
                                     {
                                         IdUnidad = und.IdUnidad,
                                         NombreUnidad = und.NombreUnidad,
                                         Factor = und.Factor,
                                         FechaCreacion = und.FechaCreacion,
                                         UsuarioCreacion = und.UsuarioCreacion,
                                         FechaModificacion = und.FechaModificacion,
                                         UsuarioModificacion = und.UsuarioModificacion,
                                         EstadoUnidad = und.EstadoUnidad,
                                         FechaCreacionJS = und.FechaCreacion.ToString()
                                     }).ToList();
                }
                else
                {

                    string[] prueba = objFiltroCLS.Cadena.Split(',');

                    List<UnidadCLS> obj = new List<UnidadCLS>();

                    for (int i = 0; i < prueba.Length; i++)
                    {
                        obj.Add(new UnidadCLS
                        {
                            IdUnidad = int.Parse(prueba[i])
                        });
                    }


                    listaUnidades = (from und in db.Unidad
                                     where und.EstadoEliminacion == false
                                     select new UnidadCLS
                                     {
                                         IdUnidad = und.IdUnidad,
                                         NombreUnidad = und.NombreUnidad,
                                         Factor = und.Factor,
                                         FechaCreacion = und.FechaCreacion,
                                         UsuarioCreacion = und.UsuarioCreacion,
                                         FechaModificacion = und.FechaModificacion,
                                         UsuarioModificacion = und.UsuarioModificacion,
                                         EstadoUnidad = und.EstadoUnidad,
                                         FechaCreacionJS = und.FechaCreacion.ToString()
                                     }).ToList();

                    listaUnidades = (from list in listaUnidades
                             where !(obj.Any(item2 => item2.IdUnidad == list.IdUnidad))
                             select list).ToList();
                }
            }
            
            

            return listaUnidades;
        }
    }
}
