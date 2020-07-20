using Datos.Modelos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        
        public int CambiarEstado(UnidadCLS objunidadCLS)
        {
            int codigoRpt = 0;
            try
            {
                using (var db = new BDVentasEntities())
                {
                    Unidad oUnidad = db.Unidad.Where(p => p.IdUnidad.Equals(objunidadCLS.IdUnidad)).First();

                    if (oUnidad.EstadoUnidad)
                        objunidadCLS.EstadoUnidad = false;
                    else
                        objunidadCLS.EstadoUnidad = true;

                    oUnidad.EstadoUnidad = objunidadCLS.EstadoUnidad;
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

    }
}
