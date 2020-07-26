using System.Collections.Generic;
using Datos.Clases;
using Entidad;

namespace Negocio
{
    public class TipoTiendaNE
    {
        private static TipoTiendaDA obj = new TipoTiendaDA();

        public List<TipoTiendaCLS> ListarTipoTiendas()
        {
            return obj.ListarTipoTiendas();
        }

        public int AgregarTipoTienda(TipoTiendaCLS objTipoTiendaCls)
        {
            return obj.AgregarTipoTienda(objTipoTiendaCls);
        }
        public int CambiarEstadoTipoTienda(TipoTiendaCLS objTipoTiendaCls)
        {
            return obj.CambiarEstadoTipoTienda(objTipoTiendaCls);
        }
        public List<TipoTiendaCLS> ListarTipoTiendasPorFiltro(FiltroCLS objFiltro)
        {
            return obj.ListarTipoTiendaPorFiltro(objFiltro);
        }
        public int EliminarTipoTienda(TipoTiendaCLS objTipoTiendaCls)
        {
            return obj.EliminarTipoTienda(objTipoTiendaCls);
        }
        public TipoTiendaCLS ObtenerTipoTiendaPorId(int IdTipoTienda)
        {
            return obj.ObtenerTipoTiendaPorId(IdTipoTienda);
        }
        public int EditarTipoTienda(TipoTiendaCLS objTipoTiendaCls)
        {
            return obj.EditarTipoTienda(objTipoTiendaCls);
        }
    }
}
