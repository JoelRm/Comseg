using Entidad;
using Datos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Datos.Clases
{
    public class MarcaDA
    {
        public List<MarcaCLS> ListarMarcas()
        {
            List<MarcaCLS> listaMarca = null;
            using (var db = new BDVentasEntities())
            {
                listaMarca = (from mca in db.Marca
                               where mca.EstadoEliminacion == false
                               select new MarcaCLS
                               {
                                   IdMarca = mca.IdMarca,
                                   NombreMarca = mca.NombreMarca,
                                   FechaCreacion = mca.FechaCreacion,
                                   UsuarioCreacion = mca.UsuarioCreacion,
                                   FechaModificacion = mca.FechaModificacion,
                                   UsuarioModificacion = mca.UsuarioModificacion,
                                   EstadoMarca = mca.EstadoMarca,
                                   FechaCreacionJS = mca.FechaCreacion.ToString()
                               }).ToList();

                return listaMarca;
            }
        }


        public int AgregarMarca(MarcaCLS objMarcaCls)
        {
            int CodResult = 0;
            try
            {
                using (var db = new BDVentasEntities())
                {
                    Marca objMarca = new Marca();
                    objMarca.NombreMarca = objMarcaCls.NombreMarca;
                    objMarca.FechaCreacion = DateTime.Now;
                    objMarca.UsuarioCreacion = "Admin";
                    objMarca.FechaModificacion = DateTime.Now;
                    objMarca.UsuarioModificacion = "Admin";
                    objMarca.EstadoMarca = true;
                    objMarca.EstadoEliminacion = false;
                    db.Marca.Add(objMarca);
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


        public int CambiarEstadoMarca(MarcaCLS objMarcaCls)
        {
            int codigoRpt = 0;
            try
            {
                using (var db = new BDVentasEntities())
                {
                    Marca oMarca = db.Marca.Where(p => p.IdMarca.Equals(objMarcaCls.IdMarca)).First();

                    if (oMarca.EstadoMarca)
                        objMarcaCls.EstadoMarca = false;
                    else
                        objMarcaCls.EstadoMarca = true;

                    oMarca.EstadoMarca = objMarcaCls.EstadoMarca;
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


        public List<MarcaCLS> ListarMarcaPorFiltro(FiltroCLS objFiltro)
        {
            List<MarcaCLS> listaMarca = null;
            bool estado = true;
            if (objFiltro.Estado == 0)
                estado = false;

            using (var db = new BDVentasEntities())
            {
                if (objFiltro.Nombre == "" || objFiltro.Nombre == null)
                {
                    if (objFiltro.Estado == 2)
                    {
                        listaMarca = (from mca in db.Marca
                                      where mca.EstadoEliminacion == false
                                      select new MarcaCLS
                                      {
                                          IdMarca = mca.IdMarca,
                                          NombreMarca = mca.NombreMarca,
                                          FechaCreacion = mca.FechaCreacion,
                                          UsuarioCreacion = mca.UsuarioCreacion,
                                          FechaModificacion = mca.FechaModificacion,
                                          UsuarioModificacion = mca.UsuarioModificacion,
                                          EstadoMarca = mca.EstadoMarca,
                                          FechaCreacionJS = mca.FechaCreacion.ToString()
                                      }).ToList();
                    }
                    else
                    {
                        listaMarca = (from mca in db.Marca
                                      where mca.EstadoEliminacion == false && mca.EstadoMarca == estado
                                      select new MarcaCLS
                                      {
                                          IdMarca = mca.IdMarca,
                                          NombreMarca = mca.NombreMarca,
                                          FechaCreacion = mca.FechaCreacion,
                                          UsuarioCreacion = mca.UsuarioCreacion,
                                          FechaModificacion = mca.FechaModificacion,
                                          UsuarioModificacion = mca.UsuarioModificacion,
                                          EstadoMarca = mca.EstadoMarca,
                                          FechaCreacionJS = mca.FechaCreacion.ToString()
                                      }).ToList();
                    }
                }
                else
                {
                    if (objFiltro.Estado == 2)
                    {
                        listaMarca = (from mca in db.Marca
                                      where mca.EstadoEliminacion == false && mca.NombreMarca.Contains(objFiltro.Nombre)
                                      select new MarcaCLS
                                      {
                                          IdMarca = mca.IdMarca,
                                          NombreMarca = mca.NombreMarca,
                                          FechaCreacion = mca.FechaCreacion,
                                          UsuarioCreacion = mca.UsuarioCreacion,
                                          FechaModificacion = mca.FechaModificacion,
                                          UsuarioModificacion = mca.UsuarioModificacion,
                                          EstadoMarca = mca.EstadoMarca,
                                          FechaCreacionJS = mca.FechaCreacion.ToString()
                                      }).ToList();
                    }
                    else
                    {
                        listaMarca = (from mca in db.Marca
                                      where mca.EstadoEliminacion == false && mca.EstadoMarca == estado && mca.NombreMarca.Contains(objFiltro.Nombre) && mca.EstadoMarca == estado
                                      select new MarcaCLS
                                      {
                                          IdMarca = mca.IdMarca,
                                          NombreMarca = mca.NombreMarca,
                                          FechaCreacion = mca.FechaCreacion,
                                          UsuarioCreacion = mca.UsuarioCreacion,
                                          FechaModificacion = mca.FechaModificacion,
                                          UsuarioModificacion = mca.UsuarioModificacion,
                                          EstadoMarca = mca.EstadoMarca,
                                          FechaCreacionJS = mca.FechaCreacion.ToString()
                                      }).ToList();
                    }
                }
            }
            return listaMarca;
        }


        public int EliminarMarca(MarcaCLS objMarcaCls)
        {
            int cdgoRpt = 0;
            try
            {
                using (var db = new BDVentasEntities())
                {
                    Marca oMarca = db.Marca.Where(p => p.IdMarca.Equals(objMarcaCls.IdMarca)).First();
                    oMarca.EstadoEliminacion = true;
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


        public MarcaCLS ObtenerMarcaPorId(int idMarca)
        {
            MarcaCLS objMarcaCls = new MarcaCLS();
            using (var db = new BDVentasEntities())
            {
                Marca oMarca = db.Marca.Where(p => p.IdMarca.Equals(idMarca)).First();
                objMarcaCls.IdMarca = oMarca.IdMarca;
                objMarcaCls.NombreMarca = oMarca.NombreMarca;
            }
            return objMarcaCls;
        }


        public int EditarMarca(MarcaCLS objMarcaCls)
        {
            int cdgoRpt = 0;
            try
            {
                using (var db = new BDVentasEntities())
                {
                    Marca oMarca = db.Marca.Where(p => p.IdMarca.Equals(objMarcaCls.IdMarca)).First();
                    oMarca.NombreMarca = objMarcaCls.NombreMarca;
                    oMarca.FechaModificacion = DateTime.Now;
                    oMarca.UsuarioModificacion = "Admin";
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
