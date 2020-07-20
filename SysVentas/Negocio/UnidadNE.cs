using Datos.Clases;
using Entidad;
using System.Collections.Generic;
namespace Negocio
{
    public class UnidadNE
    {
        private static UnidadDA obj = new UnidadDA();

        public List<UnidadCLS> ListarUnidades()
        {
            return obj.ListarUnidades();
        }

        public int AgregarUnidad(UnidadCLS objUnidadCls)
        {
            return obj.AgregarUnidad(objUnidadCls);
        }

        public int CambiarEstado(UnidadCLS objunidadCLS)
        {
            return obj.CambiarEstado(objunidadCLS);
        }

        public List<UnidadCLS> ListarUnidadesPorFiltro(FiltroCLS objFiltro)
        {
            return obj.ListarUnidadesPorFiltro(objFiltro);
        }
    }
}
