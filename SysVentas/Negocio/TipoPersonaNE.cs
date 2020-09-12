using System.Collections.Generic;
using Datos.Clases;
using Entidad;

namespace Negocio
{
    public class TipoPersonaNE
    {
        private static TipoPersonaDA obj = new TipoPersonaDA();

        public List<TipoPersonaCLS> ListarTipoPersona()
        {
            return obj.ListarTipoPersona();
        }

        public int AgregarTipoPersona(TipoPersonaCLS objTipoPersonaCls)
        {
            return obj.AgregarTipoPersona(objTipoPersonaCls);
        }
        public int CambiarEstadoTipoPersona(TipoPersonaCLS objTipoPersonaCls)
        {
            return obj.CambiarEstadoTipoPersona(objTipoPersonaCls);
        }
        public List<TipoPersonaCLS> ListarTipoPersonaPorFiltro(FiltroCLS objFiltro)
        {
            return obj.ListarTipoPersonaPorFiltro(objFiltro);
        }
        public int EliminarTipoPersona(TipoPersonaCLS objTipoPersonaCls)
        {
            return obj.EliminarTipoPersona(objTipoPersonaCls);
        }
        public TipoPersonaCLS ObtenerTipoPersonaPorId(int IdTipoPersona)
        {
            return obj.ObtenerTipoPersonaPorId(IdTipoPersona);
        }
        public int EditarTipoPersona(TipoPersonaCLS objTipoPersonaCls)
        {
            return obj.EditarTipoPersona(objTipoPersonaCls);
        }

    }
}
