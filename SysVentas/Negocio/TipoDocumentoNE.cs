using Datos.Clases;
using Entidad;
using System.Collections.Generic;

namespace Negocio
{
    public class TipoDocumentoNE
    {
        private static TipoDocumentoDA obj = new TipoDocumentoDA();

        public List<TipoDocumentoCLS> ListarTipoDocumento()
        {
            return obj.ListarTipoDocumento();
        }

        public int AgregarTipoDocumento(TipoDocumentoCLS objTipoDocumentoCLS)
        {
            return obj.AgregarTipoDocumento(objTipoDocumentoCLS);
        }
        public int CambiarEstadoTipoDocumento(TipoDocumentoCLS objTipoDocumentoCLS)
        {
            return obj.CambiarEstadoTipoDocumento(objTipoDocumentoCLS);
        }
        public List<TipoDocumentoCLS> ListarTipoDocumentoPorFiltro(FiltroCLS objFiltro)
        {
            return obj.ListarTipoDocumentoPorFiltro(objFiltro);
        }
        public int EliminarTipoDocumento(TipoDocumentoCLS objTipoDocumentoCLS)
        {
            return obj.EliminarTipoDocumento(objTipoDocumentoCLS);
        }
        public TipoDocumentoCLS ObtenerTipoDocumentoPorId(int idTipoDocumento)
        {
            return obj.ObtenerTipoDocumentoPorId(idTipoDocumento);
        }
        public int EditarTipoDocumento(TipoDocumentoCLS objTipoDocumentoCLS)
        {
            return obj.EditarTipoDocumento(objTipoDocumentoCLS);
        }

    }
}
