using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Datos.Clases;
using Entidad;
namespace Negocio
{
    public class SucursalNE
    {
        private static SucursalDA obj = new SucursalDA();

        public List<SucursalCLS> ListarSucursales()
        {
            return obj.ListarSucursales();
        }

        public int AgregarSucursal(SucursalCLS objSucursalCls)
        {
            return obj.AgregarSucursal(objSucursalCls);
        }

        public int CambiarEstado(SucursalCLS objSucursalCLS)
        {
            return obj.CambiarEstado(objSucursalCLS);
        }

        public List<SucursalCLS> ListarSucursalesPorFiltro(FiltroCLS objFiltro)
        {
            return obj.ListarSucursalesPorFiltro(objFiltro);
        }

        public int EliminarSucursal(SucursalCLS objSucursalCLS)
        {
            return obj.EliminarSucursal(objSucursalCLS);
        }

        public SucursalCLS ObtenerSucursalPorId(int idscl)
        {
            return obj.ObtenerSucursalPorId(idscl);
        }

        public int EditarSucursal(SucursalCLS objSucursalCls)
        {
            return obj.EditarSucursal(objSucursalCls);
        }
    }
}
