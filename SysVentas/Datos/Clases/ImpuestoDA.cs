using System;
using System.Collections.Generic;
using System.Linq;
using Datos.Modelos;
using Entidad;

namespace Datos.Clases
{
    public class ImpuestoDA
    {
        
        public List<ImpuestoCLS> ListarImpuesto()
        {
            List<ImpuestoCLS> listaImpuesto = null;
            using (var db = new BDVentasEntities())
            {
                listaImpuesto = (from imp in db.Impuesto
                                 where imp.EstadoEliminacion == false &&
                                 imp.EstadoImpuesto == true
                                 select new ImpuestoCLS
                                 {
                                     IdImpuesto = imp.IdImpuesto,
                                     NombreImpuesto = imp.NombreImpuesto,
                                     ValorImpuesto = imp.ValorImpuesto,
                                     FechaCreacion = imp.FechaCreacion,
                                     UsuarioCreacion = imp.UsuarioCreacion,
                                     FechaModificacion = imp.FechaModificacion,
                                     UsuarioModificacion = imp.UsuarioModificacion,
                                     EstadoImpuesto = imp.EstadoImpuesto,
                                     FechaCreacionJS = imp.FechaCreacion.ToString()
                                 }).ToList();

                return listaImpuesto;
            }
        }

        public int AgregarImpuesto(ImpuestoCLS objImpuestoCls)
        {
            int CodResult = 0;
            try
            {
                using (var db = new BDVentasEntities())
                {
                    Impuesto objImpuesto = new Impuesto();
                    objImpuesto.NombreImpuesto = objImpuestoCls.NombreImpuesto;
                    objImpuesto.ValorImpuesto = Decimal.Parse(objImpuestoCls.ValorImpuestoJS);
                    objImpuesto.FechaCreacion = DateTime.Now;
                    objImpuesto.UsuarioCreacion = "Admin";
                    objImpuesto.FechaModificacion = DateTime.Now;
                    objImpuesto.UsuarioModificacion = "Admin";
                    objImpuesto.EstadoImpuesto = true;
                    objImpuesto.EstadoEliminacion = false;
                    db.Impuesto.Add(objImpuesto);
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

        public int CambiarEstado(ImpuestoCLS objImpuestoCls)
        {
            int codigoRpt = 0;
            try
            {
                using (var db = new BDVentasEntities())
                {
                    Impuesto oImpuesto = db.Impuesto.Where(p => p.IdImpuesto.Equals(objImpuestoCls.IdImpuesto)).First();

                    if (oImpuesto.EstadoImpuesto)
                        objImpuestoCls.EstadoImpuesto = false;
                    else
                        objImpuestoCls.EstadoImpuesto = true;

                    oImpuesto.EstadoImpuesto = objImpuestoCls.EstadoImpuesto;
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

        public List<ImpuestoCLS> ListarImpuestoPorFiltro(FiltroCLS objFiltro)
        {
            List<ImpuestoCLS> listaImpuesto = null;
            bool estado = true;
            if (objFiltro.Estado == 0)
                estado = false;

            using (var db = new BDVentasEntities())
            {
                if (objFiltro.Nombre == "" || objFiltro.Nombre == null)
                {
                    if (objFiltro.Estado == 2)
                    {
                        listaImpuesto = (from imp in db.Impuesto
                                         where imp.EstadoEliminacion == false
                                         select new ImpuestoCLS
                                         {
                                             IdImpuesto = imp.IdImpuesto,
                                             NombreImpuesto = imp.NombreImpuesto,
                                             ValorImpuesto = imp.ValorImpuesto,
                                             FechaCreacion = imp.FechaCreacion,
                                             UsuarioCreacion = imp.UsuarioCreacion,
                                             FechaModificacion = imp.FechaModificacion,
                                             UsuarioModificacion = imp.UsuarioModificacion,
                                             EstadoImpuesto = imp.EstadoImpuesto,
                                             FechaCreacionJS = imp.FechaCreacion.ToString(),
                                             ValorImpuestoJS = (imp.ValorImpuesto*100).ToString()
                                         }).ToList();
                    }
                    else
                    {
                        listaImpuesto = (from imp in db.Impuesto
                                         where imp.EstadoEliminacion == false && imp.EstadoImpuesto == estado
                                         select new ImpuestoCLS
                                         {
                                             IdImpuesto = imp.IdImpuesto,
                                             NombreImpuesto = imp.NombreImpuesto,
                                             ValorImpuesto = imp.ValorImpuesto,
                                             FechaCreacion = imp.FechaCreacion,
                                             UsuarioCreacion = imp.UsuarioCreacion,
                                             FechaModificacion = imp.FechaModificacion,
                                             UsuarioModificacion = imp.UsuarioModificacion,
                                             EstadoImpuesto = imp.EstadoImpuesto,
                                             FechaCreacionJS = imp.FechaCreacion.ToString(),
                                             ValorImpuestoJS = (imp.ValorImpuesto * 100).ToString()
                                         }).ToList();
                    }
                }
                else
                {
                    if (objFiltro.Estado == 2)
                    {
                        listaImpuesto = (from imp in db.Impuesto
                                         where imp.EstadoEliminacion == false && imp.NombreImpuesto.Contains(objFiltro.Nombre)
                                         select new ImpuestoCLS
                                         {
                                             IdImpuesto = imp.IdImpuesto,
                                             NombreImpuesto = imp.NombreImpuesto,
                                             ValorImpuesto = imp.ValorImpuesto,
                                             FechaCreacion = imp.FechaCreacion,
                                             UsuarioCreacion = imp.UsuarioCreacion,
                                             FechaModificacion = imp.FechaModificacion,
                                             UsuarioModificacion = imp.UsuarioModificacion,
                                             EstadoImpuesto = imp.EstadoImpuesto,
                                             FechaCreacionJS = imp.FechaCreacion.ToString(),
                                             ValorImpuestoJS = (imp.ValorImpuesto * 100).ToString()
                                         }).ToList();
                    }
                    else
                    {
                        listaImpuesto = (from imp in db.Impuesto
                                         where imp.EstadoEliminacion == false && imp.EstadoImpuesto == estado && imp.NombreImpuesto.Contains(objFiltro.Nombre) && imp.EstadoImpuesto == estado
                                         select new ImpuestoCLS
                                         {
                                             IdImpuesto = imp.IdImpuesto,
                                             NombreImpuesto = imp.NombreImpuesto,
                                             ValorImpuesto =  imp.ValorImpuesto,
                                             FechaCreacion = imp.FechaCreacion,
                                             UsuarioCreacion = imp.UsuarioCreacion,
                                             FechaModificacion = imp.FechaModificacion,
                                             UsuarioModificacion = imp.UsuarioModificacion,
                                             EstadoImpuesto = imp.EstadoImpuesto,
                                             FechaCreacionJS = imp.FechaCreacion.ToString(),
                                             ValorImpuestoJS = (imp.ValorImpuesto * 100).ToString()
                                         }).ToList();
                    }
                }
            }
            return listaImpuesto;
        }

        public int EliminarImpuesto(ImpuestoCLS objImpuestoCls)
        {
            int cdgoRpt = 0;
            try
            {
                using (var db = new BDVentasEntities())
                {
                    Impuesto oImpuesto = db.Impuesto.Where(p => p.IdImpuesto.Equals(objImpuestoCls.IdImpuesto)).First();
                    oImpuesto.EstadoEliminacion = true;
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

        public ImpuestoCLS ObtenerImpuestoPorId(int idimp)
        {
            ImpuestoCLS objImpuestoCLS = new ImpuestoCLS();
            using (var db = new BDVentasEntities())
            {
                Impuesto oImpuesto = db.Impuesto.Where(p => p.IdImpuesto.Equals(idimp)).First();
                objImpuestoCLS.IdImpuesto = oImpuesto.IdImpuesto;
                objImpuestoCLS.NombreImpuesto = oImpuesto.NombreImpuesto;
                objImpuestoCLS.ValorImpuestoJS = oImpuesto.ValorImpuesto.ToString();
            }
            return objImpuestoCLS;
        }

        public int EditarImpuesto(ImpuestoCLS objImpuestoCls)
        {
            int cdgoRpt = 0;
            try
            {
                using (var db = new BDVentasEntities())
                {
                    Impuesto oImpuesto = db.Impuesto.Where(p => p.IdImpuesto.Equals(objImpuestoCls.IdImpuesto)).First();
                    oImpuesto.NombreImpuesto = objImpuestoCls.NombreImpuesto;
                    oImpuesto.ValorImpuesto = Decimal.Parse(objImpuestoCls.ValorImpuestoJS);

                    oImpuesto.FechaModificacion = DateTime.Now;
                    oImpuesto.UsuarioModificacion = "Admin";
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

