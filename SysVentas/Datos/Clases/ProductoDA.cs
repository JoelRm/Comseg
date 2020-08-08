using System;
using System.Collections.Generic;
using System.Linq;
using Datos.Modelos;
using Entidad;

namespace Datos.Clases
{
    public class ProductoDA
    {
        public List<ProductoCLS> ListarProductosPorFiltro(FiltroCLS objFiltro)
        {
            List<ProductoCLS> listaProducto = null;
            bool estado = true;
            if (objFiltro.Estado == 0)
                estado = false;

            using (var db = new BDVentasEntities())
            {
                if (objFiltro.Nombre == "" || objFiltro.Nombre == null)
                {
                    if (objFiltro.Estado == 2)
                    {
                        listaProducto = (from prd in db.Producto
                                         join lin in db.Linea on prd.IdLinea equals (lin.IdLinea)
                                         join mar in db.Marca on prd.IdMarca equals (mar.IdMarca)
                                         join prov in db.Proveedor on prd.IdProveedor equals(prov.IdProveedor)
                                         where prd.EstadoEliminacion == false
                                         select new ProductoCLS
                                         {
                                             CodigoProducto = prd.CodigoProducto,
                                             NombreProducto = prd.NombreProducto,
                                             IdProducto = prd.IdProducto,
                                             NombreLinea = lin.NombreLinea,
                                             NombreMarca = mar.NombreMarca,
                                             EstadoProducto = prd.EstadoProducto,
                                             NombreProveedor = prov.NombreProveedor
                                         }).ToList();
                    }
                    else
                    {
                        listaProducto = (from prd in db.Producto
                                         join lin in db.Linea on prd.IdLinea equals (lin.IdLinea)
                                         join mar in db.Marca on prd.IdMarca equals (mar.IdMarca)
                                         join prov in db.Proveedor on prd.IdProveedor equals (prov.IdProveedor)
                                         where prd.EstadoProducto == estado & prd.EstadoEliminacion == false
                                         select new ProductoCLS
                                         {
                                             CodigoProducto = prd.CodigoProducto,
                                             NombreProducto = prd.NombreProducto,
                                             IdProducto = prd.IdProducto,
                                             NombreLinea = lin.NombreLinea,
                                             NombreMarca = mar.NombreMarca,
                                             EstadoProducto = prd.EstadoProducto,
                                             NombreProveedor = prov.NombreProveedor
                                         }).ToList();
                    }
                }
                else
                {
                    if (objFiltro.Estado == 2)
                    {
                        listaProducto = (from prd in db.Producto
                                         join lin in db.Linea on prd.IdLinea equals (lin.IdLinea)
                                         join mar in db.Marca on prd.IdMarca equals (mar.IdMarca)
                                         join prov in db.Proveedor on prd.IdProveedor equals (prov.IdProveedor)
                                         where prd.EstadoEliminacion == false && prd.NombreProducto.Contains(objFiltro.Nombre)
                                         select new ProductoCLS
                                         {
                                             CodigoProducto = prd.CodigoProducto,
                                             NombreProducto = prd.NombreProducto,
                                             IdProducto = prd.IdProducto,
                                             NombreLinea = lin.NombreLinea,
                                             NombreMarca = mar.NombreMarca,
                                             EstadoProducto = prd.EstadoProducto,
                                             NombreProveedor = prov.NombreProveedor
                                         }).ToList();
                    }
                    else
                    {
                        listaProducto = (from prd in db.Producto
                                         join lin in db.Linea on prd.IdLinea equals (lin.IdLinea)
                                         join mar in db.Marca on prd.IdMarca equals (mar.IdMarca)
                                         join prov in db.Proveedor on prd.IdProveedor equals (prov.IdProveedor)
                                         where prd.EstadoEliminacion == false && prd.NombreProducto.Contains(objFiltro.Nombre) && prd.EstadoProducto == estado
                                         select new ProductoCLS
                                         {
                                             CodigoProducto = prd.CodigoProducto,
                                             NombreProducto = prd.NombreProducto,
                                             IdProducto = prd.IdProducto,
                                             NombreLinea = lin.NombreLinea,
                                             NombreMarca = mar.NombreMarca,
                                             EstadoProducto = prd.EstadoProducto,
                                             NombreProveedor = prov.NombreProveedor
                                         }).ToList();
                    }
                }
            }
            return listaProducto;
        }

        public int AgregarProducto(ProductoCLS objProductoCLS)
        {
            int CodResult = 0;
            var productoUnidad = objProductoCLS.CadenaUnd.Split('|');
            var productoAlmacen = objProductoCLS.CadenaAlm.Split('|');
            try
            {
                using (var db = new BDVentasEntities())
                {
                    //INI PRODUCTO
                    Producto objProducto = new Producto();
                    objProducto.CodigoProducto = objProductoCLS.CodigoProducto;
                    objProducto.NombreProducto = objProductoCLS.NombreProducto;
                    objProducto.IdLinea = objProductoCLS.IdLinea;
                    objProducto.IdMarca = objProductoCLS.IdMarca;
                    objProducto.IdMoneda = objProductoCLS.IdMoneda;
                    objProducto.IdImpuesto = objProductoCLS.IdImpuesto;
                    objProducto.IdProveedor = objProductoCLS.IdProveedor;
                    objProducto.EstadoEliminacion = false;
                    objProducto.FechaCreacion = DateTime.Now;
                    objProducto.UsuarioCreacion = "Admin";
                    objProducto.FechaModificacion = DateTime.Now;
                    objProducto.UsuarioModificacion = "Admin";
                    objProducto.EstadoProducto = true;
                    db.Producto.Add(objProducto);
                    db.SaveChanges();

                    var IdProducto = objProducto.IdProducto;
                    //FIN PRODUCTO

                    //INI PRODUCTO UNIDAD
                    for (int i = 0; i < productoUnidad.Length; i++)
                    {
                        var PrdUnd = productoUnidad[i].Split(',');
                        ProductoUnidad objProdUnd = new ProductoUnidad();
                        objProdUnd.IdProducto = IdProducto;
                        objProdUnd.IdUnidad = int.Parse(PrdUnd[0]);
                        objProdUnd.IsUnidadBase = bool.Parse(PrdUnd[1]);
                        objProdUnd.IsUnidadVenta = bool.Parse(PrdUnd[2]);
                        objProdUnd.EstadoProductoUnidad = bool.Parse(PrdUnd[3]);
                        objProdUnd.FechaCreacion = DateTime.Now;
                        objProdUnd.UsuarioCreacion = "Admin";
                        objProdUnd.FechaModificacion = DateTime.Now;
                        objProdUnd.UsuarioModificacion = "Admin";
                        objProdUnd.EstadoEliminacion = false;
                        db.ProductoUnidad.Add(objProdUnd);
                        db.SaveChanges();
                    }
                    //FIN PRODUCTO UNIDAD

                    //INI PRODUCTO ALMACÉN
                    List<SucursalCLS> lsSucursal = new List<SucursalCLS>();

                    for (int i = 0; i < productoAlmacen.Length; i++)
                    {
                        var prdPrdAlm = productoAlmacen[i].Split(',');

                        lsSucursal.Add(new SucursalCLS { IdSucursal = int.Parse(prdPrdAlm[1]) });

                        ProductoAlmacen objPrdAlm = new ProductoAlmacen();
                        objPrdAlm.IdProducto = IdProducto;
                        objPrdAlm.IdAlmacen = int.Parse(prdPrdAlm[0]);
                        objPrdAlm.IsActivo = bool.Parse(prdPrdAlm[2]);
                        objPrdAlm.StockFisico = 0;
                        objPrdAlm.StockSistema = 0;
                        objPrdAlm.FechaCreacion = DateTime.Now;
                        objPrdAlm.UsuarioCreacion = "Admin";
                        objPrdAlm.FechaModificacion = DateTime.Now;
                        objPrdAlm.UsuarioModificacion = "Admin";
                        objPrdAlm.EstadoEliminación = false;
                        db.ProductoAlmacen.Add(objPrdAlm);
                        db.SaveChanges();
                    }
                    //FIN PRODUCTO ALMACÉN

                    //INI PRODUCTO SUCURSAL COSTO
                    List<int> PrdSuc = null;
                    PrdSuc = lsSucursal.Select(x => x.IdSucursal).Distinct().ToList();

                    for (int i = 0; i < PrdSuc.Count; i++)
                    {
                        ProductoSucursalCosto objPrdSucCost = new ProductoSucursalCosto();
                        objPrdSucCost.IdSucursal = PrdSuc[i];
                        objPrdSucCost.IdProducto = objProducto.IdProducto;
                        objPrdSucCost.CostoUnitario = 0;
                        db.ProductoSucursalCosto.Add(objPrdSucCost);
                        db.SaveChanges();
                    }

                    //FIN PRODUCTO SUCURSAL COSTO

                    CodResult = 1;
                }
            }
            catch (Exception ex)
            {
                CodResult = 0;
            }
            return CodResult;
        }
    }
}
