using System;
using System.Collections.Generic;
using System.Linq;
using Entidad;
using Datos.Modelos;

namespace Datos.Clases
{
    public class ClienteDA
    {
        public List<ClienteCLS> ListarCliente()
        {
            List<ClienteCLS> listaCliente = null;
            using (var db = new BDVentasEntities())
            {
                listaCliente = (from cli in db.Cliente
                                where cli.EstadoEliminacion == false
                                select new ClienteCLS
                                {
                                    IdCliente = cli.IdCliente,
                                    IdTipoPersona = cli.IdTipoPersona,
                                    NroDocumentoCliente = cli.NroDocumentoCliente,
                                    NombreCliente = cli.NombreCliente,
                                    DireccionCliente = cli.DireccionCliente,
                                    NumeroContactoCliente = cli.NumeroContactoCliente,
                                    FechaCreacion = cli.FechaCreacion,
                                    UsuarioCreacion = cli.UsuarioCreacion,
                                    FechaModificacion = cli.FechaModificacion,
                                    UsuarioModificacion = cli.UsuarioModificacion,
                                    EstadoCliente = cli.EstadoCliente,
                                    FechaCreacionJS = cli.FechaCreacion.ToString()

                                }).ToList();
                return listaCliente;
            }
        }

        public int AgregarCliente(ClienteCLS objClienteCls)
        {
            int CodResult = 0;
            try
            {
                using (var db = new BDVentasEntities())
                {
                    Cliente objCliente = new Cliente();
                    objCliente.IdTipoPersona = objClienteCls.IdTipoPersona;
                    objCliente.NroDocumentoCliente = objClienteCls.NroDocumentoCliente;
                    objCliente.NombreCliente = objClienteCls.NombreCliente;
                    objCliente.DireccionCliente = objClienteCls.DireccionCliente;
                    objCliente.NumeroContactoCliente = objClienteCls.NumeroContactoCliente;
                    objCliente.FechaCreacion = DateTime.Now;
                    objCliente.UsuarioCreacion = "Admin";
                    objCliente.FechaModificacion = DateTime.Now;
                    objCliente.UsuarioModificacion = "Admin";
                    objCliente.EstadoCliente = true;
                    objCliente.EstadoEliminacion = false;
                    db.Cliente.Add(objCliente);
                    db.SaveChanges();
                    CodResult = 1;



                }

            }
            catch (Exception e)
            {
                CodResult = 0;
            }
            return CodResult;
        }

        public int CambiarEstado(ClienteCLS objClienteCls)
        {
            int codigoRpt = 0;
            try
            {
                using (var db = new BDVentasEntities())
                {
                    Cliente oCliente = db.Cliente.Where(p => p.IdCliente.Equals(objClienteCls.IdCliente)).First();
                    if (oCliente.EstadoCliente)
                        objClienteCls.EstadoCliente = false;
                    else
                        objClienteCls.EstadoCliente = true;

                    oCliente.EstadoCliente = objClienteCls.EstadoCliente;
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

        public List<ClienteCLS> ListarClientePorFiltro(FiltroCLS objFiltro)
        {
            List<ClienteCLS> listaCliente = null;
            bool estado = true;
            if (objFiltro.Estado == 0)
                estado = false;

            using (var db = new BDVentasEntities())
            {
                if (objFiltro.Nombre == "" || objFiltro.Nombre == null)
                {
                    if (objFiltro.Estado == 2)
                    {
                        listaCliente = (from cli in db.Cliente join TipoT in db.TipoPersona on cli.IdTipoPersona equals TipoT.IdTipoPersona
                                        where cli.EstadoEliminacion == false
                                        select new ClienteCLS
                                        {
                                            IdCliente = cli.IdCliente,
                                            IdTipoPersona = cli.IdTipoPersona,
                                            NroDocumentoCliente = cli.NroDocumentoCliente,
                                            NombreCliente = cli.NombreCliente,
                                            DireccionCliente = cli.DireccionCliente,
                                            NumeroContactoCliente = cli.NumeroContactoCliente,
                                            FechaCreacion = cli.FechaCreacion,
                                            EstadoCliente = cli.EstadoCliente,
                                            UsuarioCreacion = cli.UsuarioCreacion,
                                            FechaModificacion = cli.FechaModificacion,
                                            UsuarioModificacion = cli.UsuarioModificacion,
                                            FechaCreacionJS = cli.FechaCreacion.ToString(),
                                            NombreTipoCliente = TipoT.NombreTipoPersona.ToString()
                                        }).ToList();
                    }
                    else
                    {
                        listaCliente = (from cli in db.Cliente
                                        join TipoT in db.TipoPersona on cli.IdTipoPersona equals TipoT.IdTipoPersona
                                        where cli.EstadoEliminacion == false && cli.EstadoCliente == estado
                                        select new ClienteCLS
                                        {
                                            IdCliente = cli.IdCliente,
                                            IdTipoPersona = cli.IdTipoPersona,
                                            NroDocumentoCliente = cli.NroDocumentoCliente,
                                            NombreCliente = cli.NombreCliente,
                                            DireccionCliente = cli.DireccionCliente,
                                            NumeroContactoCliente = cli.NumeroContactoCliente,
                                            FechaCreacion = cli.FechaCreacion,
                                            EstadoCliente = cli.EstadoCliente,
                                            UsuarioCreacion = cli.UsuarioCreacion,
                                            FechaModificacion = cli.FechaModificacion,
                                            UsuarioModificacion = cli.UsuarioModificacion,
                                            FechaCreacionJS = cli.FechaCreacion.ToString(),
                                            NombreTipoCliente = TipoT.NombreTipoPersona.ToString()
                                        }).ToList();
                    }

                }
                else
                {
                    if (objFiltro.Estado == 2)
                    {
                        listaCliente = (from cli in db.Cliente
                                        join TipoT in db.TipoPersona on cli.IdTipoPersona equals TipoT.IdTipoPersona
                                        where cli.EstadoEliminacion == false && cli.NombreCliente.Contains(objFiltro.Nombre)
                                        select new ClienteCLS
                                        {
                                            IdCliente = cli.IdCliente,
                                            IdTipoPersona = cli.IdTipoPersona,
                                            NroDocumentoCliente = cli.NroDocumentoCliente,
                                            NombreCliente = cli.NombreCliente,
                                            DireccionCliente = cli.DireccionCliente,
                                            NumeroContactoCliente = cli.NumeroContactoCliente,
                                            FechaCreacion = cli.FechaCreacion,
                                            EstadoCliente = cli.EstadoCliente,
                                            UsuarioCreacion = cli.UsuarioCreacion,
                                            FechaModificacion = cli.FechaModificacion,
                                            UsuarioModificacion = cli.UsuarioModificacion,
                                            FechaCreacionJS = cli.FechaCreacion.ToString(),
                                            NombreTipoCliente = TipoT.NombreTipoPersona.ToString()
                                        }).ToList();
                    }
                    else
                    {
                        listaCliente = (from cli in db.Cliente
                                        join TipoT in db.TipoPersona on cli.IdTipoPersona equals TipoT.IdTipoPersona
                                        where cli.EstadoEliminacion == false && cli.EstadoCliente == estado && cli.NombreCliente.Contains(objFiltro.Nombre) && cli.EstadoCliente == estado
                                        select new ClienteCLS
                                        {
                                            IdCliente = cli.IdCliente,
                                            IdTipoPersona = cli.IdTipoPersona,
                                            NroDocumentoCliente = cli.NroDocumentoCliente,
                                            NombreCliente = cli.NombreCliente,
                                            DireccionCliente = cli.DireccionCliente,
                                            NumeroContactoCliente = cli.NumeroContactoCliente,
                                            FechaCreacion = cli.FechaCreacion,
                                            EstadoCliente = cli.EstadoCliente,
                                            UsuarioCreacion = cli.UsuarioCreacion,
                                            FechaModificacion = cli.FechaModificacion,
                                            UsuarioModificacion = cli.UsuarioModificacion,
                                            FechaCreacionJS = cli.FechaCreacion.ToString(),
                                            NombreTipoCliente = TipoT.NombreTipoPersona.ToString()
                                        }).ToList();
                    }
                }

            }
            return listaCliente;
        }

        public int EliminarCliente(ClienteCLS objClienteCls)
        {
            int cdgoRpt = 0;
            try
            {
                using (var db = new BDVentasEntities())
                {
                    Cliente oCliente = db.Cliente.Where(p => p.IdCliente.Equals(objClienteCls.IdCliente)).First();
                    oCliente.EstadoEliminacion = true;
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

        public ClienteCLS ObtenerClientePorId(int idcli)
        {
            ClienteCLS objClienteCls = new ClienteCLS();
            using (var db = new BDVentasEntities())
            {
                Cliente oCliente = db.Cliente.Where(p => p.IdCliente.Equals(idcli)).First();
                objClienteCls.IdCliente = oCliente.IdCliente;
                objClienteCls.NombreCliente = oCliente.NombreCliente;
                objClienteCls.NroDocumentoCliente = oCliente.NroDocumentoCliente;
                objClienteCls.DireccionCliente = oCliente.DireccionCliente;
                objClienteCls.NumeroContactoCliente = oCliente.NumeroContactoCliente;
                objClienteCls.IdTipoPersona = oCliente.IdTipoPersona;
            }
            return objClienteCls;
        }

        public int EditarCliente(ClienteCLS objClienteCls)
        {
            int cdgoRpt = 0;
            try
            {
                using (var db = new BDVentasEntities())
                {
                    Cliente oCliente = db.Cliente.Where(p => p.IdCliente.Equals(objClienteCls.IdCliente)).First();
                    oCliente.NombreCliente = objClienteCls.NombreCliente;
                    oCliente.IdTipoPersona = objClienteCls.IdTipoPersona;
                    oCliente.DireccionCliente = objClienteCls.DireccionCliente;
                    oCliente.NombreCliente = objClienteCls.NombreCliente;
                    oCliente.NumeroContactoCliente = objClienteCls.NumeroContactoCliente;
                    oCliente.NroDocumentoCliente = objClienteCls.NroDocumentoCliente;
                    oCliente.FechaModificacion = DateTime.Now;
                    oCliente.UsuarioModificacion = "Admin";
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
