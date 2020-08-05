using Datos.Clases;
using Entidad;
using System.Collections.Generic;

namespace Negocio
{
    public class ProveedorNE
    {
        ProveedorDA objProveedorDA = new ProveedorDA();

        public int AgregarProveedor(ProveedorCLS objProveedorCLS)
        {
            return objProveedorDA.AgregarProveedor(objProveedorCLS);
        }

        public List<ProveedorCLS> ListarProveedorPorFiltro(FiltroCLS objFiltro)
        {
            return objProveedorDA.ListarProveedorPorFiltro(objFiltro);
        }

        public ProveedorCLS ObtenerProveedorPorId(int idProv)
        {
            return objProveedorDA.ObtenerProveedorPorId(idProv);
        }

        public int EliminarProveedor(ProveedorCLS objProveedorCLS)
        {
            return objProveedorDA.EliminarProveedor(objProveedorCLS);
        }

        public int CambiarEstadoProveedor(ProveedorCLS objProveedorCLS)
        {
            return objProveedorDA.CambiarEstadoProveedor(objProveedorCLS);
        }

        public int EditarProveedor(ProveedorCLS objProveedorCLS)
        {
            return objProveedorDA.EditarProveedor(objProveedorCLS);
        }

    }
}
