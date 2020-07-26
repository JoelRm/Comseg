using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Datos.Clases;
using Entidad;

namespace Negocio
{
    public class MonedaNE
    {
        private static MonedaDA obj = new MonedaDA();

        public List<MonedaCLS> ListarMonedas()
        {
            return obj.ListarMonedas();
        }

        public int AgregarMoneda(MonedaCLS objMonedaCls)
        {
            return obj.AgregarMoneda(objMonedaCls);
        }
        public int CambiarEstadoMoneda(MonedaCLS objMonedaCls)
        {
            return obj.CambiarEstadoMoneda(objMonedaCls);
        }
        public List<MonedaCLS> ListarMonedasPorFiltro(FiltroCLS objFiltro)
        {
            return obj.ListarMonedasPorFiltro(objFiltro);
        }
        public int EliminarMoneda(MonedaCLS objMonedaCls)
        {
            return obj.EliminarMonedas(objMonedaCls);
        }
        public MonedaCLS ObtenerMonedaPorId(int IdMoneda)
        {
            return obj.ObtenerMonedaPorId(IdMoneda);
        }
        public int EditarMoneda(MonedaCLS objMonedaCls)
        {
            return obj.EditarMoneda(objMonedaCls);
        }
    }
}
