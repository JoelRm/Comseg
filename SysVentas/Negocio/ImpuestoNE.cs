using System.Collections.Generic;
using Datos.Clases;
using Entidad;

namespace Negocio
{
    public class ImpuestoNE
    {
        private static ImpuestoDA obj = new ImpuestoDA();

        public List<ImpuestoCLS> ListarImpuesto()
        {
            return obj.ListarImpuesto();
        }

        public int AgregarImpuesto(ImpuestoCLS objImpuestoCls)
        {
            return obj.AgregarImpuesto(objImpuestoCls);
        }

        public int CambiarEstado(ImpuestoCLS objImpuestoCLS)
        {
            return obj.CambiarEstado(objImpuestoCLS);
        }

        public List<ImpuestoCLS> ListarImpuestoPorFiltro(FiltroCLS objFiltro)
        {
            return obj.ListarImpuestoPorFiltro(objFiltro);
        }

        public int EliminarImpuesto(ImpuestoCLS objImpuestoCLS)
        {
            return obj.EliminarImpuesto(objImpuestoCLS);
        }

        public ImpuestoCLS ObtenerImpuestoPorId(int idUnd)
        {
            return obj.ObtenerImpuestoPorId(idUnd);
        }

        public int EditarImpuesto(ImpuestoCLS objImpuestoCls)
        {
            return obj.EditarImpuesto(objImpuestoCls);
        }
    }
}
